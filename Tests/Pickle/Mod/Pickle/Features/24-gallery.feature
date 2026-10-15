# The Workshop gallery of this mod, in the order it is uploaded (0- is the copy of the Preview, then gallery-1 to gallery-7).
# RESTAGED 2026-10-15 after the owner's question "does the story match the scenario?": the first series (2026-10-08) had two hand-made
# keepers, Lan and Ren, and no Nelim; its pawns were 20 to 60 px tall (zoom 6 to 12), their hair, clothes and eyes could not be read, every
# face was "normal", Ren (image 4) and the shooter (image 5) were out of frame (a pawn that is not paused wanders off while the camera moves),
# and every beast was seen from the side or from behind. Now: Nelim is the protagonist and is in every image (owner rule 2026-10-14), she wears
# what the fixture gives her plus a Taoist hat of Chinese Comprehensive Expansion (the theme: a Chinese mod serving a Chinese bestiary), her
# face is her own (the Sanctuary step) with a cheerful expression set last, the camera is at zoom 5 to 9, time is paused BEFORE any pawn is
# placed so that nobody walks away, and the beasts face South (toward the camera) so that their fronts can be seen.
#
# THE STORY. One day at Nelim's Sanctuary, told like a wildlife report on four beasts out of the Classic of Mountains and Seas that came
# with the New Year, and the rooster that announces the day. Nelim is the keeper; Ren (silver hair, crimson duster, crimson eyes) is the only
# guest, a hunter, in the two images that need someone to shoot or to be shaken. Each picture is an encounter, never a row:
#   1  6 h   statue garden:    Nelim listens to the Pleiades star officer crowing at dawn among the statues, a hen beside it;
#   2 10 h   south enclosure:  the four beasts in a loose arc, Nelim at the gate turning to the camera;
#   3 12 h   gravel yard:      the qiongqi faces the camera behind Nelim, who stands her ground (the flight itself is proven by feature 21: a frame cannot catch it);
#   4 14 h   bare clearing:    the nian beast breathes fire at a muffalo while Nelim holds a firecracker, the one thing it fears;
#   5 16 h   gravel yard:      Ren fires at the mingshe, its wind barrier throws the shot back, Nelim watches beside him;
#   6 18 h   water garden:     the scorpion sexie and the red ring of its aura, Ren inside it, berserk, Nelim at the edge of the ring;
#   7 12 h   postindustrial workshop, emptied first and roof removed: the gene extractor, three archite capsules, Nelim at the bench.
# Each pawn is placed AFTER the time is paused, then the face, then the frame, then the capture, at once. The size limit of the page (owner,
# 2026-10-06): each image under 2 MB, all together under 8 MB; the captures are recompressed before they go to Art/Gallery/. Subtitles:
# PUBLICATION.md, "Gallery subtitles".
#
# Every scenario is @review: a green run proves a picture was taken, not that it is worth uploading. Open every capture before keeping it,
# and drop one that shows the launcher, the log viewer, a dev-mode bar, a pawn or an animal of another mod, or an empty frame; what comes
# from the scene or the shared tool is reported to Pickle Tools (via the Ticket Manager if unreachable).
#
# Steps: the places and their cleaning, and Nelim's own face, are Nelim's Sanctuary steps (SanctuaryBacklot); the generic tools (presentation
# mode, framing, bodies, clothes, ticks, the facial expression) are Nelim's Pickle Tools steps; the beasts and the capture are this suite's own.
# Run under wsl-deps.sanctuary.map (the Backlot's minimum list plus Chinese Comprehensive Expansion), which makes the feature skip itself in
# every other pass.
@review
@requires:nelim.sanctuarybacklot
@requires:nelim.pickletools.screenshotmode
@requires:nelim.pickletools.colonistrace
@requires:nelim.pickletools.camerazoom
@requires:nelim.pickletools.screenshotstudio
@requires:nelim.pickletools.stagedecor
@requires:ninedaylongbow.ChineseComprehensiveExpansion
Feature: The gallery of Ancient Chinese Beast And Gene Expanded Renew

  Background:
    Given the save "Nelims-tribe" is loaded

  Scenario: gallery 1 - Nelim listens to the Pleiades star officer at dawn
    Given I set the hour to 6
    And I set the weather to "Clear"
    And Nelim's Pickle Tools: the colonists are sent to the map corner
    And Nelim's Pickle Tools: the temperature of the map is 18 degrees
    And Nelim's Sanctuary: I am at the sanctuary "statue-garden"
    And Nelim's Pickle Tools: studio presentation mode is enabled
    And Nelim's Pickle Tools: I let 60 ticks pass
    And Nelim's Pickle Tools: all animals are removed
    And Ancient Chinese Beast: I spawn the male pawn "SZ_Chicken" at (156, 97) facing South
    And Ancient Chinese Beast: I spawn the female pawn "SZ_Chicken" at (159, 96) facing South
    And Nelim's Pickle Tools: time is paused for the capture
    And Nelim's Pickle Tools: "Nelim" wears "HXApparel_TaoistHat_A"
    And Nelim's Pickle Tools: "Nelim" stands at (152, 97) facing South
    And Nelim's Sanctuary: Nelim has her own face
    And Nelim's Pickle Tools: "Nelim" facial expression is "normal+moodCheerful"
    And Nelim's Pickle Tools: I frame the cell (155, 97) at zoom 5
    And Nelim's Pickle Tools: the map is shown alone for a capture
    When I take a screenshot "gallery-1-dawn-crow"
    And Nelim's Pickle Tools: the interface is shown again

  Scenario: gallery 2 - the four beasts in the south enclosure
    Given I set the hour to 10
    And I set the weather to "Clear"
    And Nelim's Pickle Tools: the colonists are sent to the map corner
    And Nelim's Pickle Tools: the temperature of the map is 20 degrees
    And Nelim's Sanctuary: I am at the sanctuary "enclosure-south"
    And Nelim's Pickle Tools: studio presentation mode is enabled
    And Nelim's Pickle Tools: I let 60 ticks pass
    And Nelim's Pickle Tools: all animals are removed
    And Ancient Chinese Beast: I spawn the pawn "SZ_MingShe" at (141, 216) facing South
    And Ancient Chinese Beast: I spawn the pawn "SZ_QiongQi" at (148, 213) facing South
    And Ancient Chinese Beast: I spawn the pawn "SZ_YearBeast" at (155, 213) facing South
    And Ancient Chinese Beast: I spawn the pawn "SZ_SeXieInsect" at (162, 216) facing South
    And Nelim's Pickle Tools: time is paused for the capture
    And Nelim's Pickle Tools: "Nelim" wears "HXApparel_TaoistHat_A"
    And Nelim's Pickle Tools: "Nelim" stands at (158, 208) facing South
    And Nelim's Sanctuary: Nelim has her own face
    And Nelim's Pickle Tools: "Nelim" facial expression is "normal+moodCheerful"
    And Nelim's Pickle Tools: I frame the cell (151, 213) at zoom 9
    And Nelim's Pickle Tools: the map is shown alone for a capture
    When I take a screenshot "gallery-2-four-beasts"
    And Nelim's Pickle Tools: the interface is shown again

  Scenario: gallery 3 - the qiongqi behind Nelim, who stands her ground
    Given I set the hour to 12
    And I set the weather to "Clear"
    And Nelim's Pickle Tools: the colonists are sent to the map corner
    And Nelim's Pickle Tools: the temperature of the map is 20 degrees
    And Nelim's Sanctuary: the sanctuary "gravel-yard" is emptied
    And Nelim's Sanctuary: I am at the sanctuary "gravel-yard"
    And Nelim's Pickle Tools: studio presentation mode is enabled
    And Nelim's Pickle Tools: I let 60 ticks pass
    And Nelim's Pickle Tools: all animals are removed
    And Ancient Chinese Beast: I spawn the pawn "SZ_QiongQi" at (169, 146) facing South
    And Nelim's Pickle Tools: time is paused for the capture
    And Nelim's Pickle Tools: "Nelim" wears "HXApparel_TaoistHat_A"
    And Nelim's Pickle Tools: "Nelim" stands at (172, 141) facing South
    And Nelim's Sanctuary: Nelim has her own face
    And Nelim's Pickle Tools: "Nelim" facial expression is "normal+moodCheerful"
    And Nelim's Pickle Tools: I frame the cell (170, 143) at zoom 6
    When Nelim's Pickle Tools: the map is shown alone for a capture
    And I take a screenshot "gallery-3-qiongqi-behind-nelim"
    And Nelim's Pickle Tools: the interface is shown again

  Scenario: gallery 4 - the nian beast breathes fire, Nelim holds a firecracker
    Given I set the hour to 14
    And I set the weather to "Clear"
    And Nelim's Pickle Tools: the colonists are sent to the map corner
    And Nelim's Pickle Tools: the temperature of the map is 20 degrees
    And Nelim's Sanctuary: the vanometric cell of the sanctuary is hidden
    And Nelim's Sanctuary: the floor of the sanctuary "emerald-clearing" is bared
    And Nelim's Sanctuary: I am at the sanctuary "bare-clearing"
    And Nelim's Pickle Tools: studio presentation mode is enabled
    And Nelim's Pickle Tools: I let 60 ticks pass
    And Nelim's Pickle Tools: all animals are removed
    And Ancient Chinese Beast: I spawn the pawn "SZ_YearBeast" at (192, 152) facing East
    And Ancient Chinese Beast: I spawn the pawn "Muffalo" at (200, 152) facing West
    When Ancient Chinese Beast: pawn 1 breathes fire at pawn 2
    And Nelim's Pickle Tools: I let 30 ticks pass
    Then Ancient Chinese Beast: a thing "SZ_YearBeastFlame" exists within 5 seconds
    And Nelim's Pickle Tools: time is paused for the capture
    And Nelim's Pickle Tools: "Nelim" wears "HXApparel_TaoistHat_A"
    And Nelim's Pickle Tools: "Nelim" stands at (190, 147) facing South
    And Nelim's Pickle Tools: "Nelim" carries the item "SZ_Firecracker"
    And Nelim's Sanctuary: Nelim has her own face
    And Nelim's Pickle Tools: "Nelim" facial expression is "normal+moodCheerful"
    And Nelim's Pickle Tools: I frame the cell (194, 150) at zoom 7
    And Nelim's Pickle Tools: the map is shown alone for a capture
    And I take a screenshot "gallery-4-fire-breath"
    And Nelim's Pickle Tools: the interface is shown again

  Scenario: gallery 5 - the wind barrier throws back Ren's shot, Nelim watches
    Given I set the hour to 16
    And I set the weather to "Clear"
    And Nelim's Pickle Tools: the colonists are sent to the map corner
    And Nelim's Pickle Tools: the temperature of the map is 20 degrees
    And Nelim's Sanctuary: the sanctuary "gravel-yard" is emptied
    And Nelim's Sanctuary: I am at the sanctuary "gravel-yard"
    And Nelim's Pickle Tools: studio presentation mode is enabled
    And Nelim's Pickle Tools: I let 60 ticks pass
    And Nelim's Pickle Tools: all animals are removed
    And Ancient Chinese Beast: I spawn the pawn "SZ_MingShe" at (166, 143) facing East
    And a colonist "Ren" exists
    And Nelim's Pickle Tools: "Ren" gender is male
    And Nelim's Pickle Tools: "Ren" body type is Male
    And Nelim's Pickle Tools: "Ren" hairstyle is "Messy"
    And Nelim's Pickle Tools: "Ren" hair colour is rgb (232, 232, 238)
    And Nelim's Pickle Tools: "Ren" has the gene "Eyes_Crimson"
    And Nelim's Pickle Tools: "Ren" wears "Apparel_CollarShirt" dyed rgb (236, 226, 200)
    And Nelim's Pickle Tools: "Ren" wears "Apparel_Duster" dyed rgb (176, 38, 42)
    And Nelim's Pickle Tools: "Ren" wears "Apparel_Pants" dyed rgb (44, 40, 48)
    And Nelim's Pickle Tools: "Ren" stands at (180, 143) facing West
    And Ancient Chinese Beast: the colonist "Ren" is added to the pawns
    And Ancient Chinese Beast: pawn 2 is armed with "Gun_BoltActionRifle"
    And Nelim's Pickle Tools: I frame the cell (173, 143) at zoom 8
    When Ancient Chinese Beast: the wind barrier of pawn 1 is raised
    And Ancient Chinese Beast: pawn 2 shoots at pawn 1
    Then Ancient Chinese Beast: a projectile launched by pawn 1 is in flight within 10 seconds
    And Nelim's Pickle Tools: time is paused for the capture
    And Nelim's Pickle Tools: "Nelim" wears "HXApparel_TaoistHat_A"
    And Nelim's Pickle Tools: "Nelim" stands at (177, 140) facing South
    And Nelim's Sanctuary: Nelim has her own face
    And Nelim's Pickle Tools: "Nelim" facial expression is "normal+moodCheerful"
    And Nelim's Pickle Tools: the map is shown alone for a capture
    And I take a screenshot "gallery-5-wind-barrier"
    And Nelim's Pickle Tools: the interface is shown again

  Scenario: gallery 6 - the scorpion sexie and the ring of its aura
    Given I set the hour to 18
    And I set the weather to "Clear"
    And Nelim's Pickle Tools: the colonists are sent to the map corner
    And Nelim's Pickle Tools: the temperature of the map is 20 degrees
    And Nelim's Sanctuary: I am at the sanctuary "water-garden"
    And Nelim's Pickle Tools: studio presentation mode is enabled
    And Nelim's Pickle Tools: I let 60 ticks pass
    And Nelim's Pickle Tools: all animals are removed
    And Ancient Chinese Beast: I spawn a colonist named "Ren" near x=146 z=171
    And Nelim's Pickle Tools: "Ren" gender is male
    And Nelim's Pickle Tools: "Ren" body type is Male
    And Nelim's Pickle Tools: "Ren" hairstyle is "Messy"
    And Nelim's Pickle Tools: "Ren" hair colour is rgb (232, 232, 238)
    And Nelim's Pickle Tools: "Ren" has the gene "Eyes_Crimson"
    And Nelim's Pickle Tools: "Ren" wears "Apparel_CollarShirt" dyed rgb (236, 226, 200)
    And Nelim's Pickle Tools: "Ren" wears "Apparel_Duster" dyed rgb (176, 38, 42)
    And Nelim's Pickle Tools: "Ren" wears "Apparel_Pants" dyed rgb (44, 40, 48)
    And Nelim's Pickle Tools: "Ren" stands at (146, 171) facing South
    And Ancient Chinese Beast: I spawn the pawn "SZ_SeXieInsect" at (151, 172) with its aura clock at zero
    And Nelim's Pickle Tools: time is paused for the capture
    And Nelim's Pickle Tools: I frame the cell (147, 171) at zoom 8
    When Ancient Chinese Beast: pawn 1 is sent berserk as the aura does
    And Nelim's Pickle Tools: time is paused for the capture
    And Nelim's Pickle Tools: "Nelim" wears "HXApparel_TaoistHat_A"
    And Nelim's Pickle Tools: "Nelim" stands at (137, 169) facing South
    And Nelim's Sanctuary: Nelim has her own face
    And Nelim's Pickle Tools: "Nelim" facial expression is "normal+moodCheerful"
    And Nelim's Pickle Tools: the map is shown alone for a capture
    And I take a screenshot "gallery-6-sexie-aura"
    And Nelim's Pickle Tools: the interface is shown again

  Scenario: gallery 7 - the gene extractor in the postindustrial workshop
    Given I set the hour to 12
    And I set the weather to "Clear"
    And Nelim's Pickle Tools: the colonists are sent to the map corner
    And Nelim's Pickle Tools: the temperature of the map is 20 degrees
    And Ancient Chinese Beast: the research "SZ_BeastGene" is finished
    And Nelim's Sanctuary: I am at the sanctuary "postindustrial-workshop"
    And Nelim's Pickle Tools: studio presentation mode is enabled
    And Nelim's Pickle Tools: I let 60 ticks pass
    And Nelim's Pickle Tools: all animals are removed
    And Nelim's Sanctuary: the sanctuary "postindustrial-workshop" is emptied
    And Nelim's Sanctuary: the roof is removed from the sanctuary "postindustrial-workshop"
    And Nelim's Pickle Tools: time is paused for the capture
    And Ancient Chinese Beast: I place a powered "SZ_BeastGeneExtractor" of the player's centred at x=229 z=214
    And Nelim's Pickle Tools: I place the decor "ArchiteCapsule" at (228, 211)
    And Nelim's Pickle Tools: I place the decor "ArchiteCapsule" at (229, 211)
    And Nelim's Pickle Tools: I place the decor "ArchiteCapsule" at (230, 211)
    And Nelim's Pickle Tools: "Nelim" wears "HXApparel_TaoistHat_A"
    And Nelim's Pickle Tools: "Nelim" stands at (232, 212) facing South
    And Nelim's Sanctuary: Nelim has her own face
    And Nelim's Pickle Tools: "Nelim" facial expression is "normal+moodCheerful"
    And Nelim's Pickle Tools: I frame the cell (230, 213) at zoom 7
    And Nelim's Pickle Tools: the map is shown alone for a capture
    When I take a screenshot "gallery-7-extractor"
    And Nelim's Pickle Tools: the interface is shown again
    And Nelim's Pickle Tools: the decor is removed
