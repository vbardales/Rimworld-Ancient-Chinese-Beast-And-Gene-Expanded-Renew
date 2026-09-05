using Verse;

namespace AncientChineseBeast;

public class CompProperties_CausePermanentGameCondition : CompProperties
{
	public GameConditionDef conditionDef;

	public CompProperties_CausePermanentGameCondition()
	{
		compClass = typeof(CompCausePermanentGameCondition);
	}
}
