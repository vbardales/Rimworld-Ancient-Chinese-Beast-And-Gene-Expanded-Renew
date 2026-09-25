# Runs

What each Pickle run of this mod showed, in text. **The evidence itself is on disk and ignored by git**:
`.build/pickle-run-<date>-<time>-<language>/` holds the report of a run (`summary.md`, `junit.xml`, the captures it
produced), copied out of the runner's shared `pickle-reports/` folder before the next session's run overwrote it. A
capture is about 3 MB on the other mods measured and a run of this one leaves up to nine; none of it is needed to read
what was concluded, which is what the files in this folder say. Root `AGENTS.md`, "Test evidence", is the rule this
page applies.

**No run is recorded yet.** The companion suite in `Tests/Pickle/` is written (52 scenarios in 13 features, the
nine manual exceptions listed in its README) and has not been run: no ticket is taken without the owner's word.
The table at the bottom stays empty until a run has been read.

## Which proofs to keep, and which to drop

The disk is full and the runner's report folder is shared by every mod. For this mod:

- **Keep, per run:** `summary.md` and `junit.xml` (a few KB: what played, what failed), a `log-check.txt` giving the
  two numbers that decide whether the log was clean (red errors, and warnings from this mod, expected 0 and 0), and one
  line in the table of the day's file below. Nothing else is needed to read the conclusion.
- **Keep, only for the current build, from the English pass:** the nine `@review` captures, each as one **minified**
  picture (JPEG, 1280 px wide, quality 70, about 100 KB, never the 3 MB PNG). They are the checks that only a picture
  answers, and the scenario name is the caption:

  | Feature | Capture |
  | --- | --- |
  | `02-beast-review` | four beasts and the Pleiades star officer |
  | `04-critical-hooks` | sexie scorpion form after human form death |
  | `04-critical-hooks` | qiongqi after its flying strike lands |
  | `05-incidents` | Pleiades star officer after its incident |
  | `09-nian-and-firecracker` | nian beast breathing fire at a muffalo |
  | `11-tunnel` | the tunnel opening in the richest room |
  | `06-chicken-crow` | Pleiades star officer crow after its real ability effect |
  | `08-recipes` | nian fire-breath genepack produced by the real recipe hook |
  | `08-recipes` | friendly mingshe produced by the real clone recipe hook |

  A green `@review` scenario says the trajectory and its assertions ran, not that anybody looked at the picture. The
  scenarios `01-loads`, `03-save-reload`, `07-debug-actions`, `10-scheduler`, `12-recipes-and-clones`, the drought
  scenario of `04` and every scenario of `09` but the fire breath take no capture: their proof is the assertion, and
  `summary.md` holds it. Two things are written into the report as attachments and are worth a line in the day's file:
  what butchering a nian beast yielded (the fangs question) and which mod's copy of a def the game kept in the
  incompatibility pass.
- **Keep, from the French pass:** `summary.md`, `junit.xml` and `log-check.txt`, and a picture only for a check whose
  subject is the French text itself. The pass exists to show the game boots and plays with the French UI; the beasts
  look the same in both languages, so their captures are not kept twice.
- **Drop as soon as a newer run of the same build replaces them:** the PNG captures, `messages.ndjson` (several MB),
  `Player.log` (it carries the machine's home path), the films and contact sheets, `summary.json` (a copy of
  `summary.md`), `report.html` and `archive-complete.txt`.
- **A run of a superseded build proves nothing about the current one.** After a change to `Source/`, to the defs or to
  the steps in `Tests/Pickle/Source/`, the older folders go once a run of the new build exists; until then they are the
  only record of what the old build did.
- **Never delete a report a field still points to.** `STATUS.md` names the run behind `tested_on`; repoint that field
  to the newer run first, then delete. List what goes and what stays before deleting anything.
- **The runner's archives.** The launcher keeps a full copy of the shared folder for each run in
  `pickle-reports-archive/` and never trims it. After a run of this mod, take what is needed from the archive of that
  run, then delete that archive. Leave every other mod's alone, and any folder holding a `keep.txt`.
- **Never in git:** `.build/`, `evidence/`, `Evidence/`, `*.webm`, `*.dds`. The repository holds these text files and
  nothing else.

Rules for reading a run:

- `exitReason` is read before any number, and the scenarios played are counted against the ones written.
- A run that wrote no report is listed as such; nothing is concluded from it.
- A scenario that could not be reached is a result, as much as one that failed.

| File | Covers |
| --- | --- |
| `2026-09-24.md` | the first full pass in English (partial, the launcher died) and the first ADS2 pass |
| `2026-09-25.md` | the one-scenario runs after the fixes: the nian blow, the tunnel, the development actions |
