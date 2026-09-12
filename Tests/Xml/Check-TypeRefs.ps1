<#
.SYNOPSIS
  Finds references to a C# TYPE written as the text of an XML element, pointing at a class that
  is neither RimWorld's nor the mod's own, with nothing guarding it.

.DESCRIPTION
  HOW THIS DIFFERS FROM Check-XmlClasses.ps1. They read the same shapes and answer different
  questions, so both are worth running:

    - Check-XmlClasses.ps1 asks **does this type exist?** You hand it type lists dumped from
      RimWorld and from the mod's dependencies, and it catches a name that resolves to nothing:
      a typo, or a namespace rename half-applied. It found seventeen renamed `<placeWorkers>`
      entries and an eighteenth that was not, on 2026-09-10.
    - This one asks **is this cross-mod reference guarded?** It needs no type lists. A name that
      resolves perfectly well - because you have the mod installed - is still a finding here if
      nothing stops the line from being read when that mod is absent.

  A type that exists on your machine and is unguarded passes the first and fails the second; a
  typo in a guarded line fails the first and passes the second. Neither subsumes the other.

  One overlap worth knowing about: both discover the `List<Type>` element names by reflection, so
  that snippet now lives in two files. Check-XmlClasses.ps1 also keeps a hand-written
  `$ClassTags` of 28 single-`Type` field names where reflection finds 71, deliberately, because
  three of the 71 are ambiguous. This script takes the full reflected set and drops those three
  by detecting them, which is the follow-up its author left open.

  Check-XmlFields.ps1 checks that an element maps to a field; Check-DefRefs.ps1 that a referenced
  def exists. None of the four looks at a type named in an element's TEXT, and that is a blind
  spot with teeth:

      <inspectorTabs>
        <li>SoftWarmBeds.ITab_Bedding</li>     <- no attribute, no field name ending in Class
      </inspectorTabs>

  There is no `Class=` to key on and the field is not called `*Class`, so a sweep written around
  either of those misses it entirely. It was missed exactly that way on Soft Warm Primitive Beds,
  where two such lines could take three of Primitive Workbenches' beds out of the game.

  WHAT IT COSTS TO GET WRONG, in 1.6:

    - Type named in element text, unresolvable. `ParseHelper.ParseType` logs and returns null.
      The def parses, then dies later: `InspectTabManager.GetSharedInstance` has no null guard,
      `Dictionary.TryGetValue(null)` throws inside `ThingDef.ResolveReferences`, and
      `DefDatabase.ResolveAllReferences` catches it per def - the load survives, the def is
      abandoned part-resolved.
    - `Class="..."` unresolvable. Worse. A def whose type is registered is built by
      `DirectXmlToObjectNew`, whose `ResolveTypeForNode` throws an `ArgumentException`: the def is
      lost outright. The old forgiving path (`DirectXmlToObject.ClassTypeOf`, which falls back to
      the declared field type) still exists but no longer loads defs.

  Both are checked here. The element names are not a hand-written list - they come from
  reflection over the 1.6 assembly: every field whose type is `Type` or `List<Type>`, which is 80
  names, 9 of them lists, once the compiler-generated ones are dropped. A hand-written list is how
  this gets missed; one audit of this repository listed `jobDriver`, which is not a field at all
  (it is `driverClass`).

  WHAT COUNTS AS A GUARD. Four things, and a declared `modDependencies` entry is NOT one of them:
  RimWorld shows a dialog for a missing dependency and lets the player start anyway.

    - `MayRequire` / `MayRequireAnyOf` on the element or its list container. Read by
      `DirectXmlToObject.ListFromXml` and `ObjectFromXml`. Note that it is NOT spell-checked for a
      player: `DirectXmlCrossRefLoader.MistypedMayRequire` opens with `if (Application.isEditor)`.
      This script re-reads every packageId against the installed mods and says so when one matches
      nothing - which is the check the game will not do for you.
    - An ancestor `PatchOperationFindMod`.
    - An ancestor `PatchOperationConditional`, or a `PatchOperationTest` earlier in the same
      `PatchOperationSequence`. Both make the block conditional on something the optional mod
      declares. PropsInUse and JoyPreservation guard their Musical Instruments comps this way.
    - A `LoadFolders.xml` entry with `IfModActive`, `IfModActiveAll` or `IfModActiveAny` naming
      the folder the file sits in. ProcessorFrameworkVCE guards its add-ons this way.

  KNOWN BLIND SPOT. A patch that adds a type reference to a def belonging to the optional mod is
  guarded by construction - if the mod is absent the xpath matches nothing and the value is never
  inserted - and this script cannot see that. It costs a red line per startup rather than a broken
  def, so such a hit is worth reading rather than worth fixing blind.

  WHAT TO DO WITH A FINDING. Not every unguarded reference is a fault. The line that matters is
  whose def gets damaged:

    - The def belongs to ANOTHER mod (you are patching it): guard it. Breaking a third party is
      the one outcome a compat patch must not have.
    - The def is your own, in a mod that cannot run without the framework anyway: a guard buys
      little, and half a guard is worse than none. Medieval Homestead's wine barrel names
      `PipeSystem.ITab_Processor` unguarded, but it also carries a `PipeSystem` comp through
      `Class=`, so without Vanilla Expanded Framework the def is lost either way; guarding the tab
      alone would leave a barrel with no processor.

.PARAMETER ModPath
  A mod folder, or the repository root to sweep every mod at once. The owning mod of each file is
  found by walking up to the nearest folder holding About/About.xml, so both work, and so do mods
  nested inside another folder.

.PARAMETER ResolveOwner
  Name the mod that DEFINES each unresolved type, by scanning the Workshop content folder, and say
  whether the referencing mod declares it in modDependencies. Off by default; about a minute for
  one mod, a few for the whole repository.

  It confirms rather than guesses. A string search alone cannot tell a TypeDef from a TypeRef, so
  a mod that merely uses a type matches as well as the one that declares it - the first version of
  this named a consumer as the author of four types out of five. Candidates found by string are
  now reflection-only loaded and asked what they actually define, and a type no assembly claims is
  reported as UNCONFIRMED, with the list of mods the name was seen in, rather than pinned on one
  of them.

.PARAMETER All
  Also list the references that are guarded, and the ones pointing at the mod's own classes.

.EXAMPLE
  pwsh -File Check-TypeRefs.ps1 -ModPath C:\Users\nelim\Documents\rimworld\SoftWarmPrimitiveBedsRenew

.EXAMPLE
  The whole repository, with the owning mod of every unresolved type spelled out:

  pwsh -File Check-TypeRefs.ps1 -ModPath C:\Users\nelim\Documents\rimworld -ResolveOwner
#>
param(
    [Parameter(Mandatory=$true)][string]$ModPath,
    [string]$Managed  = 'C:\Program Files (x86)\Steam\steamapps\common\RimWorld\RimWorldWin64_Data\Managed',
    [string]$Workshop = 'C:\Program Files (x86)\Steam\steamapps\workshop\content\294100',
    # Assemblies whose types are to be treated as available, like Check-XmlFields.ps1's parameter
    # of the same name. Use it for a framework you have decided not to guard against.
    [string[]]$ExtraAssemblies = @(),
    [switch]$ResolveOwner,
    [switch]$All
)

$ErrorActionPreference = 'Stop'

# Same handler, same guard, same reason as Check-XmlFields.ps1: a framework assembly references
# Assembly-CSharp by name, .NET only looks next to this script, and an unresolvable name asked
# for twice recurses to a stack overflow rather than to an error.
$probeDirs = @($Managed) + @($ExtraAssemblies | ForEach-Object { Split-Path -Parent $_ }) | Select-Object -Unique
$script:probed = @{}
$script:asmResolver = [System.ResolveEventHandler]{
    param($sender, $e)
    if ($null -eq $script:probed) { return $null }
    $short = $e.Name.Split(',')[0]
    if ($script:probed.ContainsKey($short)) { return $null }
    $script:probed[$short] = $true
    foreach ($d in $probeDirs) {
        $p = Join-Path $d "$short.dll"
        if (Test-Path $p) { return [System.Reflection.Assembly]::LoadFrom($p) }
    }
    return $null
}
[System.AppDomain]::CurrentDomain.add_AssemblyResolve($script:asmResolver)

# The reflection-only load context has its own resolve event and does NOT fall back to the one
# above. -ResolveOwner needs it: see the note beside ReflectionOnlyLoadFrom further down.
# $roProbeDirs is set per candidate assembly, so the mod's own folder is searched alongside the
# game's Managed folder.
$script:roProbeDirs = @($Managed)
$script:roResolver = [System.ResolveEventHandler]{
    param($sender, $e)
    if ($null -eq $script:roProbeDirs) { return $null }
    $short = $e.Name.Split(',')[0]
    foreach ($d in $script:roProbeDirs) {
        $p = Join-Path $d "$short.dll"
        if (Test-Path $p) { try { return [System.Reflection.Assembly]::ReflectionOnlyLoadFrom($p) } catch { return $null } }
    }
    try { return [System.Reflection.Assembly]::ReflectionOnlyLoad($e.Name) } catch { return $null }
}
[System.AppDomain]::CurrentDomain.add_ReflectionOnlyAssemblyResolve($script:roResolver)

function Get-AssemblyTypes([string]$path) {
    $a = [System.Reflection.Assembly]::LoadFrom($path)
    try     { return $a.GetTypes() }
    catch [System.Reflection.ReflectionTypeLoadException] { return $_.Exception.Types | Where-Object { $_ } }
    catch   { return $_.Exception.InnerException.Types | Where-Object { $_ } }
}

# ---------------------------------------------------------------------------------------------
# 1. the element names to look for, by reflection
# ---------------------------------------------------------------------------------------------
$types = Get-AssemblyTypes (Join-Path $Managed 'Assembly-CSharp.dll')

$typeT     = [System.Type]
$listTypeT = [System.Collections.Generic.List[System.Type]]
$flags     = [System.Reflection.BindingFlags]'Public,NonPublic,Instance'
$fieldKind = @{}
$otherKind = @{}
foreach ($t in $types) {
    try { $fs = $t.GetFields($flags) } catch { continue }
    foreach ($f in $fs) {
        # Compiler-generated backing fields and iterator locals are never element names.
        if ($f.Name -match '^[<_]') { continue }
        if     ($f.FieldType -eq $typeT)     { $fieldKind[$f.Name] = 'Type' }
        elseif ($f.FieldType -eq $listTypeT) { $fieldKind[$f.Name] = 'List<Type>' }
        else                                 { $otherKind[$f.Name] = $f.FieldType.Name }
    }
}
# A name vanilla also declares as something else is ambiguous, and this map is built from vanilla
# only - it cannot know that a mod's own class spells the same name with a different type. The
# Vehicle Framework's VehicleDef has a `type` field holding an enum, and `<type>Land</type>` was
# reported as a missing class until this dropped the name. Ambiguous names are skipped and named,
# rather than silently kept and wrong.
$ambiguous = @($fieldKind.Keys | Where-Object { $otherKind.ContainsKey($_) } | Sort-Object)
foreach ($a in $ambiguous) { $fieldKind.Remove($a) }
$listFieldCount = @($fieldKind.GetEnumerator() | Where-Object { $_.Value -eq 'List<Type>' }).Count

# ---------------------------------------------------------------------------------------------
# 2. what counts as already known
# ---------------------------------------------------------------------------------------------
$knownFull = @{}; $knownShort = @{}
function Index-Types($ts) {
    foreach ($t in $ts) { if ($t.FullName) { $knownFull[$t.FullName] = $true }; $knownShort[$t.Name] = $true }
}
Index-Types $types
foreach ($u in 'UnityEngine.CoreModule','UnityEngine') {
    $p = Join-Path $Managed "$u.dll"
    if (Test-Path $p) { try { Index-Types (Get-AssemblyTypes $p) } catch {} }
}
foreach ($e in $ExtraAssemblies) { if (Test-Path $e) { try { Index-Types (Get-AssemblyTypes $e) } catch {} } }

function Is-Known([string]$n) {
    # GenTypes resolves a bare name against every namespace, so a short name that matches is fine.
    $knownFull.ContainsKey($n) -or $knownShort.ContainsKey($n) -or $n -like 'System.*' -or $n -like 'UnityEngine.*'
}

# ---------------------------------------------------------------------------------------------
# 3. which mod owns a file, and which types are that mod's own
# ---------------------------------------------------------------------------------------------
$modRootCache = @{}
function Mod-RootOf([string]$dir) {
    if ($modRootCache.ContainsKey($dir)) { return $modRootCache[$dir] }
    $d = $dir; $found = $null
    while ($d -and $d.Length -ge $ModPath.Length) {
        if (Test-Path (Join-Path $d 'About\About.xml')) { $found = $d; break }
        $d = Split-Path -Parent $d
    }
    # Mod/ holds the published folder; the repository folder above it is the mod's real root, and
    # it is where Source/ lives.
    if ($found -and (Split-Path -Leaf $found) -eq 'Mod') { $found = Split-Path -Parent $found }
    $modRootCache[$dir] = $found
    return $found
}

$ownBlobCache = @{}
function Own-Blob([string]$modRoot) {
    if (-not $modRoot) { return '' }
    if ($ownBlobCache.ContainsKey($modRoot)) { return $ownBlobCache[$modRoot] }
    $sb = New-Object System.Text.StringBuilder
    foreach ($f in (Get-ChildItem $modRoot -Recurse -File -Include *.dll,*.cs -ErrorAction SilentlyContinue)) {
        if ($f.FullName -match '[\\/](obj|bin|packages|\.build|\.claude)[\\/]') { continue }
        try { [void]$sb.Append([Text.Encoding]::UTF8.GetString([IO.File]::ReadAllBytes($f.FullName))) } catch {}
    }
    $blob = $sb.ToString()
    $ownBlobCache[$modRoot] = $blob
    return $blob
}

$depCache = @{}
function Declared-Deps([string]$modRoot) {
    if (-not $modRoot) { return @() }
    if ($depCache.ContainsKey($modRoot)) { return $depCache[$modRoot] }
    $ids = @()
    foreach ($rel in 'Mod\About\About.xml','About\About.xml') {
        $p = Join-Path $modRoot $rel
        if (Test-Path $p) {
            try { [xml]$x = Get-Content $p -Raw -Encoding UTF8
                  foreach ($n in $x.SelectNodes('//modDependencies//packageId')) { $ids += $n.InnerText.Trim() }
                  foreach ($n in $x.SelectNodes('//modDependenciesByVersion//packageId')) { $ids += $n.InnerText.Trim() }
            } catch {}
            break
        }
    }
    $depCache[$modRoot] = $ids
    return $ids
}

# LoadFolders entries that are conditional on a mod, as folder-segment -> the packageIds asked for
$lfCache = @{}
function Conditional-Folders([string]$modRoot) {
    if (-not $modRoot) { return @() }
    if ($lfCache.ContainsKey($modRoot)) { return $lfCache[$modRoot] }
    $out = @()
    foreach ($rel in 'Mod\LoadFolders.xml','LoadFolders.xml','Mod\loadfolders.xml','loadfolders.xml') {
        $p = Join-Path $modRoot $rel
        if (-not (Test-Path $p)) { continue }
        try { [xml]$x = Get-Content $p -Raw -Encoding UTF8 } catch { continue }
        foreach ($li in $x.SelectNodes('//li')) {
            foreach ($a in 'IfModActive','IfModActiveAll','IfModActiveAny') {
                $v = $li.GetAttribute($a)
                if ($v) {
                    $seg = $li.InnerText.Trim().Trim('/')
                    if ($seg -and $seg -ne '.') { $out += [pscustomobject]@{ Segment = $seg; Attr = $a; Ids = $v } }
                }
            }
        }
        break
    }
    $lfCache[$modRoot] = $out
    return $out
}

# ---------------------------------------------------------------------------------------------
# 4. the sweep
# ---------------------------------------------------------------------------------------------
# .claude holds session worktrees, which are whole copies of the repository; .build holds
# compilation output, which is a second copy of every published folder; _mods-sources holds raw
# Workshop copies of other people's mods, which are not ours to report on. Languages/ has no defs.
$files = Get-ChildItem $ModPath -Recurse -Filter *.xml -File |
         Where-Object { $_.FullName -notmatch '[\\/]\.claude[\\/]' -and
                        $_.FullName -notmatch '[\\/]\.build[\\/]' -and
                        $_.FullName -notmatch '[\\/]_mods-sources[\\/]' -and
                        $_.FullName -notmatch '[\\/](obj|bin)[\\/]' -and
                        $_.FullName -notmatch '[\\/]Languages[\\/]' }

$rows        = New-Object System.Collections.Generic.List[object]
$badXml      = New-Object System.Collections.Generic.List[string]
$mayRequires = @{}
$orphans     = 0

foreach ($file in $files) {
    $modRoot = Mod-RootOf $file.DirectoryName
    # No About.xml anywhere above it, so it is not part of a mod - a settings dump, a spreadsheet
    # export, a note. Nothing the game loads, and nothing to hold anyone to.
    if (-not $modRoot) { $orphans++; continue }

    try { [xml]$doc = Get-Content -LiteralPath $file.FullName -Raw -Encoding UTF8 }
    catch { [void]$badXml.Add("$($file.FullName): $(($_.Exception.Message -split "`n")[0])"); continue }
    if (-not $doc.DocumentElement) { continue }

    $modName = Split-Path -Leaf $modRoot
    $rel     = if ($file.FullName.StartsWith($ModPath)) { $file.FullName.Substring($ModPath.Length).TrimStart('\','/') } else { $file.FullName }

    foreach ($node in $doc.SelectNodes('//*')) {
        $shape = $null; $field = $null
        if ($node.Name -eq 'li' -and $node.ParentNode -and $fieldKind[$node.ParentNode.Name] -eq 'List<Type>') {
            $shape = 'List<Type>'; $field = $node.ParentNode.Name
        }
        elseif ($fieldKind[$node.Name] -eq 'Type') { $shape = 'Type'; $field = $node.Name }
        if (-not $shape) { continue }
        # A field element holding sub-elements is a different shape entirely - not a type name.
        if ($node.HasChildNodes -and $node.FirstChild.NodeType -ne 'Text') { continue }

        $val = $node.InnerText.Trim()
        if (-not $val) { continue }
        if (Is-Known $val) { continue }

        $own = (Own-Blob $modRoot).Contains($val.Split('.')[-1])

        # --- the four guards ---------------------------------------------------------------
        $how = @()
        foreach ($n in @($node, $node.ParentNode) | Where-Object { $_ -and $_.NodeType -eq 'Element' }) {
            foreach ($a in 'MayRequire','MayRequireAnyOf') {
                $v = $n.GetAttribute($a)
                if ($v) { $how += $a; foreach ($id in $v.Split(',')) { $mayRequires[$id.Trim()] = $true } }
            }
        }
        $p = $node.ParentNode
        while ($p -and $p.NodeType -eq 'Element') {
            switch ($p.GetAttribute('Class')) {
                'PatchOperationFindMod'     { $how += 'FindMod' }
                'PatchOperationConditional' { $how += 'Conditional' }
                'PatchOperationSequence'    {
                    # A Test earlier in the same sequence aborts it, which guards what follows.
                    foreach ($li in $p.SelectNodes('operations/li')) {
                        if ($li.GetAttribute('Class') -eq 'PatchOperationTest') { $how += 'Test'; break }
                    }
                }
            }
            $p = $p.ParentNode
        }
        foreach ($cf in (Conditional-Folders $modRoot)) {
            if ($rel -match [regex]::Escape($cf.Segment.Replace('/','\'))) { $how += "LoadFolders:$($cf.Attr)" }
        }

        $rows.Add([pscustomobject]@{
            Mod = $modName; Shape = $shape; Field = $field; Type = $val
            Own = $own; Guard = (($how | Select-Object -Unique) -join '+')
            ModRoot = $modRoot; File = $rel
        })
    }
}

# ---------------------------------------------------------------------------------------------
# 5. optionally, who owns each unresolved type
# ---------------------------------------------------------------------------------------------
$ownerOf = @{}
if ($ResolveOwner -and (Test-Path $Workshop)) {
    # Two phases, because one is not enough and one is too slow.
    #
    # Phase 1 finds CANDIDATES by looking for the short name in the raw bytes of each assembly.
    # Cheap, and one DLL at a time - concatenating a mod's assemblies into one string before
    # testing is quadratic and turns two minutes into ten.
    #
    # Phase 2 is the correction. A string hit does NOT mean the assembly defines the type: .NET
    # metadata stores a TypeRef exactly the way it stores a TypeDef, namespace and name as
    # separate #Strings entries, so an assembly that merely USES the type matches just as well.
    # With directory order arbitrary, a consumer usually won the race: the first version of this
    # named sargoskar.witcherhunt as the home of VEF.AnimalBehaviours.Hediff_AcidBuildup, and
    # Inoshishi3.KTTFDE as the home of Vehicles.Graphic_Vehicle. Both wrong, both plausible, and
    # a wrong packageId here is worse than none - it sends the reader to add a dependency that is
    # already correct. So each candidate is reflection-only loaded and asked what it actually
    # defines, and nothing is claimed unless an assembly answers yes.
    $wanted = [System.Collections.Generic.HashSet[string]]::new()
    $fullOf = @{}
    foreach ($r in $rows) {
        if ($r.Own) { continue }
        $s = $r.Type.Split('.')[-1]
        [void]$wanted.Add($s)
        if (-not $fullOf.ContainsKey($s)) { $fullOf[$s] = $r.Type }
    }
    $seenIn = @{}   # short name -> packageIds whose assemblies merely carry the string
    if ($wanted.Count) {
        $dirs = @(Get-ChildItem $Workshop -Directory -ErrorAction SilentlyContinue)

        # Scan the mods these findings DECLARE before all the others, because "which assembly
        # defines this type" has more than one true answer. Three installed mods ship a
        # Vehicles.dll defining Vehicles.Graphic_Vehicle - Vehicle Framework, which is its home,
        # plus Outlander Solutions and Bill Doors' Framework, each bundling a copy. All three
        # answer yes, so without an order the reply was 3HSTltd.Framework and the line read
        # "declared in modDependencies: False" about a mod that declares Vehicle Framework
        # perfectly well. Putting declared dependencies first makes the first definer found the
        # useful one, and keeps the early exit that makes this bearable at all.
        $declaredIds = @{}
        foreach ($r in $rows) { if (-not $r.Own) { foreach ($d in (Declared-Deps $r.ModRoot)) { $declaredIds[$d.ToLower()] = $true } } }
        if ($declaredIds.Count) {
            $first = New-Object System.Collections.Generic.List[object]
            $rest  = New-Object System.Collections.Generic.List[object]
            foreach ($dir in $dirs) {
                $a = Join-Path $dir.FullName 'About\About.xml'
                $id = $null
                if (Test-Path $a) { try { [xml]$x = Get-Content $a -Raw; $id = $x.ModMetaData.packageId } catch {} }
                if ($id -and $declaredIds.ContainsKey($id.ToLower())) { $first.Add($dir) } else { $rest.Add($dir) }
            }
            # AddRange, not @($first) + @($rest): with an empty first list that operator throws
            # "argument types do not match" rather than returning the second.
            Write-Host "  $($first.Count) declared dependency mod(s) will be searched first." -ForegroundColor DarkGray
            $first.AddRange($rest)
            $dirs = $first.ToArray()
        }

        Write-Host "Resolving $($wanted.Count) type name(s) across $($dirs.Count) installed mods..." -ForegroundColor DarkGray
        $i = 0
        foreach ($dir in $dirs) {
            if ($wanted.Count -eq 0) { break }
            if ((++$i % 500) -eq 0) { Write-Host "  $i/$($dirs.Count), $($wanted.Count) left" -ForegroundColor DarkGray }
            $pid2 = $null
            foreach ($dll in (Get-ChildItem $dir.FullName -Recurse -Filter *.dll -File -ErrorAction SilentlyContinue)) {
                if ($wanted.Count -eq 0) { break }
                try { $s = [Text.Encoding]::UTF8.GetString([IO.File]::ReadAllBytes($dll.FullName)) } catch { continue }
                $cand = @($wanted | Where-Object { $s.Contains($_) })
                if (-not $cand) { continue }
                if (-not $pid2) {
                    $pid2 = $dir.Name
                    $about = Join-Path $dir.FullName 'About\About.xml'
                    if (Test-Path $about) { try { [xml]$x = Get-Content $about -Raw; if ($x.ModMetaData.packageId) { $pid2 = $x.ModMetaData.packageId } } catch {} }
                }
                # Which of the candidates does this assembly actually DEFINE?
                #
                # GetTypes() in a reflection-only context resolves each type's base class, and a
                # mod assembly's bases live in Assembly-CSharp. With no
                # ReflectionOnlyAssemblyResolve handler registered, every RimWorld-derived type
                # comes back as a null entry in ReflectionTypeLoadException.Types - which is every
                # type worth looking for. Without $roProbeDirs and the handler near the top of
                # this file, this phase confirmed nothing at all, and the column went from wrong
                # to useless.
                $script:roProbeDirs = @($Managed, $dll.Directory.FullName)
                $defined = $null
                try {
                    $ra = [System.Reflection.Assembly]::ReflectionOnlyLoadFrom($dll.FullName)
                    try     { $rt = $ra.GetTypes() }
                    catch [System.Reflection.ReflectionTypeLoadException] { $rt = $_.Exception.Types | Where-Object { $_ } }
                    catch   { $rt = @() }
                    $defined = @{}
                    foreach ($t in $rt) { if ($t.FullName) { $defined[$t.FullName] = $true } }
                } catch { $defined = $null }   # bad image, duplicate identity, native DLL

                foreach ($h in $cand) {
                    if (-not $seenIn.ContainsKey($h)) { $seenIn[$h] = New-Object System.Collections.Generic.List[string] }
                    if (-not $seenIn[$h].Contains($pid2)) { $seenIn[$h].Add($pid2) }
                    if ($defined -and $defined.ContainsKey($fullOf[$h])) {
                        $ownerOf[$h] = $pid2
                        [void]$wanted.Remove($h)
                    }
                }
            }
        }
    }
}

[System.AppDomain]::CurrentDomain.remove_AssemblyResolve($script:asmResolver)
[System.AppDomain]::CurrentDomain.remove_ReflectionOnlyAssemblyResolve($script:roResolver)

# ---------------------------------------------------------------------------------------------
# 6. the report
# ---------------------------------------------------------------------------------------------
$read = $files.Count - $orphans
Write-Output "$read XML files read under $ModPath$(if ($orphans) { " ($orphans skipped: no About.xml above them)" })."

# Reading nothing is not a pass. Without this the run ends on "No unguarded reference to a
# third-party type", which is true and worthless, and the only hint is a zero three lines up.
# The way it happens in practice: the path given is inside .claude, which is excluded above
# because a session worktree is a whole copy of the repository - Check-DefInjected.ps1 has the
# same exclusion and the same trap, and this was hit for real on a mod being renamed inside one.
if ($read -eq 0) {
    Write-Output ''
    Write-Output 'NOTHING WAS READ - this is not a clean result.'
    if ($ModPath -match '[\\/]\.claude[\\/]') {
        Write-Output "  The path is inside .claude, which is skipped on purpose. Point this at the"
        Write-Output "  copy that the game actually loads, under the repository root."
    } else {
        Write-Output "  No XML under that path survived the filters (.claude, .build, _mods-sources,"
        Write-Output "  obj, bin, Languages), or none of it sits under a folder with About/About.xml."
    }
    exit 2
}
Write-Output "$($fieldKind.Count) element names searched, $listFieldCount of them List<Type>."
if ($ambiguous.Count) {
    Write-Output "$($ambiguous.Count) name(s) skipped as ambiguous - vanilla declares them with more than one field type: $($ambiguous -join ', ')"
}
Write-Output "$($rows.Count) type references that are neither RimWorld's nor Unity's."

if ($badXml.Count) {
    Write-Output ''
    Write-Output "-- MALFORMED XML --"
    $badXml | ForEach-Object { Write-Output "  $_" }
}

# MayRequire is not spell-checked outside Ludeon's editor, so do it here.
if ($mayRequires.Count -and (Test-Path $Workshop)) {
    $installed = @{}
    foreach ($dir in (Get-ChildItem $Workshop -Directory -ErrorAction SilentlyContinue)) {
        $a = Join-Path $dir.FullName 'About\About.xml'
        if (Test-Path $a) { try { [xml]$x = Get-Content $a -Raw; if ($x.ModMetaData.packageId) { $installed[$x.ModMetaData.packageId.ToLower()] = $true } } catch {} }
    }
    foreach ($p in 'Ludeon.RimWorld','Ludeon.RimWorld.Royalty','Ludeon.RimWorld.Ideology','Ludeon.RimWorld.Biotech','Ludeon.RimWorld.Anomaly','Ludeon.RimWorld.Odyssey','brrainz.harmony') { $installed[$p.ToLower()] = $true }
    $unknown = $mayRequires.Keys | Where-Object { $_ -and -not $installed.ContainsKey($_.ToLower()) } | Sort-Object
    if ($unknown) {
        Write-Output ''
        Write-Output "-- MayRequire naming no installed mod (the game will not tell you: MistypedMayRequire is editor-only) --"
        $unknown | ForEach-Object { Write-Output "  $_" }
    }
}

# @() around both: PowerShell unrolls a one-element pipeline to a scalar, and a scalar has no
# .Count - a single finding would be reported as "(-- UNGUARDED ... () --)".
$third = @($rows | Where-Object { -not $_.Own })
$bad   = @($third | Where-Object { -not $_.Guard })

if ($All) {
    Write-Output ''
    Write-Output "-- guarded, or the mod's own classes --"
    $rows | Where-Object { $_.Own -or $_.Guard } | Sort-Object Mod, Shape, Field |
        Format-Table Mod, Shape, Field, Type, Own, Guard, File -AutoSize -Wrap | Out-String -Width 200 | Write-Output
}

Write-Output ''
if (-not $bad) {
    Write-Output 'No unguarded reference to a third-party type.'
    exit 0
}

Write-Output "-- UNGUARDED references to a third-party type ($($bad.Count)) --"
Write-Output ''
foreach ($r in ($bad | Sort-Object Mod, Shape, Field, File)) {
    Write-Output "  $($r.Mod)  [$($r.Shape)]  <$($r.Field)> $($r.Type)"
    Write-Output "      $($r.File)"
    if ($ResolveOwner) {
        $short = $r.Type.Split('.')[-1]
        if ($ownerOf.ContainsKey($short)) {
            $owner = $ownerOf[$short]
            $declared = (Declared-Deps $r.ModRoot) -contains $owner
            Write-Output "      defined by: $owner - declared in modDependencies: $declared"
        }
        elseif ($seenIn.ContainsKey($short) -and $seenIn[$short].Count) {
            # No assembly claimed it. Say so, and say where the name was seen, rather than
            # promoting a mod that merely references the type to being its author.
            Write-Output "      defined by: UNCONFIRMED - no installed assembly defines it; the name appears in: $(($seenIn[$short] | Select-Object -First 5) -join ', ')"
        }
        else {
            Write-Output '      defined by: not found in any installed mod'
        }
    }
}
Write-Output ''
Write-Output 'A declared dependency is not a guard. Whether a finding is a fault depends on whose'
Write-Output 'def gets damaged: another mod''s, and it is one; your own, in a mod that cannot run'
Write-Output 'without that framework anyway, and a guard on one line of several buys nothing.'
exit 1
