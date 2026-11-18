---
localization: complete
translation_en: complete
translation_fr: complete
settings_audit: not_applicable
code_review_sha: fd2eea026104d91d60f905f251f6925f90cee573  # 2026-11-18, 12.a: diff 36832a44..HEAD over Mod and Source read: Mod/About/About.xml (description text: RimImmortal-Living thanks line, twelve genes) and five French DefInjected text lines (passes 27 to 32), Source, Assemblies and Patches unchanged: revue du diff : texte seul. Previous: 36832a442299fb7ac38b49d6389de132a35cb6df  # 2026-11-17, 8.m (replay): diff 1a96f5bc..HEAD over Mod and Source read: Mod/About/About.xml adds <li>1.7</li> to supportedVersions only, Mod/About/Preview.png rebuilt, Source and Assemblies unchanged: revue du diff : images et texte seuls. Previous: 1a96f5bc5f12d7df4261fce3473025703c8b437b  # 2026-11-16, 12.a: diff acf8b48..HEAD over Mod and Source read: only the About.xml description text (Languages paragraph, SamBucher wording), revue du diff : texte seul, no code. Previous: acf8b487c6fd413a3fd6f7dea299232702f466d6  # 2026-11-16, 8.m: diff 6589e5f..HEAD over Mod and Source read: Source, Assemblies and Patches unchanged; Mod/Defs hold six text-tag lines only (description, label) and Mod/Languages and About.xml text, OptionalCompat.xml one declaration: revue du diff : textes seuls, no code. Previous: 6589e5f5ef5c4b560b62bd1ccfa9b74f6241b2ce  # 2026-11-07, 8.m: Opus review f809e47f..0962a7e (4 findings in Ability_WindBarrier.cs), fixed in 6589e5f, diff 0962a7e..HEAD re-read (only that fix, Source and the rebuilt DLL), barrier replay f878 green. Previous: f809e47f4cd07d3a34b67b1d9c119e762a478f31  # 2026-10-13, 8.m exceptions: reviewed diff 54eb9fb..HEAD over Mod and Source (git diff --stat): only Mod/About/About.xml (description text, nothing else) and Mod/ATTRIBUTION.md (one sentence about the removed Art/textures-original), no code: revue du diff : images et texte seuls. Previous: 54eb9fb, 2026-10-13, 8.m (moved past the French and gene-name text edits of this commit, Defs QiongQi.xml and MingShe.xml read, no code; and past two description-only edits of About.xml, no code): 5ea69ab..HEAD over Source and Mod holds no code change (only Source/Directory.Build.props intermediates path build/, ATTRIBUTION.md, Preview.png, desktop.ini removed): 0 findings. Earlier review, was `code_review`: <sha> (2026-10-08, /code-review at low effort over 89a2575..5ea69ab, the 0.1.0 commit that tracked the PublishedFileId, limited to Source, Mod/Defs, Mod/Patches and Tests/Pickle/Source: 0 findings; low effort reads the diff once, no verify pass. First review of this mod, nothing earlier existed)
audit_revision: 67a4b37 (HEAD, pushed, tree clean when the 2026-10-01 audit began). While it ran, another session regenerated `Art/` and `Mod/About/Preview.png` in the working tree: uncommitted, not touched and not audited here
mod:          Ancient Chinese Beast And Gene Expanded Renew (unofficial)
packageId:    nelim.ancientchinesebeastandgeneexpanded
repo:         Rimworld-Ancient-Chinese-Beast-And-Gene-Expanded-Renew
visibility:   public
detached:     yes
workflow_stage: publish[1.2.0]
tested_1_7: yes  # 2026-11-17: baseline 170 passed (a8a1), our 7 time-bound reds all green since with tick batches (drought 585f, scheduler 40a4, births 3fcf, firecracker 2369); the 7 other reds were NPT scenarios (tool side)
social_preview_sha256: 0868266b0e73fc9131a723c56188c77a774c3a6a3d28cb1d62bcc5092a53b521
echo_review_sha: 979ef9fa06d355d9fe37ca55bdb8017b997e4fc2  # 2026-11-17, 10.a (replay): echo kept, echo-source.png and gallery 1 to 8 unchanged since acf8b48; only 0-preview.png and Preview.ico changed (our own render of the 1.7 badge Preview, 79b32d2). Previous: acf8b487c6fd413a3fd6f7dea299232702f466d6  # 2026-11-16, 10.a: echo kept again, echo-source.png and gallery 1 to 8 unchanged since 2026-11-15; only 0-preview.png (our own render of the new Preview) and Preview.config.json changed. Previous: 9d5b8f0b962db7260d3622a85774d6cad1044006  # 2026-11-15, 10.a: echo kept (echo-source.png, winged qiongqi line art, Preview panel bottom-left); the new gallery shows the same beast (images 2, 3, 8), subject unchanged; Preview.png unchanged, still equals 0-preview.png and social_preview_sha256
publication_changelog_review_sha: fd2eea026104d91d60f905f251f6925f90cee573  # 2026-11-18, 11.j: Virginie read PUBLICATION.md and CHANGELOG.md of the 1.2 line and validated ("je valide", chat). Previous: d7493d64d8c270087bd8ab943ce3044d6f67a59b  # 1.1 line
thanks_drafted_line: 1.2
licence:      silent
licence_at:   reviewed 2026-09-12 - original files and About.xml, English and Chinese Workshop
            descriptions, all 68 public comments, and the four coauthors' Steam profiles;
            no explicit reuse permission or prohibition found, no source repository link found.
            Local MIT licence covers port additions only; abandonment is not established.
upstream_mod_remotes:
  - https://github.com/MonsterTower/AncientChineseBeast
dependencies: declared
workshop_required_items: done, 2026-11-16 (read on the Steam page: Harmony 2009463077, Biotech DLC 1826140)
showcase:     complete
tested_on: 2026-11-06 pickle 6589e5f (1.6, English: feature 20 wind barrier 2/2 and feature 13 original mod 1/1 green; French feature 15 22/22 green 2026-11-03)
workshop:     published 2026-10-13, item 3806709132, public since 2026-10-13 (the owner switched it, after the upload), version 1.0.0, tag v1.0.0, run 38369937487 (publish and tag-and-release green)
remaining:
  - verified 2026-11-16 (replay 4.b, 4.e): Mod/About/OptionalCompat.xml declares XeoNovaDan.NocturnalAnimals (workshop 2004368312, patch) beside Mlie.XNDNocturnalAnimals; Check-OptionalCompat exit 0
  - verified 2026-11-16 (replay 10.f): Preview.png uploaded to the repo Social preview (owner, in chat); social_preview_sha256 equals the current Preview.png
  - verified 2026-10-01: French review by Virginie (see "Translation audit - 2026-10-01"). 11 source cells of
      `FRENCH_REVIEW.md` stay marked unverified (fields inherited from vanilla parents, not read)
  - verified 2026-10-13: Pickle on the 1.6 tree, read from the kept reports (`summary.json` `exitReason` first). Pass 1
      (English, 2026-10-01): 83 passed, 5 red (aura ring, egg, barrier cut, barrier throw-back, strike), all five green since
      (`2026-10-08a-replay-reds`, the 2026-10-08c replay (evidence deleted 2026-10-18), the 2026-10-08b run (evidence deleted 2026-10-18), the 2026-10-10f run (evidence deleted 2026-10-18)). Pass 2 (French, 2026-10-02):
      chunks a, b, c ran (drought and egg red, both green since); chunk d left no report, features 18 to 23 re-run in French
      the 2026-10-08b run (evidence deleted 2026-10-18) and the siege `2026-10-10i/j`. Passes 3 (the 2026-10-02g run (evidence deleted 2026-10-18)), 4 (the 2026-10-02f run (evidence deleted 2026-10-18)),
      5 (the 2026-10-01d run (evidence deleted 2026-10-18), 11/11) and 6 (the 2026-10-01e run (evidence deleted 2026-10-18), 11/11) passed. No red scenario is left. No full pass is owed
      before publish (AGENTS.md, rule of 2026-10-13): non-regression after the commit, at `followUp`
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
  - verified 2026-10-13: the nine manual exceptions. M1 to M5 automated and green (features 04, 20, 21, 22). M6 (feature 19),
      M7 (feature 18) and M8 (feature 23) green in French (`2026-10-08b`, `2026-10-09a`). M9 not applicable: the game’s own
      behaviour, reason in Tests/Pickle/README.md; the owner can overturn it
  - verified 2026-10-13: the two `@review` captures that missed their subject were retaken (the 2026-10-09a run (evidence deleted 2026-10-18)) and opened:
      the Pleiades star officer fills the view; the sexie (label "Sexie (human form)") stands in the red-carpeted room, red figure with spear.
      Both show their subject. The other seven were opened 2026-10-01
  - unverified: whether `MonsterTower/AncientChineseBeast` (the 1.5 source, see the 2026-10-01 audit) belongs to the
      four credited authors: nothing links it to them. The pull request exists: [MonsterTower/AncientChineseBeast#1](https://github.com/MonsterTower/AncientChineseBeast/pull/1)
      (from `vbardales/AncientChineseBeast`, opened 2026-10-09, open on 2026-10-13, one commit, no comment, no reply). The C# has not
      changed since it was opened (`git log --since=2026-10-09 -- Source` holds only the `build/` path), so it is current
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
      (evidence the 2026-09-28b run (evidence deleted 2026-10-18))
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
session:      local_f1e4cc35-8614-406f-80ff-0a2487014a59
updated:      2026-11-18
upstream_synced: 2026-11-16 MonsterTower/AncientChineseBeast@f6d3d19
protocols_read_sha: f8fee9ce3e84db4584ec0256dddb91ff50a3b435
---
# Ancient Chinese Beast And Gene Expanded Renew: status

Read by sweep across every mod, not by asking each thread in turn. Lives at root, never inside `Mod/`, so Steam never receives it.

## Where this one stands

### Gallery - 2026-11-15

Eight staged scenes (one day at Nelim's Sanctuary, Blue the only guest) plus Preview, all ACCEPTED by Virginie in chat on 2026-11-15 ("je valide"), subtitled, final names, contiguous indexes. `Art/Gallery/` holds the subtitled images (4.4 MB for 1 to 8, each under 2 MB), `Art/Gallery-clean/` the eight originals. Subtitle lines in `PUBLICATION.md`. The 2026-10-13 set is replaced (old png deleted). `0-preview.png` is the old Preview copy: regenerated at `mountPreview`.

| Index | File | Shows |
| --- | --- | --- |
| 0 | `0-preview.png` | Preview, byte copy (to redo at mountPreview) |
| 1 | `1-dawn-crow.jpg` | dawn, Nelim feeds the hens, the star officer crows |
| 2 | `2-four-beasts.jpg` | the four beasts at the south enclosure gate |
| 3 | `3-qiongqi.jpg` | the qiongqi picks its prey, Nelim braces behind sandbags |
| 4 | `4-nian-fire.jpg` | the nian beast breathes fire, Nelim holds a firecracker |
| 5 | `5-wind-barrier.jpg` | Blue fires, the mingshe's wind barrier throws the shot back (aim fixed by NPT 2a21050) |
| 6 | `6-sexie-aura.jpg` | the sexie's red aura drives Blue berserk |
| 7 | `7-extractor.jpg` | three archite capsules at the gene extractor, a hen on the bench |
| 8 | `8-tame-clones.jpg` | night, Nelim feeds the five tamed clones |

### Reviews by Virginie - 2026-10-13

She validated in chat ("validé") French of revision `54eb9fb` (`FRENCH_REVIEW.md`, regenerated at `e50d33d`: crow song without generic masculine, "rage meurtrière" for three berserker uses, qiongqi claw gene names, sound-wave wording), then `PUBLICATION.md` and `CHANGELOG.md` at `e50d33d`. Review-line table of `FRENCH_REVIEW.md` stays blank: shared script never writes it (hers), so her word recorded here.

Sections of the 1.0.0 dry-run, publication, non-regression and the 1.1.0 plan moved to `Docs/runs/2026-11-16-status-history.md` (run 38369174343 dry-run, run 38369937487 publication, tag v1.0.0 on ff3ecbd).

### Echo review - 2026-10-13

Kept. `Art/echo-source.png` is line art of winged qiongqi; gallery 2 (four beasts) and 3 (qiongqi far from Lan) show same beast, so echo and gallery agree, subject not moved. Preview rendered from it (`ccf028b`, flipped echo, cropped badge) is 896x504, opened full size: title, rule, summary, red echo under panel text, ModIcon bottom right, 1.6 badge top right, nothing cut. `Mod/About/Preview.png` sha256 `d39149d2...` equals `social_preview_sha256`: GitHub social preview current (repository public). `Art/` holds minimal set plus `textures-original/` (kept, owner decision 2026-10-11).

### Ecosystem - 2026-11-13

AUDIT 1.a, Steam search done by PiI (2026-11-13), full study in `docs/inventory/ecosystem-steam/AncientChineseBeastAndGeneExpandedRenew.md`. PiI one-line reply: original 3292446841 and its NoGene sibling 3047055011 (same author andery233xj, 21 shared defNames, held `needs_npt`) are the only mods sharing our defNames; no third fork; 19 weak hits, none shared.

Summary: Steam searches `Ancient Chinese Beast`, `Chinese mythology beasts`, `Chinese creature genes`. Found: original 3292446841 (2024-08, protected); NoGene sibling 3047055011 (fork-or-rewrite, same author's variant without the genes, not a competitor); link 3293695725 "Remove Ancient Chinese Beast Gene textures" (patch of the original, 1.6); name only 3313313985 "Ancient amorphous threat". PiI subscribed to the two small ones for study and unsubscribed them. Nothing else Chinese-themed holds our `SZ_*` defNames. Local scan from this session agrees (corpus 5302/5306 folders, 2 hits, our own `About.xml`). Gap settled 2026-11-13 (Steam API `GetPublishedFileDetails`, local `About.xml` files): 3047055011 created 2023-10-07, last updated 2023-11-27, `supportedVersions` 1.4 only, 1486 subscribers: dead for 1.6 (PiI's "alive 1.6" is wrong; the 2026-09-05 date is the local download). Upstream 3292446841 created 2024-07-19, last updated 2024-08-14, `supportedVersions` 1.4 and 1.5, folders `1.4/` `1.5/`, no 1.6, 3167 subscribers: not updated since our port. Licence not read. Nothing to add to `Check-OptionalCompat.ps1`, no combined pass owed at 8.f.


Owner decision 2026-11-16: no action on the patch 3293695725 (Remove Ancient Chinese Beast Gene textures) nor on the twin 3047055011 (NoGene, 1.4 only). Like every patch of an original, they wait for the release or the RTI pass; nothing asked of their authors, no own patch, no incompatibility declared now.
## History

Older dated sections moved to `docs/runs/2026-10-13-status-history.md` (until 2026-10-13), `docs/runs/2026-11-05-status-history.md` (2026-10-15 to 2026-11-03) and `docs/runs/2026-11-09-status-history.md` (2026-11-05 to 2026-11-08) and `docs/runs/2026-11-10-status-history.md` (2026-11-09 gallery tickets, scenes 1 to 8 up to scene 6 v5).

### NSB - 2026-11-08

First sync (no earlier one). NSB changed a lot since the 2026-10-23 feature (170 commits of `docs/` since 2026-10-13): a decorated Sanctuary is being built (the fixture `Nelims-tribe` is still the old undecorated one), `gravel-yard` is to become a zen dry garden, `enclosure-south` already carries a Nelim logo in flowers (zones 3 to 15, "sans objet dessus", VALIDE 2026-11-08), NSB roster holds no "Ren" (the guest is now Ryu "Blue" Sai, "formerly Ren in older documents"). Shotlist files not rewritten here: `write-shotlist` is next and takes these into account. Rules said back (owner 2026-11-05 and 2026-11-07): everything in NSB is free; a colonist or domestic animal outside NSB needs the owner's express validation (an animal the mod adds is authorised by default); a colonist's properties change only with her words; every outfit is free; every animal the mod includes must be in the gallery.

Places read: 2026-11-18 (NSB log since 2026-11-17 read: one new commit 2372794, plan `RECONSTRUCTION-SAUVEGARDE.md` to rebuild the Sanctuary save as `Nelims-tribe-v2`, plan only, nothing built, gates open; places keep their names and frames, no change used here); 2026-11-17 (NSB log since 2026-11-16 read, 38 commits of docs: only profiles of other pawns (Iori, Miel, Celeste), VALIDE, NEUTRES-TETE, VTW-BODYTYPES, TESTING, GALERIE, ACG-FAISABILITE, Roster.xlsx; no place doc, no change used here); 2026-11-16 (NSB log since 2026-11-13 read: no commit, no change); 2026-11-13 (NSB log since 2026-11-12 read: no commit, no change); 2026-11-12 (NSB log since 2026-11-09 read: one commit, `docs/` renamed `Docs/`, no content change, no place or roster change); 2026-11-09 (NSB log since 2026-11-08 read: no change to a place used here; z3 decor fixture added beside Nelims-tribe, our scenes place their own decor); earlier 2026-11-08 (`SANCTUAIRE-LIEUX.md` sections 11 and 12 and the place table, grep of `VALIDE.md` and `EMBELLISSEMENT-LIEUX.md`; `SANCTUAIRE-CASES.md` not opened). Tribe read: 2026-11-18 (same log: no change to Nelim, Blue, roster md, animals catalogue; only Iori, Miel, Quo, Quaren, Daichi, Dalia profiles and VALIDE, other pawns); 2026-11-17 (same log: no change to Nelim, Blue, roster md, animals catalogue); 2026-11-16 (same log, no commit); 2026-11-12 (same log, no change); 2026-11-09 (no change to roster, animals or profiles in the NSB log); earlier 2026-11-08 (`CATALOGUE-ANIMAUX.md`, `NELIM-PROFIL.md` first 40 lines, `GALERIE-HISTOIRE.md` cast, grep of `NSB-ROSTER.md`, `VALIDE.md`, `AVANCEMENT.md`; the other profiles not opened). Steps read: 2026-11-18 (NPT log since 2026-11-17: new steps head-type assert, screen text and windows, attack and haul orders, game component field, float menu option, def metadata log; no catalogue change; none serves this mod, gallery accepted, nothing used); 2026-11-17 (NPT log since 2026-11-16: two face-parts catalogue notes on the vanilla face, no step, none used); 2026-11-16 (NPT log since 2026-11-13 read: new steps, a rewording of the render-nodes steps; none used by this mod, gallery already accepted) (NPT log since 2026-11-12, steps.md and catalogues: no commit); 2026-11-12 (NPT log since 2026-11-09, stat only: decor burns, filth removal, floor building, culture and work-giver steps, hide tab bar and speed controls, `docs/` renamed `Docs/`; none serves a scene, none used); 2026-11-09 (new: step `the light of the map is dimmed to at most {float}` and `is refreshed` for dusk or night captures, fits scenes 7 and 8; step `the animals except A, B and C are kept out of the area from..to..` for hens out of frame, scenes 1 and 3; `the camera orthographic size is held at {float}`; none used yet, pending tickets kept); earlier 2026-11-08 (`PickleTools/docs/steps.md` StageDecor section and greps, git log since 2026-10-23; the rest of the 217 KB file and the catalogues not read).

| Place | Shots | Changes for the gallery | Last read |
| --- | --- | --- | --- |
| `statue-garden` | 1 | daylilies and a lit torch, removed after; NSB validated 2026-11-06 | 2026-11-08 |
| `enclosure-south` | 2 | two lit braziers; NSB now has the Nelim flower logo there, check the brazier cells (146,207) and (162,207) against it | 2026-11-08 |
| `gravel-yard` | 3, 5, 6 | sandbags, two lit torches and two daylilies for shot 6; NSB marks it "à embellir" (zen dry garden planned), cells may change | 2026-11-08 |
| `bare-clearing` (via `emerald-clearing`) | 4 | daylilies; free shooting zone, stays | 2026-11-08 |
| `water-garden` | none (was 6) | scene 6 moved to the gravel-yard 2026-11-12: its water draws a veil over everything | 2026-11-08 |
| `postindustrial-workshop` | 7 | capsules, daylilies, four lit torches; validated 2026-11-07; new NPT step "the light of the map is lifted to at least" fits the dark-room risk | 2026-11-08 |

| Colonist | Shots | Outfit per shot (garment, why) | Last read | Exceptions |
| --- | --- | --- | --- | --- |
| Nelim | 1 to 7 | as in `24-gallery.feature` (Taoist hat and blue middle robe, dragon robe, SanShan hat, burnt-orange robe, crimson robe, beige shirt); outfits are free | 2026-11-08 (first 40 lines) | none; hair `Roo_HD_Hair_Highpony` and `Roo_Royal_LongHD` under a hat are her validated canon |
| Ren | 5, 6 | `Apparel_CollarShirt`, `Apparel_Duster` crimson, `Apparel_Pants` | not in NSB | outside NSB, silver hair, `Eyes_Crimson`, bun: PENDING. NSB alternative: Ryu "Blue" Sai (short black hair, dark-green eyes, water tattoos, `Colonist` kind), no property change |

| Animal | Shots | Outfit | Last read | Exceptions |
| --- | --- | --- | --- | --- |
| Muffalo | 4 | none | `CATALOGUE-ANIMAUX.md` (not a named animal) | anonymous fauna: NSB says every other animal is decor ("Faune anonyme"), so no validation asked; the save holds no muffalo (the step spawns it) |

| Animal the mod includes | Shot(s) | Status |
| --- | --- | --- |
| `SZ_Chicken` (rooster and hen, "Pleiades star officer") | 1 | shown |
| `SZ_MingShe` | 2, 5 | shown |
| `SZ_QiongQi` | 2, 3 | shown |
| `SZ_YearBeast` | 2, 4 | shown |
| `SZ_SeXieInsect` (scorpion form) | 2, 6 | shown |
| `SZ_SeXie` (human form) | 8 (via `SZ_SeXie_Friendly`, same human form) | shown through its friendly clone, hostile one has no own shot |
| friendly clones (`SZ_MingShe_Friendly`, `SZ_QiongQi_Friendly`, `SZ_YearBeast_Friendly`, `SZ_SeXie_Friendly`, `SZ_SeXieInsect_Friendly`) | 8 | shown (candidate 8-tame-clones, `24-gallery.feature` lines 413-414 and the clone block) |

### Where the gallery work went

The shotlist table, the scene by scene journal and the run notes from 2026-11-08 to 2026-11-13 moved to `Docs/runs/2026-11-13-status-history.md`. Current plan in the STATE block below.
Older journal lines (2026-11-13 to 2026-11-15: scene 5 v4 to v9c, review sent, candidate method retired) moved to `Docs/runs/2026-11-16-status-history.md`.

Translation audit 2026-11-13: Virginie validated the French review ("je valide la relecture"). `translation_fr` stays `complete`. The French of this revision is hers, validated; after 24 /review-translation passes and the names closed (Docs/review-names.md). The upstream pull request with the text corrections (BACKLOG TODO) may now be proposed to her for its go.

NOTE 2026-11-15 (owner, scene 1, applies to every scene): if the same animal appears twice in an image (two hens), one faces the camera and the other is in profile; for three, add one seen from behind. Apply if scene 1 is ever redone, and when any scene is recomposed. Raised to Audit.

NOTE 2026-11-16 (owner): the tool for every image generation is DALL-E (OpenAI), always. PUBLICATION.md "AI-GENERATED" already says DALL-E for the preview background and the icon: unchanged, no model version to add. Told to Audit for the shared procedure.

Summary 2026-11-17 (journal of 2026-11-16 and 2026-11-17 moved to `Docs/runs/2026-11-17-status-history.md`): 1.1.0 published (run 43945169309, tag v1.1.0, item 3806709132), postOnSteam done by Virginie. 1.7 diagnostic: baseline a8a1 170 passed; own reds were slow-tick time-outs (llvmpipe, about 1 tick per 1 to 2 s), fixed by the PiT tick-batch steps: drought 585f, scheduler 40a4, births 3fcf, firecracker 2369, all green. Evidence in `Tests/Pickle/Evidence/`. Open from 1.1.0: 1.6 non-regression (14.a), cleanUp.


Summary 2026-11-18 (STATE lines of 2026-11-17 moved to `Docs/runs/2026-11-18-status-history.md`): CI regenerated (stamp d20db370c66b), tested_1_7 yes, 1.7 declared in supportedVersions, Preview 1.7 uploaded to the repo Social preview, replay 8.m/8.n/9.f done (code_review_sha, echo_review_sha refreshed), stage mountPreview[1.2.0], 1.6 non-regression bf17 filed. No pending owner action.


STATE 2026-11-18 (resume): ticket bf17 (1.6 non-regression, English, tree 4fcb011) delivered in Inbox: summary.json 238 total, 200 passed, 0 failed, 38 skipped, exitReason passed. 14.a green for 1.1.0. evidence minified (110.7 to 39.4 MB) and moved to Tests/Pickle/Evidence/2026-11-17j-16-noregression-en, Inbox empty. Owed: sync-nsb-npt (NPT changed 2026-11-18), STATUS.md journal move (29 KB).

STATE 2026-11-18 (10.g): mountPreview[1.2.0] to writeReleaseDocs[1.2.0]. Preview 1.7 rendered, echo kept, social_preview_sha256 current (10.a to 10.f done 2026-11-17). Owner (2026-11-18): cleanUp not needed when the mod goes back into a dev loop, 1.2.0 continues without it; remark sent to Audit.

STATE 2026-11-18 (writeReleaseDocs 11.a to 11.k): 11.a description complete (RimImmortal-Living line added, About.xml synced and checked), 11.b order kept, 11.c About.xml equals the block, 11.d Workshop links on CCE, ADS2, Nocturnal Animals, RimImmortal-Living, 11.e PUBLICATION.md updated (gallery state, dependencies re-read, change note 1.2.0), 11.f CHANGELOG [Unreleased] holds 1.2.0, 11.g adult boxes: none, images unchanged since 2026-11-15, Preview opened 2026-11-17, 11.h thanks_drafted_line 1.2: gallery mods listed in ATTRIBUTION.md "Gallery set"; drafts for RimImmortal-Living 3326145525 and Tribal Tattoos 2782262247, Covers extended for Roo HD 3559870636, EyeGenes3 3745223213, Hat Hair Control 3760821540 (pages not read, pseudos to confirm), 11.i change note 1.2.0 BBCode list written, UTI comment dropped (13.b), 11.j owner reread owed, 11.k Check-Status 0 error 0 warning, 9a steps: tick-batch features 25 to 28, 9b GALLERY-PROPS row added.

STATE 2026-11-18 (11.j done, 12.a to 12.e): Virginie validated PUBLICATION.md and CHANGELOG.md of the 1.2 line ("je valide"), publication_changelog_review_sha set. 12.a code_review_sha refreshed (text only, no code). 12.b dependencies unchanged since declareDependencies (About.xml diff is the description only). 12.c Check-Status -Strict: 0 error, 0 warning. 12.c bis: documents already minified 2026-11-16 (1a96f5b) and unchanged since, nothing to redo. 12.d tree pushed, Source and Assemblies unchanged since 6589e5f. 12.e CHANGELOG dated [1.2.0] - 2026-11-18, dry-run next with --preview --description (Preview and description changed since 1.1.0). Note: STYLE_RIMWORLD (2026-11-18) says the ModIcon has no reserved corner in a new prompt; our Preview keeps its accepted top-left icon, not re-rendered.

STATE 2026-11-18 (12.e, 12.f, 12.h): dry-run 1.2.0 green, run 44301292364, SHA 56aeb94e68c17453dadf75b34a5e354cd8a3ae8f, options --preview --description (title false). Log read: version 1.2.0; change note is the real BBCode list of PUBLICATION.md 1.2.0 (three items); preview to send sha256 0868266b... equals social_preview_sha256 (page now holds 394a74e0..., the old 1.6 badge); description diff against the page printed; tags to send Mod, 1.6, 1.7 (adds 1.7). workflow_stage writeReleaseDocs to publish[1.2.0]. Publish dispatch next with the same options, approval of steam-production by Virginie; PublishedFileId.txt already committed (3806709132).

STATE 2026-11-18 (13.a): publish dispatched, run 44301506459, SHA 56aeb94e68c17453dadf75b34a5e354cd8a3ae8f, version 1.2.0, --preview --description, waiting for Virginie to approve steam-production. After the upload: subscribe test through PiI (13.b), startWatch (13.f).
