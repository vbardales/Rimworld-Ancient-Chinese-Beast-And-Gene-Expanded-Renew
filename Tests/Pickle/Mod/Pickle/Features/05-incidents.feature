@review
Feature: Ancient Chinese Beast incidents enter the running map

  Scenario: the ordinary beast incident produces one of its walking beasts
    Given the save "test-colony" is loaded
    When Ancient Chinese Beast: I execute incident "SZ_BeastApproach"
    Then Ancient Chinese Beast: a "SZ_MingShe" or "SZ_QiongQi" pawn exists within 10 seconds
    And no errors were logged

  Scenario: the Pleiades star officer incident enters the map
    Given the save "test-colony" is loaded
    And I zoom all the way in
    When Ancient Chinese Beast: I execute incident "SZ_ChickenPasses"
    Then Ancient Chinese Beast: a "SZ_Chicken" pawn exists within 10 seconds
    And I take a screenshot "Pleiades star officer after its incident"
    And no errors were logged
