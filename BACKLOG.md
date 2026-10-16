# Backlog

Ideas for mod not started. Each entry say what mechanic would be, what already cover part of it, what must be settled before first line of code.

Idea earn place here only if serve what mod already do. Anything shipped is in changelog instead, anything needing watch in play is in `TESTING.md`.

Built 2026-09-25, moved to changelog: **the beasts rest and breed**, and optional **Nocturnal Animals** body clocks (first two entries of this file, decided by owner same day).

---

## Crossbreeding: a hybrid of a beast and an ordinary animal

Proposed 2026-09-25, still open. Mod meant taken to be **Better Crossbreeding** (DizzyEevee, Workshop 3520675842, `DizzyEevee.BetterCrossbreeding`), only current 1.6 mod of that name; installed. Its own page say it do nothing without a mod that depend on it. It extend vanilla 1.6 mechanic (`RaceProperties.canCrossBreedWith`) with `DZY.Crossbreeding.Extension` on mother's `PawnKindDef`, whose `outcomes` say, per partner species, what child is: maternal (vanilla), paternal, random, or another species drawn from weighted list.

**What mechanic would be.** Beast mating with ordinary animal and giving hybrid: Pleiades star officer with a hen, tame qiongqi with a big cat, tame nian beast with a muffalo; child being a beast, an animal, or a third thing.

### What is already there, and what it blocks

Blocker of first version gone: since 2026-09-25 beasts have two sexes, breed among themselves (see changelog), and chicken and mingshe lay eggs. What is left:

| Piece | What it gives | What it leaves |
| --- | --- | --- |
| Breeding among same race | a mother and a father, a pregnancy or an egg, a baby in player's faction | nothing that name another species: `canCrossBreedWith` is empty |
| `SZ_Chicken` lays its own eggs (`SZ_ChickenEggFertilized`) | a hen's fertilised egg hatches a Pleiades star officer | a vanilla rooster's fertilisation would hatch mod's egg, not a hybrid |
| Extractor's clone recipes | only way to first tame beast | a hybrid line is second way to a beast, and has to cost something |
| Genes (12) | beasts' abilities are genes a colonist can wear | a hybrid child would need to say which genes, if any, it carries |

**To settle before first line.**

- **Whether vanilla field enough.** `canCrossBreedWith` on a beast race and on partner's race let game mate them and child is mother's race; Better Crossbreeding only needed for another outcome (paternal, random, a third species). First thing to try is vanilla field alone.
- **Which pairs make sense.** Chicken with a vanilla hen, qiongqi with a big cat: only two with plausible partner.
- **The guard.** Better Crossbreeding's extension class kill a def when its mod missing, so its `outcomes` go behind same kind of guard as Nocturnal Animals patch (`PatchOperationFindMod` on display name).
- **Cost.** Hybrid child should not undercut the bench: sterile, or weaker, or only the chicken.

## A pull request to the source repository of the original

Found 2026-10-01: **`MonsterTower/AncientChineseBeast`**, "山海志怪Mod 1.5版本源代码", public, one commit (2025-09-10), no licence, forking allowed, issues open. It is original's 1.5 source; whether its owner is one of four credited creators not established (none of four carry account's name). `PUBLISHING.md` make a pull request to an origin repository systematic, independent of Workshop publication, and keep it here until done. It is public, so **nothing is forked or proposed without Virginie's word**.

What a pull request would carry: 1.6 changes (`PawnFlyer.TickInterval`, `PostDeSpawn(Map, DestroyMode)`, `Wildness` stat, `GenExplosion.DoExplosion` and `PathFinder` calls, `RegionGrid.AllRooms`) and fixes of defects original had (comp that threw on every destroy, null reference on a player-faction mingshe, beast incident that threw from debug menu), each described in `ATTRIBUTION.md`. This port decompiled from 1.5 assembly, not built from that repository, so two trees differ in layout (repository keep a `Harmony` folder and firecracker debug comp this port replaced; this port have `PatchMain.cs`, `DebugActions.cs`, one file per patch): compare file by file before proposing anything, and keep original's own layout in proposal. Defs and textures live in Workshop mod, not in that repository, so only C# can be proposed there.

## Done: the description has one source

Decided by CI session on 2026-09-25. `PUBLICATION.md` exists and hold Steam description once, in Markdown block under `## Steam description`, its last line `[Source code on GitHub](URL)`; `.github/publish.config.json` read it and generate `<description>` of `Mod/About/About.xml` from it (`sync-about-description.mjs` report they agree, checked 2026-10-01). Workflow (`.github/`) not edited by hand; change note's first line carry version (`[b]1.0.0[/b]`).