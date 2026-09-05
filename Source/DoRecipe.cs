using System;
using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;

namespace AncientChineseBeast;

[StaticConstructorOnStartup]
public class DoRecipe
{
	[HarmonyPatch(typeof(GenRecipe), "MakeRecipeProducts", new Type[]
	{
		typeof(RecipeDef),
		typeof(Pawn),
		typeof(List<Thing>),
		typeof(Thing),
		typeof(IBillGiver),
		typeof(Precept_ThingStyle),
		typeof(ThingStyleDef),
		typeof(int?)
	})]
	private static class DoRecipe_PreFix
	{
		[HarmonyPostfix]
		private static void Post(RecipeDef recipeDef, ref IEnumerable<Thing> __result)
		{
			if (ModsConfig.BiotechActive)
			{
				DefModExtension_Genes modExtension = recipeDef.GetModExtension<DefModExtension_Genes>();
				if (modExtension != null)
				{
					Genepack genepack = (Genepack)ThingMaker.MakeThing(ThingDefOf.Genepack);
					List<GeneDef> genes = new List<GeneDef> { modExtension.gene };
					genepack.Initialize(genes);
					__result = new List<Thing> { genepack };
				}
			}
			DefModExtension_CloneBeast modExtension2 = recipeDef.GetModExtension<DefModExtension_CloneBeast>();
			if (modExtension2 != null)
			{
				__result = new List<Thing> { PawnGenerator.GeneratePawn(modExtension2.pawn, Faction.OfPlayer) };
			}
		}
	}
}
