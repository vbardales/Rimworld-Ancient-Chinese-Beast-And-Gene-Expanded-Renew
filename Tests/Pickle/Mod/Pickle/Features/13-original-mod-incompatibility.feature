# A pass of its own: this file plays only when the original mod (Workshop 3292446841) is staged, with
#
#   Run-PickleWsl.ps1 -Mod AncientChineseBeastAndGeneExpandedRenew -DepMap wsl-deps.incompat-original.map `
#     -Filter '13-original-mod-incompatibility'
#
# and is skipped by requirement in every other pass, where it counts as skipped and not as passed.
#
# About.xml declares the two incompatible because they define the same defs. RimWorld does not refuse two
# mods that do: the later one's copy of a def silently replaces the earlier one's. So the symptom that is
# asserted is exactly that, and it stays green while the incompatibility is still true: both mods carry
# the beast, and the game keeps one copy. If the original stops defining it, or stops loading on 1.6, the
# scenario goes red, and that is the day the incompatibleWith line can be reconsidered.
#
# It starts from the main menu, not from a save: the conflict is settled while the defs load, and a save
# that failed to load because of it would end the scenario before it could show the symptom.
@requires:andery233xj.AncientChineseBeast
Feature: Declared incompatibility with the original Ancient Chinese Beast

  Scenario: the two mods define the same beast and the game keeps one copy of it
    Given the main menu is open
    Then mod "andery233xj.AncientChineseBeast" is loaded
    And mod "nelim.ancientchinesebeastandgeneexpandedrenew" is loaded
    And Ancient Chinese Beast: the "ThingDef" "SZ_MingShe" is defined by both mods "andery233xj.AncientChineseBeast" and "nelim.ancientchinesebeastandgeneexpandedrenew"
    And Ancient Chinese Beast: the game keeps one copy of the "ThingDef" "SZ_MingShe", from mod "andery233xj.AncientChineseBeast" or "nelim.ancientchinesebeastandgeneexpandedrenew"
    And Ancient Chinese Beast: I attach the logged errors to the report
