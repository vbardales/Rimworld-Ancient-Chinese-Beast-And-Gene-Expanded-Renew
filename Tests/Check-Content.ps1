param([string]$ModPath = "$PSScriptRoot/../Mod")
$ErrorActionPreference = 'Stop'
$failures = [System.Collections.Generic.List[string]]::new()
$script:checks = 0
function Assert-Content([bool]$Condition, [string]$Message) {
    $script:checks++
    if (-not $Condition) { $failures.Add($Message) }
}
$files = @(Get-ChildItem -LiteralPath $ModPath -Recurse -Filter *.xml -File)
Assert-Content ($files.Count -gt 0) 'No XML files found.'
$defs = @()
foreach ($file in $files) {
    try { $doc = [xml](Get-Content -LiteralPath $file.FullName -Raw) }
    catch { Assert-Content $false "Malformed XML: $($file.FullName)"; continue }
    Assert-Content $true "XML: $($file.Name)"
    if ($doc.DocumentElement.Name -eq 'Defs') { $defs += @($doc.SelectNodes('/Defs/*[defName]')) }
}
foreach ($group in ($defs | Group-Object { "$($_.Name)/$($_.defName)" })) {
    Assert-Content ($group.Count -eq 1) "Duplicate definition: $($group.Name)"
}
$genes = @($defs | Where-Object Name -eq GeneDef | ForEach-Object { [string]$_.defName })
$recipes = @($defs | Where-Object { $_.Name -eq 'RecipeDef' -and $_.ParentName -eq 'SZ_ExtractGeneRecipe' })
Assert-Content ($genes.Count -eq 12) 'Expected twelve beast genes.'
Assert-Content ($recipes.Count -eq 12) 'Expected twelve gene extraction recipes.'
foreach ($gene in $genes) {
    $matching = @($recipes | Where-Object { $_.SelectSingleNode('modExtensions/li[@Class="AncientChineseBeast.DefModExtension_Genes"]/gene').InnerText -eq $gene })
    Assert-Content ($matching.Count -eq 1) "Gene must have exactly one extraction recipe: $gene"
}
foreach ($recipe in $recipes) {
    $gene = $recipe.SelectSingleNode('modExtensions/li[@Class="AncientChineseBeast.DefModExtension_Genes"]/gene')
    Assert-Content ($null -ne $gene -and $gene.InnerText -in $genes) "Unknown extraction gene: $($recipe.defName)"
}
$clones = @($defs | Where-Object { $_.Name -eq 'RecipeDef' -and $_.ParentName -eq 'SZ_CloneBeastRecipe' })
Assert-Content ($clones.Count -gt 0) 'No cloning recipes found.'
foreach ($recipe in $clones) {
    $pawn = $recipe.SelectSingleNode('modExtensions/li[@Class="AncientChineseBeast.DefModExtension_CloneBeast"]/pawn')
    $kind = @($defs | Where-Object { $_.Name -eq 'PawnKindDef' -and $_.defName -eq $pawn.InnerText })
    Assert-Content ($null -ne $pawn -and $pawn.InnerText.EndsWith('_Friendly') -and $kind.Count -eq 1) "Clone must reference a friendly pawn kind: $($recipe.defName)"
}
$about = [xml](Get-Content -LiteralPath (Join-Path $ModPath 'About/About.xml') -Raw)
$url = [string]$about.ModMetaData.url
Assert-Content ($url -match '^https://github\.com/[^/]+/[^/]+/?$') 'Metadata must link to the GitHub repository.'
Assert-Content ($url.Length -gt 0 -and $about.ModMetaData.description.Contains($url)) 'Description must include the repository URL.'
Assert-Content ($about.ModMetaData.name.EndsWith('(unofficial)')) 'The unofficial continuation suffix is missing.'
foreach ($dependency in 'brrainz.harmony','Ludeon.RimWorld.Biotech') {
    Assert-Content ($dependency -in @($about.ModMetaData.modDependencies.li.packageId)) "Missing dependency: $dependency"
}

# Compatibility with A Dog Said... Animal Prosthetics 2. The other mod's data is not in this repository, so
# the patch is checked against a stand-in that has its three abstract category defs beside a decoy recipe.
$adsId = 'SamBucher.ADogSaidAnimalProsthetics2'
$adsPatchPath = Join-Path $ModPath 'Patches/ADogSaidAnimalProsthetics2.xml'
Assert-Content (Test-Path -LiteralPath $adsPatchPath) 'The A Dog Said 2 patch is missing.'
if (Test-Path -LiteralPath $adsPatchPath) {
    $adsPatch = [xml](Get-Content -LiteralPath $adsPatchPath -Raw)
    $guard = $adsPatch.SelectSingleNode('/Patch/Operation')
    Assert-Content ($guard.Class -eq 'PatchOperationConditional') 'The A Dog Said 2 patch must be guarded by a conditional on the category def.'
    Assert-Content ($guard.xpath -eq '/Defs/RecipeDef[@Name="ADS_Cat1"]') 'The guard must test for the category def itself.'
    Assert-Content ($null -eq $guard.SelectSingleNode('nomatch')) 'The guard must not fail without the other mod.'
    Assert-Content ($null -eq $adsPatch.SelectSingleNode('//*[@MayRequire]')) 'MayRequire on an operation is read by nothing.'
    $friendly = @($defs | Where-Object { $_.Name -eq 'ThingDef' -and ([string]$_.defName).EndsWith('_Friendly') } | ForEach-Object { [string]$_.defName })
    Assert-Content ($friendly.Count -eq 5) 'Expected five friendly clone races.'
    $expected = @{ ADS_Cat3 = $friendly; ADS_Cat2 = $friendly + 'SZ_Chicken'; ADS_Cat1 = $friendly + 'SZ_Chicken' }
    $standIn = [xml]'<Defs><RecipeDef Name="ADS_Cat1" Abstract="True"><recipeUsers><li>Husky</li></recipeUsers></RecipeDef><RecipeDef Name="ADS_Cat2" Abstract="True"><recipeUsers><li>Husky</li></recipeUsers></RecipeDef><RecipeDef Name="ADS_Cat3" Abstract="True"><recipeUsers><li>Husky</li></recipeUsers></RecipeDef><RecipeDef><defName>Decoy</defName><recipeUsers><li>Husky</li></recipeUsers></RecipeDef></Defs>'
    foreach ($add in @($adsPatch.SelectNodes('//li[@Class="PatchOperationAdd"]'))) {
        $nodes = @($standIn.SelectNodes($add.xpath))
        Assert-Content ($nodes.Count -eq 1) "Add must select exactly one category list: $($add.xpath)"
        $category = if ($add.xpath -match '"(ADS_Cat\d)"') { $Matches[1] } else { '' }
        $added = @($add.SelectNodes('value/li') | ForEach-Object { $_.InnerText })
        Assert-Content ($category -in $expected.Keys) "Unknown category in the patch: $($add.xpath)"
        if ($category -in $expected.Keys) {
            Assert-Content ((@($added | Sort-Object) -join ',') -eq (@($expected[$category] | Sort-Object) -join ',')) "$category must list exactly the animals a colony can own."
        }
    }
    Assert-Content (@($adsPatch.SelectNodes('//li[@Class="PatchOperationAdd"]')).Count -eq 3) 'Expected one add per category.'
    $withoutOther = [xml]'<Defs><RecipeDef><defName>Decoy</defName></RecipeDef></Defs>'
    Assert-Content (@($withoutOther.SelectNodes($guard.xpath)).Count -eq 0) 'Without the other mod the guard must match nothing.'
    $hostile = @($defs | Where-Object { $_.Name -eq 'ThingDef' -and $_.ParentName -eq 'SZBeastParent' -and ([string]$_.defName) -notlike '*_Friendly' -and $_.defName -ne 'SZ_Chicken' } | ForEach-Object { [string]$_.defName })
    $everyAdded = @($adsPatch.SelectNodes('//value/li') | ForEach-Object { $_.InnerText })
    Assert-Content ($hostile.Count -ge 4 -and -not ($hostile | Where-Object { $_ -in $everyAdded })) 'A hostile beast must not be given prosthetics.'
}
# Rest and breeding. Every beast, hostile or tame, rests and has two sexes through the shared parent; a race that says
# otherwise would silently undo it. The three life stages are the vanilla animal ones, and a kind must carry as many
# pictures as its race has stages, or the game reports a config error.
$parentDoc = [xml](Get-Content -LiteralPath (Join-Path $ModPath 'Defs/Pawn/Parent.xml') -Raw)
$parentRace = $parentDoc.SelectSingleNode('/Defs/ThingDef[@Name="SZBeastParent"]/race')
Assert-Content ($null -ne $parentRace) 'SZBeastParent has no race.'
if ($null -ne $parentRace) {
    Assert-Content ($null -eq $parentRace.SelectSingleNode('needsRest') -and $null -eq $parentRace.SelectSingleNode('hasGenders')) 'The parent must leave needsRest and hasGenders at their defaults (true).'
    $stages = @($parentRace.SelectNodes('lifeStageAges/li'))
    Assert-Content (($stages | ForEach-Object { [string]$_.def }) -join ',' -eq 'AnimalBaby,AnimalJuvenile,AnimalAdult') 'The parent race needs the three animal life stages, baby, juvenile and adult, in that order.'
    $ages = @($stages | ForEach-Object { [double]::Parse([string]$_.minAge, [Globalization.CultureInfo]::InvariantCulture) })
    Assert-Content ($ages.Count -eq 3 -and $ages[0] -eq 0 -and $ages[0] -lt $ages[1] -and $ages[1] -lt $ages[2]) 'Life stage ages must ascend from 0.'
    Assert-Content ($null -ne $stages[-1].SelectSingleNode('soundDeath')) 'The adult stage carries the beast''s sounds.'
    Assert-Content ([double]$parentRace.mateMtbHours -gt 0 -and [double]$parentRace.gestationPeriodDays -gt 0 -and $null -ne $parentRace.SelectSingleNode('litterSizeCurve/points')) 'The parent race needs a mating rate, a gestation and a litter size.'
    $beastRaces = @($defs | Where-Object { $_.Name -eq 'ThingDef' -and $_.ParentName -eq 'SZBeastParent' })
    Assert-Content ($beastRaces.Count -eq 11) 'Expected eleven beast races (six hostile, five tame).'
    foreach ($race in $beastRaces) {
        Assert-Content ($null -eq $race.SelectSingleNode('race/needsRest') -and $null -eq $race.SelectSingleNode('race/hasGenders')) "$($race.defName) overrides needsRest or hasGenders."
        $kind = @($defs | Where-Object { $_.Name -eq 'PawnKindDef' -and $_.race -eq $race.defName })
        Assert-Content ($kind.Count -eq 1) "$($race.defName) needs exactly one pawn kind."
        if ($kind.Count -eq 1) { Assert-Content (@($kind[0].SelectNodes('lifeStages/li')).Count -eq 3) "$($kind[0].defName) needs three life stage pictures, as its race has three life stages." }
    }
    # Two races lay eggs instead of giving birth: the tame mingshe, a snake, and the Pleiades star officer, a bird.
    foreach ($layer in @(@('SZ_MingShe_Friendly', 'SZ_MingShe_Friendly'), @('SZ_Chicken', 'SZ_Chicken'))) {
        $egg = @($defs | Where-Object { $_.Name -eq 'ThingDef' -and $_.defName -eq $layer[0] })[0].SelectSingleNode('comps/li[@Class="CompProperties_EggLayer"]')
        Assert-Content ($null -ne $egg) "$($layer[0]) lays eggs."
        if ($null -ne $egg) {
            $fert = @($defs | Where-Object { $_.Name -eq 'ThingDef' -and $_.defName -eq [string]$egg.eggFertilizedDef })
            $unfert = @($defs | Where-Object { $_.Name -eq 'ThingDef' -and $_.defName -eq [string]$egg.eggUnfertilizedDef })
            Assert-Content ($fert.Count -eq 1 -and $unfert.Count -eq 1) "Both eggs of $($layer[0]) must be defined."
            if ($fert.Count -eq 1) { Assert-Content ([string]$fert[0].SelectSingleNode('comps/li[@Class="CompProperties_Hatcher"]/hatcherPawn').InnerText -eq $layer[1]) "The fertilised egg of $($layer[0]) must hatch its own kind." }
        }
    }    $naPath = Join-Path $ModPath 'Patches/NocturnalAnimals.xml'
    Assert-Content (Test-Path -LiteralPath $naPath) 'The Nocturnal Animals patch is missing.'
    if (Test-Path -LiteralPath $naPath) {
        $na = [xml](Get-Content -LiteralPath $naPath -Raw)
        $root = $na.SelectSingleNode('/Patch/Operation')
        Assert-Content ($root.Class -eq 'PatchOperationFindMod' -and @($root.SelectNodes('mods/li')).Count -ge 2) 'The extension class does not exist without its mod: the patch must be guarded by a FindMod naming the continuation and the original.'
        $named = @($na.SelectNodes('//xpath') | ForEach-Object { [regex]::Matches($_.InnerText, 'defName="([^"]+)"') | ForEach-Object { $_.Groups[1].Value } })
        Assert-Content ((@($named | Sort-Object) -join ',') -eq (@($beastRaces | ForEach-Object { [string]$_.defName } | Sort-Object) -join ',')) 'The Nocturnal Animals patch must name each of the eleven beast races exactly once.'
        Assert-Content (@($na.SelectNodes('//bodyClock') | ForEach-Object { $_.InnerText } | Where-Object { $_ -notin 'Nocturnal','Crepuscular' }).Count -eq 0) 'Only the two chosen clocks are used.'
        Assert-Content ($null -eq $na.SelectSingleNode('//*[@MayRequire]')) 'MayRequire on an operation is read by nothing.'
    }
}
# The categories are copied onto the surgery recipes once, when the other mod runs its own patch, so this mod
# has to load before it; a loadAfter as well would make the order unsatisfiable.
Assert-Content ($adsId -in @($about.ModMetaData.loadBefore.li)) 'About.xml must load before A Dog Said 2.'
Assert-Content ($adsId -notin @($about.ModMetaData.loadAfter.li)) 'About.xml must not also load after A Dog Said 2.'
Assert-Content ($adsId -notin @($about.ModMetaData.modDependencies.li.packageId)) 'A Dog Said 2 is optional, not a dependency.'
Write-Output "$script:checks content checks, $($failures.Count) failure(s)."
$failures | Write-Output
if ($failures.Count) { exit 1 }
exit 0
