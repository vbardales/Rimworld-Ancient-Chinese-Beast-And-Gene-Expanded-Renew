using HarmonyLib;
using Verse;

namespace AncientChineseBeast;

[StaticConstructorOnStartup]
public class HediffComp_GetsPermanent_Patch
{
	[HarmonyPatch(typeof(HediffComp_GetsPermanent), "set_IsPermanent")]
	private static class HediffComp_GetsPermanent_PostPatch
	{
		[HarmonyPrefix]
		private static void PreFix(ref bool value, HediffComp_GetsPermanent __instance)
		{
			if (__instance.parent.pawn.def.GetModExtension<DefModExtension_PreventPermanentInjuries>() != null)
			{
				value = false;
			}
		}
	}
}
