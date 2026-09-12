---
mod:          Ancient Chinese Beast And Gene Expanded Renew
packageId:    nelim.ancientchinesebeastandgeneexpandedrenew
repo:         Rimworld-Ancient-Chinese-Beast-And-Gene-Expanded-Renew
visibility:   public
detached:     yes
stage:        done
licence:      silent
licence_at:   four places checked - no LICENSE file in the mod's 207 files, no clause in the About
            description, no repository linked from it, nothing on the Workshop page
dependencies: declared
showcase:     complete
tested_on:
workshop:     not published
remaining:
  - unverified: never seen running; TESTING.md is the protocol, sixteen scenarios, none run
  - defect: Singleton.nextBeastTimeHours is incremented, reset, and read by nothing. Inherited,
      deliberate, harmless now that no button depends on it
  - defect: CompAbilityEffect_SectorCells caches into a list it fills with itself, so the cache
      branch is unreachable. Inherited, deliberate, costs nothing
  - defect: the keyed string SZ_CannotReachBuildingToExtractGene is referenced from neither the
      C# nor the defs. Inherited, left alone
session:      c81f6605-4d8c-49a6-a097-494859f3e856
updated:      2026-09-12
---

# Ancient Chinese Beast And Gene Expanded Renew — status

Read by a sweep across every mod, rather than by asking each thread in turn. It lives at the
root, never inside `Mod/`, so Steam never receives it.

## Where this one stands

The port is finished and nothing about it is waiting on a decision. What it is waiting on is a
game.

- **The code.** Nine Harmony patch targets, all resolving against 1.6. `Tests/` asserts that on
  every run, along with the parameter binding and the overrides, and both of its failing states
  were reproduced before it was trusted. `dotnet run --project Tests`, 22 checks.
- **The XML.** All five checkers in the monorepo's `scripts/` come back clean: fields, classes,
  def references, third-party type references, translation keys.
- **The showcase.** `Preview.png` 896x504 with the title lettered into the dark corner,
  `ModIcon.png` 128x128, both re-encoded losslessly, both passing the 200 px and 32 px tests.
- **The repository.** Detached from the monorepo, one remote, public, and directory, packageId
  and repository name all spell out the mod's displayed name.
- **The game.** Never launched. Every behaviour claimed in `README.md`, `ATTRIBUTION.md` and
  `TESTING.md` is read out of the code, not observed.

So `stage: done` means done as far as a person without the game running can take it. It does not
mean the mod works, and `tested_on` being empty is the honest half of that sentence.

## What would move it

`TESTING.md`, block by block. Three of its scenarios decide whether the port worked at all: the
sexie changing shape, the qiongqi landing its flight, and the mingshe's drought ending with the
beast. Those are the three hooks 1.6 silenced, and the three the port claims to have fixed.

The development-mode entries under **Ancient Chinese Beast** in the debug menu exist for that run:
a beast now, the nian beast within the hour, the sixty-day gate cleared, and the beast clock
printed to the log.

---

`stage` vocabulary: `port`, `showcase`, `preTest`, `done`, `tested`, `published`.
`licence` vocabulary: `open` an explicit licence, `silent` no licence and a dead source,
`alive` no licence but a living source, `forbidden` a written refusal, `original` owing nothing
to anyone — not a name, not an idea traceable to one mod, not a value derived from its assets.
`remaining` in three kinds: `feature` for something missing from a first release, `defect` for a
known fault left unfixed, `unverified` for what could not be checked.

- **`dependencies`** — `declared` when every mod this one needs is named in the About's
  `modDependencies`, `to check` when a non-vanilla `loadAfter` suggests a dependency that is not
  declared, `none` when the mod needs nothing. An undeclared dependency is not cosmetic: on
  2026-09-11 Reequilibrage animaux took 47 vanilla animals down with it, Muffalo included, because
  the class it injects belongs to a mod that was not declared and not loaded.
