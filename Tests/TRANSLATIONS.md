# Translation maintenance

Run the translation gate whenever UI code, Defs, patches or language resources change.
Reset affected `localization`, `translation_en` and `translation_fr` fields in `STATUS.md`
to `unchecked` until revalidation. Historical stages do not bypass this gate.

```powershell
pwsh -NoProfile -File Tests/Run-All.ps1
```

This builds the mod, runs the contract checks, then runs the shared
`../../scripts/Check-Translations.ps1` (`-ModRoot` this mod). It checks that every Def text
has a French injection, plus stale and duplicate entries, formatting tokens and Keyed use.
The mod keeps no local translation checker or inventory since 2026-10-11 (owner rule on local scripts).

The original `SZ_CannotReachBuildingToExtractGene` key is retained for compatibility, with
no active call site; `Run-All.ps1` passes it to `-AllowUnused`.

`TextMote_Dodge` is a vanilla RimWorld Keyed key that `Source/ProjectileImpact_Patch.cs` calls
with `.Translate()`; the game supplies its text, so this mod ships no entry for it.
`Run-All.ps1` passes it to `-VanillaKeyed`.

## Manual source audit

Automated checks are safeguards, not a general proof of localization. Reinspect every
player-facing call site and XML field when the source changes, including strings constructed
through helpers or parameters. In this version:

- Ability gizmos use their translated AbilityDefs. Incident workers use translated incident
  fields, including `BeastClass.label` and `BeastClass.text`, both marked `[MustTranslate]`.
- `DebugActions.LocalizedAction` is the only dynamic Keyed helper. Its four literal call-site
  keys are explicitly recognized by the checker; its category and messages use `.Translate()`.
  The yielder supplies localized nodes because vanilla debug attributes do not translate
  their constant category/name arguments. Internal node paths use stable keys.
- `Singleton.BeastFor` resolves a saved beast's pawn kind back to the current incident Def,
  so newly sent letters use the current language rather than serialized old text.
- `TextMote_Dodge` is the sole directly reused vanilla Keyed call. Corpses, meat and generated
  crafting recipes use vanilla label templates; combat reports use the vanilla maneuver
  grammar referenced by the Defs. Check those dependency resources when changing the references.
- No mod patches, optional content or LoadFolders exist. The inventory walks this mod's
  `Defs/` after resolving inheritance; it is deliberately not a general multi-mod exporter.
  Add explicit handling before introducing alternate load roots or generated text resources.
- String-list translation inventory is not implemented: an encountered `[MustTranslate]`
  string list fails explicitly. No such mod field exists at the audited revision.
- IDs, asset paths, save keys and technical logs remain untranslated. About metadata and
  repository documentation are outside the in-game text gate. The unused condition-letter
  comp already exposes a `[MustTranslate]` field and has no active XML instance.

Inspect the checker output. Any `UNVERIFIED`, unknown type, unsupported
patch or unresolved target in the injection check prevents certifying the affected coverage,
even if that checker's exit code is zero. Add explicit third-party targets if needed.

## In-game evidence

Record static results in `STATUS.md`, with the audited revision/files and date. `complete`
means ready for in-game testing. Keep the language display checks from `TESTING.md` in
`remaining` as `unverified` until performed, including a save created in each language and
loaded in the other. Never infer successful rendering, grammar or layout from XML validity.
