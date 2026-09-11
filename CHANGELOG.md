# Changelog

All notable changes to this port are recorded here.
The format follows [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).

## [1.0.0] — 2026-09-11

First release. Not yet on the Steam Workshop: this tags the source, and the Workshop item follows
once the mod has been tried in a running game.

Ported from andery233xj, Frolg, DongFang and Ninedaylongbow's
**山海志怪-华夏凶兽和基因扩展 — Ancient Chinese Beast And Gene Expanded**, Workshop
[3292446841](https://steamcommunity.com/sharedfiles/filedetails/?id=3292446841), last supporting
1.5. `ATTRIBUTION.md` records the whole of it; this is the summary.

### Changed — to run on 1.6

- **The qiongqi's flying strike flies again.** 1.6 moved `PawnFlyer`'s flight logic from `Tick()`
  to `TickInterval(int delta)`. The mod's flyer overrode `Tick()`, which in 1.6 overrides nothing
  and reaches an empty base — the flyer would have hung in the air over its target. It now
  overrides `TickInterval` and advances two ticks per game tick, as before.
- **The sexie changes shape again.** `ThingComp.PostDeSpawn` gained a `DestroyMode`, so the hook
  that turns the broken human form into the scorpion quietly stopped overriding anything. The
  same change had silenced the hook that ends the mingshe's drought when its causer dies.
- **The beasts are untameable again.** 1.6 turned animal wildness from a field of
  `RaceProperties` into a stat, defaulting to an out-of-range `-1`. All seven defs were moved to
  `<statBases><Wildness>`.
- **Explosions carry the right arguments.** `GenExplosion.DoExplosion` gained two parameters in
  the middle of its list; both call sites were rewritten with named arguments.
- `PathFinder.FindPath` became `Verse.PathFinder.FindPathNow` with a reordered signature,
  `JumpUtility.ValidJumpTarget` gained a leading `Thing`, `RegionGrid.allRooms` became the
  `AllRooms` property, and `Entity.Tick()` became `protected`. All followed.
- Every one of the nine Harmony patch targets was verified against the 1.6 assemblies by
  reflection before anything was compiled. All nine survived unchanged.

### Added — a test suite and a test protocol

- `TESTING.md` is sixteen manual scenarios, ordered so each leaves the save in the state the next
  one needs, covering the four beasts, the chicken, the twelve genes, the bench, the schedule and
  the save. Every expected result in it is read out of the code, never observed. It exists because
  nothing else in this repository can say whether the mod works.
- **The beast incidents can now be fired from the development menu.** Both workers read the chosen
  beast out of a field only the mod's own clock sets, so firing them by hand raised a null
  reference before anything spawned. `Singleton.BeastFor` falls back to the incident def's own
  list.


- `Tests/` checks the mod against the RimWorld assemblies it will be loaded beside: that every
  Harmony target still resolves, that every patch method's parameters still bind by name, and that
  no method that shares a name with a virtual one has quietly stopped overriding it. Those are the
  three ways this port broke, and none of them is a compile error. `dotnet run --project Tests`,
  22 checks, no game needed and none launched.

### Changed — English text

- **The beasts have their names.** The original English was machine-translated: the qiongqi was
  "Pauper", the sexie "Sex evil", and the mingshe was called "Ming Snake", "Snake Snake", "song
  snake" and — in one recipe — "Naruto". They are now mingshe, qiongqi, sexie, nian beast and
  Pleiades star officer.
- Every label and description was rewritten. Content the Chinese carried and the English had lost
  is back: the tip about the Pleiades star officer, the five clone beasts' own descriptions (the
  English reused the hostile beast's, so a tame beast described itself as a raider), and the
  authors' joke at the end of the chicken's description.
- **Labels that were Chinese in every language are now translatable.** 91 body-part names, every
  beast's melee tools, the firecracker's throw verb and the flame projectiles sat in the defs in
  Chinese, where no translation could reach them. They now hold vanilla's English wording, and
  the authors' Chinese moved into `Languages/ChineseSimplified/DefInjected/` — including a
  `BodyDef/` folder the original did not have.

### Fixed — defects present in the original

- **A comp that threw on every destroy.** `CompCauseGameCondition_WithLetter` read a private
  field off a class it does not derive from, so its `PostDestroy` raised `ArgumentException` and
  its message never appeared. No def uses the comp, which is why it went unnoticed.
- **A null reference on a player-faction mingshe.** The permanent-drought comp only creates its
  condition for non-player beasts, then ended it unconditionally on despawn.
- **The mingshe's sound wave described itself as a flamethrower** — its description was a copy of
  the nian beast's.
- **The monstrous strength hediff described the opposite of what it does.** It claimed to weaken
  enemies; it doubles the bearer's unarmed melee damage, which is what the Chinese says.
- **The Pleiades crow thought is translated again.** Its Chinese keys addressed the stage by
  index where RimWorld resolves it by label handle.
- Two Chinese translation keys pointing at a research project that does not ship were removed.

### Changed — packaging

- `Storyteller.png` went from 2192×2343 and 5.6 MB to 1160×1240, twice the 580×620 the game draws
  it at; `BeastGeneExtractor.png` from 5334×5334 to 1344×1344. The mod is 6 MB instead of 13 MB.
  Both originals are kept under `Art/textures-original/`.
- `Preview.png` carries the mod's name. The crop had been chosen with the upper-left third left
  dark and empty for exactly that, and it had stayed empty. The untitled crop is kept as
  `Art/Preview-untitled.png` and the script that letters it as `Art/title.ps1`, so the wording can
  be redone without regenerating the image.
- The two showcase images were re-encoded, losslessly: `Preview.png` from 840 KB to 590 KB and
  `ModIcon.png` from 29 KB to 26 KB, both pixel for pixel what they were. Neither needed the alpha
  channel it carried, and both had been written with a fixed row filter where PNG allows one per
  row.
- Harmony is declared as a dependency, as it already was upstream, alongside Biotech.
- Single-version layout: the 1.4 and 1.5 folders and `LoadFolders.xml` are gone.
