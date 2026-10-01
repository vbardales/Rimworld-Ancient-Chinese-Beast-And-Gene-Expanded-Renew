# The sexie does not walk in: its incident opens a tunnel in the richest room of the colony. Which room is
# the question a person cannot settle by looking, so the scenario asks the game for every room's wealth.
Feature: The sexie's tunnel

  @review
  Scenario: the tunnel opens in the richest room and the sexie comes out of it
    Given the save "test-colony" is loaded
    When Ancient Chinese Beast: I execute incident "SZ_BeastApproachTunnel"
    Then Ancient Chinese Beast: a thing "SZ_SeXieTunnelSpawner" exists within 10 seconds
    And Ancient Chinese Beast: the tunnel spawner stands in the richest room
    When Ancient Chinese Beast: the game runs at normal speed
    And Ancient Chinese Beast: the tunnel is due to open now
    Then Ancient Chinese Beast: a "SZ_SeXie" pawn exists within 20 seconds
    # the spawner draws nothing a person can see before it opens (the first capture showed only the floor), so the picture is taken of the sexie coming out
    When Ancient Chinese Beast: I look at the first "SZ_SeXie"
    And I zoom all the way in
    Then I take a screenshot "the sexie coming out of its tunnel in the richest room"
    And no errors were logged
