# A pass of its own: this file plays only when [XND] Nocturnal Animals (Continued) (Mlie, Workshop 2269731409) is
# staged, with
#
#   Run-PickleWsl.ps1 -Mod AncientChineseBeastAndGeneExpandedRenew -DepMap wsl-deps.nocturnal.map `
#     -Filter '16-nocturnal-animals'
#
# and is skipped by requirement in every other pass, where it counts as skipped and not as passed.
#
# Patches/NocturnalAnimals.xml gives each beast a body clock through that mod's extension, behind a guard on the
# mod's display name. What settles that it worked is the extension the game holds on the race, read by reflection
# because its class lives in the other mod; the clock itself (which hours a pawn sleeps) is that mod's own logic.
@requires:Mlie.XNDNocturnalAnimals
Feature: Nocturnal Animals body clocks

  Scenario Outline: each beast has the body clock the patch gives it
    Given the main menu is open
    Then mod "Mlie.XNDNocturnalAnimals" is loaded
    And Ancient Chinese Beast: the body clock of "<race>" is <clock>

    Examples:
      | race                    | clock       |
      | SZ_QiongQi              | Nocturnal   |
      | SZ_QiongQi_Friendly     | Nocturnal   |
      | SZ_SeXie                | Nocturnal   |
      | SZ_SeXie_Friendly       | Nocturnal   |
      | SZ_SeXieInsect          | Nocturnal   |
      | SZ_SeXieInsect_Friendly | Nocturnal   |
      | SZ_MingShe              | Crepuscular |
      | SZ_MingShe_Friendly     | Crepuscular |
      | SZ_YearBeast            | Crepuscular |
      | SZ_YearBeast_Friendly   | Crepuscular |
      | SZ_Chicken              | Crepuscular |
