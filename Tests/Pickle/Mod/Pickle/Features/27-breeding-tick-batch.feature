# The live-birth scenario of 15-rest-and-breeding, with the Pickle Tools tick-batch step. On the 1.7 lane (software rendering,
# about 1 frame per second) the original reached 186 to 192 ticks in 300 real seconds, too few for a mating to end (ticket b127,
# 2026-11-17). Here the mating and the birth each get a batch of ticks, then the checks read the result. Needs Colonist Race: it
# skips itself in a pass that does not stage it (wsl-deps.v17.map does).
@requires:nelim.pickletools.colonistrace
Feature: Beast breeding after a tick batch

  Scenario Outline: a tame pair mates and the female gives birth, after a tick batch
    Given the save "test-colony" is loaded
    And Ancient Chinese Beast: I spawn the tame "<kind>" of gender male at x=144 z=155
    And Ancient Chinese Beast: I spawn the tame "<kind>" of gender female at x=148 z=155
    When Ancient Chinese Beast: pawn 1 mates with pawn 2
    And Nelim's Pickle Tools: the game is advanced by 1500 ticks
    Then Ancient Chinese Beast: pawn 2 is pregnant within 60 seconds
    When Ancient Chinese Beast: the pregnancy of pawn 2 is due now
    And Nelim's Pickle Tools: the game is advanced by 300 ticks
    Then Ancient Chinese Beast: a young "<kind>" of the player's faction is born within 20 seconds
    And no errors were logged

    Examples:
      | kind                    |
      | SZ_YearBeast_Friendly   |
      | SZ_QiongQi_Friendly     |
      | SZ_SeXie_Friendly       |
      | SZ_SeXieInsect_Friendly |
