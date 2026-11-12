---
localization: complete
translation_en: complete
translation_fr: complete
settings_audit: not_applicable
code_review_sha: 6589e5f5ef5c4b560b62bd1ccfa9b74f6241b2ce  # 2026-11-07, 8.m: Opus review f809e47f..0962a7e (4 findings in Ability_WindBarrier.cs), fixed in 6589e5f, diff 0962a7e..HEAD re-read (only that fix, Source and the rebuilt DLL), barrier replay f878 green. Previous: f809e47f4cd07d3a34b67b1d9c119e762a478f31  # 2026-10-13, 8.m exceptions: reviewed diff 54eb9fb..HEAD over Mod and Source (git diff --stat): only Mod/About/About.xml (description text, nothing else) and Mod/ATTRIBUTION.md (one sentence about the removed Art/textures-original), no code: revue du diff : images et texte seuls. Previous: 54eb9fb, 2026-10-13, 8.m (moved past the French and gene-name text edits of this commit, Defs QiongQi.xml and MingShe.xml read, no code; and past two description-only edits of About.xml, no code): 5ea69ab..HEAD over Source and Mod holds no code change (only Source/Directory.Build.props intermediates path build/, ATTRIBUTION.md, Preview.png, desktop.ini removed): 0 findings. Earlier review, was `code_review`: <sha> (2026-10-08, /code-review at low effort over 89a2575..5ea69ab, the 0.1.0 commit that tracked the PublishedFileId, limited to Source, Mod/Defs, Mod/Patches and Tests/Pickle/Source: 0 findings; low effort reads the diff once, no verify pass. First review of this mod, nothing earlier existed)
audit_revision: 67a4b37 (HEAD, pushed, tree clean when the 2026-10-01 audit began). While it ran, another session regenerated `Art/` and `Mod/About/Preview.png` in the working tree: uncommitted, not touched and not audited here
mod:          Ancient Chinese Beast And Gene Expanded Renew (unofficial)
packageId:    nelim.ancientchinesebeastandgeneexpanded
repo:         Rimworld-Ancient-Chinese-Beast-And-Gene-Expanded-Renew
visibility:   public
detached:     yes
workflow_stage: shootGallery[1.1.0]
social_preview_sha256: ef4033f58e512d0f5eaff4384e2ca7d1c0c5e0a2142fb371a5569a324223052c
echo_review_sha: d4409fa79443f95e80e837fc4941245708106090  # 2026-10-23, 10.a: echo kept (echo-source.png, Preview panel bottom-left, validated by Virginie in chat)
publication_changelog_review_sha: 5bed84a774984f2711ba3048ce90046038b30fcc
licence:      silent
licence_at:   reviewed 2026-09-12 - original files and About.xml, English and Chinese Workshop
            descriptions, all 68 public comments, and the four coauthors' Steam profiles;
            no explicit reuse permission or prohibition found, no source repository link found.
            Local MIT licence covers port additions only; abandonment is not established.
upstream_mod_remotes:
  - https://github.com/MonsterTower/AncientChineseBeast
dependencies: declared
showcase:     complete
tested_on: 2026-11-06 pickle 6589e5f (1.6, English: feature 20 wind barrier 2/2 and feature 13 original mod 1/1 green; French feature 15 22/22 green 2026-11-03)
workshop:     published 2026-10-13, item 3806709132, public since 2026-10-13 (the owner switched it, after the upload), version 1.0.0, tag v1.0.0, run 38369937487 (publish and tag-and-release green)
remaining:
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
updated:      2026-11-12
upstream_synced: 2026-11-12 MonsterTower/AncientChineseBeast@f6d3d19
protocols_read_sha: fd4f8885d84a91c2b46f234f4461d41416c94534
---
# Ancient Chinese Beast And Gene Expanded Renew: status

Read by sweep across every mod, not by asking each thread in turn. Lives at root, never inside `Mod/`, so Steam never receives it.

## Where this one stands

### Gallery - 2026-10-13

Seven staged photos on Sanctuary Backlot plus Preview, all accepted by owner (commits `54945a2`, `f41a79e`, `09577d4`, `35ba34e`, `1a91870`); `Art/Gallery/` holds nothing else. Opened again 2026-10-13. Order: four beasts together second (most demonstrative), dawn crow opens story.

| Index | File | Shows |
| --- | --- | --- |
| 0 | `0-preview.png` | Preview, byte copy |
| 1 | `1-dawn-crow.png` | rooster and hen among statues (green overlay lines at edges, accepted as is) |
| 2 | `2-four-beasts.png` | the four beasts together |
| 3 | `3-qiongqi-far.png` | the qiongqi far from Lan |
| 4 | `4-nian-fire.png` | the nian beast breathing fire |
| 5 | `5-wind-barrier.png` | the mingshe inside its wind barrier |
| 6 | `6-sexie-aura.png` | the sexie scorpion form in its aura |
| 7 | `7-extractor.png` | the gene extractor in sunlit workshop |

### Reviews by Virginie - 2026-10-13

She validated in chat ("validé") French of revision `54eb9fb` (`FRENCH_REVIEW.md`, regenerated at `e50d33d`: crow song without generic masculine, "rage meurtrière" for three berserker uses, qiongqi claw gene names, sound-wave wording), then `PUBLICATION.md` and `CHANGELOG.md` at `e50d33d`. Review-line table of `FRENCH_REVIEW.md` stays blank: shared script never writes it (hers), so her word recorded here.

### Dry-run 1.0.0 - 2026-10-13

Run `38369174343` (https://github.com/vbardales/Rimworld-Ancient-Chinese-Beast-And-Gene-Expanded-Renew/actions/runs/38369174343), `publish-tag.yml`, mode dry-run, ref `ff3ecbd8d5aebf1ae9ed741c0287567ef20a91ce`, version 1.0.0, options `update_preview=true update_description=true update_title=false update_tags=false`, template `ef2f76993832`. Success; log read: 189 files, 6.64 MB staged (Textures 80 files, no `.dds`, `Assemblies/` 1 file), change note `[b]1.0.0[/b]`, preview `d39149d2...` 625361 bytes (equals committed Preview), description 6786 chars converted to BBCode (names no RimWorld version, carries Chinese Comprehensive Expansion thanks), tag-and-release skipped as expected. Item private, so no comparison with public page. Gallery (`Art/Gallery/` 0 to 7) is owner's manual upload.

### Publication 1.0.0 - 2026-10-13

Run [38369937487](https://github.com/vbardales/Rimworld-Ancient-Chinese-Beast-And-Gene-Expanded-Renew/actions/runs/38369937487): dispatched by this session with `dispatch-publish.sh` on `ff3ecbd8d5aebf1ae9ed741c0287567ef20a91ce` (same options as dry-run), approved by Virginie on `steam-production`; `publish` and `tag-and-release` green. Tag `v1.0.0` on `ff3ecbd` and GitHub release exist. `About/PublishedFileId.txt` still reads 3806709132, committed. Item stays private (visibility never sent): owner turns it public, uploads gallery by hand. Not read yet: item page, which private item does not show to session. `USE_THIS_INSTEAD.md` row drafted, comment drafted in `PUBLICATION.md`; thank-you comments (Chinese Comprehensive Expansion row in `WORKSHOP_COMMENTS.md`) wait for public switch (14.b).

### Non-regression 1.0.0 (14.a) - 2026-10-13

Item public (owner, 2026-10-13); Steam API still answered `result 9` (not readable) few minutes after, so public page not read yet. Gallery uploaded by owner. Six requests filed on revision `ff3ecbd` (Mod and Source unchanged since): English `20261013-104025-715-5390` (the 2026-10-13a run (evidence deleted 2026-10-18)), French `20261013-104026-466-9293` (`2026-10-13b-nr-fr`), ADS2 `...-e453` (`c`), Nocturnal `...-66be` (`d`), CCE `...-a2ea` (`e`), original mod `...-09c7` (`f`). Result English (the 2026-10-13a run (evidence deleted 2026-10-18), ticket 5390, `exitReason: failed`): 119 scenarios, 86 passed, 2 failed, 31 skipped. RED: two wind-barrier scenarios ("the barrier cuts what stands inside and spares what stands outside", "the barrier throws back a shot fired from outside it"), both `NullReferenceException` in `ListerThings.Remove` via `Ability_WindBarrier.AbilityTick` -> `Destroy`, the null reference guard of 79d0cd6 (2026-10-01) meant to stop; both green on 2026-10-08b in FRENCH (the 2026-10-08b run (evidence deleted 2026-10-18)); English pass 1 had them red before guard, no English green recorded; same game 1.6.4871 rev600, same assembly (built 2026-10-10 19:34). Dispatcher held lock ~60 min before END. Cause not found yet. Cause analysis: `ListerThings.Remove` throws only when map lister never registered projectile (group lists created in `Add`), so guard of 79d0cd6 cannot catch it; static list `Ability_WindBarrier.projectiles` stays stuck after throw, hence nine repeats. Replay of feature `20-wind-barrier` in English filed: `20261013-162831-460-e0b4` (the 2026-10-13g run (evidence deleted 2026-10-18)). Replay `2026-10-13g-nr-barrier-replay` (ticket e0b4, `exitReason: passed`, 2/2, 0 NullReference in Player.log, same game and DLL): two barrier scenarios green alone, red only inside full English pass. So not deterministic on barrier itself; order of full pass (state left by earlier scenarios, e.g. static projectile list) suspect, not proven. Defect of 1.0.0 stands as intermittent; hardening of Ability_WindBarrier.cs written 2026-10-14 in 1.1.0 (local lists, remove-before-destroy, same-map check, try/catch with one warning; dotnet build green; Tests.csproj fixed 2026-10-14 (ignored Tests/build/ held Pickle-step AssemblyAttributes.cs that SDK globbed, CS0579); Run-All now: 108 content checks 0 failure, 26 assembly contracts nothing to report, then translations step still stops with 6 findings, as on 2026-10-13 with change stashed; barrier not played yet). Code review sha and playTests reopen on this Source change. Other five results not in.

### Next version 1.1.0 - 2026-10-13

Owner (2026-10-13): description-form fix waits, grouped with RimWorld 1.7 pass; minor bump to 1.1.0, so chain reopens at `code[1.1.0]` (AUDIT.md 14.e). Comments posted by owner 2026-10-13: original mod page, Chinese Comprehensive Expansion, Use This Instead (registers updated). Six 1.0.0 non-regression tickets still running on `ff3ecbd`. `tested_1_7` absent: 1.7 prerequisites (Pickle PR 63, NPT steps on net10.0) not read here.

### Echo review - 2026-10-13

Kept. `Art/echo-source.png` is line art of winged qiongqi; gallery 2 (four beasts) and 3 (qiongqi far from Lan) show same beast, so echo and gallery agree, subject not moved. Preview rendered from it (`ccf028b`, flipped echo, cropped badge) is 896x504, opened full size: title, rule, summary, red echo under panel text, ModIcon bottom right, 1.6 badge top right, nothing cut. `Mod/About/Preview.png` sha256 `d39149d2...` equals `social_preview_sha256`: GitHub social preview current (repository public). `Art/` holds minimal set plus `textures-original/` (kept, owner decision 2026-10-11).


## History

Older dated sections moved to `docs/runs/2026-10-13-status-history.md` (until 2026-10-13), `docs/runs/2026-11-05-status-history.md` (2026-10-15 to 2026-11-03) and `docs/runs/2026-11-09-status-history.md` (2026-11-05 to 2026-11-08) and `docs/runs/2026-11-10-status-history.md` (2026-11-09 gallery tickets, scenes 1 to 8 up to scene 6 v5).

### NSB - 2026-11-08

First sync (no earlier one). NSB changed a lot since the 2026-10-23 feature (170 commits of `docs/` since 2026-10-13): a decorated Sanctuary is being built (the fixture `Nelims-tribe` is still the old undecorated one), `gravel-yard` is to become a zen dry garden, `enclosure-south` already carries a Nelim logo in flowers (zones 3 to 15, "sans objet dessus", VALIDE 2026-11-08), NSB roster holds no "Ren" (the guest is now Ryu "Blue" Sai, "formerly Ren in older documents"). Shotlist files not rewritten here: `write-shotlist` is next and takes these into account. Rules said back (owner 2026-11-05 and 2026-11-07): everything in NSB is free; a colonist or domestic animal outside NSB needs the owner's express validation (an animal the mod adds is authorised by default); a colonist's properties change only with her words; every outfit is free; every animal the mod includes must be in the gallery.

Places read: 2026-11-12 (NSB log since 2026-11-09 read: one commit, `docs/` renamed `Docs/`, no content change, no place or roster change); 2026-11-09 (NSB log since 2026-11-08 read: no change to a place used here; z3 decor fixture added beside Nelims-tribe, our scenes place their own decor); earlier 2026-11-08 (`SANCTUAIRE-LIEUX.md` sections 11 and 12 and the place table, grep of `VALIDE.md` and `EMBELLISSEMENT-LIEUX.md`; `SANCTUAIRE-CASES.md` not opened). Tribe read: 2026-11-12 (same log, no change); 2026-11-09 (no change to roster, animals or profiles in the NSB log); earlier 2026-11-08 (`CATALOGUE-ANIMAUX.md`, `NELIM-PROFIL.md` first 40 lines, `GALERIE-HISTOIRE.md` cast, grep of `NSB-ROSTER.md`, `VALIDE.md`, `AVANCEMENT.md`; the other profiles not opened). Steps read: 2026-11-12 (NPT log since 2026-11-09, stat only: decor burns, filth removal, floor building, culture and work-giver steps, hide tab bar and speed controls, `docs/` renamed `Docs/`; none serves a scene, none used); 2026-11-09 (new: step `the light of the map is dimmed to at most {float}` and `is refreshed` for dusk or night captures, fits scenes 7 and 8; step `the animals except A, B and C are kept out of the area from..to..` for hens out of frame, scenes 1 and 3; `the camera orthographic size is held at {float}`; none used yet, pending tickets kept); earlier 2026-11-08 (`PickleTools/docs/steps.md` StageDecor section and greps, git log since 2026-10-23; the rest of the 217 KB file and the catalogues not read).

| Place | Shots | Changes for the gallery | Last read |
| --- | --- | --- | --- |
| `statue-garden` | 1 | daylilies and a lit torch, removed after; NSB validated 2026-11-06 | 2026-11-08 |
| `enclosure-south` | 2 | two lit braziers; NSB now has the Nelim flower logo there, check the brazier cells (146,207) and (162,207) against it | 2026-11-08 |
| `gravel-yard` | 3, 5 | sandbags; NSB marks it "à embellir" (zen dry garden planned), cells may change | 2026-11-08 |
| `bare-clearing` (via `emerald-clearing`) | 4 | daylilies; free shooting zone, stays | 2026-11-08 |
| `water-garden` | 6 | two lit torches; NSB validated 2026-11-06 | 2026-11-08 |
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
| `SZ_SeXie` (human form) | none | MISSING: add to a shot in `write-shotlist` |
| friendly clones (`SZ_MingShe_Friendly`, `SZ_QiongQi_Friendly`, `SZ_YearBeast_Friendly`, `SZ_SeXie_Friendly`, `SZ_SeXieInsect_Friendly`) | none | MISSING: add one shot (or one grouped shot saying how they differ from the hostile ones) in `write-shotlist` |

### Shotlist - 2026-11-08 (plan, no capture rated)

Written in the header of `Tests/Pickle/Mod/Pickle/Features/24-gallery.feature` (8 shots, one story: New Year's day at the Sanctuary, 6 h to 20 h). Changes today: Ryu "Blue" Sai (NSB colonist, roster properties, nothing changed) replaces the invented Ren in shots 5 and 6 (owner question on Ren still open, Ryu is the default); shot 8 added (rule 5: five tame clones, `SZ_SeXie_Friendly` among them); outfits kept per story stage (emerald dragon robe 1 to 2, brown robe and SanShan hat 3 to 6, beige 7 to 8); shot 7 moved to 19 h (the extractor causes shot 8); shot 1 zoom 6 and shot 7 zoom 5 for variety; decor, instant and "how obtained" written for every shot. Opus director pass kept: outfit continuity, order of 7 and 8, zoom variety, hay on the ground, a target for the qiongqi, ring readable by pose. Not kept (no step or a validated place): the burning-ground effect of shot 4, zen rocks of shot 3, a melee weapon raised in shot 6, hen kibble thrown in the air. `SZ_SeXie` hostile human form is still in no shot (the scorpion form is in 2 and 6, the tame human form in 8): to add or to justify at the owner's call. Existing `Art/Gallery/1-` to `7-` (accepted 2026-10-13) belong to the old plan: the new candidates replace them by index.

| shot | a time | b decor | c living | d pawns | e action | f frame | g subject | j mod | plan |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| 1 dawn crow | 6 h Clear | daylily x2, TorchLamp lit, Kibble x2 | rooster, hen | dragon robe, ponytail, cheerful | throws kibble, hens run | zoom 6 (155,97) | feeds hens, rooster crows | rooster at 268 px | 5 |
| 2 four beasts | 10 h Clear | 2 braziers, Hay x2, bambooBundle | 4 beasts | dragon robe, ponytail, cheerful | opens gate, nian eats | zoom 9 (153,213) | beasts at the gate | 4 beasts | 5 |
| 3 qiongqi | 12 h Clear | 4 Sandbags, TorchLamp lit | qiongqi front, hen target | brown robe, SanShan hat, loose hair, WaitCombat | rifle, moment before strike | zoom 6 (170,143) | picked its target | qiongqi | 5 |
| 4 nian fire | 14 h Clear | daylily x4, Sandbags x2, bambooBundle | nian beast, muffalo | brown robe, SanShan hat, cheerful | firecracker out, flame | zoom 7 (194,150) | fire breath | flame and beast | 5 |
| 5 wind barrier | 16 h Clear | Sandbags x4, TorchLamp lit | mingshe, Ryu | brown robe, SanShan hat, wary | watches with MedicineHerbal | zoom 8 (173,143) | barrier throws shot back | barrier and projectile | 5 |
| 6 sexie aura | 18 h Clear | daylily x2, 2 TorchLamp lit | scorpion sexie, Ryu | brown robe, SanShan hat, afraid | backs away, Ryu lunges | zoom 8 (147,171) | aura drives Ryu berserk | scorpion and ring | 5 |
| 7 extractor | 19 h Clear | 3 capsules, daylily x2, 4 torches lit | hen | beige, Taoist hat, cheerful | slides capsule in | zoom 5 (230,213) | gene extractor at work | machine | 5 |
| 8 tame clones | 20 h Clear | 2 braziers, 2 torches, Hay x2, bambooBundle | 5 tame clones | beige, no hat, ponytail, cheerful | empties hay | zoom 9 (166,235) | tame clones come home | 5 clones | 4.5 (g: tame looks like hostile, malus assumed) |

Series k: ok (one story, rhythm 6 h to 20 h, wide opening shot 1 and 2, close shot 7, closing night shot 8). Mean plan 4.94. Risks: `enclosure-south` flower logo (no object on it) for shot 2; `gravel-yard` may become a zen garden; friendly kinds may spawn hostile (check faction in the first run); total gallery under 8 MB (subtitled jpg). No ticket filed yet.

Owner decision 2026-11-08 (Virginie, in chat: "prend Blue"): the guest of shots 5 and 6 is Ryu "Blue" Sai (NSB colonist, roster properties, nothing changed). The invented Ren is dropped, no validation owed. Shotlist unchanged.

Gallery tickets 2026-11-08 (map `wsl-deps.sanctuary.map` resynced with the Backlot: Hat Hair Control with a seed for the two hats, wardrobe mods, Let's Have a Cat, Tribal Tattoos; commits 6909a9a and the Tribal Tattoos one): `20261108-211537-571-31aa` scenes 1 to 4 (Inbox `2026-11-08a-gallery-1-4`), `20261108-211622-602-abd5` scenes 5 to 7 (Inbox `2026-11-08b-gallery-5-7`). Scene 8 held (plan 4.5, owner call pending). Tree frozen on Mod and Source until RUN_DONE. On RUN_DONE: read summary.json and junit.xml, open every capture, `score-gallery` (image, adequacy, understanding, decoration, REDO under 4), recompose REDO alone; one review for the owner at the very end (GALLERY.md rule of 2026-11-08).

Owner decision 2026-11-08 (Virginie, in chat: "je valide la scène 8"): scene 8 accepted at plan 4.5 (malus on g assumed). Tickets refiled after replacing `bambooBundle` (not in the pass map) by TorchLamp, Plant_Daylily and Hay in scenes 2, 4 and 8 (commit after 6909a9a): `20261108-212232-447-a4be` scenes 1 to 4 (Inbox `2026-11-08a-gallery-1-4`; the first submit of this set was refused by the def check, the cancelled `31aa` is void), `20261108-211622-602-abd5` scenes 5 to 7 (Inbox `2026-11-08b-gallery-5-7`), `20261108-212214-550-4dcf` scene 8 (Inbox `2026-11-08c-gallery-8`). Def check once warned on `Sandbags` and the face animations `moodCheerful` and `WaitCombat`: if a scene fails on them, read junit.xml and fix the name or ask NPT.


PiT answer 2026-11-09: veil not drawn by any PiT step (likely game weather/sky layer, or a mod layer; no step hides it). Scene 6 v6: added `the eclipse of the map is ended` and diagnostics `the render nodes of "Ryu" are logged`, `the body texture of "Ryu" is logged`. Check-ShotlistVsScenario OK, commit pushed, ticket 82e7 filed (Inbox 2026-11-09i-gallery-6, NoBatch, sanctuary map). Next on RUN_DONE: read [render-nodes] lines from Player.log, send to PiT, open capture. Fallbacks kept in Inbox: 2026-11-09h-gallery-6, 2026-11-09f-gallery-2. Candidates: 1, 3, 4, 7, 8.

RUN_DONE 2026-11-10: 82e7 (scene 6 v6, eclipse ended, render-node logs) exit 0, 1/1 (summary.json read), Inbox 2026-11-09i-gallery-6. Capture opened: veil unchanged after the eclipse step (brown-green clouds over the whole frame, both ring draws skipped, so not the ring); scorpion readable, Nelim and two torches visible; Ryu a floating head with a red cape. Player.log: Body node tex empty, apparel nodes tex empty, Head nodes only Facial Animation controllers, no hair; [body-texture] says Naked_Thin drawn. Image 3.5, adequacy 2.5: REDO. Asked PiT (local_03a66e9e) what draws the veil and why Ryu has no body. Capture kept in Inbox as fallback. Resume 2026-11-10: protocols_read_sha 41d6a3a9 (AUDIT: Preview illustration made once at mountPreview from accepted gallery, no PROMPT or Preview-source before; PUBLISHING: social preview never before gallery validated; STYLE_RIMWORLD and GALLERY-PROPS: no effect at shootGallery), TM registered, no archived session of this mod, marker deleted. Journal 2026-11-09 moved to docs/runs. NPT steps changed 2026-11-10: sync-nsb-npt owed before next shotlist change. Pending: PiT answer (scene 6). Candidates: 1, 3, 4, 7, 8. Scene 2 v4 accept or recompose; scene 5 to recompose. Art/Preview.config.json: no change this session (last: panelAnchor bottom-left, 05275dc, told 2026-11-09).

PiT answer 2026-11-10 (commit 5697c5d): new steps "the sky, weather and map layers are logged" (names the veil) and "the sky overlays are hidden" (not used yet); Ryu body: suspects (a) Thin body missing for a male pawn in WDI, (b) graphics not rebuilt, (c) missing texture (Player.log of 82e7: no "Could not load texture" nor "Failed to find" line, (c) ruled out). Scene 6 v7 diagnostic: Ryu body type Male instead of Thin, sky log before the capture, Check-ShotlistVsScenario OK, filed ede4 (Inbox 2026-11-10a-gallery-6, NoBatch, sanctuary map). Next on RUN_DONE: read [sky] lines in Player.log, open capture, tell PiT the result of (a). Pending: ede4 (6). Candidates: 1, 3, 4, 7, 8.

RUN_DONE ede4 read 2026-11-12 (resume, delivered via relay note, no wake): exit 0, 1/1. Capture opened: Ryu still a floating head with red cape, no body, with body type Male too, so suspect (a) is out; veil unchanged. [sky] log: weather Clear, sky glow 0.45, condition `PsychicSoothe` (GameCondition_PsychicEmanation, map, 39188 ticks left), overlays none found. Image 3 (veil, no body), adequacy 2: REDO. Sent to PiT through the TM: PsychicSoothe tint suspect, ask for a step ending the condition or rebuilding pawn graphics. Protocols read 2026-11-12 (fd4f8885): nothing for shootGallery (Art/ closed set gained `Work/`). Pending: PiT answer (scene 6). Candidates: 1, 3, 4, 7, 8. Scene 2 v4 accept or recompose; scene 5 to recompose. Scene 2 v4 accept or recompose; scene 5 to recompose (Ryu absent there too: same body suspect).

NPT answer 2026-11-12: steps "the game condition PsychicSoothe is ended" and "the graphics of Ryu are refreshed" added (compiled, not played). Scene 6 v8 filed: ticket 20261112-204940-143-97df (Inbox 2026-11-12a-gallery-6, NoBatch, sanctuary map, commit a3aa151). On RUN_DONE: open capture (veil gone? Ryu body?), if the body is still missing send Player.log lines about Ryu's body graphic to NPT. Pending: 97df (6), ChatGPT review page 1/1 answered and treated. Candidates: 1, 3, 4, 7, 8.

Translation review 2026-11-12 treated (commits 4223a30, 9c95eae, 928aa9d): French paw labels, 22 Chinese keys filled, Chinese source corrections applied (Audit item 21). Upstream pull request with the Chinese corrections: owner 2026-11-12 "on l'ouvrira après la validation" (after her French validation); the old PR MonsterTower/AncientChineseBeast#1 is closed (2026-11-11). Open it then, from `vbardales/AncientChineseBeast`.

RUN_DONE 2026-11-12: 97df (scene 6 v8, PsychicSoothe ended, Ryu graphics refreshed) exit 0, 1/1 (summary.json read). Capture opened: veil unchanged, Ryu still a floating head with a red cape, scorpion, Nelim and two torches readable. Image 3, adequacy 2: REDO. The condition line is gone from the [sky] log, so PsychicSoothe is not the veil; section layers hold `SectionLayer_PollutionCloud` and `SectionLayer_Gas` (suspects). Ryu nodes: Body, shirt and pants show no texture, only the duster and head draw. Sent to NPT (reply awaited: step to read why a body node does not draw, step to hide pollution or gas). Scene 6 v9 filed: `20261112-221308-776-f812` (Inbox 2026-11-12b-gallery-6, NoBatch, sanctuary map, commit bd46c46) with "the sky overlays are hidden". Inbox: scene 6 captures 09h, 09i, 10a, 12a deleted (refused, read); 09f (scene 2 v4) kept. Pending: f812 (6), NPT answer. Candidates: 1, 3, 4, 7, 8. Scene 2 v4 accept or recompose; scene 5 to recompose.

NPT answer 2026-11-12: steps "the draw state of the render nodes of Ryu is logged" (read canDrawNow and graphics count, after the refresh), "the section layers of the map are logged" and "the section layers named PollutionCloud are hidden" (also Gas). f812 (v9) cancelled before it ran ("the sky overlays are hidden" does not touch section layers). Scene 6 v10 filed: `20261112-221712-540-b326` (Inbox 2026-11-12b-gallery-6, NoBatch, sanctuary map, commit 822189a): PollutionCloud hidden and node draw state logged. On RUN_DONE: veil gone? if not, try Gas next; read [render-state] for Body, shirt, pants. Pending: b326 (6). Candidates: 1, 3, 4, 7, 8.

RUN_DONE 2026-11-12: b326 (scene 6 v10) exit 1, RED 0/1 (summary.json read): the NPT step "the section layers named PollutionCloud are hidden" failed ("0 DrawLayer method(s) patched ... the game changed"), a step fault, not the map. The step "the draw state of the render nodes of Ryu is logged" ran: Body canDrawNow=True graphics=1 (Naked_Male), shirt, pants, duster nodes canDrawNow=False graphics=1, head True; no body seen in the capture. Sent to NPT with the log lines, asked for a fix of the layer step (inherited DrawLayer) and a step logging node offset, scale and mesh. Scene 6 not refiled until NPT answers. Inbox: 2026-11-12b-gallery-6 kept until NPT has read it. Pending: NPT answer. Candidates: 1, 3, 4, 7, 8.

NPT answer 2026-11-12: the apparel canDrawNow=False of b326 was a step artifact (draw parms built without the Clothes flag), so that verdict is void; the Body node said True with Naked_Male, so the floating head is probably position or scale. NPT fixed the draw-state step (Clothes and Headgear flags, logs transform, scale, mesh bounds per node) and the layer step (every declared DrawLayer, the Visible getter, same for Gas). Scene 6 v11 filed: `20261112-222624-238-e16c` (Inbox 2026-11-12c-gallery-6, NoBatch, sanctuary map, commit 19bed3e): refresh, draw state, PollutionCloud and Gas hidden. Inbox 2026-11-12b-gallery-6 (b326) deleted. On RUN_DONE: veil gone? read [render-state] transform lines of Body against Head. Pending: e16c (6). Candidates: 1, 3, 4, 7, 8.

RUN_DONE 2026-11-12: e16c (scene 6 v11, PollutionCloud and Gas hidden, node draw state with Clothes and Headgear) exit 0, 1/1 (summary.json read). Capture opened: veil and Ryu unchanged (head and red shape, no body), so not PollutionCloud, not Gas (1 and 2 methods patched), not PsychicSoothe. Node state: all of Ryu's nodes canDrawNow=True with graphics, offsets 0, scale 1, mesh plane 1.5x1.5: transforms are fine. Image 3, adequacy 2: REDO. Sent to NPT: list what draws over the map (veil only at water-garden 18h), log the material and texture of each Ryu node. Scene 6 not refiled until NPT answers. Inbox 2026-11-12c deleted. Pending: NPT answer. Candidates: 1, 3, 4, 7, 8. Scene 2 v4 accept or recompose; scene 5 to recompose.

NPT answer 2026-11-12: material log added to the draw-state step (shader, texture, size, visible pixels, colour per node: read Body), bisect with `the section layers named "SectionLayer" are hidden` possible, strongest suspect for the veil is the dusk sky and sun glow ("the sun glow of the map is held at 1.0", "the light of the map is logged"). Scene 6 v12 filed (commit and ticket in the next line): sun glow held at 1.0, light and section-layer logs, node materials. If the veil goes, it is the dusk glow; the final look then needs another way (lit decor, dimmed light step) and not the held glow. If both tests fail, ask NPT for the overlay-drawer lister. Pending: v12 (6).

RUN_DONE 2026-11-12: cb9f (scene 6 v12, sun glow held at 1.0, node materials) exit 0, 1/1 (summary.json read). Capture opened: the held glow changed the light (day shadows, bluer scorpion) but the veil stayed, so it is not the dusk. Node materials normal (Body Naked_Male 512x512, skin shader), transforms normal. Hypothesis: the veil is the WATER terrain (whole frame except the dirt patch; lily pads sit on it; Watergen visible=True, 984 vertices in the section under the camera), drawn above the low nodes of Ryu (body, shirt, pants) and below his head and duster, which is why only head and cape show. Image 3, adequacy 2: REDO. Scene 6 v13 filed: `20261112-224950-013-7a76` (commit d759bc9, Inbox 2026-11-12e-gallery-6, NoBatch, sanctuary map): section layer "Watergen" hidden, glow hold removed. If the veil and the body problem both go, the cause is the water layer over pawns, and the capture needs the Watergen hide or another place without water. Inbox 2026-11-12d deleted. Pending: v13 (6). Candidates: 1, 3, 4, 7, 8.

RUN_DONE 2026-11-12: 7a76 (scene 6 v13, Watergen layer hidden) exit 0, 1/1 (summary.json read). Capture opened: veil and Ryu unchanged (Watergen patched 1 method, visible=True 984 vertices). So not the water layer as patched, not the dusk, not PollutionCloud, Gas or PsychicSoothe. Ryu's body is missing in scene 5 too (other place); nodes, materials and transforms are normal; Nelim in the same frame draws in full. Suspect: Ryu is spawned by this mod's own step and edited by NPT steps. Image 3, adequacy 2: REDO. Sent to NPT: is the roster Ryu in the save (use the real pawn), a step logging the pawn's actual draw and screen rect, and the overlay-drawer lister for the veil. Five runs tonight (a to e); scene 6 not refiled until NPT answers. Inbox 2026-11-12e deleted. Pending: NPT answer. Candidates: 1, 3, 4, 7, 8. Scene 2 v4 accept or recompose; scene 5 to recompose.

NPT answer 2026-11-12: Ryu "Blue" is a roster colonist of the sanctuary (NSB AVANCEMENT.md line 26): use the real pawn with the existing steps (`"Blue" stands at ... facing South`), no spawn; added `the draw position of "Ryu" is logged` and `what draws over the map is logged` (commit 942458e). Scene 6 v14 filed: `20261112-230158-779-0bfa` (commit 794c8d0, Inbox 2026-11-12f-gallery-6, NoBatch, sanctuary map): the real Blue, taken as pawn 1 by a new LOCAL step in `Tests/Pickle/Source/SpawnSteps.cs` ("I take the colonist named Blue as a pawn of the scenario"; to declare to NPT), no property of his set (roster canon), apparel kept, draw logs. On RUN_DONE: is Blue drawn in full? veil: read [draw-over-map] (glowers, Harmony patch owners). Pending: 0bfa (6). Candidates: 1, 3, 4, 7, 8.

RUN_DONE 2026-11-12: 0bfa (scene 6 v14) exit 1, RED: UNDEFINED STEP "I take the colonist named {string} as a pawn of the scenario": the step DLL `Tests/Pickle/Mod/Pickle/Assemblies/AncientChineseBeast.PickleSteps.dll` is committed and was not rebuilt (my fault). Rebuilt (dotnet build, 0 errors), `Check-Steps.ps1` green (one dead pattern: "I spawn a colonist named", unused now, remove when scene 5 is rewritten), committed 9f73047. Scene 6 v14 refiled: `20261112-230620-336-b279` (Inbox 2026-11-12g-gallery-6, NoBatch, sanctuary map). Inbox 2026-11-12f deleted. Pending: b279 (6). Candidates: 1, 3, 4, 7, 8.

RUN_DONE 2026-11-12: b279 (scene 6 v14) exit 1, RED on the data: "no free colonist called Blue; the colonists are: Nelim": the sanctuary save holds only Nelim, the real roster Blue is not in it (NPT had assumed he was). The take-colonist step and the rebuilt step DLL are reverted (commit below). Scene 6 v15 filed: spawned Ryu as in v13 with NPT's logs `the draw position of "Ryu" is logged` ([pawn-draw]) and `what draws over the map is logged` ([draw-over-map]); ticket and commit in the next line. Inbox 2026-11-12g deleted. To raise with Virginie/NPT later: the fixture save has no roster colonist but Nelim, so every other roster colonist of a gallery shot is built by steps. Pending: v15 (6). Candidates: 1, 3, 4, 7, 8.

RUN_DONE 2026-11-12: b379 (scene 6 v15, spawned Ryu, NPT draw logs) exit 0, 1/1 (summary.json read). Capture opened: unchanged (head and red shape, no body, same veil). [pawn-draw]: Human, Colonist, adult, size 1.0, body type Male, spawned, on screen at the centre (870, 540) where the head shows, normal. [draw-over-map]: no overlay, no condition, sun glow 0.45, only warm TorchLamp glowers. Harmony patches touching the body draw: VEF (Body.CanDrawNow postfix, AppendDrawRequests prefix), HatHairControl, fairycoreapparel2 (Apparel_Body.CanDrawNow). Image 3, adequacy 2: REDO. Sent to NPT: log the real draw requests of the pawn, read the Naked_Male texture pixels through a GPU copy. Scene 6 v16 filed: `20261112-231736-350-6367` (commit 9156170, Inbox 2026-11-12i-gallery-6): section layer "TerrainScatter" hidden. A stale ticket ca11 (filed by mistake with the old scene) was cancelled. Inbox 2026-11-12h deleted. GitHub unreachable from this machine: 6 local commits not pushed. Pending: 6367 (6). Candidates: 1, 3, 4, 7, 8.

RUN_DONE 2026-11-12: 6367 (scene 6 v16, TerrainScatter hidden) exit 0, 1/1 (summary.json read). Capture opened: veil and Ryu unchanged; the texture opacity lines are absent (the run used the DLL without NPT's 43aa5fb). Not the water layer, not TerrainScatter, not the dusk, not PollutionCloud or Gas. Image 3, adequacy 2: REDO. Scene 6 v17 filed: `20261112-232242-867-cfc2` (commit 8e39586, Inbox 2026-11-12j-gallery-6): NPT step "the draw requests of Ryu are logged" after the screenshot, texture opacity in the draw-state step. TM: do not refile unless the plan changes: this is that change (new NPT steps). French title decided by Virginie, final form (TM 29b, 29e): "Extension Bêtes chinoises antiques et gènes étendus, renouvelée, non-officielle"; written in Docs/review-names.md. Inbox 2026-11-12i deleted. GitHub unreachable, local commits unpushed. Pending: cfc2 (6). Candidates: 1, 3, 4, 7, 8.

RUN_DONE 2026-11-12: cfc2 (scene 6 v17, draw requests, texture opacity) exit 0, 1/1 (summary.json read). Capture unchanged. KEY FINDING: Ryu's textures are opaque (Naked_Male_south 14.5 % opaque, shirt, pants, duster, head all fine) and the game REQUESTS the draw of the body, tattoo, shirt, pants at y 8.42, the duster at 8.43, the head nodes at 8.44 to 8.45. On screen only head and duster (red cape) show: something drawn over the map at an altitude between 8.42 and 8.43 covers everything below it. That is the "veil" and it explains the missing body. Not PollutionCloud, Gas, Watergen, TerrainScatter (each hidden in turn), not sun glow, glowers, weather, conditions. Candidates not tried: SectionLayer_Snow, Sand, Darkness, EdgeShadows, IndoorMask, FogOfWar, LightingOverlay, SunShadows, PipeSystem Resource, or a mote or fleck. Sent to NPT: a step listing what draws at y 8.40 to 8.50, or hide-by-altitude; or I file one run hiding the 8 layers at once. TM: no refile until NPT answers. Image 3, adequacy 2: REDO. Inbox 2026-11-12j deleted. Pending: NPT answer. Candidates: 1, 3, 4, 7, 8.

NPT answer 2026-11-12: new step "the things drawn at an altitude from 8.40 to 8.50 are logged" (the y of every AltitudeLayer plus the things in the band) and advice to bisect the nine remaining section layers at once. Scene 6 v18 filed: `20261112-232858-181-d6fb` (commit 7ed8a27, Inbox 2026-11-12k-gallery-6): the altitude log and Snow, Sand, Darkness, EdgeShadows, IndoorMask, FogOfWar, LightingOverlay, SunShadows, Resource hidden at once. If the veil goes, halve the list next run; if it stays, it is a thing or a fleck (read the altitude log). Pending: d6fb (6). Candidates: 1, 3, 4, 7, 8.

RUN_DONE 2026-11-12: d6fb (scene 6 v18) exit 1, RED: NPT step "the things drawn at an altitude from 8.40 to 8.50 are logged" threw "Index was outside the bounds of the array" before printing, so the nine layer hides and the capture never ran: a step fault, not the scene. Sent to NPT; not refiled until it answers (TM). Pending: NPT fix, then refile v18 as is. Inbox 2026-11-12k kept until then (junit.xml, Player.log). Candidates: 1, 3, 4, 7, 8.
