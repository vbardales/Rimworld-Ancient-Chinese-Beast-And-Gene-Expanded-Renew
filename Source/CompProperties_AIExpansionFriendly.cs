using RimWorld;
using Verse;

namespace AncientChineseBeast;

public class CompProperties_AIExpansionFriendly : CompProperties
{
	public AbilityDef rangeAbility;

	public CompProperties_AIExpansionFriendly()
	{
		compClass = typeof(CompAIExpansionFriendly);
	}
}
