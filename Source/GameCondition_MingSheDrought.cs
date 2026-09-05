using System.Collections.Generic;
using RimWorld;
using Verse;

namespace AncientChineseBeast;

public class GameCondition_MingSheDrought : GameCondition
{
	private static List<Thing> things = new List<Thing>();

	public override WeatherDef ForcedWeather()
	{
		return WeatherDefOf.Clear;
	}

	public override void GameConditionTick()
	{
		if (conditionCauser == null || !conditionCauser.Spawned || (conditionCauser as Pawn).Dead || conditionCauser.Faction == Faction.OfPlayer)
		{
			End();
		}
		else
		{
			if (Find.TickManager.TicksGame % 2500 != 0)
			{
				return;
			}
			things.AddRange(base.SingleMap.listerThings.ThingsInGroup(ThingRequestGroup.Plant));
			foreach (Thing thing in things)
			{
				if (thing.Map == conditionCauser.Map && !CheckPlant(thing.def.defName))
				{
					thing.TakeDamage(new DamageInfo(DamageDefOf.Rotting, (float)Rand.Range(7, 20), 0f, -1f, (Thing)null, (BodyPartRecord)null, (ThingDef)null, DamageInfo.SourceCategory.ThingOrUnknown, (Thing)null, true, true, QualityCategory.Normal, true));
				}
			}
			things.Clear();
		}
	}

	public static bool CheckPlant(string defName)
	{
		int result;
		switch (defName)
		{
		default:
			result = ((defName == "Plant_TreePolux") ? 1 : 0);
			break;
		case "Plant_GrassAnima":
		case "Plant_TreeAnima":
		case "Plant_MossGauranlen":
		case "Plant_TreeGauranlen":
			result = 1;
			break;
		}
		return (byte)result != 0;
	}
}
