# In-game scenarios, run by Pickle

This companion is development-only and is never distributed in `Mod/`. It converts the behaviors of
`TESTING.md` into self-staging scenarios: each one loads or builds its own state, acts through the real game
path, asserts what can be asserted, and where a picture is the only honest evidence takes a bounded `@review`
capture for a person to open. **It has never been run.** Every number below is a count of what was written.

## Present coverage

Thirteen features, 52 scenarios once the outlines are expanded (51 in a minimal pass; the last is skipped by
requirement there).

| Feature | Scenarios | What it settles | `@review` capture |
|---|---|---|---|
| `01-loads` | 1 | the mod, Harmony and Biotech load in order; the principal defs exist; no warning from the mod, no error | none |
| `02-beast-review` | 1 | the four beasts and the chicken render together on a clean map | one |
| `03-save-reload` | 1 | four hostile beasts survive a real save and reload | none |
| `04-critical-hooks` | 3 | the three hooks 1.6 silenced: the drought ends with its mingshe, the human sexie leaves its scorpion, the qiongqi lands its flight | two |
| `05-incidents` | 2 | the ordinary-beast incident and the chicken's incident fire and spawn | one |
| `06-chicken-crow` | 4 | the crow kills a staged sexie, lifts a colonist's mood by twenty, kills exactly one of two sexies, and the bird crows by itself at four | one |
| `07-debug-actions` | 1 | the nian action sets the flag the scheduler reads | none |
| `08-recipes` | 2 | one extraction and one clone, through the real recipe hook | two |
| `09-nian-and-firecracker` | 7 | ordinary blow a tenth, firecracker damage a hundred times, a real explosion wounds the beast, the fire breath reaches its target, butchery, the firecracker chain starts and stops | one |
| `10-scheduler` | 9 | the nian beast at the debug flag and at the first hour of the year (and not at hour 5, nor on day 10), Sexie's 900000-tick beast, the gate and the daily roll under a seed that wins, every development action in the language of the run | none |
| `11-tunnel` | 1 | the sexie's tunnel opens in the richest room and the sexie comes out | one |
| `12-recipes-and-clones` | 19 | all twelve gene recipes, all five clones, the archite capsules, and a tame mingshe that dies without a drought or an error | none |
| `13-original-mod-incompatibility` | 1 | with the original mod staged, both define the same beast and the game keeps one copy (`@requires:andery233xj.AncientChineseBeast`) | none |

Nine captures in all. `docs/runs/README.md` says which to keep and how small.

### Where each of the 28 scenarios of `TESTING.md` is played

| `TESTING.md` | Played by | Left to a person, and why |
|---|---|---|
| A1, A2 | `01` | the 127 defs are counted offline; the run checks the principal ones |
| B1, B2 | `05`, `11` | |
| B3, B4 | `07`, `10` | |
| C1 | `04` (the drought starts and ends) | M1 |
| C2 | | M2 |
| C3 | `04` | |
| C4 | `12` | |
| C5 | `04` (the flight lands) | M3 |
| C6 | `04` (the shape changes) | M4 |
| C7 | `09` | M5 |
| C8 | `09` | the fangs, see below |
| D1, D2, D3 | `05`, `06` | |
| E1, E2 | | M6 |
| E3, E5, E6 | `12` (all of them), `08` (with a picture) | |
| E4 | | M7 |
| F1, F2, F3 | `10` | F1's rarity over years is the product of the two things `10` plays: the gate and the roll |
| G1 | `03` | M8 |
| G2 | | M9 |

### The manual exceptions

Manual play is an exception for a capability the suite does not have, and each one is recorded here with the
evidence to inspect. **They are manual tests to validate: `tested` waits for every one of them to be green.**

| | `TESTING.md` | Why Pickle does not play it | What to inspect |
|---|---|---|---|
| M1 | C1 | plants rot hourly for as long as the beast lives, and the sparing of anima, Gauranlen and polux trees is an exception list; watching it is hours of game time | a crop field and one tree of each kind, an hour after the mingshe arrives |
| M2 | C2 | the wind shield reflects shots fired from outside and cuts what stands inside; it needs a shooter, a ring and time | shots from outside thrown back, a pawn inside cut |
| M3 | C5 | the dodge is a probability, "the furthest shooter" is an AI choice, and the head bias is a distribution | twenty shots and the dodge motes; which of two shooters it flies at; where the wounds land |
| M4 | C6 | the aura's berserk needs psychically sensitive colonists and the ring's cadence | colonists inside eleven tiles turning on each other |
| M5 | C7 | the nian AI breaking a door down to reach a colonist indoors | a door, a colonist behind it |
| M6 | E1, E2 | the research tab is a picture, and building the bench and having a colonist haul a corpse to it is a job chain | the tab **Chinese items**; a bill worked to its end |
| M7 | E4 | the three genes' effects on a colonist: dodge, doubled unarmed damage, extra head health | the health tab and the combat log |
| M8 | G1 (part) | changing language on a saved game and sending the next letter: a language cannot be switched inside a scenario | the letter after the switch, in both directions |
| M9 | G2 | adding the mod to an existing save and removing it from one that has beasts needs a different mod set between two launches | the save opens, with and without |

### One finding the suite is written to settle

The nian beast's description, this repository's README and `TESTING.md` say butchering it yields **nian beast
fangs**. No item def of that name ships with the mod, and the beast's race carries no butcher product. The
butchery scenario in `09` asserts meat and writes **every product it yields** into the report, so the first run
answers whether the fangs exist (perhaps supplied by `ninedaylongbow.ChineseComprehensiveExpansion`, which the
mod only loads after) or are text the port inherited. Until then it is recorded as unverified in `STATUS.md`.

## Passes

There is no DLC-absent pass: Biotech is a hard dependency, so the mod does not load without it. About.xml does
name one optional mod, in `loadAfter`: `ninedaylongbow.ChineseComprehensiveExpansion`. A pass with it is owed
(`AUDIT.md`: a pass with the optional mods) and is **not written**, because its Workshop id has not been looked
up; `TESTING.md`, "Passes", lists it as pass 3. The three passes below are written, and each is a separate
launch of the shared runner.

```powershell
powershell.exe -ExecutionPolicy Bypass -File scripts/Run-PickleWsl.ps1 -Mod AncientChineseBeastAndGeneExpandedRenew -Language English
powershell.exe -ExecutionPolicy Bypass -File scripts/Run-PickleWsl.ps1 -Mod AncientChineseBeastAndGeneExpandedRenew -Language French
powershell.exe -ExecutionPolicy Bypass -File scripts/Run-PickleWsl.ps1 -Mod AncientChineseBeastAndGeneExpandedRenew -Language English -DepMap wsl-deps.incompat-original.map -Filter '13-original-mod-incompatibility'
```

The first two are the minimal pass, in both languages; `13` is skipped by requirement in them, and that skip
is counted, not passed. The third is the declared-incompatibility pass. It stages the original mod
(`andery233xj.AncientChineseBeast`, Workshop 3292446841, last supporting 1.5), which has to be in the WSL
install's Workshop cache first: a download that goes through `Use-Wsl.ps1` and has **not been done**.
`10-scheduler` already reads the debug labels through their Keyed keys, so the same lines serve both languages.

A restart sequence is not claimed: the mod's saved state is the round trip in `03`, and no scenario here depends
on a value crossing a process boundary.

## Before a ticket is taken

1. `dotnet build Source` at the repository root, so the mod assembly the steps reference is current.
2. `dotnet build Tests/Pickle/Source`, which writes the step DLL into `Mod/Pickle/Assemblies/`.
3. `powershell.exe -ExecutionPolicy Bypass -File Tests/Pickle/Check-Steps.ps1`: every pattern compiles, none
   is declared twice or ambiguous, every step that waits declares its deadline, and every feature line
   resolves to exactly one expression. It read 52 patterns and 250 step lines when this was written.
4. The owner's word. `PickleTools/TESTING.md` records that no ticket is to be taken until she authorizes one,
   after WSL's root filesystem went read-only on 2026-09-23. Read `scripts/Pickle-Status.ps1` first, and if a
   run is written down, take the report out of `pickle-reports` before the next launch overwrites it.

## What a green run would not say

- A green `@review` scenario says the trajectory and its assertions ran, not that anybody looked at the picture.
- `10-scheduler` moves the game clock by hundreds of thousands of ticks without simulating them. Whatever the
  storyteller would have done in that time is skipped, and it may fire an incident of its own on the next tick.
- The winning random seed is found by trying, and the hour tick runs directly for the two roll scenarios:
  the tick loop's call to it is what the other scenarios prove.
- The suite reads the mod's own assembly directly (`Singleton`, `DebugActions`). A member that goes away
  breaks the build, which is the point, and a change in what it does is not seen by a build.
