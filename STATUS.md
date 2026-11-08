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
workflow_stage: playTests[1.1.0]
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
session:      local_f1e4cc35-8614-406f-80ff-0a2487014a59
updated:      2026-11-08
protocols_read_sha: 6e1f76dfd8a201085e01aa7faff8b5ed6631b5fd
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

Older dated sections moved to `docs/runs/2026-10-13-status-history.md` (until 2026-10-13) and `docs/runs/2026-11-05-status-history.md` (2026-10-15 to 2026-11-03).

Resume 2026-11-05: protocols_read_sha 1cee56b1 (diffs of AUDIT, PICKLE skimmed: 6.g review now needed to leave localize, `mod.json` manifest, Preview config key `background`: no effect at playTests; `-Force` used, dirty `docs/registre/summary.md` is not a stage doc), TM registered (session local_ab115c2b). No archived session of this mod. Preview regenerated (echo.width/height removed 2026-11-03): opened, echo red beside the panel text, nothing cut, no overlap with title; committed. Mod tests conversion (AGENTS.md "Mod tests shape", owner 2026-11-05) deferred: ticket febe (French feature 15) still running, Mod and Source frozen. Open: febe result, then conversion to `Tests/Rule-OwnValues.ps1` (ask CI/CD for `--regenerate`), 8.c/8.g barrier hardening, 8.f feature 13, 8.i French pass, 8.l `tested_on`, 8.m code review. STATUS.md over 40 KB: journal to `docs/runs/` at next cut.

Preview 2026-11-05: regenerated from the config migrated by Virginie (no titleSize, tag as words, Fit-Title of protocols a93cc18: titleSize 38, two title lines, tag on two lines below), opened, echo clear of all text, nothing cut; validated by Virginie in chat ("validé"). Mod tests converted (Tests/Rule-OwnValues.ps1, generated Test-Mod.ps1, windows mod-tests job in build.yml, Audit stamped). social_preview_sha256 bed19bf6a75a979b82a8c54c3287435f9f6782b0ba810a65e8de34a707c38673: GitHub social preview uploaded by Claude in Chrome 2026-11-05 (settings page shows the new image, no og:image hash read).

Sleep 2026-11-05: tests converted and pushed (Rule-OwnValues.ps1 stamped by Audit; generated Test-Mod.ps1 and build.yml with the windows mod-tests job, CI green on b11b949; PatchEngine now on the runner, patch rules run there; never hand-edit build.yml, ask CI/CD to regenerate). Preview regenerated, validated and uploaded as GitHub social preview. TM order "map is shown alone" already done (feature uses the shared Nelim's Pickle Tools steps, no local copy). Waiting: ticket febe (French feature 15, queued behind NSB/NPT, TM relays RUN_DONE; on green minify into `Evidence/`). Open: 8.c/8.g barrier hardening, 8.f feature 13, 8.i French pass after febe, 8.l tested_on, 8.m code review (Opus sub-agent), GALLERY rule d vs 24-gallery plan, STATUS.md over 40 KB (journal to docs/runs/).

Resume 2026-11-05 (2): protocols_read_sha 95f9ae9b (diffs of AGENTS, GALLERY, STYLE_RIMWORLD, scripts.md skimmed: no effect at playTests), TM registered (local_ab115c2b), no archived session of this mod, sleep marker deleted. Preview.png committed 2026-11-05 so no re-render owed, but `Art/Preview.config.json` has an uncommitted edit by another hand (title now `Expanded` 0.65 + `Renew (unofficial)` suffix): not mine, Preview.png not re-rendered from it, owner to say. Ticket febe (French feature 15) no RUN_DONE yet. STATUS.md journal moved to `docs/runs/2026-11-05-status-history.md`.

Preview 2026-11-05 (2): regenerated from the edited config (Expanded 0.65 + suffix Renew (unofficial), titleSize 39, three title lines), opened, echo clear of text, nothing cut; validated by Virginie in chat ("je valide"). social_preview_sha256 ef4033f58e512d0f5eaff4384e2ca7d1c0c5e0a2142fb371a5569a324223052c. GitHub social preview uploaded by Claude in Chrome after her "oui" (settings page shows the new image, no og:image hash read).

Sleep 2026-11-05 (2): Preview regenerated, validated, committed (a4cfb8b) and uploaded as GitHub social preview (194ecbe). Waiting: ticket febe (French feature 15, TM relays RUN_DONE; on green minify into `Evidence/`). Open: 8.c/8.g barrier hardening, 8.f feature 13, 8.i French pass after febe, 8.l tested_on, 8.m code review (Opus sub-agent), GALLERY rule d vs 24-gallery plan.

Resume 2026-11-06: protocols_read_sha 37600657 (diffs of AGENTS, GALLERY, STYLE_RIMWORLD skimmed: Preview auto-regen rule, nothing changed in Preview inputs; gallery rewrite-deletes rule n/a at playTests), TM registered (local_ab115c2b), no archived session, marker deleted. TM backlog digest (118 runs): newest 12 all already digested (8d2f egg green 11-03, ca51 20/21, a8ce siege green, others old watchdog exit=3 read at the time); Inbox and Parked empty. Still waiting: ticket febe (French feature 15), queue paused by Virginie.

Resume 2026-11-06 (2): protocols_read_sha 89aa1bb1 (log since 37600657: AUDIT-STATUS, LOCAL_SCRIPTS rows, Run-PickleWsl remote: no effect at playTests; -Force, dirty scripts/Run-PickleWsl.ps1 not read), TM registered (session local_5bc1b5af), no archived session of this mod, Preview.png committed 2026-11-05 so no re-render owed. Still waiting: ticket febe (French feature 15). Open: 8.c/8.g barrier hardening, 8.f feature 13, 8.i French pass after febe, 8.l tested_on, 8.m code review.

Resume 2026-11-06 (3): protocols_read_sha 2eac6514 (new doc docs/LOCAL-SCRIPTS-CUT-2026-11-06.md skimmed: no row for this mod, no effect at playTests), TM registered (local_5bc1b5af), no archived session of this mod, Preview.png committed 2026-11-05 so no re-render owed. Still waiting: ticket febe (French feature 15). Open: 8.c/8.g barrier hardening, 8.f feature 13, 8.i French pass after febe, 8.l tested_on, 8.m code review.

RUN_DONE 2026-11-06: ticket febe (French feature 15 rest-breeding-fr, run 2026-11-03a): exitReason passed, 22/22, 0 failed, 0 skipped, lane hetzner. Minified to Evidence/ with RELEASE.md (older en rest/egg folders deleted by Prune-Evidence). Inbox empty. Mod and Source unfrozen: next 8.c/8.g barrier hardening, 8.f feature 13, 8.i French pass remainder, 8.l tested_on, 8.m code review. TM note: replay-audit now runs from zero (claude-plugins 70d7e16), ledger .replays/<Mod>-<date>.tsv, then REPLAY to Audit; not started here.

Code review 8.m 2026-11-06 (Opus sub-agent, f809e47f..0962a7e): 4 findings in Ability_WindBarrier.cs (stale static StoreProjectiles list could pass the same-map check and crash Destroy; reflect ran before the validity check; catch logged no stack and no once-guard; no spawned check on the pawn). Fixed in 6589e5f: projectiles read from pawn.Map.listerThings, early return when pawn not spawned, Log.WarningOnce with full exception. Run-All.ps1 green, DLL rebuilt. code_review_sha NOT set yet: set it to the sha reviewed after the replay is green (re-read the diff 0962a7e..HEAD first). Tickets filed on 6589e5f: f878 (feature 20 wind barrier, English, Inbox 2026-11-06a-barrier-en), bacf (feature 13 original mod, Inbox 2026-11-06b-original-en); older 0cb9 and 2596 cancelled. On RUN_DONE: read summary.json and junit.xml, sort per TEST-EVIDENCE.md; if green: 8.c/8.g barrier and 8.f feature 13 done, then 8.i French pass remainder, 8.l tested_on, 8.m code_review_sha, 8.n. Mod and Source frozen until both RUN_DONE.

RUN_DONE 2026-11-06 (read at resume 2026-11-07, Inbox): f878 feature 20 wind barrier English, exitReason passed, 2/2, 0 NullReference in Player.log, tree 6589e5f; bacf feature 13 original mod English, exitReason passed, 1/1, tree 6589e5f. Minified to Evidence/ with RELEASE.md. 8.c/8.g barrier and 8.f feature 13 done; code_review_sha and tested_on set. Open: 8.i French pass for the French text changed since f809e47f (features 05, 08, 12, 18, 19, 23), then 8.n. Scenario D: no `*-addition.feature` here, nothing to remove.

Resume 2026-11-07: protocols_read_sha 18f8db99 (diffs of AGENTS, AUDIT, GALLERY, PICKLE read: `tested_on` never empty, scenario D not applicable, mod contacts Virginie directly; no effect on this stage), TM registered (local_dd8cdcd8), no archived session of this mod, marker deleted.

Ticket 30ce filed 2026-11-07 (French features 05, 08, 12, 18, 19, 23, tree 6589e5f, Inbox 2026-11-07a-french-text). On RUN_DONE: read summary.json and junit.xml, sort per TEST-EVIDENCE.md; green: 8.i done, then 8.n to shootGallery[1.1.0]. Mod and Source frozen until RUN_DONE.

OptionalCompat 2026-11-07 (TM order, Audit 4.b/4.e): Check-OptionalCompat OK, 1 patched target, 1 declared: Mlie.XNDNocturnalAnimals (workshopId 2269731409, patch), commit 40690e7. ADS2 loadBefore and CCE loadAfter are order-only, not declared. Audit told. File added while ticket 30ce waits: no code change, no relaunch.

RUN_DONE 2026-11-07: ticket 30ce (French features 05, 08, 12, 18, 19, 23, tree 6589e5f): exitReason passed, 27/27, 0 skipped, 0 exception in Player.log, lane azure. Minified to Evidence/2026-11-07a-french-text with RELEASE.md, Inbox empty. 8.i done. FRENCH_REVIEW.md regenerated as TRANSLATION_REVIEW.md (new name, AUDIT 6.f); protocols_read_sha a0f60444. Mod and Source unfrozen. Next: 8.n to shootGallery[1.1.0].

Resume 2026-11-08: protocols_read_sha 6e1f76df (diffs of AGENTS, AUDIT, PICKLE skimmed: AUDIT 9.e bis gallery subtitles applies at shootGallery, rest wording; `-Force`, dirty files are docs not read for this stage), TM registered (local_ab115c2b), no archived session of this mod, marker deleted. Preview.png committed 2026-11-05 so no re-render owed; `Art/Preview.config.json` still has an uncommitted edit by another hand (not mine). Open: 8.n to shootGallery[1.1.0].

Replay 2026-11-08 (from zero, ledger ../.replays/AncientChineseBeastAndGeneExpandedRenew-20261108.tsv, Check-Replay OK): sections 1 to 8 read, 60 done, 8 n/a, 8.m and 8.n open, stage stays playTests[1.1.0]. 8.m: 40690e7 changed Mod/About/OptionalCompat.xml after code_review_sha 6589e5f; the game ignores the file but AUDIT 8.m exceptions do not list it, so Audit to confirm the exception (then set code_review_sha to HEAD) or ask a review. Run-All.ps1 green now (exit 0); Run-UnitTests.ps1 n/a (no Tests.exe at root, script defect); Check-DefInjected 12 NO FIELD on modExtensions list paths (unverified, script limit); Check-Translations default run flags SZ_CannotReachBuildingToExtractGene (mod allowance in Run-All, inherited). Then 8.n to shootGallery[1.1.0].
