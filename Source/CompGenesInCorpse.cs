using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace AncientChineseBeast;

public class CompGenesInCorpse : ThingComp
{
	private CompProperties_GenesInCorpse Props => (CompProperties_GenesInCorpse)props;

	public override void PostDestroy(DestroyMode mode, Map previousMap)
	{
		if (mode == DestroyMode.KillFinalize)
		{
			if (!Singleton.instance.beastCorpses.ContainsKey(parent.def))
			{
				Singleton.instance.beastCorpses.Add(parent.def, new List<Corpse>());
			}
			Singleton.instance.beastCorpses[parent.def].Add((parent as Pawn).Corpse);
		}
	}

	public void ExtractAt(IntVec3 position, Map previousMap)
	{
		Genepack genepack = (Genepack)ThingMaker.MakeThing(ThingDefOf.Genepack);
		List<GeneDef> genes = new List<GeneDef> { Props.genes.RandomElement() };
		genepack.Initialize(genes);
		GenPlace.TryPlaceThing((Thing)genepack, position, previousMap, ThingPlaceMode.Near, (Action<Thing, int>)null, (Predicate<IntVec3>)null, default(Rot4));
		(parent as Pawn).Corpse.Destroy();
		Singleton.instance.beastCorpses.TryGetValue(parent.def, out var value);
		value.Remove((parent as Pawn).Corpse);
	}
}
