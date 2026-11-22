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
checked 2026-10-08 against `PUBLISHING.md`, « Images »: numbered `0-`, `1-`, `2-`… with single-digit prefixes, in page order, nothing else
in the folder; `0-` is a byte copy of `Mod/About/Preview.png` (compared after the 2026-10-08 regeneration); every other
image is a **staged photograph** of the shared Sanctuary location, not a test capture; each image under 2 MB, the folder
under 8 MB. `Art/Gallery/` holds only the ready-to-ship set (final names, subtitled),
a refused image is recomposed and replaced. The story, the set and the shot list are in `GALLERY.md`. State 2026-11-18: images 0 to 8, indexes contiguous, subtitled, accepted by the owner on 2026-11-15 and unchanged since; only `0-preview.png` was redone (1.7 badge, 2026-11-17).

## Dependencies and DLC

Hard: Harmony (`brrainz.harmony`, Workshop 2009463077) and Biotech (`Ludeon.RimWorld.Biotech`), both in `modDependencies`. Optional, never required: Chinese Comprehensive Expansion (`loadAfter`), A Dog Said... Animal Prosthetics 2 (`loadBefore`, patch), Nocturnal Animals (patch). Incompatible: the original mod (`incompatibleWith`). No other DLC. Read from `About.xml`, 2026-10-13, read again 2026-11-18 (1.2.0): `supportedVersions` now holds 1.6 and 1.7 (green 1.7 run, owner's word 2026-11-17), nothing else changed.

## Adult content boxes

None ticked. The mod holds no nudity, sexual content or gore beyond RimWorld's own combat. All nine gallery images (0 to 8) were opened on 2026-11-15 and show creatures, a rooster, colonists and a workshop only. Images 3 and 6 were taken again and opened on 2026-11-22 (a qiongqi, a hen and a colonist behind sandbags; a sexie, two colonists and an aura ring), same kind of content; the Preview (0) was re-rendered with the 1.7 badge and opened on 2026-11-17, same content.

## Gallery subtitles

One line of English at the bottom of each gallery scene without an interface window (owner rule of 2026-10-15, `GALLERY.md`, "Sous-titres"): `0-` (the Preview) has none, and this mod has no interface capture. The clean originals go to `Art/Gallery-clean/`; `Art/Gallery/` holds the subtitled images, set with `scripts/Add-Subtitle.ps1`. Rewritten 2026-11-15 for the eight scenes of the restaged story (`24-gallery.feature`): one day at Nelim's Sanctuary, Nelim the protagonist in every image, Blue the only guest (images 5 and 6). Burned on the eight images of `Art/Gallery/` (final names, below).

| Index | File | Line |
| --- | --- | --- |
| 1 | `1-dawn-crow.jpg` | At dawn, Nelim feeds the hens while the Pleiades star officer crows among the statues. |
| 2 | `2-four-beasts.jpg` | Four beasts out of the Classic of Mountains and Seas have come to the Sanctuary for the New Year. |
| 3 | `3-qiongqi.jpg` | The qiongqi has picked its prey, and Nelim braces behind the sandbags. |
| 4 | `4-nian-fire.jpg` | The nian beast breathes fire at a muffalo. Nelim holds the one thing it fears: a firecracker. |
| 5 | `5-wind-barrier.jpg` | Blue fires at the mingshe, and its wind barrier throws the shot back. |
| 6 | `6-sexie-aura.jpg` | The sexie's red aura drives Blue berserk, and Nelim keeps to the edge of the ring. |
| 7 | `7-extractor.jpg` | Three archite capsules wait at the extractor, and a hen minds the bench. |
| 8 | `8-tame-clones.jpg` | After the day, Nelim feeds the five tamed clones that came out of the extractor. |

## Steam description

```markdown
UNOFFICIAL. This mod is published without the original authors' explicit consent. If any original author contacts me to request its removal, I undertake to take it down promptly.

An update of andery233xj, Frolg, DongFang and Ninedaylongbow's [山海志怪-华夏凶兽和基因扩展 - Ancient Chinese Beast And Gene Expanded](https://steamcommunity.com/sharedfiles/filedetails/?id=3292446841) to the latest RimWorld version.

I am not the author of this mod. The creatures, the art, the mechanics and the original code are theirs; all I did was the work needed to make it run on the latest version, and a pass over the English text. Credit goes to them; mistakes in the update are mine. If the original authors come back to it, or ask me to take this down, I will.

Original mod: [Ancient Chinese Beast And Gene Expanded](https://steamcommunity.com/sharedfiles/filedetails/?id=3292446841)

## What it does

Four beasts out of the Classic of Mountains and Seas come to the rim, each one a raid of its own, and each one leaving genes behind that your colonists can extract and wear.

- The mingshe, a winged snake whose coming brings drought. It will not attack, but your crops wither while it lives. At range it screams; up close it bites; every so often it raises a wall of wind that throws back every shot fired from outside it and cuts anything caught inside.
- The qiongqi, one of the four fiends. Its eye reads an attack before it lands, so half of everything thrown at it misses. It picks out your shooters and flies at the furthest one, head first.
- The sexie, the heart-butchering scorpion, which arrives in human shape and does not attack - it only sends out a sound that drives your most psychically sensitive colonist berserk. Break that shape and the scorpion comes out of it, enraged, firing poisoned tail-needles that go through walls.
- The nian beast, the New Year monster. Armoured against everything but fire and noise: any weapon other than a firecracker does a tenth of its damage to it. It comes on the first day of the year.

And the Pleiades star officer, a divine rooster that wanders past the colony and crows at four in the morning. Its crow lifts the colony's spirits - and kills a sexie outright.

Kill a beast, keep its corpse, finish the research, and a gene extractor pulls twelve genes out of them: the mingshe's wind shield, sound wave and fangs; the qiongqi's flying strike, eye and claws; the sexie's crystal spurs, heart-butchering aura and monstrous strength; and the nian beast's fire breath, scales and horn. The same bench clones a tame beast of your own from a corpse.

Firecrackers are craftable, and are the answer to the nian beast. Two anti-beast rifles come with the mod.

A fifth storyteller, Sexie, is included: she likes to cause trouble at random, and sends a beast boss at you every fifteen days.

Requires Biotech. Requires Harmony.

Works with [A Dog Said... Animal Prosthetics 2](https://steamcommunity.com/sharedfiles/filedetails/?id=3238353862) (optional): the five tame clones can receive its prosthetics and bionics like a wolf or a thrumbo, and the Pleiades star officer like a duck. Nothing changes without it.

Loads after [Chinese Comprehensive Expansion](https://steamcommunity.com/sharedfiles/filedetails/?id=3221850511) (optional), by two of the same authors: no patch, only the load order, so the two sit together without a conflict.

Gene textures: the beast genes show wings, horns and other textures on a pawn. If you prefer a plain look, subscribe to [Remove Ancient Chinese Beast Gene textures](https://steamcommunity.com/sharedfiles/filedetails/?id=3293695725) by 逍逍客. It removes the textures of four genes (the mingshe's wind wing, the qiongqi's flying strike, the sexie's shoot and the year beast's horn) and keeps their abilities. Tested with this mod; the load order does not matter.

The beasts rest and breed like any animal: they lie down when tired, and a tame pair has offspring that grow up (the mingshe and the Pleiades star officer lay eggs). Clones saved before this version have no sex and stay sterile. With [Nocturnal Animals](https://steamcommunity.com/sharedfiles/filedetails/?id=2269731409) (optional) each beast keeps its own hours: the qiongqi and the sexie hunt by night.

Languages: English and French, and Simplified Chinese. French: proofread by a native speaker. Simplified Chinese: the authors' own text; what was added (the labels that used to be hard-coded) was completed with Claude (Anthropic) and reviewed by ChatGPT (OpenAI), and has not been checked by a native speaker.

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
SamBucher, for [A Dog Said... Animal Prosthetics 2](https://steamcommunity.com/sharedfiles/filedetails/?id=3238353862), and for explaining how to add a mod to it.
Mlie and XeoNovaDan, for [Nocturnal Animals](https://steamcommunity.com/sharedfiles/filedetails/?id=2269731409), whose body clocks this mod plugs into.
ninedaylongbow and Frolg, for [Chinese Comprehensive Expansion](https://steamcommunity.com/sharedfiles/filedetails/?id=3221850511), the optional companion this one loads after, and the Taoist hat Nelim wears in the gallery.
TangW and 逍逍客, for [RimImmortal-Living](https://steamcommunity.com/sharedfiles/filedetails/?id=3326145525), the robes and hats Nelim wears in the gallery.
逍逍客, for [Remove Ancient Chinese Beast Gene textures](https://steamcommunity.com/sharedfiles/filedetails/?id=3293695725), the optional patch that gives the genes a plain look.
Andreas Pardeike, for Harmony.

Tested with Pickle, RimLogging and Nelim's Pickle Tools, thanks to their authors: development only, never a dependency of this mod.

What is reused and how it differs is detailed in ATTRIBUTION.md (with the other mods the gallery shows), and LICENSE says what the MIT grant covers. The changelog and the list of defects inherited from the original are in the repository.

[Source code on GitHub](https://github.com/vbardales/Rimworld-Ancient-Chinese-Beast-And-Gene-Expanded-Renew)
```

## Change note

### 1.2.0

Steam change note of 1.2.0 (published 2026-11-18); its first line carries the version. Older notes (1.1.0, 1.0.0): `Docs/runs/2026-11-19-publication-sent.md`. The full list is `CHANGELOG.md`,
section `## [1.2.0]`.

```
[b]1.2.0[/b]
[list]
[*] Now runs on RimWorld 1.7 as well as 1.6, checked with the mod's own scenarios (beasts, genes, extractor, incidents, breeding); nothing in the content changed.
[*] New Preview image with the 1.7 badge.
[*] The credits now name the mods the gallery shows, starting with RimImmortal-Living, whose robes Nelim wears.
[/list]
[url=https://github.com/vbardales/Rimworld-Ancient-Chinese-Beast-And-Gene-Expanded-Renew/blob/main/CHANGELOG.md]Full changelog on GitHub[/url]
```

## Thank-you comments (1.2.0, posted 2026-11-18)

Register: `WORKSHOP_COMMENTS.md`. Comments on the original mod (3292446841) and on Chinese Comprehensive Expansion (3221850511) were posted on 2026-10-13, and the pages of Harmony, Pickle, RimLogging, A Dog Said... Animal Prosthetics 2 and Nocturnal Animals already hold a comment from another mod of the collection. For the gallery of 1.2.0 (owner rule 2026-11-18, every gallery mod is thanked), the pages of Roo's HD Hairstyles (3559870636), EyeGenes3 (3745223213) and Hat Hair Control (3760821540) are already `posted`: this mod only joins their `Covers`, no second message. Two pages have no comment yet and get one, posted by the owner after 1.2.0 is public. The pages were not read by a session (Steam bot protection): check each pseudo on the page and the mood of the last comments before posting.

RimImmortal-Living (3326145525, TangW and 逍逍客; the third author account is deleted on the page):

```
Nelim wears your robes and hats in every picture of the gallery of [url=https://steamcommunity.com/sharedfiles/filedetails/?id=3806709132]Ancient Chinese Beast And Gene Expanded Renew[/url], and the dragon robe holds its own next to a qiongqi xD Thank you @TangW(堂丸) and @逍逍客 for the mod :)
```

Tribal Tattoos (2782262247, Shenanigans):

```
Blue, the guest in two pictures of the gallery of [url=https://steamcommunity.com/sharedfiles/filedetails/?id=3806709132]Ancient Chinese Beast And Gene Expanded Renew[/url], wears the Sacred Water tattoo from your pack, and it still reads at gallery size. Thank you @Shenanigans :)
```

No Use This Instead comment for this mod (Mlie, 2026-11-18, on the page: a ` Renew` suffix is enough, AUDIT.md 13.b).
