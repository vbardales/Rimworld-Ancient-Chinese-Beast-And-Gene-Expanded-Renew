using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;

namespace AncientChineseBeast;

[StaticConstructorOnStartup]
public class ProjectileImpact_Patch
{
	[HarmonyPatch(typeof(Projectile), "CanHit")]
	private static class ProjectileImpact_PreFix
	{
		[HarmonyPrefix]
		private static bool PreFix(Thing thing, Projectile __instance)
		{
			if (thing.def.defName == "SZ_QiongQi" || thing.def.defName == "SZ_QiongQi_Friendly" || (ModsConfig.BiotechActive && thing is Pawn pawn && pawn.genes?.GetGene(DefDatabase<GeneDef>.GetNamed("SZGene_QiongQi_Eyes")) != null))
			{
				if (!things.ContainsKey(thing.thingIDNumber))
				{
					things.Add(thing.thingIDNumber, new HashSet<KeyValuePair<Thing, bool>>());
				}
				foreach (KeyValuePair<Thing, bool> item in things[thing.thingIDNumber])
				{
					if (item.Key == __instance)
					{
						return !item.Value;
					}
				}
				if (Rand.Chance(0.5f))
				{
					MoteMaker.ThrowText(thing.DrawPos, thing.Map, "TextMote_Dodge".Translate(), 1.9f);
					things[thing.thingIDNumber].Add(new KeyValuePair<Thing, bool>(__instance, value: true));
					return false;
				}
				things[thing.thingIDNumber].Add(new KeyValuePair<Thing, bool>(__instance, value: false));
				return true;
			}
			return true;
		}
	}

	private static Dictionary<int, HashSet<KeyValuePair<Thing, bool>>> things = new Dictionary<int, HashSet<KeyValuePair<Thing, bool>>>();
}
