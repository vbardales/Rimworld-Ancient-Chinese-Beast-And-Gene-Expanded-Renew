# Negative controls: each intentional fault must make the checker fail for the expected reason.
$ErrorActionPreference = 'Stop'
$root = Split-Path $PSScriptRoot -Parent
$fixture = Join-Path $root ".build/content-fixture-$([guid]::NewGuid().ToString('N'))"
New-Item -ItemType Directory -Path $fixture -Force | Out-Null
# Copy XML only; no game assemblies or artwork are needed by these tests.
foreach ($file in Get-ChildItem "$root/Mod" -Recurse -Filter *.xml -File) {
    $relative = [IO.Path]::GetRelativePath("$root/Mod", $file.FullName)
    $target = Join-Path $fixture $relative
    New-Item -ItemType Directory -Path (Split-Path $target) -Force | Out-Null
    Copy-Item -LiteralPath $file.FullName -Destination $target
}
function Expect-Failure([string]$Relative, [scriptblock]$Mutation, [string]$Diagnostic) {
    $path = Join-Path $fixture $Relative
    $original = [IO.File]::ReadAllText($path)
    try {
        [IO.File]::WriteAllText($path, (& $Mutation $original))
        $output = & pwsh -NoProfile -File "$PSScriptRoot/Check-Content.ps1" -ModPath $fixture 2>&1
        if ($LASTEXITCODE -ne 1 -or ($output -join "`n") -notmatch [regex]::Escape($Diagnostic)) {
            throw "Negative control failed: $Diagnostic`n$output"
        }
        Write-Host "Detected: $Diagnostic"
    } finally { [IO.File]::WriteAllText($path, $original) }
}
Expect-Failure 'Defs/Recipe/ExtractGenes.xml' { param($s) $s + '<broken>' } 'Malformed XML'
Expect-Failure 'Defs/Recipe/ExtractGenes.xml' { param($s) $s.Replace('<gene>SZGene_YearBeast_Flamethrower</gene>', '<gene>MissingGene</gene>') } 'Unknown extraction gene'
Expect-Failure 'Defs/Recipe/ExtractGenes.xml' { param($s) $s.Replace('</Defs>', '<RecipeDef><defName>SZ_ExtractGene</defName></RecipeDef></Defs>') } 'Duplicate definition'
Expect-Failure 'Defs/Recipe/CloneBeast.xml' { param($s) $s.Replace('<pawn>SZ_YearBeast_Friendly</pawn>', '<pawn>SZ_YearBeast</pawn>') } 'Clone must reference a friendly pawn kind'
Expect-Failure 'About/About.xml' { param($s) $s.Replace('Source, changelog and the list of defects inherited from the original: https://github.com/vbardales/Rimworld-Ancient-Chinese-Beast-And-Gene-Expanded-Renew', 'Source available on request.') } 'Description must include the repository URL'
Write-Host 'Five negative controls passed. Fixtures are retained under .build for inspection.'
