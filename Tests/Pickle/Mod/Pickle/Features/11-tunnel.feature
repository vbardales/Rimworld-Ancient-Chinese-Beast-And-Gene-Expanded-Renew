# The sexie does not walk in: its incident opens a tunnel in the richest room of the colony. Which room is
# the question a person cannot settle by looking, so the scenario asks the game for every room's wealth.
Feature: The sexie's tunnel

  @review
  Scenario: the tunnel opens in the richest room and the sexie comes out of it
    Given the save "test-colony" is loaded
    When Ancient Chinese Beast: I execute incident "SZ_BeastApproachTunnel"
    Then Ancient Chinese Beast: a thing "SZ_SeXieTunnelSpawner" exists within 10 seconds
    And Ancient Chinese Beast: the tunnel spawner stands in the richest room
    When Ancient Chinese Beast: I look at the first "SZ_SeXieTunnelSpawner"
    And I zoom in
    Then I take a screenshot "the tunnel opening in the richest room"
    And Ancient Chinese Beast: a "SZ_SeXie" pawn exists within 90 seconds
    And no errors were logged
