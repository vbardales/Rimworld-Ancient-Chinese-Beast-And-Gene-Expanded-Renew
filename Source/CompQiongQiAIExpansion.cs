using RimWorld;
using Verse;
using Verse.AI;

namespace AncientChineseBeast;

public class CompQiongQiAIExpansion : ThingComp
{
	private Ability ability;

	public override void CompTick()
	{
		if (!parent.Spawned || parent.Faction == Faction.OfPlayer || Find.TickManager.TicksGame % 60 != 0 || !(ability ?? (ability = (parent as Pawn).abilities.GetAbility(DefDatabase<AbilityDef>.GetNamed("SZ_QiongQi_FlyingStrike")))).CanCast)
		{
			return;
		}
		Pawn pawn = null;
		float num = -1f;
		foreach (Pawn allPawn in parent.Map.mapPawns.AllPawns)
		{
			if (!allPawn.Downed && ((allPawn.Faction != null && allPawn.Faction.IsPlayer) || allPawn.RaceProps.Humanlike) && ability.VerbTracker.PrimaryVerb.CanHitTarget(allPawn))
			{
				float num2 = parent.Position.x - allPawn.Position.x;
				float num3 = parent.Position.z - allPawn.Position.z;
				float num4 = num2 * num2 + num3 * num3;
				if (num4 > num)
				{
					num = num4;
					pawn = allPawn;
				}
			}
		}
		if (pawn != null)
		{
			Pawn pawn2 = parent as Pawn;
			pawn2.jobs.ClearQueuedJobs();
			pawn2.jobs.TryTakeOrderedJob(ability.GetJob(pawn, pawn.Position), JobTag.Misc);
		}
	}
}
