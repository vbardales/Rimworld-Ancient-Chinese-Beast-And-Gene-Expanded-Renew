# Backlog

Ideas for this mod that are not started. Each entry says what the mechanic would be, what already
covers part of it, and what has to be settled before the first line of code.

An idea earns a place here only if it serves what the mod already does. Anything already shipped is in
the changelog instead, and anything that needs watching in play is in `TESTING.md`.

---

## Decided 2026-09-25: the beasts sleep and breed. Proposal, awaiting the owner's go

The owner's answer to the two entries below: yes to both. This is the proposal that follows from what was read in the
game (the vanilla animal think tree pulls in `SatisfyBasicNeeds`, which holds `JobGiver_GetRest`, and has a mating node; a
saved pawn whose race gains sexes keeps `Gender.None`, since `Pawn` fixes nothing up on load).

**Scope: the six races a colony can own** (the five clones and the Pleiades star officer). The four hostile beasts are
raid pawns and stay as they are: they never rest, and they never breed.

**Sleep: small.**

- `needsRest` back to true on the six, **set on each one, not on `SZBeastParent`**, which the hostile four inherit. The clones
  are already on the vanilla `Animal` tree, so they lie down with no other change.
- Rhythms, through Nocturnal Animals **when it is there** (a folder loaded only if `Mlie.XNDNocturnalAnimals` is active, since
  the extension class kills a def when its mod is missing): qiongqi and sexie (both forms) nocturnal, mingshe and nian beast
  crepuscular, the Pleiades star officer **crepuscular**, because it crows at 04:00 and the vanilla clock (asleep 22:00 to
  06:00) would have it asleep at that hour. Without Nocturnal Animals they simply follow the vanilla clock.
- To settle in the code: whether the 04:00 crow (`CompChickenAIExpansion`) still fires from a sleeping bird. A scenario
  will say.

**Breeding: medium.**

- **Who.** Nian beast, qiongqi, mingshe and the chicken get two sexes (`hasGenders`). **Not the sexie**: its human form dies
  into a scorpion, which no litter can carry, so both forms stay genderless and sterile.
- **How.** Breeding among the same race only; one young per litter; a long gestation and a slow `mateMtbHours`, so a line
  takes seasons while the bench still gives a beast today. The clone recipe already draws a sex at random, so a colony
  clones twice to get a pair. The young are the same beast in the same colony faction.
- **Life stages.** Today the race has one stage, adult from age 0, so a newborn would be born full size. Three stages, baby,
  juvenile and adult, on **the same textures at a smaller `drawSize`** (no new art), with smaller body size and health.
- **The mingshe lays an egg** (fertilised egg and a hatcher) instead of giving birth, being a snake. A later step.
- **Saved clones stay genderless and sterile**, since nothing gives them a sex; only clones made after the change can breed.
  That is stated in the changelog rather than fixed.
- **Crossbreeding with Better Crossbreeding**, a later and optional step behind its own guard: only the chicken and the
  qiongqi have a plausible partner (a hen; a big cat). Not part of the first version.

**Tests.** Offline: the six races have the two fields and the hostile four do not; life stages ascend; the sexie has no
sexes. Pickle: a rest window per rhythm, a forced pregnancy that gives a young of the right kind, faction and life stage, the
crow at 04:00 with a bird that sleeps. **Risk:** balance, and the extra think-tree work for anything that has to wake a
sleeping companion when it is attacked (vanilla animals do wake).

**Order.** Sleep first, alone and small. Breeding second, the nian beast and the qiongqi before the chicken and the mingshe.
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
