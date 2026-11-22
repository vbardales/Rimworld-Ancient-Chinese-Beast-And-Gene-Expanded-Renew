# In-game scenarios, run by Pickle

Dev-only companion, never shipped in `Mod/`. Turns `TESTING.md` behaviors into self-staging scenarios: each loads/builds own state, acts via real game path, asserts what assertable, and where picture only honest evidence takes bounded `@review` capture for human to open. **First run 2026-09-25**, partial (`Docs/runs/pickle.md`). All numbers below count what written, not what passed.

## Present coverage

23 features, 112 scenarios with outlines expanded (counted 2026-10-01; 88 in minimal pass: `13`, `14`, `16`, `17`, 24 scenarios, skipped by requirement there). Features `17`–`22` and manual-exception scenarios in `04` added from 2026-09-28; see "The manual exceptions" for what each settles.

| Feature | Scenarios | What it settles | `@review` capture |
|---|---|---|---|
| `01-loads` | 1 | mod, Harmony, Biotech load in order; principal defs exist; no mod warning, no error | none |
| `02-beast-review` | 1 | four beasts + chicken render together on clean map | one |
| `03-save-reload` | 1 | four hostile beasts survive real save + reload | none |
| `04-critical-hooks` | 6 | three hooks 1.6 silenced: drought ends with its mingshe, human sexie leaves its scorpion, qiongqi lands flight; plus M1 (drought rots plants hourly, four exceptions spared) and M4 (scorpion aura, two scenarios) | two |
| `05-incidents` | 2 | ordinary-beast incident and chicken incident fire + spawn | one |
| `06-chicken-crow` | 4 | crow kills staged sexie, lifts colonist mood by 20, kills exactly one of two sexies, bird crows alone at four | one |
| `07-debug-actions` | 1 | nian action sets flag scheduler reads | none |
| `08-recipes` | 2 | one extraction, one clone, via real recipe hook | two |
| `09-nian-and-firecracker` | 7 | ordinary blow a tenth, firecracker damage ×100, real explosion wounds beast, fire breath reaches target, butchery, firecracker chain starts + stops | one |
| `10-scheduler` | 9 | nian beast at debug flag and at first hour of year (not hour 5, not day 10), Sexie's 900000-tick beast, gate and daily roll under winning seed, every dev action in run language | none |
| `11-tunnel` | 1 | sexie tunnel opens in richest room, sexie exits | one |
| `12-recipes-and-clones` | 19 | all 12 gene recipes, all 5 clones, archite capsules, tame mingshe dies without drought or error | none |
| `13-original-mod-incompatibility` | 1 | original mod staged, both define same beast, game keeps one copy (`@requires:andery233xj.AncientChineseBeast`) | none |
| `14-animal-prosthetics-2` | 11 | A Dog Said... Animal Prosthetics 2 staged, recipe list game holds per race: five clones offer bionics, chicken simple prosthesis no bionics, four hostile beasts nothing, this mod loads before it (`@requires:SamBucher.ADogSaidAnimalProsthetics2`) | none |
| `15-rest-and-breeding` | 22 | beasts rest + breed: tired tame beast lies down (six races), hostile one has need (five) and arrives rested (five), tame pair mates and female gives birth (four races) or lays egg that hatches (mingshe, star officer) | none |
| `16-nocturnal-animals` | 11 | Nocturnal Animals staged, each of eleven races carries body clock patch gives (`@requires:Mlie.XNDNocturnalAnimals`) | none |
| `17-chinese-comprehensive-expansion` | 1 | the one mod `About.xml` names in `loadAfter` staged, this mod loads after it, no collision (`@requires:ninedaylongbow.ChineseComprehensiveExpansion`) | none |
| `18-gene-effects` | 2 | M7: monstrous strength doubles unarmed colonist melee damage; nian horn adds HP to its part | none |
| `19-bench-job-chain` | 1 | M6: colonist hauls beast corpse to extractor, works bill to ten archite capsules | one, when passes |
| `20-wind-barrier` | 2 | M2: mingshe barrier cuts what inside, spares what far; throws back shot fired from outside | none |
| `21-qiongqi` | 5 | M3: dodge near one half (hostile qiongqi + colonist with eye gene), none without; blows land on head; flying strike goes to farthest colonist | none |
| `22-siege` | 1 | M5: nian beast attacks enclosure of colonist it can't reach (enclosure, not door specifically: door = least resistance, scenario only asks something of enclosure breached) | none |
| `23-letter-language` | 1 | M8: beast chosen in save with letter in other language sends Def letter in run language (`Singleton.BeastFor`); played in English pass and again in French | none |

Nine captures total from English pass, plus tenth `19` takes when passes. `TEST-EVIDENCE.md` of the protocols says which keep and how small. Opened 2026-10-01: `05` capture (star officer) and `11` (tunnel) don't show subject; camera + zoom to set in those scenarios.

### Where each of the 28 scenarios of `TESTING.md` is played

| `TESTING.md` | Played by | Left to human, why |
|---|---|---|
| A1, A2 | `01` | 127 defs counted offline; run checks principal ones |
| B1, B2 | `05`, `11` | |
| B3, B4 | `07`, `10` | |
| C1 | `04` (drought starts + ends) | M1 |
| C2 | | M2 |
| C3 | `04` | |
| C4 | `12` | |
| C5 | `04` (flight lands) | M3 |
| C6 | `04` (shape changes) | M4 |
| C7 | `09` | M5 |
| C8 | `09` | |
| D1, D2, D3 | `05`, `06` | |
| E1, E2 | | M6 |
| E3, E5, E6 | `12` (all), `08` (with picture) | |
| E4 | | M7 |
| F1, F2, F3 | `10` | F1 rarity over years = product of two things `10` plays: gate + roll |
| G1 | `03` | M8 |
| G2 | | M9 |
| H1 (added with A Dog Said 2 patch) | `14` | which operation Health tab offers for which body part, other mod's own logic |
| I1, I2, I3 (added with rest + breeding) | `15`, `16` | real hours of sleep, real gestation + egg, look of young |

### The manual exceptions

Manual play = exception for capability suite lacks; each recorded here with evidence to inspect. **Manual tests to validate: `tested` waits for all green.**

| | `TESTING.md` | Why Pickle doesn't play it | What to inspect |
|---|---|---|---|
| M1 | C1 | plants rot hourly while beast lives; sparing anima, Gauranlen, polux trees is exception list; watching = hours of game time | crop field + one tree each kind, hour after mingshe arrives |
| M2 | C2 | wind shield reflects outside shots, cuts what inside; needs shooter, ring, time | outside shots thrown back, pawn inside cut |
| M3 | C5 | dodge is probability, "the furthest shooter" is AI choice, head bias is distribution | twenty shots + dodge motes; which of two shooters it flies at; where wounds land |
| M4 | C6 | aura berserk needs psychically sensitive colonists + ring cadence | colonists within eleven tiles turning on each other |
| M5 | C7 | nian AI breaking door to reach colonist indoors | door, colonist behind it |
| M6 | E1, E2 | research tab is picture; building bench + colonist hauling corpse to it = job chain | tab **Chinese items**; bill worked to end |
| M7 | E4 | three genes' effects on colonist: dodge, doubled unarmed damage, extra head health | health tab + combat log |
| M8 | G1 (part) | switch language on save, send next letter: language can't switch inside scenario | letter after switch, both directions |
| M9 | G2 | adding mod to existing save + removing from save with beasts needs different mod set between two launches | save opens, with and without |

**State 2026-10-01.** Seven of nine written as scenarios; rest not automatable as is.

| | Scenario | State |
|---|---|---|
| M1 | `04`, drought rots plants hourly | green, 2026-09-28 (`2026-09-28c-m1`) |
| M2 | `20`, wind barrier | green, 2026-09-28 (both scenarios, two runs) |
| M3 | `21`, qiongqi | green, 2026-09-28 (five scenarios, two runs) |
| M4 | `04`, scorpion aura | green, 2026-09-28 (2 of 2) |
| M5 | `22`, siege | green, 2026-09-29, after several red runs taught scenario to remove colony's own colonists and ask for enclosure not door |
| M6 | `19`, bench job chain | **red**, three runs 2026-09-28. Cause found 2026-10-01 in diagnostic runs attached: extractor interaction cell not standable + unreachable at chosen place. Placement step now takes nearest place with standable footprint + interaction cell; replay owed |
| M7 | `18`, gene effects | **red**, 2026-09-28, both scenarios |
| M8 | `23`, stale letter of saved beast replaced | written 2026-10-01, not yet played: language switch itself is game's (`AUDIT.md`, "On ne teste pas le jeu"), so scenario asserts what mod owns, letter in run language, in English pass and French |
| M9 | none | **not applicable**: adding mod to save, opening save whose mod gone = game's own behaviour (`AUDIT.md`, "On ne teste pas le jeu"). Mod answers for what it declares, checked in `About.xml` (dependencies, `loadAfter`, `incompatibleWith`), and survival of own saved state, played by `03`. Owner can overturn, ask for `-Then` / `-ThenWithout` removal pass |

### A finding the suite settled

Nian beast description, README, `TESTING.md` said butchering yields **nian beast fangs**. Butchery scenario in `09` asserts meat, writes **every product it yields** to report; first run (2026-09-25) listed one product, `Meat_SZ_YearBeast` x2800: no fangs, no def of that name ships. Promise was inherited port text; removed from three descriptions (English, French, Simplified Chinese), README, `TESTING.md`. Scenario stays: now proves butchery gives meat, reports anything else.

## Passes

No DLC-absent pass: Biotech hard dependency, mod won't load without. About.xml names one optional mod in `loadAfter`: `ninedaylongbow.ChineseComprehensiveExpansion`, Workshop 3221850511 (looked up 2026-09-28 by packageId, `Search-Workshop.sh` over local corpus). Pass 3 of `TESTING.md`, "Passes", written (`17-chinese-comprehensive-expansion.feature`, `wsl-deps.cce.map`), green 2026-09-28. Other optional mod, A Dog Said... Animal Prosthetics 2, not in `loadAfter` (mod loads *before* it); its pass written. Six passes below written, each separate launch of shared runner, submitted as own request (see "Before a ticket is taken").

```powershell
powershell.exe -ExecutionPolicy Bypass -File scripts/Run-PickleWsl.ps1 -Mod AncientChineseBeastAndGeneExpandedRenew -Language English
powershell.exe -ExecutionPolicy Bypass -File scripts/Run-PickleWsl.ps1 -Mod AncientChineseBeastAndGeneExpandedRenew -Language French
powershell.exe -ExecutionPolicy Bypass -File scripts/Run-PickleWsl.ps1 -Mod AncientChineseBeastAndGeneExpandedRenew -Language English -DepMap wsl-deps.incompat-original.map -Filter '13-original-mod-incompatibility'
powershell.exe -ExecutionPolicy Bypass -File scripts/Run-PickleWsl.ps1 -Mod AncientChineseBeastAndGeneExpandedRenew -Language English -DepMap wsl-deps.ads2.map -Filter '14-animal-prosthetics-2'
powershell.exe -ExecutionPolicy Bypass -File scripts/Run-PickleWsl.ps1 -Mod AncientChineseBeastAndGeneExpandedRenew -Language English -DepMap wsl-deps.cce.map -Filter '17-chinese-comprehensive-expansion'
powershell.exe -ExecutionPolicy Bypass -File scripts/Run-PickleWsl.ps1 -Mod AncientChineseBeastAndGeneExpandedRenew -Language English -DepMap wsl-deps.nocturnal.map -Filter '16-nocturnal-animals'
```

First two = minimal pass, both languages; `13`, `14`, `16` skipped by requirement there, skip counted, not passed. Fourth stages A Dog Said 2 (Workshop 3238353862, `wsl-deps.ads2.map`), Windows subscription (1.3.7), so staging finds it, no download. Recipe + category names checked against those local 1.6 files; pass ran green (11 of 11, 2026-09-25). Fifth stages Nocturnal Animals (Workshop 2269731409, `wsl-deps.nocturnal.map`), also Windows subscription, plays `16`. Third = declared-incompatibility pass. Stages original mod (`andery233xj.AncientChineseBeast`, Workshop 3292446841, last supporting 1.5), Windows subscription staging reads first, so nothing downloaded into WSL cache.
`10-scheduler` already reads debug labels via Keyed keys, so same lines serve both languages.

No restart sequence claimed: mod saved state = round trip in `03`, no scenario here depends on value crossing process boundary.

## Before a ticket is taken

1. `dotnet build Source` at repo root, so mod assembly steps reference is current.
2. `dotnet build Tests/Pickle/Source`, writes step DLL into `Mod/Pickle/Assemblies/`.
3. `pwsh -File ../../scripts/Check-Steps.ps1 -ModRoot .` (shared script): every pattern compiles, none
   declared twice or ambiguous, every waiting step declares deadline, every feature line
   resolves to exactly one expression. Last run read 56 patterns, 265 step lines.
4. Owner's word, then request to TicketDispatcher, not hand launch:
   `Rimworld-Ticket-Dispatcher/scripts/Submit-PickleRun.ps1 -Mod AncientChineseBeastAndGeneExpandedRenew -Owner
   local_<session id> -Label "..." -EvidenceDir <repo-relative folder>` with same `-Language`, `-DepMap`,
   `-Filter` as commands above, one request per pass (`Rimworld-Ticket-Dispatcher/docs/WELCOME.md`). Wakes
   session at START, END, RUN_DONE; nothing watches queue. First or last pass runs every scenario; fix or
   exploration runs one, with `-Filter '::<scenario name>'`. Read `scripts/Pickle-Status.ps1` to see machine;
   take report out of `pickle-reports` before next launch overwrites it.

## What a green run would not say

- Green `@review` scenario = trajectory + assertions ran, not that anyone looked at picture.
- `10-scheduler` moves game clock by hundreds of thousands of ticks without simulating. Whatever storyteller
  would have done skipped; may fire own incident next tick.
- Winning random seed found by trying; hour tick runs directly for two roll scenarios: tick loop's call to it
  is what other scenarios prove.
- Suite reads mod's own assembly directly (`Singleton`, `DebugActions`). Removed member breaks build (the
  point); change in behavior not seen by build.