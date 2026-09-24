# This covers the ordinary save round-trip without relying on a private pre-existing save.
@review
Feature: Ancient Chinese Beast state survives a save and reload

  Scenario: spawned beasts remain present after a round trip
    Given the save "test-colony" is loaded
    And I spawn a "SZ_MingShe" at (143, 155)
    And I spawn a "SZ_QiongQi" at (145, 155)
    And I spawn a "SZ_SeXie" at (147, 155)
    And I spawn a "SZ_YearBeast" at (149, 155)
    When I save and reload
    Then 1 "SZ_MingShe" exist
    And 1 "SZ_QiongQi" exist
    And 1 "SZ_SeXie" exist
    And 1 "SZ_YearBeast" exist
    And the save round trips
    And no errors were logged
