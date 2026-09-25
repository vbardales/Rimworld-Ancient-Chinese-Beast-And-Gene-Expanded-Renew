# Backlog

Ideas for this mod that are not started. Each entry says what the mechanic would be, what already
covers part of it, and what has to be settled before the first line of code.

An idea earns a place here only if it serves what the mod already does. Anything already shipped is in
the changelog instead, and anything that needs watching in play is in `TESTING.md`.

---

## Nocturnal Animals: a body clock for the beasts

Proposed 2026-09-25, on the owner's question whether the mod could handle it too. Read in the installed mod
(`[XND] Nocturnal Animals (Continued)`, Mlie, Workshop 2269731409, `Mlie.XNDNocturnalAnimals`) and in its wiki, not assumed.

**What it is.** A DefModExtension, `NocturnalAnimals.ExtendedRaceProperties`, with one field, `bodyClock`:
`Diurnal` (sleeps 22:00 to 06:00, the vanilla behaviour and the default of every animal nobody patched),
`Nocturnal` (sleeps 11:00 to 19:00), `Crepuscular` (sleeps 22:00 to 02:00 and 11:00 to 15:00) and, added by the
continuation, `Cathemeral`. The clock is also written on the animal's info card. Adding it to a race is four lines of patch.

**What the mechanic would be.** The beasts follow a rhythm that suits them: the sexie, a scorpion, and the qiongqi
would be nocturnal; the Pleiades star officer, a rooster that crows at four, would be crepuscular or diurnal. What changes for
a pawn is when the tame ones are up, and, for the hostile ones, when they are on the map awake.

### What is already there, and what it blocks

| Piece | What it gives | What it leaves |
| --- | --- | --- |
| `SZBeastParent` sets `<needsRest>false</needsRest>` | the beasts never tire and never sleep | **a body clock decides when a pawn sleeps, and these pawns never do**: the extension would be inert and would only print a rhythm on the info card that nothing follows |
| Think trees: the hostile beasts have their own (`SZ_AIYearBeast`, and one for each of the others); the friendly clones use the vanilla `Animal` tree (`thinkTreeMain Animal`, read in `Pawn/Friendly/Year.xml`) | the clones already sit on the tree that puts an animal to rest when it has the need | for the clones a rest need would be enough; for the hostile beasts none of the custom trees asks the pawn to rest, so a rest need alone would not make one lie down |
| Friendly clones are combat companions | a colony's beast that fights for it | a companion that sleeps half the day is a worse companion; the owner may not want that |
| Nocturnal Animals lists every animal in its own settings | the player can already set a clock per race, ours included | so the patch is a default, not a capability |

**To settle before the first line.**

- **Whether the beasts should sleep at all.** Without it the whole entry is cosmetic. With it (a rest need, a think node that
  rests) it is a gameplay change to the raid beasts as well as to the clones, and it needs its own tests.
- **Which races.** Only the five clones and the chicken (the ones a colony can own), or the hostile four too. A sleeping
  hostile beast that arrives by an incident is a different balance from one that is always up.
- **The guard.** A `NocturnalAnimals.ExtendedRaceProperties` class that is not loaded kills the def that carries it, so the
  patch needs a real mod guard: `PatchOperationFindMod` compares the mod's *display name*, and the wiki's template still uses
  the old name, `[XND] Nocturnal Animals`, while the installed one is `[XND] Nocturnal Animals (Continued)`; a `LoadFolders.xml`
  with `IfModActive="Mlie.XNDNocturnalAnimals"` would not depend on a name. This mod has no `LoadFolders.xml` today.
- **`loadBefore` or `loadAfter`.** Nothing to decide until the extension is written; NA reads the extension at load.

---

## Crossbreeding: a hybrid of a beast and an ordinary animal

Proposed 2026-09-25, same question. The mod meant is taken to be **Better Crossbreeding** (DizzyEevee, Workshop
3520675842, `DizzyEevee.BetterCrossbreeding`), the only current 1.6 mod of that name; it is installed. It says on its own page that it
does nothing without a mod that depends on it. It extends the vanilla 1.6 mechanic (`RaceProperties.canCrossBreedWith`) with a
`DZY.Crossbreeding.Extension` on the mother's `PawnKindDef` whose `outcomes` say, per partner species, what the child is:
maternal (vanilla), paternal, random, or another species drawn from a weighted list.

**What the mechanic would be.** A beast mating with an ordinary animal and giving a hybrid: the Pleiades star officer with
a hen, or a tame nian beast with a muffalo, the child being a beast, an animal, or a third thing of the mod's own.

### What is already there, and what it blocks

| Piece | What it gives | What it leaves |
| --- | --- | --- |
| `SZBeastParent` sets `<hasGenders>false</hasGenders>` | one sex, no mother and no father to tell apart | **breeding needs two sexes, and the beasts have none**: `canCrossBreedWith` and the extension would never be consulted |
| Clone and gene recipes (`SZ_Clone_*`, `SZ_ExtractGene_*`) | the only way to get a tame beast, at a bench, from a corpse | a breeding line would be a second, free way to the same result, undoing the cost the bench sets |
| `Wildness` 0 on the clones and `mateMtbHours` unset | tame, docile animals | no mating rate, no litter, no gestation: all of it to design |
| Genes (12) | the beasts' abilities are genes a colonist can wear | a hybrid child of a beast would need to say which genes, if any, it carries |

**To settle before the first line.**

- **Whether a beast may breed.** That is the whole idea; the recipes' cost is what it would compete with. A hybrid that is sterile
  or that only the rooster can give (a hen's eggs, a fertilised egg) keeps the bench the only source of the four big beasts.
- **The chicken first.** It is the one small, plausible candidate: a rooster is a natural father and eggs already exist in vanilla.
  It needs a sex (`hasGenders`), an egg layer or a fertilised egg, and a hatcher, on a race that today is a single genderless bird.
- **Where the hybrid is defined.** Better Crossbreeding must stay optional: `outcomes` are read from a mod extension, so the
  same guard problem as above applies to `DZY.Crossbreeding.Extension`.
- **Vanilla 1.6 crossbreeding without the mod** already lets a race name partners in `canCrossBreedWith`; whether the
  idea needs the other mod at all, or only the vanilla field, is the first thing to check.
