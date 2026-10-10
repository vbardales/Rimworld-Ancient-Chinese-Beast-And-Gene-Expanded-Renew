# The Workshop gallery of this mod, in the order it is uploaded (0- is the copy of the Preview, then gallery-1 to gallery-7).
# The item is not public yet; the gallery is for the owner's page and is accepted by her image by image (PUBLISHING.md).
#
# The story: one day at Nelim's Sanctuary, told like a wildlife report on four beasts out of the Classic of Mountains and Seas
# that came with the New Year. Two keepers walk the day: Lan (black hair in a ponytail, a jade robe, golden eyes) and Ren
# (silver hair, a crimson duster over a cream shirt, crimson eyes). Each picture is an encounter, never a row:
#   1  6 h   statue garden:    the Pleiades star officer crows at dawn among the statues, a hen beside it, Lan listens;
#   2 10 h   south enclosure:  the four beasts, one beside the other, Ren at the gate;
#   3 12 h   gravel yard:      the qiongqi caught in the air, in its flying strike at Lan, the farthest, Ren watching;
#   4 14 h   bare clearing:    the nian beast breathes fire at a muffalo, Ren holding a firecracker;
#   5 16 h   gravel yard:      the mingshe's wind barrier throws back Lan's shot;
#   6 18 h   water garden:     the scorpion sexie and the red ring of its aura, Ren inside it, berserk;
#   7 12 h   postindustrial workshop: the gene extractor, a qiongqi corpse beside it, archite capsules, Lan at the bench.
# The size limit of the page (owner, 2026-10-06): any number of images, each under 2 MB, all together under 8 MB; the
# captures are recompressed before they go to Art/Gallery/, as `<n>-candidate-<name>` until she accepts them.
#
# Each scenario is one image: it sets the hour and the weather of its moment, frames its own corner of the shared place,
# photographs, and the interface comes back. Animals already living in a place are removed first; time is paused once the
# beasts stand, so that one does not eat its neighbour before the picture.
#
# Every scenario is @review: a green run proves a picture was taken, not that it is worth uploading. Open every capture before
# keeping it, and drop one that shows the launcher, the log viewer, a dev-mode bar, a pawn or an animal of another mod, or an
# empty frame; what comes from the scene or the shared tool is reported to Pickle Tools (via the Ticket Manager if unreachable).
#
# Steps: the places and their cleaning are Nelim's Sanctuary steps (SanctuaryBacklot); the generic tools (presentation mode,
# decor, framing, bodies, clothes, ticks) are Nelim's Pickle Tools steps; the beasts and the capture are this suite's own.
# Run under wsl-deps.sanctuary.map (the Backlot's minimum list), which makes the feature skip itself in every other pass.
@review
@requires:nelim.sanctuarybacklot
Feature: The gallery of Ancient Chinese Beast And Gene Expanded Renew

  Background:
    Given the save "Nelims-tribe" is loaded

  Scenario: gallery 1 - the Pleiades star officer crows at dawn
    Given I set the hour to 6
    And I set the weather to "Clear"
    And Nelim's Pickle Tools: the colonists are sent to the map corner
    And Nelim's Pickle Tools: the temperature of the map is 18 degrees
    And Nelim's Sanctuary: I am at the sanctuary "statue-garden"
    And Nelim's Pickle Tools: studio presentation mode is enabled
    And Nelim's Pickle Tools: I let 60 ticks pass
    And Nelim's Pickle Tools: all animals are removed
    And Ancient Chinese Beast: I spawn the male pawn "SZ_Chicken" at (155, 98) facing East
    And Ancient Chinese Beast: I spawn the female pawn "SZ_Chicken" at (158, 97) facing West
    And a colonist "Lan" exists
    And Nelim's Pickle Tools: "Lan" gender is female
    And Nelim's Pickle Tools: "Lan" body type is Female
    And Nelim's Pickle Tools: "Lan" hairstyle is "Ponytails"
    And Nelim's Pickle Tools: "Lan" hair colour is rgb (30, 26, 28)
    And Nelim's Pickle Tools: "Lan" has the gene "Eyes_Golden"
    And Nelim's Pickle Tools: "Lan" wears "Apparel_Robe" dyed rgb (46, 125, 98)
    And Nelim's Pickle Tools: "Lan" wears "Apparel_Pants" dyed rgb (50, 50, 56)
    And Nelim's Pickle Tools: "Lan" stands at (152, 96) facing East
    And Nelim's Pickle Tools: "Lan" facial expression is "normal"
    And Nelim's Pickle Tools: I frame the cell (155, 97) at zoom 6
    And Ancient Chinese Beast: time is paused
    And Ancient Chinese Beast: the map is shown alone for a capture
    When I take a screenshot "gallery-1-dawn-crow"
    And Ancient Chinese Beast: the interface is shown again

  Scenario: gallery 2 - the four beasts in the south enclosure
    Given I set the hour to 10
    And I set the weather to "Clear"
    And Nelim's Pickle Tools: the colonists are sent to the map corner
    And Nelim's Pickle Tools: the temperature of the map is 20 degrees
    And Nelim's Sanctuary: I am at the sanctuary "enclosure-south"
    And Nelim's Pickle Tools: studio presentation mode is enabled
    And Nelim's Pickle Tools: I let 60 ticks pass
    And Nelim's Pickle Tools: all animals are removed
    And Ancient Chinese Beast: I spawn the pawn "SZ_MingShe" at (137, 217) facing East
    And Ancient Chinese Beast: I spawn the pawn "SZ_QiongQi" at (145, 212) facing East
    And Ancient Chinese Beast: I spawn the pawn "SZ_YearBeast" at (154, 214) facing West
    And Ancient Chinese Beast: I spawn the pawn "SZ_SeXieInsect" at (162, 217) facing West
    And a colonist "Ren" exists
    And Nelim's Pickle Tools: "Ren" gender is male
    And Nelim's Pickle Tools: "Ren" body type is Male
    And Nelim's Pickle Tools: "Ren" hairstyle is "Messy"
    And Nelim's Pickle Tools: "Ren" hair colour is rgb (232, 232, 238)
    And Nelim's Pickle Tools: "Ren" has the gene "Eyes_Crimson"
    And Nelim's Pickle Tools: "Ren" wears "Apparel_CollarShirt" dyed rgb (236, 226, 200)
    And Nelim's Pickle Tools: "Ren" wears "Apparel_Duster" dyed rgb (176, 38, 42)
    And Nelim's Pickle Tools: "Ren" wears "Apparel_Pants" dyed rgb (44, 40, 48)
    And Nelim's Pickle Tools: "Ren" stands at (158, 208) facing South
    And Nelim's Pickle Tools: "Ren" facial expression is "normal"
    And Nelim's Pickle Tools: I frame the cell (149, 214) at zoom 12
    And Ancient Chinese Beast: time is paused
    And Ancient Chinese Beast: the map is shown alone for a capture
    When I take a screenshot "gallery-2-four-beasts"
    And Ancient Chinese Beast: the interface is shown again

  Scenario: gallery 3 - the qiongqi in its flying strike
    Given I set the hour to 12
    And I set the weather to "Clear"
    And Nelim's Pickle Tools: the colonists are sent to the map corner
    And Nelim's Pickle Tools: the temperature of the map is 20 degrees
    And Nelim's Sanctuary: the sanctuary "gravel-yard" is emptied
    And Nelim's Sanctuary: I am at the sanctuary "gravel-yard"
    And Nelim's Pickle Tools: studio presentation mode is enabled
    And Nelim's Pickle Tools: I let 60 ticks pass
    And Nelim's Pickle Tools: all animals are removed
    And Ancient Chinese Beast: I spawn the pawn "SZ_QiongQi" at (158, 143) facing East
    And a colonist "Lan" exists
    And Nelim's Pickle Tools: "Lan" gender is female
    And Nelim's Pickle Tools: "Lan" body type is Female
    And Nelim's Pickle Tools: "Lan" hairstyle is "Ponytails"
    And Nelim's Pickle Tools: "Lan" hair colour is rgb (30, 26, 28)
    And Nelim's Pickle Tools: "Lan" has the gene "Eyes_Golden"
    And Nelim's Pickle Tools: "Lan" wears "Apparel_Robe" dyed rgb (46, 125, 98)
    And Nelim's Pickle Tools: "Lan" wears "Apparel_Pants" dyed rgb (50, 50, 56)
    And Nelim's Pickle Tools: "Lan" stands at (182, 143) facing West
    And Nelim's Pickle Tools: "Lan" facial expression is "normal"
    And Ancient Chinese Beast: the colonist "Lan" is added to the pawns
    And Nelim's Pickle Tools: I frame the cell (170, 143) at zoom 11
    When Ancient Chinese Beast: the qiongqi pawn 1 is caught in flight at pawn 2 within 40 seconds
    And Ancient Chinese Beast: the map is shown alone for a capture
    And I take a screenshot "gallery-3-flying-strike"
    And Ancient Chinese Beast: the interface is shown again

  Scenario: gallery 4 - the nian beast breathes fire at a muffalo
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
    And Ancient Chinese Beast: I spawn the pawn "SZ_YearBeast" at (190, 152) facing East
    And Ancient Chinese Beast: I spawn the pawn "Muffalo" at (199, 152) facing West
    And a colonist "Ren" exists
    And Nelim's Pickle Tools: "Ren" gender is male
    And Nelim's Pickle Tools: "Ren" body type is Male
    And Nelim's Pickle Tools: "Ren" hairstyle is "Messy"
    And Nelim's Pickle Tools: "Ren" hair colour is rgb (232, 232, 238)
    And Nelim's Pickle Tools: "Ren" has the gene "Eyes_Crimson"
    And Nelim's Pickle Tools: "Ren" wears "Apparel_CollarShirt" dyed rgb (236, 226, 200)
    And Nelim's Pickle Tools: "Ren" wears "Apparel_Duster" dyed rgb (176, 38, 42)
    And Nelim's Pickle Tools: "Ren" wears "Apparel_Pants" dyed rgb (44, 40, 48)
    And Nelim's Pickle Tools: "Ren" stands at (192, 148) facing East
    And Nelim's Pickle Tools: "Ren" carries the item "SZ_Firecracker"
    And Nelim's Pickle Tools: I frame the cell (195, 151) at zoom 6
    When Ancient Chinese Beast: pawn 1 breathes fire at pawn 2
    And Nelim's Pickle Tools: I let 30 ticks pass
    Then Ancient Chinese Beast: a thing "SZ_YearBeastFlame" exists within 5 seconds
    And Ancient Chinese Beast: time is paused
    And Ancient Chinese Beast: the map is shown alone for a capture
    And I take a screenshot "gallery-4-fire-breath"
    And Ancient Chinese Beast: the interface is shown again

  Scenario: gallery 5 - the wind barrier throws back a shot
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
    And a colonist "Lan" exists
    And Nelim's Pickle Tools: "Lan" gender is female
    And Nelim's Pickle Tools: "Lan" body type is Female
    And Nelim's Pickle Tools: "Lan" hairstyle is "Ponytails"
    And Nelim's Pickle Tools: "Lan" hair colour is rgb (30, 26, 28)
    And Nelim's Pickle Tools: "Lan" has the gene "Eyes_Golden"
    And Nelim's Pickle Tools: "Lan" wears "Apparel_Robe" dyed rgb (46, 125, 98)
    And Nelim's Pickle Tools: "Lan" wears "Apparel_Pants" dyed rgb (50, 50, 56)
    And Nelim's Pickle Tools: "Lan" stands at (181, 143) facing West
    And Ancient Chinese Beast: the colonist "Lan" is added to the pawns
    And Ancient Chinese Beast: pawn 2 is armed with "Gun_BoltActionRifle"
    And Nelim's Pickle Tools: I frame the cell (172, 143) at zoom 9
    When Ancient Chinese Beast: the wind barrier of pawn 1 is raised
    And Ancient Chinese Beast: pawn 2 shoots at pawn 1
    Then Ancient Chinese Beast: a projectile launched by pawn 1 is in flight within 10 seconds
    And Ancient Chinese Beast: time is paused
    And Ancient Chinese Beast: the map is shown alone for a capture
    And I take a screenshot "gallery-5-wind-barrier"
    And Ancient Chinese Beast: the interface is shown again

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
    And Nelim's Pickle Tools: "Ren" stands at (146, 171) facing East
    And Ancient Chinese Beast: I spawn the pawn "SZ_SeXieInsect" at (151, 172) with its aura clock at zero
    And Ancient Chinese Beast: time is paused
    And Nelim's Pickle Tools: I frame the cell (150, 172) at zoom 11
    When Ancient Chinese Beast: pawn 1 is sent berserk as the aura does
    And Ancient Chinese Beast: time is paused
    And Ancient Chinese Beast: the map is shown alone for a capture
    And I take a screenshot "gallery-6-sexie-aura"
    And Ancient Chinese Beast: the interface is shown again

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
    And Ancient Chinese Beast: I place a powered "SZ_BeastGeneExtractor" of the player's centred at x=235 z=214
    And Ancient Chinese Beast: I spawn the pawn "SZ_QiongQi" at x=235 z=218
    And Ancient Chinese Beast: I kill "SZ_QiongQi" at x=235 z=218
    And Nelim's Pickle Tools: I place the decor "ArchiteCapsule" at (234, 211)
    And Nelim's Pickle Tools: I place the decor "ArchiteCapsule" at (235, 211)
    And Nelim's Pickle Tools: I place the decor "ArchiteCapsule" at (236, 211)
    And a colonist "Lan" exists
    And Nelim's Pickle Tools: "Lan" gender is female
    And Nelim's Pickle Tools: "Lan" body type is Female
    And Nelim's Pickle Tools: "Lan" hairstyle is "Ponytails"
    And Nelim's Pickle Tools: "Lan" hair colour is rgb (30, 26, 28)
    And Nelim's Pickle Tools: "Lan" has the gene "Eyes_Golden"
    And Nelim's Pickle Tools: "Lan" wears "Apparel_CollarShirt" dyed rgb (240, 240, 236)
    And Nelim's Pickle Tools: "Lan" wears "Apparel_Pants" dyed rgb (50, 50, 56)
    And Nelim's Pickle Tools: "Lan" stands at (237, 213) facing West
    And Nelim's Pickle Tools: I frame the cell (235, 214) at zoom 6
    And Ancient Chinese Beast: time is paused
    And Ancient Chinese Beast: the map is shown alone for a capture
    When I take a screenshot "gallery-7-extractor"
    And Ancient Chinese Beast: the interface is shown again
    And Nelim's Pickle Tools: the decor is removed
