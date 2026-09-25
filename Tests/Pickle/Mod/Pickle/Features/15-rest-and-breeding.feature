# The beasts rest and breed (BACKLOG.md, decided 2026-09-25). Nothing here waits for a real night or a real
# gestation: a scenario tires the pawn by setting its need, brings a mating to the game's own Mate job, and lets a
# pregnancy, an egg or a hatcher finish from just below completion, so that what is proved is the wiring (the need,
# the vanilla think tree, the sexes, the life stages, the eggs, the kinds and factions of the young) and not a timer.
# The tame beasts are the ones a colony owns; the hostile ones are checked only for the need.
Feature: The beasts rest and breed

  Scenario Outline: a tired tame beast lies down
    Given the save "test-colony" is loaded
    And Ancient Chinese Beast: I spawn the tame "<kind>" of gender male at x=146 z=155
    When Ancient Chinese Beast: the rest of pawn 1 is set to 0.05
    Then Ancient Chinese Beast: pawn 1 is asleep within 20 seconds
    And no errors were logged

    Examples:
      | kind                    |
      | SZ_YearBeast_Friendly   |
      | SZ_QiongQi_Friendly     |
      | SZ_MingShe_Friendly     |
      | SZ_SeXie_Friendly       |
      | SZ_SeXieInsect_Friendly |
      | SZ_Chicken              |

  Scenario Outline: a hostile beast has a rest need too
    Given the save "test-colony" is loaded
    When Ancient Chinese Beast: I spawn the pawn "<kind>" at x=146 z=155
    Then Ancient Chinese Beast: pawn 1 has a rest need
    And no errors were logged

    Examples:
      | kind           |
      | SZ_YearBeast   |
      | SZ_QiongQi     |
      | SZ_MingShe     |
      | SZ_SeXie       |
      | SZ_SeXieInsect |

  # A pair that gives birth: the male mates with the female through the real job, she is pregnant, and a pregnancy
  # brought to its end gives a baby of the same race, in the player's faction.
  Scenario Outline: a tame pair mates and the female gives birth
    Given the save "test-colony" is loaded
    And Ancient Chinese Beast: I spawn the tame "<kind>" of gender male at x=144 z=155
    And Ancient Chinese Beast: I spawn the tame "<kind>" of gender female at x=148 z=155
    When Ancient Chinese Beast: pawn 1 mates with pawn 2
    Then Ancient Chinese Beast: pawn 2 is pregnant within 40 seconds
    When Ancient Chinese Beast: the pregnancy of pawn 2 is due now
    Then Ancient Chinese Beast: a young "<kind>" of the player's faction is born within 20 seconds
    And no errors were logged

    Examples:
      | kind                    |
      | SZ_YearBeast_Friendly   |
      | SZ_QiongQi_Friendly     |
      | SZ_SeXie_Friendly       |
      | SZ_SeXieInsect_Friendly |

  # The two that lay eggs, the mingshe (a snake) and the Pleiades star officer (a bird): fertilised by the male, an egg
  # is laid, and an egg brought to its end hatches a baby of the same kind, in the player's faction.
  Scenario Outline: a tame pair mates and the female lays an egg that hatches
    Given the save "test-colony" is loaded
    And Ancient Chinese Beast: I spawn the tame "<kind>" of gender male at x=144 z=155
    And Ancient Chinese Beast: I spawn the tame "<kind>" of gender female at x=148 z=155
    When Ancient Chinese Beast: pawn 1 mates with pawn 2
    Then Ancient Chinese Beast: pawn 2 is fertilised within 40 seconds
    When Ancient Chinese Beast: the egg of pawn 2 is due now
    Then Ancient Chinese Beast: a thing "<egg>" exists within 60 seconds
    When Ancient Chinese Beast: every "<egg>" is due to hatch now
    Then Ancient Chinese Beast: a young "<kind>" of the player's faction is born within 20 seconds
    And no errors were logged

    Examples:
      | kind                | egg                       |
      | SZ_MingShe_Friendly | SZ_MingSheEggFertilized   |
      | SZ_Chicken          | SZ_ChickenEggFertilized   |
