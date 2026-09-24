# Runtime checks only: the offline suite owns XML, type and translation inventories.
Feature: Ancient Chinese Beast loads in the minimal set

  Scenario: its hard dependencies and principal content load without an error
    Then mod "nelim.ancientchinesebeastandgeneexpandedrenew" is loaded
    And mod "brrainz.harmony" is loaded
    And mod "Ludeon.RimWorld.Biotech" is loaded
    And mod "nelim.ancientchinesebeastandgeneexpandedrenew" loads after "brrainz.harmony"
    And def "SZ_MingShe" of type "PawnKindDef" exists
    And def "SZ_QiongQi" of type "PawnKindDef" exists
    And def "SZ_SeXie" of type "PawnKindDef" exists
    And def "SZ_YearBeast" of type "PawnKindDef" exists
    And def "SZ_Chicken" of type "PawnKindDef" exists
    And def "SZ_BeastGeneExtractor" of type "ThingDef" exists
    And no warnings from mod "Ancient Chinese Beast And Gene Expanded Renew (unofficial)"
    And no errors were logged
