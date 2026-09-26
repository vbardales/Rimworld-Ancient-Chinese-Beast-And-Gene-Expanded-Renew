---
localization: complete
translation_en: complete
translation_fr: complete
settings_audit: not_applicable
audit_revision: eeb57db (pushed, tree clean when the audit began) plus the commit that records the 2026-09-24 audit
mod:          Ancient Chinese Beast And Gene Expanded Renew (unofficial)
packageId:    nelim.ancientchinesebeastandgeneexpandedrenew
repo:         Rimworld-Ancient-Chinese-Beast-And-Gene-Expanded-Renew
visibility:   public
detached:     yes
stage:        done
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
  - unverified: Tests/Pickle - 16 features, 91 scenarios, nine manual exceptions (M1 to M9) recorded in its
      README, with a step sheet in docs/MANUAL-TESTS.md. Played in a real game on 2026-09-25 and 2026-09-26 (English,
      no optional mods, then the Animal Prosthetics 2 and Nocturnal Animals passes), see docs/runs/. Green on the
      current tree (2026-09-25 and 26): features 01 to 13, 15 and 16, and 14 on 2026-09-25; the French pass and the `@review` captures are unread. Not proven as one full run: no
      initial/final pass with all scenarios has been played. The French pass (features 01, 05, 07, 08) is submitted
      (request 4fc7) and not read
  - unverified: the delivered assembly changed on 2026-09-25 (SHA-256 BE213D7D...9653A0, was 5F38C060...676769D): the
      debug action "Beast attack now" now forces its incident (Singleton.BeastApproach(forced)), because the first
      Pickle run showed both incidents refusing to fire unforced on a day-1 colony. Built, 26 assembly contracts
      and 284 content checks green; the scenario that proves it passed on 2026-09-25 (request f2fd)
  - unverified: the beasts rest and breed (2026-09-25, merged into main): every beast has a rest need and two sexes, the
      tame ones give birth (or lay eggs: mingshe and star officer) to babies that grow through baby, juvenile and adult,
      and Nocturnal Animals gives each a body clock. Offline: 341 content checks green, the XML classes, fields and
      references green, the French keys resolved. In game, green on 2026-09-26: feature 15 (rest 11/11, eggs 2/2,
      births 4/4) and feature 16 (11/11). Saved clones stay genderless and sterile. Not played: a long hostile raid, to
      see whether a tired hostile beast lies down instead of attacking (its think trees put SatisfyBasicNeeds before the
      attack; a fresh beast starts rested, so this is judged low risk, not measured)
  - unverified: no person has played the mod. What is known of it in a game is what Pickle showed on 2026-09-25
      (above); TESTING.md remains the protocol, 29 scenarios
  - unverified: nine manual tests to validate (M1 to M9, Tests/Pickle/README.md), the cases the suite
      cannot play. `tested` waits for every one of them to be green
  - unverified: the nian beast's description lost its butchery paragraph on 2026-09-25 (English, French,
      Simplified Chinese; the promise of "nian beast fangs" was inherited text, a butchery yields meat only,
      seen in the run of that day). The field paths are unchanged; the four PowerShell 7 translation scripts
      were re-run 2026-09-26 and are green; the new text is in no in-game check yet
  - verified 2026-09-26: Tests/Run-All.ps1 ran whole under PowerShell 7.6 (pwsh, installed on this machine): builds, 341
      content checks, translation check (378 Def fields, 9 Keyed, 0 failure), configuration, XML checker exit codes, all
      negative controls green. The content negative control for the repository URL was fixed the same day (the
      description now carries the URL twice, so the mutation removes both)
  - unverified: A Dog Said... Animal Prosthetics 2 compatibility (Mod/Patches/ADogSaidAnimalProsthetics2.xml,
      loadBefore in About.xml, added 2026-09-24). Offline: the patch's paths and lists are checked against a
      stand-in of the other mod's category defs, negative control seen. In game: feature 14, pass 5
      (wsl-deps.ads2.map, Workshop 3238353862, a Windows subscription at 1.3.7), written and submitted to the
      TicketDispatcher. First run 2026-09-25: 4 of 11 passed, 7 failed, all seven because the staging loaded
      this mod after ADS2 (it does not sort by loadBefore), which is what the mechanism predicts and not a defect of
      the patch. With the pass map naming this mod first (`path:` overlay), the second run passed 11 of 11
      (exitReason passed, 2026-09-25): the five clones offer wooden, simple and bionic replacements, the chicken
      wooden and simple and no bionic, the four hostile beasts nothing, and the load order is the mod first. Still
      unverified: what the Health tab's operation menu shows for a given body part, which is the other mod's own
      logic and is not asserted (TESTING.md, H1)
  - unverified: pass 3, the pass with the optional mod ninedaylongbow.ChineseComprehensiveExpansion (the
      one mod About.xml names in loadAfter), is owed and not written: its Workshop id has not been looked up
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

### Ordered workflow audit - 2026-09-24

**Result: `preTest` -> `done`.** Audited revision `eeb57db` (HEAD, pushed, tree clean when the audit began);
the commit that records this audit follows it. The chain was checked in order against `AUDIT.md` and against
the artifacts on disk, not against the stage declared here. Nothing was launched in a game, no ticket was
taken and nothing was published.

| Transition | Result | Evidence and limits |
| --- | --- | --- |
| dansMonoRepo -> horsMonoRepo | Validated | Own repository, `origin` public on `main` at HEAD. STATUS present; licence `silent` with its four places named; packageId, repository and folder all spell the displayed name. README, ATTRIBUTION, LICENSE and CHANGELOG in English; the `Mod/` copies of ATTRIBUTION and LICENSE are byte-identical to the root ones (SHA-256 compared). |
| ModIcon generated | Validated, one note | 128x128 PNG, 27059 bytes. The delivered DLL was rebuilt today and its SHA-256 is unchanged (`5F38C060...676769D`). Note: this session re-encoded the icon losslessly on 2026-09-11, pixel for pixel, before the rule that forbids a session to touch it; it was not redone. |
| Preview generated | Validated | 896x504 PNG, 762904 bytes, under 1 MB; inspected at 896 px and at 268 px. Recomposed 2026-09-24 (text in the upper left) and engraved again on 2026-09-25 to the charter of that day: 734,072 bytes, title 34 px at 50 px from the left, two deliberate deviations recorded in `Art/PREVIEW.md` (top margin 24 px, summary 330 px). |
| preOptions | Validated | Red accent and ochre secondary are distinct in the renderer's own report; English description; title hierarchy (`And`, `Renew`, the unofficial tag) rendered as specified. |
| options | Not applicable, justified | The 74 source file names include no `Mod` subclass and no settings class; `Mod/Defs` has no MainButton folder. No page and no shortcut exist, so none is empty. Read from file names and the 2026-09-13 inventory, not a symbol search. |
| l10n | Validated, on unchanged inputs | `.build/translation-coverage.log` and `translation-tests.log` (2026-09-13): 370 Def fields, 9 Keyed entries, 702 injection paths, 0 failures, negative controls passed. Git shows no change to `Mod/Defs`, `Mod/Languages`, `Source` or `Mod/Assemblies` since the l10n commit `ca985d6`. The four scripts that need PowerShell 7 could not be re-run here. |
| preTest | Validated | `About.xml` declares Harmony and Biotech as hard dependencies and lists the one optional mod in `loadAfter`; no `LoadFolders`, patch or conditional content; changed since only by the GitHub link. (2026-09-24, after this audit: one patch, `Patches/ADogSaidAnimalProsthetics2.xml`, and a `loadBefore` were added, see the remaining lines.) |
| done | Validated | Run today: 262 content checks and 0 failures; the mod built with the delivered hash; 26 assembly contracts; XML classes, XML fields, def references, external types; configuration 133 of 133 defs. Pickle scenarios written (13 features, 52 scenarios), their phrases resolved against Pickle, their scope justified in `Tests/Pickle/README.md`. Settings, DLC-absent and restart passes justified as not applicable. |
| tested | Unverified | Nothing was played. |

**Defects found, and fixed here.**

- `Tests/Tests.csproj` compiled the net48 Pickle step sources, so `Build tests` failed and `Run-All.ps1` could
  not complete. Excluded in the project; the build and the assembly contracts pass again.
- `CHANGELOG.md` recorded the preview change under `0.1.0`, which predates it. `AUDIT.md` wants `0.1.0` to
  hold only what was uploaded, so the change sits under `1.0.0 - unreleased`, above it.
- `TESTING.md` did not say how many Pickle passes the mod needs. It does now (four launches).
- `Tests/Pickle/README.md` said the mod has no optional integration. `loadAfter` names one.
- A recipe step passed no worker, which the game's own code dereferences. Fixed, see the Pickle section below.

**Mandatory checks still open, for `done` -> `tested`.** None of these is a defect; each is unverified.

- Pass 1 (English, without the optional mods): played in part on 2026-09-25, feature by feature, six requests still to
  read. Pass 2 (French): not run.
- Pass 3 (with `ninedaylongbow.ChineseComprehensiveExpansion`): not written, its Workshop id is not looked up.
- Pass 4 (`13`): submitted (request f950); the original mod is a Windows subscription, nothing to download.
- Pass 5 (Animal Prosthetics 2, `14`): green, 11 of 11, 2026-09-25.
- The nine manual exceptions M1 to M9 (`Tests/Pickle/README.md`): to validate.
- The `@review` captures: none exists yet, so none has been opened.

**Recommendations, optional.** Install PowerShell 7 so that `Tests/Run-All.ps1` runs as one command. Look up the
optional mod's Workshop id. The changelog headings follow the CI (`## [1.0.0] — unreleased`, `## [0.1.0] — 2026-09-23`),
which the owner chose on 2026-09-25 over the `# 0.1.0` she had asked for on 2026-09-24.

**Left as it was, on purpose.** `.build/translation-inventory.json` was rewritten at 10:30 today by a partial
run under Windows PowerShell 5.1 (370 entries, a different size). Regenerate it with PowerShell 7 before
relying on it. The preview on the Workshop item is the lower-right one it was uploaded with.
### Prepublication, and what `tested` now requires — 2026-09-24

**The Workshop item exists.** It was created by the first upload on 2026-09-23 at 14:30, from the
working folder: item 3806709132, private, version 0.1.0. `Mod/About/PublishedFileId.txt` is committed
and pushed (`89a2575`) and the remote copy was read back with the same number. Steam froze the name,
the description and the packageId at creation, and the About.xml it received was the one ending in
the GitHub link. `CHANGELOG.md` holds that version as `## [0.1.0]`. Publications from here go through GitHub
Actions: a dry-run for the exact commit first, and only Virginie approves `steam-production`.

**What the upload probably carried that git does not.** 80 `.dds` files, 21 MB, written by the game
beside the PNGs on 2026-09-23 at 14:12. They were never tracked and are ignored now; a CI upload
builds from a checkout and will not carry them. The item's actual file list has not been read, so
this is a consequence of the timestamps, not an observation.

**`stage` is `done`, not `tested`.** Three conditions must all hold before a mod can be `tested`:

1. no scenario tagged `@wip`;
2. every scenario that depends on a condition (`@requires:`) has run;
3. no manual test left to validate, every one green.

| Condition | This mod |
| --- | --- |
| No `@wip` | Holds for the thirteen features written: none carries the tag, they carry `@review` only |
| Conditional scenarios have run | `13-original-mod-incompatibility` (`@requires:andery233xj.AncientChineseBeast`) is written with its pass map and submitted (request f950), not yet read; the original mod is a Windows subscription, so nothing has to be downloaded. `14-animal-prosthetics-2` (`@requires:SamBucher.ADogSaidAnimalProsthetics2`) has run and passed. The pass with the optional mod `ninedaylongbow.ChineseComprehensiveExpansion` (`loadAfter`) is owed and not written |
| No manual test to validate | Not met. Nine manual exceptions (M1 to M9) are recorded in `Tests/Pickle/README.md`, each with why it is not automated and what to inspect. None has been done |

Nothing counts until the suite has been run, so `tested_on` stays empty and a green static run does
not move `stage`. The first run also has to be made twice, English and French.

**Evidence** stays on disk and out of git. `docs/runs/README.md` says which proofs of a run to keep
and in what form. None exists yet: no Pickle report of this mod is in the shared folder or in the
runner's archive.

**Queue tickets.** A Codex heartbeat is what a Claude session does with a watcher, the Monitor tool,
on its ticket. The suite is written and its phrases check, and it takes no ticket until the owner
authorizes one (`PickleTools/TESTING.md`, after WSL's root filesystem went read-only on 2026-09-23).
When it does, the launch is followed by a watcher and not polled.

### The Pickle suite, finished — 2026-09-24

**What it is now.** `Tests/Pickle/` holds 13 features and 52 scenarios once the outlines are expanded,
five step classes and a phrase checker. It plays the nian beast and the firecracker (real blows through
the game's damage path, the fire breath, butchery, the chain of small explosions and its end), the whole
scheduler by moving the game clock (the debug flag, the first hour of the year and its two negative
controls, Sexie's 900000 ticks, the sixty-day gate and the daily roll under a seed chosen to win),
every development action by its Keyed key in whichever language the pass runs, the sexie's tunnel, all
twelve gene recipes, all five clones, the archite capsules, a tame mingshe's death, the crow's mood and
its kill count, the bird crowing by itself at four, and the declared incompatibility as its own pass.
`Tests/Pickle/README.md` maps each of the 28 `TESTING.md` scenarios to the feature that plays it or to a
manual exception, and lists the three pass commands.

**What was checked, and what that proves.** `Tests/Pickle/Check-Steps.ps1`: 52 patterns compile, none is
declared twice or ambiguous with Pickle's 205 built-in expressions, every step that waits declares a
deadline, and all 250 step lines of the features resolve to exactly one expression. The step assembly
builds against the game's 1.6 reference assemblies and against the mod's own assembly, so a scheduler
member that goes away breaks the build. That proves the lines will find their steps. It proves nothing
about what the steps do: no line of it has run in a game.

**What writing it found.**

- Six steps written earlier waited up to ten seconds with the default five-second deadline. They now
  declare one, and the checker fails the next one that does not.
- `I save and reload` and `the save round trips` are not attributes in Pickle: the runner registers them as
  string literals in `RunSession.RegisterBuiltInEngineSteps`. The checker knows them now.
- `Tests/Tests.csproj` compiled every `.cs` under `Tests/`, including the net48 Pickle step sources, so
  the offline suite's `Build tests` step failed. Excluded in the project. `Tests/Run-All.ps1` had last run
  green before `Tests/Pickle/Source` existed.
- The debug labels: the four development actions are now exercised
  through the Keyed key that names them, so a key untranslated in the language of the run fails the step.
- The archite-capsule scenario would have failed on a NullReferenceException of the game's own:
  `GenRecipe.PostProcessProduct` reads `worker.Ideo` with no null check, and the recipe steps passed no
  worker. They pass the map's first colonist now, and that scenario names one. Read from the game's IL.

**What was not done.** Nothing was run in a game and no ticket was taken. The original mod is not
downloaded into the WSL install, so the incompatibility pass cannot stage. The four PowerShell 7 scripts
above could not be re-run here; their last green run (2026-09-13, logs kept in `.build/`) was on inputs
git shows unchanged since. Everything else `Tests/Run-All.ps1` runs was green on 2026-09-24 (262 content
checks, 26 assembly contracts, XML classes and fields, def references, external types, 133 of 133
configuration defs), on a delivered assembly whose SHA-256 is still `5F38C060...676769D`.

**The preview.** The copy moved from the lower right to the upper left. The lower-right placement covered
the three red firecrackers, which are the image's one vivid accent, and its veil dimmed the beast. Five
placements were rendered through `Art/preview.html` and compared. The delivered one has a two-line title
at 32 px, a 330 px summary and a smaller veil; `Art/render-preview.cjs` passed every check it has (Segoe UI
throughout, title over two lines, contrast 8.9, 6.7, 8.1, 7.0 and 5.0 to 1, 763 KB) and the image was
inspected at 896 px and at 268.

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
