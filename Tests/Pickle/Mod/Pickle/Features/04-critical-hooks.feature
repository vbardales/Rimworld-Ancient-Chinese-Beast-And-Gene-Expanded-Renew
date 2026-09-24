@review
Feature: Ancient Chinese Beast critical 1.6 callbacks

  Scenario: a mingshe drought ends when its causer dies
    Given the save "test-colony" is loaded
    And I spawn a "SZ_MingShe" at (142, 155)
    Then Ancient Chinese Beast: drought is active
    When Ancient Chinese Beast: I kill "SZ_MingShe" at x=142 z=155
    Then Ancient Chinese Beast: drought ends within 10 seconds
    And no errors were logged

  Scenario: killing the human sexie produces its scorpion form
    Given the save "test-colony" is loaded
    And I zoom all the way in
    And I move the camera to (146, 155)
    And I spawn a "SZ_SeXie" at (146, 155)
    When Ancient Chinese Beast: I kill "SZ_SeXie" at x=146 z=155
    Then Ancient Chinese Beast: "SZ_SeXieInsect" appears at x=146 z=155 within 10 seconds
    And I take a screenshot "sexie scorpion form after human form death"
    And no errors were logged

  Scenario: the qiongqi flying strike lands at its destination
    Given the save "test-colony" is loaded
    And I zoom all the way in
    And I move the camera to (152, 155)
    And I spawn a "SZ_QiongQi" at (142, 155)
    When Ancient Chinese Beast: I launch the qiongqi at x=142 z=155 to x=152 z=155
    Then Ancient Chinese Beast: the qiongqi lands at x=152 z=155 within 10 seconds
    And I take a screenshot "qiongqi after its flying strike lands"
    And no errors were logged
