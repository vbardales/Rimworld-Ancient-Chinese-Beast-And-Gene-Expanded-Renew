# XML validator snapshot

These six scripts were copied from the local `rimworld/scripts` collection on 2026-09-12.
`upstream.json` records each source path and SHA-256 before local changes. They are versioned
here so a fresh checkout has everything needed; no sibling checkout, symlink or download is used.
They are development tools outside `Mod/`, so the Workshop upload does not include them.

Local changes: `Check-XmlClasses.ps1` and `Check-DefRefs.ps1` now return exit code 1 when they
report findings, and 0 on success. The original scripts printed findings without failing the
process. `Run-All.ps1` runs each checker in its own PowerShell process and propagates failures.
The class-name index is generated from the installed game and freshly built mod at each run,
inside `.build/`; no game assembly or stale type-name list is added to the repository.

To update: obtain a reviewed version of the shared scripts, compare it to this snapshot, retain
the exit-code fixes, update `upstream.json`, and run `Tests/Run-All.ps1`. Review validator changes
against their documented limitations; a green static run cannot replace the in-game scenarios.
For multiple consuming repositories, a dedicated shared-tool repository with pinned versions
would avoid maintaining copies. Until that exists, this snapshot is the reproducible source.
