param(
    [string]$ModPath = "$PSScriptRoot/../Mod",
    [string]$OutputPath = "$PSScriptRoot/../.build/translation-inventory.json",
    [string]$Managed = 'C:/Program Files (x86)/Steam/steamapps/common/RimWorld/RimWorldWin64_Data/Managed',
    [string]$GameData = 'C:/Program Files (x86)/Steam/steamapps/common/RimWorld/Data'
)
$ErrorActionPreference = 'Stop'
# Reuse the versioned checker's inheritance, reflection and handle rules. Its path
# validation runs first; this inventory adds coverage, which that checker cannot prove.
. "$PSScriptRoot/Xml/Check-DefInjected.ps1" -TransMod $ModPath -Managed $Managed -GameData $GameData -ExtraAssemblies "$ModPath/Assemblies/AncientChineseBeast.dll"
$inventory = [System.Collections.Generic.List[object]]::new()
function Visit-Text($node, [Type]$type, [string]$path, [string]$defKind) {
    $type = Get-ElementType $node $type
    $fields = Get-FieldsRecursive $type
    foreach ($child in $node.ChildNodes) {
        if ($child.NodeType -ne 'Element' -or -not $fields.ContainsKey($child.LocalName)) { continue }
        $field = $fields[$child.LocalName]
        $next = "$path.$($field.Name)"
        if ($field.FieldType -eq [string]) {
            if ((Has-Attr $field 'MustTranslateAttribute') -and -not [string]::IsNullOrWhiteSpace($child.InnerText)) {
                $inventory.Add([pscustomobject]@{type=$defKind; key=$next; english=$child.InnerText})
            }
        } elseif ($field.FieldType.IsGenericType -and $field.FieldType.GetGenericTypeDefinition() -eq [System.Collections.Generic.List``1]) {
            $elementType = $field.FieldType.GetGenericArguments()[0]
            if ($elementType -eq [string]) {
                if (Has-Attr $field 'MustTranslateAttribute') { throw "Translatable string list needs explicit inventory support: $next" }
            } elseif (-not $elementType.IsPrimitive -and -not $elementType.IsEnum -and -not $defType.IsAssignableFrom($elementType)) {
                $map = Get-ListHandleMap $child $elementType
                for ($i=0; $i -lt $map.Elements.Count; $i++) { Visit-Text $map.Elements[$i] $elementType "$next.$($map.Suggested[$i])" $defKind }
            }
        } elseif (-not $field.FieldType.IsPrimitive -and -not $field.FieldType.IsEnum -and -not $defType.IsAssignableFrom($field.FieldType)) {
            Visit-Text $child $field.FieldType $next $defKind
        }
    }
}
[System.AppDomain]::CurrentDomain.add_AssemblyResolve($script:asmResolver)
try {
    foreach ($file in Get-ChildItem "$ModPath/Defs" -Recurse -Filter *.xml) {
        $xml = [xml](Get-Content $file.FullName -Raw)
        foreach ($node in $xml.SelectNodes('/Defs/*[defName]')) {
            $resolved = @($defs[$node.defName] | Where-Object Type -eq $node.LocalName)[0]
            Visit-Text $resolved.Node $byName[$node.LocalName] $node.defName $node.LocalName
        }
    }
} finally { [System.AppDomain]::CurrentDomain.remove_AssemblyResolve($script:asmResolver) }
$inventory | Sort-Object type,key | ConvertTo-Json -Depth 5 | Set-Content -LiteralPath $OutputPath -Encoding utf8
Write-Host "Inventoried $($inventory.Count) translatable Def fields: $OutputPath"
