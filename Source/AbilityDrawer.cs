using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace AncientChineseBeast;

[StaticConstructorOnStartup]
public class AbilityDrawer
{
	[HarmonyPatch(typeof(Pawn), "DrawAt")]
	private static class AbilityDrawer_PostFix
	{
		[HarmonyPostfix]
		private static void PostFix(Pawn __instance, Vector3 drawLoc)
		{
			if (__instance.abilities == null)
			{
				return;
			}
			foreach (Ability ability in __instance.abilities.abilities)
			{
				if (ability is Ability_Draw ability_Draw)
				{
					ability_Draw.Draw(drawLoc);
				}
			}
		}
	}
}
