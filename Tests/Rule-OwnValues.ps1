param([Parameter(Mandatory)][string]$ModRoot, [string]$SharedDir)

# Own values and facts of this mod's content: 12 beast genes and extraction recipes, friendly clone races, 11 beast races (rest, sexes, three
# life stages, eggs), the A Dog Said 2 and Nocturnal Animals patches run on stand-ins, the About.xml links and load order. One consumer,
# nothing shareable; Tests/Test-Mod.ps1 (generated) runs it after the shared checks. Prints findings, exit 1 on any.
# The generic checks (XML well formed, duplicate defNames, About shape, images, def references, XML fields, translations) live in the shared scripts.
$ErrorActionPreference = 'Stop'
$root = (Resolve-Path -LiteralPath $ModRoot).Path
$ModPath = Join-Path $root 'Mod'
$script:findings = @()
$engine = @($SharedDir, (Join-Path $root '../scripts')) | Where-Object { $_ } | ForEach-Object { Join-Path $_ 'lib/PatchEngine.ps1' } | Where-Object { Test-Path -LiteralPath $_ } | Select-Object -First 1
if (-not $engine) { Write-Warning 'lib/PatchEngine.ps1 not found (needs the protocols checkout): the patch rules are SKIPPED here, not passed (every local run has it).' } else { . $engine }

# One rule: the block returns its problems; each is printed under the rule name. A test that returns $false is a problem too.
function It([string]$name, [scriptblock]$body) {
    try { $problems = @(& $body | Where-Object { $_ }) } catch { $problems = @("threw: $($_.Exception.GetBaseException().Message)") }
    foreach ($p in $problems) { $script:findings += "[$name] $p" }
}
function Test-That([string]$TrName, [scriptblock]$TrBody) {
    It $TrName { $r = & $TrBody; if ($r -ne $true) { "failed" } }
}
function Read-Xml([string]$Path) { $d = New-Object System.Xml.XmlDocument; $d.Load($Path); $d }
$defs = @()
foreach ($file in Get-ChildItem -LiteralPath $ModPath -Recurse -Filter *.xml -File) {
    $doc = Read-Xml $file.FullName
    if ($doc.DocumentElement.Name -eq 'Defs') { $defs += @($doc.SelectNodes('/Defs/*[defName]')) }
}
function Get-Def([string]$Type, [string]$DefName) { @($defs | Where-Object { $_.Name -eq $Type -and $_.defName -eq $DefName }) }
$about = Read-Xml (Join-Path $ModPath 'About/About.xml')
$genes = @($defs | Where-Object Name -eq GeneDef | ForEach-Object { [string]$_.defName })
$recipes = @($defs | Where-Object { $_.Name -eq 'RecipeDef' -and $_.ParentName -eq 'SZ_ExtractGeneRecipe' })
$geneExt = 'modExtensions/li[@Class="AncientChineseBeast.DefModExtension_Genes"]/gene'

Test-That 'twelve beast genes and twelve extraction recipes' { $genes.Count -eq 12 -and $recipes.Count -eq 12 }
It 'each gene has exactly one extraction recipe, each recipe a known gene' {
    foreach ($gene in $genes) {
        if (@($recipes | Where-Object { $_.SelectSingleNode($geneExt).InnerText -eq $gene }).Count -ne 1) { "Gene must have exactly one extraction recipe: $gene" }
    }
    foreach ($recipe in $recipes) {
        $gene = $recipe.SelectSingleNode($geneExt)
        if ($null -eq $gene -or $gene.InnerText -notin $genes) { "Unknown extraction gene: $($recipe.defName)" }
    }
}
$clones = @($defs | Where-Object { $_.Name -eq 'RecipeDef' -and $_.ParentName -eq 'SZ_CloneBeastRecipe' })
Test-That 'cloning recipes exist' { $clones.Count -gt 0 }
It 'each clone recipe references a friendly pawn kind' {
    foreach ($recipe in $clones) {
        $pawn = $recipe.SelectSingleNode('modExtensions/li[@Class="AncientChineseBeast.DefModExtension_CloneBeast"]/pawn')
        if ($null -eq $pawn -or -not $pawn.InnerText.EndsWith('_Friendly') -or @(Get-Def PawnKindDef $pawn.InnerText).Count -ne 1) { "Clone must reference a friendly pawn kind: $($recipe.defName)" }
    }
}
$url = [string]$about.ModMetaData.url
Test-That 'metadata links to the GitHub repository' { $url -match '^https://github\.com/[^/]+/[^/]+/?$' }
Test-That 'description includes the repository URL' { $url.Length -gt 0 -and $about.ModMetaData.description.Contains($url) }
It 'About.xml: unofficial title and own published id (not the original 3292446841)' {
    if (-not ([string]$about.ModMetaData.name).EndsWith('(unofficial)')) { 'The title must end with (unofficial).' }
    $idFile = Join-Path $ModPath 'About/PublishedFileId.txt'
    if ((Test-Path -LiteralPath $idFile) -and ((Get-Content -LiteralPath $idFile -Raw).Trim() -eq '3292446841')) { 'PublishedFileId.txt holds the ORIGINAL mod id.' }
}
It 'About.xml names the dependencies' { foreach ($d in 'brrainz.harmony', 'Ludeon.RimWorld.Biotech') { if ($d -notin @($about.ModMetaData.modDependencies.li.packageId)) { "Missing dependency: $d" } } }

# A Dog Said... Animal Prosthetics 2. The other mod's data is not in this repository: the patch runs through the shared
# PatchEngine on a stand-in with its three abstract category defs beside a decoy recipe.
$adsId = 'SamBucher.ADogSaidAnimalProsthetics2'
$adsPatch = Join-Path $ModPath 'Patches/ADogSaidAnimalProsthetics2.xml'
$friendly = @($defs | Where-Object { $_.Name -eq 'ThingDef' -and ([string]$_.defName).EndsWith('_Friendly') } | ForEach-Object { [string]$_.defName })
$standIn = '<Defs><RecipeDef Name="ADS_Cat1" Abstract="True"><recipeUsers><li>Husky</li></recipeUsers></RecipeDef><RecipeDef Name="ADS_Cat2" Abstract="True"><recipeUsers><li>Husky</li></recipeUsers></RecipeDef><RecipeDef Name="ADS_Cat3" Abstract="True"><recipeUsers><li>Husky</li></recipeUsers></RecipeDef><RecipeDef><defName>Decoy</defName><recipeUsers><li>Husky</li></recipeUsers></RecipeDef></Defs>'
Test-That 'five friendly clone races' { $friendly.Count -eq 5 }
Test-That 'the A Dog Said 2 patch exists' { Test-Path -LiteralPath $adsPatch }
It 'the patch gives each category exactly the animals a colony can own' {
    if (-not $engine) { return }
    $doc = New-Object System.Xml.XmlDocument; $doc.LoadXml($standIn)
    Invoke-PatchFile $adsPatch $doc -RequireMatch
    $expected = @{ ADS_Cat3 = $friendly; ADS_Cat2 = $friendly + 'SZ_Chicken'; ADS_Cat1 = $friendly + 'SZ_Chicken' }
    foreach ($cat in $expected.Keys) {
        $got = @($doc.SelectNodes("/Defs/RecipeDef[@Name='$cat']/recipeUsers/li") | ForEach-Object { $_.InnerText } | Where-Object { $_ -ne 'Husky' })
        if ((@($got | Sort-Object) -join ',') -ne (@($expected[$cat] | Sort-Object) -join ',')) { "$cat must list exactly the animals a colony can own: $($got -join ',')" }
    }
    if (@($doc.SelectNodes('/Defs/RecipeDef[defName="Decoy"]/recipeUsers/li')).Count -ne 1) { 'The decoy recipe must stay untouched.' }
}
It 'without the other mod the patch changes nothing' {
    if (-not $engine) { return }
    $doc = New-Object System.Xml.XmlDocument; $doc.LoadXml('<Defs><RecipeDef><defName>Decoy</defName></RecipeDef></Defs>')
    $before = $doc.OuterXml
    Invoke-PatchFile $adsPatch $doc -RequireMatch
    if ($doc.OuterXml -ne $before) { 'The patch edited a document without the category defs.' }
}
It 'a hostile beast is given no prosthetics' {
    if (-not $engine) { return }
    $hostile = @($defs | Where-Object { $_.Name -eq 'ThingDef' -and $_.ParentName -eq 'SZBeastParent' -and ([string]$_.defName) -notlike '*_Friendly' -and $_.defName -ne 'SZ_Chicken' } | ForEach-Object { [string]$_.defName })
    if ($hostile.Count -lt 4) { 'Expected at least four hostile beasts.' }
    $doc = New-Object System.Xml.XmlDocument; $doc.LoadXml($standIn)
    Invoke-PatchFile $adsPatch $doc
    foreach ($h in $hostile) { if ($doc.SelectNodes("//recipeUsers/li[text()='$h']").Count) { "Hostile beast $h must not be given prosthetics." } }
}
# The categories are copied onto the surgery recipes once, when the other mod runs its own patch, so this mod has to load
# before it; a loadAfter as well would make the order unsatisfiable.
Test-That 'About.xml loads before A Dog Said 2' { $adsId -in @($about.ModMetaData.loadBefore.li) }
Test-That 'About.xml does not also load after A Dog Said 2' { $adsId -notin @($about.ModMetaData.loadAfter.li) }
Test-That 'A Dog Said 2 is optional, not a dependency' { $adsId -notin @($about.ModMetaData.modDependencies.li.packageId) }

# Rest and breeding. Every beast, hostile or tame, rests and has two sexes through the shared parent; a race that says
# otherwise would silently undo it. The three life stages are the vanilla animal ones, and a kind must carry as many
# pictures as its race has stages, or the game reports a config error.
$parentRace = (Read-Xml (Join-Path $ModPath 'Defs/Pawn/Parent.xml')).SelectSingleNode('/Defs/ThingDef[@Name="SZBeastParent"]/race')
Test-That 'SZBeastParent has a race' { $null -ne $parentRace }
$stages = @($parentRace.SelectNodes('lifeStageAges/li'))
$ages = @($stages | ForEach-Object { [double]::Parse([string]$_.minAge, [Globalization.CultureInfo]::InvariantCulture) })
Test-That 'the parent leaves needsRest and hasGenders at their defaults' { $null -eq $parentRace.SelectSingleNode('needsRest') -and $null -eq $parentRace.SelectSingleNode('hasGenders') }
Test-That 'the parent race has the baby, juvenile and adult stages in order' { (($stages | ForEach-Object { [string]$_.def }) -join ',') -eq 'AnimalBaby,AnimalJuvenile,AnimalAdult' }
Test-That 'life stage ages ascend from 0' { $ages.Count -eq 3 -and $ages[0] -eq 0 -and $ages[0] -lt $ages[1] -and $ages[1] -lt $ages[2] }
Test-That 'the adult stage carries the death sound' { $null -ne $stages[-1].SelectSingleNode('soundDeath') }
Test-That 'the parent race has a mating rate, a gestation and a litter size' { [double]$parentRace.mateMtbHours -gt 0 -and [double]$parentRace.gestationPeriodDays -gt 0 -and $null -ne $parentRace.SelectSingleNode('litterSizeCurve/points') }
$beastRaces = @($defs | Where-Object { $_.Name -eq 'ThingDef' -and $_.ParentName -eq 'SZBeastParent' })
Test-That 'eleven beast races (six hostile, five tame)' { $beastRaces.Count -eq 11 }
It 'each beast keeps rest and sexes, has one pawn kind with three life stage pictures' {
    foreach ($race in $beastRaces) {
        if ($null -ne $race.SelectSingleNode('race/needsRest') -or $null -ne $race.SelectSingleNode('race/hasGenders')) { "$($race.defName) overrides needsRest or hasGenders." }
        $kind = @($defs | Where-Object { $_.Name -eq 'PawnKindDef' -and $_.race -eq $race.defName })
        if ($kind.Count -ne 1) { "$($race.defName) needs exactly one pawn kind." }
        elseif (@($kind[0].SelectNodes('lifeStages/li')).Count -ne 3) { "$($kind[0].defName) needs three life stage pictures, as its race has three life stages." }
    }
}
# Two races lay eggs instead of giving birth: the tame mingshe, a snake, and the Pleiades star officer, a bird.
It 'the mingshe and the star officer lay eggs that hatch their own kind' {
    foreach ($layer in 'SZ_MingShe_Friendly', 'SZ_Chicken') {
        $egg = @(Get-Def ThingDef $layer)[0].SelectSingleNode('comps/li[@Class="CompProperties_EggLayer"]')
        if ($null -eq $egg) { "$layer lays eggs."; continue }
        $fert = @(Get-Def ThingDef ([string]$egg.eggFertilizedDef))
        if ($fert.Count -ne 1 -or @(Get-Def ThingDef ([string]$egg.eggUnfertilizedDef)).Count -ne 1) { "Both eggs of $layer must be defined."; continue }
        if ([string]$fert[0].SelectSingleNode('comps/li[@Class="CompProperties_Hatcher"]/hatcherPawn').InnerText -ne $layer) { "The fertilised egg of $layer must hatch its own kind." }
    }
}
# Nocturnal Animals: the extension class does not exist without that mod, so the patch must do nothing unless one of its
# two names is active, and must then give each of the eleven races its clock.
$naPatch = Join-Path $ModPath 'Patches/NocturnalAnimals.xml'
$clocks = @{ Nocturnal = 'SZ_QiongQi', 'SZ_QiongQi_Friendly', 'SZ_SeXie', 'SZ_SeXie_Friendly', 'SZ_SeXieInsect', 'SZ_SeXieInsect_Friendly'
             Crepuscular = 'SZ_MingShe', 'SZ_MingShe_Friendly', 'SZ_YearBeast', 'SZ_YearBeast_Friendly', 'SZ_Chicken' }
function New-BeastDoc { $d = New-Object System.Xml.XmlDocument; [void]$d.AppendChild($d.CreateElement('Defs')); foreach ($r in $beastRaces) { [void]$d.DocumentElement.AppendChild($d.ImportNode($r, $true)) }; $d }
Test-That 'the Nocturnal Animals patch exists' { Test-Path -LiteralPath $naPatch }
It 'with either name active each race gets its clock' {
    if (-not $engine) { return }
    foreach ($name in '[XND] Nocturnal Animals (Continued)', '[XND] Nocturnal Animals') {
        $doc = New-BeastDoc
        Invoke-PatchFile $naPatch $doc -ActiveMods @($name) -RequireMatch
        foreach ($clock in $clocks.Keys) {
            foreach ($race in $clocks[$clock]) {
                $got = @($doc.SelectNodes("/Defs/ThingDef[defName='$race']/modExtensions/li[@Class='NocturnalAnimals.ExtendedRaceProperties']/bodyClock") | ForEach-Object { $_.InnerText })
                if ($got.Count -ne 1 -or $got[0] -ne $clock) { "$race must get exactly one $clock clock with '$name' active: $($got -join ',')" }
            }
        }
    }
}
It 'without either name nothing is added' {
    if (-not $engine) { return }
    $doc = New-BeastDoc; $before = $doc.OuterXml
    Invoke-PatchFile $naPatch $doc -ActiveMods @('Some other mod')
    if ($doc.OuterXml -ne $before) { 'The patch edited the defs without Nocturnal Animals.' }
}
Test-That 'no operation relies on MayRequire' { $null -eq (Read-Xml $naPatch).SelectSingleNode('//*[@MayRequire]') -and $null -eq (Read-Xml $adsPatch).SelectSingleNode('//*[@MayRequire]') }

if ($script:findings.Count) { $script:findings; exit 1 }
Write-Output "PASS: Rule-OwnValues ($($defs.Count) defs, $($beastRaces.Count) beast races)"
