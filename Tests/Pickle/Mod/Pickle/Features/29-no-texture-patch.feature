# A pass of its own: this file plays only when the Workshop patch "Remove Ancient Chinese Beast Gene textures"
# (XXK.AncientChineseBeastNoTexture, Workshop 3293695725) is staged after this mod, with Resolve This Instead beside
# them, with
#
#   Submit-PickleRun.ps1 -Mod AncientChineseBeastAndGeneExpandedRenew -DepMap wsl-deps.notexture.map `
#     -Filter '29-no-texture-patch' -Language English
#
# and is skipped by requirement in every other pass. The patch (Patches/Patch.xml) holds four PatchOperationRemove
# (success Always) on /Defs/GeneDef[defName="..."]/renderNodeProperties for four genes this mod also defines. Its
# About.xml has no dependency and no guard, so it should apply to this mod when it loads after it. This pass settles
# that, and that nothing logs a warning or an error with the patch and Resolve This Instead staged.
# The two "has no value" steps are new (PiT, 2026-11-22), compiled and not played when this file was written.
@requires:XXK.AncientChineseBeastNoTexture
@requires:nelim.pickletools.deffields
Feature: The no-texture patch of the original applies to this mod's genes

  Scenario: the three mods load, the patch after this mod
    Given Ancient Chinese Beast: the main menu is open within 120 seconds
    Then mod "XXK.AncientChineseBeastNoTexture" is loaded
    And mod "nelim.resolvethisinstead" is loaded
    And mod "nelim.ancientchinesebeastandgeneexpanded" is loaded
    And mod "XXK.AncientChineseBeastNoTexture" loads after "nelim.ancientchinesebeastandgeneexpanded"
    And no warnings from mod "Ancient Chinese Beast And Gene Expanded Renew (unofficial)"
    And no errors were logged

  Scenario: the four genes lose their render nodes, their abilities stay
    Given Ancient Chinese Beast: the main menu is open within 120 seconds
    Then Nelim's Pickle Tools: the def "SZGene_MingShe_WindWing" of type "GeneDef" has no value in the field "renderNodeProperties"
    And Nelim's Pickle Tools: the def "SZGene_QiongQi_FlyingStrike" of type "GeneDef" has no value in the field "renderNodeProperties"
    And Nelim's Pickle Tools: the def "SZGene_SeXie_Shoot" of type "GeneDef" has no value in the field "renderNodeProperties"
    And Nelim's Pickle Tools: the def "SZGene_YearBeast_Horn" of type "GeneDef" has no value in the field "renderNodeProperties"
    And def "SZGene_SeXie_Shoot" of type "GeneDef" exists
    And Nelim's Pickle Tools: the def "SZGene_SeXie_Shoot" of type "GeneDef" has a value in the field "abilities"
    And no errors were logged
