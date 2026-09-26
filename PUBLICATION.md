# Publication

What the Steam Workshop page asks for and the repository holds nowhere else. Workshop item **3806709132**
(`Mod/About/PublishedFileId.txt` holds the id and must never be lost). Publications go through the CI
(see `Rimworld-Release-Admin/docs/OPERATIONS.md`); only Virginie approves the `steam-production` environment.

Status: this file is the **single source** of the description, written once in Markdown. The CI is not yet
set to read it (the workflow under `.github/` is not edited by hand): until the mod is moved to this source
with `generate-publish-workflow.sh ... --description-markdown PUBLICATION.md`, `Mod/About/About.xml` keeps its
hand-written BBCode description, and the two must be kept in step. Before the first publish that sends the
description, the dry-run must print a text that reads the same as the one it replaces.

## Steam description

```markdown
UNOFFICIAL. This mod is published without the original author's explicit consent. If the original author contacts me to request its removal, I undertake to take it down promptly.

Update of andery233xj, Frolg, DongFang and Ninedaylongbow's [山海志怪-华夏凶兽和基因扩展 - Ancient Chinese Beast And Gene Expanded](https://steamcommunity.com/sharedfiles/filedetails/?id=3292446841) to RimWorld 1.6.

I am not the author of this mod. The creatures, the art, the mechanics and the original code are theirs; all I did was the work needed to make it run on 1.6, and a pass over the English text. Credit goes to them; mistakes in the update are mine. If the original authors come back to it, or ask me to take this down, I will.

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

The beasts rest and breed like any animal: they lie down when tired, and a tame pair gives young that grow up (the mingshe and the Pleiades star officer lay eggs). Clones saved before this version have no sex and stay sterile. With [Nocturnal Animals](https://steamcommunity.com/sharedfiles/filedetails/?id=2269731409) (optional) each beast keeps its own hours: the qiongqi and the sexie hunt by night.

## What changed in the 1.6 update

The mod's own logic is unchanged. What broke was where 1.6 moved the ground under it:

- The tick refactor. RimWorld 1.6 split Thing.Tick() into Tick() and TickInterval(int delta), and PawnFlyer moved its flight logic into the latter. The qiongqi's flying strike would have hung in the air with nothing to advance it.
- ThingComp.PostDeSpawn gained a DestroyMode argument. Two overrides in the mod silently stopped overriding anything - and one of them is the sexie's second phase, so the human form would have died without ever becoming the scorpion.
- Animal wildness stopped being a field of RaceProperties and became a stat. Left as it was, every beast would have tamed like a rat.
- GenExplosion.DoExplosion, PathFinder.FindPath, JumpUtility.ValidJumpTarget and RegionGrid.allRooms all changed shape.

All nine Harmony patch targets were checked against the 1.6 assemblies before anything was compiled; all of them survived.

The English text has been rewritten. The original was machine-translated from Chinese and had gone wrong in places - the qiongqi was called "Pauper", the sexie "Sex evil", the mingshe's tooth "Naruto-tooth" - and a number of weapon and body-part labels had never been translated at all and showed as Chinese in an English game. The Simplified Chinese translation is the authors' own; it has been extended to cover the labels that used to be hard-coded, and the nian beast's description has lost its last paragraph, which promised nian beast fangs on butchering that the mod never supplied.

Safe to add to an ongoing save. Removing it mid-save removes the beasts, their genes and the storyteller.

Source, changelog and the list of defects inherited from the original: https://github.com/vbardales/Rimworld-Ancient-Chinese-Beast-And-Gene-Expanded-Renew

The update work was done with the help of an AI assistant (Claude, by Anthropic). Thanks to andery233xj, Frolg, DongFang and Ninedaylongbow for the mod; to SamBucher for [A Dog Said... Animal Prosthetics 2](https://steamcommunity.com/sharedfiles/filedetails/?id=3238353862) and for saying how a mod is added to it; to Mlie and XeoNovaDan for [Nocturnal Animals](https://steamcommunity.com/sharedfiles/filedetails/?id=2269731409); to Andreas Pardeike for Harmony; and to the authors of Pickle and RimLogging, the test tools this update was checked with (development only, never a dependency of the mod).

If I do not answer within a reasonable time after being contacted, anyone may freely update this or any other of my mods, including publishing a continuation of it. All credit must be preserved.

[Source code on GitHub](https://github.com/vbardales/Rimworld-Ancient-Chinese-Beast-And-Gene-Expanded-Renew)
```

## Change note

Steam change note of the next publish; its first line carries the version. The full list is `CHANGELOG.md`,
section `## [1.0.0]`.

```
[b]1.0.0[/b]
See the changelog on GitHub for the full list.
```
