# Protocols read, and in which version

What the session of this mod read of the workspace documents, on **2026-10-01** (about 04:45 to 05:30), at the owner's
request, for the audit of that day (`STATUS.md`). It replaces the note of 2026-09-25: every protocol file had changed
since (all hashes differ), and a rule or two that this mod had followed had moved.

A version is the last commit that touched the file **in the repository that holds it**, then the first 12 characters
of the SHA-256 of the file **as read**. A file whose hash no longer matches has changed and is read again before it is
relied on; one whose row says "not useful" is not read again unless a task depends on it. The protocol documents
(`AGENTS`, `AUDIT`, `PUBLISHING`, `TRANSLATIONS`, `STYLE_RIMWORLD`, `MOD_SETTINGS`, `WORKSHOP_COMMENTS`,
`scripts/SEARCHING`) belong to `vbardales/Rimworld-protocols` (git dir `../rimworld-protocols.git`, work tree = the
collection folder, HEAD `c105a43` when read): `git log` from the monorepo returns the commit that removed them, so the
versions below come from that git dir. `PickleTools`, `Rimworld-Release-Admin` and `Rimworld-Ticket-Dispatcher` are
repositories of their own (HEAD `b7620cb`, `b70348b`, `ae69394`). Read whole, line by line, unless a row says otherwise.

## The collection's documents

| Document | Version | SHA-256 (12) | Lines | Useful here? |
|---|---|---|---|---|
| `AGENTS.md` | `7fd7475`, 2026-09-29 09:37 | `7a236f03ca15` | 21 | **Yes.** The evidence rule (keep the latest report per scenario, one text line per run in `docs/runs/`, delete the archive of one's own run, never a report a `STATUS.md` field points to), publishing by CI. Read as it stands in the session's context |
| `AUDIT.md` | `7fd7475`, 2026-09-29 09:37 | `0fb60fdf8c87` | 274 | **Yes, the reference.** The chain; step 9 `done -> tested` (no `@wip`, every `@requires` played with its report read, no manual test left); step 12 (the audit goes down to the last proven state, `workflow_stage`, the session title); the Pickle rules (the request carries no SHA, small tickets, `exitReason` first, two passes at least); the `.dds` and evidence rules |
| `MOD_SETTINGS.md` | `b83933b`, 2026-09-23 20:46 | `404916bc99a7` | 107 | Only §1 and §5, to justify `settings_audit: not_applicable` (this mod has no settings). The rest is for mods that have some |
| `PUBLISHING.md` | `02394c0`, 2026-10-01 04:41 | `d65e0afcefb2` | 785 | **Yes.** New since 09-25 and used: the four animal integrations (rule completed today), the pull request to an origin repository (systematic, in `BACKLOG.md`, public so only with Virginie's word), the gallery's `0-` image and the Preview carrying the ModIcon, the description's single Markdown source. Not useful here: the git-incident history, repository topics, junctions, the `RimWorks/mod-ci` review |
| `TRANSLATIONS.md` | `c105a43`, 2026-10-01 05:15 | `e5197820fda1` | 213 | **Yes.** Plurals (2026-09-25), the neutral o-series and the three-segment switch, the French review file (`FRENCH_REVIEW.md`, owner only closes `translation_fr`). This mod has no French text that agrees with a pawn and no counted key |
| `STYLE_RIMWORLD.md` | `c105a43`, 2026-10-01 05:15 | `d536a6addedd` | 682 | **Partly.** The engraved-text section, the ModIcon cutout and the gallery's image 0, to judge the committed Preview. The image-prompt blocks, the palette measures and the `ModIcon` generation are of no use: this session generates no illustration and never a ModIcon |
| `WORKSHOP_COMMENTS.md` | `7fd7475`, 2026-09-29 09:37 | `3fb37586f04b` | 159 | Only the register row 3292446841 (the original, `drafted`, to post after the item is public) and the method. The other rows are other mods'. Read before drafting a comment, not otherwise |
| `scripts/SEARCHING.md` | `50de695`, 2026-09-28 21:04 | `013075b06b89` | 222 | **No.** Searching the mod corpus; this mod needed three bounded reads of single mod folders (Dogs mate, Better Crossbreeding, the original), not a corpus search. Not read again |
| `PickleTools/README.md` | `ff20d89`, 2026-09-29 10:19 | `a18a07fd2365` | 88 | Partly. The tool table and the pass-map line; the tools themselves are not used by this mod's suite beyond its own steps |
| `PickleTools/Headless/README.md` | `ed4e73a`, 2026-09-26 22:52 | `2310bb974f68` | 509 | **Yes.** Filter terms, pass maps (`path:` overlays, the trailing newline), `-Then` with `-ThenWithout` (a candidate for M9), evidence copying, exit codes, the traps |
| `PickleTools/docs/steps.md` | `da7c3b0`, 2026-09-28 20:22 | `df2b37a6aff2` | 262 | Partly. None of its 110 steps spawns a beast; this mod has its own steps. Generated, not edited. Read again only to write a step |
| `Rimworld-Release-Admin/docs/OPERATIONS.md` | `3c03f51`, 2026-09-26 23:20 | `23fcf6423000` | 112 | **Yes for the publication** (dry-run of the exact commit, full SHA, only Virginie approves, the first-publication path, what a publish sends). Nothing to do with it before `tested` |
| `Rimworld-Ticket-Dispatcher/docs/WELCOME.md` | `77ca9d7`, 2026-09-27 23:26 | `08b440a03f74` | 150 | **Yes.** Which test to play, pass maps, no watcher, no SHA in a request, `summary.json` and `junit.xml` are what an evidence folder keeps, the `desktop.ini` warning for `Mod/`, where to write the versions read |
| `Rimworld-Ticket-Dispatcher/docs/SUBMIT.md` | `d07b2b8`, 2026-09-26 18:25 | `eaca3969c7eb` | 133 | **Yes.** Every option of `Submit-PickleRun.ps1`, the launcher's exit codes. Needed for the final pass |

`EXTERNAL_TOOLS.md` is not on the list and was not read.

## This repository's documents

| Document | Version | State | Note |
|---|---|---|---|
| `STATUS.md` | `67a4b37`, 2026-09-30 17:04 | modified, not committed | Read whole; the 2026-10-01 audit was written into it |
| `README.md` | `70feeae`, 2026-09-25 20:55 | modified, not committed | Read whole; its Testing paragraph said the 28 scenarios had not been executed, corrected |
| `CHANGELOG.md` | `70feeae`, 2026-09-25 20:55 | clean | Read whole; `## [1.0.0] - unreleased` above `## [0.1.0] - 2026-09-23`, whose entry says "Creation of the `PublishedFileId.txt` file". Left as it is |
| `ATTRIBUTION.md` | `70feeae`, 2026-09-25 20:55 | modified, not committed | Read whole; gained the source repository found today and a corrected "what is not covered" paragraph. `Mod/ATTRIBUTION.md` recopied, byte-identical (SHA-256 compared) |
| `LICENSE` | `c718af2`, 2026-09-20 11:15 | clean | Read whole, not touched (`Mod/LICENSE` is identical) |
| `PUBLICATION.md` | `b50919b`, 2026-09-26 17:34 | modified, not committed | Read whole; its status line said the CI did not read it yet, corrected |
| `TESTING.md` | `70feeae`, 2026-09-25 20:55 | modified, not committed | Read whole; counts, pass 3 and the `tested` conditions updated |
| `BACKLOG.md` | `e8b22b0`, 2026-09-25 22:30 | modified, not committed | Read whole; the pull-request entry added |
| `docs/runs/` | README `704316f`; day files `abaa862`, `bbf5a63`, `42f03ed`, `67a4b37` | README modified, `2026-10-01.md` new | All read; README rewritten (what to keep, the evidence map) |
| `Tests/Pickle/README.md` | `8703ff2`, 2026-09-28 00:08 | modified, not committed | Read whole; features 17 to 22, the state of M1 to M9, pass 3 |
| `Tests/Pickle/` features and steps | `bea3e9e`, 2026-09-29 15:36 | clean | **Partly read**: features 17 to 22 whole, the head of 04, the counts of all 22 by a script; `Check-Steps.ps1` run. The 16 others not line by line: their content is known from the README and the reports |
| `Mod/About/About.xml` | `19e649d`, 2026-09-27 23:22 | clean | Read whole; matches `PUBLICATION.md` (`sync-about-description.mjs`) |
| `docs/MANUAL-TESTS.md` | `17b3fbb`, 2026-09-26 22:46 | modified, not committed | Read whole; it was in French, rewritten in English with the state of M1 to M9 |
| `FRENCH_REVIEW.md` | `20bee84`, 2026-09-30 14:25 | clean | Header only; it is the owner's to read, and the French files have not changed since it was generated |

`NOTES.md` and `BUGS.md` do not exist in this repository.

## What the reading turned up, for this mod

- **The 2026-09-25 note's open item is closed:** `PUBLICATION.md` exists. **New items:** the four animal integrations
  (Dogs mate and Better Crossbreeding recorded as not applicable, with their reasons, in `STATUS.md`); a source
  repository of the original, `MonsterTower/AncientChineseBeast`, in `upstream_mod_remotes`, and the pull request
  entry in `BACKLOG.md`; `workflow_stage` and the session title `ancientchinesebeastandgeneexpanded / done`.
- **The evidence rule moved:** keep `summary.json` and `junit.xml`, never `report.html`, `messages.ndjson` or
  `Player.log`. This session deleted `summary.json` from the 26 kept folders before reading that line in `WELCOME.md`
  again; `docs/runs/README.md` and `STATUS.md` record it.
- **A request carries no SHA:** the final pass writes the SHA in `-Label` and leaves the tree still until `RUN_DONE`.
  Today the working tree is not still: another session is regenerating `Art/` and `Mod/About/Preview.png`.

## Update of 2026-10-08

The owner asked for the documents to be read again. Every protocol file but `AGENTS.md`, `MOD_SETTINGS.md` and
`PickleTools/Headless/README.md` had changed (hash compared with the table above). **How each was read matters:** a
changed file was read **by its diff against the version read on 2026-10-01** (`git log`/`git diff` in the repository that
holds it), not whole, unless the row says "whole". Hashes are the first 12 characters of the SHA-256 of the file as it
stands. Protocols repository HEAD `bc206b5`; `PickleTools` `ed45974`, `Rimworld-Release-Admin` `657951b`,
`Rimworld-Ticket-Dispatcher` `964b790`.

| Document | SHA-256 (12) | Lines | Read | What it changed here |
|---|---|---|---|---|
| `AGENTS.md` | `7a236f03ca15` | 21 | unchanged | none |
| `MOD_SETTINGS.md` | `404916bc99a7` | 107 | unchanged | none |
| `AUDIT.md` | `0ac039d38c76` | 279 | diff (5 added lines, read whole) | `prepublished` needs the gallery ready, candidates named `<n>-candidate-<name>` under 2 MB each and 8 MB in all; the WSL mods are removed after the last ticket; non-regression passes go last; what the mod does not modify is not tested. Applied in `TESTING.md`, `PUBLICATION.md`, `STATUS.md` |
| `PUBLISHING.md` | `cffd8d0f5688` | 799 | diff (17 lines) and the « Images » section whole | two publication modes (this mod: CI, now said in `PUBLICATION.md`); the gallery is one story of staged photographs in the shared Sanctuary location; a capture is opened and anomalies go to Pickle Tools; the minimal `Art/` set and `Art/Preview.config.json`; every image under 2 MB, the folder under 8 MB |
| `TRANSLATIONS.md` | `491f88e5eb3b` | 225 | diff | the review file is generated by `scripts/Make-FrenchReview.ps1`, first line `# French review - <mod name>`: done |
| `STYLE_RIMWORLD.md` | `0c551b87ac4d` | 729 | diff, the Preview and ModIcon sections | the renderer writes `ModIcon.png`, the Preview, the gallery's `0-` and both `.ico`; the owner alone produces `ModIcon-source.png`: regenerated |
| `WORKSHOP_COMMENTS.md` | `20d353368495` | 166 | diff skimmed | only other mods' rows changed; this mod's row 3292446841 unchanged |
| `scripts/SEARCHING.md` | `cde797ddcdbc` | 228 | not read | not useful here (as before) |
| `PickleTools/README.md` | `d1749f3baf4a` | 91 | not read | not needed beyond `docs/` below |
| `PickleTools/Headless/README.md` | `2310bb974f68` | 509 | unchanged | none |
| `PickleTools/docs/steps.md` | `148568ab65bb` | 409 | not read | the staging steps are summarised by `docs/STAGING.md` |
| `PickleTools/docs/STAGING.md` | `67631d23877c` | 79 | whole | the step list for staged photographs (colonist, decor, camera, animals, hour, weather) |
| `PickleTools/docs/GALERIE.md` | `5109bde96425` | 123 | whole | the shared Sanctuary location, steps, one-story rule, map of dependencies, joining Pickle Tools (via the Ticket Manager when unreachable), no new place without asking |
| `PickleTools/docs/SANCTUAIRE-LIEUX.md` | `0f90448179bf` | 228 | whole | every named place of the Sanctuary, used to choose the locations of this mod's gallery |
| `GALLERY-PROPS.md` | `575ed37198f8` | 69 | whole | props that were played for staged animal photographs |
| `EXTERNAL_TOOLS.md` | `a3cbd816207f` | 138 | not read | not about this mod |
| `Rimworld-Release-Admin/docs/OPERATIONS.md` | `d3ea56ae977b` | 128 | diff | the private local-publication path (`publish-local.sh`); this mod publishes by the CI |
| `Rimworld-Ticket-Dispatcher/docs/WELCOME.md` | `a35fb8cfef5a` | 159 | diff | priority, size (`-Tests`), batching of requests, the worker waits while the owner's Windows game runs |
| `Rimworld-Ticket-Dispatcher/docs/SUBMIT.md` | `a301c2fe7594` | 169 | diff | the ticket fields (`Priority`, `Tests`, `NoBatch`, `Stage` set by the Ticket Manager); a name filter is written `::<title>` |

Not useful, not to read again unless a task depends on it: `scripts/SEARCHING.md`, `EXTERNAL_TOOLS.md`,
`PickleTools/README.md`, `PickleTools/docs/steps.md`, `WORKSHOP_COMMENTS.md` (this mod's row only).
