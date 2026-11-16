# Protocols read, and in which version

Session of this mod read workspace docs on **2026-10-01** (~04:45 to 05:30), at owner's request, for that day's audit
(`STATUS.md`). Replaces 2026-09-25 note: every protocol file changed since (all hashes differ), and a rule or two this
mod followed had moved.

Version = last commit touching file **in repo that holds it**, then first 12 chars of SHA-256 of file **as read**. Hash
mismatch → file changed, read again before relying on it. Row says "not useful" → not read again unless task depends on
it. Protocol docs (`AGENTS`, `AUDIT`, `PUBLISHING`, `TRANSLATIONS`, `STYLE_RIMWORLD`, `MOD_SETTINGS`, `WORKSHOP_COMMENTS`,
`scripts/SEARCHING`) belong to `vbardales/Rimworld-protocols` (git dir `../rimworld-protocols.git`, work tree =
collection folder, HEAD `c105a43` when read): `git log` from monorepo returns commit that removed them, so versions below
come from that git dir. `PickleTools`, `Rimworld-Release-Admin`, `Rimworld-Ticket-Dispatcher` = own repos (HEAD
`b7620cb`, `b70348b`, `ae69394`). Read whole, line by line, unless row says otherwise.

## The collection's documents

| Document | Version | SHA-256 (12) | Lines | Useful here? |
|---|---|---|---|---|
| `AGENTS.md` | `7fd7475`, 2026-09-29 09:37 | `7a236f03ca15` | 21 | **Yes.** Evidence rule (keep latest report per scenario, one text line per run in `docs/runs/`, delete own run's archive, never a report a `STATUS.md` field points to), publishing by CI. Read as in session context |
| `AUDIT.md` | `7fd7475`, 2026-09-29 09:37 | `0fb60fdf8c87` | 274 | **Yes, the reference.** Chain; step 9 `done -> tested` (no `@wip`, every `@requires` played + report read, no manual test left); step 12 (audit goes to last proven state, `workflow_stage`, session title); Pickle rules (request carries no SHA, small tickets, `exitReason` first, ≥2 passes); `.dds` and evidence rules |
| `MOD_SETTINGS.md` | `b83933b`, 2026-09-23 20:46 | `404916bc99a7` | 107 | Only §1 and §5, to justify `settings_audit: not_applicable` (mod has no settings). Rest for mods with settings |
| `PUBLISHING.md` | `02394c0`, 2026-10-01 04:41 | `d65e0afcefb2` | 785 | **Yes.** New since 09-25, used: four animal integrations (rule completed today), pull request to origin repo (systematic, in `BACKLOG.md`, public so only with Virginie's word), gallery's `0-` image + Preview carrying ModIcon, description's single Markdown source. Not useful: git-incident history, repo topics, junctions, `RimWorks/mod-ci` review |
| `TRANSLATIONS.md` | `c105a43`, 2026-10-01 05:15 | `e5197820fda1` | 213 | **Yes.** Plurals (2026-09-25), neutral o-series + three-segment switch, French review file (`FRENCH_REVIEW.md`, only owner closes `translation_fr`). Mod has no French text agreeing with pawn, no counted key |
| `STYLE_RIMWORLD.md` | `c105a43`, 2026-10-01 05:15 | `d536a6addedd` | 682 | **Partly.** Engraved-text section, ModIcon cutout, gallery image 0, to judge committed Preview. Image-prompt blocks, palette measures, `ModIcon` generation useless: session generates no illustration, never a ModIcon |
| `WORKSHOP_COMMENTS.md` | `7fd7475`, 2026-09-29 09:37 | `3fb37586f04b` | 159 | Only register row 3292446841 (original, `drafted`, post after item public) and method. Other rows = other mods. Read before drafting comment, not otherwise |
| `scripts/SEARCHING.md` | `50de695`, 2026-09-28 21:04 | `013075b06b89` | 222 | **No.** Mod corpus search; mod needed three bounded reads of single mod folders (Dogs mate, Better Crossbreeding, original), not corpus search. Not read again |
| `PickleTools/README.md` | `ff20d89`, 2026-09-29 10:19 | `a18a07fd2365` | 88 | Partly. Tool table + pass-map line; tools not used by mod's suite beyond own steps |
| `PickleTools/Headless/README.md` | `ed4e73a`, 2026-09-26 22:52 | `2310bb974f68` | 509 | **Yes.** Filter terms, pass maps (`path:` overlays, trailing newline), `-Then` with `-ThenWithout` (candidate for M9), evidence copying, exit codes, traps |
| `PickleTools/docs/steps.md` | `da7c3b0`, 2026-09-28 20:22 | `df2b37a6aff2` | 262 | Partly. None of 110 steps spawns a beast; mod has own steps. Generated, not edited. Read again only to write a step |
| `Rimworld-Release-Admin/docs/OPERATIONS.md` | `3c03f51`, 2026-09-26 23:20 | `23fcf6423000` | 112 | **Yes for publication** (dry-run of exact commit, full SHA, only Virginie approves, first-publication path, what publish sends). Nothing to do before `tested` |
| `Rimworld-Ticket-Dispatcher/docs/WELCOME.md` | `77ca9d7`, 2026-09-27 23:26 | `08b440a03f74` | 150 | **Yes.** Which test to play, pass maps, no watcher, no SHA in request, `summary.json` + `junit.xml` = what evidence folder keeps, `desktop.ini` warning for `Mod/`, where to write versions read |
| `Rimworld-Ticket-Dispatcher/docs/SUBMIT.md` | `d07b2b8`, 2026-09-26 18:25 | `eaca3969c7eb` | 133 | **Yes.** Every option of `Submit-PickleRun.ps1`, launcher exit codes. Needed for final pass |

`EXTERNAL_TOOLS.md` not on list, not read.

## This repository's documents

| Document | Version | State | Note |
|---|---|---|---|
| `STATUS.md` | `67a4b37`, 2026-09-30 17:04 | modified, not committed | Read whole; 2026-10-01 audit written into it |
| `README.md` | `70feeae`, 2026-09-25 20:55 | modified, not committed | Read whole; Testing paragraph said 28 scenarios not executed, corrected |
| `CHANGELOG.md` | `70feeae`, 2026-09-25 20:55 | clean | Read whole; `## [1.0.0] - unreleased` above `## [0.1.0] - 2026-09-23`, whose entry says "Creation of the `PublishedFileId.txt` file". Left as is |
| `ATTRIBUTION.md` | `70feeae`, 2026-09-25 20:55 | modified, not committed | Read whole; gained source repo found today + corrected "what is not covered" paragraph. `Mod/ATTRIBUTION.md` recopied, byte-identical (SHA-256 compared) |
| `LICENSE` | `c718af2`, 2026-09-20 11:15 | clean | Read whole, untouched (`Mod/LICENSE` identical) |
| `PUBLICATION.md` | `b50919b`, 2026-09-26 17:34 | modified, not committed | Read whole; status line said CI did not read it yet, corrected |
| `TESTING.md` | `70feeae`, 2026-09-25 20:55 | modified, not committed | Read whole; counts, pass 3, `tested` conditions updated |
| `BACKLOG.md` | `e8b22b0`, 2026-09-25 22:30 | modified, not committed | Read whole; pull-request entry added |
| `docs/runs/` | README `704316f`; day files `abaa862`, `bbf5a63`, `42f03ed`, `67a4b37` | README modified, `2026-10-01.md` new | All read; README rewritten (what to keep, evidence map) |
| `Tests/Pickle/README.md` | `8703ff2`, 2026-09-28 00:08 | modified, not committed | Read whole; features 17 to 22, state of M1 to M9, pass 3 |
| `Tests/Pickle/` features and steps | `bea3e9e`, 2026-09-29 15:36 | clean | **Partly read**: features 17 to 22 whole, head of 04, counts of all 22 by script; `Check-Steps.ps1` run. Other 16 not line by line: content known from README + reports |
| `Mod/About/About.xml` | `19e649d`, 2026-09-27 23:22 | clean | Read whole; matches `PUBLICATION.md` (`sync-about-description.mjs`) |
| `docs/MANUAL-TESTS.md` | `17b3fbb`, 2026-09-26 22:46 | modified, not committed | Read whole; was French, rewritten in English with state of M1 to M9 |
| `FRENCH_REVIEW.md` | `20bee84`, 2026-09-30 14:25 | clean | Header only; owner's to read, French files unchanged since generated |

`NOTES.md` and `BUGS.md` do not exist in this repo.

## What the reading turned up, for this mod

- **2026-09-25 note's open item closed:** `PUBLICATION.md` exists. **New items:** four animal integrations (Dogs mate +
  Better Crossbreeding recorded not applicable, with reasons, in `STATUS.md`); source repo of original,
  `MonsterTower/AncientChineseBeast`, in `upstream_mod_remotes`, + pull request entry in `BACKLOG.md`; `workflow_stage`
  and session title `ancientchinesebeastandgeneexpanded / done`.
- **Evidence rule moved:** keep `summary.json` + `junit.xml`, never `report.html`, `messages.ndjson` or `Player.log`.
  Session deleted `summary.json` from 26 kept folders before re-reading that line in `WELCOME.md`;
  `docs/runs/README.md` and `STATUS.md` record it.
- **Request carries no SHA:** final pass writes SHA in `-Label`, leaves tree still until `RUN_DONE`. Today working tree
  not still: another session regenerating `Art/` and `Mod/About/Preview.png`.

## Update of 2026-10-08

Owner asked docs read again. Every protocol file except `AGENTS.md`, `MOD_SETTINGS.md`, `PickleTools/Headless/README.md`
changed (hash vs table above). **How each read matters:** changed file read **by diff against version read 2026-10-01**
(`git log`/`git diff` in holding repo), not whole, unless row says "whole". Hashes = first 12 chars of SHA-256 of file
as it stands. Protocols repo HEAD `bc206b5`; `PickleTools` `ed45974`, `Rimworld-Release-Admin` `657951b`,
`Rimworld-Ticket-Dispatcher` `964b790`.

| Document | SHA-256 (12) | Lines | Read | What it changed here |
|---|---|---|---|---|
| `AGENTS.md` | `7a236f03ca15` | 21 | unchanged | none |
| `MOD_SETTINGS.md` | `404916bc99a7` | 107 | unchanged | none |
| `AUDIT.md` | `0ac039d38c76` | 279 | diff (5 added lines, read whole) | `prepublished` needs gallery ready, candidates named `<n>-candidate-<name>` under 2 MB each, 8 MB total; WSL mods removed after last ticket; non-regression passes go last; what mod does not modify not tested. Applied in `TESTING.md`, `PUBLICATION.md`, `STATUS.md` |
| `PUBLISHING.md` | `cffd8d0f5688` | 799 | diff (17 lines) + « Images » section whole | two publication modes (this mod: CI, now stated in `PUBLICATION.md`); gallery = one story of staged photos in shared Sanctuary location; capture opened, anomalies go to Pickle Tools; minimal `Art/` set + `Art/Preview.config.json`; every image under 2 MB, folder under 8 MB |
| `TRANSLATIONS.md` | `491f88e5eb3b` | 225 | diff | review file generated by `scripts/Make-FrenchReview.ps1`, first line `# French review - <mod name>`: done |
| `STYLE_RIMWORLD.md` | `0c551b87ac4d` | 729 | diff, Preview + ModIcon sections | renderer writes `ModIcon.png`, Preview, gallery's `0-`, both `.ico`; owner alone produces `ModIcon-source.png`: regenerated |
| `WORKSHOP_COMMENTS.md` | `20d353368495` | 166 | diff skimmed | only other mods' rows changed; this mod's row 3292446841 unchanged |
| `scripts/SEARCHING.md` | `cde797ddcdbc` | 228 | not read | not useful here (as before) |
| `PickleTools/README.md` | `d1749f3baf4a` | 91 | not read | not needed beyond `docs/` below |
| `PickleTools/Headless/README.md` | `2310bb974f68` | 509 | unchanged | none |
| `PickleTools/docs/steps.md` | `148568ab65bb` | 409 | not read | staging steps summarised by `docs/STAGING.md` |
| `PickleTools/docs/STAGING.md` | `67631d23877c` | 79 | whole | step list for staged photos (colonist, decor, camera, animals, hour, weather) |
| `PickleTools/docs/GALERIE.md` | `5109bde96425` | 123 | whole | shared Sanctuary location, steps, one-story rule, dependency map, joining Pickle Tools (via Ticket Manager when unreachable), no new place without asking |
| `PickleTools/docs/SANCTUAIRE-LIEUX.md` | `0f90448179bf` | 228 | whole | every named Sanctuary place, used to pick locations for mod's gallery |
| `GALLERY-PROPS.md` | `575ed37198f8` | 69 | whole | props played for staged animal photos |
| `EXTERNAL_TOOLS.md` | `a3cbd816207f` | 138 | not read | not about this mod |
| `Rimworld-Release-Admin/docs/OPERATIONS.md` | `d3ea56ae977b` | 128 | diff | private local-publication path (`publish-local.sh`); this mod publishes by CI |
| `Rimworld-Ticket-Dispatcher/docs/WELCOME.md` | `a35fb8cfef5a` | 159 | diff | priority, size (`-Tests`), request batching, worker waits while owner's Windows game runs |
| `Rimworld-Ticket-Dispatcher/docs/SUBMIT.md` | `a301c2fe7594` | 169 | diff | ticket fields (`Priority`, `Tests`, `NoBatch`, `Stage` set by Ticket Manager); name filter written `::<title>` |

Not useful, don't re-read unless task depends on it: `scripts/SEARCHING.md`, `EXTERNAL_TOOLS.md`,
`PickleTools/README.md`, `PickleTools/docs/steps.md`, `WORKSHOP_COMMENTS.md` (this mod's row only).