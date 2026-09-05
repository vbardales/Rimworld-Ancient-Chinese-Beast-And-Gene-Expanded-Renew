using System;
using HarmonyLib;
using Verse;

namespace AncientChineseBeast;

[StaticConstructorOnStartup]
public class ExposeDataPatch
{
	[HarmonyPatch(typeof(Game), "ExposeSmallComponents", new Type[] { })]
	private static class ExposeDataPatch_PostFix
	{
		[HarmonyPostfix]
		private static void PostFix()
		{
			if (Singleton.instance == null)
			{
				Singleton.instance = new Singleton();
			}
			Scribe_Deep.Look(ref Singleton.instance, "SZBeast_Singleton");
		}
	}
}
