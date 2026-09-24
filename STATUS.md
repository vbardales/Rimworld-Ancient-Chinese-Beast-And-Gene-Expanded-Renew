---
localization: complete
translation_en: complete
translation_fr: complete
settings_audit: not_applicable
audit_revision: 4871397f5ed3f48a75035b6d090af53039932a62 plus the local preview composition changes recorded below
mod:          Ancient Chinese Beast And Gene Expanded Renew (unofficial)
packageId:    nelim.ancientchinesebeastandgeneexpandedrenew
repo:         Rimworld-Ancient-Chinese-Beast-And-Gene-Expanded-Renew
visibility:   public
detached:     yes
stage:        preTest
licence:      silent
licence_at:   reviewed 2026-09-12 - original files and About.xml, English and Chinese Workshop
            descriptions, all 68 public comments, and the four coauthors' Steam profiles;
            no explicit reuse permission or prohibition found, no source repository link found.
            Local MIT licence covers port additions only; abandonment is not established.
dependencies: declared
showcase:     complete
tested_on:
workshop:     prepublished 2026-09-23, item 3806709132, private, version 0.1.0
remaining:
  - unverified: Tests/Pickle now supplies loading, staged creature-review, save/reload,
      ordinary-beast/Pleiades incidents, chicken crow, nian debug action, representative
      gene/cloning recipes and compiled local steps/features for the three critical 1.6 hooks,
      but still lacks nian/firecracker and scheduling scenarios
  - unverified: never seen running; TESTING.md is the protocol, 28 scenarios, none run
  - unverified: what the 0.1.0 upload carried. It was made from the working folder, where 80 .dds
      files (21 MB) sat beside the PNGs, written by the game 18 minutes earlier. Check the item's
      file list; the first CI upload builds from a checkout and replaces it
  - unverified: English and French display checks, generated names, debug actions and
      save/reload across languages have not been run; see TESTING.md, Translation checks
  - defect: Singleton.nextBeastTimeHours is incremented, reset, and read by nothing. Inherited,
      deliberate, harmless now that no button depends on it
  - defect: CompAbilityEffect_SectorCells caches into a list it fills with itself, so the cache
      branch is unreachable. Inherited, deliberate, costs nothing
  - defect: the keyed string SZ_CannotReachBuildingToExtractGene is referenced from neither the
      C# nor the defs. Inherited, left alone
session:      local_2aa0146a-2f99-4b81-a9c8-6a3572719d9f
updated:      2026-09-24
---

# Ancient Chinese Beast And Gene Expanded Renew — status

Read by a sweep across every mod, rather than by asking each thread in turn. It lives at the
root, never inside `Mod/`, so Steam never receives it.

## Where this one stands

### Prepublication, and what `tested` now requires — 2026-09-24

**The Workshop item exists.** It was created by the first upload on 2026-09-23 at 14:30, from the
working folder: item 3806709132, private, version 0.1.0. `Mod/About/PublishedFileId.txt` is committed
and pushed (`89a2575`) and the remote copy was read back with the same number. Steam froze the name,
the description and the packageId at creation, and the About.xml it received was the one ending in
the GitHub link. `CHANGELOG.md` opens on `# 0.1.0`. Publications from here go through GitHub
Actions: a dry-run for the exact commit first, and only Virginie approves `steam-production`.

**What the upload probably carried that git does not.** 80 `.dds` files, 21 MB, written by the game
beside the PNGs on 2026-09-23 at 14:12. They were never tracked and are ignored now; a CI upload
builds from a checkout and will not carry them. The item's actual file list has not been read, so
this is a consequence of the timestamps, not an observation.

**`stage` stays `preTest`.** Three conditions must all hold before a mod can be `tested`:

1. no scenario tagged `@wip`;
2. every scenario that depends on a condition (`@requires:`) has run;
3. no manual test left to validate, every one green.

| Condition | This mod |
| --- | --- |
| No `@wip` | Holds for the eight features written: none carries the tag, they carry `@review` only |
| Conditional scenarios have run | Nothing to run: the mod has no optional integration. The declared incompatibility with `andery233xj.AncientChineseBeast` still needs a pass of its own, and it is not written |
| No manual test to validate | Not met. No manual exception is recorded in `Tests/Pickle/README.md`, so it is the suite that blocks: 12 scenarios written against the 28 planned in `TESTING.md`, and none of them run |

Nothing counts until the suite has been run, so `tested_on` stays empty and a green static run does
not move `stage`. The first run also has to be made twice, English and French.

**Evidence** stays on disk and out of git. `docs/runs/README.md` says which proofs of a run to keep
and in what form. None exists yet: no Pickle report of this mod is in the shared folder or in the
runner's archive.

**Queue tickets.** A Codex heartbeat is what a Claude session does with a watcher, the Monitor tool,
on its ticket. The suite is not ready to take one: its README says it must not be run before the
nian/firecracker and scheduling scenarios exist.

### Ordered workflow audit — 2026-09-22

**Result: `done` -> `preTest`.** The actual distributed `Mod/About/About.xml`
now ends with the exact final
`[url=https://github.com/vbardales/Rimworld-Ancient-Chinese-Beast-And-Gene-Expanded-Renew]Source code on GitHub[/url]`
link, after the adoption clause. `Tests/Check-Content.ps1` passed all 262 checks after this
metadata-only correction, and a direct XML check confirmed the exact ending. The raw repository
URL earlier in the prose and the separate `<url>` field remain supplemental; the final BBCode link
satisfies the mandatory `Preview generated -> preOptions` criterion. No publication occurred.

The current `stage: preTest` uses the workflow destination name directly. The metadata correction
does not invalidate the passing settings, localization, dependency, test-plan or automated-test
checks, but the mandatory Pickle suite was not present when this repository was rechecked. The
existing 28 manual scenarios are a useful behavior inventory, not the required automated staging
that produces captures or films for human review.

Independent later evidence remains valid but cannot complete `preTest -> done` without that suite:
the 2026-09-22 run of `Tests/Run-All.ps1` passed after the sandbox-only SDK access failure was
retried with the locally installed SDK available. It rebuilt the delivered DLL with the recorded
SHA-256 `5F38C06080A1E04AEE40FA6448EE430FCBE7D1D8CF73E87AE34534EA8676769D`, passed 262 content
checks, five content negative controls, 26 assembly contracts, all XML/configuration validators,
and the EN/FR translation checks and their negative controls. The mod itself was not launched.

The preview was recomposed from the preserved `Art/Preview.png`, without regenerating its
illustration. `Art/preview-layout.json` now selects the calm lower-right ground so the copy and
veil no longer cover the beasts in the upper half; `Art/preview.html` and
`Art/render-preview.cjs` support that explicit position. The delivered `Mod/About/Preview.png`
was rendered at 896x504, directly inspected at that size and at 268 px, and is 575625 bytes.
The fresh QA report records Segoe UI without fallback, a two-line title, no out-of-frame text or
badge overlap, and minimum contrast of 8.29:1 for primary title text, 7.24:1 for the suffix,
6.78:1 for the tag, 8.58:1 for the summary and 5.03:1 for the badge. The common style guide now
requires choosing the upper-left or lower-right calm zone that leaves the subject unobscured,
rather than imposing upper-left placement.

**Strictly necessary next transition:** complete the `Tests/Pickle/` companion. Its initial
loading, fixed-cell creature-review, save/reload, ordinary-beast/Pleiades incidents and the three
critical 1.6-hook features, chicken crow, the nian debug action and representative gene/cloning
recipes are present and the local step DLL compiles. It still needs self-staging features for
nian/firecracker and scheduling. Each scenario must set up the relevant beast, pawn, corpse,
research or save state itself; assert what can be asserted; then make only a bounded `@review`
capture or film available for human judgment. The minimal pass must run in English and French.
There are no optional integrations to add to a second pass, and the declared upstream
incompatibility needs its own documented review pass. Only after that suite is complete can
`preTest -> done` be revalidated; its execution and media review remain `done -> tested` work.

### Ordered workflow audit — 2026-09-13

**Result: `done` -> `done`.** This is a fresh audit of the working tree, not an inference
from the historical stage. The user's ordered workflow takes precedence over the parent
documents: the options gate does not require in-game interaction when source inspection
justifies no settings. `done` is readiness for final gameplay validation; it is not `tested`.

Scope: this autonomous Git repository, with the distributed root at `Mod/`. Audited HEAD:
`4871397f5ed3f48a75035b6d090af53039932a62`. Existing local changes covered CHANGELOG,
README, STATUS, TESTING, the delivered DLL, DebugActions.cs, Singleton.cs, English Keyed,
and Tests/Run-All.ps1. Untracked work comprised English DefInjected, French resources,
Check-Translations.ps1, Get-TranslationInventory.ps1, Tests/TRANSLATIONS.md and
Test-TranslationChecker.ps1. All were included in the audit and preserved. No commit,
publication, feature change or image generation was performed.

Evidence is retained in `.build/audit-2026-09-13/`: `working-tree-before.txt`,
`audited-files.json` (SHA-256 inventory of Mod, Source and Tests), `dll-before.txt`,
`run-all.log` (sandbox access failure), `run-all-unrestricted.log` (successful full run),
and directly inspected 32 px / 268 px image reductions. Earlier narrative and test logs
remain historical evidence; the following results describe this audit.

| Transition destination | Result | Evidence and limits |
| --- | --- | --- |
| horsMonoRepo | Validated | `git rev-parse --show-toplevel` identifies this repository. `git ls-remote origin HEAD` returns the audited HEAD; `gh repo view` confirms PUBLIC and main on the configured GitHub repository. Names follow the Renew/unofficial convention without requiring literal equality. English documentation exists; root/distributed LICENSE and ATTRIBUTION copies have identical SHA-256 hashes. |
| ModIcon generated | Validated | Development deliverables present; mod build succeeded with zero warnings/errors and the delivered DLL remained byte-identical. Icon directly inspected at 128 px and 32 px: PNG, 27059 bytes, single orange winking beast mascot, dark background, legible silhouette, no text. |
| Preview generated | Validated | Delivered PNG directly inspected at 896x504 and 268 px; 612132 bytes. Overhead ground scene, restricted palette, winged beast and firecrackers, no concrete camera defect. A historical generation report or recorded comparison with a game screenshot is not required. |
| preOptions | Validated | English description; exact title order/case, reduced And and Renew, separate unofficial tag and 1.6 badge. Red accent is visually distinct from the ochre secondary ink. Art/preview.html reads the saved palette and layout. Existing contrast/font measurements are retained, not claimed as rerun measurements. |
| options | Not applicable, justified | Settings inventory and access checks below establish no relevant settings, empty page or shortcut. |
| l10n | Validated, static | 370 Def fields and nine Keyed entries checked, zero failures; 702 injection paths checked, zero errors. Four translation negative controls passed. Source call sites, dynamic debug keys, incident fields and representative EN/FR wording reviewed. English Def source values provide native coverage where appropriate. |
| preTest | Validated | Harmony and Biotech are used and declared, with appropriate loadAfter entries. The ChineseComprehensiveExpansion entry is optional ordering only: no source/Def dependency found. No LoadFolders, conditional content or mod patches. No missing Def/type reference found. No RIMMSQOL dependency is needed. |
| done | Validated | Tests/Run-All.ps1 completed with exit 0: builds, 262 content checks, 26 assembly contracts, six XML/translation/configuration validators and eleven negative controls passed. TESTING.md provides 28 manual scenarios, setup/actions/expected results and EN/FR checks, including new colonies and existing saves. |
| tested | Unverified | No gameplay session executed or supplied for this working tree. Logs, EN/FR display, gameplay, save/reload and new/existing-save scenarios remain unverified. Installed game assemblies establish static compatibility only. |

The exact `stage` value `done` maps to **done** in the requested chain:
`dansMonoRepo -> horsMonoRepo -> ModIcon generated -> Preview generated -> preOptions ->
options -> l10n -> preTest -> done -> tested`. Older vocabulary below is historical;
`port` and `showcase` alone do not certify a precise gate in this chain.

#### Settings audit

`settings_audit: not_applicable`, established against the 74 source files and distributed
Defs. There is no Verse.Mod settings implementation, ModSettings/GetSettings,
SettingsCategory/DoSettingsWindowContents, MainButtonDef or MainTabWindow settings route.
The inventory includes Singleton's normal 1% daily roll and sixty-day gate, Sexie's
fifteen-day schedule, annual nian event, combat/ability values, extraction/cloning recipes
and the four debug actions. These are the inherited gameplay design and developer test
controls, not an existing player configuration that has been left accessible only in XML.
No documented player configuration requirement or unfinished settings feature was found.
Exposing balance constants would add new customization scope, so no option is invented.

There is consequently no defaults/input/reset/application-time/settings-persistence or
shortcut integration test to run. Saved gameplay state is covered separately by the manual
scenarios. No RIMMSQOL or other customization integration was tested or certified.
The mandatory source check establishes absence of both an empty page and a shortcut.

#### Verification details and limits

The first test invocation stopped at MSBuild because sandbox permissions denied access to
the installed Microsoft SDK directory; this was an environment failure, not a mod defect.
The authorized retry completed the whole suite against RimWorld assembly 1.6.9676.17735.
Delivered DLL SHA-256 before and after the build:
`5F38C06080A1E04AEE40FA6448EE430FCBE7D1D8CF73E87AE34534EA8676769D`.
The XML run resolved 82 class references, checked fields in 52 files, resolved Def references
and parents, and checked 133/133 configuration Defs using 26 rules. The external-type
checker's ambiguous lordJob/targetType/type element names are absent from the mod XML.
Its passing result does not prove arbitrary runtime ConfigErrors or gameplay behavior;
the log explicitly describes its static limits. No artificial gameplay pass is inferred.

The recorded rights classification remains `silent`: no third-party licence is invented,
and MIT explicitly excludes original content. The earlier 2026-09-12 source-rights review
is retained; Workshop comments and author profiles were not re-audited live in this run.
This classification records the evidence available, not permission or proven abandonment.

#### Remaining work, distinguished from optional recommendations

- **Next gate, done -> tested (unverified):** execute all applicable TESTING.md scenarios in
  game, inspect logs and EN/FR UI, cover a new colony and existing saves, and rerun affected
  regression checks after any fixes. No settings/shortcut runtime test is applicable.
- **Publication-only defect:** About.xml currently provides raw repository URLs but lacks
  the final `[url=...]Source code on GitHub[/url]` required by PUBLISHING.md. Correct that
  before publication; it does not change the user's English-description/naming gate or
  constitute a failure of the gameplay-readiness stage. Nothing was published here.
- **Documentation cleanup completed — 2026-09-13:** LICENSE/ATTRIBUTION now describe the
  recorded 2026-09-12 review without implying abandonment or reuse permission. MIT remains
  limited to the listed port additions. Both distributed copies were synchronized and
  verified byte-identical to their root counterparts. This documentation-only follow-up
  leaves `stage: done` and the independent code, XML, translation and image checks unchanged;
  the audit's file-hash inventory predates these documentation edits.
- The inherited dead counter, ineffective cache and unused Keyed entry below were confirmed
  by source inspection. They do not establish a failed gameplay test. The counter is read
  for its own increment and serialization, but not used to decide scheduling; historical
  shorthand such as “read by nothing” should be understood in that narrower sense.

The following sections retain the previous audit history.

The port is finished and nothing about it is waiting on a decision. What it is waiting on is a
game.

- **The code.** Nine Harmony patch targets, all resolving against 1.6. `Tests/` asserts that on
  every run, along with the parameter binding and the overrides, and both of its failing states
  were reproduced before it was trusted. On 2026-09-12, 26 assembly checks passed against
  game assembly 1.6.9676.17735, including explicit presence checks for the three critical hooks.
- **The XML.** All six versioned checkers in `Tests/Xml/` pass: fields, classes, def references,
  third-party type references, translation keys and configuration consistency. There are also
  262 passing content checks and eleven passing negative controls. Run `Tests/Run-All.ps1` to
  rebuild and repeat the checks; no scripts from the parent repository are needed.
- **The showcase.** `Mod/About/Preview.png` recomposed in HTML/CSS at 896x504 according to
  `../STYLE_RIMWORLD.md`; see the preview verification below. `ModIcon.png` remains 128x128.
- **The repository.** Detached from the monorepo, one remote, public, and directory, packageId
  and repository name all spell out the mod's displayed name.
- **The game.** Never launched. Every behaviour claimed in `README.md`, `ATTRIBUTION.md` and
  `TESTING.md` is read out of the code, not observed.

So `stage: done` means done as far as a person without the game running can take it. It does not
mean the mod works, and `tested_on` being empty is the honest half of that sentence.

## What would move it

### Translation audit — 2026-09-13

The translation gate in `../PUBLISHING.md` and `../TRANSLATIONS.md` has been applied to
the working tree based on `4871397`. The historical `stage: done` is preserved. The three
`complete` fields certify static translation readiness only, not an observed game session.

- Scope: all `Source/*.cs`, `Mod/Defs/**/*.xml`, and language resources. This mod has no
  `LoadFolders.xml`, version-specific content, optional integration folders or XML patches.
  Reflection over the installed RimWorld 1.6 and rebuilt mod assemblies inventories 370
  `[MustTranslate]` string fields, including inherited recipe job strings, body-part labels,
  tools, thought stages, gene name symbols and the incident extension's beast letters.
- French now covers all 370 fields. English uses the source Def values for 340 fields and
  30 explicit English injections for the inherited Chinese gene-name symbols and bilingual
  incident letters. Chinese resources and original source text remain available unchanged.
  The inherited qiongqi-claw naming symbols refer to the nian beast in the original data;
  both new languages preserve that meaning rather than changing the content during translation.
- Eight active mod-owned Keyed entries cover the debug category, four action labels and three
  messages. One unused original compatibility key is also present in English and French;
  its presence is not counted as active UI coverage. Debug nodes use `DebugActionYielder`
  because the game's `DebugActionAttribute` labels are constant strings and are not translated.
- `Singleton.BeastFor` refreshes a saved beast's letter from the currently translated incident
  Def by pawn kind. The original deep save fields are preserved. This prevents a newly sent
  letter from reusing the language serialized in an older save; existing historical letters
  are not rewritten.
- Reused vanilla key `TextMote_Dodge` verified locally as `Dodge` / `Esquive`. Vanilla
  `CorpseLabel`, `MeatLabel`, `RecipeMake`, `RecipeMakeDescription` and `RecipeMakeJobString`
  exist in both installed languages with matching `{0}` parameters. Generated content uses
  these templates and translated owned labels; combat grammar comes from the referenced
  vanilla maneuver rules. No mod-owned grammar packs or custom string-list resources exist.
- Technical logs, serialized names, defNames, texture paths, reflection targets and About
  metadata are excluded from in-game translation. The unused condition-letter comp already
  marks its custom `text` field `[MustTranslate]` and has no XML instance to translate.
- Validation: `pwsh -NoProfile -File Tests/Run-All.ps1` builds the delivered DLL and runs the
  existing content/assembly/XML suite plus EN/FR coverage. The dedicated
  `Tests/Check-Translations.ps1` validates 370 fields and nine Keyed entries with zero failures;
  its inventory stage also validates 702 DefInjected paths across all three languages with
  zero errors and no unresolved targets. Four negative controls detect a missing French field,
  a key missing from both languages, a duplicate key and a broken format parameter.
  XML, parameter tokens, rich-text tags, line-break counts and identical texts were checked;
  unchanged `mingshe`, `qiongqi`, `explosion` and `tunnel` are reviewed names/cognates.
- Evidence and maintenance: `Tests/TRANSLATIONS.md`; generated field inventory and full test
  output are in `.build/translation-inventory.json` and `.build/translation-tests.log`.
  English/French UI, generated text, clipping and language-switch save checks remain unverified
  until performed in game, as explicitly recorded in `remaining`.

### Preview verification — 2026-09-12

- Source: `Art/Preview.png`, copied without changes from the existing text-free
  `Art/Preview-untitled.png`. No illustration replacement; the existing originals remain
  archived under their existing names. `Art/Preview-unofficial-source.png` contains old text
  and is not the background of the new composition.
- Composition: `Art/preview.html`; settings: `Art/preview-layout.json`; sole palette reference:
  `Art/preview-palette.json`; renderer: `Art/render-preview.cjs`. `Art/PREVIEW.md` documents usage.
- Palette: veil sampled from shadowed earth. Vivid accent comes from the red firecrackers,
  with saturation increased, clearly distinct from the dominant ochre family shared by the
  soil and the beast's fur. That ochre family is lightened for the tag and title suffix.
  Strong title words, the connector and the summary share exactly the same primary ink.
- Font verified through Chrome's actual platform-font reporting after `document.fonts.ready`:
  Segoe UI Semibold for the title, Segoe UI Regular for tag/summary, Segoe UI Bold for the badge.
  No fallback. The title uses 46 px on two balanced lines. Direct spans reduce `And` and
  `Renew` to 29.9 px (65%), both still weight 600. `And` retains primary ink; `Renew` uses
  secondary ink. Exact name, case and order preserved; status tag remains on its own line.
- Version 1.6 is read from the delivered About.xml. Badge coordinates, rotation, text bounds
  and separation checked. Visual inspection passed at 896x504 and 268 px: no clipped text or
  overlap between text elements, title/version identifiable, reduced words readable, rule
  visible, vivid red accent distinct from the ochre secondary ink.
- Minimum measured contrast on the rendered background with text and shadows hidden:
  main title words/connector 6.41:1, title suffix 5.37:1, summary 6.60:1, tag 7.50:1,
  badge 5.03:1. Every pixel in the text regions was
  checked, beyond just their four corners. Report: `Art/preview-qa/report.json`; text-free
  background: `Art/preview-qa/background.png`; thumbnail: `Art/preview-qa/preview-268.png`.
- Delivered `Mod/About/Preview.png`: 612132 bytes, below 900 kB. Nothing published.

### In-game verification

`TESTING.md`, block by block. Three of its scenarios decide whether the port worked at all: the
sexie changing shape, the qiongqi landing its flight, and the mingshe's drought ending with the
beast. Those are the three hooks 1.6 silenced, and the three the port claims to have fixed.

The development-mode entries under **Ancient Chinese Beast** in the debug menu exist for that run:
a beast now, the nian beast within the hour, the sixty-day gate cleared, and the beast clock
printed to the log.

---

`stage` vocabulary: `port`, `showcase`, `preTest`, `done`, `tested`, `published`.
`licence` vocabulary: `open` an explicit licence or permission, `silent` no explicit licence,
reuse permission or prohibition found (does not establish abandonment),
`alive` no licence but a source explicitly recorded as maintained, `forbidden` a written refusal, `original` owing nothing
to anyone — not a name, not an idea traceable to one mod, not a value derived from its assets.
`remaining` in three kinds: `feature` for something missing from a first release, `defect` for a
known fault left unfixed, `unverified` for what could not be checked.

- **`dependencies`** — `declared` when every mod this one needs is named in the About's
  `modDependencies`, `to check` when a non-vanilla `loadAfter` suggests a dependency that is not
  declared, `none` when the mod needs nothing. An undeclared dependency is not cosmetic: on
  2026-09-11 Reequilibrage animaux took 47 vanilla animals down with it, Muffalo included, because
  the class it injects belongs to a mod that was not declared and not loaded.
