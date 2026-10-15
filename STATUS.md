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
workflow_stage: code[1.1.0]
social_preview_sha256: d39149d2b12bf4a09c53fbeda175a8155c3cf61bf394c9309394e720496db79c
echo_review_sha: aa3be1896d12bc22ee330dfeacec30ff9e1c5328  # 2026-10-13, 10.a: echo kept
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
      (`2026-10-08a-replay-reds`, `2026-10-08c-fr-egg-1`, `2026-10-08b-fr-18-23`, `2026-10-10f-strike`). Pass 2 (French, 2026-10-02):
      chunks a, b, c ran (drought and egg red, both green since); chunk d left no report, features 18 to 23 re-run in French
      `2026-10-08b-fr-18-23` and the siege `2026-10-10i/j`. Passes 3 (`2026-10-02g-p3-17-replay`), 4 (`2026-10-02f-p4-13-replay`),
      5 (`2026-10-01d-p5-14`, 11/11) and 6 (`2026-10-01e-p6-16`, 11/11) passed. No red scenario is left. No full pass is owed
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
  - verified 2026-10-13: the two `@review` captures that missed their subject were retaken (`2026-10-09a-review-captures`) and opened:
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
updated:      2026-10-10
protocols_read_sha: 65e09838c8023b798d4ba0ff04df04284a96f11e
---

# Ancient Chinese Beast And Gene Expanded Renew: status

Read by a sweep across every mod, rather than by asking each thread in turn. It lives at the
root, never inside `Mod/`, so Steam never receives it.

## Where this one stands

### Gallery - 2026-10-13

Seven staged photographs on the Sanctuary Backlot plus the Preview, all accepted by the owner (commits `54945a2`, `f41a79e`, `09577d4`, `35ba34e`, `1a91870`); `Art/Gallery/` holds nothing else. Opened again 2026-10-13. Order: the four beasts together come second (the most demonstrative), the dawn crow opens the story.

| Index | File | Shows |
| --- | --- | --- |
| 0 | `0-preview.png` | Preview, byte copy |
| 1 | `1-dawn-crow.png` | rooster and hen among statues (green overlay lines at the edges, accepted as is) |
| 2 | `2-four-beasts.png` | the four beasts together |
| 3 | `3-qiongqi-far.png` | the qiongqi far from Lan |
| 4 | `4-nian-fire.png` | the nian beast breathing fire |
| 5 | `5-wind-barrier.png` | the mingshe inside its wind barrier |
| 6 | `6-sexie-aura.png` | the sexie scorpion form in its aura |
| 7 | `7-extractor.png` | the gene extractor in the sunlit workshop |

### Reviews by Virginie - 2026-10-13

She validated in chat ("validé") the French of revision `54eb9fb` (`FRENCH_REVIEW.md`, regenerated at `e50d33d`: crow song without the generic masculine, "rage meurtrière" for the three berserker uses, qiongqi claw gene names, sound-wave wording), then `PUBLICATION.md` and `CHANGELOG.md` at `e50d33d`. The review-line table of `FRENCH_REVIEW.md` stays blank: the shared script never writes it (hers), so her word is recorded here.

### Dry-run 1.0.0 - 2026-10-13

Run `38369174343` (https://github.com/vbardales/Rimworld-Ancient-Chinese-Beast-And-Gene-Expanded-Renew/actions/runs/38369174343), `publish-tag.yml`, mode dry-run, ref `ff3ecbd8d5aebf1ae9ed741c0287567ef20a91ce`, version 1.0.0, options `update_preview=true update_description=true update_title=false update_tags=false`, template `ef2f76993832`. Success; log read: 189 files, 6.64 MB staged (Textures 80 files, no `.dds`, `Assemblies/` 1 file), change note `[b]1.0.0[/b]`, preview `d39149d2...` 625361 bytes (equals the committed Preview), description 6786 characters converted to BBCode (names no RimWorld version, carries the Chinese Comprehensive Expansion thanks), tag-and-release skipped as expected. The item is private, so no comparison with a public page. The gallery (`Art/Gallery/` 0 to 7) is the owner's manual upload.

### Publication 1.0.0 - 2026-10-13

Run [38369937487](https://github.com/vbardales/Rimworld-Ancient-Chinese-Beast-And-Gene-Expanded-Renew/actions/runs/38369937487): dispatched by this session with `dispatch-publish.sh` on `ff3ecbd8d5aebf1ae9ed741c0287567ef20a91ce` (same options as the dry-run), approved by Virginie on `steam-production`; `publish` and `tag-and-release` green. Tag `v1.0.0` on `ff3ecbd` and the GitHub release exist. `About/PublishedFileId.txt` still reads 3806709132, committed. The item stays private (visibility is never sent): the owner turns it public and uploads the gallery by hand. Not read yet: the item page, which a private item does not show to a session. `USE_THIS_INSTEAD.md` row drafted, comment drafted in `PUBLICATION.md`; thank-you comments (Chinese Comprehensive Expansion row in `WORKSHOP_COMMENTS.md`) wait for the public switch (14.b).

### Non-regression 1.0.0 (14.a) - 2026-10-13

Item public (owner, 2026-10-13); the Steam API still answered `result 9` (not readable) a few minutes after, so the public page is not read yet. Gallery uploaded by the owner. Six requests filed on revision `ff3ecbd` (Mod and Source unchanged since): English `20261013-104025-715-5390` (`2026-10-13a-nr-en`), French `20261013-104026-466-9293` (`2026-10-13b-nr-fr`), ADS2 `...-e453` (`c`), Nocturnal `...-66be` (`d`), CCE `...-a2ea` (`e`), original mod `...-09c7` (`f`). Result English (`2026-10-13a-nr-en`, ticket 5390, `exitReason: failed`): 119 scenarios, 86 passed, 2 failed, 31 skipped. RED: the two wind-barrier scenarios ("the barrier cuts what stands inside and spares what stands outside", "the barrier throws back a shot fired from outside it"), both on `NullReferenceException` in `ListerThings.Remove` via `Ability_WindBarrier.AbilityTick` -> `Destroy`, the null reference the guard of 79d0cd6 (2026-10-01) was meant to stop; both were green on 2026-10-08b in FRENCH (`2026-10-08b-fr-18-23`); English pass 1 had them red before the guard and no English green is recorded; same game 1.6.4871 rev600, same assembly (built 2026-10-10 19:34). Dispatcher held the lock about 60 min before END. Cause not found yet. Cause analysis: `ListerThings.Remove` throws only when the map lister never registered the projectile (group lists are created in `Add`), so the guard of 79d0cd6 cannot catch it; the static list `Ability_WindBarrier.projectiles` stays stuck after the throw, hence nine repeats. Replay of feature `20-wind-barrier` in English filed: `20261013-162831-460-e0b4` (`2026-10-13g-nr-barrier-replay`). Replay `2026-10-13g-nr-barrier-replay` (ticket e0b4, `exitReason: passed`, 2/2, 0 NullReference in Player.log, same game and DLL): the two barrier scenarios are green alone, red only inside the full English pass. So not deterministic on the barrier itself; the order of the full pass (state left by earlier scenarios, e.g. the static projectile list) is the suspect, not proven. Defect of 1.0.0 stands as an intermittent one; hardening of Ability_WindBarrier.cs written 2026-10-14 in 1.1.0 (local lists, remove-before-destroy, same-map check, try/catch with one warning; dotnet build green; Tests.csproj fixed 2026-10-14 (the ignored Tests/build/ held a Pickle-step AssemblyAttributes.cs that the SDK globbed, CS0579); Run-All now: 108 content checks 0 failure, 26 assembly contracts nothing to report, then the translations step still stops with 6 findings, as on 2026-10-13 with the change stashed; barrier not played yet). The code review sha and playTests reopen on this Source change. Other five results not in.

### Next version 1.1.0 - 2026-10-13

Owner (2026-10-13): the description-form fix waits and is grouped with the RimWorld 1.7 pass; minor bump to 1.1.0, so the chain reopens at `code[1.1.0]` (AUDIT.md 14.e). Comments posted by the owner on 2026-10-13: the original mod page, Chinese Comprehensive Expansion, Use This Instead (registers updated). The six 1.0.0 non-regression tickets are still running on `ff3ecbd`. `tested_1_7` is absent: the 1.7 prerequisites (Pickle PR 63, NPT steps on net10.0) are not read here.

### Echo review - 2026-10-13

Kept. `Art/echo-source.png` is the line art of the winged qiongqi; gallery 2 (four beasts) and 3 (qiongqi far from Lan) show that same beast, so echo and gallery agree and the subject has not moved. The Preview rendered from it (`ccf028b`, flipped echo, cropped badge) is 896x504, opened at full size: title, rule, summary, red echo under the panel text, ModIcon at the bottom right, 1.6 badge top right, nothing cut. `Mod/About/Preview.png` sha256 `d39149d2...` equals `social_preview_sha256`: the social preview on GitHub is current (repository public). `Art/` holds the minimal set plus `textures-original/` (kept, owner decision 2026-10-11).


## History

Older dated sections (workflow audits 2026-09-13 to 2026-10-11, translation audits, preview verification and migration, in-game verification notes) moved to `docs/runs/2026-10-13-status-history.md` on 2026-10-13.


AI-GENERATED claim (owner, 2026-10-15): the preview background and the icon were generated with DALL-E (OpenAI). The description of 1.1.0 now names it (PUBLICATION.md, About.xml regenerated); the 1.0.0 page still says "AI-generated artwork" until 1.1.0 is published.
