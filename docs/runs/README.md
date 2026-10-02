# Runs

What each Pickle run of this mod showed, in text. **The evidence itself is on disk and ignored by git**:
`Tests/Pickle/Evidence/<date><letter>-<scope>/` holds what was kept of a run, copied out of the runner's shared
`pickle-reports/` folder by the launcher (`-EvidenceDir`) before the next run overwrote it. None of it is needed to read
what was concluded, which is what the files in this folder say. Root `AGENTS.md`, "Test evidence", is the rule this
page applies.

The suite has been played in a real game since 2026-09-25, **feature by feature and never as one full run**. The
table at the bottom says which day file covers what.

## Which proofs to keep, and which to drop

The disk fills up and the runner's report folder is shared by every mod. For this mod (rewritten 2026-10-01; the
evidence folder went from 198 MB to 2 MB):

- **Keep, per run:** `summary.json` (it carries `exitReason` and `setName`, read before any number) and `junit.xml`
  (the suite and scenario names, the failure messages, the attachments), and `summary.md` (the readable table). A few
  KB together. One line in the day's file of this folder says what the run proved.
- **Keep, only for the current build, from the English pass:** the nine `@review` captures, each as one **minified**
  picture (JPEG, 1280 px wide, `ffmpeg -vf scale=1280:-2 -q:v 6`, about 100 KB, never the 3 MB PNG), in a `captures/`
  folder beside the report. They are the checks that only a picture answers, and the scenario name is the caption:

  | Feature | Capture |
  | --- | --- |
  | `02-beast-review` | four beasts and the Pleiades star officer |
  | `04-critical-hooks` | sexie scorpion form after human form death |
  | `04-critical-hooks` | qiongqi after its flying strike lands |
  | `05-incidents` | Pleiades star officer after its incident |
  | `09-nian-and-firecracker` | nian beast breathing fire at a muffalo |
  | `11-tunnel` | the sexie coming out of its tunnel in the richest room |
  | `06-chicken-crow` | Pleiades star officer crow after its real ability effect |
  | `08-recipes` | nian fire-breath genepack produced by the real recipe hook |
  | `08-recipes` | friendly mingshe produced by the real clone recipe hook |

  A green `@review` scenario says the trajectory and its assertions ran, not that anybody looked at the picture. Open
  every capture before keeping it, and say in `STATUS.md` which ones do not show their subject (on 2026-10-01 two do:
  `05` and `11`).
  The other scenarios take no capture: their proof is the assertion, and `summary.md` holds it.
- **Keep, from the French pass:** `summary.json`, `junit.xml`, `summary.md`, and a picture only for a check whose
  subject is the French text itself. The beasts look the same in both languages, so their captures are not kept twice.
- **A red report stays until a green one replaces it.** The latest report of a scenario is its current verdict, red or
  green; it is the only proof a scenario is still red (M6 and M7 on 2026-10-01).
- **Drop as soon as a newer run of the same scenarios replaces them:** the whole older folder, if the newer one covers
  every scenario of it; if not, only keep the older folder for the scenarios the newer one did not repeat.
- **Drop, always:** `report.html`, `messages.ndjson` (several MB), `Player.log` (it carries the machine's home path),
  the films, the contact sheets, `evidence-complete.txt`, and the PNG captures once their JPEG exists.
- **A run of a superseded build proves nothing about the current one.** After a change to `Source/`, to the defs, to the
  patches or to the steps in `Tests/Pickle/Source/`, the older folders go once a run of the new build exists; until then
  they are the only record of what the old build did. The final pass of a `tested` claim replaces them all.
- **Never delete a report a field still points to.** `STATUS.md` names the run behind `tested_on`; repoint that field
  to the newer run first, then delete. List what goes and what stays before deleting anything.
- **The runner's archives.** The launcher keeps a full copy of the shared folder for each run in
  `pickle-reports-archive/` and never trims it. After a run of this mod, take what is needed from the archive of that
  run, then delete that archive (`robocopy <empty folder> <archive> /MIR`, then `Remove-Item`: the capture names pass
  MAX_PATH). Leave every other mod's alone, and any folder holding a `keep.txt`. On 2026-10-01 none of the nine
  folders there belonged to this mod.
- **Never in git:** `.build/`, `evidence/`, `Evidence/`, `*.webm`, `*.dds`. The repository holds these text files and
  nothing else.

Rules for reading a run:

- `exitReason` is read before any number, and the scenarios played are counted against the ones written.
- A run that wrote no report is listed as such; nothing is concluded from it.
- A scenario that could not be reached is a result, as much as one that failed.
- The shared report folder holds every mod's reports: check `setName` and the suite name before citing one.

## What the evidence folders hold (2026-10-01)

26 folders, 2 MB. `summary.json` was deleted from all of them by mistake on 2026-10-01 (see the day file); the final
pass restores the rule.

| Folder | Covers | Result |
| --- | --- | --- |
| `2026-10-01d-p5-14` | feature 14, Animal Prosthetics 2 | 11/11 |
| `2026-09-25b-f04` | 04: the three hooks 1.6 silenced (+ 2 captures) | 3/3 |
| `2026-09-25b-f06` | 06: the chicken's crow (+ 1 capture) | 4/4 |
| `2026-09-25b-f13` | 13: the original mod's incompatibility (old packageId) | 1/1 |
| `2026-09-25c-f0203` | 02 and 03: beasts render, save and reload (+ 1 capture) | 2/2 |
| `2026-10-01e-p6-16` | 16: Nocturnal Animals | 11/11 |
| `2026-09-25c-rest` | 15: a tired tame beast lies down, a hostile one has the need | 11/11 |
| `2026-09-25e-birth`, `2026-09-25e-egg` | 15: births and eggs | 4/4, 2/2 |
| `2026-09-26a-misc` | 01, 05, 07, 08 (+ 3 captures) | 6/6 |
| `2026-09-26b-nian` | 09: the nian beast and the firecracker (+ 1 capture) | 7/7 |
| `2026-09-26c-sched` | 10 and 12: scheduler, recipes and clones | 28/28 |
| `2026-09-26d-french` | 01, 05, 07, 08 in French | 6/6 |
| `2026-09-26e-hostile-rest` | 15: a hostile beast arrives rested | 5/5 |
| `2026-09-27c-tunnel` | 11: the sexie's tunnel, fixed tree (+ 1 capture) | 1/1 |
| `2026-09-27d-packageid` | 01 on the new packageId; 13 skipped | 1 passed, 1 skipped |
| `2026-09-28b-cce` | 17: Chinese Comprehensive Expansion | 1/1 |
| `2026-09-28c-m1` | M1: the drought rots plants (in 04) | 1/1 |
| `2026-09-28d-m7` | M7: gene effects (18) | **0/2 red** |
| `2026-09-28g-m2`, `2026-09-28l-m2` | M2: the wind barrier (20): throw-back, then the cut | 1/2 + 1/1 |
| `2026-09-28h-m3`, `2026-09-28m-m3head` | M3: the qiongqi (21): dodge, farthest shooter, then the head blows | 4/5 + 1/1 |
| `2026-09-28o-m4` | M4: the sexie's aura (in 04) | 2/2 |
| `2026-09-28p-m6` | M6: the bench job chain (19) | **0/1 red** |
| `2026-09-29a-m5` | M5: the nian beast and the enclosure (22) | 1/1 |

Deleted on 2026-10-01 as superseded: `2026-09-24-en`, `2026-09-25b-blow`, `2026-09-25d-tunnel`, `2026-09-25-f09`,
`2026-09-28e-m4`, `2026-09-28j-m4`, `2026-09-28f-m6`, `2026-09-28k-m6`, `2026-09-28i-m5`, `2026-09-28n-m5`,
`2026-09-28q-m5`. Older day files still name some of them: the line is the record, the folder is gone.

| File | Covers |
| --- | --- |
| `2026-09-24.md` | the first full pass in English (partial, the launcher died) and the first ADS2 pass |
| `2026-09-25.md` | the one-scenario runs after the fixes, the rest-and-breed tree, the tunnel, eggs and births |
| `2026-09-26.md` | features 01 05 07 08, 09, 10 and 12, the French pass, the hostile beast's rest |
| `2026-09-27.md` | the tunnel fix, pass 3, and the manual exceptions automated as scenarios (M1 to M7) |
| `2026-10-01.md` | the audit: offline replay, the evidence trim |
