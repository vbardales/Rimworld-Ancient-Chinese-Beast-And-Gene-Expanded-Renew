# Local XML validators

Two scripts stay here, copied from the shared `rimworld/scripts` collection on 2026-09-12 (`upstream.json` records
their source and SHA-256): `Check-DefRefs.ps1` and `Check-XmlClasses.ps1`. They carry local changes the shared copies
do not have, so this mod keeps them until Audit workflow merges those changes into `scripts/`:

- both return exit code 1 when they report findings, and 0 on success (the shared ones print findings without failing
  the process; `Test-XmlExitCodes.ps1` and `Run-All.ps1` depend on it);
- `Check-XmlClasses.ps1` accepts a comma-separated `-TypeLists` (run through `-File`, an array arrives as one string).

The shared copy of `Check-DefRefs.ps1` is newer on one point (it reads `ThingFilter` category lists); the local copy
lacks it. The other four validators (`Check-ConfigErrors`, `Check-DefInjected`, `Check-TypeRefs`, `Check-XmlFields`)
are run from `../../scripts/` since 2026-10-11 (owner rule on local scripts, `scripts/LOCAL_SCRIPTS.md`).
`optional-mod-types.txt` lists the types of the optional mods for `Check-XmlClasses.ps1`. The class-name index is built at
each run, inside `build/`.
