# Ancient Chinese Beast And Gene Expanded — what was taken, and what was changed

## Source

| | |
|---|---|
| Mod | 山海志怪-华夏凶兽和基因扩展 — Ancient Chinese Beast And Gene Expanded |
| Authors | andery233xj (data and mechanics), Frolg (art), 玖日长弓 / Ninedaylongbow (creature events, item text, announcement), 东方 / DongFang (sponsor) |
| Workshop | [3292446841](https://steamcommunity.com/sharedfiles/filedetails/?id=3292446841) |
| `packageId` | `andery233xj.AncientChineseBeast` |
| `supportedVersions` | 1.4, 1.5 |
| Licence | **none declared** — see `LICENSE` for what that means here |

### On the licence

Checked in the four places that decide it: **no `LICENSE` or `COPYING` file** anywhere in the
mod's 207 files, **no clause in the body of the `About.xml` description**, no repository linked
from it, and nothing on the Workshop page. The description is a changelog, a credits list and a
feature list; it says nothing about reuse either way.

That fourth check is there because of たたら製鉄, whose refusal of redistribution was buried in
the prose of its `About.xml` description and not in any file. This one has no such clause.

The source review recorded on 2026-09-12 found no explicit licence, reuse permission or
prohibition for the original material. This is the basis for the `silent` classification;
abandonment is not established. Silence is neither refusal nor permission.

This unofficial port is distributed without the original authors' explicit consent, with
credit, a link to the original, and removal on request. These commitments do not constitute
permission from the original authors. The MIT licence in `LICENSE` covers only the port
additions listed there, not the original material.

## What was taken

| | |
|---|---|
| All 88 textures | unchanged, except for the two noted under *Textures* below |
| The three sounds | unchanged |
| All 133 defs | unchanged in shape and numbers; the English text was rewritten |
| The Simplified Chinese translation | the authors' own, kept and extended; the last paragraph of the nian beast's description, which promised nian beast fangs on butchering that the mod never supplied, was removed on 2026-09-25 |
| The C# | decompiled from `1.5/Assemblies/AncientChineseBeast.dll` and recompiled against 1.6 |

The mod overwrites no vanilla def and ships no XML patch, so there was nothing to untangle on
that side.

## What 1.6 broke

Nine Harmony patch targets, checked one by one against 1.6's `Assembly-CSharp.dll` by reflection
**before** anything was compiled. All nine still exist with the same signature, and `Tests/` now
asserts it on every run:

| Target | |
|---|---|
| `Pawn.DrawAt` | postfix, draws the wind barrier and the berserk ring |
| `Verse.GenRecipe.MakeRecipeProducts` | postfix, turns an extraction recipe into a genepack, a clone recipe into a pawn |
| `TickManager.DoSingleTick` | prefix, ticks the mod's singleton |
| `Game.ExposeSmallComponents` | postfix, saves it |
| `BodyPartDef.GetMaxHealth` | postfix, the nian beast horn's extra head health |
| `HediffComp_GetsPermanent.set_IsPermanent` | prefix, the beasts take no permanent injuries |
| `Projectile.CanHit` | prefix, the qiongqi eye's dodge |
| `ThingWithComps.SpawnSetup` / `DeSpawn` | postfixes, the projectile list the wind shield reads |

The breakage was elsewhere. Five changes the compiler caught, and two it did not.

### The compiler caught these

- **`GenExplosion.DoExplosion`** gained two parameters in the middle of its list —
  `postExplosionGasRadiusOverride` and `postExplosionGasAmount` — so both all-positional calls
  landed two slots off from the fifteenth argument on. Rewritten with named arguments, which
  cannot slip again.
- **`PathFinder.FindPath` → `FindPathNow`**, and the type moved from `Verse.AI` to `Verse`.
  `PathFinderCostTuning` became a struct, and the tuning now comes before the end mode.
- **`JumpUtility.ValidJumpTarget(Map, IntVec3)` → `(Thing, Map, IntVec3)`**. The new first
  argument decides whether the cell is checked as walkable by that pawn or by anything at all;
  the caster is passed, which is what `PawnFlyer` itself checks later.
- **`RegionGrid.allRooms`** became a private field behind the `AllRooms` property.
- **`Entity.Tick()` became `protected`.** Four classes had it public.

### The compiler did not catch these

Both are the same shape: a base-class signature changed, so a method that was an override in 1.5
compiled cleanly in 1.6 as a *new* method that overrides nothing. Nothing fails at load; the code
simply never runs.

- **`PawnFlyer` moved its flight logic from `Tick()` to `TickInterval(int delta)`.**
  `PawnFlyingStrike` overrode `Tick()` and called `base.Tick()`, which in 1.6 reaches the empty
  `Entity.Tick()`. The qiongqi's flying strike would have hung in the air with nothing to advance
  it. `PawnFlyer` pins `UpdateRateTicks` to 1, so `delta` is always 1 and running the body twice
  per call still advances the flight two ticks per game tick, as in 1.5.
- **`ThingComp.PostDeSpawn(Map)` became `PostDeSpawn(Map, DestroyMode)`.** Two overrides went
  quiet:
  - `CompSeXieExpansion.PostDeSpawn` is the sexie's second phase. The human form would have died
    without ever becoming the scorpion — half the boss fight, gone with no error message.
  - `CompCausePermanentGameCondition.PostDeSpawn` ends the mingshe's drought. The condition would
    have outlived its causer with nothing left to end it.

  Found by decompiling the 1.5 assembly **twice**: once resolved against the 1.6 references, which
  is what produced the clean C# to build from, and once with no references at all, which is the
  only view that reports the original `override` keywords truthfully. Every method that lost
  `override` between the two is a silent break.

### Animal wildness

1.6 moved wildness out of `RaceProperties` and into a `Wildness` stat whose default is `-1`,
deliberately out of range "so we can catch missing wildness stats on animals". Seven defs still
used `<race><wildness>`; all seven were moved to `<statBases><Wildness>`. Left alone, every beast
would have tamed like a rat.

The parent def asked for `5`, far outside the stat's `0..1` range. Clamped to `1` the effect is
unchanged: the tame-chance curve reaches zero at `1`, so the beasts stay untameable, which is
what `5` meant.

Two of the seven were missed by `scripts/Fix-Wildness.ps1` and moved by hand: one because its
`<statBases>` line carries a trailing comment, the other because the def contains a nested
`<ThingDef>` inside `descriptionHyperlinks`, which breaks the script's non-greedy block match.

## What was changed in the text

The English was machine-translated from Chinese and had gone wrong in places. The creatures'
names are now their pinyin, which is how they are written in English about the *Classic of
Mountains and Seas*:

| was | is | |
|---|---|---|
| Ming Snake, Snake Snake, song snake, **Naruto** | mingshe | 鸣蛇 |
| **Pauper**, Ponzi | qiongqi | 穷奇 |
| **Sex evil**, color demon | sexie | 色邪 |
| YearBeast | nian beast | 年兽 |
| Pleiadian official | Pleiades star officer | 昴日星官 |
| Tomb (a body part) | pincer | 螯 |
| Inverted Horse Poison | horse-felling venom | 倒马毒 |
| Poison Taki Evil Fog-Sex Evil | Sexie, the Venomous Mist | 毒泷恶雾·色邪 |

Beyond the names, every label and description was rewritten, and content the Chinese carried but
the English had lost was put back: the tip that a Pleiades star officer makes a sexie easy, the
separate descriptions the five clone beasts have in Chinese (the English reused the hostile
beast's text verbatim, so a tame beast described itself as a raider), and the authors' own joke
at the end of the chicken's description.

**Labels that had never been translated at all** showed as Chinese in every language, because
they sat in the defs where no translation could reach them: 91 body-part `customLabel`s across
the four body defs, every melee tool on every beast, the firecracker's throw verb, and the flame
and firecracker projectiles. These now hold vanilla's English wording, and the authors' Chinese
was moved into `Languages/ChineseSimplified/DefInjected/`, where it belongs — including a
`BodyDef/` folder the original did not have. Nothing was lost on the Chinese side; 302 injection
keys resolve, checked with `scripts/Check-DefInjected.ps1`.

## Textures

Two were rescaled; the originals are kept under `Art/textures-original/`.

| | was | is | drawn at |
|---|---|---|---|
| `Storyteller.png` | 2192×2343, 5.6 MB | 1160×1240, 1.6 MB | 580×620 — `Storyteller.PortraitSizeLarge` |
| `BeastGeneExtractor.png` | 5334×5334, 1.5 MB | 1344×1344, 293 KB | 10.5 cells |

The mod went from 13 MB to 6 MB. Nothing else was touched.

## Defects that preceded the port

None of these are 1.6 regressions; they are in the 1.5 mod as shipped. Fixed where the fix was
unambiguous, listed here either way.

- **`CompCauseGameCondition_WithLetter.PostDestroy` threw every time it ran.** It read the private
  `condition` field off `CompCausePermanentGameCondition` — a different class in the same mod,
  which this comp does not derive from — so `FieldInfo.GetValue` raised `ArgumentException` and
  the message it exists to post never appeared. Nobody ever saw it, because **no def uses this
  comp**. Rewritten against its own base class's public `CausedConditions`.
- **`CompCausePermanentGameCondition.PostDeSpawn` could throw a null reference.** The condition is
  only created when the causer does not belong to the player, so a player-faction mingshe —
  from the clone recipe, or from dev mode — had none to end. Guarded.
- **The mingshe's sound wave described itself as a flamethrower.** `SZ_MingShe_SoundWave`'s
  description was a copy of `SZ_YearBeast_Flamethrower`'s, "Sprays flames in a fan-shaped area".
  Rewritten from the Chinese.
- **The monstrous strength hediff described the opposite of what it does.** `SZ_Strength` said it
  confused enemies and cut their combat ability; its one stage gives the *bearer* a
  `MeleeDamageFactor` of 2, and the Chinese agrees — 提高徒手搏斗能力, "improves unarmed fighting".
  Rewritten to match the code.
- **The Pleiades crow thought was never translated.** The Chinese keys addressed the thought's
  single stage as `stages.0`, and RimWorld resolves a stage by its label handle when it has one.
  Repointed at the real handle.
- **A research project that does not exist.** The Chinese translation carries a label and a
  description for `SZ_AntiChineseBeastWeapon`, "research how to make anti-beast weapons". No such
  def ships, and the two rifles have no recipe and no research gate — they are trade and reward
  items only. The two orphan keys were removed; the missing research was not invented.
- **A keyed string nothing uses.** `SZ_CannotReachBuildingToExtractGene`, in the English `Keyed`
  file, is referenced from neither the C# nor the defs. Left alone.
- **A cache that never caches.** `CompAbilityEffect_SectorCells.GetSectorCells` compares against a
  `radiusCache` it never assigns, and fills its result cache with `resultCache.AddRange(resultCache)`
  — the list added to itself. The cache branch is unreachable and the cache is always empty. It
  costs nothing and was left as it is.
- **Two of the three debug buttons did nothing.** `CompSZBeastDebug`, a comp on the firecracker,
  added 120 or 1 200 000 to `Singleton.nextBeastTimeHours`. That field is incremented every hour
  and reset to zero when a beast arrives, and **no code reads it**; whatever gate it once opened
  had gone by the version that shipped. Only the third button, the one that forces the nian beast,
  did anything, and all three required spawning a firecracker and selecting it to appear.

  Replaced rather than recorded, because the port needs them to be testable at all: the comp and
  its def entry are gone, and four `[DebugAction]` entries sit under **Ancient Chinese Beast** in
  the development menu instead. What the two dead buttons were reaching for turns out to be two
  separate levers, since `HourTick` gates a beast behind both a 1% daily roll and a sixty-day
  interval: one entry forces a beast now, another clears the interval and leaves the roll to do
  its work. A third keeps the nian beast button, and a fourth prints the clock to the log.

  `nextBeastTimeHours` itself is left in place. It is written on load and saved, so removing it
  would change the save format for a field that costs nothing.
- **The beast incidents threw when fired from the development menu.** Both workers read the chosen
  beast out of `Singleton.beast`, which only the mod's own clock ever sets. In play that is the
  only route, so it never showed; from the debug menu the field is null and the worker raised a
  null reference before spawning anything. Fixed with `Singleton.BeastFor`, which falls back to the
  incident def's own list. This one was worth fixing rather than recording: without it half of
  `TESTING.md` cannot be run at all.
- **The friendly beasts' English descriptions were the hostile ones, word for word.** Fixed, from
  the Chinese.

## What was checked, and what still has not been

The five XML checkers in `scripts/` were run over the published folder on 2026-09-11, each one
against the 1.6 assemblies by reflection. All five came back clean:

| | |
|---|---|
| `Check-XmlFields.ps1` | every element maps to a field on the 1.6 class — 52 files |
| `Check-XmlClasses.ps1` | all 83 types named from the XML resolve |
| `Check-DefRefs.ps1` | 108 defs, 7 abstract parents; every reference resolves, to the right def type |
| `Check-TypeRefs.ps1` | 49 references to types outside RimWorld, none of them to a third-party mod |
| `Check-DefInjected.ps1` | 302 translation keys, all of them landing on something |

The first of those runs found eleven problems that turned out to be the checker's, not the mod's:
it walked `DrawData.dataNorth` and its siblings as objects, where the field is a
`Nullable<RotationalData>` that `DirectXmlToObject` unwraps before it reads the node. The checker
now unwraps `Nullable<T>` and `SlateRef<T>` the same way, which also took vanilla's own count from
eighteen problems to none.

What none of this covers: **no person has played the mod in a game.** Most of what this file
describes is read out of the code. Since 2026-09-25 the Pickle suite (`Tests/Pickle/`) has played parts
of it in a real game: the gene recipes and the clones, the schedule, the incidents, the firecracker damage
and the compatibility with Animal Prosthetics 2. The sexie's second phase, the flyer's landing and the
crow are queued and not yet seen; `STATUS.md` says where each stands.

## Credits

The mod is andery233xj, Frolg, DongFang and Ninedaylongbow's work. This repository holds a 1.6
update of it and nothing more.

Thanks to Andreas Pardeike for Harmony, and to the ILSpy project, without which none of the C#
work would have been possible.

**A Dog Said... Animal Prosthetics 2** by SamBucher (Steam Workshop 3238353862) is an optional integration. Its
category lists (`ADS_Cat1` to `ADS_Cat3`), the way a mod is added to them and the names of its surgery recipes were
read in its own files to write `Mod/Patches/ADogSaidAnimalProsthetics2.xml`, which names this mod's races and copies
nothing of that mod. Thanks to SamBucher for the mod and for documenting the convention.

**[XND] Nocturnal Animals (Continued)** by Mlie, after XeoNovaDan's original (Steam Workshop 2269731409), is a second
optional integration. Its wiki (a DefModExtension `NocturnalAnimals.ExtendedRaceProperties` with one field, `bodyClock`) and its
installed files were read to write `Mod/Patches/NocturnalAnimals.xml`, which names this mod's races behind a guard on that
mod's name and copies nothing of it. Thanks to Mlie and XeoNovaDan.

**Pickle and RimLogging**, the test tools this update was checked with, are used in development only and are never a
dependency of the mod. Thanks to their authors.

The update was done with the help of an AI assistant (Claude, by Anthropic).
