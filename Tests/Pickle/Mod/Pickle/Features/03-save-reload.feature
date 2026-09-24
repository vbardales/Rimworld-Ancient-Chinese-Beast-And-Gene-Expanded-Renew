# This covers the ordinary save round-trip without relying on a private pre-existing save.
@review
Feature: Ancient Chinese Beast state survives a save and reload

  Scenario: spawned beasts remain present after a round trip
    Given the save "test-colony" is loaded
    And Ancient Chinese Beast: I spawn the pawn "SZ_MingShe" at x=143 z=155
    And Ancient Chinese Beast: I spawn the pawn "SZ_QiongQi" at x=145 z=155
    And Ancient Chinese Beast: I spawn the pawn "SZ_SeXie" at x=147 z=155
    And Ancient Chinese Beast: I spawn the pawn "SZ_YearBeast" at x=149 z=155
    When I save and reload
    Then 1 "SZ_MingShe" exist
    And 1 "SZ_QiongQi" exist
    And 1 "SZ_SeXie" exist
    And 1 "SZ_YearBeast" exist
    And the save round trips
    And no errors were logged
