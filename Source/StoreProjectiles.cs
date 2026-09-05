using System;
using System.Collections.Generic;
using HarmonyLib;
using Verse;

namespace AncientChineseBeast;

[StaticConstructorOnStartup]
public class StoreProjectiles
{
	[HarmonyPatch(typeof(ThingWithComps), "SpawnSetup", new Type[]
	{
		typeof(Map),
		typeof(bool)
	})]
	private static class ProjectilesSpawn_PostFix
	{
		[HarmonyPostfix]
		private static void Postfix(ThingWithComps __instance)
		{
			if (__instance is Projectile item)
			{
				projectiles.Add(item);
			}
		}
	}

	[HarmonyPatch(typeof(ThingWithComps), "DeSpawn", new Type[] { typeof(DestroyMode) })]
	private static class ProjectilesDeSpawn_PostFix
	{
		[HarmonyPostfix]
		private static void Postfix(ThingWithComps __instance)
		{
			if (__instance is Projectile item)
			{
				projectiles.Remove(item);
			}
		}
	}

	public static List<Projectile> projectiles = new List<Projectile>();
}
