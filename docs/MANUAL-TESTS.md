# Manual tests M1 to M9

What the Pickle suite does not play on its own. The reason for each is in `Tests/Pickle/README.md`, "The manual
exceptions", which also holds their state. `tested` waits for every one of them to be green, or to be listed as not
applicable with its reason (`AUDIT.md`, `done -> tested`). The owner does the ones that stay manual.

Rewritten in English on 2026-10-01 (this file was in French: everything the repository holds is in English,
`PUBLISHING.md`, "Dépôt").

**Where each stands on 2026-10-01.** M1 to M5 are automated and green (features 04, 20, 21, 22): nothing to do by
hand. M6 and M7 are automated and red (features 19 and 18): the scenario or the mod is to be fixed, or the case done
by hand below. M8 and M9 are not automated.

Common setup: a test game in developer mode, the mod active with Biotech and Harmony. The debug menu has a category
**Ancient Chinese Beast** ("Bêtes chinoises antiques" in French): *Beast attack now*, *Nian beast next hour*,
*Clear the sixty-day gate*, *Report the beast clock*. Read `Player.log` with the console key or in the game's folder.
For each test note: green, red, and what was seen.

| # | To do | Expected |
|---|---|---|
| M1 | A crop field and one tree of each kind (anima, Gauranlen, polux among them). Run *Beast attack now* until the mingshe arrives, wait one game hour. | Plants rot every hour while the beast lives; anima, Gauranlen and polux are spared. The drought ends when it dies. (Automated, green.) |
| M2 | A hostile mingshe, a shooter outside its wind ring, a colonist inside the ring. | Shots from outside are thrown back, the colonist inside is cut. (Automated, green.) |
| M3 | A hostile qiongqi facing twenty shots, then two shooters at different distances. | About half of the shots dodged (dodge motes); it flies at the farthest shooter; wounds land on the head more often. (Automated, green.) |
| M4 | A sexie in human form, several colonists of whom one is very psychically sensitive, within eleven tiles. | Colonists in the ring turn on each other at the aura's pace. (Automated, green.) |
| M5 | A nian beast, a colonist shut behind a door. | The beast breaks the enclosure down to reach them. (Automated, green.) |
| M6 | Research tab **Chinese items** ("Objets chinois"); build the extractor, have a corpse carried to it, start the bill. | The tab displays; the bill runs to its end and gives the genes or the clone. (Automated, **red**.) |
| M7 | A colonist with each of three genes: the qiongqi's eye (dodge), the sexie's monstrous strength (doubled unarmed damage), the nian beast's horn (tougher head). | Effects visible in the health tab and the combat log. (Automated for two of the three, **red**; the dodge is in feature 21, green.) |
| M8 | Save, change the language (English to French, then back), reload, send the next beast letter. | The letter is in the new language, in both directions. (Not automated: see `Tests/Pickle/README.md`.) |
| M9 | Add the mod to an existing save; then, on a save that has beasts, remove it. | The save opens in both cases (removing the mod removes the beasts, their genes and the storyteller). (Not automated.) |
