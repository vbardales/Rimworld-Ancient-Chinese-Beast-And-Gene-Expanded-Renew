using System.Collections.Generic;
using Verse;
using Verse.AI;

namespace AncientChineseBeast;

public abstract class JobGiver_KillHuman : ThinkNode_JobGiver
{
	protected static List<Pawn> targetsCacheReachable = new List<Pawn>();

	protected static List<Pawn> targetsCacheUnreachable = new List<Pawn>();

	protected Pawn FindPawnTarget(Pawn pawn)
	{
		float num = 99999f;
		Pawn result = null;
		foreach (Pawn allPawn in pawn.Map.mapPawns.AllPawns)
		{
			if (!allPawn.Downed && ((allPawn.Faction != null && allPawn.Faction.IsPlayer) || allPawn.RaceProps.Humanlike))
			{
				if (pawn.CanReach(allPawn, PathEndMode.OnCell, Danger.Deadly))
				{
					targetsCacheReachable.Add(allPawn);
				}
				else
				{
					targetsCacheUnreachable.Add(allPawn);
				}
			}
		}
		List<Pawn> list = ((targetsCacheReachable.Count > 0) ? targetsCacheReachable : targetsCacheUnreachable);
		foreach (Pawn item in list)
		{
			float num2 = pawn.Position.x - item.Position.x;
			float num3 = pawn.Position.z - item.Position.z;
			float num4 = num2 * num2 + num3 * num3;
			if (num4 < num)
			{
				num = num4;
				result = item;
			}
		}
		targetsCacheReachable.Clear();
		targetsCacheUnreachable.Clear();
		return result;
	}
}
