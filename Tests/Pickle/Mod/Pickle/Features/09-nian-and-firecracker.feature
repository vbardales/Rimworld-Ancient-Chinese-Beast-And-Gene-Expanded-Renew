# The nian beast takes a tenth of every ordinary blow and a hundred times a firecracker's; the
# firecracker throws a chain of smaller ones and stops. Those are numbers in defs that an offline test can
# read and cannot use, so each scenario strikes a real pawn through the game's own damage path.
Feature: The nian beast and the firecracker

  # A bullet, not a cut: the first run struck with a cut and read 4.235 where a tenth of 30 is 3, because a cut spills
  # onto a second body part and the total is the sum of two injuries (2.1176 on the leg, 2.1176 on the body). The
  # bullet lands on the one part it is aimed at, so the number is the tenth itself, and the control below has one
  # injury to compare with too.
  Scenario: an ordinary blow does a tenth of its damage to the nian beast
    Given the save "test-colony" is loaded
    And Ancient Chinese Beast: I spawn the pawn "SZ_YearBeast" at x=146 z=155
    When Ancient Chinese Beast: the "SZ_YearBeast" at x=146 z=155 is struck for 30 damage of "Bullet"
    Then Ancient Chinese Beast: the last blow dealt at most 3.5 damage
    And Ancient Chinese Beast: the "SZ_YearBeast" at x=146 z=155 is alive
    And no errors were logged

  # The control that makes the number above mean something: the same blow, the same armour penetration,
  # on an animal with no factor of its own.
  Scenario: the same blow does its full damage to an ordinary animal
    Given the save "test-colony" is loaded
    And Ancient Chinese Beast: I spawn the pawn "Muffalo" at x=146 z=155
    When Ancient Chinese Beast: the "Muffalo" at x=146 z=155 is struck for 30 damage of "Bullet"
    Then Ancient Chinese Beast: the last blow dealt more than 25 damage
    And no errors were logged

  # Three points of damage, against thirty above: a firecracker's damage is multiplied a thousand times
  # and the beast's own factor takes a tenth of that back, so what lands is a hundred times the blow.
  Scenario: a firecracker's damage does a hundred times its size to the nian beast
    Given the save "test-colony" is loaded
    And Ancient Chinese Beast: I spawn the pawn "SZ_YearBeast" at x=146 z=155
    When Ancient Chinese Beast: the "SZ_YearBeast" at x=146 z=155 is struck for 3 damage of "SZ_Firecracker_Flame"
    Then Ancient Chinese Beast: the last blow dealt more than 200 damage
    And no errors were logged

  Scenario: a firecracker going off beside the nian beast wounds it
    Given the save "test-colony" is loaded
    And Ancient Chinese Beast: I spawn the pawn "SZ_YearBeast" at x=146 z=155
    When Ancient Chinese Beast: a firecracker goes off at x=146 z=154
    Then Ancient Chinese Beast: the "SZ_YearBeast" at x=146 z=155 is wounded within 10 seconds
    And no errors were logged

  @review
  Scenario: the nian beast's fire breath reaches its target
    Given the save "test-colony" is loaded
    And I zoom out
    And I move the camera to (146, 155)
    And Ancient Chinese Beast: I spawn the pawn "SZ_YearBeast" at x=140 z=155
    And Ancient Chinese Beast: I spawn the pawn "Muffalo" at x=150 z=155
    When Ancient Chinese Beast: the "SZ_YearBeast" at x=140 z=155 breathes fire at the "Muffalo" at x=150 z=155
    And I wait 30 ticks
    Then Ancient Chinese Beast: a thing "SZ_YearBeastFlame" exists within 5 seconds
    And I take a screenshot "nian beast breathing fire at a muffalo"
    And Ancient Chinese Beast: the flame target is hurt or burning within 30 seconds
    And no errors were logged

  # What a butchery yields is written into the report either way. The race description promises "nian
  # beast fangs" and no def of that name ships with the mod, so the report is where that is settled.
  Scenario: butchering a nian beast yields meat, and the report lists everything else it yields
    Given the save "test-colony" is loaded
    And Ancient Chinese Beast: I spawn the pawn "SZ_YearBeast" at x=146 z=155
    When Ancient Chinese Beast: the "SZ_YearBeast" at x=146 z=155 is killed outright
    And Ancient Chinese Beast: the corpse of a "SZ_YearBeast" at x=146 z=155 is butchered by a colonist
    Then Ancient Chinese Beast: the butchery yielded meat
    And no errors were logged

  # Three blasts and no more: the first drops pieces of the first level, whose blasts drop pieces of the
  # second, whose blasts drop nothing. The pieces last a few ticks each, so they are watched tick by
  # tick and the record is what is asserted.
  Scenario: a firecracker sets off a chain of smaller ones, and the chain stops after three blasts
    Given the save "test-colony" is loaded
    When Ancient Chinese Beast: a firecracker goes off at x=146 z=155
    And Ancient Chinese Beast: I watch the firecracker pieces for 240 ticks
    Then Ancient Chinese Beast: the watched pieces included level "SZ_Firecracker_Flame"
    And Ancient Chinese Beast: the watched pieces included level "SZ_Firecracker_FlameB"
    And Ancient Chinese Beast: the watched pieces never included level "SZ_Firecracker_FlameC"
    And Ancient Chinese Beast: no firecracker piece remains
    And no errors were logged
