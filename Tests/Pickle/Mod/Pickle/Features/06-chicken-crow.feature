@review
Feature: The Pleiades star officer crow affects the nearest scorpion beast

  Scenario: crow kills a staged human sexie through the real ability effect
    Given the save "test-colony" is loaded
    And I zoom all the way in
    And I move the camera to (146, 155)
    And Ancient Chinese Beast: I spawn the pawn "SZ_Chicken" at x=144 z=155
    And Ancient Chinese Beast: I spawn the pawn "SZ_SeXie" at x=148 z=155
    When Ancient Chinese Beast: the chicken at x=144 z=155 crows
    Then Ancient Chinese Beast: no living "SZ_SeXie" pawn exists within 10 seconds
    And I take a screenshot "Pleiades star officer crow after its real ability effect"
    And no errors were logged

  Scenario: the crow lifts a colonist's mood by twenty
    Given the save "test-colony" is loaded
    And a colonist "Ada" exists
    And Ancient Chinese Beast: I spawn the pawn "SZ_Chicken" at x=144 z=155
    When Ancient Chinese Beast: the chicken at x=144 z=155 crows
    Then "Ada" has thought "SZ_ChickenCrow"
    And "Ada" thought "SZ_ChickenCrow" mood offset is 20
    And no errors were logged

  # Two sexies on the map, one crow: the crow's own list holds both and it kills only the last of it.
  Scenario: the crow kills exactly one of two sexies
    Given the save "test-colony" is loaded
    And Ancient Chinese Beast: I spawn the pawn "SZ_Chicken" at x=144 z=155
    And Ancient Chinese Beast: I spawn the pawn "SZ_SeXie" at x=148 z=155
    And Ancient Chinese Beast: I spawn the pawn "SZ_SeXie" at x=150 z=155
    When Ancient Chinese Beast: the chicken at x=144 z=155 crows
    Then Ancient Chinese Beast: exactly 1 living "SZ_SeXie" pawns exist within 10 seconds
    And no errors were logged

  # The bird's own AI crows once its clock reads four; the clock is put just before four and the game's
  # tick loop does the rest, so the scenario waits for the trigger and not for a whole night.
  Scenario: the bird crows on its own at four in the morning
    Given the save "test-colony" is loaded
    And a colonist "Ada" exists
    And Ancient Chinese Beast: I spawn the pawn "SZ_Chicken" at x=144 z=155
    When Ancient Chinese Beast: the clock is moved to 3 ticks before local hour 4 of day 0 of a new year
    And I wait 10 ticks
    Then "Ada" has thought "SZ_ChickenCrow"
    And no errors were logged
