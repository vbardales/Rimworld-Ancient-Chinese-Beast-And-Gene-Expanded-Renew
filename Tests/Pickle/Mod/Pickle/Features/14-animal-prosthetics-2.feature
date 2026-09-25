# A pass of its own: this file plays only when A Dog Said... Animal Prosthetics 2 (Workshop 3238353862) is
# staged, with
#
#   Run-PickleWsl.ps1 -Mod AncientChineseBeastAndGeneExpandedRenew -DepMap wsl-deps.ads2.map `
#     -Filter '14-animal-prosthetics-2'
#
# and is skipped by requirement in every other pass, where it counts as skipped and not as passed.
#
# That mod files each animal in one of three cumulative categories (its ADS_Cat1, ADS_Cat2 and ADS_Cat3 lists)
# and copies the lists onto its surgery recipes once, when its own patch runs. This mod adds its races to the
# lists and loads before it (Patches/ADogSaidAnimalProsthetics2.xml, loadBefore in About.xml). What settles
# whether that worked is the recipe list the game holds on each race, so that is what is asserted:
# a tame clone is a category 3 animal (every kind of prosthesis), the chicken a category 2 one (no bionics),
# and a hostile beast none at all. The recipe names are the concrete recipes of that mod's 1.6 folder.
#
# The pass map puts this mod before the other one on purpose (see wsl-deps.ads2.map): the staging does not
# sort by loadBefore. The last scenario asserts that order, so a map that loses it fails there and not
# obscurely in the recipe lists.
#
# Names are short on purpose: a screenshot's file name is built from the feature and scenario names, and the
# launcher's copy of a report failed on a path over 260 characters in the first run.
#
# It needs no save: the recipe lists are settled while the defs load, by patches.
@requires:SamBucher.ADogSaidAnimalProsthetics2
Feature: A Dog Said 2 prosthetics

  Scenario Outline: a tame clone is a category 3 animal
    Given the main menu is open
    Then Ancient Chinese Beast: the race "<race>" offers the recipes "InstallWoodenPawAnimal", "InstallSimpleProstheticLegAnimal" and "InstallBionicLegAnimal"
    And no errors were logged

    Examples:
      | race                    |
      | SZ_YearBeast_Friendly   |
      | SZ_QiongQi_Friendly     |
      | SZ_MingShe_Friendly     |
      | SZ_SeXie_Friendly       |
      | SZ_SeXieInsect_Friendly |

  Scenario: the chicken is a category 2 animal, like a duck
    Given the main menu is open
    Then Ancient Chinese Beast: the race "SZ_Chicken" offers the recipes "InstallPegLegAnimal" and "InstallSimpleProstheticLegAnimal"
    And Ancient Chinese Beast: the race "SZ_Chicken" does not offer the recipe "InstallBionicLegAnimal"
    And no errors were logged

  Scenario Outline: a hostile beast is in no category
    Given the main menu is open
    Then Ancient Chinese Beast: the race "<race>" does not offer the recipe "InstallPegLegAnimal"
    And Ancient Chinese Beast: the race "<race>" does not offer the recipe "InstallBionicLegAnimal"

    Examples:
      | race         |
      | SZ_YearBeast |
      | SZ_QiongQi   |
      | SZ_MingShe   |
      | SZ_SeXie     |

  Scenario: this mod loads before the other one
    Given the main menu is open
    Then mod "SamBucher.ADogSaidAnimalProsthetics2" is loaded
    And Ancient Chinese Beast: the mod "nelim.ancientchinesebeastandgeneexpandedrenew" loads before "SamBucher.ADogSaidAnimalProsthetics2"
