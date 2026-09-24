@review
Feature: Ancient Chinese Beast recipes use the real Harmony recipe product hook

  Scenario: extracting a nian gene produces the configured genepack
    Given the save "test-colony" is loaded
    And I zoom all the way in
    And I move the camera to (146, 155)
    When Ancient Chinese Beast: I make recipe "SZ_ExtractGene_YearA"
    Then Ancient Chinese Beast: the recipe output is a genepack containing "SZGene_YearBeast_Flamethrower"
    When Ancient Chinese Beast: I display the recipe output at x=146 z=155
    Then I take a screenshot "nian fire-breath genepack produced by the real recipe hook"
    And no errors were logged

  Scenario: cloning a mingshe produces the configured friendly beast
    Given the save "test-colony" is loaded
    And I zoom all the way in
    And I move the camera to (146, 155)
    When Ancient Chinese Beast: I make recipe "SZ_Clone_MingShe"
    Then Ancient Chinese Beast: the recipe output is a player "SZ_MingShe_Friendly" pawn
    When Ancient Chinese Beast: I display the recipe output at x=146 z=155
    Then I take a screenshot "friendly mingshe produced by the real clone recipe hook"
    And no errors were logged
