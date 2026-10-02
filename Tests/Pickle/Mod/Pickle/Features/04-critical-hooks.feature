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

  # M4 of Tests/Pickle/README.md's manual exceptions: the scorpion sexie's aura (CompSeXieExpansion.BerserkRing)
  # sends humanlikes within 10.9 tiles berserk. Two colonists stand close, one far: who is berserk is what a
  # person would watch, and what is asserted. The colonists come first and the beast last: the ring looks at who
  # is on the map when it first ticks and again every 1800 ticks, and the first run (2026-09-28) spawned the beast
  # first, so the second colonist was not in the ring's list yet and the wait ended at 90 real seconds.
  Scenario: the scorpion sexie's aura sends colonists within its ring berserk and spares the far one
    Given the save "test-colony" is loaded
    And Ancient Chinese Beast: I spawn a colonist near x=146 z=150
    And Ancient Chinese Beast: I spawn a colonist near x=150 z=152
    And Ancient Chinese Beast: I spawn a colonist near x=118 z=155
    And Ancient Chinese Beast: I spawn the pawn "SZ_SeXieInsect" at x=146 z=155 with its aura clock at zero
    Then Ancient Chinese Beast: pawn 3 is more than 12 tiles from pawn 4
    And Ancient Chinese Beast: pawn 1 goes berserk within 30 seconds
    And Ancient Chinese Beast: pawn 2 goes berserk within 30 seconds
    And Ancient Chinese Beast: pawn 3 is not berserk
    And no errors were logged

  # The same comp also sends the most psychically sensitive colonist of the whole map berserk every 3600 ticks, wherever
  # they stand (CompSeXieExpansion.BerserkPerMintutes): the first run of the ring scenario found its far colonist berserk
  # for exactly that reason. With one colonist on the map, far from the beast, it is the only one that pick can name.
  Scenario: the scorpion sexie also sends the most psychically sensitive colonist berserk from anywhere
    Given the save "test-colony" is loaded
    And Ancient Chinese Beast: I spawn a colonist near x=118 z=155
    And Ancient Chinese Beast: I remove every colonist I did not spawn
    And Ancient Chinese Beast: I spawn the pawn "SZ_SeXieInsect" at x=146 z=155
    Then Ancient Chinese Beast: pawn 1 is more than 12 tiles from pawn 2
    And Ancient Chinese Beast: pawn 1 goes berserk within 30 seconds
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
