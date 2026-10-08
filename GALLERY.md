# Gallery plan

Rules (`PUBLISHING.md`, « Images », read 2026-10-08): every gallery picture is a **staged photograph** of one story, shot
on the shared Sanctuary location (`Nelims-tribe`, Nelim's Sanctuary Backlot), except menus, which are plain screenshots.
This mod has no settings page, so there is no menu picture. Image `0-` is the byte copy of `Mod/About/Preview.png`; the
others are numbered `1-`, `2-`… on one digit, in page order, each under 2 MB, the folder under 8 MB. A candidate is named
`<n>-candidate-<name>.png` until the owner accepts it (`candidate` is then dropped); a refused one is deleted. The earlier
captures of the test colony (`2026-10-01a-p1-en`) are test proof only and are never used.

## The story

One day at Nelim's Sanctuary, told like a wildlife report on four beasts out of the Classic of Mountains and Seas that
came with the New Year. Two keepers walk the day, chosen by hand (body, face, hair, clothes, eyes): **Lan** (black hair in a
ponytail, a jade robe, golden eyes) and **Ren** (silver hair, a crimson duster over a cream shirt, crimson eyes). Each picture
is an encounter, never a row of subjects.

## Places, chosen on the places' own descriptions (`PickleTools/docs/GALERIE.md`, `SANCTUAIRE-LIEUX.md`)

All named places were read. Chosen: `statue-garden` (statues and flowers: a divine rooster among them), `enclosure-south`
(the Backlot's advice for imposing animals and monsters), `gravel-yard` (35 x 25 of flat ground, emptied, for a flight and
a shot that cross twenty cells), `bare-clearing` (earth, the vanometric cell hidden, for the fire), `water-garden` (a pond
bank, for the red ring to read against green and water), `postindustrial-workshop` (powered, for the extractor). Not
chosen: the house rooms (the thrumbo sleep there and the light is warm for a beast of fire), the smileys (a loud orange
carpet), `exhibition-zone` (reserved for a full-screen window, which this mod does not have).

## Shot list (feature `24-gallery`, one scenario = one image)

| # | Hour | Place | Subject |
| --- | --- | --- | --- |
| 1 | 6 | statue-garden | the Pleiades star officer crows at dawn among the statues, a hen beside it, Lan listens |
| 2 | 10 | enclosure-south | the four beasts, Ren at the gate |
| 3 | 12 | gravel-yard | the qiongqi caught in the air, flying at Lan, the farthest |
| 4 | 14 | bare-clearing | the nian beast breathes fire at a muffalo, Ren holds a firecracker |
| 5 | 16 | gravel-yard | the mingshe's wind barrier throws back Lan's shot |
| 6 | 18 | water-garden | the scorpion sexie and the red ring of its aura, Ren inside it, berserk |
| 7 | 12 | postindustrial-workshop | the gene extractor, a qiongqi corpse beside it, archite capsules, Lan at the bench |

## How it runs

- Pass map `Tests/Pickle/wsl-deps.sanctuary.map` (a copy of the Backlot's minimum list, with its seeds in
  `Tests/Pickle/config/sanctuary/`); the feature carries `@requires:nelim.sanctuarybacklot`, so every other pass skips it.
- Steps: the Sanctuary and Pickle Tools steps for the place, the decor, the keepers' look and the camera; this suite's
  `GallerySteps.cs` for a beast placed and turned on a cell, a qiongqi caught in its flight, the pause and the capture of
  the map alone. A pose cannot be frozen (no step, verified negative by Pickle Tools): the pawn stays put because the game is paused.
- A green run does not validate a picture: every capture is opened. What comes from the scene or from a shared tool is
  described to Pickle Tools with the capture (via the Ticket Manager if it cannot be reached), never worked around here.
- Captures are recompressed (palette or width) to stay under 2 MB each before they enter `Art/Gallery/` as candidates.

## State (2026-10-08)

Written and resolved by `Check-Steps.ps1` (all patterns compile, every line resolves against this suite, Pickle and both
shared catalogues); first run requested, evidence `2026-10-08d-gallery-1`; no capture seen yet; `Art/Gallery/` holds
`0-preview.png` only.
