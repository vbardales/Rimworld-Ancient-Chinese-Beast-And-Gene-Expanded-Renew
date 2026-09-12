# Translation maintenance

Run the translation gate whenever UI code, Defs, patches or language resources change.
Reset affected `localization`, `translation_en` and `translation_fr` fields in `STATUS.md`
to `unchecked` until revalidation. Historical stages do not bypass this gate.

```powershell
pwsh -NoProfile -File Tests/Run-All.ps1
```

This builds the mod, runs the existing contract checks, then runs
`Check-Translations.ps1` and `Test-TranslationChecker.ps1`. The translation check first
calls `Get-TranslationInventory.ps1`, which reuses the versioned injection checker's
reflection, XML inheritance and translation-handle rules. It writes
`.build/translation-inventory.json`, then compares every inventoried field against French
and against English source text or English injections. A successful comparison of two
language directories alone would miss a key absent from both.

The 2026-09-13 inventory contains 370 fields across 19 Def types. It includes nested
anatomy, attack tools, thought stages, gene-name symbols, incident extensions and inherited
recipe job strings. There are eight active Keyed entries and one unused legacy entry.
English overrides are limited to 30 fields whose original values are Chinese or bilingual;
all other English values come from the Defs. French has an explicit entry for every field.

`Check-Translations.ps1` checks nonempty values, exact-case keys, duplicates, formatting
parameters, rich-text tags, line-break counts, untranslated CJK text and unreviewed identical
translations. `mingshe`, `qiongqi`, `explosion` and `tunnel` are deliberately identical.
The original `SZ_CannotReachBuildingToExtractGene` key is retained for compatibility, with
no active call site. The four negative controls use isolated copies under `.build/` and
must detect omissions from French, a key omitted from both languages, duplicates and a
changed parameter index. `-UseExistingInventory` is for those isolated resource fixtures;
do not use it to certify changed Defs.

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

Inspect both the checker output and the inventory. Any `UNVERIFIED`, unknown type, unsupported
patch or unresolved target in the injection check prevents certifying the affected coverage,
even if that checker's exit code is zero. Add explicit third-party targets if needed.

## In-game evidence

Record static results in `STATUS.md`, with the audited revision/files and date. `complete`
means ready for in-game testing. Keep the language display checks from `TESTING.md` in
`remaining` as `unverified` until performed, including a save created in each language and
loaded in the other. Never infer successful rendering, grammar or layout from XML validity.
