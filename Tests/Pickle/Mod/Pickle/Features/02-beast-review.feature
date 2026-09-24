# A reviewer judges only the rendered creatures. The scenario creates the same clean comparison
# every time; it does not ask a person to prepare a colony or use developer tools.
@review
Feature: Ancient Chinese Beast creatures on a clean map

  Background:
    Given the save "test-colony" is loaded
    And I zoom all the way in
    And I move the camera to (146, 155)

  Scenario: the four hostile beasts and the Pleiades star officer render together
    When I spawn a "SZ_MingShe" at (142, 153)
    And I spawn a "SZ_QiongQi" at (144, 153)
    And I spawn a "SZ_SeXie" at (146, 153)
    And I spawn a "SZ_YearBeast" at (148, 153)
    And I spawn a "SZ_Chicken" at (150, 153)
    And I wait 30 ticks
    Then I take a screenshot "four beasts and the Pleiades star officer"
    And no errors were logged
