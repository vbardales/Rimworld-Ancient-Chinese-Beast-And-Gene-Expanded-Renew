using System.Collections.Generic;
using Verse;

namespace AncientChineseBeast;

public class Gene_Hediffs : Gene
{
	public override void PostAdd()
	{
		base.PostAdd();
		foreach (HediffDefWithBodyPartDef hediff in def.GetModExtension<DefModExtension_GeneHediffs>().hediffs)
		{
			List<BodyPartRecord> allParts = pawn.RaceProps.body.AllParts;
			foreach (BodyPartRecord item in allParts)
			{
				if (hediff.bodyPart == item.def || item.groups.Contains(hediff.bodyPartGroup))
				{
					pawn.health.AddHediff(hediff.hediff, item);
				}
			}
		}
	}

	public override void PostRemove()
	{
		base.PostRemove();
		foreach (HediffDefWithBodyPartDef hediff in def.GetModExtension<DefModExtension_GeneHediffs>().hediffs)
		{
			Hediff firstHediffOfDef = pawn.health.hediffSet.GetFirstHediffOfDef(hediff.hediff);
			pawn.health.RemoveHediff(firstHediffOfDef);
		}
	}
}
