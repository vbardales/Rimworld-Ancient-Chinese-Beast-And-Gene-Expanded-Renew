# Ancient Chinese Beast And Gene Expanded Renew

A RimWorld 1.6 port of **山海志怪-华夏凶兽和基因扩展 — Ancient Chinese Beast And Gene Expanded**
by **andery233xj, Frolg, DongFang and Ninedaylongbow** — Steam Workshop
[3292446841](https://steamcommunity.com/sharedfiles/filedetails/?id=3292446841), last supporting
1.5.

Four beasts out of the *Classic of Mountains and Seas*, each one a raid of its own, each one
leaving genes behind that your colonists can wear. Plus a divine rooster, a storyteller, two
rifles and a great many firecrackers.

See [ATTRIBUTION.md](ATTRIBUTION.md) for why this port exists and on what terms.

Requires **Biotech** and **Harmony**.

---

## The beasts

| | | arrives |
|---|---|---|
| **mingshe** 鸣蛇 | a winged snake whose coming brings drought | walks in from a map edge |
| **qiongqi** 穷奇 | one of the four fiends; its eye reads an attack before it lands | walks in from a map edge |
| **sexie** 色邪 | the heart-butchering scorpion, in two shapes | digs up through the floor of your richest room |
| **nian beast** 年兽 | the New Year monster, armoured against everything but noise | walks in, on the first day of the year |

Each one fights differently, and none of them fights like a vanilla animal.

**The mingshe** will not attack. It brings a permanent drought instead: full sun, no rain, and
every plant on the map taking rot damage every in-game hour until it is dead. Anima trees,
Gauranlen trees and polux trees are spared. At range it screams a cone of sound that dazes; up
close it bites with venom. Every so often it raises a wind shield — a ten-tile ring that cuts
anything inside it and throws every shot fired from outside straight back at whoever fired it.

**The qiongqi** dodges half of everything, hunts the furthest shooter it can see rather than the
nearest target, and closes by flying: it spawns a dash animation, leaves the ground, and lands
cutting everything within four tiles. It aims for the head.

**The sexie** arrives as a person. That shape does not attack; it stands there and, every so
often, sends out an aura that drives every psychically sensitive colonist within eleven tiles
berserk against their own friends. Kill that shape and the scorpion crawls out of it — a second,
angrier pawn that fires venomous tail-needles through walls and pincers anything that closes.

**The nian beast** takes a tenth of the damage from anything that is not a firecracker, and a
thousandfold multiplier from anything that is — the two together mean firecrackers are the only
weapon that meaningfully hurts it. It breathes a cone of fire that spawns a wave of small flame
projectiles. Butcher it for nian beast fangs.

Each of the four also exists as a tame version, cloned at the extractor — same abilities, on your
side, with an AI that will use its ranged ability while it fights in melee.

## The chicken

The **Pleiades star officer** 昴日星官 wanders past the colony now and then and can be tamed. It
crows at four every morning, and the crow can be triggered by hand. Every colonist and ally on
the map gets a +20 mood thought for a day.

Each crow also kills one sexie on the map outright. That is not a metaphor.

## The genes

Kill a beast, keep the corpse, research **beast gene extraction** — 1000 points, Spacer,
hi-tech bench plus multi-analyzer, after Archogenetics — and the **beast gene extractor** will
pull one of twelve genes out of a corpse as a genepack:

| beast | genes |
|---|---|
| mingshe | wind shield, sound wave, fangs |
| qiongqi | flying strike, eye (50% dodge), claws |
| sexie | crystal spurs, heart-butchering aura, monstrous strength |
| nian beast | fire breath, scales, horn |

The same bench clones a tame beast from a corpse, and renders any beast corpse into ten archite
capsules.

## Firecrackers

Twenty wood at a crafting spot or a smithy. A thrown grenade with a smaller radius that chains:
each blast has a one-in-ten chance per cell of dropping a smaller firecracker, which does the
same again one step down. Three levels, then it stops. The nian beast is terrified of them.

## The storyteller

**Sexie, the Venomous Mist** is a fifth storyteller. She favours misc incidents and faction
arrivals over big threats, and on top of her own schedule she sends a beast at you every fifteen
days regardless.

Under any other storyteller the beasts still come, but rarely: one roll a day at 1%, and never
within sixty days of the last one — so the first is unlikely before day 160 or so. (The beasts'
own descriptions say "a year after the colony is established". That is the authors' flavour
text, not the schedule the code runs.)

The nian beast is the exception. It comes on the first hour of the first day of the year,
whatever the storyteller, and it does not roll for it.

---

## Building

```bash
cd Source
dotnet build
```

`Krafs.Rimworld.Ref` supplies the 1.6 reference assemblies from NuGet, so no RimWorld install is
needed to compile. The output lands in `Mod/Assemblies/`; build intermediates are kept out of the
published folder by `Source/Directory.Build.props`.

## Testing

```bash
dotnet run --project Tests
```

This one does need RimWorld installed, since it reads the game's own assembly. Pass the path to
`RimWorldWin64_Data/Managed` as an argument if the game is not in the default Steam location.

It checks the three things that broke when this mod met 1.6, none of which the compiler catches:

- every Harmony target still resolves to a real method, with the signature the patch declares
- every patch method's parameters still bind, since Harmony matches them **by name** against the
  target's own parameters, and a rename upstream is not a compile error
- no method that shares a name with a virtual one has quietly stopped overriding it, which is what
  happened to the flyer's `Tick` and to two `PostDeSpawn` hooks

It runs no game code and starts no game. A clean run says the mod's attachment points are where
it thinks they are, not that the mod works.

## Layout

```
AncientChineseBeastAndGeneExpandedRenew/
  Mod/     the published folder - this is what the Workshop uploader sends
  Source/  C#, never published
  Tests/   reflection checks against the installed game, never published
  Art/     uncropped showcase art, the two oversized textures, and the script that letters the preview
  .build/  compiler intermediates, git-ignored, deliberately outside Mod/
```

## Compatibility

Safe to add to an ongoing save. Removing it mid-save removes the beasts, their genes, the
storyteller and the extractor.

Incompatible with the original mod (`andery233xj.AncientChineseBeast`), which defines the same
defs; run one or the other.
