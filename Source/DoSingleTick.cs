using System;
using HarmonyLib;
using Verse;

namespace AncientChineseBeast;

[StaticConstructorOnStartup]
public class DoSingleTick
{
	[HarmonyPatch(typeof(TickManager), "DoSingleTick", new Type[] { })]
	private static class DoSingleTick_PreFix
	{
		[HarmonyPrefix]
		private static bool PreFix()
		{
			if (Singleton.instance == null)
			{
				Singleton.instance = new Singleton();
			}
			Singleton.instance.Tick();
			return true;
		}
	}
}
