# STATUS history, 2026-11-17 (evening)

Moved from STATUS.md on 2026-11-18: CI regeneration, 2369 green, 1.7 declared, Social preview, bf17 filed, replay 8.m/8.n and 9.f.

STATE 2026-11-17 (CI regenerated): CI/CD regenerated `.github` and `Tests/Test-Mod.ps1` (stamp d20db370c66b, Steam tags now a default of every publication, `--tags` and `update_tags` removed). Committed by path and pushed. `Check-CiTemplate` identical, `Tests/Test-Mod.ps1` 6 passed, 0 failed, 0 skipped. The 1.1.0 dry-run (43944718301) is obsolete: the dry-run of 1.2.0 is redone without `--tags` at `publish`. A real publish needs STEAM_REFRESH_TOKEN on `steam-production` (Virginie).

STATE 2026-11-17 (2369 green, tested_1_7 yes): ticket 2369 RUN_DONE green, 1 of 1 (47 s, set v17), firecracker chain green on 1.7 with the batched watch. Evidence minified and moved to `Tests/Pickle/Evidence/2026-11-17i-v17-firecracker`. Inbox 0. Every own red of the 1.7 diagnostic is now green; `tested_1_7: yes`. `<li>1.7</li>` and the Preview badge only with Virginie's word, same commit as the Preview redo. Owed: 1.6 non-regression of 1.1.0 (14.a), sync-nsb-npt, STATUS.md journal move (48 KB).

STATE 2026-11-17 (1.7 declared, owner "oui"): `<li>1.7</li>` added to supportedVersions, Preview re-rendered (badge now 1.7, opened: nothing cut), `social_preview_sha256` updated (new Preview to upload to the repo Social preview by Virginie). Art/Preview.config.json unchanged. Target 1.2.0.

STATE 2026-11-17 (Social preview): Preview.png (sha256 = social_preview_sha256, 1.7 badge) uploaded to the repo Social preview through Claude in Chrome, on the owner's order; the settings page shows the new image. Nothing owed from Virginie.

STATE 2026-11-17 (1.6 non-regression filed): journal moved to `Docs/runs/2026-11-17-status-history.md` (STATUS.md 27 KB). Ticket bf17 (1.6, English, filter `!24-gallery`, no DepMap, tree 4fcb011 frozen, Mod and Source unchanged since 6589e5f except text), evidence `Tests/Pickle/Inbox/2026-11-17j-16-noregression-en`. This is 14.a for the published 1.1.0. French not replayed (French text changed 2026-11-13 to 16, validated by Virginie, still owed if wanted). On RUN_DONE: read summary.json, junit.xml, triage, then cleanUp.

STATE 2026-11-17 (replay, 8.m and 8.n, Audit answer: no skip, AUDIT.md chain stays whole): code_review_sha refreshed (diff read: 1.7 line and Preview only). playTests[1.2.0] to writeShotlist[1.2.0]. 9 non touché : galerie 1.1.0 acceptée et inchangée (Art/Gallery images 1 to 8 unchanged since acf8b48, see 1.1.0 table above).

STATE 2026-11-17 (replay, 9.f): writeShotlist[1.2.0] to mountPreview[1.2.0]. 10 non touché : Preview 1.7 refaite et envoyée (render and badge 79b32d2, social_preview_sha256 equals Mod/About/Preview.png), echo kept (10.a, echo_review_sha refreshed).
