<#
.SYNOPSIS
  Compile every step pattern of this suite with Pickle's own expression engine, and match every step
  line of every feature against them and against Pickle's built-in vocabulary. No game, a few seconds.

.DESCRIPTION
  Written for the failure this whole family of suites keeps paying for: an invalid pattern makes a run
  play zero scenarios (Pickle builds its whole step table before it runs anything and reports
  infrastructure-error), and the machine is shared, so a lost run is also forty minutes of everybody
  else's queue. FlavorTextExtendedFR's Check-Steps.ps1 and PickleTools/ResearchSteps/Check-Steps.ps1 are
  the two it grew out of. This one asks four things, each of which has cost a run somewhere:

    1. Every pattern this suite declares COMPILES, with the PickleParameterTypeRegistry the game uses.
       Parentheses in a Cucumber Expression mean optional text, so "at (x, y)" is not a cell.
    2. No pattern is declared twice, and none is AMBIGUOUS: Pickle matches on the text alone, so a step
       line that this suite's expressions and Pickle's own both match fails a healthy scenario.
    3. Every step line of every feature matches EXACTLY ONE expression, from this suite or from Pickle. A
       line that matches none is a typo that would only show on the run; that is stricter than the
       sibling scripts, which leave the unmatched lines to be read by a person.
    4. Every step that waits (an `async Task` method) declares TimeoutSeconds. The default step deadline
       is five seconds, and a step that waits ten dies at five with a bare timeout that names nothing.

  It also reports a pattern no feature uses. A step nobody calls is weight; the doctrine is to delete it.

  What it does not do: run anything. A pattern that compiles and matches proves the line will find its
  step, not that the step does the right thing.

.EXAMPLE
  powershell.exe -ExecutionPolicy Bypass -File Tests/Pickle/Check-Steps.ps1
#>
param(
    [string]$PickleAssemblies = 'C:\Program Files (x86)\Steam\steamapps\workshop\content\294100\3791648678\Assemblies',
    [string]$Cecil = "$env:USERPROFILE\.nuget\packages\mono.cecil\0.11.5\lib\net40\Mono.Cecil.dll"
)
$ErrorActionPreference = 'Stop'
$suite = $PSScriptRoot

foreach ($dll in 'CucumberExpressions.dll', 'RimWorks.Pickle.Core.dll') {
    $path = Join-Path $PickleAssemblies $dll
    if (-not (Test-Path $path)) { throw "$dll not found under $PickleAssemblies. Pass -PickleAssemblies with the installed Pickle mod's Assemblies folder." }
    [Reflection.Assembly]::LoadFrom($path) | Out-Null
}
if (-not (Test-Path $Cecil)) { throw "Mono.Cecil not found at $Cecil. Pass -Cecil, or restore the package (mono.cecil 0.11.5)." }
Add-Type -Path $Cecil

$core = [AppDomain]::CurrentDomain.GetAssemblies() | Where-Object { $_.GetName().Name -eq 'RimWorks.Pickle.Core' }
$registryType = $core.GetType('RimWorks.Pickle.Core.Steps.PickleParameterTypeRegistry')
if (-not $registryType) { throw 'PickleParameterTypeRegistry no longer exists: Pickle renamed it, update this script.' }
$registry = [Activator]::CreateInstance($registryType)
function New-Expr($pattern) { New-Object CucumberExpressions.CucumberExpression($pattern, $registry) }

$bad = 0

# --- this suite's patterns -----------------------------------------------------------------------

# The attribute argument is a C# literal: undo its escaping to get the pattern Pickle sees. The pattern
# may be followed by a named argument (TimeoutSeconds = 45f), so the closing bracket is not required.
$attr = '\[(Given|When|Then)\("((?:[^"\\]|\\.)*)"([^\]]*)\]'
$mine = @()
foreach ($f in Get-ChildItem -LiteralPath (Join-Path $suite 'Source') -Filter *.cs) {
    $text = [IO.File]::ReadAllText($f.FullName)
    foreach ($m in [regex]::Matches($text, $attr)) {
        # The method that follows the attribute: is it async? Only then does it wait.
        $after = $text.Substring($m.Index + $m.Length, [Math]::Min(120, $text.Length - $m.Index - $m.Length))
        $mine += [pscustomobject]@{
            File    = $f.Name
            Pattern = ($m.Groups[2].Value -replace '\\\\', '\' -replace '\\"', '"')
            Async   = ($after -match '^\s*public\s+async\s+Task')
            Timeout = ($m.Groups[3].Value -match 'TimeoutSeconds')
        }
    }
}
if ($mine.Count -eq 0) { throw "no step patterns found under $suite\Source: the attribute shape this script looks for has changed." }

foreach ($g in ($mine | Group-Object Pattern | Where-Object { $_.Count -gt 1 })) {
    Write-Host "DUPLICATE  $($g.Name)  (declared $($g.Count) times, in $(($g.Group.File | Sort-Object -Unique) -join ', '))" -ForegroundColor Red; $bad++
}
foreach ($d in $mine | Where-Object { $_.Async -and -not $_.Timeout }) {
    Write-Host "NO TIMEOUT  $($d.File): $($d.Pattern)`n            waits (async) but declares no TimeoutSeconds: the default deadline is five seconds." -ForegroundColor Red; $bad++
}

$myExprs = @()
foreach ($d in $mine) {
    try { $myExprs += [pscustomobject]@{ Source = 'suite'; Pattern = $d.Pattern; Regex = (New-Expr $d.Pattern).Regex; Used = $false } }
    catch {
        $e = $_.Exception; while ($e.InnerException) { $e = $e.InnerException }
        Write-Host "INVALID  $($d.File): $($d.Pattern)`n         $($e.Message.Split("`n")[0])" -ForegroundColor Red; $bad++
    }
}

# --- Pickle's own vocabulary, read from the attributes of its two assemblies ---------------------

$pickle = @()
foreach ($name in 'RimWorks.Pickle.Vanilla.dll', 'RimWorks.Pickle.dll') {
    $asm = [Mono.Cecil.AssemblyDefinition]::ReadAssembly((Join-Path $PickleAssemblies $name))
    foreach ($t in $asm.MainModule.GetTypes()) {
        foreach ($m in $t.Methods) {
            foreach ($a in $m.CustomAttributes | Where-Object { $_.AttributeType.Name -in 'GivenAttribute', 'WhenAttribute', 'ThenAttribute' }) {
                $pickle += [string]$a.ConstructorArguments[0].Value
            }
        }
    }
}
# Registered by the runner in RunSession.RegisterBuiltInEngineSteps as string literals, not as attributes,
# so the extraction above cannot see them (found by reading that method's IL on 2026-09-24).
foreach ($p in 'the save {string} is loaded', 'I save and reload', 'I save and reload as {string}', 'the save round trips') { $pickle += $p }
$pickleExprs = @()
foreach ($p in $pickle | Sort-Object -Unique) {
    try { $pickleExprs += [pscustomobject]@{ Source = 'pickle'; Pattern = $p; Regex = (New-Expr $p).Regex } } catch { }
}

# --- every step line of every feature -----------------------------------------------------------

$lines = 0; $unresolved = @(); $ambiguous = @{}
foreach ($file in Get-ChildItem -LiteralPath (Join-Path $suite 'Mod\Pickle\Features') -Filter *.feature) {
    foreach ($raw in [IO.File]::ReadAllLines($file.FullName)) {
        if ($raw.Trim() -notmatch '^(Given|When|Then|And|But)\s+(.+)$') { continue }
        $step = $Matches[2].Trim(); $lines++
        $hits = @($myExprs + $pickleExprs | Where-Object { $_.Regex.IsMatch($step) })
        $distinct = @($hits | Select-Object -ExpandProperty Pattern -Unique)
        foreach ($h in $hits | Where-Object { $_.Source -eq 'suite' }) { $h.Used = $true }
        if ($hits.Count -eq 0) { $unresolved += "$($file.Name): $step" }
        elseif ($distinct.Count -gt 1) { $ambiguous["$($file.Name): $step"] = ($hits | ForEach-Object { "$($_.Source) `"$($_.Pattern)`"" }) -join ' AND ' }
    }
}

# --- report --------------------------------------------------------------------------------------

Write-Host ''
Write-Host "$($mine.Count) suite patterns, $($myExprs.Count) compile. Compared against $($pickleExprs.Count) from Pickle. $lines step lines across the features."

foreach ($k in $ambiguous.Keys) { Write-Host "AMBIGUOUS  $k`n           $($ambiguous[$k])" -ForegroundColor Red; $bad++ }
if ($unresolved.Count -gt 0) {
    Write-Host ''
    Write-Host "$($unresolved.Count) step line(s) match no expression at all (this suite, Pickle):" -ForegroundColor Red
    $unresolved | Sort-Object -Unique | ForEach-Object { Write-Host "  $_" -ForegroundColor Red }
    $bad++
}
$unused = @($myExprs | Where-Object { -not $_.Used })
if ($unused.Count -gt 0) {
    Write-Host ''
    Write-Host "$($unused.Count) suite pattern(s) no feature uses - weight, not coverage:" -ForegroundColor Yellow
    foreach ($u in $unused) { Write-Host "  $($u.Pattern)" -ForegroundColor Yellow }
}

Write-Host ''
if ($bad -gt 0) {
    Write-Host "$bad PROBLEM(S). An invalid pattern makes a run play zero scenarios (infrastructure-error); an ambiguous line fails a healthy scenario; a line no expression matches is a typo the run would only find out." -ForegroundColor Red
    exit 1
}
Write-Host 'ALL PATTERNS COMPILE, NONE DECLARED TWICE OR AMBIGUOUS, EVERY WAITING STEP HAS A DEADLINE, EVERY FEATURE LINE RESOLVES' -ForegroundColor Green
exit 0
