# M3 of Tests/Pickle/README.md's manual exceptions, and the qiongqi eye's dodge left over from M7: a probability, a
# choice of target and a distribution of blows, played as samples big enough that a fair coin cannot fail the
# bounds. A colonist with no eye gene dodges nothing, which is what tells the dodge is the qiongqi's and not the game's.
Feature: The qiongqi's dodge, flying strike and blows

  Scenario: a hostile qiongqi dodges about half of the shots
    Given the save "test-colony" is loaded
    And Ancient Chinese Beast: I spawn the pawn "SZ_QiongQi" at x=146 z=155
    Then Ancient Chinese Beast: pawn 1 dodges between 0.40 and 0.60 of 400 shots
    And no errors were logged

  Scenario: a colonist without the eye gene dodges nothing
    Given the save "test-colony" is loaded
    And Ancient Chinese Beast: I spawn a colonist at x=146 z=152
    Then Ancient Chinese Beast: pawn 1 dodges between 0.00 and 0.00 of 100 shots
    And no errors were logged

  Scenario: the qiongqi eye gene gives a colonist the same dodge
    Given the save "test-colony" is loaded
    And Ancient Chinese Beast: I spawn a colonist at x=146 z=152
    When Ancient Chinese Beast: pawn 1 receives the gene "SZGene_QiongQi_Eyes"
    Then Ancient Chinese Beast: pawn 1 dodges between 0.40 and 0.60 of 400 shots
    And no errors were logged

  Scenario: the qiongqi's blows land on the head far more often than a vanilla blow does
    Given the save "test-colony" is loaded
    And Ancient Chinese Beast: I spawn the pawn "SZ_QiongQi" at x=146 z=155
    Then Ancient Chinese Beast: pawn 1 lands at least 0.35 of 120 blows on the head of fresh colonists
    And no errors were logged

  Scenario: the qiongqi's flying strike goes to the farthest colonist it can hit
    Given the save "test-colony" is loaded
    And Ancient Chinese Beast: I spawn the pawn "SZ_QiongQi" on open ground
    And Ancient Chinese Beast: I spawn a colonist 6 tiles north of pawn 1
    And Ancient Chinese Beast: I spawn a colonist 18 tiles north of pawn 1
    Then Ancient Chinese Beast: pawn 3 is more than 12 tiles from pawn 1
    And Ancient Chinese Beast: the qiongqi pawn 1 sets its flying strike on pawn 3 within 40 seconds
    And no errors were logged
