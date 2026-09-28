# M5 of Tests/Pickle/README.md's manual exceptions: a nian beast that cannot reach a colonist indoors breaks what is in
# its way (JobGiver_KillHuman_RangedAbility, FirstBlockingBuilding). A colonist is walled in by steel with one wooden
# door, and the beast stands outside; the AI plays, nothing is forced. The door, the way of least resistance, is what
# has to give. The colony's own colonists are removed first: the beast only falls
# back to an unreachable target when it can reach none (JobGiver_KillHuman.FindPawnTarget), and the first run
# (2026-09-28) had them on the map.
Feature: The nian beast breaks a door down to reach a colonist indoors

  Scenario: the nian beast attacks the enclosure of a walled-in colonist it cannot reach
    Given the save "test-colony" is loaded
    And Ancient Chinese Beast: I wall in a colonist behind a wooden door, centred at x=156 z=146
    And Ancient Chinese Beast: I remove every colonist I did not spawn
    And Ancient Chinese Beast: I spawn the pawn "SZ_YearBeast" at x=156 z=134
    Then Ancient Chinese Beast: the enclosure is breached within 40 seconds
    And no errors were logged
