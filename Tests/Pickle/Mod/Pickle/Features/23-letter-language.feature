# M8 of Tests/Pickle/README.md's manual exceptions. A saved game keeps the beast it chose, letter included, in the
# language of the day it was saved. Changing the language is the game's restart and not a scenario, so this plays the
# part the mod owns: a stale saved letter is replaced by the one of the Def in the language of the run
# (Singleton.BeastFor). It runs in the English pass and again in the French pass, and no text is spelled out, so the
# same lines hold in both.
Feature: A saved beast sends its letter in the language of the run

  Scenario: the stale letter of a saved beast is replaced by the current one
    Given the save "test-colony" is loaded
    And Ancient Chinese Beast: the beast chosen in the saved game carries the letter of another language for incident "SZ_BeastApproach"
    When Ancient Chinese Beast: I execute incident "SZ_BeastApproach"
    Then Ancient Chinese Beast: the newest letter has the text and the label of the beast list of incident "SZ_BeastApproach", not the stale ones
    And no errors were logged
