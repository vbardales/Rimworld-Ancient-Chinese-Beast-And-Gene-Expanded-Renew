---
localization: complete
translation_en: complete
translation_fr: complete
settings_audit: not_applicable
audit_revision: 67a4b37 (HEAD, pushed, tree clean when the 2026-10-01 audit began). While it ran, another session regenerated `Art/` and `Mod/About/Preview.png` in the working tree: uncommitted, not touched and not audited here
mod:          Ancient Chinese Beast And Gene Expanded Renew (unofficial)
packageId:    nelim.ancientchinesebeastandgeneexpanded
repo:         Rimworld-Ancient-Chinese-Beast-And-Gene-Expanded-Renew
visibility:   public
detached:     yes
stage:        done
workflow_stage: done
licence:      silent
licence_at:   reviewed 2026-09-12 - original files and About.xml, English and Chinese Workshop
            descriptions, all 68 public comments, and the four coauthors' Steam profiles;
            no explicit reuse permission or prohibition found, no source repository link found.
            Local MIT licence covers port additions only; abandonment is not established.
upstream_mod_remotes:
  - https://github.com/MonsterTower/AncientChineseBeast
dependencies: declared
showcase:     complete
tested_on:
workshop:     prepublished 2026-09-23, item 3806709132, private, version 0.1.0
remaining:
  - verified 2026-10-01: French review by Virginie (see "Translation audit - 2026-10-01"). 11 source cells of
      `FRENCH_REVIEW.md` stay marked unverified (fields inherited from vanilla parents, not read)
  - unverified: Tests/Pickle - 23 features, 112 scenarios once the outlines are expanded (counted 2026-10-01);
      `Check-Steps.ps1` green 2026-10-01 (107 patterns, 415 step lines). **Pass 1 (English, every scenario, request b5b0,
      2026-10-01, 78 min, `exitReason` failed): 83 passed, 5 failed, 24 skipped by requirement.** First full pass. Red: the
      aura ring (clock), the chicken egg (wait), the barrier cut (the save did not load in 180 s), the barrier throw-back
      (a real defect of the original, guarded in `Source/`), the qiongqi strike (wait). All fixed after the run and not yet
      replayed. Passes 2 (French), 3, 4, 5 and 6 are queued (requests 71bc, 57f8, d047, 36bb, 2d38) and had not run when
      this was written. Not proven on the current tree: the five replays and passes 2 to 6
  - unverified: the delivered assembly changed four times in a week (forced "Beast attack now" 2026-09-25, rest
      and breeding 2026-09-25, the sexie's tunnel 2026-09-27, the wind barrier's projectile guard 2026-10-01). Current
      SHA-256 `40AA5903...A7BA74` (before the guard `042989FA...A1295F`), rebuilt by `Tests/Run-All.ps1` on 2026-10-01
      and byte-identical to the delivered file. The guard is in no in-game run yet. Offline: 26 assembly contracts and
      341 content checks green. In game: green per feature, see above
  - unverified: the beasts rest and breed (2026-09-25, merged into main): every beast has a rest need and two sexes, the
      tame ones give birth (or lay eggs: mingshe and star officer) to babies that grow through baby, juvenile and adult,
      and Nocturnal Animals gives each a body clock. Offline: 341 content checks green, the XML classes, fields and
      references green, the French keys resolved. In game, green on 2026-09-26: feature 15 (rest 11/11, eggs 2/2,
      births 4/4) and feature 16 (11/11). Saved clones stay genderless and sterile. Not played: a long hostile raid, to
      see whether a tired hostile beast lies down instead of attacking (its think trees put SatisfyBasicNeeds before the
      attack; a fresh beast starts rested, so this is judged low risk, not measured)
  - unverified: no person has played the mod. What is known of it in a game is what Pickle showed on 2026-09-25
      (above); TESTING.md remains the protocol, 29 scenarios
  - unverified: the nine manual exceptions (M1 to M9, Tests/Pickle/README.md, docs/MANUAL-TESTS.md). `tested` waits
      for every one of them to be green or explicitly not applicable with its reason. State on 2026-10-01: M1 to M5
      automated and green (features 04, 20, 21, 22). M6 (feature 19) red three times on 2026-09-28; its cause was read
      in the diagnostic the runs attached (the extractor’s interaction cell was not standable) and the placement step
      is fixed, replay owed. M7 (feature 18) red twice, "Accessing map pawns off main thread" while a colonist is
      generated, cause not found; replay owed on the current tree. M8 automated as feature 23 (the part the mod owns),
      written, not played. M9 not applicable: the game’s own behaviour, reason in Tests/Pickle/README.md; the owner can
      overturn it
  - defect (fixed in the features 2026-10-01, replay owed): two of the nine `@review` captures did not show their subject: `05-incidents` (the
      Pleiades star officer is a few pixels at the top left of a base-wide view) and `11-tunnel` (the label under the
      pointer reads "Tunnel", no tunnel is drawn on screen). The camera and the zoom are the scenarios' to set
  - unverified: whether `MonsterTower/AncientChineseBeast` (the 1.5 source, see the 2026-10-01 audit) belongs to the
      four credited authors: nothing links it to them. A fork and a pull request are public: they go out only with
      Virginie's word (BACKLOG.md)
  - verified 2026-10-01: Tests/Run-All.ps1 under PowerShell 7.6.6, exit 0: 341 content checks and five negative
      controls, 26 assembly contracts, XML fields, classes, def references and external types, 137 of 137
      configuration defs, 378 Def fields and 9 Keyed entries with four translation negative controls, both XML
      exit-code checks. The delivered assembly came out byte-identical
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
  - verified 2026-09-28: pass 3, the optional mod ninedaylongbow.ChineseComprehensiveExpansion (the one
      mod About.xml names in loadAfter). Its Workshop id (3221850511) was looked up (`Search-Workshop.sh`
      over the local corpus, by its packageId; a Windows subscription, 1.6 folder present) and the pass
      written (`17-chinese-comprehensive-expansion.feature`, `wsl-deps.cce.map`, mirrors the ADS2 pass: no
      patch either way, only the loadAfter order and no def conflict). First run red, the map's order
      copied from ads2 unadjusted (this mod before CCE instead of after); fixed and green, 1/1
      (evidence `2026-09-28b-cce`)
  - checked 2026-09-28: what the 0.1.0 upload carried. The item's own cached copy
      (`steamapps/workshop/content/294100/3806709132`, since the owner is subscribed to her own item) still
      holds the 80 `.dds` files (28 MB total with the textures) that sat beside the PNGs at upload time,
      written by the game. They are gitignored and untracked (`git ls-files` finds none, `git check-ignore`
      confirms `*.dds`), so a checkout has none of them: the next publish, which the CI builds from a
      checkout, replaces the item's content wholesale and drops them on its own, nothing to do by hand.
      The item stays private and prepublished, so no one has downloaded the 0.1.0 copy
  - unverified: English and French display checks, generated names, debug actions and
      save/reload across languages have not been run; see TESTING.md, Translation checks
  - defect: Singleton.nextBeastTimeHours is incremented, reset, and read by nothing. Inherited,
      deliberate, harmless now that no button depends on it
  - defect: CompAbilityEffect_SectorCells caches into a list it fills with itself, so the cache
      branch is unreachable. Inherited, deliberate, costs nothing
  - defect: the keyed string SZ_CannotReachBuildingToExtractGene is referenced from neither the
      C# nor the defs. Inherited, left alone
session:      local_ecc57511-3350-4f1d-9e1d-979c259d1b6b
updated:      2026-10-01
---

# Ancient Chinese Beast And Gene Expanded Renew — status

Read by a sweep across every mod, rather than by asking each thread in turn. It lives at the
root, never inside `Mod/`, so Steam never receives it.

## Where this one stands

### Ordered workflow audit - 2026-10-01

**Result: `done` -> `done`** (`stage: done`, `workflow_stage: done`; session title
`ancientchinesebeastandgeneexpanded / done`). Audited revision `67a4b37` (HEAD, pushed; tree clean when the audit
began). Against the current `AUDIT.md`, `PUBLISHING.md` (version of 2026-10-01 04:41), `TRANSLATIONS.md` (2026-09-30)
and `MOD_SETTINGS.md`; the versions read are in `docs/PROTOCOLS-READ.md`. Nothing was launched in a game, no Pickle
ticket was taken and nothing was published. The previous audit (2026-09-24, below) reached the same state; its table
is kept as history, and what changed since is recorded here.

| Transition | Result | Evidence and limits |
| --- | --- | --- |
| dansMonoRepo -> horsMonoRepo | Validated | Own repository, `origin` public on `main`, HEAD pushed. `upstream_mod_remotes` now lists the source repository found on 2026-10-01 (see below); it was `N/A`. `licence: silent` stays: a repository found is not a licence, and that one has none. `(unofficial)` suffix and the first paragraph of the description follow the rule. The `Mod/` copies of `LICENSE` and `ATTRIBUTION.md` are byte-identical to the root ones (SHA-256 compared). |
| ModIcon generated | Validated | 128x128 PNG, 27059 bytes at HEAD; the 32 px reduction was inspected, the winking dragon head still reads. Not touched: the owner alone generates it. |
| Preview generated | Validated on the committed file | HEAD's `Mod/About/Preview.png` is 896x504, 816119 bytes, inspected at full size: title, tag, rule, summary, version badge, ModIcon cutout at the bottom right at -15°. A regeneration is under way in the working tree (another session, 05:00 on 2026-10-01: `Mod/About/Preview.png` 644800 bytes, `Art/Gallery/0-preview.png`, `Art/ModIcon-redrawn.png`, new `Art/` files); it is uncommitted and was not audited. The gallery's image 0 is still `Art/Workshop/00-preview.png` at HEAD (the rule of 2026-09-29 is one digit, `0-`): that session's `Art/Gallery/` is the new place. |
| preOptions | Validated | English description; ends with the `Source code on GitHub` link; `sync-about-description.mjs` reports `About.xml` is the plain text of `PUBLICATION.md`; `.github/publish.config.json` reads that Markdown block. |
| options | Not applicable, justified | Read again: no `ModSettings`, `GetSettings`, `DoSettingsWindowContents`, `Mod` subclass or `MainButtonDef` in `Source/` or `Mod/` (searched by symbol, not only by file name). No page and no shortcut exist, so none is empty. |
| l10n | Validated for what a session can check | 378 Def fields and 9 Keyed entries, 0 failures, four negative controls (`Tests/Run-All.ps1`, 2026-10-01). Plurals (rule of 2026-09-25): none of the nine Keyed entries takes a parameter, so no counted phrase exists and no `.One`/`.Many` is owed. French gender agreement (rule of 2026-09-30): all 19 French files read on 2026-09-30, no text agrees with a pawn, no switch needed. `FRENCH_REVIEW.md` (revision `f1c84fc`) is current: the French and English files last changed at `70feeae`, before it. `translation_fr` is `complete` since Virginie's review of 2026-10-01 (revision `16cb222`). |
| preTest | Validated | `modDependencies` Harmony (with its Workshop URL) and Biotech; `loadAfter` the optional Chinese Comprehensive Expansion; `loadBefore` Animal Prosthetics 2; `incompatibleWith` the original; no `LoadFolders`. Two guarded patches: Animal Prosthetics 2 (`PatchOperationConditional` on `ADS_Cat1`, no `MayRequire` on an operation) and Nocturnal Animals (`PatchOperationFindMod` on its display name). The four animal integrations of `PUBLISHING.md` are treated, see below. |
| done | Validated | Offline checks replayed, not read from an old report: `pwsh -NoProfile -File Tests/Run-All.ps1` (PowerShell 7.6.6), exit 0: 341 content checks and 5 negative controls, 26 assembly contracts against game 1.6.9676.17735, XML fields, classes, def references, external types, 137 of 137 configuration defs, the translation checks, both exit-code checks. The delivered assembly was rebuilt byte-identical (SHA-256 `042989FA...A1295F`). `Tests/Pickle/Check-Steps.ps1`: 105 patterns compile, none declared twice or ambiguous, every waiting step has a deadline, 409 step lines resolve. 23 features, 112 scenarios written; scope justified in `Tests/Pickle/README.md`. |
| tested | Not met, unverified | See the three conditions below. |

**The three conditions of `done -> tested`, checked on 2026-10-01.**

| Condition | State |
| --- | --- |
| No scenario tagged `@wip` | **Holds.** None of the 23 features carries the tag (searched). |
| Every conditional scenario has run | Four features carry `@requires`. `17` (Chinese Comprehensive Expansion) green 1/1 on 2026-09-28, on the current tree. `14` (Animal Prosthetics 2) green 11/11 and `16` (Nocturnal Animals) green 11/11, both on 2026-09-25, before the tunnel fix and the packageId change. `13` (the original mod) green 1/1 on 2026-09-25; the packageId run of 2026-09-27 skipped it, so it has no run on the current tree. Each report was read, suite and scenario names included (`junit.xml`, `summary.md`); the `13` one still records the packageId that carried `renew`, which confirms it predates the change. The `exitReason` and `setName` of every kept report lived in `summary.json`, which the trim of 2026-10-01 deleted before `WELCOME.md` was read again ("`summary.json` et `junit.xml` suffisent"): they cannot be re-read, the counts match the features played, and the final pass replaces these reports. All four are to be replayed in the final pass. |
| No manual test left to validate | **Not met.** M1 to M5 green (automated), M6 and M7 red, M8 and M9 neither automated nor played: see `remaining`. |

The nine `@review` captures kept were opened on 2026-10-01. Seven show what they claim (the four beasts and the
rooster together, the scorpion form with its aura ring, the qiongqi after its landing, the rooster beside the
scorpion form, the nian beast breathing fire at a muffalo, the friendly mingshe, the genepack named by the hover label).
Two do not show their subject: see the defect in `remaining`. They are from builds before the tunnel fix, except the
tunnel one; the final pass produces the captures of the current tree.

**The source repository (`upstream_mod_remotes`).** The original's Steam page and its `About.xml` link no repository
(read again 2026-10-01: the page, the first page of its comments, the local `About.xml`). A GitHub search by the mod's packageId and name
finds **`MonsterTower/AncientChineseBeast`**: "山海志怪Mod 1.5版本源代码" (source of the 1.5 mod), public, created
2025-09-10, one commit (`init`), no licence, forking allowed, issues open, no pull request and no issue. Its files
are the original's source (the same class names as the 1.5 assembly this port was decompiled from, plus the
firecracker debug comp that this port replaced). The account is `MonsterTower` ("旋风", a student and community modder,
Xiamen); **none of the four creators listed on the Steam page** (FrolgHart, andery233xj, 瑞秋·克劳狄乌斯, 玖日长弓)
**carries that name**, and nothing on either side links the two. So it is a source repository of the mod, owner
unconfirmed; it carries no licence and does not change `licence: silent`. This port was started from the 1.5 assembly,
not from that repository, so its history cannot be rebased onto it; what can be proposed is a pull request of the 1.6
changes (`PawnFlyer.TickInterval`, `PostDeSpawn(Map, DestroyMode)`, the wildness stat, the `GenExplosion` call, the
debug actions). `PUBLISHING.md` makes the pull request systematic once an origin repository exists and puts it in
`BACKLOG.md` until done; it is public, so it waits for Virginie's word.

**The four animal integrations (`PUBLISHING.md`, rule of 2026-09-28 completed 2026-10-01).** Read in the installed
1.6 files of the other mods on 2026-10-01.

| Mod | Treatment |
| --- | --- |
| A Dog Said... Animal Prosthetics 2 | Treated: `Patches/ADogSaidAnimalProsthetics2.xml`, `loadBefore`; played, feature 14. |
| [XND] Nocturnal Animals (Continued) | Treated: `Patches/NocturnalAnimals.xml`; played, feature 16. |
| Dogs mate (Continued) | **Not applicable.** Its 1.6 version uses the vanilla crossbreeding field and adds a "Can mate with" stat; its groups (`Revolus.DogsMate.AnimalGroupDef`: the canids, the felids, the rodents, the mammals, the platypus) list animals that share a species or a close relative with others. The beasts are unique species with no vanilla relative to mate with, and none of the 137 defs declares `canCrossBreedWith`. Nothing to add. |
| Better Crossbreeding | **Not applicable as shipped.** It only acts through a `DZY.Crossbreeding.Extension` on a mother's `PawnKindDef` and the vanilla `canCrossBreedWith`; the beasts breed among their own race only (since 2026-09-25) and declare neither. A hybrid of a beast and an ordinary animal is the open idea of `BACKLOG.md`: if the owner builds it, both integrations are reopened with it. |

This is a decision the owner can overturn: it is written here so that the absence of a patch is a recorded choice and
not an oversight.

**Evidence, 2026-10-01.** `Tests/Pickle/Evidence/` went from 198 MB to 2 MB, still on disk and out of git (`evidence/`
and `Evidence/` are ignored; no report and no `.dds` is tracked: `git ls-files` finds none). Kept: the latest report of
each scenario, as `summary.md` and `junit.xml`, and the nine English `@review` captures as 1280-pixel JPEGs. Deleted:
the 11 folders superseded by a later report of the same scenarios, and `report.html`, `messages.ndjson`, `Player.log`,
`summary.json` and the PNG captures of the rest. **Slip, owned:** `summary.json` should have stayed (it carries
`exitReason` and `setName`; `WELCOME.md` keeps `summary.json` and `junit.xml`); it is gone from the 26 kept folders and
`docs/runs/README.md` now says to keep it. No archive of this mod's runs remains in `pickle-reports-archive`
(the nine folders there are other mods'); none was touched. `docs/runs/README.md` says what to keep in a run.

**Work strictly needed for the next transition (`done -> tested`).** (1) Fix or justify M6 and M7, the two red
scenarios, and decide M8 and M9 (automate, or list as not applicable with a reason). (2) Fix the camera of the two
captures that miss their subject. (3) Play a final pass on the final tree: every scenario, in English, then in French,
plus the passes for the four `@requires` features (`13`, `14`, `16`, `17`), one request each, the SHA written in the
`-Label`, the tree left still until `RUN_DONE`; read `exitReason` first and open the captures. (4) Virginie's French
review of `FRENCH_REVIEW.md` closes `translation_fr`.

**Gallery image 0.** Uploaded by the owner on 2026-10-01 (her word in chat): `Art/Gallery/0-preview.png`, SHA-256
`4fe2d418e6dc...`, byte-identical to the committed `Mod/About/Preview.png` at that time. The other gallery images
(the `@review` captures) were opened on 2026-10-02 from pass 1 (`2026-10-01a-p1-en`) and five looked usable, but
**none is a gallery image**: they come from the Pickle test colony, not from the owner's colony `zenNelim`, which is the
one the Workshop page must show. The five copies were removed from `Art/Gallery/` (untracked, never committed or
uploaded). The captures stay in the evidence as test proof only. Gallery images 1 and up are to be taken by the owner in
`zenNelim`.

**Recommendations, optional.** The Workshop description and the gallery are the owner's steps in
`PUBLICATION.md`; the `.github` workflow is stamped `289c71f74e3b` and `generate-publish-workflow.sh --check` says
whether it is behind the template.

### Ordered workflow audit - 2026-09-24

*History, kept. The state it reached (`done`) is confirmed by the audit above; where its table and the audit above
differ, the audit above prevails.*

**Result: `preTest` -> `done`.** Audited revision `eeb57db` (HEAD, pushed, tree clean when the audit began);
the commit that records this audit follows it. The chain was checked in order against `AUDIT.md` and against
the artifacts on disk, not against the stage declared here. Nothing was launched in a game, no ticket was
taken and nothing was published.

| Transition | Result | Evidence and limits |
| --- | --- | --- |
| dansMonoRepo -> horsMonoRepo | Validated | Own repository, `origin` public on `main` at HEAD. STATUS present; licence `silent` with its four places named; packageId, repository and folder all spell the displayed name. README, ATTRIBUTION, LICENSE and CHANGELOG in English; the `Mod/` copies of ATTRIBUTION and LICENSE are byte-identical to the root ones (SHA-256 compared). |
| ModIcon generated | Validated, one note | 128x128 PNG, 27059 bytes. The delivered DLL was rebuilt today and its SHA-256 is unchanged (`5F38C060...676769D`). Note: this session re-encoded the icon losslessly on 2026-09-11, pixel for pixel, before the rule that forbids a session to touch it; it was not redone. |
| Preview generated | Validated | 896x504 PNG, 736202 bytes, under 1 MB; inspected at 896 px and at 268 px. Recomposed 2026-09-24 (text in the upper left) and engraved again on 2026-09-25 to the charter of that day. Moved to the bottom-left corner on 2026-09-27 (owner: the upper-left text still touched the beast's ear): a mod-local third anchor added to `Art/preview.html`, full account and contrast minimums in `Art/PREVIEW.md`. `Art/Preview.ico` regenerated from the new image. The ModIcon was composed sliding out of the bottom-right corner at -15° on 2026-09-29, the owner's own pick for this mod (a shared doc briefly attributed a different, top-left placement to her; she said she never wrote that, so this mod kept its validated bottom-right one). Cutout is a border flood-fill (`Art/compose-preview.cjs`), checkerboard-verified (`Art/preview-qa/modicon-checker.png`), no false hole in the interior black. `Art/Workshop/00-preview.png` added as the gallery's image 0. |
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
| No manual test to validate | Not met. Nine manual exceptions (M1 to M9) are written up in `Tests/Pickle/README.md`; M1 to M7 are now also automated as Pickle scenarios (`Tests/Pickle/Mod/Pickle/Features/`). Green so far: M2 (wind barrier), M3 (dodge/head bias), M4 (berserk aura, ring and map-wide pick), M5 (nian AI reaching a walled-in colonist, `2026-09-29a-m5`). Still owed: M1 (drought rot) and M7 (gene effects) results unconfirmed since submission; M6 (bench job chain) still red, cause not found. M8 and M9 stay manual: Pickle cannot switch language or the active mod set inside one scenario run |

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
| preOptions | Validated | English description; exact title order/case, reduced And and Renew, inline unofficial tag and 1.6 badge. Red accent is visually distinct from the ochre secondary ink. `Art/Preview.config.json` holds the saved palette and layout. Existing contrast measurements are retained, not claimed as rerun measurements. |
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

### Translation audit - 2026-10-01

**French review. Reviewer: Virginie. Date: 2026-10-01. Revision reviewed: `16cb222`.** She validated it in chat
("je valide") after three rounds of corrections, all applied (commits `49f1c12`, `16cb222`): the crow thought
label, the sexie description, the poison wording, and three wordings of the crow, the sound wave and the aura. The
session recorded this on her word and did not review its own French. Her next round (2026-10-02) found two blockers:
the 11 `unverified: inherited from a vanilla parent def` cells, and seven gene or hediff descriptions saying `le porteur`.
Both fixed in `5fc4e94` (vanilla parents `BluntBase`, `Flame`, `Bite`, `PawnFlyerBase` read in the 1.6 game data and
traced in `FRENCH_REVIEW.md`; the descriptions rewritten without agreement). She validated the result in chat on
2026-10-02 ("Validé"); `translation_fr` stays `complete`. Any later change to a French file sets it back to `unchecked`.

### Translation audit — 2026-09-30

French gender agreement (`../TRANSLATIONS.md`, "French gender agreement"): read every French file
of this mod, all 19 (18 `DefInjected` files + `Keyed/text.xml`, `Mod/Languages/French/**/*.xml`), no
pattern search. None of this mod's French texts agree with a pawn's gender: every entry describes a
creature, an item or an event in the third person, using the creature's own grammatical gender
(*la sexie*, *le mingshe*), never a `{PAWN_gender ? ...}` switch. No occurrence of the switch, and
none needed.

Where the French lives: `Mod/Languages/French/DefInjected/{AbilityDef,BodyDef,BodyPartDef,
BodyPartGroupDef,DamageDef,GameConditionDef,GeneDef,HediffDef,IncidentDef,JobDef,PawnKindDef,
RecipeDef,ResearchProjectDef,ResearchTabDef,StorytellerDef,ThingDef,ThoughtDef,ToolCapacityDef,
WorkGiverDef}/Translations.xml` and `Mod/Languages/French/Keyed/text.xml`. No grammar files.

`FRENCH_REVIEW.md` generated by `Tests/Generate-FrenchReview.ps1` (adapted from FoodCourt's
`_tools/Generate-FrenchReview.ps1`), revision `f1c84fc`. Original = English throughout: this mod's
Defs were ported straight to English (checked: `Mod/Defs/Pawn/QiongQi.xml`'s native `<label>` reads
`qiongqi`, not Chinese), and no separate Chinese-language file exists in this repository
(`ATTRIBUTION.md`: licence review found no source repository to read one from).

`translation_fr` stays `partial`: this session's own checks (inventory, coverage, gender agreement)
are done, but only Virginie reading `FRENCH_REVIEW.md` can mark it `complete`. `remaining` carries
"French review by Virginie" as `unverified` until she has.

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

## Preview source migration — 2026-10-02

The final text-free 896 x 504 crop is now the canonical `Art/Preview-source.png`; the accepted
redrawn transparent badge remains `Art/ModIcon-source.png`, and the validated line art remains
`Art/echo.png`. Copy, typography, layout and palette are consolidated in
`Art/Preview.config.json`. Superseded source variants, the second gallery location, local
renderers and committed QA intermediates were removed; all remain recoverable from Git history.
The shared renderer writes diagnostics under ignored `Art/.render/`, regenerates both ICOs and
keeps `Art/Gallery/0-preview.png` byte-for-byte equal to the delivered Preview. Compared with the
pre-migration PNG, only 27 RGB channel values differ, each by one level; dimensions, composition
and visual appearance are unchanged. Nothing published.

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
