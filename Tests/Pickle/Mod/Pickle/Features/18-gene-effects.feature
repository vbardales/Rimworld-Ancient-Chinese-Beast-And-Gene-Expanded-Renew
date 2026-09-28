# M7 of Tests/Pickle/README.md's manual exceptions: the genes' effects on a colonist, which 08 and 12 do not reach
# (they play the recipes that extract the genes, not what a gene does once implanted). Two of the three that
# TESTING.md E4 calls measurable are stat or hediff facts and are asserted here; the qiongqi eye's dodge is a coin
# flip per projectile and stays for a statistical scenario (M3's family).
Feature: What the extracted genes do to a colonist

  Scenario: monstrous strength doubles an unarmed colonist's melee damage
    Given the save "test-colony" is loaded
    And Ancient Chinese Beast: I spawn a colonist at x=146 z=152
    When Ancient Chinese Beast: pawn 1 receives the gene "SZGene_SeXie_Strength"
    Then Ancient Chinese Beast: pawn 1 deals doubled melee damage unarmed within 10 seconds
    And no errors were logged

  Scenario: the nian beast's horn adds hit points to the part that carries it
    Given the save "test-colony" is loaded
    And Ancient Chinese Beast: I spawn a colonist at x=146 z=152
    When Ancient Chinese Beast: pawn 1 receives the gene "SZGene_YearBeast_Horn"
    Then Ancient Chinese Beast: pawn 1 has a nian horn whose part holds more hit points than its base
    And no errors were logged
