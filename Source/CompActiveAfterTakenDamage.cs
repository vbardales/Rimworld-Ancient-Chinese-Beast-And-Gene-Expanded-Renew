using Verse;

namespace AncientChineseBeast;

public class CompActiveAfterTakenDamage : ThingComp
{
	public bool actived;

	public override void PostPostApplyDamage(DamageInfo dinfo, float totalDamageDealt)
	{
		if (dinfo.Instigator != null && dinfo.Instigator.Faction != null)
		{
			actived = true;
		}
	}

	public override void PostExposeData()
	{
		Scribe_Values.Look(ref actived, "actived", defaultValue: false);
	}
}
