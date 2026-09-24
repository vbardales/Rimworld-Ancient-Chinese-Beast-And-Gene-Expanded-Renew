# The mod's scheduler is Singleton.HourTick, run by a patch on the game's tick loop once every 2500
# ticks. Nothing here waits for a real day: each scenario moves the game clock to just before the tick
# it means to test and lets the real loop cross it, or calls the hour tick directly under a random seed
# chosen to win a 1% roll, so a scenario that says "no beast" is refused by the gate and not by luck.
Feature: The beast schedule

  Scenario: the nian debug action makes the nian beast arrive at the next hour tick
    Given the save "test-colony" is loaded
    When Ancient Chinese Beast: I invoke debug action "ForceYearBeast"
    Then Ancient Chinese Beast: the year-beast debug flag is set
    When Ancient Chinese Beast: the clock is moved to 3 ticks before the next multiple of 2500
    And I wait 10 ticks
    Then Ancient Chinese Beast: a "SZ_YearBeast" pawn exists within 15 seconds
    And Ancient Chinese Beast: the year-beast debug flag is clear
    And no errors were logged

  Scenario: the nian beast arrives on the first hour of the first day of the year, with no flag and no roll
    Given the save "test-colony" is loaded
    When Ancient Chinese Beast: the clock is moved to 3 ticks before local hour 0 of day 0 of a new year
    And Ancient Chinese Beast: the sixty-day gate is forced closed
    And I wait 10 ticks
    Then Ancient Chinese Beast: a "SZ_YearBeast" pawn exists within 15 seconds
    And no errors were logged

  Scenario: a later hour of the first day does not bring the nian beast
    Given the save "test-colony" is loaded
    When Ancient Chinese Beast: the clock is moved to 3 ticks before local hour 5 of day 0 of a new year
    And Ancient Chinese Beast: the sixty-day gate is forced closed
    And I wait 10 ticks
    Then Ancient Chinese Beast: no nian beast is present after 30 ticks

  Scenario: the first hour of another day does not bring it either
    Given the save "test-colony" is loaded
    When Ancient Chinese Beast: the clock is moved to 3 ticks before local hour 0 of day 10 of a new year
    And Ancient Chinese Beast: the sixty-day gate is forced closed
    And I wait 10 ticks
    Then Ancient Chinese Beast: no nian beast is present after 30 ticks

  Scenario: under Sexie a beast arrives at every 900000 ticks, whatever the gate says
    Given the save "test-colony" is loaded
    And Ancient Chinese Beast: the storyteller is switched to "SZ_Storyteller_Sexie"
    When Ancient Chinese Beast: the clock is moved to 3 ticks before the next multiple of 900000
    And Ancient Chinese Beast: the sixty-day gate is forced closed
    And I wait 10 ticks
    Then Ancient Chinese Beast: an ordinary beast arrives within 30 seconds
    And no errors were logged

  Scenario: under an ordinary storyteller the same tick brings nothing while the gate is closed
    Given the save "test-colony" is loaded
    When Ancient Chinese Beast: the clock is moved to 3 ticks before the next multiple of 900000
    And Ancient Chinese Beast: the sixty-day gate is forced closed
    And I wait 10 ticks
    Then Ancient Chinese Beast: no ordinary beast is present after 60 ticks

  Scenario: under an ordinary storyteller a beast can arrive at the daily roll once the gate is open
    Given the save "test-colony" is loaded
    When Ancient Chinese Beast: the ordinary hour tick runs at a day boundary with a winning roll and the gate open
    Then Ancient Chinese Beast: an ordinary beast arrives within 30 seconds
    And no errors were logged

  Scenario: a winning roll is refused while the sixty-day gate is closed
    Given the save "test-colony" is loaded
    When Ancient Chinese Beast: the ordinary hour tick runs at a day boundary with a winning roll and the gate closed
    Then Ancient Chinese Beast: no ordinary beast is present after 60 ticks

  # The development menu is built from a DebugActionYielder so that labels can be translated. The
  # scenario names each entry by its Keyed key, so the same lines serve the English pass and the French
  # one: a key that is not translated in the language of the run fails the step that reads it.
  Scenario: every development action is labelled in the language of the run and does what it says
    Given the save "test-colony" is loaded
    Then the debug actions menu builds
    When Ancient Chinese Beast: I trigger the localized debug action "SZ_DebugNianNextHour"
    Then Ancient Chinese Beast: the year-beast debug flag is set
    When Ancient Chinese Beast: I trigger the localized debug action "SZ_DebugClearCooldown"
    Then Ancient Chinese Beast: the sixty-day gate is open
    When Ancient Chinese Beast: I trigger the localized debug action "SZ_DebugReportClock"
    And Ancient Chinese Beast: I trigger the localized debug action "SZ_DebugBeastNow"
    Then Ancient Chinese Beast: an ordinary beast arrives within 30 seconds
    And no errors were logged
