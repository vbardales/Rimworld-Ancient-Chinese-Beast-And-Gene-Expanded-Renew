# The drought scenario of 04-critical-hooks, with the Pickle Tools tick-batch step: on the 1.7 lane (software rendering,
# about 1 frame per second) 3600 real ticks run in about 2 minutes, where waiting for them takes over 400 seconds and times out
# (tickets 7c28 and 585f, 2026-11-17). Needs Colonist Race, so it skips itself in a pass that does not stage it (wsl-deps.v17.map does).
@requires:nelim.pickletools.colonistrace
Feature: Ancient Chinese Beast drought after a tick batch

  Scenario: the drought rots plants hourly but spares its four exceptions after a tick batch
    Given the save "test-colony" is loaded
    And Ancient Chinese Beast: I plant "Plant_TreeOak" at x=140 z=150
    And Ancient Chinese Beast: I plant "Plant_TreeAnima" at x=142 z=150
    And Ancient Chinese Beast: I plant "Plant_MossGauranlen" at x=144 z=150
    And Ancient Chinese Beast: I plant "Plant_TreePolux" at x=146 z=150
    And Ancient Chinese Beast: I spawn the pawn "SZ_MingShe" at x=142 z=155
    Then Ancient Chinese Beast: drought is active
    When Nelim's Pickle Tools: the game is advanced by 3600 ticks
    And Ancient Chinese Beast: the plant at x=140 z=150 takes drought damage within 60 seconds
    Then Ancient Chinese Beast: the plant at x=142 z=150 is untouched by the drought
    And Ancient Chinese Beast: the plant at x=144 z=150 is untouched by the drought
    And Ancient Chinese Beast: the plant at x=146 z=150 is untouched by the drought
    And no errors were logged
