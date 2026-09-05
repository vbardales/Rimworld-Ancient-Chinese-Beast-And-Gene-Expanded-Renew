using System.Collections.Generic;
using System.Linq;
using RimWorld;
using Verse;
using Verse.Sound;

namespace AncientChineseBeast;

public class CompAbilityEffect_Crow : CompAbilityEffect
{
	private static List<Pawn> pawns = new List<Pawn>();

	public override bool AICanTargetNow(LocalTargetInfo target)
	{
		return true;
	}

	public override bool CanApplyOn(LocalTargetInfo target, LocalTargetInfo dest)
	{
		return true;
	}

	public override bool Valid(LocalTargetInfo target, bool throwMessages = false)
	{
		return true;
	}

	public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
	{
		Map map = parent.pawn.Map;
		SoundDef.Named("SZ_Crow").PlayOneShot(parent.pawn);
		foreach (Pawn allPawn in map.mapPawns.AllPawns)
		{
			if (allPawn.Faction != null && (allPawn.Faction.IsPlayer || allPawn.Faction.PlayerRelationKind == FactionRelationKind.Ally) && allPawn.needs != null && allPawn.needs.mood != null && allPawn.needs.mood.thoughts != null && allPawn.needs.mood.thoughts.memories != null)
			{
				allPawn.needs.mood.thoughts.memories.TryGainMemory(ThoughtDef.Named("SZ_ChickenCrow"));
			}
			if (allPawn.def.defName == "SZ_SeXie" || allPawn.def.defName == "SZ_SeXieInsect")
			{
				pawns.Add(allPawn);
			}
		}
		if (pawns.Count > 0)
		{
			Pawn pawn = pawns.Last();
			pawn.Kill(null, null);
			pawns.RemoveLast();
		}
	}
}
