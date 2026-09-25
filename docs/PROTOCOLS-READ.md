# Protocols read, and in which version

What the session of this mod read of the workspace documents, on **2026-09-25** (about 18:00 to 18:40), at the owner's
request, after a context compaction. Every file below was read **whole**, line by line, except where a row says otherwise.
A version is the last commit that touched the file **in the repository that holds it**, then the first 12 characters of the
SHA-256 of the file **as read**. A file whose hash no longer matches has changed and is read again before it is relied on;
one whose row says "not useful" is not read again unless a task depends on it.

Where the documents live: the protocol documents (`AGENTS`, `AUDIT`, `PUBLISHING`, `TRANSLATIONS`, `STYLE_RIMWORLD`,
`scripts/SEARCHING`) belong to the repository `vbardales/Rimworld-protocols` (git dir `Documents\rimworld-protocols.git`,
work tree = the collection folder, HEAD `0743ff9` when read). `PickleTools`, `Rimworld-Release-Admin` and
`Rimworld-Ticket-Dispatcher` are repositories of their own (HEAD `d6d8db1`, `d403592`, `7af1f5a`). All the files read here had
a clean working copy.

## The collection's documents

| Document | Version | SHA-256 (12) | Lines | Useful here? |
|---|---|---|---|---|
| `AGENTS.md` | `3a1d2cb`, 2026-09-24 12:08 | `36631e730433` | 46 | **Yes.** Evidence rule (keep the latest report per scenario, one text line per run in `docs/runs/`, delete the archive of one's own run afterwards, never a report a `STATUS.md` field points to), publishing by CI |
| `AUDIT.md` | `49cd841`, 2026-09-25 17:09 | `f46fe88e5ec0` | 232 | **Yes, the reference.** The stage chain; `done -> tested` (no `@wip`, every `@requires` played, no manual test left); **a request carries no SHA** (the mod is staged when its ticket is played, from the working tree of that moment: keep the tree still until `RUN_DONE`, and write the SHA in `-Label`); small tickets (a fix plays the fewest scenarios, an initial or final pass plays all); no watcher, no `Monitor`, no cron; `exitReason` before any count; two passes at least, one more per incompatibility; fail fast before a `publish` |
| `PUBLISHING.md` | `0743ff9`, 2026-09-25 17:52 | `d3660c50cf84` | 683 | **Yes, for the publication.** Description is sent once; `THANKS` must name every integration exercised (so Animal Prosthetics 2's author) and link each named mod's Workshop page; `PUBLICATION.md` is required; CI path, dry-run first, full SHA, only Virginie approves; commit with a pathspec and read `git status` afterwards |
| `TRANSLATIONS.md` | `b83933b`, 2026-09-23 20:46 | `3368579d01dc` | 100 | Only to justify the three translation fields. The Animal Prosthetics 2 patch adds no player-facing text |
| `STYLE_RIMWORLD.md` | `7311308`, 2026-09-25 15:50 | `de13cbe5e1f9` | 484 | **Partly.** Only the engraved-text section applies here (title, tag, rule, summary, badge; `Art/preview-palette.json` holds the five colours). The image-prompt blocks are of no use: this session generates no illustration and never a ModIcon |
| `scripts/SEARCHING.md` | `372c447`, 2026-09-23 21:01 | `9dbd52b2bcd4` | 168 | **No.** Searching the mod corpus; this repository never needs it, and the owner asked that it not be searched by hand |
| `PickleTools/README.md` | `2b7b6d0`, 2026-09-25 17:22 | `6ea974180eb8` | 84 | Partly. The tool table, and that `Elsewhere/` lists steps that live in one mod's repository: look there before writing a step a second time |
| `PickleTools/Headless/README.md` | `b2712fc`, 2026-09-25 15:03 | `988dbf0dcee7` | 487 | **Yes.** Filter terms, `-DepMap` lines (`path:` overlays activate in file order, which is how this mod is put before another one), exit codes, evidence copying, the traps (default step timeout 5 s, built-in waits, screenshot names 183 characters long) |
| `PickleTools/Docs/steps.md` | untracked in git | `61750eca84d2` | 217 | Partly. The steps of the tools; none of them spawns a pawn. Generated, not to be edited |
| `Rimworld-Release-Admin/docs/OPERATIONS.md` | `d403592`, 2026-09-25 16:33 | `6f556de4bbf7` | 207 | **Yes for publishing.** Dry-run of the exact commit, the documented mode (`CHANGELOG.md` section `## [<version>]` and the fenced block under `### <version>` of `PUBLICATION.md`), what a publish sends, credentials. The rest is for other mods |
| `Rimworld-Ticket-Dispatcher/docs/WELCOME.md` | `79668cc`, 2026-09-25 17:16 | `b9f93a680f17` | 97 | **Yes.** Which test to play, the pass maps, no watcher, no SHA in a request, how to delete an archive that MAX_PATH refuses, and where to write the versions read |
| `Rimworld-Ticket-Dispatcher/docs/SUBMIT.md` | `79668cc`, 2026-09-25 17:16 | `9ac5e37bb64c` | 131 | **Yes.** Every option of `Submit-PickleRun.ps1`, the launcher's exit codes, examples |

Not read: `MOD_SETTINGS.md`, `EXTERNAL_TOOLS.md`, `WORKSHOP_COMMENTS.md` (not on the list; `AUDIT.md` and `PUBLISHING.md` name
them, and `WORKSHOP_COMMENTS.md` is to be read before the thanks comments of a publication).

## This repository's documents

Written or edited by this session, so not re-read line by line; their state when this note was written:

| Document | Version | SHA-256 (12) | Note |
|---|---|---|---|
| `STATUS.md` | `e6427ef`, 2026-09-25 12:30 | `b3f516712b7c` | **Working copy modified, not committed**: the Animal Prosthetics 2 result |
| `README.md` | `ca985d6`, 2026-09-13 01:34 | `9348a1f5653f` | Gained the Animal Prosthetics 2 paragraph on 2026-09-25 (after this version) |
| `CHANGELOG.md` | `e6427ef`, 2026-09-25 12:30 | `14bf119ebca9` | Headings follow the CI since 2026-09-25 (`## [1.0.0] - unreleased`, `## [0.1.0] - 2026-09-23`); the version listed is from before that edit |
| `ATTRIBUTION.md` | `ca985d6`, 2026-09-13 01:34 | `f38af3d7f1b6` | Credits Animal Prosthetics 2, Pickle and RimLogging since 2026-09-25 (after this version) |
| `LICENSE` | `c718af2`, 2026-09-20 11:15 | `d58493ff168b` | |
| `TESTING.md` | `aa70b21`, 2026-09-24 20:47 | `a7b57f30976e` | 29 scenarios (block H added) |
| `Mod/About/About.xml` | `aa70b21`, 2026-09-24 20:47 | `b57da0e04843` | Links and thanks Animal Prosthetics 2, links the original mod, thanks Pickle and RimLogging since 2026-09-25 (after this version) |
| `Tests/Pickle/README.md` | `847f18b`, 2026-09-24 21:05 | `9604e5cbabb5` | |
| `docs/runs/` | `e6427ef` (README) | `4ad6aab1efeb` | `2026-09-24.md`, `2026-09-25.md` |

`BACKLOG.md`, `NOTES.md`, `BUGS.md` and `PUBLICATION.md` do not exist in this repository.

## What the reading turned up, for this mod

- **`PUBLICATION.md` is missing.** `AUDIT.md` requires it at `tested -> prepublished` (screenshot order, thanks comments,
  dependencies, adult-content answers, and the Steam change note under `### <version>` that the CI sends).
- **Thanks and links for Animal Prosthetics 2: done 2026-09-25** in `About.xml`, `ATTRIBUTION.md` (both copies, identical)
  and the README. Still to do: its entry in `WORKSHOP_COMMENTS.md`, and the description on the Steam page, edited by hand
  because it is sent only at creation.
- **Changelog headings: settled 2026-09-25.** The owner chose the CI's format over `# 0.1.0`: `## [1.0.0] - unreleased` and
  `## [0.1.0] - 2026-09-23`, the CI reading the section that starts with `## [<version>]` (`changelog-section.sh`).
- **The engraved text was engraved again on 2026-09-25** to the charter of `STYLE_RIMWORLD.md`: title 34 px, 50 px from the
  left, two lines, the tag, the rule and the badge. Two deliberate deviations (top margin 24 px, summary 330 px, so the
  text stays clear of the beast) are recorded in `Art/PREVIEW.md`.- **Queued requests carry no SHA.** The three requests in the queue when this was written (`5c23`, `fbf9`, `f2fd`) will stage
  the tree of the moment they are played. Future requests write the SHA in `-Label`.
