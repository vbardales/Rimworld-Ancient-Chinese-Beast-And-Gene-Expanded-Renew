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
Write-Output "$script:checks content checks, $($failures.Count) failure(s)."
$failures | Write-Output
if ($failures.Count) { exit 1 }
exit 0
