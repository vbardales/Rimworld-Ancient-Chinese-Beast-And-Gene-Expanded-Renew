# In-game scenarios, run by Pickle

This companion is development-only and is never distributed in `Mod/`. It converts the behaviors of
`TESTING.md` into self-staging scenarios: each one loads or builds its own state, acts through the real game
path, asserts what can be asserted, and where a picture is the only honest evidence takes a bounded `@review`
capture for a person to open. **It was first run on 2026-09-25**, in part (`docs/runs/`). Every number below is a count of what was written, not of what passed.

## Present coverage

Twenty-three features, 112 scenarios once the outlines are expanded (counted 2026-10-01; 88 in a minimal pass: `13`,
`14`, `16` and `17`, 24 scenarios, are skipped by requirement there). Features `17` to `22` and the manual
exceptions' scenarios in `04` were added from 2026-09-28; see "The manual exceptions" for what each settles.

| Feature | Scenarios | What it settles | `@review` capture |
|---|---|---|---|
| `01-loads` | 1 | the mod, Harmony and Biotech load in order; the principal defs exist; no warning from the mod, no error | none |
| `02-beast-review` | 1 | the four beasts and the chicken render together on a clean map | one |
| `03-save-reload` | 1 | four hostile beasts survive a real save and reload | none |
| `04-critical-hooks` | 6 | the three hooks 1.6 silenced: the drought ends with its mingshe, the human sexie leaves its scorpion, the qiongqi lands its flight; and M1 (the drought rots plants hourly, four exceptions spared) and M4 (the scorpion's aura, two scenarios) | two |
| `05-incidents` | 2 | the ordinary-beast incident and the chicken's incident fire and spawn | one |
| `06-chicken-crow` | 4 | the crow kills a staged sexie, lifts a colonist's mood by twenty, kills exactly one of two sexies, and the bird crows by itself at four | one |
| `07-debug-actions` | 1 | the nian action sets the flag the scheduler reads | none |
| `08-recipes` | 2 | one extraction and one clone, through the real recipe hook | two |
| `09-nian-and-firecracker` | 7 | ordinary blow a tenth, firecracker damage a hundred times, a real explosion wounds the beast, the fire breath reaches its target, butchery, the firecracker chain starts and stops | one |
| `10-scheduler` | 9 | the nian beast at the debug flag and at the first hour of the year (and not at hour 5, nor on day 10), Sexie's 900000-tick beast, the gate and the daily roll under a seed that wins, every development action in the language of the run | none |
| `11-tunnel` | 1 | the sexie's tunnel opens in the richest room and the sexie comes out | one |
| `12-recipes-and-clones` | 19 | all twelve gene recipes, all five clones, the archite capsules, and a tame mingshe that dies without a drought or an error | none |
| `13-original-mod-incompatibility` | 1 | with the original mod staged, both define the same beast and the game keeps one copy (`@requires:andery233xj.AncientChineseBeast`) | none |
| `14-animal-prosthetics-2` | 11 | with A Dog Said... Animal Prosthetics 2 staged, the recipe list the game holds on each race: the five clones offer bionics, the chicken a simple prosthesis and no bionics, the four hostile beasts nothing, and this mod loads before it (`@requires:SamBucher.ADogSaidAnimalProsthetics2`) | none |
| `15-rest-and-breeding` | 22 | the beasts rest and breed: a tired tame beast lies down (six races), a hostile one has the need (five) and arrives rested (five), a tame pair mates and the female gives birth (four races) or lays an egg that hatches (mingshe, star officer) | none |
| `16-nocturnal-animals` | 11 | with Nocturnal Animals staged, each of the eleven races carries the body clock the patch gives it (`@requires:Mlie.XNDNocturnalAnimals`) | none |
| `17-chinese-comprehensive-expansion` | 1 | with the one mod `About.xml` names in `loadAfter` staged, this mod loads after it and nothing collides (`@requires:ninedaylongbow.ChineseComprehensiveExpansion`) | none |
| `18-gene-effects` | 2 | M7: monstrous strength doubles an unarmed colonist's melee damage; the nian horn adds hit points to its part | none |
| `19-bench-job-chain` | 1 | M6: a colonist hauls a beast corpse to the extractor and works the bill to ten archite capsules | one, when it passes |
| `20-wind-barrier` | 2 | M2: the mingshe's barrier cuts what stands inside and spares what is far; it throws back a shot fired from outside | none |
| `21-qiongqi` | 5 | M3: the dodge near one half (hostile qiongqi and a colonist with the eye gene) and none without it; the blows land on the head; the flying strike goes to the farthest colonist | none |
| `22-siege` | 1 | M5: the nian beast attacks the enclosure of a colonist it cannot reach (the enclosure, not the door specifically: the door is the way of least resistance, and the scenario asks only that something of the enclosure is breached) | none |
| `23-letter-language` | 1 | M8: a beast chosen in a saved game with a letter of another language sends the letter of the Def in the language of the run (`Singleton.BeastFor`); played in the English pass and again in the French one | none |

Nine captures in all from the English pass, plus a tenth that `19` takes when it passes. `docs/runs/README.md` says
which to keep and how small. Opened on 2026-10-01, the `05` capture (the star officer) and the `11` one (the tunnel)
do not show their subject: the camera and the zoom are to be set in those scenarios.

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
| C8 | `09` | |
| D1, D2, D3 | `05`, `06` | |
| E1, E2 | | M6 |
| E3, E5, E6 | `12` (all of them), `08` (with a picture) | |
| E4 | | M7 |
| F1, F2, F3 | `10` | F1's rarity over years is the product of the two things `10` plays: the gate and the roll |
| G1 | `03` | M8 |
| G2 | | M9 |
| H1 (added with the A Dog Said 2 patch) | `14` | which operation the Health tab offers for which body part, the other mod's own logic |
| I1, I2, I3 (added with rest and breeding) | `15`, `16` | real hours of sleep, a real gestation and egg, the look of the young |

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

**State on 2026-10-01.** Seven of the nine have been written as scenarios; the others cannot be automated as they stand.

| | Scenario | State |
|---|---|---|
| M1 | `04`, the drought rots plants hourly | green, 2026-09-28 (`2026-09-28c-m1`) |
| M2 | `20`, the wind barrier | green, 2026-09-28 (both scenarios, two runs) |
| M3 | `21`, the qiongqi | green, 2026-09-28 (five scenarios, two runs) |
| M4 | `04`, the scorpion's aura | green, 2026-09-28 (2 of 2) |
| M5 | `22`, the siege | green, 2026-09-29, after several red runs that taught the scenario to remove the colony's own colonists and to ask for the enclosure rather than the door |
| M6 | `19`, the bench job chain | **red**, three runs on 2026-09-28. Cause found 2026-10-01 in the diagnostic the runs attached: the extractor's interaction cell was not standable and unreachable at the chosen place. The placement step now takes the nearest place with a standable footprint and interaction cell; replay owed |
| M7 | `18`, the gene effects | **red**, 2026-09-28, both scenarios |
| M8 | `23`, the stale letter of a saved beast is replaced | written 2026-10-01, not yet played: the language switch itself is the game's (`AUDIT.md`, "On ne teste pas le jeu"), so the scenario asserts what the mod owns, the letter in the language of the run, in the English pass and in the French one |
| M9 | none | **not applicable**: adding a mod to a save, and opening a save whose mod is gone, are the game's own behaviour (`AUDIT.md`, "On ne teste pas le jeu"). What the mod answers for is what it declares, checked in `About.xml` (the dependencies, `loadAfter`, `incompatibleWith`), and the survival of its own saved state, played by `03`. The owner can overturn this and ask for a `-Then` / `-ThenWithout` removal pass |

### A finding the suite settled

The nian beast's description, the README and `TESTING.md` said butchering it yields **nian beast fangs**. The butchery
scenario in `09` asserts meat and writes **every product it yields** into the report, and the first run
(2026-09-25) listed one product, `Meat_SZ_YearBeast` x2800: no fangs, and no def of that name ships. The promise was
text the port inherited, and it has been taken out of the three descriptions (English, French, Simplified Chinese), the
README and `TESTING.md`. The scenario stays: it now proves that a butchery gives meat and reports anything else.

## Passes

There is no DLC-absent pass: Biotech is a hard dependency, so the mod does not load without it. About.xml does
name one optional mod, in `loadAfter`: `ninedaylongbow.ChineseComprehensiveExpansion`, Workshop 3221850511
(looked up 2026-09-28 by its packageId, `Search-Workshop.sh` over the local corpus). Pass 3 of `TESTING.md`,
"Passes", is written (`17-chinese-comprehensive-expansion.feature`, `wsl-deps.cce.map`) and ran green on 2026-09-28.
The other optional mod, A Dog Said... Animal Prosthetics 2, is not in `loadAfter` (the mod loads *before* it)
and its pass is written. The six passes below are written, and each is a separate launch of the shared runner,
submitted as its own request (see "Before a ticket is taken").

```powershell
powershell.exe -ExecutionPolicy Bypass -File scripts/Run-PickleWsl.ps1 -Mod AncientChineseBeastAndGeneExpandedRenew -Language English
powershell.exe -ExecutionPolicy Bypass -File scripts/Run-PickleWsl.ps1 -Mod AncientChineseBeastAndGeneExpandedRenew -Language French
powershell.exe -ExecutionPolicy Bypass -File scripts/Run-PickleWsl.ps1 -Mod AncientChineseBeastAndGeneExpandedRenew -Language English -DepMap wsl-deps.incompat-original.map -Filter '13-original-mod-incompatibility'
powershell.exe -ExecutionPolicy Bypass -File scripts/Run-PickleWsl.ps1 -Mod AncientChineseBeastAndGeneExpandedRenew -Language English -DepMap wsl-deps.ads2.map -Filter '14-animal-prosthetics-2'
powershell.exe -ExecutionPolicy Bypass -File scripts/Run-PickleWsl.ps1 -Mod AncientChineseBeastAndGeneExpandedRenew -Language English -DepMap wsl-deps.cce.map -Filter '17-chinese-comprehensive-expansion'
powershell.exe -ExecutionPolicy Bypass -File scripts/Run-PickleWsl.ps1 -Mod AncientChineseBeastAndGeneExpandedRenew -Language English -DepMap wsl-deps.nocturnal.map -Filter '16-nocturnal-animals'
```

The first two are the minimal pass, in both languages; `13`, `14` and `16` are skipped by requirement in them, and
that skip is counted, not passed. The fourth stages A Dog Said 2 (Workshop 3238353862, `wsl-deps.ads2.map`),
which is a Windows subscription (1.3.7), so staging finds it with no download. Its recipe and category names
were checked against those local 1.6 files, and the pass has run green (11 of 11, 2026-09-25). The fifth stages Nocturnal Animals
(Workshop 2269731409, `wsl-deps.nocturnal.map`), a Windows subscription too, and plays `16`. The third is the declared-incompatibility pass. It stages the original mod
(`andery233xj.AncientChineseBeast`, Workshop 3292446841, last supporting 1.5), a Windows subscription that the
staging reads first, so nothing has to be downloaded into the WSL cache.
`10-scheduler` already reads the debug labels through their Keyed keys, so the same lines serve both languages.

A restart sequence is not claimed: the mod's saved state is the round trip in `03`, and no scenario here depends
on a value crossing a process boundary.

## Before a ticket is taken

1. `dotnet build Source` at the repository root, so the mod assembly the steps reference is current.
2. `dotnet build Tests/Pickle/Source`, which writes the step DLL into `Mod/Pickle/Assemblies/`.
3. `powershell.exe -ExecutionPolicy Bypass -File Tests/Pickle/Check-Steps.ps1`: every pattern compiles, none
   is declared twice or ambiguous, every step that waits declares its deadline, and every feature line
   resolves to exactly one expression. It read 56 patterns and 265 step lines when this was last run.
4. The owner's word, then a request to the TicketDispatcher, not a launch by hand:
   `Rimworld-Ticket-Dispatcher/scripts/Submit-PickleRun.ps1 -Mod AncientChineseBeastAndGeneExpandedRenew -Owner
   local_<session id> -Label "..." -EvidenceDir <repo-relative folder>` with the same `-Language`, `-DepMap` and
   `-Filter` as the commands above, one request per pass (`Rimworld-Ticket-Dispatcher/docs/WELCOME.md`). It
   wakes the session at START, END and RUN_DONE; nothing watches the queue. A first or last pass runs every
   scenario; a fix or an exploration runs one, with `-Filter '::<scenario name>'`. Read
   `scripts/Pickle-Status.ps1` to see the machine, and take a report out of `pickle-reports` before the next
   launch overwrites it.

## What a green run would not say

- A green `@review` scenario says the trajectory and its assertions ran, not that anybody looked at the picture.
- `10-scheduler` moves the game clock by hundreds of thousands of ticks without simulating them. Whatever the
  storyteller would have done in that time is skipped, and it may fire an incident of its own on the next tick.
- The winning random seed is found by trying, and the hour tick runs directly for the two roll scenarios:
  the tick loop's call to it is what the other scenarios prove.
- The suite reads the mod's own assembly directly (`Singleton`, `DebugActions`). A member that goes away
  breaks the build, which is the point, and a change in what it does is not seen by a build.
