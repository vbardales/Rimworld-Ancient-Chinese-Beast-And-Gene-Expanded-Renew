# Negative controls: each intentional fault must make Check-Content.ps1 fail, for the expected reason.
$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot '../../scripts/lib/TestRunner.ps1')
$root = Split-Path $PSScriptRoot -Parent
$fixture = Join-Path $root "build/content-fixture-$([guid]::NewGuid().ToString('N'))"
New-Item -ItemType Directory -Path $fixture -Force | Out-Null
# Copy XML only; no game assemblies or artwork are needed by these tests.
foreach ($file in Get-ChildItem "$root/Mod" -Recurse -Filter *.xml -File) {
    $relative = [IO.Path]::GetRelativePath("$root/Mod", $file.FullName)
    $target = Join-Path $fixture $relative
    New-Item -ItemType Directory -Path (Split-Path $target) -Force | Out-Null
    Copy-Item -LiteralPath $file.FullName -Destination $target
}
function Expect-Failure([string]$Relative, [scriptblock]$Mutation, [string]$Diagnostic) {
    Test-That "Check-Content fails on: $Diagnostic" {
        $path = Join-Path $fixture $Relative
        $original = [IO.File]::ReadAllText($path)
        try {
            $mutated = & $Mutation $original
            if ($mutated -ceq $original) { throw 'The mutation changed nothing.' }
            [IO.File]::WriteAllText($path, $mutated)
            $output = & pwsh -NoProfile -File "$PSScriptRoot/Check-Content.ps1" -ModPath $fixture 2>&1
            $LASTEXITCODE -eq 1 -and ($output -join "`n") -match [regex]::Escape($Diagnostic)
        } finally { [IO.File]::WriteAllText($path, $original) }
    }
}
Expect-Failure 'Defs/Recipe/ExtractGenes.xml' { param($s) $s.Replace('<gene>SZGene_YearBeast_Flamethrower</gene>', '<gene>MissingGene</gene>') } 'Unknown extraction gene'
Expect-Failure 'Defs/Recipe/CloneBeast.xml' { param($s) $s.Replace('<pawn>SZ_YearBeast_Friendly</pawn>', '<pawn>SZ_YearBeast</pawn>') } 'Clone must reference a friendly pawn kind'
Expect-Failure 'About/About.xml' { param($s) [regex]::Replace($s, '(?s)<description>.*?</description>', { param($m) $m.Value.Replace('https://github.com/vbardales/Rimworld-Ancient-Chinese-Beast-And-Gene-Expanded-Renew', 'Source available on request.') }) } 'description includes the repository URL'
Expect-Failure 'Patches/ADogSaidAnimalProsthetics2.xml' { param($s) [regex]::new('<li>SZ_QiongQi_Friendly</li>').Replace($s, '', 1) } 'ADS_Cat3 must list exactly the animals a colony can own'
Expect-Failure 'Patches/NocturnalAnimals.xml' { param($s) $s.Replace('<bodyClock>Nocturnal</bodyClock>', '<bodyClock>Diurnal</bodyClock>') } 'must get exactly one Nocturnal clock'
Complete-Tests
