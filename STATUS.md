---
localization: complete
translation_en: complete
translation_fr: complete
settings_audit: not_applicable
code_review_sha: 1a96f5bc5f12d7df4261fce3473025703c8b437b  # 2026-11-16, 12.a: diff acf8b48..HEAD over Mod and Source read: only the About.xml description text (Languages paragraph, SamBucher wording), revue du diff : texte seul, no code. Previous: acf8b487c6fd413a3fd6f7dea299232702f466d6  # 2026-11-16, 8.m: diff 6589e5f..HEAD over Mod and Source read: Source, Assemblies and Patches unchanged; Mod/Defs hold six text-tag lines only (description, label) and Mod/Languages and About.xml text, OptionalCompat.xml one declaration: revue du diff : textes seuls, no code. Previous: 6589e5f5ef5c4b560b62bd1ccfa9b74f6241b2ce  # 2026-11-07, 8.m: Opus review f809e47f..0962a7e (4 findings in Ability_WindBarrier.cs), fixed in 6589e5f, diff 0962a7e..HEAD re-read (only that fix, Source and the rebuilt DLL), barrier replay f878 green. Previous: f809e47f4cd07d3a34b67b1d9c119e762a478f31  # 2026-10-13, 8.m exceptions: reviewed diff 54eb9fb..HEAD over Mod and Source (git diff --stat): only Mod/About/About.xml (description text, nothing else) and Mod/ATTRIBUTION.md (one sentence about the removed Art/textures-original), no code: revue du diff : images et texte seuls. Previous: 54eb9fb, 2026-10-13, 8.m (moved past the French and gene-name text edits of this commit, Defs QiongQi.xml and MingShe.xml read, no code; and past two description-only edits of About.xml, no code): 5ea69ab..HEAD over Source and Mod holds no code change (only Source/Directory.Build.props intermediates path build/, ATTRIBUTION.md, Preview.png, desktop.ini removed): 0 findings. Earlier review, was `code_review`: <sha> (2026-10-08, /code-review at low effort over 89a2575..5ea69ab, the 0.1.0 commit that tracked the PublishedFileId, limited to Source, Mod/Defs, Mod/Patches and Tests/Pickle/Source: 0 findings; low effort reads the diff once, no verify pass. First review of this mod, nothing earlier existed)
audit_revision: 67a4b37 (HEAD, pushed, tree clean when the 2026-10-01 audit began). While it ran, another session regenerated `Art/` and `Mod/About/Preview.png` in the working tree: uncommitted, not touched and not audited here
mod:          Ancient Chinese Beast And Gene Expanded Renew (unofficial)
packageId:    nelim.ancientchinesebeastandgeneexpanded
repo:         Rimworld-Ancient-Chinese-Beast-And-Gene-Expanded-Renew
visibility:   public
detached:     yes
workflow_stage: playTests[1.2.0]
social_preview_sha256: 394a74e01465952f456c84ce7069270661b750f73df85d53730a465c6c0e2626
echo_review_sha: acf8b487c6fd413a3fd6f7dea299232702f466d6  # 2026-11-16, 10.a: echo kept again, echo-source.png and gallery 1 to 8 unchanged since 2026-11-15; only 0-preview.png (our own render of the new Preview) and Preview.config.json changed. Previous: 9d5b8f0b962db7260d3622a85774d6cad1044006  # 2026-11-15, 10.a: echo kept (echo-source.png, winged qiongqi line art, Preview panel bottom-left); the new gallery shows the same beast (images 2, 3, 8), subject unchanged; Preview.png unchanged, still equals 0-preview.png and social_preview_sha256
publication_changelog_review_sha: d7493d64d8c270087bd8ab943ce3044d6f67a59b
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
session:      local_5bc1b5af-5a8d-4b9e-98fa-5f1f54777aa6
updated:      2026-11-16
upstream_synced: 2026-11-16 MonsterTower/AncientChineseBeast@f6d3d19
protocols_read_sha: 70263f7abedb6f58a8a477e803c19bd877a406cf
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

Places read: 2026-11-16 (NSB log since 2026-11-13 read: no commit, no change); 2026-11-13 (NSB log since 2026-11-12 read: no commit, no change); 2026-11-12 (NSB log since 2026-11-09 read: one commit, `docs/` renamed `Docs/`, no content change, no place or roster change); 2026-11-09 (NSB log since 2026-11-08 read: no change to a place used here; z3 decor fixture added beside Nelims-tribe, our scenes place their own decor); earlier 2026-11-08 (`SANCTUAIRE-LIEUX.md` sections 11 and 12 and the place table, grep of `VALIDE.md` and `EMBELLISSEMENT-LIEUX.md`; `SANCTUAIRE-CASES.md` not opened). Tribe read: 2026-11-16 (same log, no commit); 2026-11-12 (same log, no change); 2026-11-09 (no change to roster, animals or profiles in the NSB log); earlier 2026-11-08 (`CATALOGUE-ANIMAUX.md`, `NELIM-PROFIL.md` first 40 lines, `GALERIE-HISTOIRE.md` cast, grep of `NSB-ROSTER.md`, `VALIDE.md`, `AVANCEMENT.md`; the other profiles not opened). Steps read: 2026-11-16 (NPT log since 2026-11-13 read: new steps, a rewording of the render-nodes steps; none used by this mod, gallery already accepted) (NPT log since 2026-11-12, steps.md and catalogues: no commit); 2026-11-12 (NPT log since 2026-11-09, stat only: decor burns, filth removal, floor building, culture and work-giver steps, hide tab bar and speed controls, `docs/` renamed `Docs/`; none serves a scene, none used); 2026-11-09 (new: step `the light of the map is dimmed to at most {float}` and `is refreshed` for dusk or night captures, fits scenes 7 and 8; step `the animals except A, B and C are kept out of the area from..to..` for hens out of frame, scenes 1 and 3; `the camera orthographic size is held at {float}`; none used yet, pending tickets kept); earlier 2026-11-08 (`PickleTools/docs/steps.md` StageDecor section and greps, git log since 2026-10-23; the rest of the 217 KB file and the catalogues not read).

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

STATE 2026-11-16 (writeReleaseDocs, 11.a to 11.k read): 11.a description complete, `Languages` paragraph added (Chinese extended with Claude, reviewed by ChatGPT, no native check; French proofread by a native speaker); 11.b structure checked (body, IF I GO QUIET, AI-GENERATED, THANKS, ATTRIBUTION line, `Source code on GitHub` last, target the mod repo); 11.c About.xml description regenerated from PUBLICATION.md, `sync-about-description.mjs` says identical; 11.d links on every cited mod; 11.e PUBLICATION.md up to date (gallery table 0 to 8 accepted, dependencies, adult boxes: nine images); 11.f CHANGELOG `## [Unreleased]` holds the 1.1.0 entries incl. the Languages and review items; 11.g adult boxes none, nine images opened 2026-11-15; 11.h thank-you and Use This Instead drafts exist (post at `postOnSteam`); 11.i change note `[b]1.1.0[/b]` written; 11.k: gameplay Pickle steps exist (`Tests/Pickle/Source`, 20 step files); `GALLERY-PROPS.md` 9b n/a: the mod ships no prop, apparel or hairstyle for other mods (only the gene extractor, its own, seen in gallery 7). OPEN: 11.j, Virginie reads `PUBLICATION.md` and `CHANGELOG.md` (the Steam description changed, so the 2026-10-13 review `5bed84a` is stale); `publication_changelog_review_sha` is written only on her chat confirmation.

STATE 2026-11-16 (11.j done): Virginie read PUBLICATION.md and CHANGELOG.md of this revision and validated ("je valide, relu", chat). `publication_changelog_review_sha` set to the commit read. 11.a to 11.k closed.

STATE 2026-11-16 (12.a to 12.d): 12.a `code_review_sha` refreshed (only About.xml description text since the last read, revue du diff : texte seul); 12.b dependencies and OptionalCompat.xml unchanged since declareDependencies (XeoNovaDan declaration added and checked 2026-11-16); 12.c `Check-Status -Strict` 0 ERROR 0 WARN; 12.c bis Docs/GALLERY.md, MANUAL-TESTS.md, PROTOCOLS-READ.md and Tests/Pickle/README.md minified, identifiers checked unchanged (BACKLOG, TESTING, STATUS, README were minified 2026-10-16; review-names.md and review-refusals.md left whole, ChatGPT reads them; PROMPT_*.md left whole, it is a prompt); 12.d tree clean after the commit, Run-All 9 of 9 and Source and DLL unchanged since 6589e5f. NEXT 12.e: date the CHANGELOG `[1.1.0]`, dry-run on that SHA. Open question for the owner: publish 1.1.0 now or wait for the 1.7 pass (CHANGELOG says "grouped with the 1.7 pass").

STATE 2026-11-16 (12.e to 12.h): owner "oui" to publishing 1.1.0 now (without waiting for the 1.7 pass; 1.7 comes later). CHANGELOG `## [1.1.0] - 2026-11-16`. Rollback target (12.f): tag v1.0.0, commit ff3ecbd, last known good. 12.f text gate: Virginie reads before the send the French and Chinese wording changed after her 2026-11-13 validation (review passes 24 to 29: sexie sound, gene provenance, quadruped leg labels, scorpion poison, PUBLICATION thanks wording); pending her word in chat. `publication_changelog_review_sha` = the commit that dates [1.1.0] (her 11.j reading covered the same content, only the heading changed). workflow_stage `publish[1.1.0]` set before the dry-run (12.h).

### Dry-run 1.1.0 - 2026-11-16

Run [43944718301](https://github.com/vbardales/Rimworld-Ancient-Chinese-Beast-And-Gene-Expanded-Renew/actions/runs/43944718301), `publish-tag.yml`, mode dry-run, ref `c42180d847a35f09d8fb1d4470d3a7344b49999c`, version 1.1.0, options `update_preview=true update_description=true update_title=false update_tags=false`, template `7148d24d02d5`. Success; log read: 195 files, 6.84 MB staged (Textures 80 files 5.47 MB), description is the plain text of PUBLICATION.md, change note `[b]1.1.0[/b]`, preview to send sha256 `394a74e0...` (816664 bytes) against 625361 bytes on the page now, title and tags not sent, "nothing was sent to Steam". The runner's build of the DLL differs in bytes from the committed one (committed `9dc0e15c...`, rebuilt `1a0ff6e7...`): the committed, tested DLL ships, the rebuilt one is discarded (workflow warning by design). Publish needs the commit above unchanged and the word of Virginie on the French wording changed after her 2026-11-13 validation, then her approval of `steam-production`.

### Publication 1.1.0 - 2026-11-16

Virginie validated in chat the French and English wording changed after 2026-11-13 ("Oui, validé"). Publish run [43945169309](https://github.com/vbardales/Rimworld-Ancient-Chinese-Beast-And-Gene-Expanded-Renew/actions/runs/43945169309) dispatched with `dispatch-publish.sh` on `c42180d847a35f09d8fb1d4470d3a7344b49999c`, version 1.1.0, options `--preview --description` (same as the dry-run 43944718301); it waits for her approval of `steam-production`.

STATE 2026-11-16 (published): run 43945169309 green (`publish` and `tag-and-release`), approved by Virginie on `steam-production`. Tag `v1.1.0` and GitHub release exist; `About/PublishedFileId.txt` unchanged (3806709132, committed). Item already public (switched 2026-10-13). 13.b: SUBSCRIBE-TEST? sent to PiI, answer awaited. workflow_stage `startWatch[1.1.0]`.

STATE 2026-11-16 (13.b done): PiI SUBSCRIBE-TEST OK on 3806709132 (re-downloaded, item updated 20:01 UTC): 195 files, About.xml byte-identical to Mod/About/About.xml with the Languages paragraph, DLL identical (cmp), Languages ChineseSimplified, English, French. About.xml has no modVersion tag, so the version is not readable from the folder (tag v1.1.0 and the run prove it). Next: 14.f and 14.g watch, then postOnSteam.

STATE 2026-11-16 (14.f done): GitHub repo watch set (`gh api PUT subscription`, subscribed true); Steam comment notifications are Virginie's; collection 3815982565 membership to confirm with her. workflow_stage `postOnSteam[1.1.0]`: Virginie posts the drafts of PUBLICATION.md (original page 3292446841, Chinese Comprehensive Expansion 3221850511, Use This Instead 3396308787) and uploads the new gallery `Art/Gallery/0..8` by hand (gallery changed since the 1.0.0 upload).

DECISION 2026-11-16 (owner): the RimWorld 1.7 pass goes into the next version, 1.2.0 (1.1.0 stays a 1.6-only release). Plan: finish postOnSteam, run the 1.6 non-regression (14.a) on the published 1.1.0, then open the 1.7 diagnostic (`tested_1_7`, AUDIT "Passe 1.7") with target 1.2.0; `<li>1.7</li>` and the 1.7 Preview badge only after a green 1.7 run.

NOTE 2026-11-16 (Audit answer, 1.7): prerequisites met for a first ticket (Pickle proven on 1.7 with RetroJoyRenew, NPT net48 steps load, SaB load pass 2026-11-10; a red caused by a tool is a tool defect, never `tested_1_7: no`). Ticket through the file-pickle-ticket skill on the 1.7 lane (game /home/nelim/rimworld17, PickleSrc branch pr63, sequential), usual wsl-deps map plus No Version Warning as a test-only mod (Workshop id to get from Virginie, never in LoadFolders or About), English only (no French pack on 1.7). Test the current net472 DLL with its Harmony patches FIRST; a `1.7/` folder (net10.0) and `<v1.7>` in LoadFolders only if it fails. `<li>1.7</li>` only after a green 1.7 run AND Virginie's word, in the same commit as the Preview redo; 1.2.0 is the right minor; the 1.7 declaration goes upstream as a separate PR (upstream_mod_remotes exists) after the green run. Record `tested_1_7` and log errors in docs/runs/.

STATE 2026-11-16 (change notes): Virginie posted the real BBCode notes of 1.0.0 and 1.1.0 on the Steam change-notes page (the pointer sentence is gone). Rule from the owner: a change note is always the real changelog (BBCode list), never again the pointer; proposed to Audit as a shared rule with a lint. Still open in postOnSteam: the three comments and the gallery replacement (her word).

STATE 2026-11-16 (gallery posted): Virginie replaced the gallery of item 3806709132 with `Art/Gallery/0` to `8` (her word in chat). Open in postOnSteam: the three comments (original 3292446841, Chinese Comprehensive Expansion 3221850511, Use This Instead 3396308787) and the collection check (3815982565).

STATE 2026-11-16 (back to code[1.2.0]): owner order, the 1.7 pass restarts the chain at `code[1.2.0]` (AUDIT 14.e). 1.1.0 is published and in watch; still owed from it: the three Steam comments and the collection check (Virginie), the 1.6 non-regression of the published 1.1.0 (14.a, folded into the first 1.7 ticket cycle: Mod and Source are unchanged), cleanUp. Open for 1.2.0: No Version Warning Workshop id from Virginie; 1.7 ticket through file-pickle-ticket on the 1.7 lane; test the net472 DLL first. The steam-note lint of Audit (70263f7) applies from writeReleaseDocs.

STATE 2026-11-16 (14.b/14.h comments): Virginie says the three comments (original 3292446841, Chinese Comprehensive Expansion 3221850511, Use This Instead 3396308787) were already posted earlier; nothing more to post. Tags: not verified (Steam page answered 429), the CI sent none (update_tags=false at 1.0.0 and 1.1.0); to check on the page, the `1.7` tag comes with `update_tags=true` at 1.2.0. Collection 3815982565 membership still to confirm.

STATE 2026-11-16 (checks by Virginie): Steam tags are set and the item is in the collection 3815982565 (her word in chat). Git tags v1.0.0 (ff3ecbd) and v1.1.0 (c42180d) and their releases exist on origin. No Version Warning id asked to PiI.

STATE 2026-11-16 (3.0 and 1.7 ticket): 3.0 upstream sync: `MonsterTower/AncientChineseBeast` holds no commit after f6d3d19 (fetched 2026-11-16), `upstream_synced` updated. 1.7 diagnostic filed: ticket 20261116-211244-709-a8a1 (a8a1), English, `-Game /home/nelim/rimworld17`, `-DepMap wsl-deps.v17.map` (No Version Warning 2599504692 test-only, id from PiI), `-Filter '!24-gallery'` (the gallery set is not a 1.7 matter), evidence `Tests/Pickle/Inbox/2026-11-16a-v17-en`, tree frozen at c180a81 (current net472 DLL, no 1.7 folder). WAITING position 4/4. On RUN_DONE: read summary.json (exitReason first) and junit.xml, then `tested_1_7` (yes or no with the log error in docs/runs/; a tool-caused red is a tool defect, never `no`).

STATE 2026-11-16 (chain walked down to playTests[1.2.0], owner order, ticket a8a1 kept): proofs read now: 3.a no feature in remaining, 3.b Source and DLL unchanged since 6589e5f (git diff empty), 3.c CHANGELOG `## [Unreleased]` planned as 1.2.0; 4.x dependencies and OptionalCompat.xml unchanged, Check-OptionalCompat OK, workshop_required_items done; 5.x settings_audit not_applicable; 6.x localization, translation_en, translation_fr complete (Virginie validated the wording changes of 2026-11-16); 7.x `Tests/Run-All.ps1` rerun 9 of 9 green, Pickle suite and Inbox in place. 8.0 ecosystem: PiI study 2026-11-13 stands (links block appended 2026-11-16). At playTests: ticket a8a1 (1.7 diagnostic, English) in the queue; on its result `tested_1_7`.

STATE 2026-11-16 (before sleep): playTests[1.2.0], ticket a8a1 (1.7 diagnostic, English, `-Game /home/nelim/rimworld17`, `wsl-deps.v17.map`, `!24-gallery`, tree frozen at c180a81) in the queue. On RUN_DONE: read summary.json (exitReason, total, passed) then junit.xml, triage the Inbox folder `Tests/Pickle/Inbox/2026-11-16a-v17-en`, record `tested_1_7` (yes, or no with the log error in docs/runs/; tool-caused red is a tool defect, never `no`), then replay-audit. Owed from 1.1.0: 1.6 non-regression (14.a) folded into the first 1.7 cycle, cleanUp. Rule of the owner: "J'attends" lines carry no ticket index, position or inbox (panel shows them). Change notes are real BBCode changelogs. Open for Virginie: nothing.
