# The firecracker chain scenario of 09-nian-and-firecracker, with the Pickle Tools batched watch step. On the 1.7 lane (software
# rendering, about 1 frame per second) the original, which waits tick by tick, timed out at 90 s. Here the ticks run in a batch and
# every piece is listed after each tick, with the value of its damageDef field. Needs Colonist Race: it skips itself in a pass that
# does not stage it (wsl-deps.v17.map does).
@requires:nelim.pickletools.colonistrace
Feature: The firecracker chain after a tick batch

  Scenario: a firecracker sets off a chain of smaller ones, and the chain stops after three blasts, after a tick batch
    Given the save "test-colony" is loaded
    When Ancient Chinese Beast: a firecracker goes off at x=146 z=155
    And Nelim's Pickle Tools: the game is advanced by 240 ticks watching the field "damageDef" of the things of def "SZ_Firecracker_Explosion"
    Then Nelim's Pickle Tools: the watched things of def "SZ_Firecracker_Explosion" showed the value "SZ_Firecracker_Flame"
    And Nelim's Pickle Tools: the watched things of def "SZ_Firecracker_Explosion" showed the value "SZ_Firecracker_FlameB"
    And Nelim's Pickle Tools: the watched things of def "SZ_Firecracker_Explosion" never showed the value "SZ_Firecracker_FlameC"
    And Ancient Chinese Beast: no firecracker piece remains
    And no errors were logged
