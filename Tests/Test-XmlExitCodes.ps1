param([string]$Managed, [string]$GameData, [string]$TypeList)
$ErrorActionPreference = 'Stop'
$fixture = Join-Path $PSScriptRoot "../.build/xml-negative-$([guid]::NewGuid().ToString('N'))"
New-Item -ItemType Directory -Path "$fixture/Defs" -Force | Out-Null
'<Defs><ThingDef><defName>TestBadClass</defName><thingClass>Missing.TestClass</thingClass></ThingDef></Defs>' | Set-Content "$fixture/Defs/Fixture.xml"
$output = & pwsh -NoProfile -File "$PSScriptRoot/Xml/Check-XmlClasses.ps1" -ModPath $fixture -TypeLists $TypeList 2>&1
if ($LASTEXITCODE -ne 1 -or ($output -join "`n") -notmatch 'Missing.TestClass') { throw "Class checker did not reject an unknown class: $output" }
Write-Host 'Detected unknown class with exit code 1.'
'<Defs><ThingDef ParentName="MissingTestParent"><defName>TestBadParent</defName></ThingDef></Defs>' | Set-Content "$fixture/Defs/Fixture.xml"
$output = & pwsh -NoProfile -File "$PSScriptRoot/Xml/Check-DefRefs.ps1" -ModPath $fixture -Managed $Managed -GameData $GameData -Brief 2>&1
if ($LASTEXITCODE -ne 1 -or ($output -join "`n") -notmatch 'MissingTestParent') { throw "Reference checker did not reject an unknown parent: $output" }
Write-Host 'Detected unknown parent with exit code 1.'
