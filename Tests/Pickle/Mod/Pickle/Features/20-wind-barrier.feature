# M2 of Tests/Pickle/README.md's manual exceptions: the mingshe's wind barrier (Ability_WindBarrier). Raised, it cuts
# everything within its radius every half second (a hostile mingshe cuts anything, so a steel wall stands for "what stands
# inside"; steel itself has no hit points) and throws back a shot fired from outside it (the projectile is destroyed and a copy
# launched by the mingshe goes back). The barrier is raised the way the ability's own Apply raises it (ticksTime = 900).
Feature: The mingshe's wind barrier

  Scenario: the barrier cuts what stands inside and spares what stands outside
    Given the save "test-colony" is loaded
    And Ancient Chinese Beast: I spawn the pawn "SZ_MingShe" at x=146 z=155
    And Ancient Chinese Beast: I set up "Wall" near x=146 z=149
    And Ancient Chinese Beast: I set up "Wall" near x=146 z=125
    Then Ancient Chinese Beast: thing 2 is more than 12 tiles from pawn 1
    When Ancient Chinese Beast: the wind barrier of pawn 1 is raised
    Then Ancient Chinese Beast: thing 1 is cut within 20 seconds
    And Ancient Chinese Beast: thing 2 is intact
    And no errors were logged

  Scenario: the barrier throws back a shot fired from outside it
    Given the save "test-colony" is loaded
    And Ancient Chinese Beast: I spawn the pawn "SZ_MingShe" at x=146 z=155
    And Ancient Chinese Beast: I stand a rifle-bearing colonist near x=146 z=133
    Then Ancient Chinese Beast: pawn 2 is more than 11 tiles from pawn 1
    When Ancient Chinese Beast: the wind barrier of pawn 1 is raised
    And Ancient Chinese Beast: pawn 2 shoots at pawn 1
    Then Ancient Chinese Beast: a projectile launched by pawn 1 is in flight within 10 seconds
    And no errors were logged
