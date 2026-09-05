using RimWorld;
using Verse;

namespace AncientChineseBeast;

public class DamageWorker_SoundWaveDamage : DamageWorker_AddInjury
{
	public override DamageResult Apply(DamageInfo dinfo, Thing victim)
	{
		DamageResult damageResult = base.Apply(dinfo, victim);
		if (damageResult.totalDamageDealt > 0f && victim.Spawned)
		{
			victim.TakeDamage(new DamageInfo(DamageDefOf.Stun, 4f, 0f, -1f, (Thing)null, (BodyPartRecord)null, (ThingDef)null, DamageInfo.SourceCategory.ThingOrUnknown, (Thing)null, true, true, QualityCategory.Normal, true));
		}
		return damageResult;
	}
}
