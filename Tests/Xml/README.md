# XML validators

This mod keeps no local XML validator. `Tests/Run-All.ps1` runs the shared ones from `../../scripts/`
(`Check-XmlClasses`, `Check-DefRefs`, `Check-XmlFields`, `Check-TypeRefs`, `Check-ConfigErrors`, `Check-DefInjected`).

`optional-mod-types.txt` lists the types of the optional mods for `Check-XmlClasses.ps1`. The class-name index is built at
each run, inside `build/`.
