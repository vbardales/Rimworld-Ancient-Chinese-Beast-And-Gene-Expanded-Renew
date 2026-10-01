# Backlog

Ideas for this mod that are not started. Each entry says what the mechanic would be, what already
covers part of it, and what has to be settled before the first line of code.

An idea earns a place here only if it serves what the mod already does. Anything already shipped is in
the changelog instead, and anything that needs watching in play is in `TESTING.md`.

Built on 2026-09-25 and moved to the changelog: **the beasts rest and breed**, and the optional **Nocturnal Animals**
body clocks (the first two entries of this file, decided by the owner the same day).

---

## Crossbreeding: a hybrid of a beast and an ordinary animal

Proposed 2026-09-25, and still open. The mod meant is taken to be **Better Crossbreeding** (DizzyEevee, Workshop
3520675842, `DizzyEevee.BetterCrossbreeding`), the only current 1.6 mod of that name; it is installed. It says on its own
page that it does nothing without a mod that depends on it. It extends the vanilla 1.6 mechanic
(`RaceProperties.canCrossBreedWith`) with a `DZY.Crossbreeding.Extension` on the mother's `PawnKindDef`, whose `outcomes` say,
per partner species, what the child is: maternal (vanilla), paternal, random, or another species drawn from a weighted list.

**What the mechanic would be.** A beast mating with an ordinary animal and giving a hybrid: the Pleiades star officer with a
hen, the tame qiongqi with a big cat, a tame nian beast with a muffalo; the child being a beast, an animal, or a third thing.

### What is already there, and what it blocks

The blocker of the first version is gone: since 2026-09-25 the beasts have two sexes, breed among themselves (see the
changelog) and the chicken and the mingshe lay eggs. What is left:

| Piece | What it gives | What it leaves |
| --- | --- | --- |
| Breeding among the same race | a mother and a father, a pregnancy or an egg, a baby in the player's faction | nothing that names another species: `canCrossBreedWith` is empty |
| `SZ_Chicken` lays its own eggs (`SZ_ChickenEggFertilized`) | a hen's fertilised egg hatches a Pleiades star officer | a vanilla rooster's fertilisation would hatch the mod's egg, not a hybrid |
| The extractor's clone recipes | the only way to a first tame beast | a hybrid line is a second way to a beast, and has to cost something |
| Genes (12) | the beasts' abilities are genes a colonist can wear | a hybrid child would need to say which genes, if any, it carries |

**To settle before the first line.**

- **Whether the vanilla field is enough.** `canCrossBreedWith` on a beast race and on the partner's race lets the game mate
  them and the child is the mother's race; Better Crossbreeding is only needed for another outcome (paternal, random, a third
  species). The first thing to try is the vanilla field alone.
- **Which pairs make sense.** The chicken with a vanilla hen, the qiongqi with a big cat: the only two with a plausible partner.
- **The guard.** Better Crossbreeding's extension class kills a def when its mod is missing, so its `outcomes` go behind the same
  kind of guard as the Nocturnal Animals patch (`PatchOperationFindMod` on the display name).
- **Cost.** A hybrid child should not undercut the bench: sterile, or weaker, or only the chicken.

## A pull request to the source repository of the original

Found 2026-10-01: **`MonsterTower/AncientChineseBeast`**, "山海志怪Mod 1.5版本源代码", public, one commit
(2025-09-10), no licence, forking allowed, issues open. It is the original's 1.5 source; whether its owner is one of the
four credited creators is not established (none of the four carries the account's name). `PUBLISHING.md` makes a pull
request to an origin repository systematic, independent of the Workshop publication, and keeps it here until it is
done. It is public, so **nothing is forked or proposed without Virginie's word**.

What a pull request would carry: the 1.6 changes (`PawnFlyer.TickInterval`, `PostDeSpawn(Map, DestroyMode)`, the
`Wildness` stat, the `GenExplosion.DoExplosion` and `PathFinder` calls, `RegionGrid.AllRooms`) and the fixes of
defects the original had (the comp that threw on every destroy, the null reference on a player-faction mingshe, the
beast incident that threw from the debug menu), each described in `ATTRIBUTION.md`. This port was decompiled from the
1.5 assembly, not built from that repository, so the two trees differ in layout (the repository keeps a `Harmony`
folder and the firecracker debug comp this port replaced; this port has `PatchMain.cs`, `DebugActions.cs`, one file
per patch): compare file by file before proposing anything, and keep the original's own layout in the proposal. The
Defs and textures live in the Workshop mod, not in that repository, so only the C# can be proposed there.

## Done: the description has one source

Decided by the CI session on 2026-09-25. `PUBLICATION.md` exists and holds the Steam description once, in a Markdown
block under `## Steam description`, its last line `[Source code on GitHub](URL)`; `.github/publish.config.json` reads
it and generates the `<description>` of `Mod/About/About.xml` from it (`sync-about-description.mjs` reports they
agree, checked 2026-10-01). The workflow (`.github/`) is not edited by hand; the change note's first line carries the
version (`[b]1.0.0[/b]`).
