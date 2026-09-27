# A pass of its own: this file plays only when the one optional mod About.xml names in loadAfter is staged
# (ninedaylongbow.ChineseComprehensiveExpansion, Workshop 3221850511), with
#
#   Run-PickleWsl.ps1 -Mod AncientChineseBeastAndGeneExpandedRenew -DepMap wsl-deps.cce.map `
#     -Filter '17-chinese-comprehensive-expansion'
#
# and is skipped by requirement in every other pass, where it counts as skipped and not as passed. Pass 3 of
# Tests/Pickle/README.md, "Passes" (owed since AUDIT.md and, until now, not written because the Workshop id
# had not been looked up).
#
# That mod has no patch of its own for this one and this mod has none for it: the whole of the compatibility
# is the loadAfter ordering, so this pass settles exactly that and that nothing the two mods define collides.
# It needs no save: both are settled while the defs load.
@requires:ninedaylongbow.ChineseComprehensiveExpansion
Feature: Chinese Comprehensive Expansion, the one optional mod named in loadAfter

  Scenario: loads after it, with no conflict
    Given the main menu is open
    Then mod "ninedaylongbow.ChineseComprehensiveExpansion" is loaded
    And mod "nelim.ancientchinesebeastandgeneexpanded" is loaded
    And mod "nelim.ancientchinesebeastandgeneexpanded" loads after "ninedaylongbow.ChineseComprehensiveExpansion"
    And def "SZ_MingShe" of type "PawnKindDef" exists
    And def "SZ_BeastGeneExtractor" of type "ThingDef" exists
    And no warnings from mod "Ancient Chinese Beast And Gene Expanded Renew (unofficial)"
    And no errors were logged
