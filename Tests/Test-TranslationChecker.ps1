param([string]$InventoryPath = "$PSScriptRoot/../.build/translation-inventory.json")
$ErrorActionPreference = 'Stop'
$root = [IO.Path]::GetFullPath("$PSScriptRoot/..")
$fixtures = Join-Path $root ".build/translation-negative-$([Guid]::NewGuid().ToString('N'))"
$cases = @('missing-def','missing-key-both','duplicate-key','parameter')
foreach ($case in $cases) {
    $fixture = Join-Path $fixtures $case
    [void][IO.Directory]::CreateDirectory($fixture)
    Copy-Item -LiteralPath "$root/Mod/Languages" -Destination $fixture -Recurse
    $path = "$fixture/Languages/French/Keyed/text.xml"
    $xml = [xml](Get-Content -LiteralPath $path -Raw)
    switch ($case) {
        'missing-def' {
            $path = "$fixture/Languages/French/DefInjected/AbilityDef/Translations.xml"
            $xml = [xml](Get-Content -LiteralPath $path -Raw)
            [void]$xml.LanguageData.RemoveChild($xml.SelectSingleNode('/LanguageData/*'))
            $expected = 'Missing French:'
        }
        'missing-key-both' {
            foreach ($language in 'English','French') {
                $keyPath = "$fixture/Languages/$language/Keyed/text.xml"
                $keyXml = [xml](Get-Content -LiteralPath $keyPath -Raw)
                [void]$keyXml.LanguageData.RemoveChild($keyXml.SelectSingleNode('/LanguageData/SZ_DebugNianScheduled'))
                $keyXml.Save($keyPath)
            }
            $expected = 'Missing English Keyed: SZ_DebugNianScheduled'
        }
        'duplicate-key' {
            [void]$xml.LanguageData.AppendChild($xml.SelectSingleNode('/LanguageData/SZ_DebugClockLogged').CloneNode($true))
            $expected = 'Duplicate entry:'
        }
        'parameter' {
            $path = "$fixture/Languages/French/DefInjected/DamageDef/Translations.xml"
            $xml = [xml](Get-Content -LiteralPath $path -Raw)
            $node = $xml.SelectSingleNode('/LanguageData/*[contains(text(),"{0}")]')
            $node.InnerText = $node.InnerText.Replace('{0}', '{1}')
            $expected = 'Formatting mismatch:'
        }
    }
    if ($case -ne 'missing-key-both') { $xml.Save($path) }
    $result = & pwsh -NoProfile -File "$PSScriptRoot/Check-Translations.ps1" -ModPath $fixture -InventoryPath $InventoryPath -UseExistingInventory 2>&1 | Out-String
    if ($LASTEXITCODE -ne 1 -or -not $result.Contains($expected)) { throw "Negative control failed: $case`n$result" }
    Write-Output "Detected: $case"
}
Write-Output 'Four translation negative controls passed.'
