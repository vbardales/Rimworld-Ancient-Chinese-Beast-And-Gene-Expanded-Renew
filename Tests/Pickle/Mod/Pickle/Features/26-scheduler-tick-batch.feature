# The four "nothing arrives" scheduler scenarios of 10-scheduler, with the Pickle Tools tick-batch step. On the 1.7 lane (software
# rendering, about 1 frame per second) the original steps wait 40 and 70 real ticks and hit their 30 second timeout (ticket 64b0,
# 2026-11-17). Here the ticks are run at once, then the check reads the map after one more tick. Needs Colonist Race: it skips itself
# in a pass that does not stage it (wsl-deps.v17.map does).
@requires:nelim.pickletools.colonistrace
Feature: The beast schedule after a tick batch

  Scenario: a later hour of the first day does not bring the nian beast, after a tick batch
    Given the save "test-colony" is loaded
    When Ancient Chinese Beast: the clock is moved to 3 ticks before local hour 5 of day 0 of a new year
    And Ancient Chinese Beast: the sixty-day gate is forced closed
    And Nelim's Pickle Tools: the game is advanced by 40 ticks
    Then Ancient Chinese Beast: no nian beast is present after 1 ticks

  Scenario: the first hour of another day does not bring it either, after a tick batch
    Given the save "test-colony" is loaded
    When Ancient Chinese Beast: the clock is moved to 3 ticks before local hour 0 of day 10 of a new year
    And Ancient Chinese Beast: the sixty-day gate is forced closed
    And Nelim's Pickle Tools: the game is advanced by 40 ticks
    Then Ancient Chinese Beast: no nian beast is present after 1 ticks

  Scenario: under an ordinary storyteller the same tick brings nothing while the gate is closed, after a tick batch
    Given the save "test-colony" is loaded
    When Ancient Chinese Beast: the clock is moved to 3 ticks before the next multiple of 900000
    And Ancient Chinese Beast: the sixty-day gate is forced closed
    And Nelim's Pickle Tools: the game is advanced by 70 ticks
    Then Ancient Chinese Beast: no ordinary beast is present after 1 ticks

  Scenario: a winning roll is refused while the sixty-day gate is closed, after a tick batch
    Given the save "test-colony" is loaded
    When Ancient Chinese Beast: the ordinary hour tick runs at a day boundary with a winning roll and the gate closed
    And Nelim's Pickle Tools: the game is advanced by 60 ticks
    Then Ancient Chinese Beast: no ordinary beast is present after 1 ticks
