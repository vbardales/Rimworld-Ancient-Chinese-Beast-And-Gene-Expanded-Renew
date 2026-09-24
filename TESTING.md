# Runtime behavior inventory and review contract

Run `pwsh -NoProfile -File Tests/Run-All.ps1` first for the automated content, Harmony, override
and XML checks. The six XML validators are versioned in `Tests/Xml/`; no monorepo is needed.
These static checks do not execute gameplay. The following scenarios require a running game.

## Automation first

This file is the behavior inventory from which the Pickle companion suite must be written; it is
**not** an instruction to make a tester set up and play every case by hand. For each applicable
scenario, the suite must load or create its fixture, spawn the relevant beast/pawn/corpse/item,
apply the action through the real game path, assert every observable state it can, and then save a
bounded screenshot or film tagged `@review`. A green run proves that the trajectory and its
assertions completed; a person only opens the resulting evidence to judge what an image or sound
can show.

Some evidence remains inherently human: whether animation, particle effects, a sound, text
clipping or a translated phrase looks or sounds right. Even then the Gherkin scenario must still
prepare the exact moment — for example a sexie at its transformation, a qiongqi starting its
flight, or a mingshe dying with drought active — and capture it. Manual play is an exception for a
missing automation capability or a private pre-existing save; it never substitutes for scenario
setup. Record the exception, its reason and the exact evidence to inspect in `Tests/Pickle/README.md`.

Evidence stays on disk and out of git. Which proofs of a run are worth keeping, in what form and for
how long, is in `docs/runs/README.md`; read it before deleting or committing anything a run wrote.

The companion suite has not yet been created. Until it exists, the 28 cases below are **planned
automation coverage**, not completed manual testing and not evidence for `done`.

28 scenarios, ordered so that each one leaves the save in the state the next one needs. The
whole run is about an hour when performed manually. Pickle features should instead reload or
construct their own state, except for deliberate documented `@same-world` sequences.

## Manual fallback only

- Development mode on: Options, then Development mode. Most scenarios use it.
- A colony on a temperate map, a handful of colonists, and a stockpile. Growing crops matters for
  scenario 4 and nothing else.
- **Keep `Player.log` after the session** (`%USERPROFILE%\AppData\LocalLow\Ludeon Studios\RimWorld
  by Ludeon Studios\Player.log`). A red error there is a result even when the scenario looked fine
  on screen.
- Expect this mod to be **the only one loaded** beyond Harmony, Biotech and the DLCs, for the first
  run at least. A second run inside the full modlist is worth doing afterwards, and any difference
  between the two runs is itself the finding.

Every "expected" line below is read out of the code or the defs, not from having seen it happen.
That is the point of the exercise: **nothing in this file has ever been observed.**

---

## Block A — it loads at all

### A1. The mod loads without errors

1. Start the game with the mod active.
2. Open the log (`~` key, or Development mode then "Open the log").

**Expected.** No red. In particular, nothing saying a type could not be found, nothing about a
missing field, and nothing from Harmony about a patch it could not apply. The nine patches apply at
startup, in `PatchMain`'s static constructor.

**If it fails here, stop.** Everything below assumes the assembly loaded.

### A2. The content is in the game

1. Development mode, then the debug actions menu (the icon with the tools).
2. Search for `SZ_` in "Spawn thing".

**Expected.** The beasts, the firecracker, the two rifles and the extractor all appear. 127 defs
ship; you are only checking that they are present, not each one.

---

## Block B — the beasts arrive

The incidents have `baseChance` zero: the storyteller never rolls them. They are fired by the mod's
own clock (see block F), so the only practical way to see one is the development menu.

### B1. The qiongqi or the mingshe walks in

1. Debug actions, "Execute incident", pick `SZ_BeastApproach`.

**Expected.** A letter, in the mod's own wording, and a beast spawned near a map edge. Which of the
two you get is random. No error in the log.

> This is the scenario that made a code change necessary. The incident worker read the chosen beast
> out of a field that only the mod's own clock ever set, so firing it from this menu threw a null
> reference before anything spawned. It now picks one from the incident's own list when the field is
> empty. If you see a beast, that fix works.

### B2. The sexie digs up through the floor

1. Build or find a room with some wealth in it. The spawner picks **the richest room on the map**.
2. Debug actions, "Execute incident", `SZ_BeastApproachTunnel`.

**Expected.** A tunnel appears **inside that room**, not at a map edge, and after the usual
tunnel delay a sexie comes out of it. Check it chose the room you expected: that ordering is
`RegionGrid.AllRooms` sorted by wealth, and `AllRooms` is one of the members 1.6 changed.

### B3. The nian beast comes on New Year

1. Debug actions, category **Ancient Chinese Beast**, then **Nian beast next hour**.
2. Let an hour of game time pass.

**Expected.** A message saying so, then the nian beast incident fires within the hour, whatever the
date.

> The original put this on a `ThingComp` on the firecracker: you had to spawn one, drop it and
> select it to see three buttons labelled in Chinese, of which **two did nothing at all** - they
> added to a counter no code reads. The comp is gone and the four entries below replaced it.

### B4. The development entries do what they say

All four are under **Ancient Chinese Beast** in the debug actions menu.

| entry | expected |
|---|---|
| **Beast attack now** | one of the four beasts arrives immediately, by whichever of the two incidents suits it |
| **Nian beast next hour** | scenario B3 |
| **Clear the sixty-day gate** | a message; no beast yet. It only lifts the interval, leaving the 1% daily roll to fire on its own, which is what makes F1 testable in an evening |
| **Report the beast clock** | a line in the log giving the tick, the ticks since the last beast, the storyteller and its schedule, the beast currently chosen, and how many kinds of corpse are held |

**Run "Report the beast clock" before and after each of the other three.** It is the only window
onto the scheduling state, and every claim in block F is a claim about that state.

---

## Block C — each beast fights its own way

Spawn the beasts directly for these (debug "Spawn pawn"), rather than waiting for incidents. Use a
throwaway save: several of these are meant to kill colonists.

### C1. The mingshe brings a drought and does not attack

1. Spawn `SZ_MingShe` on a map with a grown crop field.
2. Watch it for an in-game hour.

**Expected.**
- A permanent game condition appears in the top-right bar, and the weather turns to clear sun.
- **The beast does not attack.** It moves, it defends itself, it does not hunt colonists.
- Every plant on the map takes damage each in-game hour, and eventually dies.
- **Anima trees, Gauranlen trees and polux trees are spared.** Plant one of each first if you can;
  this is an exception list in the code and a list is exactly what rots.

### C2. The mingshe's wind shield throws shots back

1. With the mingshe alive, shoot at it from more than ten tiles away, repeatedly.
2. Wait for it to raise the shield: a visible ring about ten tiles across.

**Expected.** While the ring is up, a shot fired **from outside it** is thrown back at whoever
fired it. Anything standing **inside** the ring is cut. Try both: a colonist inside the ring and a
colonist outside shooting in.

### C3. The mingshe's drought ends when it dies

1. Kill the mingshe.

**Expected.** The condition disappears from the bar and the weather is free to change again.

> This one is worth care. The hook that ends the condition is one of the two that had silently
> stopped overriding anything on 1.6. If the drought outlives the beast, that is the bug back.

### C4. A tame mingshe does not crash

1. Development mode, spawn `SZ_MingShe_Friendly` as a player-faction pawn.
2. Let it live an hour, then kill it.

**Expected.** No error either way, and no drought: the condition is only created for a beast that
is not yours. The original threw a null reference here, because it created the condition
conditionally and ended it unconditionally.

### C5. The qiongqi dodges, picks the far shooter, and flies

1. Spawn `SZ_QiongQi`. Put two colonists with ranged weapons at different distances.

**Expected.**
- Roughly **half** of the shots aimed at it miss with a "dodge" text mote. Fire twenty and count.
- It goes for **the furthest shooter it can see**, not the nearest target.
- To close the distance it **flies**: an animation spawns, it leaves the ground, and it lands
  cutting everything within four tiles.
- Wounds land on the head more often than chance would give.

> The flight is the other thing 1.6 broke. If the qiongqi rises and then hangs in the air over its
> target without ever landing, the flyer is not being ticked.

### C6. The sexie changes shape

1. Spawn `SZ_SeXie` - the human-shaped one.

**Expected.**
- **It does not attack.** It stands there.
- Every so often it sends out an aura, about eleven tiles across, that drives the psychically
  sensitive colonists inside it berserk against their own side. A colonist with high psychic
  sensitivity makes this easier to see.
- **Kill it, and a scorpion (`SZ_SeXieInsect`) comes out of the corpse**, angrier: it fires
  venomous tail-needles **through walls** and uses pincers up close.

> The shape change is the first of the two overrides 1.6 silenced. If the human form simply dies
> and nothing comes out, that is the bug back, and it is the single most important line in this
> file.

### C7. The nian beast is only hurt by firecrackers

1. Spawn `SZ_YearBeast`.
2. Shoot it with an ordinary weapon and watch the damage numbers.
3. Craft or spawn firecrackers and throw them at it.

**Expected.** Everything that is not a firecracker does **a tenth** of its damage. A firecracker
does **a thousand times** its damage. The two together are why firecrackers are the only weapon
that matters here.

**Also.** It breathes a cone of fire that spawns a wave of small flame projectiles, and it will
break a door down to reach someone indoors.

### C8. Butchering a nian beast gives fangs

1. Butcher the corpse at a butcher table.

**Expected.** Nian beast fangs among the products.

---

## Block D — the chicken

### D1. The Pleiades star officer wanders past and can be tamed

1. Debug actions, "Execute incident", `SZ_ChickenPasses`.
2. Tame it.

**Expected.** A letter, and a bird you can tame like any animal.

### D2. Its crow lifts the colony and kills a sexie

1. With the tamed bird on the map, select it and use its crow ability by hand.

**Expected.**
- A sound plays.
- **Every colonist and every allied pawn on the map** gains "heartened by the Pleiades star
  officer", **+20 mood for one day**. Check an ally too, not only your own colonists.
- If a sexie or a sexie scorpion is on the map, **one of them dies outright**. Put two on the map
  and check exactly one dies.

### D3. It crows on its own at four in the morning

1. Leave the bird on the map and let the clock reach 04:00.

**Expected.** The same thing happens without being asked.

---

## Block E — genes, cloning and the bench

### E1. The research is where it says it is

1. Open the research tab.

**Expected.** A tab called **Chinese items**, holding **beast gene extraction**: 1000 points,
spacer tech, needing a **hi-tech research bench** and a **multi-analyzer**, after **Archogenetics**.

### E2. The extractor can be built and takes a corpse

1. Finish the research (debug: finish it instantly).
2. Build the **beast gene extractor**.
3. Bring a beast corpse to it - keep one from block C, or spawn `Corpse_SZ_QiongQi`.

**Expected.** The bench offers its recipes, and a colonist hauls the corpse and works on it.

### E3. Each of the twelve genes comes out as a genepack

1. Run the extraction recipes, one per gene.

**Expected.** Twelve distinct genes across four beasts, each arriving **as a genepack**, not as a
loose gene:

| beast | genes |
|---|---|
| mingshe | wind shield, sound wave, fangs |
| qiongqi | flying strike, eye, claws |
| sexie | crystal spurs, heart-butchering aura, monstrous strength |
| nian beast | fire breath, scales, horn |

The recipe that produces them is a vanilla one with a postfix on it, so a genepack arriving with
nothing in it, or a wrong gene, points at that patch.

### E4. The genes work on a colonist

Implant them and check the three that are measurable rather than cosmetic:

- **the qiongqi's eye**: the colonist dodges about half of incoming shots, with the same text mote
  the beast gets.
- **monstrous strength**: unarmed melee damage **doubled**. The label used to claim it weakened
  enemies, which is the opposite of what it does; check the description reads the right way round.
- **the nian beast's horn**: extra head health. Look at the head's hit points on the health tab.

### E5. A clone comes out alive and on your side

1. Run a clone recipe on a corpse.

**Expected.** A tame beast of that kind, **in your faction**, with the same abilities as the wild
one, and an AI that uses its ranged ability while fighting in melee. Check its description is its
own: the English used to reuse the hostile beast's text, so a tame beast described itself as a
raider.

### E6. A corpse renders into archite capsules

1. Run "extract archite capsules" on any beast corpse.

**Expected.** **Ten** archite capsules.

---

## Block F — the schedule, which needs patience or a save editor

These are the slowest and the least certain. Do them last, or not at all on a first pass.

### F1. Under an ordinary storyteller the beasts are rare

The code rolls **once a game day**, at **1%**, and refuses if **less than sixty days** have passed
since the last beast. So the first one is unlikely before roughly day 160.

**How to test it without waiting.** Let a colony run at high speed for a few in-game years and
count the beasts. The number should be small and the gaps never shorter than sixty days.

> The beasts' own descriptions say they come "a year after the colony is established". That is the
> authors' flavour text; the schedule above is what the code does. Do not treat the description as
> the expected result.

### F2. Under Sexie the beasts come every fifteen days

1. Start a colony with the storyteller **Sexie, the Venomous Mist**.
2. Run past day 1, then watch.

**Expected.** A beast every fifteen days, on top of whatever she sends otherwise, and independent
of the 1% roll above.

### F3. The nian beast comes on the first day of the year

**Expected.** At the first hour of day 0 of the year, whatever the storyteller, without any roll.
Scenario B3 is the shortcut; this is the real thing, and worth one confirmation.

---

## Block G — the save

### G1. The mod's own state survives a save and reload

1. Get a beast to arrive, then save, quit to the menu, and reload.

**Expected.** The chosen beast, the clock's last-beast time and the corpse list all come back. They
are saved through a patch on `Game.ExposeSmallComponents`. A beast that forgets which beast it is
after a reload, or a drought that comes back without its causer, is a failure here.

### G2. Adding and removing mid-save

1. Add the mod to an existing save: it should load with no error.
2. Remove it from a save that has beasts in it: the beasts, their genes, the storyteller and the
   extractor go, and the save should still open.

---

## Translation checks

Apply these checks while running the 28 scenarios in **English and French**. Static coverage
passes as of 2026-09-13, but none of these display checks has been performed in game.

- During blocks A, C, D and E, inspect beasts in both forms, friendly clones, anatomy, melee
  tools, weapons, firecrackers, abilities, genes, research, the extractor and its recipe bills.
  Check labels, descriptions, tooltips and current job reports. Include generated corpse,
  meat and crafting recipe names, and a generated xenotype using the beast gene-name symbols.
- During blocks B and C, read every arrival letter, the drought notification, the chicken's
  mood thought and combat reports. Trigger a qiongqi dodge and verify `Dodge` / `Esquive`.
  Rich-text markers and `{0}` parameters must be rendered, with no raw keys or English/Chinese
  fallback in French. Chinese proper names transliterated as `mingshe` and `qiongqi` are intended.
- During block F, check the category `Ancient Chinese Beast` / `Bêtes chinoises antiques`,
  all four development actions and their three notification messages. Technical log entries
  deliberately remain English. Check the action labels again after changing language.
- During block G, save after a beast has been selected, change language, reload and trigger
  its matching arrival incident. The newly sent letter must use the new language and still
  describe the selected beast. Repeat in the other direction and, if available, with a save
  from before this translation update. Existing historical letters keep their saved wording.

Look for clipped buttons/tooltips and malformed line breaks as well as incorrect words.
Record each language, game version, outcome and any screenshot/log evidence in `STATUS.md`.
Keep the runtime entry in `remaining` until both languages have been checked.

## What to send back

For each manual exception: its scenario number, why Pickle could not cover it, and **seen** or
**not seen**, plus what happened instead. A scenario that could not be reached matters as much as
one that failed, and so does the log.

The three that decide whether the port worked, if there is only time for three: **C6** (the sexie
changes shape), **C5** (the qiongqi lands its flight) and **C3** (the drought ends with its beast).
Those are the three hooks 1.6 broke.
