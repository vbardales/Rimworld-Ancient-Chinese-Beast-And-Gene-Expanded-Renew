---
localization: complete
translation_en: complete
translation_fr: complete
settings_audit: not_applicable
code_review_sha: fd2eea026104d91d60f905f251f6925f90cee573  # 2026-11-18, 12.a: diff 36832a44..HEAD over Mod and Source read: Mod/About/About.xml (description text: RimImmortal-Living thanks line, twelve genes) and five French DefInjected text lines (passes 27 to 32), Source, Assemblies and Patches unchanged: revue du diff : texte seul.
mod:          Ancient Chinese Beast And Gene Expanded Renew (unofficial)
packageId:    nelim.ancientchinesebeastandgeneexpanded
repo:         Rimworld-Ancient-Chinese-Beast-And-Gene-Expanded-Renew
remote:       https://github.com/vbardales/Rimworld-Ancient-Chinese-Beast-And-Gene-Expanded-Renew.git
visibility:   public
detached:     yes
workflow_stage: writeReleaseDocs[1.2.0]
tested_1_7: yes  # 2026-11-17: baseline 170 passed (a8a1), our 7 time-bound reds all green since with tick batches (drought 585f, scheduler 40a4, births 3fcf, firecracker 2369); the 7 other reds were NPT scenarios (tool side)
social_preview_sha256: 62216f5b519f010f91174cf016253987b6e6c1b7ff211cf0e2f5ab1592c12134
gallery_validated_sha: 7687bfe8274569fb4480aa027e1a8bd472213134  # 2026-11-22 oui de Virginie ("je valide", chat), 8 images, scene 5 eyes judged normal (face mods VTE/VEFA)
echo_review_sha: a2592eb9cbd7ca2318d05357432488b1eecbffbb  # 2026-11-22, 10.a (after the gallery redo of scenes 3 and 6): Virginie kept the echo ("Garder l'écho", chat), echo-source.png unchanged. Previous: 91bc63b3fd1cca5e03baf36c4b5ee9f450de99be  # 2026-11-18
preview_source_decision: keep, 2026-11-22  # Virginie: "on garde la preview" (chat), after the echo kept; Art/Preview-source.png unchanged
publication_changelog_review_sha: fd2eea026104d91d60f905f251f6925f90cee573  # 2026-11-18, 11.j: Virginie read PUBLICATION.md and CHANGELOG.md of the 1.2 line and validated ("je valide", chat). Previous: d7493d64d8c270087bd8ab943ce3044d6f67a59b  # 1.1 line
thanks_drafted_line: 1.2
ecosystem_line: 1.2  # 2026-11-22, PiI short DELTA since 2026-11-13: nothing new (report section "Delta 2026-11-22", pushed 9076dc7)
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
tested_on: 2026-11-18 pickle 1d91 (1.6 English non-regression of 1.2.0, 200 passed, 38 skipped, exitReason passed, Docs/runs/pickle.md); earlier 2026-11-06 pickle 6589e5f (1.6, English: feature 20 wind barrier 2/2 and feature 13 original mod 1/1 green; French feature 15 22/22 green 2026-11-03)
workshop:     published 2026-10-13, item 3806709132, public since 2026-10-13 (the owner switched it, after the upload), version 1.0.0, tag v1.0.0, run 38369937487 (publish and tag-and-release green)
remaining:
  - gallery 3 CANDIDATE (2026-11-22, ticket 94d3 green on hetzner, capture opened: Nelim directly behind the sandbags, clear of the subtitle band, qiongqi and hen readable; 268 px read as before). Files Art/Gallery-clean/3-qiongqi.jpg and Art/Gallery/3-qiongqi.jpg (0,42 MB), run minified in Tests/Pickle/Evidence/2026-11-22b-gallery-3-qiongqi. Scene 6 candidate since 51d2. All 8 images are candidates and subtitled (hash 7687bfe8274569fb4480aa027e1a8bd472213134). Next: replay-audit, then Virginie validates the whole gallery once (9.f, `gallery_validated_sha`), never image by image
  - patch 3293695725 "Remove Ancient Chinese Beast Gene textures" (XXK.AncientChineseBeastNoTexture; Virginie 2026-11-22: "B, quitte a le mettre sous forme de param dans la conf", test it with RTI). Read: Patches/Patch.xml = 4 PatchOperationRemove (success Always) of renderNodeProperties on SZGene_MingShe_WindWing, SZGene_QiongQi_FlyingStrike, SZGene_SeXie_Shoot, SZGene_YearBeast_Horn, all four defined by this mod too; its About has no dependency or guard, so it should apply when loaded after this mod (not verified in game). RTI session: irrelevant to this patch (no MayRequire/FindMod); UTI already pairs andery233xj.AncientChineseBeast to this mod but the pair is OFF by default in RTI, on by default only if Renew ships About/ResolveThisInstead.xml with the pair and `<compatible>yes</compatible>` (optional, not asked). Test: Tests/Pickle/wsl-deps.notexture.map + 29-no-texture-patch.feature (d568e88), ticket 330e RAN 2026-11-22: scenario 2 (four genes lose their render nodes, abilities stay) GREEN with the patch loaded BEFORE this mod, scenario 1 RED on its own assertion "loads after" (staging put the patch first); XML patches apply after all defs, so order likely irrelevant, not proven; TM confirms the order is the map/staging, not the game; this mod has no loadAfter on the patch and needs none. Order assertion removed from scenario 1; rerun ticket de08 GREEN 2/2 2026-11-22 (hetzner; scenario 2 uses the PiT "has no value" steps, 4 of them, so they are played and green), minified in Tests/Pickle/Evidence/2026-11-22c-notexture-29, parked run deleted. PiI told the id is free. Virginie 2026-11-22: option 1 (documentation only, no incompatibility to remove: Renew declares incompatibleWith only the original, Remove has no dependency). Note written in PUBLICATION.md ("Gene textures", credit 逍逍客) and synced into About.xml; EN only, FR and zh notes not asked. The map wsl-deps.notexture.map stays (PiI told, id stays subscribed); it uses PiT's two new steps "has no value / has a value in the field" (compiled, NOT PLAYED, DefFieldSteps): a red may be the steps, not the patch. PiI keeps 3293695725 subscribed (protected study_for_ACBaGE) until I say free. On RUN_DONE: green means recommend documentation only (PUBLICATION.md and About note: subscribe to the patch, load it after Renew); then ask Virginie option 1 (note) or 2 (an options checkbox "show gene textures", needs C# in Source, EN/FR/zh keys, MOD_SETTINGS.md pass, version 1.3.0, tests). Tell PiI the id is free when done
  - (older) gallery 3 and 6 REDO a third time (2026-11-22): ticket 00a2 green (2/2), captures opened and 268 px thumbnails checked, both REDO, run folder deleted. 3: qiongqi faces Nelim, hen and sandbag shown, but Nelim about 15 px tall at 268 px, back to camera, rifle and bracing not readable (understanding 3.5). 6: aura ring and scorpion readable, but Ryu stands idle with pale torso (collar shirt reads as bare), no knife visible, no lunge, Nelim not cowering visibly (adequacy 3, understanding 3). Cause of 6 not established: berserk is sent before the knife and the poses are set, the job may be dropped; ask NPT for a mid-attack pose step. Recomposed b5b6cc9 (3: Nelim one cell closer, zoom 12; 6: knife wielded, Ryu ordered to attack the sexie with the existing NPT step, 40 ticks pass before the pause, shirt (52,84,120), zoom 12), ticket 8725 "gallery 3 and 6 redo v3 b5b6cc9" filed (evidence Tests/Pickle/Inbox/gallery-redo-3-6c). On RUN_DONE: open both captures, thumbnail check at 268 px, judge (score-gallery), subtitle (Add-Subtitle), add to Art/Gallery and Art/Gallery-clean as 3-qiongqi.jpg and 6-sexie-aura.jpg
  - translations (Virginie 2026-11-23, rule (a), PUBLISHING.md and AUDIT 11.h): THANKS now cites the original authors for the mod AND its Simplified Chinese text (done, About synced). Their thank-you message: a comment on the original page was posted 2026-10-13; Virginie 2026-11-23: no second message, the posted comment stands (WORKSHOP_COMMENTS.md: a second on a posted page is never the default)
  - writeReleaseDocs[1.2.0] (replay writeReleaseDocs.. 2026-11-22, Virginie typed it, stage unchanged): 11.a to 11.g done (adult boxes text fixed in place). Open: 11.h thanks draft for Remove (she said not now), 11.i Steam note of the next version, 11.j her reread of PUBLICATION.md and CHANGELOG.md (description changed), 12.a code review record (About.xml description text changed since fd2eea0), 12.b to 12.h. VERSION: suffix 1.2.0 is the published one (v1.2.0 tagged 2026-11-18); next version unnumbered (CHANGELOG [Unreleased]); Virginie 2026-11-22: "on clean pour l instant", no release now
  - AGENTS migration done 2026-11-22: Docs/PROTOCOLS-READ.md and the Docs/runs files other than pickle.md and the cited 2026-11-19-publication-sent.md removed, pointers rewritten (STATUS, TESTING, Tests/Pickle/README, .gitignore)
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
  - unverified: whether `MonsterTower/AncientChineseBeast` (the 1.5 source, see the 2026-10-01 audit) belongs to the
      four credited authors: nothing links it to them. The pull request exists: [MonsterTower/AncientChineseBeast#1](https://github.com/MonsterTower/AncientChineseBeast/pull/1)
      (from `vbardales/AncientChineseBeast`, opened 2026-10-09, open on 2026-10-13, one commit, no comment, no reply). The C# has not
      changed since it was opened (`git log --since=2026-10-09 -- Source` holds only the `build/` path), so it is current
  - unverified: the nian beast's description lost its butchery paragraph on 2026-09-25 (English, French,
      Simplified Chinese; the promise of "nian beast fangs" was inherited text, a butchery yields meat only,
      seen in the run of that day). The field paths are unchanged; the four PowerShell 7 translation scripts
      were re-run 2026-09-26 and are green; the new text is in no in-game check yet
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
updated:      2026-11-22
upstream_synced: 2026-11-16 MonsterTower/AncientChineseBeast@f6d3d19
protocols_read_sha: dcfd14ae14dea5b3901b3582d8de41847d15a96d
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

### Ecosystem - 2026-11-13
Reviews and echo review of 2026-10-13 (French and PUBLICATION validated by Virginie, echo kept) removed from this file (git history keeps them); current echo state is `echo_review_sha`.


AUDIT 1.a, Steam search done by PiI (2026-11-13), full study in `docs/inventory/ecosystem-steam/AncientChineseBeastAndGeneExpandedRenew.md`. PiI one-line reply: original 3292446841 and its NoGene sibling 3047055011 (same author andery233xj, 21 shared defNames, held `needs_npt`) are the only mods sharing our defNames; no third fork; 19 weak hits, none shared.

Summary: Steam searches `Ancient Chinese Beast`, `Chinese mythology beasts`, `Chinese creature genes`. Found: original 3292446841 (2024-08, protected); NoGene sibling 3047055011 (fork-or-rewrite, same author's variant without the genes, not a competitor); link 3293695725 "Remove Ancient Chinese Beast Gene textures" (patch of the original, 1.6); name only 3313313985 "Ancient amorphous threat". PiI subscribed to the two small ones for study and unsubscribed them. Nothing else Chinese-themed holds our `SZ_*` defNames. Local scan from this session agrees (corpus 5302/5306 folders, 2 hits, our own `About.xml`). Gap settled 2026-11-13 (Steam API `GetPublishedFileDetails`, local `About.xml` files): 3047055011 created 2023-10-07, last updated 2023-11-27, `supportedVersions` 1.4 only, 1486 subscribers: dead for 1.6 (PiI's "alive 1.6" is wrong; the 2026-09-05 date is the local download). Upstream 3292446841 created 2024-07-19, last updated 2024-08-14, `supportedVersions` 1.4 and 1.5, folders `1.4/` `1.5/`, no 1.6, 3167 subscribers: not updated since our port. Licence not read. Nothing to add to `Check-OptionalCompat.ps1`, no combined pass owed at 8.f.


Delta 2026-11-22 (PiI, short search for the 1.2 line, report `docs/inventory/ecosystem-steam/AncientChineseBeastAndGeneExpandedRenew.md`): nothing new since 2026-11-13, no fork, duplicate or translation of the original 3292446841 or the twin 3047055011. Original last updated 2024-08-14 (1.4 1.5), twin 2023-11-27 (1.4), patch 3293695725 2025-06-18 (1.6). One link row added: Chinese Comprehensive Expansion 3221850511 (same authors, 1.5 1.6, named by our About loadAfter). Marks kept, no subscription made, local defName scan not rerun.

Owner decision 2026-11-16: no action on the patch 3293695725 (Remove Ancient Chinese Beast Gene textures) nor on the twin 3047055011 (NoGene, 1.4 only). Like every patch of an original, they wait for the release or the RTI pass; nothing asked of their authors, no own patch, no incompatibility declared now.
## History

Older dated sections (until 2026-11-09) and the shotlist and scene journals were moved out and then removed in the AGENTS migration of 2026-11-22; git history keeps them (`git log -- STATUS.md`).

### NSB - 2026-11-08

First sync (no earlier one). NSB changed a lot since the 2026-10-23 feature (170 commits of `docs/` since 2026-10-13): a decorated Sanctuary is being built (the fixture `Nelims-tribe` is still the old undecorated one), `gravel-yard` is to become a zen dry garden, `enclosure-south` already carries a Nelim logo in flowers (zones 3 to 15, "sans objet dessus", VALIDE 2026-11-08), NSB roster holds no "Ren" (the guest is now Ryu "Blue" Sai, "formerly Ren in older documents"). Shotlist files not rewritten here: `write-shotlist` is next and takes these into account. Rules said back (owner 2026-11-05 and 2026-11-07): everything in NSB is free; a colonist or domestic animal outside NSB needs the owner's express validation (an animal the mod adds is authorised by default); a colonist's properties change only with her words; every outfit is free; every animal the mod includes must be in the gallery.

Places read: 2026-11-22 (NSB log since 2026-11-18: one commit 6db18f8, runs/status journals migration only, no place change); 2026-11-18 (NSB log since 2026-11-17 read: one new commit 2372794, plan `RECONSTRUCTION-SAUVEGARDE.md` to rebuild the Sanctuary save as `Nelims-tribe-v2`, plan only, nothing built, gates open; places keep their names and frames, no change used here); 2026-11-17 (NSB log since 2026-11-16 read, 38 commits of docs: only profiles of other pawns (Iori, Miel, Celeste), VALIDE, NEUTRES-TETE, VTW-BODYTYPES, TESTING, GALERIE, ACG-FAISABILITE, Roster.xlsx; no place doc, no change used here); 2026-11-16 (NSB log since 2026-11-13 read: no commit, no change); 2026-11-13 (NSB log since 2026-11-12 read: no commit, no change); 2026-11-12 (NSB log since 2026-11-09 read: one commit, `docs/` renamed `Docs/`, no content change, no place or roster change); 2026-11-09 (NSB log since 2026-11-08 read: no change to a place used here; z3 decor fixture added beside Nelims-tribe, our scenes place their own decor); earlier 2026-11-08 (`SANCTUAIRE-LIEUX.md` sections 11 and 12 and the place table, grep of `VALIDE.md` and `EMBELLISSEMENT-LIEUX.md`; `SANCTUAIRE-CASES.md` not opened). Tribe read: 2026-11-22 (same log: no roster, profile or animal change); 2026-11-18 (same log: no change to Nelim, Blue, roster md, animals catalogue; only Iori, Miel, Quo, Quaren, Daichi, Dalia profiles and VALIDE, other pawns); 2026-11-17 (same log: no change to Nelim, Blue, roster md, animals catalogue); 2026-11-16 (same log, no commit); 2026-11-12 (same log, no change); 2026-11-09 (no change to roster, animals or profiles in the NSB log); earlier 2026-11-08 (`CATALOGUE-ANIMAUX.md`, `NELIM-PROFIL.md` first 40 lines, `GALERIE-HISTOIRE.md` cast, grep of `NSB-ROSTER.md`, `VALIDE.md`, `AVANCEMENT.md`; the other profiles not opened). Steps read: 2026-11-22 (NPT log since 2026-11-19, stat only: new steps for open windows and buttons logged, X faces Y or a cell, lamp glow scaled, light at a cell logged, animal steps, zoom floor 0.1; none serves this mod, gallery accepted, dormant, nothing used); 2026-11-19 (NPT log since 2026-11-18: StageDecor blueprint and plant removal, backstory steps, interface shown, selection cleared, mouth framing, terrain log; none serves this mod, gallery accepted, nothing used); 2026-11-18 (NPT log since 2026-11-17: new steps head-type assert, screen text and windows, attack and haul orders, game component field, float menu option, def metadata log; no catalogue change; none serves this mod, gallery accepted, nothing used); 2026-11-17 (NPT log since 2026-11-16: two face-parts catalogue notes on the vanilla face, no step, none used); 2026-11-16 (NPT log since 2026-11-13 read: new steps, a rewording of the render-nodes steps; none used by this mod, gallery already accepted) (NPT log since 2026-11-12, steps.md and catalogues: no commit); 2026-11-12 (NPT log since 2026-11-09, stat only: decor burns, filth removal, floor building, culture and work-giver steps, hide tab bar and speed controls, `docs/` renamed `Docs/`; none serves a scene, none used); 2026-11-09 (new: step `the light of the map is dimmed to at most {float}` and `is refreshed` for dusk or night captures, fits scenes 7 and 8; step `the animals except A, B and C are kept out of the area from..to..` for hens out of frame, scenes 1 and 3; `the camera orthographic size is held at {float}`; none used yet, pending tickets kept); earlier 2026-11-08 (`PickleTools/docs/steps.md` StageDecor section and greps, git log since 2026-10-23; the rest of the 217 KB file and the catalogues not read).

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


Translation audit 2026-11-13: Virginie validated the French review ("je valide la relecture"). `translation_fr` stays `complete`. The French of this revision is hers, validated; after 24 /review-translation passes and the names closed (Docs/review-names.md). The upstream pull request with the text corrections (BACKLOG TODO) may now be proposed to her for its go.

NOTE 2026-11-15 (owner, scene 1, applies to every scene): if the same animal appears twice in an image (two hens), one faces the camera and the other is in profile; for three, add one seen from behind. Apply if scene 1 is ever redone, and when any scene is recomposed. Raised to Audit.

NOTE 2026-11-16 (owner): the tool for every image generation is DALL-E (OpenAI), always. PUBLICATION.md "AI-GENERATED" already says DALL-E for the preview background and the icon: unchanged, no model version to add. Told to Audit for the shared procedure.
