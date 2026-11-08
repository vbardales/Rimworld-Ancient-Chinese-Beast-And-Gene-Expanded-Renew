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
if (-not $Harmony) { $Harmony = [IO.Path]::GetFullPath((Join-Path $Managed '../../../../workshop/content/294100/2009463077/1.6/Assemblies/0Harmony.dll')) }
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
    Invoke-Check 'Own values of the mod' { & pwsh -NoProfile -File "$PSScriptRoot/Rule-OwnValues.ps1" -ModRoot $root -SharedDir (Resolve-Path "$root/../scripts").Path }
    Invoke-Check 'Build mod' { & dotnet build "$root/Source" -p:UseSharedCompilation=false }
    Invoke-Check 'Build tests' { & dotnet build "$PSScriptRoot" -p:UseSharedCompilation=false -p:UseAppHost=false }
    $types = Join-Path $root 'build/xml-types.txt'
    Invoke-Check 'Assembly contracts' { & dotnet "$root/build/bin-tests/Debug/net8.0/AncientChineseBeast.Tests.dll" $Managed $Harmony $types }
    Invoke-Check 'Shared offline checks' { & pwsh -NoProfile -File "$PSScriptRoot/../../scripts/Run-OfflineChecks.ps1" -ModRoot $root -Skip DefInjected,SettingsContract -TypeLists "$types,$PSScriptRoot/Xml/optional-mod-types.txt" -ExtraAssemblies $assembly -Brief -TranslationsArgs '-AllowUnused,SZ_CannotReachBuildingToExtractGene,-VanillaKeyed,TextMote_Dodge' }
    Write-Host "`nAll automated checks passed. In-game scenarios remain manual."
} finally { Pop-Location }
