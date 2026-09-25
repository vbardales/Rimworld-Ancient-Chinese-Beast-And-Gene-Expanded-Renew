param(
    [string]$Managed = 'C:/Program Files (x86)/Steam/steamapps/common/RimWorld/RimWorldWin64_Data/Managed',
    [string]$Harmony,
    [string]$GameData
)
$ErrorActionPreference = 'Stop'
$root = Split-Path $PSScriptRoot -Parent
$mod = Join-Path $root 'Mod'
$assembly = Join-Path $mod 'Assemblies/AncientChineseBeast.dll'
if (-not $GameData) { $GameData = [IO.Path]::GetFullPath((Join-Path $Managed '../../Data')) }
if (-not $Harmony) { $Harmony = [IO.Path]::GetFullPath((Join-Path $Managed '../../../../workshop/content/294100/2009463077/Current/Assemblies/0Harmony.dll')) }
foreach ($path in @((Join-Path $Managed 'Assembly-CSharp.dll'), $Harmony, $GameData)) {
    if (-not (Test-Path -LiteralPath $path)) { throw "Missing prerequisite: $path. Set -Managed, -Harmony or -GameData explicitly." }
}
function Invoke-Check([string]$Name, [scriptblock]$Action) {
    Write-Host "`n=== $Name ==="
    & $Action
    if ($LASTEXITCODE -ne 0) { throw "$Name failed (exit $LASTEXITCODE)." }
}
Push-Location $root
try {
    Invoke-Check 'Content contracts' { & pwsh -NoProfile -File "$PSScriptRoot/Check-Content.ps1" -ModPath $mod }
    Invoke-Check 'Content checker negative controls' { & pwsh -NoProfile -File "$PSScriptRoot/Test-ContentChecker.ps1" }
    Invoke-Check 'Build mod' { & dotnet build "$root/Source" -p:UseSharedCompilation=false }
    Invoke-Check 'Build tests' { & dotnet build "$PSScriptRoot" -p:UseSharedCompilation=false -p:UseAppHost=false }
    $types = Join-Path $root '.build/xml-types.txt'
    Invoke-Check 'Assembly contracts' { & dotnet "$root/.build/bin-tests/Debug/net8.0/AncientChineseBeast.Tests.dll" $Managed $Harmony $types }
    Invoke-Check 'XML classes' { & pwsh -NoProfile -File "$PSScriptRoot/Xml/Check-XmlClasses.ps1" -ModPath $mod -TypeLists "$types,$PSScriptRoot/Xml/optional-mod-types.txt" -Brief }
    Invoke-Check 'XML fields' { & pwsh -NoProfile -File "$PSScriptRoot/Xml/Check-XmlFields.ps1" -ModPath $mod -Managed $Managed -ExtraAssemblies $assembly }
    Invoke-Check 'Def references' { & pwsh -NoProfile -File "$PSScriptRoot/Xml/Check-DefRefs.ps1" -ModPath $mod -Managed $Managed -GameData $GameData -Brief }
    Invoke-Check 'External types' { & pwsh -NoProfile -File "$PSScriptRoot/Xml/Check-TypeRefs.ps1" -ModPath $mod -Managed $Managed }
    Invoke-Check 'Translations and EN/FR coverage' { & pwsh -NoProfile -File "$PSScriptRoot/Check-Translations.ps1" -ModPath $mod -Managed $Managed -GameData $GameData }
    Invoke-Check 'Translation checker negative controls' { & pwsh -NoProfile -File "$PSScriptRoot/Test-TranslationChecker.ps1" }
    Invoke-Check 'Configuration' { & pwsh -NoProfile -File "$PSScriptRoot/Xml/Check-ConfigErrors.ps1" -ModPath $mod -Managed $Managed -GameData $GameData -ExtraAssemblies $assembly }
    Invoke-Check 'XML checker exit codes' { & pwsh -NoProfile -File "$PSScriptRoot/Test-XmlExitCodes.ps1" -Managed $Managed -GameData $GameData -TypeList $types }
    Write-Host "`nAll automated checks passed. In-game scenarios remain manual."
} finally { Pop-Location }
