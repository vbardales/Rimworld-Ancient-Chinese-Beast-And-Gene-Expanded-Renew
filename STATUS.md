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
updated:      2026-11-13
upstream_synced: 2026-11-12 MonsterTower/AncientChineseBeast@f6d3d19
protocols_read_sha: ffe51fdb66913d517ac064cbece7ec6ca05a6eb0
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

### Ecosystem - 2026-11-13

AUDIT 1.a, Steam search done by PiI (2026-11-13), full study in `docs/inventory/ecosystem-steam/AncientChineseBeastAndGeneExpandedRenew.md`. PiI one-line reply: original 3292446841 and its NoGene sibling 3047055011 (same author andery233xj, 21 shared defNames, held `needs_npt`) are the only mods sharing our defNames; no third fork; 19 weak hits, none shared.

Summary: Steam searches `Ancient Chinese Beast`, `Chinese mythology beasts`, `Chinese creature genes`. Found: original 3292446841 (2024-08, protected); NoGene sibling 3047055011 (fork-or-rewrite, same author's variant without the genes, not a competitor); link 3293695725 "Remove Ancient Chinese Beast Gene textures" (patch of the original, 1.6); name only 3313313985 "Ancient amorphous threat". PiI subscribed to the two small ones for study and unsubscribed them. Nothing else Chinese-themed holds our `SZ_*` defNames. Local scan from this session agrees (corpus 5302/5306 folders, 2 hits, our own `About.xml`). Gap: this session read 3047055011 as dead for 1.6 (`supportedVersions` 1.4 only, `About.xml` 2026-09-05), PiI's table says alive 1.6; to settle in the registry. Licence not read. Nothing to add to `Check-OptionalCompat.ps1`, no combined pass owed at 8.f.

## History

Older dated sections moved to `docs/runs/2026-10-13-status-history.md` (until 2026-10-13), `docs/runs/2026-11-05-status-history.md` (2026-10-15 to 2026-11-03) and `docs/runs/2026-11-09-status-history.md` (2026-11-05 to 2026-11-08) and `docs/runs/2026-11-10-status-history.md` (2026-11-09 gallery tickets, scenes 1 to 8 up to scene 6 v5).

### NSB - 2026-11-08

First sync (no earlier one). NSB changed a lot since the 2026-10-23 feature (170 commits of `docs/` since 2026-10-13): a decorated Sanctuary is being built (the fixture `Nelims-tribe` is still the old undecorated one), `gravel-yard` is to become a zen dry garden, `enclosure-south` already carries a Nelim logo in flowers (zones 3 to 15, "sans objet dessus", VALIDE 2026-11-08), NSB roster holds no "Ren" (the guest is now Ryu "Blue" Sai, "formerly Ren in older documents"). Shotlist files not rewritten here: `write-shotlist` is next and takes these into account. Rules said back (owner 2026-11-05 and 2026-11-07): everything in NSB is free; a colonist or domestic animal outside NSB needs the owner's express validation (an animal the mod adds is authorised by default); a colonist's properties change only with her words; every outfit is free; every animal the mod includes must be in the gallery.

Places read: 2026-11-12 (NSB log since 2026-11-09 read: one commit, `docs/` renamed `Docs/`, no content change, no place or roster change); 2026-11-09 (NSB log since 2026-11-08 read: no change to a place used here; z3 decor fixture added beside Nelims-tribe, our scenes place their own decor); earlier 2026-11-08 (`SANCTUAIRE-LIEUX.md` sections 11 and 12 and the place table, grep of `VALIDE.md` and `EMBELLISSEMENT-LIEUX.md`; `SANCTUAIRE-CASES.md` not opened). Tribe read: 2026-11-12 (same log, no change); 2026-11-09 (no change to roster, animals or profiles in the NSB log); earlier 2026-11-08 (`CATALOGUE-ANIMAUX.md`, `NELIM-PROFIL.md` first 40 lines, `GALERIE-HISTOIRE.md` cast, grep of `NSB-ROSTER.md`, `VALIDE.md`, `AVANCEMENT.md`; the other profiles not opened). Steps read: 2026-11-12 (NPT log since 2026-11-09, stat only: decor burns, filth removal, floor building, culture and work-giver steps, hide tab bar and speed controls, `docs/` renamed `Docs/`; none serves a scene, none used); 2026-11-09 (new: step `the light of the map is dimmed to at most {float}` and `is refreshed` for dusk or night captures, fits scenes 7 and 8; step `the animals except A, B and C are kept out of the area from..to..` for hens out of frame, scenes 1 and 3; `the camera orthographic size is held at {float}`; none used yet, pending tickets kept); earlier 2026-11-08 (`PickleTools/docs/steps.md` StageDecor section and greps, git log since 2026-10-23; the rest of the 217 KB file and the catalogues not read).

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
| `SZ_SeXie` (human form) | none | MISSING: add to a shot in `write-shotlist` |
| friendly clones (`SZ_MingShe_Friendly`, `SZ_QiongQi_Friendly`, `SZ_YearBeast_Friendly`, `SZ_SeXie_Friendly`, `SZ_SeXieInsect_Friendly`) | none | MISSING: add one shot (or one grouped shot saying how they differ from the hostile ones) in `write-shotlist` |

### Where the gallery work went

The shotlist table, the scene by scene journal and the run notes from 2026-11-08 to 2026-11-13 moved to `Docs/runs/2026-11-13-status-history.md`. Current plan in the STATE block below.

STATE 2026-11-13 (before sleep): names and mod titles CLOSED (Docs/review-names.md; registry at Audit). /review-translation ran 24 passes, saturated (style only), nothing pending; Docs/review-refusals.md holds the refusals. Gallery: candidates 1, 2, 3, 4, 6, 7, 8 in Art/Gallery-clean (scene 6 moved to the gravel-yard, ring drawn, no duster); scene 5 v4 (Ryu without the duster) filed as ticket 20261113-001509-818-0a63, WAITING (Inbox 2026-11-13a-gallery-5): on RUN_DONE read summary.json, open the capture, score-gallery, then one final review message for Virginie with ALL candidates, then the orange line. Still owed: replay-audit (REPLAY line to the TM), upstream PR with the text corrections (MonsterTower/AncientChineseBeast, after Virginie validates the French, BACKLOG TODO), old Art/Gallery 1-7 pngs to replace by the accepted candidates. 5-hour plan limit nearly reached at the time of the sleep.

Translation audit 2026-11-13: Virginie validated the French review ("je valide la relecture"). `translation_fr` stays `complete`. The French of this revision is hers, validated; after 24 /review-translation passes and the names closed (Docs/review-names.md). The upstream pull request with the text corrections (BACKLOG TODO) may now be proposed to her for its go.

STATE 2026-11-13 (second sleep): Longbow decided (kept); every name and title decided; French review validated by Virginie. Only open: ticket 20261113-001509-818-0a63 (scene 5 v4, WAITING position 1/2): on RUN_DONE open the capture, score-gallery, then ONE final review message for Virginie with ALL candidates (1, 2, 3, 4, 6, 7, 8 in Art/Gallery-clean, plus 5 if candidate), then replay-audit (REPLAY line to the TM). Upstream PR with texts impossible (upstream holds C# only, BACKLOG).
