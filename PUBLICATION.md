# Publication

What the Steam Workshop page asks for and the repository holds nowhere else. Workshop item **3806709132**
(`Mod/About/PublishedFileId.txt` holds the id and must never be lost). Publications go through the CI
(see `Rimworld-Release-Admin/docs/OPERATIONS.md`); only Virginie approves the `steam-production` environment.

Status: this file is the **single source** of the description, written once in Markdown. The workflow under
`.github/` reads it (`.github/publish.config.json`: `description.file` `PUBLICATION.md`, `aboutFromDescription`), and
`Mod/About/About.xml`'s `<description>` is generated from it: `node .github/scripts/sync-about-description.mjs`
reports they agree (checked 2026-10-01). The 1.0.0 publish (2026-10-13) sent the description; the dry-run of any later publish that changes it must print
a text that reads the same as the one on the Workshop page it replaces.

**Publication mode: CI** (`PUBLISHING.md`, « Deux modes de publication »; checked 2026-10-08). The mod is
public, so it is the GitHub Actions workflow, not `publish-local.sh`: green dry-run of the exact commit, `publish` with the
40-character SHA, `steam-production` approved by Virginie alone, tag and release made by the CI. Published 2026-10-13 (run 38369937487);
the owner turned the item public by hand the same day.

## Gallery

The Workshop gallery is the owner's manual upload of `Art/Gallery/` (SteamCMD sends only the header image). Rules
checked 2026-10-08 against `PUBLISHING.md`, « Images »: numbered `0-`, `1-`, `2-`… on one digit, in page order, nothing else
in the folder; `0-` is a byte copy of `Mod/About/Preview.png` (compared after the 2026-10-08 regeneration); every other
image is a **staged photograph** of the shared Sanctuary location, not a test capture; each image under 2 MB, the folder
under 8 MB. Candidates are named `<n>-candidate-<name>.png` until the owner accepts them (then `candidate` is dropped),
a refused one is deleted. The story, the set and the shot list are in `GALLERY.md`. State 2026-10-13: images 0 to 7 accepted by the owner, indexes contiguous, 7.4 MB in all, each under 2 MB (table in `STATUS.md`).

## Dependencies and DLC

Hard: Harmony (`brrainz.harmony`, Workshop 2009463077) and Biotech (`Ludeon.RimWorld.Biotech`), both in `modDependencies`. Optional, never required: Chinese Comprehensive Expansion (`loadAfter`), A Dog Said... Animal Prosthetics 2 (`loadBefore`, patch), Nocturnal Animals (patch). Incompatible: the original mod (`incompatibleWith`). No other DLC. Read from `About.xml`, 2026-10-13.

## Adult content boxes

None ticked. The mod holds no nudity, sexual content or gore beyond RimWorld's own combat. All eight gallery images (0 to 7) were opened on 2026-10-13 and show creatures, a rooster, a colonist and a workshop only.

## Gallery subtitles

One line of English at the bottom of each gallery scene without an interface window (owner rule of 2026-10-15, `GALLERY.md`, "Sous-titres"): `0-` (the Preview) has none, and this mod has no interface capture. The clean originals go to `Art/Gallery-clean/` under the same names; `Art/Gallery/` holds the subtitled images, set with `scripts/Add-Subtitle.ps1`. Rewritten 2026-10-16 for the restaged story (`GALLERY.md`, "The story"; `24-gallery.feature`): one day at Nelim's Sanctuary, Nelim the protagonist in every image, Ren the only guest (images 5 and 6). The file names are those of the old series; each line is set on the matching new capture once the owner accepts it. Not set on the images yet.

| Index | File | Line |
| --- | --- | --- |
| 1 | `1-dawn-crow.png` | At dawn, Nelim stops among the statues: the Pleiades star officer is crowing. |
| 2 | `2-four-beasts.png` | Four beasts out of the Classic of Mountains and Seas have come to the Sanctuary for the New Year. |
| 3 | `3-qiongqi-far.png` | Behind Nelim, the qiongqi has picked out its prey, and she stands her ground. |
| 4 | `4-nian-fire.png` | The nian beast breathes fire at a muffalo. Nelim holds the one thing it fears: a firecracker. |
| 5 | `5-wind-barrier.png` | Ren fires at the mingshe, and its wind barrier throws the shot back. |
| 6 | `6-sexie-aura.png` | The sexie's red aura drives Ren berserk, and Nelim keeps to the edge of the ring. |
| 7 | `7-extractor.png` | At the extractor, three archite capsules wait for what the beasts leave behind, and a hen minds the bench. |

## Steam description

```markdown
UNOFFICIAL. This mod is published without the original author's explicit consent. If the original author contacts me to request its removal, I undertake to take it down promptly.

Update of andery233xj, Frolg, DongFang and Ninedaylongbow's [山海志怪-华夏凶兽和基因扩展 - Ancient Chinese Beast And Gene Expanded](https://steamcommunity.com/sharedfiles/filedetails/?id=3292446841) to the latest RimWorld version.

I am not the author of this mod. The creatures, the art, the mechanics and the original code are theirs; all I did was the work needed to make it run on the latest version, and a pass over the English text. Credit goes to them; mistakes in the update are mine. If the original authors come back to it, or ask me to take this down, I will.

Original mod: [Ancient Chinese Beast And Gene Expanded](https://steamcommunity.com/sharedfiles/filedetails/?id=3292446841)

## What it does

Four beasts out of the Classic of Mountains and Seas come to the rim, each one a raid of its own, and each one leaving genes behind that your colonists can extract and wear.

- The mingshe, a winged snake whose coming brings drought. It will not attack, but your crops wither while it lives. At range it screams; up close it bites; every so often it raises a wall of wind that throws back every shot fired from outside it and cuts anything caught inside.
- The qiongqi, one of the four fiends. Its eye reads an attack before it lands, so half of everything thrown at it misses. It picks out your shooters and flies at the furthest one, head first.
- The sexie, the heart-butchering scorpion, which arrives in human shape and does not attack - it only sends out a sound that drives your most psychically sensitive colonist berserk. Break that shape and the scorpion comes out of it, enraged, firing poisoned tail-needles that go through walls.
- The nian beast, the New Year monster. Armoured against everything but fire and noise: any weapon other than a firecracker does a tenth of its damage to it. It comes on the first day of the year.

And the Pleiades Star Officer, a divine rooster that wanders past the colony and crows at four in the morning. Its crow lifts the colony's spirits - and kills a sexie outright.

Kill a beast, keep its corpse, finish the research, and a gene extractor pulls twelve genes out of them: the mingshe's wind shield and sound wave, the qiongqi's flying strike and claws, the sexie's crystal spurs and berserk aura, the nian beast's fire breath, scales and horn. The same bench clones a tame beast of your own from a corpse.

Firecrackers are craftable, and are the answer to the nian beast. Two anti-beast rifles come with the mod.

A fifth storyteller, Sexie, is included: it likes to cause trouble at random, and sends a beast boss at you every fifteen days.

Requires Biotech. Requires Harmony.

Works with [A Dog Said... Animal Prosthetics 2](https://steamcommunity.com/sharedfiles/filedetails/?id=3238353862) (optional): the five tame clones can receive its prosthetics and bionics like a wolf or a thrumbo, and the Pleiades star officer like a duck. Nothing changes without it.

Loads after [Chinese Comprehensive Expansion](https://steamcommunity.com/sharedfiles/filedetails/?id=3221850511) (optional), by two of the same authors: no patch, only the load order, so the two sit together without a conflict.

The beasts rest and breed like any animal: they lie down when tired, and a tame pair has offspring that grow up (the mingshe and the Pleiades star officer lay eggs). Clones saved before this version have no sex and stay sterile. With [Nocturnal Animals](https://steamcommunity.com/sharedfiles/filedetails/?id=2269731409) (optional) each beast keeps its own hours: the qiongqi and the sexie hunt by night.

## What changed in the update

The mod's own logic is unchanged. What broke was where the new version moved the ground under it:

- The tick refactor. RimWorld split Thing.Tick() into Tick() and TickInterval(int delta), and PawnFlyer moved its flight logic into the latter. The qiongqi's flying strike would have hung in the air with nothing to advance it.
- ThingComp.PostDeSpawn gained a DestroyMode argument. Two overrides in the mod silently stopped overriding anything - and one of them is the sexie's second phase, so the human form would have died without ever becoming the scorpion.
- Animal wildness stopped being a field of RaceProperties and became a stat. Left as it was, every beast would have tamed like a rat.
- GenExplosion.DoExplosion, PathFinder.FindPath, JumpUtility.ValidJumpTarget and RegionGrid.allRooms all changed shape.

All nine Harmony patch targets were checked against the new game assemblies before anything was compiled; all of them survived.

The English text has been rewritten. The original was machine-translated from Chinese and had gone wrong in places - the qiongqi was called "Pauper", the sexie "Sex evil", the mingshe's tooth "Naruto-tooth" - and a number of weapon and body-part labels had never been translated at all and showed as Chinese in an English game. The Simplified Chinese translation is the authors' own; it has been extended to cover the labels that used to be hard-coded, and the nian beast's description has lost its last paragraph, which promised nian beast fangs on butchering that the mod never supplied.

Safe to add to an ongoing save. Removing it mid-save removes the beasts, their genes and the storyteller.

## IF I GO QUIET

If I do not answer within a reasonable time after being contacted, anyone may freely update this or any other of my mods, including publishing a continuation of it. All credit must be preserved.

## AI-GENERATED

The update to the latest RimWorld version, its tests and its documentation were written with Claude Code (Anthropic). The preview background and the icon are artwork generated with DALL-E (OpenAI), and the preview was lettered afterwards in HTML. Working with these tools is part of how I make mods.

## THANKS

andery233xj, Frolg, DongFang and Ninedaylongbow, for the mod: the beasts, the art, the mechanics and the original code are theirs.
SamBucher, for [A Dog Said... Animal Prosthetics 2](https://steamcommunity.com/sharedfiles/filedetails/?id=3238353862), and for saying how a mod is added to it.
Mlie and XeoNovaDan, for [Nocturnal Animals](https://steamcommunity.com/sharedfiles/filedetails/?id=2269731409), whose body clocks this mod plugs into.
ninedaylongbow and Frolg, for [Chinese Comprehensive Expansion](https://steamcommunity.com/sharedfiles/filedetails/?id=3221850511), the optional companion this one loads after.
Andreas Pardeike, for Harmony.

Tested with Pickle, RimLogging and Nelim's Pickle Tools, thanks to their authors: development only, never a dependency of this mod.

What is reused and how it differs is detailed in ATTRIBUTION.md, and LICENSE says what the MIT grant covers. The changelog and the list of defects inherited from the original are in the repository.

[Source code on GitHub](https://github.com/vbardales/Rimworld-Ancient-Chinese-Beast-And-Gene-Expanded-Renew)
```

## Change note

### 1.1.0

Steam change note of the next publish; its first line carries the version. The full list is `CHANGELOG.md`,
section `## [1.1.0]` (still `## [Unreleased]` until the publish). 1.0.0 went out on 2026-10-13 with `[b]1.0.0[/b]`.

```
[b]1.1.0[/b]
See the changelog on GitHub for the full list.
```

## Thank-you comment (not posted)

Register: `WORKSHOP_COMMENTS.md`, row 3292446841 (the original mod). Post only after item 3806709132 is public,
by the owner, on the original page. It is also the way the original authors can reach her to ask for a takedown.
The pages of Harmony, Pickle, RimLogging, A Dog Said... Animal Prosthetics 2 and Nocturnal Animals already have
their comment (or a draft) from another mod of the collection: only `Covers` was extended, nothing more to post.

```
Wanted to see the mingshe's wind wall on a 1.6 colony, so here's an unofficial update: [url=https://steamcommunity.com/sharedfiles/filedetails/?id=3806709132]Ancient Chinese Beast And Gene Expanded Renew[/url]. The beasts are all yours, I only moved it over. Thank you for them :) If you'd rather it came down, just tell me here or on the page.
```

One more recipient: Chinese Comprehensive Expansion (3221850511, by ninedaylongbow and Frolg), the optional `loadAfter` mod exercised by pass 3. Register row drafted 2026-10-13. Post after item 3806709132 is public, by the owner, on that page:

```
I had your Chinese Comprehensive Expansion load beside an unofficial 1.6 update of Ancient Chinese Beast And Gene Expanded to check that the two get along, and they do: [url=https://steamcommunity.com/sharedfiles/filedetails/?id=3806709132]Ancient Chinese Beast And Gene Expanded Renew[/url] simply loads after yours. Thank you for the expansion :)
```

## Use This Instead comment (not posted)

Register: `USE_THIS_INSTEAD.md`, row 3292446841. Post only after item 3806709132 is public, by the owner, on the [Use This Instead](https://steamcommunity.com/sharedfiles/filedetails/?id=3396308787) page.

```
A replacement for [url=https://steamcommunity.com/sharedfiles/filedetails/?id=3292446841]山海志怪-华夏凶兽和基因扩展 Ancient Chinese Beast And Gene Expanded[/url] (andery233xj, Frolg, DongFang, Ninedaylongbow; packageId andery233xj.AncientChineseBeast; RimWorld 1.4 and 1.5): [url=https://steamcommunity.com/sharedfiles/filedetails/?id=3806709132]Ancient Chinese Beast And Gene Expanded Renew (unofficial)[/url], packageId nelim.ancientchinesebeastandgeneexpanded, for the latest RimWorld version. It is declared incompatible with the original. Thank you for keeping this list :)
```
