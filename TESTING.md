# Runtime behavior inventory and review contract

Run `pwsh -NoProfile -File Tests/Run-All.ps1` first for automated content, Harmony, override and XML checks. Two XML validators versioned in `Tests/Xml/`, other four run from protocols repository `scripts/` (sibling folder of mod).
Static checks do not execute gameplay. Scenarios below need running game.

## Automation first

This file = behavior inventory from which Pickle companion suite must be written; **not** instruction to make tester set up and play every case by hand. For each applicable scenario, suite must load or create fixture, spawn relevant beast/pawn/corpse/item, apply action through real game path, assert every observable state possible, then save bounded screenshot or film tagged `@review`. Green run proves trajectory and assertions completed; person only opens resulting evidence to judge what image or sound can show.

Some evidence inherently human: whether animation, particle effects, sound, text clipping or translated phrase looks or sounds right. Even then Gherkin scenario must prepare exact moment (e.g. sexie at transformation, qiongqi starting flight, mingshe dying with drought active) and capture it. Manual play = exception for missing automation capability or private pre-existing save; never substitutes for scenario setup. Record exception, reason, exact evidence to inspect in `Tests/Pickle/README.md`.

Evidence stays on disk, out of git. Which proofs of run worth keeping, in what form, how long, is in `docs/runs/README.md`; read before deleting or committing anything run wrote.

Companion suite exists (`Tests/Pickle/`, 23 features, 112 scenarios), played feature by feature since 2026-09-25 (`docs/runs/`); not played as one full run on current tree. Which of 28 cases below each feature plays = table in its README, so are nine manual exceptions (M1 to M9). On 2026-10-01 M1 to M5 automated and green, M6 and M7 automated and red, M8 and M9 neither automated nor played; until every one green or explicitly not applicable with reason, mod cannot be `tested`. Written scenario = automation, not evidence anything passed: evidence = report of run on current tree.

**What `tested` asks for** (`AUDIT.md`, `done -> tested`), and where mod stands 2026-10-01: no scenario tagged `@wip` (holds); every `@requires` scenario has run on current tree (not yet: `13`, `14`, `16` ran on older trees, `17` on current one); no manual test left to validate (not met); Pickle suites green with `exitReason` read first and `@review` captures opened (two of nine do not show subject); logs checked and interface verified in English and French; French review by owner.

28 scenarios, ordered so each leaves save in state next needs. Whole run about an hour when performed manually. Pickle features should instead reload or construct own state, except deliberate documented `@same-world` sequences.

## Passes

`AUDIT.md` names three families of Pickle passes, asks each mod to say here how many needed and what each covers. This mod needs six launches:

| # | Pass | Set | Covers |
| --- | --- | --- | --- |
| 1 | without the optional mods, English | the minimal set: Core, the DLCs, Harmony, RimLogging, Pickle, Biotech, the mod | every feature but `13` and `14`, skipped by requirement |
| 2 | without the optional mods, French | the same set, `-Language French` | the same features, against the French files |
| 3 | with the optional mod | the minimal set plus `ninedaylongbow.ChineseComprehensiveExpansion` (Workshop 3221850511), the one mod `About.xml` names in `loadAfter`, `wsl-deps.cce.map` | `17`: loads after that mod with no conflict (green 1/1, 2026-09-28) |
| 4 | declared incompatibility | the minimal set plus `andery233xj.AncientChineseBeast`, `wsl-deps.incompat-original.map` | `13`, asserts symptom the incompatibility is declared for |
| 5 | with A Dog Said... Animal Prosthetics 2 | the minimal set plus `SamBucher.ADogSaidAnimalProsthetics2` (Workshop 3238353862), `wsl-deps.ads2.map` | `14`, block H below: recipe lists on races, load order |
| 6 | with Nocturnal Animals | the minimal set plus `Mlie.XNDNocturnalAnimals` (Workshop 2269731409), `wsl-deps.nocturnal.map` | `16`, block I below: body clock each race carries |

No pass without DLC (Biotech hard dependency, mod does not load without it), no restart sequence (nothing crosses process boundary). All six passes written. Passes 1 and 2 (every scenario, English then French) never played whole on current tree; passes 3 to 6 each played green once, on trees differing from current except pass 3. Final pass of `tested` claim plays all six, one request each, SHA in `-Label`. Two other optional mods code does not name (Dogs mate, Better Crossbreeding) need no pass: see `STATUS.md`, "The four animal integrations".

**Order of the passes** (`AUDIT.md`, rule of 2026-10-02). What never ran, and what is red, played alone in small tickets (`-Filter` on feature or on `::<scenario title>`), first. Non-regression passes, replaying what already green (whole suite, English then French, optional-mod passes), all queued together at end, on final revision: queued earlier they occupy machine to prove nothing new and are out of date at next commit. Scenario in non-regression as soon as it has green run on current logic; change to mod or to step it uses makes it new again. On 2026-10-08 tree: new or red are aura ring, flying strike, drought wait (all corrected 2026-10-02), French pass of features 18 to 23, French egg scenario; everything else with green run is non-regression, waits for end.

**Not tested, on purpose** (`AUDIT.md`, rule of 2026-10-02): what mod leaves as vanilla or as another mod defines. Nothing of vanilla `Flame`, `Bite`, `BluntBase` or `PawnFlyerBase` damage and flyer defs beasts' own defs inherit from exercised for itself; vanilla egg-laying (`CompEggLayer`), rest, mating exercised only through beasts' own values (feature `15`: ten-day mating, twenty-day gestation, egg defs). Two optional mods played only for what this mod's patches add (passes 5 and 6), not their own behaviour. Not applicable, with reason: behaviour of Animal Prosthetics 2 once recipe exists, and Nocturnal Animals' body clock beyond field this mod sets.

**After the last Pickle ticket** (`AUDIT.md`): mods this mod's sessions downloaded into WSL installation (optional Workshop items of passes 3, 5, 6) removed under machine lock, after listing what goes and stays, keeping any item another mod's `wsl-deps` still names; `STATUS.md` records what removed. Not done yet.

## Manual fallback only

- Development mode on: Options, then Development mode. Most scenarios use it.
- Colony on temperate map, handful of colonists, stockpile. Growing crops matters for scenario 4 only.
- **Keep `Player.log` after session** (`%USERPROFILE%\AppData\LocalLow\Ludeon Studios\RimWorld
  by Ludeon Studios\Player.log`). Red error there = result even when scenario looked fine on screen.
- Expect this mod **only one loaded** beyond Harmony, Biotech, DLCs, for first run at least. Second run inside full modlist worth doing afterwards; any difference between two runs is itself finding.

Every "expected" line below read out of code or defs. Pickle runs of 2026-09-25 showed some happening (`docs/runs/`); **no person yet observed any of it.**

---

## Block A: it loads at all

### A1. The mod loads without errors

1. Start game with mod active.
2. Open log (`~` key, or Development mode then "Open the log").

**Expected.** No red. Nothing saying type not found, nothing about missing field, nothing from Harmony about patch it could not apply. Nine patches apply at startup, in `PatchMain`'s static constructor.

**If fails here, stop.** Everything below assumes assembly loaded.

### A2. The content is in the game

1. Development mode, then debug actions menu (icon with tools).
2. Search `SZ_` in "Spawn thing".

**Expected.** Beasts, firecracker, two rifles, extractor all appear. 127 defs ship; only checking present, not each one.

---

## Block B: the beasts arrive

Incidents have `baseChance` zero: storyteller never rolls them. Fired by mod's own clock (see block F), so only practical way to see one = development menu.

### B1. The qiongqi or the mingshe walks in

1. Debug actions, "Execute incident", pick `SZ_BeastApproach`.

**Expected.** Letter, in mod's own wording, and beast spawned near map edge. Which of two random. No error in log.

> This scenario made code change necessary. Incident worker read chosen beast from field only mod's own clock ever set, so firing from this menu threw null reference before anything spawned. Now picks one from incident's own list when field empty. If you see beast, fix works.

### B2. The sexie digs up through the floor

1. Build or find room with some wealth. Spawner picks **richest room on map**.
2. Debug actions, "Execute incident", `SZ_BeastApproachTunnel`.

**Expected.** Tunnel appears **inside that room**, not at map edge, and after usual tunnel delay sexie comes out. Check it chose expected room: ordering is `RegionGrid.AllRooms` sorted by wealth, and `AllRooms` is one of members 1.6 changed.

### B3. The nian beast comes on New Year

1. Debug actions, category **Ancient Chinese Beast**, then **Nian beast next hour**.
2. Let an hour of game time pass.

**Expected.** Message saying so, then nian beast incident fires within hour, whatever date.

> Original put this on `ThingComp` on firecracker: had to spawn one, drop it, select it to see three buttons labelled in Chinese, of which **two did nothing at all** - added to counter no code reads. Comp gone, four entries below replaced it.

### B4. The development entries do what they say

All four under **Ancient Chinese Beast** in debug actions menu.

| entry | expected |
|---|---|
| **Beast attack now** | one of four beasts arrives immediately, by whichever of two incidents suits it |
| **Nian beast next hour** | scenario B3 |
| **Clear the sixty-day gate** | message; no beast yet. Only lifts interval, leaving 1% daily roll to fire on own, which makes F1 testable in an evening |
| **Report the beast clock** | line in log giving tick, ticks since last beast, storyteller and its schedule, beast currently chosen, how many kinds of corpse held |

**Run "Report the beast clock" before and after each of other three.** Only window onto scheduling state, and every claim in block F is claim about that state.

---

## Block C: each beast fights its own way

Spawn beasts directly (debug "Spawn pawn"), rather than waiting for incidents. Use throwaway save: several meant to kill colonists.

### C1. The mingshe brings a drought and does not attack

1. Spawn `SZ_MingShe` on map with grown crop field.
2. Watch it for in-game hour.

**Expected.**
- Permanent game condition appears in top-right bar, weather turns clear sun.
- **Beast does not attack.** Moves, defends itself, does not hunt colonists.
- Every plant on map takes damage each in-game hour, eventually dies.
- **Anima trees, Gauranlen trees, polux trees spared.** Plant one of each first if possible; exception list in code and list is exactly what rots.

### C2. The mingshe's wind shield throws shots back

1. With mingshe alive, shoot at it from more than ten tiles away, repeatedly.
2. Wait for it to raise shield: visible ring about ten tiles across.

**Expected.** While ring up, shot fired **from outside it** thrown back at whoever fired. Anything **inside** ring is cut. Try both: colonist inside ring and colonist outside shooting in.

### C3. The mingshe's drought ends when it dies

1. Kill mingshe.

**Expected.** Condition disappears from bar, weather free to change again.

> Worth care. Hook ending condition is one of two that silently stopped overriding anything on 1.6. If drought outlives beast, that is bug back.

### C4. A tame mingshe does not crash

1. Development mode, spawn `SZ_MingShe_Friendly` as player-faction pawn.
2. Let it live an hour, then kill it.

**Expected.** No error either way, no drought: condition only created for beast not yours. Original threw null reference here, because created condition conditionally and ended it unconditionally.

### C5. The qiongqi dodges, picks the far shooter, and flies

1. Spawn `SZ_QiongQi`. Put two colonists with ranged weapons at different distances.

**Expected.**
- Roughly **half** of shots aimed at it miss with "dodge" text mote. Fire twenty, count.
- Goes for **furthest shooter it can see**, not nearest target.
- To close distance it **flies**: animation spawns, leaves ground, lands cutting everything within four tiles.
- Wounds land on head more often than chance gives.

> Flight is other thing 1.6 broke. If qiongqi rises then hangs in air over target without landing, flyer not being ticked.

### C6. The sexie changes shape

1. Spawn `SZ_SeXie` - human-shaped one.

**Expected.**
- **Does not attack.** Stands there.
- Every so often sends out aura, about eleven tiles across, driving psychically sensitive colonists inside berserk against own side. Colonist with high psychic sensitivity makes this easier to see.
- **Kill it, and scorpion (`SZ_SeXieInsect`) comes out of corpse**, angrier: fires venomous tail-needles **through walls**, uses pincers up close.

> Shape change is first of two overrides 1.6 silenced. If human form simply dies and nothing comes out, that is bug back, and single most important line in this file.

### C7. The nian beast is only hurt by firecrackers

1. Spawn `SZ_YearBeast`.
2. Shoot with ordinary weapon, watch damage numbers.
3. Craft or spawn firecrackers, throw at it.

**Expected.** Everything not firecracker does **a tenth** of its damage. Firecracker does **a thousand times** its damage. Together why firecrackers only weapon that matters here.

**Also.** Breathes cone of fire spawning wave of small flame projectiles, and breaks door down to reach someone indoors.

### C8. Butchering a nian beast gives meat, and only meat

1. Butcher corpse at butcher table.

**Expected.** Meat, nothing else: race carries no butcher product, original mod's promise of "nian beast fangs" taken out of descriptions. Seen in game 2026-09-25: 2800 units of meat.

---

## Block D: the chicken

### D1. The Pleiades star officer wanders past and can be tamed

1. Debug actions, "Execute incident", `SZ_ChickenPasses`.
2. Tame it.

**Expected.** Letter, and bird tameable like any animal.

### D2. Its crow lifts the colony and kills a sexie

1. With tamed bird on map, select it, use crow ability by hand.

**Expected.**
- Sound plays.
- **Every colonist and every allied pawn on map** gains "heartened by the Pleiades star officer", **+20 mood for one day**. Check an ally too, not only own colonists.
- If sexie or sexie scorpion on map, **one of them dies outright**. Put two on map, check exactly one dies.

### D3. It crows on its own at four in the morning

1. Leave bird on map, let clock reach 04:00.

**Expected.** Same thing happens without being asked.

---

## Block E: genes, cloning and the bench

### E1. The research is where it says it is

1. Open research tab.

**Expected.** Tab called **Chinese items**, holding **beast gene extraction**: 1000 points, spacer tech, needing **hi-tech research bench** and **multi-analyzer**, after **Archogenetics**.

### E2. The extractor can be built and takes a corpse

1. Finish research (debug: finish instantly).
2. Build **beast gene extractor**.
3. Bring beast corpse to it - keep one from block C, or spawn `Corpse_SZ_QiongQi`.

**Expected.** Bench offers its recipes, colonist hauls corpse and works on it.

### E3. Each of the twelve genes comes out as a genepack

1. Run extraction recipes, one per gene.

**Expected.** Twelve distinct genes across four beasts, each arriving **as genepack**, not loose gene:

| beast | genes |
|---|---|
| mingshe | wind shield, sound wave, fangs |
| qiongqi | flying strike, eye, claws |
| sexie | crystal spurs, heart-butchering aura, monstrous strength |
| nian beast | fire breath, scales, horn |

Recipe producing them is vanilla one with postfix, so genepack arriving empty, or wrong gene, points at that patch.

### E4. The genes work on a colonist

Implant them, check three measurable rather than cosmetic:

- **qiongqi's eye**: colonist dodges about half of incoming shots, same text mote beast gets.
- **monstrous strength**: unarmed melee damage **doubled**. Label used to claim it weakened enemies, opposite of what it does; check description reads right way round.
- **nian beast's horn**: extra head health. Look at head's hit points on health tab.

### E5. A clone comes out alive and on your side

1. Run clone recipe on corpse.

**Expected.** Tame beast of that kind, **in your faction**, same abilities as wild one, and AI using its ranged ability while fighting in melee. Check description is its own: English used to reuse hostile beast's text, so tame beast described itself as raider.

### E6. A corpse renders into archite capsules

1. Run "extract archite capsules" on any beast corpse.

**Expected.** **Ten** archite capsules.

---

## Block F: the schedule, which needs patience or a save editor

Slowest and least certain. Do last, or not at all on first pass.

### F1. Under an ordinary storyteller the beasts are rare

Code rolls **once a game day**, at **1%**, refuses if **less than sixty days** passed since last beast. First unlikely before roughly day 160.

**How to test without waiting.** Let colony run at high speed few in-game years, count beasts. Number should be small, gaps never shorter than sixty days.

> Beasts' own descriptions say they come "a year after the colony is established". Authors' flavour text; schedule above is what code does. Do not treat description as expected result.

### F2. Under Sexie the beasts come every fifteen days

1. Start colony with storyteller **Sexie, the Venomous Mist**.
2. Run past day 1, then watch.

**Expected.** Beast every fifteen days, on top of whatever she sends otherwise, independent of 1% roll above.

### F3. The nian beast comes on the first day of the year

**Expected.** At first hour of day 0 of year, whatever storyteller, without any roll. Scenario B3 is shortcut; this is real thing, worth one confirmation.

---

## Block G: the save

### G1. The mod's own state survives a save and reload

1. Get beast to arrive, then save, quit to menu, reload.

**Expected.** Chosen beast, clock's last-beast time, corpse list all come back. Saved through patch on `Game.ExposeSmallComponents`. Beast forgetting which beast it is after reload, or drought returning without causer, = failure here.

### G2. Adding and removing mid-save

1. Add mod to existing save: should load with no error.
2. Remove it from save with beasts in it: beasts, genes, storyteller, extractor go, save should still open.

---

## Block H: A Dog Said... Animal Prosthetics 2 (optional)

### H1. The tame clones and the chicken get its prosthetics, the hostile beasts do not

1. Load mod with `SamBucher.ADogSaidAnimalProsthetics2` after it.
2. Open tame `SZ_YearBeast_Friendly` in Health tab, add bill.

**Expected.** Operations menu offers wooden, simple, bionic replacements fitting parts beast has. Pleiades star officer offered wooden and simple, no bionic. Hostile beast has no such recipe on race. Without other mod, nothing in this block exists, log stays clean.

> Scenario `14` plays recipe lists and load order; which operation tab offers for which body part is other mod's own logic, not asserted.

---

## Block I: the beasts rest and breed (from 2026-09-25)

### I1. A tired tame beast lies down; a hostile one has the need

1. Tame beast (or spawn tame clone), lower rest need in development mode, watch.

**Expected.** Lies down where it stands, gets up when rested. Hostile beasts have rest need too (lie down between hunts). With Nocturnal Animals, sleeping hours follow its clock: qiongqi and sexie up at night, star officer awake at four in morning and crows.

### I2. A tame pair breeds

1. Clone two of same beast (recipe draws sex at random: clone until pair), keep together.
2. Wait, or use development tools to bring on mating.

**Expected.** Pregnancy in female (**fertilised egg** in mingshe and star officer), **baby** at term, then juvenile, then adult, same textures at smaller size; young in your faction. Clone saved before this version has no sex, cannot breed.

### I3. Nocturnal Animals (optional)

**Expected.** Without other mod, nothing in log and vanilla clock. With it, each race carries clock of patch (`Patches/NocturnalAnimals.xml`) on info card.

> Scenarios `15` and `16` play wiring of all three: need, Mate job, pregnancy, egg and hatching, extension on each race. Real hours of sleep, real gestations, look of young stay for person.

---

## Translation checks

Apply while running 28 scenarios in **English and French**. Static coverage passes as of 2026-09-13, but none of these display checks performed in game.

- During blocks A, C, D, E, inspect beasts in both forms, friendly clones, anatomy, melee tools, weapons, firecrackers, abilities, genes, research, extractor and recipe bills. Check labels, descriptions, tooltips, current job reports. Include generated corpse, meat, crafting recipe names, and generated xenotype using beast gene-name symbols.
- During blocks B and C, read every arrival letter, drought notification, chicken's mood thought, combat reports. Trigger qiongqi dodge, verify `Dodge` / `Esquive`. Rich-text markers and `{0}` parameters must render, no raw keys or English/Chinese fallback in French. Chinese proper names transliterated as `mingshe` and `qiongqi` intended.
- During block F, check category `Ancient Chinese Beast` / `Bêtes chinoises antiques`, all four development actions and three notification messages. Technical log entries deliberately remain English. Check action labels again after changing language.
- During block G, save after beast selected, change language, reload, trigger matching arrival incident. Newly sent letter must use new language and still describe selected beast. Repeat other direction and, if available, with save from before this translation update. Existing historical letters keep saved wording.

Look for clipped buttons/tooltips and malformed line breaks as well as incorrect words.
Record each language, game version, outcome, any screenshot/log evidence in `STATUS.md`.
Keep runtime entry in `remaining` until both languages checked.

## What to send back

For each manual exception: scenario number, why Pickle could not cover it, **seen** or **not seen**, plus what happened instead. Scenario that could not be reached matters as much as one that failed, so does log.

Three deciding whether port worked, if time for only three: **C6** (sexie changes shape), **C5** (qiongqi lands flight), **C3** (drought ends with beast). Those are three hooks 1.6 broke.