using System.Reflection;
using RimWorld;
using Verse;

namespace AncientChineseBeast;

public class CompCauseGameCondition_WithLetter : CompCauseGameCondition
{
	public new CompProperties_CausesGameConditionWithLetter Props => (CompProperties_CausesGameConditionWithLetter)props;

	public override void PostDestroy(DestroyMode mode, Map previousMap)
	{
		// This read the private "condition" field off CompCausePermanentGameCondition, a
		// different class in this mod that this comp does not derive from, so FieldInfo.GetValue
		// threw every time and the message below never got posted. It predates the 1.6 update -
		// no def uses this comp, which is why nobody ever saw it. The conditions this comp
		// actually causes are the ones its own base class tracks.
		foreach (GameCondition condition in CausedConditions)
		{
			condition.End();
		}
		Messages.Message(Props.text, new TargetInfo(parent.Position, previousMap), MessageTypeDefOf.NeutralEvent);
	}
}
