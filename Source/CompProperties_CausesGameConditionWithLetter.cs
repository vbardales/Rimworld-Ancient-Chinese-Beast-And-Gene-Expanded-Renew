using RimWorld;
using Verse;

namespace AncientChineseBeast;

public class CompProperties_CausesGameConditionWithLetter : CompProperties_CausesGameCondition
{
	[MustTranslate]
	public string text;

	public CompProperties_CausesGameConditionWithLetter()
	{
		compClass = typeof(CompCauseGameCondition_WithLetter);
	}
}
