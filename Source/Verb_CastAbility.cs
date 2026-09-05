using RimWorld;
using Verse;

namespace AncientChineseBeast;

public class Verb_CastAbility : RimWorld.Verb_CastAbility
{
	protected override int ShotsPerBurst => verbProps.burstShotCount;

	public override void DrawHighlight(LocalTargetInfo target)
	{
		if (!verbProps.targetable)
		{
			ability.DrawEffectPreviews(target);
		}
		else
		{
			base.DrawHighlight(target);
		}
	}
}
