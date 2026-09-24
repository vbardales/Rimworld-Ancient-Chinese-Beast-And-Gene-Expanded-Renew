@review
Feature: Ancient Chinese Beast debug actions stage their own observable state

  Scenario: schedule the nian through its actual debug action
    Given the save "test-colony" is loaded
    When Ancient Chinese Beast: I invoke debug action "ForceYearBeast"
    Then Ancient Chinese Beast: the year-beast debug flag is set
    And no errors were logged
