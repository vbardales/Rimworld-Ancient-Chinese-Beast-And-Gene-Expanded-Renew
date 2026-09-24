# A reviewer judges only the rendered creatures. The scenario creates the same clean comparison
# every time; it does not ask a person to prepare a colony or use developer tools.
@review
Feature: Ancient Chinese Beast creatures on a clean map

  Background:
    Given the save "test-colony" is loaded
    And I zoom all the way in
    And I move the camera to (146, 155)

  Scenario: the four hostile beasts and the Pleiades star officer render together
    When Ancient Chinese Beast: I spawn the pawn "SZ_MingShe" at x=142 z=153
    And Ancient Chinese Beast: I spawn the pawn "SZ_QiongQi" at x=144 z=153
    And Ancient Chinese Beast: I spawn the pawn "SZ_SeXie" at x=146 z=153
    And Ancient Chinese Beast: I spawn the pawn "SZ_YearBeast" at x=148 z=153
    And Ancient Chinese Beast: I spawn the pawn "SZ_Chicken" at x=150 z=153
    And I wait 30 ticks
    Then I take a screenshot "four beasts and the Pleiades star officer"
    And no errors were logged
