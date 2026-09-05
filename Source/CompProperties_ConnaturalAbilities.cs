using System.Collections.Generic;
using RimWorld;
using Verse;

namespace AncientChineseBeast;

public class CompProperties_ConnaturalAbilities : CompProperties
{
	public List<AbilityDef> abilities = new List<AbilityDef>();

	public bool forceHostile = true;

	public CompProperties_ConnaturalAbilities()
	{
		compClass = typeof(CompConnaturalAbilities);
	}
}
