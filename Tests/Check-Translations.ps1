param(
    [string]$ModPath = "$PSScriptRoot/../Mod",
    [string]$SourcePath = "$PSScriptRoot/../Source",
    [string]$Managed = 'C:/Program Files (x86)/Steam/steamapps/common/RimWorld/RimWorldWin64_Data/Managed',
    [string]$GameData = 'C:/Program Files (x86)/Steam/steamapps/common/RimWorld/Data',
    [string]$InventoryPath = "$PSScriptRoot/../.build/translation-inventory.json",
    [switch]$UseExistingInventory
)
$ErrorActionPreference = 'Stop'
if (-not $UseExistingInventory) {
    & pwsh -NoProfile -File "$PSScriptRoot/Get-TranslationInventory.ps1" -ModPath $ModPath -Managed $Managed -GameData $GameData -OutputPath $InventoryPath
    if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }
}
$items = @(Get-Content -LiteralPath $InventoryPath -Raw | ConvertFrom-Json)
if (-not $items.Count) { throw 'Empty translation inventory.' }
$failures = [System.Collections.Generic.List[string]]::new()
function Read-Entries([string]$path, [bool]$typed) {
    $entries = [System.Collections.Generic.Dictionary[string,string]]::new([StringComparer]::Ordinal)
    foreach ($file in Get-ChildItem -LiteralPath $path -Recurse -Filter *.xml) {
        $xml = [xml](Get-Content $file.FullName -Raw)
        foreach ($node in $xml.SelectNodes('/LanguageData/*')) {
            $key = if ($typed) { "$($file.Directory.Name)/$($node.LocalName)" } else { $node.LocalName }
            if (-not $entries.TryAdd($key, $node.InnerText)) { $failures.Add("Duplicate entry: $key in $path") }
            if ([string]::IsNullOrWhiteSpace($node.InnerText)) { $failures.Add("Empty entry: $key in $path") }
        }
    }
    return ,$entries
}
function Tokens([string]$text, [string]$pattern) {
    return (([regex]::Matches($text, $pattern) | ForEach-Object Value | Sort-Object) -join '|')
}
function Compare-Text([string]$key, [string]$english, [string]$french) {
    foreach ($pattern in @('\{[^{}]+\}', '</?[a-zA-Z][^>]*>', '\\n')) {
        if ((Tokens $english $pattern) -cne (Tokens $french $pattern)) { $failures.Add("Formatting mismatch: $key ($pattern)") }
    }
    foreach ($text in @($english, $french)) {
        if ($text -match '[\p{IsCJKUnifiedIdeographs}]|\bTODO\b|\bTBD\b') { $failures.Add("Untranslated text: $key") }
    }
    # Proper names and words spelled identically in both languages, reviewed individually.
    if ($english -ceq $french -and $english -cnotin @('mingshe','qiongqi','explosion','tunnel')) {
        $failures.Add("Unreviewed identical translation: $key")
    }
}
$en = Read-Entries "$ModPath/Languages/English/DefInjected" $true
$fr = Read-Entries "$ModPath/Languages/French/DefInjected" $true
$owned = [System.Collections.Generic.HashSet[string]]::new([StringComparer]::Ordinal)
foreach ($item in $items) {
    $key = "$($item.type)/$($item.key)"
    if (-not $owned.Add($key)) { $failures.Add("Duplicate inventory path: $key") }
    $text = if ($en.ContainsKey($key)) { $en[$key] } else { $item.english }
    if ([string]::IsNullOrWhiteSpace($text)) { $failures.Add("Missing English: $key") }
    if (-not $fr.ContainsKey($key)) { $failures.Add("Missing French: $key"); continue }
    Compare-Text $key $text $fr[$key]
}
foreach ($key in @($en.Keys) + @($fr.Keys)) {
    if (-not $owned.Contains($key)) { $failures.Add("Entry outside the field inventory: $key") }
}
$enKeys = Read-Entries "$ModPath/Languages/English/Keyed" $false
$frKeys = Read-Entries "$ModPath/Languages/French/Keyed" $false
$used = [System.Collections.Generic.HashSet[string]]::new([StringComparer]::Ordinal)
foreach ($file in Get-ChildItem -LiteralPath $SourcePath -Filter *.cs) {
    $code = Get-Content $file.FullName -Raw
    foreach ($pattern in @('"(SZ_[^"]+)"\s*\.Translate\(', 'LocalizedAction\("(SZ_[^"]+)"')) {
        foreach ($match in [regex]::Matches($code, $pattern)) { [void]$used.Add($match.Groups[1].Value) }
    }
    if ($code -match 'Messages\.Message\("[^"\r\n]+"\s*,') { $failures.Add("Hardcoded message in $($file.Name)") }
    if ($code -match '\[DebugAction\(') { $failures.Add("Untranslated debug attribute in $($file.Name)") }
}
# Retain the original unused key for compatibility; it is not evidence of active UI coverage.
[void]$used.Add('SZ_CannotReachBuildingToExtractGene')
foreach ($key in $used) {
    if (-not $enKeys.ContainsKey($key)) { $failures.Add("Missing English Keyed: $key"); continue }
    if (-not $frKeys.ContainsKey($key)) { $failures.Add("Missing French Keyed: $key"); continue }
    Compare-Text $key $enKeys[$key] $frKeys[$key]
}
foreach ($key in @($enKeys.Keys) + @($frKeys.Keys)) {
    if (-not $used.Contains($key)) { $failures.Add("Unused Keyed entry needs review: $key") }
}
Write-Output "$($items.Count) Def fields, $($used.Count) Keyed entries (including one legacy key), $($failures.Count) failure(s)."
$failures | Write-Output
if ($failures.Count) { exit 1 }
exit 0
