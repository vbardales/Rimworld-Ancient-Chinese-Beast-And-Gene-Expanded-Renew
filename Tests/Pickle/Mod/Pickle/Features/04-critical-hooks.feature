@review
Feature: Ancient Chinese Beast critical 1.6 callbacks

  # M1 of Tests/Pickle/README.md's manual exceptions. The rot is a fixed exception list
  # (GameCondition_MingSheDrought.CheckPlant), not a probability, so one hour of game time is enough:
  # exactly one of the four exempt kinds and one ordinary tree, both spawned mature.
  Scenario: the drought rots plants hourly but spares its four exceptions
    Given the save "test-colony" is loaded
    And Ancient Chinese Beast: I plant "Plant_TreeOak" at x=140 z=150
    And Ancient Chinese Beast: I plant "Plant_TreeAnima" at x=142 z=150
    And Ancient Chinese Beast: I plant "Plant_MossGauranlen" at x=144 z=150
    And Ancient Chinese Beast: I plant "Plant_TreePolux" at x=146 z=150
    And Ancient Chinese Beast: I spawn the pawn "SZ_MingShe" at x=142 z=155
    Then Ancient Chinese Beast: drought is active
    When Ancient Chinese Beast: the plant at x=140 z=150 takes drought damage within 90 seconds
    Then Ancient Chinese Beast: the plant at x=142 z=150 is untouched by the drought
    And Ancient Chinese Beast: the plant at x=144 z=150 is untouched by the drought
    And Ancient Chinese Beast: the plant at x=146 z=150 is untouched by the drought
    And no errors were logged

  Scenario: a mingshe drought ends when its causer dies
    Given the save "test-colony" is loaded
    And Ancient Chinese Beast: I spawn the pawn "SZ_MingShe" at x=142 z=155
    Then Ancient Chinese Beast: drought is active
    When Ancient Chinese Beast: I kill "SZ_MingShe" at x=142 z=155
    Then Ancient Chinese Beast: drought ends within 10 seconds
    And no errors were logged

  Scenario: killing the human sexie produces its scorpion form
    Given the save "test-colony" is loaded
    And I zoom all the way in
    And I move the camera to (146, 155)
    And Ancient Chinese Beast: I spawn the pawn "SZ_SeXie" at x=146 z=155
    When Ancient Chinese Beast: I kill "SZ_SeXie" at x=146 z=155
    Then Ancient Chinese Beast: "SZ_SeXieInsect" appears at x=146 z=155 within 10 seconds
    And I take a screenshot "sexie scorpion form after human form death"
    And no errors were logged

  Scenario: the qiongqi flying strike lands at its destination
    Given the save "test-colony" is loaded
    And I zoom all the way in
    And I move the camera to (152, 155)
    And Ancient Chinese Beast: I spawn the pawn "SZ_QiongQi" at x=142 z=155
    When Ancient Chinese Beast: I launch the qiongqi at x=142 z=155 to x=152 z=155
    Then Ancient Chinese Beast: the qiongqi lands at x=152 z=155 within 10 seconds
    And I take a screenshot "qiongqi after its flying strike lands"
    And no errors were logged
