<#
.SYNOPSIS
  Replays, offline, the consistency rules RimWorld applies to defs at load time.

.DESCRIPTION
  The four sibling checkers all answer "does this name resolve?" - Check-DefRefs.ps1 for defs,
  Check-XmlClasses.ps1 and Check-TypeRefs.ps1 for C# types, Check-XmlFields.ps1 for fields, and
  Check-DefInjected.ps1 for translation keys. None of them looks at whether the VALUES make
  sense together, and that is a separate family of faults with its own log line:

      Config error in AB_AirConditioner: is airtight but Fillage is not Full

  Verse.Def.ConfigErrors and Verse.ThingDef.ConfigErrors hold about sixty such rules. They run
  once, at load, on the def AFTER inheritance has been applied, and they are the reason a port
  that passes every name check can still fill the log on its first run. This script replays the
  subset of them that can be decided from the XML alone.

  WHAT IT IS NOT. It does not call the game's own ConfigErrors. That method needs a constructed
  ThingDef, and a ThingDef cannot even be instantiated outside Unity - Activator.CreateInstance
  throws on Verse.BaseContent's static initialiser. The rules below are therefore reimplemented,
  which means they can be wrong, which is what -SelfTest exists for.

  -SelfTest RUNS THE RULES ON THE GAME'S OWN DEFS. Core and the DLCs load without a single
  config error, by definition: anything this script reports there is its own bug, not Ludeon's.
  That is the only honest way to calibrate a reimplementation, and it is the same method
  Check-DefRefs.ps1 used when its tag list was widened. Run it after touching any rule.

  THE RULE TEXTS ARE NOT REMEMBERED. Each one was read out of Assembly-CSharp.dll on 2026-09-12
  by walking the IL of the ConfigErrors iterators and resolving every ldstr token. What could
  not be read that way is the CONDITION, only the message - so the predicates below are written
  from the message and the field semantics, and checked by -SelfTest.

  INHERITANCE IS PART OF THE JOB. A def is checked as the game sees it, after ParentName has
  been walked, because almost every rule here reads a field the def inherits rather than one it
  writes. BuildingBase alone carries useHitPoints, category, selectable and a dozen more. The
  merge follows Verse.XmlInheritance.RecursiveNodeCopyOverwriteElements: a node the child also
  declares wins, a node it does not is copied down, and a LIST the child declares replaces the
  parent's outright rather than merging element by element.

  WHAT IT DOES NOT COVER, and deliberately:
    - patch operations. The mod's own XML is read as written; a def another mod patches into
      shape is judged unpatched. Check-XmlFields.ps1 has the same blind spot for the same
      reason.
    - rules that need the def graph rather than the def: "is equipment but has no verbs or
      tools" reads a parent's tools, "has tool with linkedBodyPartsGroup X but body Y has no
      parts with that group" reads another def entirely.
    - rules whose condition is a computed property with no XML equivalent - IsEdifice,
      EverHaulable, CanEverDeteriorate. Guessing those produces false positives on vanilla,
      which -SelfTest turns into noise, which is worse than a missing rule.
    - a def whose ParentName chain leaves what was scanned. It is not checked at all, and the
      missing parent is named in the report so -AlsoScan can be pointed at the dependency.
      Checking it anyway is worse than skipping it: Zen Garden Plus came back with a null
      thingClass and a null graphicClass, neither of them true, because the base its trees
      inherit from lives in the mod it extends.
  The uncovered rules are listed at the end of a run, so the gap is visible rather than implied.

  EXIT CODES. 0 clean, 1 config errors, 2 clean as far as it got but some defs could not be
  checked at all. The third exists because a run that reads 7 defs out of 903, for want of
  -AlsoScan, must not answer 0 to a caller that only tests for success.

.EXAMPLE
  .\Check-ConfigErrors.ps1 -ModPath C:\...\AncientBuildingsRenew\Mod
.EXAMPLE
  .\Check-ConfigErrors.ps1 -SelfTest        # the calibration: Core and the DLCs must come back clean
#>
param(
    [Parameter(Mandatory=$true, ParameterSetName='Mod')][string]$ModPath,
    [Parameter(Mandatory=$true, ParameterSetName='Self')][switch]$SelfTest,
    [string]$GameData = 'C:\Program Files (x86)\Steam\steamapps\common\RimWorld\Data',
    [string]$Managed  = 'C:\Program Files (x86)\Steam\steamapps\common\RimWorld\RimWorldWin64_Data\Managed',
    # Dependencies whose abstract parents the mod inherits from. Without them a def whose
    # ParentName lives in another mod is checked with half its fields missing, and every rule
    # that reads an inherited field reports a fault that is not there.
    [string[]]$AlsoScan = @(),
    # The mod's own assembly and its frameworks, for the one rule that needs a type hierarchy.
    [string[]]$ExtraAssemblies = @(),
    [switch]$Brief
)

$ErrorActionPreference = 'Stop'

# --- defaults -------------------------------------------------------------------------------
# Field defaults, needed because a rule reads a field the def never writes. These are ASSERTED
# here rather than read from the assembly: field initialisers are not reachable by reflection,
# and an instance cannot be built outside Unity (see the note above). -SelfTest is what makes
# them safe - a wrong default fires on vanilla immediately, because vanilla is full of defs that
# leave the field unwritten.
$DEFAULT = @{
    useHitPoints   = $true
    stackLimit     = 1
    drawGUIOverlay = $false
    fillPercent    = 0.0
    passability    = 'Standard'
}

# --- the C# types, for the one rule that needs a hierarchy ----------------------------------
$script:probed = @{}
$probeDirs = @($Managed) + @($ExtraAssemblies | ForEach-Object { Split-Path -Parent $_ }) | Select-Object -Unique
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

$script:types = @{}
$script:thingWithComps = $null
function Initialize-Types {
    $asmPaths = @(Join-Path $Managed 'Assembly-CSharp.dll') + $ExtraAssemblies
    foreach ($p in $asmPaths) {
        if (-not (Test-Path $p)) { continue }
        try { $asm = [System.Reflection.Assembly]::LoadFrom($p) } catch { continue }
        # GetTypes() always throws here: Assembly-CSharp references Unity assemblies that are
        # not loadable outside the game. The exception still carries every type it did resolve.
        $ts = $null
        try { $ts = $asm.GetTypes() } catch [System.Reflection.ReflectionTypeLoadException] { $ts = $_.Exception.Types }
        foreach ($t in $ts) {
            if ($null -eq $t) { continue }
            if (-not $script:types.ContainsKey($t.Name))     { $script:types[$t.Name] = $t }
            if (-not $script:types.ContainsKey($t.FullName)) { $script:types[$t.FullName] = $t }
        }
    }
    $script:thingWithComps = $script:types['Verse.ThingWithComps']
}

# --- reading the XML ------------------------------------------------------------------------
function Get-DefFiles([string]$root) {
    if (-not (Test-Path $root)) { return @() }
    Get-ChildItem -Path $root -Recurse -Filter *.xml -File -ErrorAction SilentlyContinue |
        Where-Object { $_.FullName -match '[\\/]Defs[\\/]' }
}

# Every def node of a folder, plus the Name= index the ParentName walk needs. Both are built
# from the same pass so a mod can inherit from its own abstract parents as well as the game's.
function Read-Defs([string]$root, [hashtable]$nameIndex) {
    $out = New-Object System.Collections.ArrayList
    foreach ($f in Get-DefFiles $root) {
        $doc = New-Object System.Xml.XmlDocument
        try { $doc.Load($f.FullName) } catch { Write-Warning "malformed XML, skipped: $($f.FullName)"; continue }
        if ($null -eq $doc.DocumentElement) { continue }
        foreach ($n in $doc.DocumentElement.ChildNodes) {
            if ($n.NodeType -ne [System.Xml.XmlNodeType]::Element) { continue }
            $nm = $n.GetAttribute('Name')
            if ($nm) { $nameIndex[$nm] = $n }
            [void]$out.Add([pscustomobject]@{ Node = $n; File = $f.FullName })
        }
    }
    ,$out
}

# Verse.XmlInheritance.RecursiveNodeCopyOverwriteElements, as close as XML alone allows:
# what the child declares wins, what it does not is copied down from the parent, and a list is
# never merged - the <li> children of a list the child declares are the whole list. Inherit="false"
# on a child node stops that node from being filled in from above.
function Merge-Inherited([System.Xml.XmlElement]$parent, [System.Xml.XmlElement]$child) {
    foreach ($pn in $parent.ChildNodes) {
        if ($pn.NodeType -ne [System.Xml.XmlNodeType]::Element) { continue }
        $existing = $null
        foreach ($cn in $child.ChildNodes) {
            if ($cn.NodeType -eq [System.Xml.XmlNodeType]::Element -and $cn.Name -eq $pn.Name) { $existing = $cn; break }
        }
        if ($null -eq $existing) {
            $imported = $child.OwnerDocument.ImportNode($pn, $true)
            [void]$child.AppendChild($imported)
        }
        elseif ($pn.Name -ne 'li' -and $existing.GetAttribute('Inherit') -ne 'false' -and $existing.GetAttribute('IsNull') -ne 'True') {
            $hasElementChildren = $false
            foreach ($x in $pn.ChildNodes) { if ($x.NodeType -eq [System.Xml.XmlNodeType]::Element) { $hasElementChildren = $true; break } }
            if ($hasElementChildren) { Merge-Inherited $pn $existing }
        }
    }
}

# Returns the resolved def, or $null when a parent in the chain is missing. That case is NOT a
# finding and must never be checked: a def missing half its fields fails rules it passes in the
# game. Zen Garden Plus inherits ZEN_OrchardTreeBase from the mod it extends, and without
# -AlsoScan it came back with a null thingClass and a null graphicClass, neither of them true.
$script:missingParents = @{}
function Resolve-Def([System.Xml.XmlElement]$node, [hashtable]$nameIndex) {
    $doc = New-Object System.Xml.XmlDocument
    $resolved = $doc.ImportNode($node, $true)
    [void]$doc.AppendChild($resolved)
    $guard = 0
    $parentName = $node.GetAttribute('ParentName')
    while ($parentName -and $guard -lt 20) {
        $guard++
        $p = $nameIndex[$parentName]
        if ($null -eq $p) { $script:missingParents[$parentName] = $true; return $null }
        Merge-Inherited $p $resolved
        $parentName = $p.GetAttribute('ParentName')
    }
    $resolved
}

# --- small readers ---------------------------------------------------------------------------
# IsNull="True" is how a def cancels a field it would otherwise inherit: Flamebow carries
# <recipeMaker IsNull="True" /> to drop BaseWeaponNeolithic's. The field is then null in the
# game, so the node has to read as ABSENT here or every rule that asks "is this field set?"
# answers yes on a field that was explicitly unset. -SelfTest found it on exactly one def.
function Get-Child([System.Xml.XmlElement]$n, [string]$name) {
    foreach ($c in $n.ChildNodes) {
        if ($c.NodeType -eq [System.Xml.XmlNodeType]::Element -and $c.Name -eq $name) {
            if ($c.GetAttribute('IsNull') -eq 'True') { return $null }
            return $c
        }
    }
    return $null
}
function Get-Text([System.Xml.XmlElement]$n, [string]$name) {
    $c = Get-Child $n $name
    if ($null -eq $c) { return $null }
    return $c.InnerText
}
function Get-Num([System.Xml.XmlElement]$n, [string]$name, [double]$fallback) {
    $t = Get-Text $n $name
    if ($null -eq $t) { return $fallback }
    $v = 0.0
    if ([double]::TryParse($t, [ref]$v)) { return $v }
    if ([double]::TryParse($t, [Globalization.NumberStyles]::Float, [Globalization.CultureInfo]::InvariantCulture, [ref]$v)) { return $v }
    return $fallback
}
function Get-Bool([System.Xml.XmlElement]$n, [string]$name, [bool]$fallback) {
    $t = Get-Text $n $name
    if ($null -eq $t) { return $fallback }
    return ($t.Trim().ToLowerInvariant() -eq 'true')
}
function Get-ListItems([System.Xml.XmlElement]$n, [string]$name) {
    $c = Get-Child $n $name
    if ($null -eq $c) { return @() }
    $r = @()
    foreach ($li in $c.ChildNodes) {
        if ($li.NodeType -eq [System.Xml.XmlNodeType]::Element -and $li.Name -eq 'li') { $r += $li }
    }
    ,$r
}

# --- the rules --------------------------------------------------------------------------------
# One function, one pass over a resolved def. Every message below is the game's own wording,
# read from the IL; the predicate in front of it is this script's.
function Test-Def([System.Xml.XmlElement]$d, [string]$file) {
    $out = New-Object System.Collections.ArrayList
    $isAbstract = ($d.GetAttribute('Abstract') -eq 'True')
    if ($isAbstract) { return ,$out }                     # abstract parents are never built into a def
    $defName = Get-Text $d 'defName'
    $label   = Get-Text $d 'label'
    $id      = $defName
    if (-not $id) { $id = "<$($d.Name) with no defName>" }
    function Add-Finding([string]$rule, [string]$msg) {
        [void]$out.Add([pscustomobject]@{ Def = $id; Type = $d.Name; Rule = $rule; Message = $msg; File = $file })
    }

    # --- Verse.Def.ConfigErrors: these apply to EVERY def type ---
    # ...except that some def types fill their own defName in code, and vanilla ships them with
    # the element absent: every SongDef in Core has a clipPath and no defName. Found by
    # -SelfTest, which reported 53 of them.
    if (-not $defName) {
        if ($d.Name -notin @('SongDef')) { Add-Finding 'Def' 'lacks defName' }
    }
    elseif ($defName -eq 'null') { Add-Finding 'Def' "defName cannot be the string 'null'." }
    elseif ($defName -notmatch '^[A-Za-z0-9_\-]+$') {
        Add-Finding 'Def' "defName should only contain letters, numbers, underscores, or dashes."
    }
    $descNode = Get-Child $d 'description'
    if ($null -ne $descNode) {
        $desc = $descNode.InnerText
        if ($desc.Length -eq 0) { Add-Finding 'Def' 'empty description' }
        elseif ($desc -ne $desc.TrimStart()) { Add-Finding 'Def' 'description has leading whitespace' }
        elseif ($desc -ne $desc.TrimEnd())   { Add-Finding 'Def' 'description has trailing whitespace' }
    }
    if ($label -and $label -match '[\[\]\{\}]' -and -not (Get-Bool $d 'ignoreIllegalLabelCharacterConfigError' $false)) {
        Add-Finding 'Def' 'label contains illegal character(s): "[]{}"'
    }

    if ($d.Name -ne 'ThingDef') { return ,$out }

    # --- Verse.ThingDef.ConfigErrors ---
    # The resolved category decides which of the rules below apply at all. Vanilla is the
    # authority on that: every one of the narrowings here was put in because -SelfTest reported
    # defs the game itself loads in silence.
    $category = Get-Text $d 'category'

    # Ethereal things - triggers, skyfallers, orbital strikes, the signal actions - carry no
    # label and the game does not ask them for one. 18 of them fired before this guard.
    if (-not $label -and $category -ne 'Ethereal') { Add-Finding 'ThingDef' 'no label' }
    if ($defName -and $defName -match '[0-9]$') {
        Add-Finding 'ThingDef' 'defName ends with a numerical digit, which is not allowed on ThingDefs.'
    }

    $thingClass = Get-Text $d 'thingClass'
    if (-not $thingClass) { Add-Finding 'ThingDef' 'has null thingClass.' }

    $statBases = Get-Child $d 'statBases'
    if ($null -ne $statBases) {
        $seen = @{}
        foreach ($s in $statBases.ChildNodes) {
            if ($s.NodeType -ne [System.Xml.XmlNodeType]::Element) { continue }
            if ($seen.ContainsKey($s.Name)) { Add-Finding 'ThingDef' "defines the stat base $($s.Name) more than once." }
            $seen[$s.Name] = $true
        }
    }

    $cats = Get-ListItems $d 'thingCategories'
    if ($cats.Count -gt 1) {
        $seen = @{}
        foreach ($c in $cats) {
            $v = $c.InnerText.Trim()
            if ($seen.ContainsKey($v)) { Add-Finding 'ThingDef' "has duplicate thingCategory $v" }
            $seen[$v] = $true
        }
    }

    $costList = Get-Child $d 'costList'
    if ($null -ne $costList) {
        foreach ($c in $costList.ChildNodes) {
            if ($c.NodeType -ne [System.Xml.XmlNodeType]::Element) { continue }
            $v = 0.0
            if ([double]::TryParse($c.InnerText, [ref]$v) -and $v -eq 0) {
                Add-Finding 'ThingDef' "cost in $($c.Name) is zero."
            }
        }
    }

    $stuffCats      = Get-ListItems $d 'stuffCategories'
    $costStuffCount = Get-Child $d 'costStuffCount'
    $madeFromStuff  = ($stuffCats.Count -gt 0)
    # The count has to be greater than zero, not merely present: AncientBlastDoor inherits
    # DoorBase's stuff cost, cancels the categories with Inherit="False" and writes
    # costStuffCount 0, and the game says nothing. -SelfTest found that one too.
    if ($null -ne $costStuffCount -and (Get-Num $d 'costStuffCount' 0) -gt 0 -and -not $madeFromStuff) {
        Add-Finding 'ThingDef' 'has costStuffCount but no stuffCategories.'
    }
    if ($madeFromStuff -and $null -ne (Get-Child $d 'constructEffect')) {
        Add-Finding 'ThingDef' "madeFromStuff but has a defined constructEffect (which will always be overridden by stuff's construct animation)."
    }
    if ($null -ne (Get-Child $d 'recipeMaker') -and $null -eq $costList -and $null -eq $costStuffCount) {
        Add-Finding 'ThingDef' 'has a recipeMaker but no costList or costStuffCount.'
    }

    $stackLimit = Get-Num $d 'stackLimit' $DEFAULT.stackLimit
    if ($stackLimit -gt 1 -and -not (Get-Bool $d 'drawGUIOverlay' $DEFAULT.drawGUIOverlay)) {
        Add-Finding 'ThingDef' 'has stackLimit > 1 but also has drawGUIOverlay = false.'
    }

    $fillPercent = Get-Num $d 'fillPercent' $DEFAULT.fillPercent
    $passability = Get-Text $d 'passability'
    if (-not $passability) { $passability = $DEFAULT.passability }
    $buildable   = ($null -ne (Get-Child $d 'designationCategory'))
    if ($passability -eq 'Impassable' -and $buildable -and $fillPercent -lt 1) {
        Add-Finding 'ThingDef' 'impassable, player-buildable building that can be shot/seen over.'
    }

    $building = Get-Child $d 'building'
    if ($null -ne $building) {
        if ((Get-Bool $building 'isAirtight' $false) -and $fillPercent -lt 1) {
            Add-Finding 'ThingDef' 'is airtight but Fillage is not Full'
        }
        if ((Get-Bool $building 'alwaysDeconstructible' $false) -and -not (Get-Bool $building 'deconstructible' $true)) {
            Add-Finding 'BuildingProperties' 'alwaysDeconstructible=true but deconstructible=false'
        }
    }

    # These two read a stat and a flag that a pawn, a weapon and an ethereal thing all set for
    # their own reasons, and the guard the game puts in front of them could not be read out of
    # the IL - only the message could. Restricted to buildings, where the predicate is exactly
    # right and where these mods live. Unrestricted it reported 178 animals and both mortars,
    # all of which the game loads without a word.
    $useHitPoints = Get-Bool $d 'useHitPoints' $DEFAULT.useHitPoints
    if ($category -eq 'Building' -and -not $useHitPoints -and $null -ne $statBases) {
        if ((Get-Num $statBases 'Flammability' 0) -gt 0) {
            Add-Finding 'ThingDef' 'flammable but has no hitpoints (will burn indefinitely)'
        }
        if ((Get-Num $statBases 'DeteriorationRate' 0) -gt 0) {
            Add-Finding 'ThingDef' "has >0 DeteriorationRate but can't deteriorate."
        }
    }

    # Verse.GraphicData.ConfigErrors, reached through the ThingDef that owns it.
    $gd = Get-Child $d 'graphicData'
    if ($null -ne $gd) {
        if (-not (Get-Text $gd 'graphicClass')) { Add-Finding 'GraphicData' 'graphicClass is null' }
        $tex = Get-Text $gd 'texPath'
        if ($null -eq $tex -or $tex.Trim().Length -eq 0) { Add-Finding 'GraphicData' 'texPath is null or empty' }
    }

    # Verse.CompProperties.ConfigErrors: a <li> with neither a Class= nor a compClass is the
    # base CompProperties, which does nothing and is never what was meant.
    foreach ($li in (Get-ListItems $d 'comps')) {
        $cls = $li.GetAttribute('Class')
        if ((-not $cls -or $cls -eq 'CompProperties') -and -not (Get-Text $li 'compClass')) {
            Add-Finding 'CompProperties' 'has CompProperties with null compClass.'
        }
    }

    # The one rule that needs the type hierarchy rather than the XML.
    if ($script:thingWithComps -and $thingClass -and $null -ne (Get-Child $d 'comps')) {
        $t = $script:types[$thingClass]
        if ($null -eq $t) { $t = $script:types["Verse.$thingClass"] }
        if ($null -eq $t) { $t = $script:types["RimWorld.$thingClass"] }
        if ($null -ne $t -and -not $script:thingWithComps.IsAssignableFrom($t)) {
            Add-Finding 'ThingDef' "has components but it's thingClass is not a ThingWithComps"
        }
    }

    ,$out
}

# --- run ---------------------------------------------------------------------------------------
Initialize-Types

$nameIndex = @{}
$gameRoots = @()
if ($GameData -and (Test-Path $GameData)) {
    $gameRoots = Get-ChildItem $GameData -Directory -ErrorAction SilentlyContinue |
                 Where-Object { Test-Path (Join-Path $_.FullName 'Defs') } | ForEach-Object { $_.FullName }
}

$gameDefs = New-Object System.Collections.ArrayList
foreach ($r in $gameRoots) {
    if (-not $Brief) { Write-Host "reading $([IO.Path]::GetFileName($r))..." }
    $d = Read-Defs $r $nameIndex
    [void]$gameDefs.AddRange($d)
}
foreach ($r in $AlsoScan) {
    if (-not $Brief) { Write-Host "reading dependency $([IO.Path]::GetFileName($r))..." }
    [void](Read-Defs $r $nameIndex)
}

if ($SelfTest) {
    $target = $gameDefs
    $what   = "Core and the DLCs"
} else {
    $target = Read-Defs $ModPath $nameIndex
    $what   = $ModPath
}

$findings = New-Object System.Collections.ArrayList
$skipped  = 0
foreach ($e in $target) {
    $resolved = Resolve-Def $e.Node $nameIndex
    if ($null -eq $resolved) { $skipped++; continue }
    foreach ($f in (Test-Def $resolved $e.File)) { [void]$findings.Add($f) }
}

Write-Host ""
Write-Host "=== $what ==="
Write-Host "defs checked: $($target.Count - $skipped) of $($target.Count)   rules applied: 26"
if ($target.Count -eq 0) {
    Write-Host "-- no Defs folder here: a mod that ships only patches, textures or an assembly has nothing to check --"
}

# This warning comes BEFORE the verdict, and on purpose. Flavor Text Extended ran without
# -AlsoScan, got "defs checked: 7" and "no config error" with the reason printed below both, and
# said what anyone would have concluded: that the mod was clean, when 896 of its 903 defs had not
# been read at all. A verdict on an incomplete run has to arrive after the reason it is
# incomplete, not before it. The exit code says the same thing: 2, not 0.
if ($skipped -gt 0) {
    Write-Host ""
    Write-Host "INCOMPLETE: $skipped def(s) were NOT checked - their ParentName chain leaves what was scanned."
    Write-Host "Pass the dependency's folder to -AlsoScan. Until then the verdict below covers only the rest."
    Write-Host "Parents not found:"
    foreach ($p in ($script:missingParents.Keys | Sort-Object)) { Write-Host "  $p" }
    Write-Host ""
}

if ($findings.Count -eq 0) {
    Write-Host "-- no config error --"
} else {
    $findings | Sort-Object Def | ForEach-Object {
        Write-Host ("{0,-30} {1}" -f $_.Def, $_.Message)
        if (-not $Brief) { Write-Host ("{0,-30}   {1}" -f '', $_.File) }
    }
    Write-Host ""
    Write-Host "$($findings.Count) config error(s)."
}

if (-not $Brief) {
    Write-Host ""
    Write-Host "Not covered by this script, and worth reading the log for anyway:"
    Write-Host "  - anything a patch operation would have changed: defs are read as written"
    Write-Host "  - rules that read another def: equipment verbs and tools, linkedBodyPartsGroup"
    Write-Host "    against a body, damage multipliers, smeltProducts"
    Write-Host "  - rules whose condition is a computed property: IsEdifice, EverHaulable,"
    Write-Host "    CanEverDeteriorate, Fillage on anything but isAirtight"
}

[System.AppDomain]::CurrentDomain.remove_AssemblyResolve($script:asmResolver)
$script:probed = $null

# 0 everything checked and clean, 1 config errors found, 2 clean as far as it got but some defs
# could not be checked at all. A caller that only tests for nonzero is right either way; one that
# tests for 0 does not get told "clean" about a run that read seven defs out of 903.
if ($findings.Count -gt 0) { exit 1 }
if ($skipped -gt 0) { exit 2 }
exit 0
