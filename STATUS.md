---
localization: complete
translation_en: complete
translation_fr: complete
settings_audit: not_applicable
code_review_sha: f809e47f4cd07d3a34b67b1d9c119e762a478f31  # 2026-10-13, 8.m exceptions: reviewed diff 54eb9fb..HEAD over Mod and Source (git diff --stat): only Mod/About/About.xml (description text, nothing else) and Mod/ATTRIBUTION.md (one sentence about the removed Art/textures-original), no code: revue du diff : images et texte seuls. Previous: 54eb9fb, 2026-10-13, 8.m (moved past the French and gene-name text edits of this commit, Defs QiongQi.xml and MingShe.xml read, no code; and past two description-only edits of About.xml, no code): 5ea69ab..HEAD over Source and Mod holds no code change (only Source/Directory.Build.props intermediates path build/, ATTRIBUTION.md, Preview.png, desktop.ini removed): 0 findings. Earlier review, was `code_review`: <sha> (2026-10-08, /code-review at low effort over 89a2575..5ea69ab, the 0.1.0 commit that tracked the PublishedFileId, limited to Source, Mod/Defs, Mod/Patches and Tests/Pickle/Source: 0 findings; low effort reads the diff once, no verify pass. First review of this mod, nothing earlier existed)
audit_revision: 67a4b37 (HEAD, pushed, tree clean when the 2026-10-01 audit began). While it ran, another session regenerated `Art/` and `Mod/About/Preview.png` in the working tree: uncommitted, not touched and not audited here
mod:          Ancient Chinese Beast And Gene Expanded Renew (unofficial)
packageId:    nelim.ancientchinesebeastandgeneexpanded
repo:         Rimworld-Ancient-Chinese-Beast-And-Gene-Expanded-Renew
visibility:   public
detached:     yes
workflow_stage: playTests[1.1.0]
social_preview_sha256: 9bb0241125d628bb2f097bee504eaaa1b966eb1cb3ae20e3d2fb2cf1b8d34faa
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
tested_on: 2026-10-10 (1.6, tree c4edf71 for Source and Mod; last red scenarios green)
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
session:      local_f1e4cc35-8614-406f-80ff-0a2487014a59
updated:      2026-10-23
protocols_read_sha: 1293bff327dd5e5e24df923406d20f23fb45acee
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

Older dated sections (workflow audits 2026-09-13 to 2026-10-11, translation audits, preview verification and migration, in-game verification notes) moved to `docs/runs/2026-10-13-status-history.md` on 2026-10-13.


AI-GENERATED claim (owner, 2026-10-15): preview background and icon generated with DALL-E (OpenAI). Description of 1.1.0 now names it (PUBLICATION.md, About.xml regenerated); 1.0.0 page still says "AI-generated artwork" until 1.1.0 published.

Workshop page "Required items" (owner, 2026-10-15): Harmony listed (Biotech is DLC, not item). Page only, nothing to publish.

Non-regression refiled 2026-10-15 on 1.1.0 tree (HEAD with wind-barrier hardening, DLL rebuilt): five tickets b to f of 2026-10-13 left no evidence folder, in no queue (lost after dispatcher stall), only 5390 (red, 2 barrier) and e0b4 (green replay) ran. New set: English full 20261015-211635-942-2bf2 (2026-10-15a-en), French full ...-ccb7 (b-fr), ADS2 ...-aa6e (c), Nocturnal ...-ecd6 (d), CCE ...-7c4a (e), original mod ...-4ddf (f). Test hardened build, not ff3ecbd; 1.0.0 published build covered by 5390 result only. Results not in.

1.7 reading (2026-10-15, metadata of ~/rimworld17/Assembly-CSharp.dll read with System.Reflection.Metadata, no game run; ilspycmd 8.2 cannot open that assembly): two private reflections of DLL still resolve by name. `Verse.Projectile.origin` exists (protected field, caught by Instance|NonPublic) and `RimWorld.Verb_MeleeAttackDamage.DamageInfosToApply` exists (private, single method of that name). Says lookups will not return null; does not say calls behave same. `tested_1_7` stays absent until 1.7 run.

Audit replay 2026-10-15 (protocols re-read from 65e09838: AGENTS, AUDIT, CICD, GALLERY, README, scripts.md, LOCAL_SCRIPTS, USE_THIS_INSTEAD). Changes touching this mod: (1) session name carries no marker any more (Workflow Board computes colour), name is `ancientchinesebeasta... / code[1.1.0]`; (2) gallery subtitles rule of 2026-10-15 (GALLERY.md, "Sous-titres"): scenes without UI window carry one English line, originals in `Art/Gallery-clean/`, table "Gallery subtitles" in PUBLICATION.md, tool `scripts/Add-Subtitle.ps1`; gallery of this mod (images 1 to 7, uploaded 2026-10-13) predates it; (3) post-publish tag check and 14.c cleanup message with Workshop links: noted for 1.1.0 and cleanup. Run-All translations step: 6 findings down to 1 after shared Check-Translations fix (1ae53af); last one, vanilla key TextMote_Dodge called in Source, needs exemption in shared script, requested from Audit session.

Gallery review 2026-10-15 (owner asked: which story played, matches scenario, pawns worked). Findings from seven images opened against `24-gallery.feature`: (a) story promises two keepers, Lan and Ren, hand-made; 2026-10-14 rule makes Nelim protagonist, others optional guests, so series has no protagonist; (b) pawns 20 to 60 px at zoom 6 to 12: hairstyles, outfits, eye genes written in scenarios, invisible in images; (c) facial expression "normal" or unset everywhere, not storytelling (berserk Ren in 6 has none, face-part steps of GALERIE.md unused); (d) image 4 promises "Ren holds a firecracker", Ren not in frame; image 5 promises "Lan's shot", shooter out of frame, only streak; image 3 promises qiongqi caught in air, shows it walking; (e) beasts side or rear views, no front view (rule 2026-10-14); (f) no external mod brought in for theme. Verdict: images 2 and 6 hold; 1, 3, 4, 5, 7 do not carry story. Subtitles written in PUBLICATION.md ("Gallery subtitles") against what images show; not set on images, gallery to be restaged first (owner decision pending).

Gallery restaged 2026-10-15 (owner: "oui, refais"): `24-gallery.feature` rewritten (Nelim protagonist in all seven images with Taoist hat of Chinese Comprehensive Expansion, her own face, cheerful expression, Ren only guest in 5 and 6, zoom 5 to 9, time paused before any pawn placed, beasts facing South), `wsl-deps.sanctuary.map` gains Chinese Comprehensive Expansion (then this mod by path:), GALLERY.md story and shot list updated. Check-Steps: all patterns compile, every line resolves. Requested: `20261015-223103-311-02e4` (`2026-10-15g-gallery-restaged-1`, English, wsl-deps.sanctuary.map, filter 24-gallery), superseded 2026-10-16 by `20261016-114421-971-e18e` (`2026-10-16a-gallery-restaged-2`, same filter and map; TM asked to cancel 02e4). 2026-10-16 additions (owner: any mod may serve theme): RimImmortal Core, Living and Hairstyle in map (Nelim: jade middle robe, bun, Taoist hat; Ren: man's bun), facial expressions (Nelim watchful in 3, wary in 6; Ren hard-eyed in 5, slanted brows in 6). Images of 2026-10-13 stay in `Art/Gallery/` until new ones opened and judged; subtitles table of PUBLICATION.md rewritten against new story, not set on images. Not played yet.

- 2026-10-15: Check-Translations.ps1 gate green with `-AllowUnused SZ_CannotReachBuildingToExtractGene -VanillaKeyed TextMote_Dodge` (Run-All.ps1; reasons in Tests/TRANSLATIONS.md). Audit added -VanillaKeyed.
Run-All 2026-10-17 (code[1.1.0], -Harmony set to the NuGet lib.harmony 2.3.3 net472 DLL: the workshop 2009463077 copy is not installed): all steps green, content checks, assembly contracts, translations (203 source texts, 5 Keyed calls, TextMote_Dodge exemption now passed), config. Barrier hardening of 1.1.0 not played yet.

Ticket 2026-10-17: `20261017-165629-008-18a3` (`2026-10-17a-barrier-18-23-en`, English, features 18 to 23 in order, tree b3bf415): tests the 1.1.0 barrier hardening in the order suspected of the 2026-10-13 red. Keep Mod and Source frozen until RUN_DONE. French replay and `tested_1_7` follow.

Stage replay 2026-10-17, code[1.1.0] to playTests[1.1.0] (AUDIT 3 to 7; owner asked to advance). Diff ff3ecbd..HEAD over Mod and Source: Ability_WindBarrier.cs (hardening), About.xml (description text only: no dependency, no version, no LoadFolders change), ATTRIBUTION.md, the rebuilt DLL. 3: no feature left in remaining, DLL rebuilt after the last Source edit (2026-10-14 16:12), CHANGELOG [Unreleased] lists the three changes. 4: dependencies unchanged since 1.0.0 (declared 1.0.0, no new reference in the barrier fix). 5: settings_audit not_applicable stands, no settings added. 6: no new text, translations step green 2026-10-17 (203 source texts, French injections), French review of 1.0.0 stands. 7: Run-All green 2026-10-17 (content, contracts, XML, translations, config), Pickle suites unchanged, one ticket filed (18a3). Not a full pass: only features 18 to 23, English, for the barrier.

French no tu/vous pass 2026-10-17 (AUDIT 6.d): 5 clone recipes (no "Vous obtiendrez", no "laisse-le"), BeastGene research note ("Il faut conserver"), Sexie storyteller ("la vôtre" gone), nian letter label ("cliquer"). Kept: "Quel beau coq tu fais." in the crow description (a character's quoted words to the rooster, not the player). FRENCH_REVIEW.md regenerated, Run-All green. Virginie's review of these 8 changed lines pending; no code change. Ticket 18a3 is English, unaffected.

French no nous either (Virginie, 2026-10-17): the four letters of IncidentDef rewritten without nous, notre, nos, soyons (qiongqi, mingshe, sexie tunnel, crow). Her review of these lines, and of the eight above, pending.

French: "éventrent" to "perforent" in the qiongqi claw gene description, confirmed by Virginie 2026-10-17 (ChatGPT review).

ChatGPT review 2026-10-17 (third), Virginie: 'corrige ce qu'il faut'. Applied: crow label and letter label 'de passage', storyteller 'fâcheux'; PUBLICATION.md (published state, change note now 1.1.0), CHANGELOG.md (preview position wording). Not applied: generator header remark (shared script, Audit). Her review of the French lines changed today is pending.

Fourth ChatGPT review 2026-10-17: 'à soi' removed from the mingshe, qiongqi and nian clone recipes (Virginie: apply recommended). Storyteller 'fâcheux' kept. Truncated-report remark is the review plugin's, not the mod's.

Fifth ChatGPT review 2026-10-17: PUBLICATION.md "meant to become public" now "is public" (applied); "of/at the shared Sanctuary location" not applied.

French validated by Virginie in chat 2026-10-17 ("validé"), revision 45aa221: all French lines changed today (no tu/vous/nous pass, crow, storyteller, letters, clone recipes, qiongqi claw gene). FRENCH_REVIEW.md review-line table stays blank (her word recorded here).

Evidence triage 2026-10-18 (new Inbox/Evidence/Parked model): kept in `Tests/Pickle/Evidence/` the latest green proof of each check (ADS2, Nocturnal, CCE of 2026-10-15; the extractor scenario of 2026-10-10i as sole proof; the siege proofs 2026-10-10i/j were dropped 2026-10-19, see below). Reds (evidence deleted, to replay): gallery 6 (cell (137, 169) not standable), siege (nian chases a colony animal; step now removes them), mating and tired-beast rest (new on the 1.1.0 tree, not yet studied: "a tame pair mates and the female gives birth" not pregnant after 5 matings, English and French; "a tired tame beast lies down", French, chicken not asleep). Everything else of `Inbox/` deleted after reading.

Study without ticket 2026-10-18 of the two reds of the full passes of 2026-10-15 (code read, no run): `Source` and `Mod/Defs` have not changed since the rest and breeding commit `70feeae` (2026-09-25) apart from the wind barrier, and the same scenarios were green 11/11 on 2026-10-01 on that code. "A tame pair mates" (English SeXie, French QiongQi, one race each): the game gives one chance in two of pregnancy per mating (`RestAndBreedingSteps.cs`), the step mated 5 times in 2454 of 3600 ticks, the real-time cap of the run (150 s) cut it, so a slow full pass plus about a 3 percent run of five misses; probable flake of the test, not of the mod. "A tired tame beast lies down" (French, chicken, rest 0.04, job GotoWander after 20 game seconds): one race of six, not reproduced in English; probable timing flake. Not proven: no replay filed. Both stay open as probable flakes until a small replay (features 15) is green; no code change made.

Results of the three tickets of 2026-10-18 read 2026-10-19 (`bfb0` siege, `84fc` English and `ec24` French rest and breeding): all three ran the wrong scenarios. The Docker launcher splits a `-Filter` at the first space (`stalled-*` logs: `-pickle-run=::the -pickle-http-port=nian`), so each ran `::the`, every scenario whose title starts with "the", with a broken port argument. No siege, rest, breeding or barrier scenario ran in any of them: those checks are unproven, not red. The tool-suite reds seen there (main menu, interface scale, bottom buttons) are not the mod's. Kept in `Evidence/` with a `RELEASE.md` each: `2026-10-18a-siege-en` (78 of 80 passed, watchdog-timeout, partial proof of features 04 to 21 on tree ecf6758), `2026-10-10i` (extractor scenario only), ADS2, Nocturnal and CCE of 2026-10-15. Stale and covered flags judged 2026-10-19: ADS2, Nocturnal, CCE not stale (only French text commits since 2026-10-15, none touches categories, load order or body clocks); siege scenario dropped from `2026-10-10i`, `2026-10-10j` deleted (siege green contradicted by the 2026-10-15 red, step changed 2026-10-18; script's COVERED 1/2 came from the French run of the same scenario name, not a real replay). Siege replay `20261019-172836-342-b4f9` (filter `22-siege`), rest and breeding English `...-1d12` and French `...-dd12` (filter `15-rest-and-breeding`) filed 2026-10-19 on tree ecf6758. Deleted: the five other runs and three stalled archives. Next: replay `::the nian beast attacks the enclosure...` (siege), `::a tame pair mates and the female gives birth` and `::a tired tame beast lies down` once the launcher passes a filter with spaces (reported to TM). Tree stays frozen at ecf6758 for Mod and Source. Gallery 6 waits for `shootGallery`.

Results of the three tickets of 2026-10-19 read 2026-10-20 (`b4f9` siege, `1d12` English and `dd12` French rest and breeding, folders `2026-10-19b-*`, tree ecf6758). All three ran feature 15 scenarios (the siege ticket too: no siege scenario ran, siege stays unproven). Feature 15: rest need, hostile rest need and arrives-rested green 5/5 in each run; tired beast lies down 5/6, mating and birth 3/4 or 2/3; the egg scenario red once in two English runs. Every red is a real-time cut, not the mod: the game ran 1026 to 1952 ticks of the 2700 to 3600 asked in 150 s (about 7 to 13 ticks per second), the step timeout of 100 s fired on the tired beast, and the mating step had made only 2 to 4 matings at one chance in two each. Test cap too tight for a slow game; mod and Source untouched. Kept in `Evidence/`: `2026-10-19b-rest-breeding-en` (summary, junit, `RELEASE.md`). Rest deleted. Protocols moved to `docs/` (2026-10-20): re-read, only the Markers rule changed (pastille none when working with no ticket). Open: siege replay, and a green feature 15 (cap raised or game speed).

Ticket 2026-10-20 (tree a40e0f2, Mod and Source frozen until RUN_DONE): game-wait cap raised 150 to 300 real seconds (`Stage.cs`), rest and breeding step timeouts to 320 s. Filed on feature filters without spaces: siege `20261020-231625-639-a8ce` (`22-siege`), rest and breeding English `20261020-231633-147-ce6f` (`15-rest-and-breeding`). French rest and breeding follows if English is green.

Preview 2026-10-23 (owner validated in chat): regenerated from the new Preview.config.json schema (`panel.panelAnchor` bottom-left, echo.file `echo-source.png`), echo kept, `echo_review_sha` d4409fa, `social_preview_sha256` 9bb02411..., uploaded as GitHub social preview by Claude in Chrome (seen on the settings page; no og:image hash read). Tickets a8ce (22-siege) and ce6f (15-rest-and-breeding) wait, owner rerouted by TM to session local_f1e4cc35 (code ACBaGE); on RUN_DONE read summary.json, replay French rest and breeding if English green. Mod and Source frozen at a40e0f2 until then.

Gallery plan rewritten 2026-10-23 after /rate-gallery (series mean 1.6, not played): `24-gallery.feature` header now carries a per-shot plan with risk and counter-plan; Nelim changes outfit, hair (Roo_Royal_LongHD under a hat, Roo_HD_Hair_Highpony without; no bun), action and decor in each shot; shot 2 staggered (no arc), shot 7 keeps its roof (four lit torches) and gets a hen and daylilies, shot 6 Nelim moved to (141,170). `wsl-deps.sanctuary.map` gains Roo's HD Hairstyles (3559870636). Check-Steps green (717 lines resolve). Subtitle 7 updated. Gallery stays untouched at playTests; no ticket filed, no capture taken. Unverified: Plant_Daylily, Sandbags, Brazier, TorchLamp, Kibble, Hay, MedicineHerbal, RI_Apparel_DragonRobe/InsideApparel/LongPants/SanShanHat defNames resolve in game (RI and Roo names read in the mod folders); cell (141,170) standable; hat plus Roo hair renders under Show Hair Under Stuff (HAT-HAIR-STUDY ticket e457 unread).
