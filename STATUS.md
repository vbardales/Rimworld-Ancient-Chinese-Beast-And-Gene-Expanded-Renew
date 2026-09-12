---
mod:          Ancient Chinese Beast And Gene Expanded Renew (unofficial)
packageId:    nelim.ancientchinesebeastandgeneexpandedrenew
repo:         Rimworld-Ancient-Chinese-Beast-And-Gene-Expanded-Renew
visibility:   public
detached:     yes
stage:        done
licence:      silent
licence_at:   reviewed 2026-09-12 - original files and About.xml, English and Chinese Workshop
            descriptions, all 68 public comments, and the four coauthors' Steam profiles;
            no explicit reuse permission or prohibition found, no source repository link found.
            Local MIT licence covers port additions only; abandonment is not established.
dependencies: declared
showcase:     complete
tested_on:
workshop:     not published
remaining:
  - unverified: never seen running; TESTING.md is the protocol, 28 scenarios, none run
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
  were reproduced before it was trusted. On 2026-09-12, 26 assembly checks passed against
  game assembly 1.6.9676.17735, including explicit presence checks for the three critical hooks.
- **The XML.** All six versioned checkers in `Tests/Xml/` pass: fields, classes, def references,
  third-party type references, translation keys and configuration consistency. There are also
  240 passing content checks and seven passing negative controls. Run `Tests/Run-All.ps1` to
  rebuild and repeat the checks; no scripts from the parent repository are needed.
- **The showcase.** `Mod/About/Preview.png` recomposed in HTML/CSS at 896x504 according to
  `../STYLE_RIMWORLD.md`; see the preview verification below. `ModIcon.png` remains 128x128.
- **The repository.** Detached from the monorepo, one remote, public, and directory, packageId
  and repository name all spell out the mod's displayed name.
- **The game.** Never launched. Every behaviour claimed in `README.md`, `ATTRIBUTION.md` and
  `TESTING.md` is read out of the code, not observed.

So `stage: done` means done as far as a person without the game running can take it. It does not
mean the mod works, and `tested_on` being empty is the honest half of that sentence.

## What would move it

### Preview verification — 2026-09-12

- Source: `Art/Preview.png`, copied without changes from the existing text-free
  `Art/Preview-untitled.png`. No illustration replacement; the existing originals remain
  archived under their existing names. `Art/Preview-unofficial-source.png` contains old text
  and is not the background of the new composition.
- Composition: `Art/preview.html`; settings: `Art/preview-layout.json`; sole palette reference:
  `Art/preview-palette.json`; renderer: `Art/render-preview.cjs`. `Art/PREVIEW.md` documents usage.
- Palette: veil sampled from shadowed earth. Vivid accent comes from the red firecrackers,
  with saturation increased, clearly distinct from the dominant ochre family shared by the
  soil and the beast's fur. That ochre family is lightened for the tag and title suffix.
  Strong title words, the connector and the summary share exactly the same primary ink.
- Font verified through Chrome's actual platform-font reporting after `document.fonts.ready`:
  Segoe UI Semibold for the title, Segoe UI Regular for tag/summary, Segoe UI Bold for the badge.
  No fallback. The title uses 46 px on two balanced lines. Direct spans reduce `And` and
  `Renew` to 29.9 px (65%), both still weight 600. `And` retains primary ink; `Renew` uses
  secondary ink. Exact name, case and order preserved; status tag remains on its own line.
- Version 1.6 is read from the delivered About.xml. Badge coordinates, rotation, text bounds
  and separation checked. Visual inspection passed at 896x504 and 268 px: no clipped text or
  overlap between text elements, title/version identifiable, reduced words readable, rule
  visible, vivid red accent distinct from the ochre secondary ink.
- Minimum measured contrast on the rendered background with text and shadows hidden:
  main title words/connector 6.41:1, title suffix 5.37:1, summary 6.60:1, tag 7.50:1,
  badge 5.03:1. Every pixel in the text regions was
  checked, beyond just their four corners. Report: `Art/preview-qa/report.json`; text-free
  background: `Art/preview-qa/background.png`; thumbnail: `Art/preview-qa/preview-268.png`.
- Delivered `Mod/About/Preview.png`: 612132 bytes, below 900 kB. Nothing published.

### In-game verification

`TESTING.md`, block by block. Three of its scenarios decide whether the port worked at all: the
sexie changing shape, the qiongqi landing its flight, and the mingshe's drought ending with the
beast. Those are the three hooks 1.6 silenced, and the three the port claims to have fixed.

The development-mode entries under **Ancient Chinese Beast** in the debug menu exist for that run:
a beast now, the nian beast within the hour, the sixty-day gate cleared, and the beast clock
printed to the log.

---

`stage` vocabulary: `port`, `showcase`, `preTest`, `done`, `tested`, `published`.
`licence` vocabulary: `open` an explicit licence or permission, `silent` no explicit licence,
reuse permission or prohibition found (does not establish abandonment),
`alive` no licence but a source explicitly recorded as maintained, `forbidden` a written refusal, `original` owing nothing
to anyone — not a name, not an idea traceable to one mod, not a value derived from its assets.
`remaining` in three kinds: `feature` for something missing from a first release, `defect` for a
known fault left unfixed, `unverified` for what could not be checked.

- **`dependencies`** — `declared` when every mod this one needs is named in the About's
  `modDependencies`, `to check` when a non-vanilla `loadAfter` suggests a dependency that is not
  declared, `none` when the mod needs nothing. An undeclared dependency is not cosmetic: on
  2026-09-11 Reequilibrage animaux took 47 vanilla animals down with it, Muffalo included, because
  the class it injects belongs to a mod that was not declared and not loaded.
