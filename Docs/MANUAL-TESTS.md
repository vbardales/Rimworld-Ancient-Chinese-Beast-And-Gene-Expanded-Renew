# Manual tests M1 to M9

What Pickle suite not play alone. Reason for each in `Tests/Pickle/README.md`, "The manual
exceptions", which also holds their state. `tested` wait for every one green, or listed as not
applicable with reason (`AUDIT.md`, `done -> tested`). Owner do ones that stay manual.

Rewritten in English on 2026-10-01 (file was French: everything repository holds is English,
`PUBLISHING.md`, "Dépôt").

**Where each stands on 2026-10-01.** M1 to M5 automated, green (features 04, 20, 21, 22): nothing to do by
hand. M6 and M7 automated, red (features 19 and 18): fix scenario or mod, or do case by hand below. M8 and M9 not automated.

Common setup: test game in developer mode, mod active with Biotech and Harmony. Debug menu has category
**Ancient Chinese Beast** ("Bêtes chinoises antiques" in French): *Beast attack now*, *Nian beast next hour*,
*Clear the sixty-day gate*, *Report the beast clock*. Read `Player.log` with console key or in game folder.
For each test note: green, red, what seen.

| # | To do | Expected |
|---|---|---|
| M1 | Crop field and one tree of each kind (anima, Gauranlen, polux among them). Run *Beast attack now* until mingshe arrives, wait one game hour. | Plants rot every hour while beast lives; anima, Gauranlen, polux spared. Drought ends when it dies. (Automated, green.) |
| M2 | Hostile mingshe, shooter outside its wind ring, colonist inside ring. | Shots from outside thrown back, colonist inside cut. (Automated, green.) |
| M3 | Hostile qiongqi facing twenty shots, then two shooters at different distances. | About half shots dodged (dodge motes); flies at farthest shooter; wounds land on head more often. (Automated, green.) |
| M4 | Sexie in human form, several colonists, one very psychically sensitive, within eleven tiles. | Colonists in ring turn on each other at aura's pace. (Automated, green.) |
| M5 | Nian beast, colonist shut behind door. | Beast breaks enclosure down to reach them. (Automated, green.) |
| M6 | Research tab **Chinese items** ("Objets chinois"); build extractor, have corpse carried to it, start bill. | Tab displays; bill runs to end, gives genes or clone. (Automated, **red**.) |
| M7 | Colonist with each of three genes: qiongqi's eye (dodge), sexie's monstrous strength (doubled unarmed damage), nian beast's horn (tougher head). | Effects visible in health tab and combat log. (Automated for two of three, **red**; dodge in feature 21, green.) |
| M8 | Save, change language (English to French, then back), reload, send next beast letter. | Letter in new language, both directions. (Automated for what mod owns, feature 23, written 2026-10-01, not yet played.) |
| M9 | Add mod to existing save; then, on save that has beasts, remove it. | Save opens in both cases. **Adding** needs no own test: any basic scenario already loads mod into game that never had it (owner, 2026-10-09). **Removing** automated by `-Then` / `-ThenWithout nelim.ancientchinesebeastandgeneexpanded` request: save with beasts, reload without mod (written after queue empty, see `Tests/Pickle/README.md`). |