using System.Reflection;
using HarmonyLib;
using JetBrains.Annotations;
using Verse;

namespace AncientChineseBeast;

[UsedImplicitly]
[StaticConstructorOnStartup]
public class PatchMain
{
	static PatchMain()
	{
		Harmony harmony = new Harmony("SZBeast_HarmonyPatches");
		harmony.PatchAll(Assembly.GetExecutingAssembly());
	}
}
