# Gallery plan

Rules (`PUBLISHING.md`, « Images », read 2026-10-08): every gallery picture = **staged photograph** of one story, shot on shared Sanctuary location (`Nelims-tribe`, Nelim's Sanctuary Backlot). Exception: menus = plain screenshots. Mod has no settings page → no menu picture. Image `0-` = byte copy of `Mod/About/Preview.png`; others numbered `1-`, `2-`… one digit, page order, each <2 MB, folder <8 MB. Candidate named `<n>-candidate-<name>.png` until owner accepts (then drop `candidate`); refused → deleted. Earlier test colony captures (`2026-10-01a-p1-en`) = test proof only, never used.

## The story (restaged 2026-10-15)

One day at Nelim’s Sanctuary, told as wildlife report on four beasts from Classic of Mountains and Seas that came with New Year, plus rooster announcing day. **Nelim is the protagonist** (owner rule 2026-10-14), in every image: jade middle robe (RimImmortal-Living), Taoist hat (Chinese Comprehensive Expansion, the theme), RimImmortal-Hairstyle bun, own face, cheerful expression. Ren takes man's bun, same mod. **Ren** (silver hair, crimson duster, crimson eyes) = only guest, in two images needing shooter or victim. Camera zoom 5–9, time paused before any pawn placed, beasts face South. First series (Lan and Ren, zoom 6–12) replaced; see STATUS.md, "Gallery review 2026-10-15".

## Places, chosen on the places' own descriptions (`PickleTools/docs/GALERIE.md`, `SANCTUAIRE-LIEUX.md`)

All named places read. Chosen: `statue-garden` (statues + flowers: divine rooster among them), `enclosure-south` (Backlot advice for imposing animals/monsters), `gravel-yard` (35 x 25 flat ground, emptied, for flight and shot crossing twenty cells), `bare-clearing` (earth, vanometric cell hidden, for fire), `water-garden` (pond bank, red ring reads against green + water), `postindustrial-workshop` (powered, for extractor). Not chosen: house rooms (thrumbo sleep there, warm light wrong for fire beast), smileys (loud orange carpet), `exhibition-zone` (reserved for full-screen window, mod has none).

## Shot list (feature `24-gallery`, one scenario = one image)

| # | Hour | Place | Subject |
| --- | --- | --- | --- |
| 1 | 6 | statue-garden | Nelim listens to Pleiades star officer crowing at dawn among statues, hen beside |
| 2 | 10 | enclosure-south | four beasts in loose arc, Nelim at gate |
| 3 | 12 | gravel-yard | qiongqi faces camera behind Nelim |
| 4 | 14 | bare-clearing | nian beast breathes fire at muffalo, Nelim holds firecracker |
| 5 | 16 | gravel-yard | Ren fires, mingshe’s wind barrier throws shot back, Nelim watches |
| 6 | 18 | water-garden | scorpion sexie + red ring, Ren inside, berserk, Nelim at edge |
| 7 | 12 | postindustrial-workshop | gene extractor, three archite capsules, Nelim at bench |

## How it runs

- Pass map `Tests/Pickle/wsl-deps.sanctuary.map` (copy of Backlot's minimum list, seeds in `Tests/Pickle/config/sanctuary/`); feature carries `@requires:nelim.sanctuarybacklot`, so every other pass skips it.
- Steps: Sanctuary + Pickle Tools steps for place, decor, keepers' look, camera; this suite's `GallerySteps.cs` for beast placed + turned on cell, qiongqi caught mid-flight, pause, capture of map alone. Pose cannot be frozen (no step, verified negative by Pickle Tools): pawn stays put because game paused.
- Green run ≠ validated picture: open every capture. Issues from scene or shared tool → describe to Pickle Tools with capture (via Ticket Manager if unreachable), never work around here.
- Recompress captures (palette or width) to stay <2 MB each before entering `Art/Gallery/` as candidates.

## State (2026-10-08)

Written + resolved by shared `scripts/Check-Steps.ps1` (all patterns compile, every line resolves against this suite, Pickle, both shared catalogues); first run requested, evidence `2026-10-08d-gallery-1`; no capture seen yet; `Art/Gallery/` holds `0-preview.png` only.