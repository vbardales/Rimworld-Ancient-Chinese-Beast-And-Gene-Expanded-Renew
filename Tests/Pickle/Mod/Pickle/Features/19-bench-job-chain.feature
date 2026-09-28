# M6 of Tests/Pickle/README.md's manual exceptions: 08 and 12 make the recipes' products directly; here a colonist
# does the job chain the way a colony would (find the bill, haul the corpse to the bench, work it to the end).
# Only the pieces are placed: the research is finished, the bench stands powered, a bill waits on it, a beast corpse
# lies on the ground and a colonist who can do the bench's work is standing by. The research tab itself is a
# picture a person still has to look at (README, M6); this scenario settles the job chain and keeps a capture.
@review
Feature: A colonist works the beast gene extractor to the end

  Scenario: a colonist hauls a beast corpse to the extractor and gets ten archite capsules
    Given the save "test-colony" is loaded
    And Ancient Chinese Beast: the research "SZ_BeastGene" is finished
    And Ancient Chinese Beast: I place a powered "SZ_BeastGeneExtractor" of the player's centred at x=156 z=146
    And Ancient Chinese Beast: I spawn the pawn "SZ_QiongQi" at x=150 z=146
    And Ancient Chinese Beast: I kill "SZ_QiongQi" at x=150 z=146
    And Ancient Chinese Beast: I spawn a colonist who can do "Smithing" work at x=150 z=142
    When Ancient Chinese Beast: I put the bill "SZ_ExtractGene" on the "SZ_BeastGeneExtractor"
    Then Ancient Chinese Beast: at least 10 "ArchiteCapsule" lie on the map within 120 seconds
    And I zoom all the way in
    And I move the camera to (156, 146)
    And I take a screenshot "extractor after the colonist worked the bill"
    And no errors were logged
