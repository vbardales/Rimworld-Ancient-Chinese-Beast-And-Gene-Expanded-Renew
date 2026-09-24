# Every recipe of the beast gene extractor goes through one Harmony postfix on the game's recipe
# products. 08 shows it once for a gene and once for a clone, with a picture; these run it for all of
# them, so that a recipe whose gene, faction or output the postfix gets wrong cannot hide behind the two
# that were looked at. The recipe-to-gene table is the one in Defs/Recipe/ExtractGenes.xml, twelve rows;
# the content checker in Tests/ proves the two agree on the disk, this proves the game does.
Feature: Every extractor recipe produces what its def says

  Scenario Outline: a gene extraction recipe produces its genepack
    Given the save "test-colony" is loaded
    When Ancient Chinese Beast: I make recipe "<recipe>"
    Then Ancient Chinese Beast: the recipe output is a genepack containing "<gene>"
    And no errors were logged

    Examples:
      | recipe                  | gene                          |
      | SZ_ExtractGene_YearA    | SZGene_YearBeast_Flamethrower |
      | SZ_ExtractGene_YearB    | SZGene_YearBeast_Skin         |
      | SZ_ExtractGene_YearC    | SZGene_YearBeast_Horn         |
      | SZ_ExtractGene_QiongQiA | SZGene_QiongQi_FlyingStrike   |
      | SZ_ExtractGene_QiongQiB | SZGene_QiongQi_Eyes           |
      | SZ_ExtractGene_QiongQiC | SZGene_QiongQi_Scratch        |
      | SZ_ExtractGene_MingSheA | SZGene_MingShe_WindWing       |
      | SZ_ExtractGene_MingSheB | SZGene_MingShe_SoundWave      |
      | SZ_ExtractGene_MingSheC | SZGene_MingShe_Teeth          |
      | SZ_ExtractGene_SeXieA   | SZGene_SeXie_Shoot            |
      | SZ_ExtractGene_SeXieB   | SZGene_SeXie_Ring             |
      | SZ_ExtractGene_SeXieC   | SZGene_SeXie_Strength         |

  Scenario Outline: a clone recipe produces its tame beast, in the player's faction
    Given the save "test-colony" is loaded
    When Ancient Chinese Beast: I make recipe "<recipe>"
    Then Ancient Chinese Beast: the recipe output is a player "<pawn>" pawn
    And no errors were logged

    Examples:
      | recipe             | pawn                    |
      | SZ_Clone_YearBeast | SZ_YearBeast_Friendly   |
      | SZ_Clone_SeXieA    | SZ_SeXie_Friendly       |
      | SZ_Clone_SeXieB    | SZ_SeXieInsect_Friendly |
      | SZ_Clone_QiongQi   | SZ_QiongQi_Friendly     |
      | SZ_Clone_MingShe   | SZ_MingShe_Friendly     |

  # The one recipe here that runs the game's own product code, which needs a worker to read an ideology from.
  Scenario: rendering a beast corpse gives ten archite capsules
    Given the save "test-colony" is loaded
    And a colonist "Ada" exists
    When Ancient Chinese Beast: I make recipe "SZ_ExtractGene"
    Then Ancient Chinese Beast: the recipe output holds 10 "ArchiteCapsule"
    And no errors were logged

  # The historical failure of the drought comp: it created its game condition only for a wild beast and
  # ended it unconditionally, so a tame mingshe threw when it died. The tame one is the recipe's own.
  Scenario: a tame mingshe brings no drought and dies without an error
    Given the save "test-colony" is loaded
    When Ancient Chinese Beast: I make recipe "SZ_Clone_MingShe"
    And Ancient Chinese Beast: I display the recipe output at x=146 z=155
    Then Ancient Chinese Beast: drought is not active
    When Ancient Chinese Beast: the "SZ_MingShe_Friendly" at x=146 z=155 is killed outright
    Then Ancient Chinese Beast: drought is not active
    And no errors were logged
