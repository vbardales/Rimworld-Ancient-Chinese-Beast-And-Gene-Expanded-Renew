using RimWorld;
using Verse;

namespace AncientChineseBeast;

public class YearFlameProjectile : Projectile
{
	protected override void Impact(Thing hitThing, bool blockedByShield = false)
	{
		base.Impact(hitThing, blockedByShield);
		if (hitThing != null)
		{
			hitThing.TakeDamage(new DamageInfo(def.projectile.damageDef, (float)DamageAmount, ArmorPenetration, ExactRotation.eulerAngles.y, launcher, (BodyPartRecord)null, equipmentDef, DamageInfo.SourceCategory.ThingOrUnknown, intendedTarget.Thing, !(launcher is Pawn pawn) || !pawn.Drafted, true, QualityCategory.Normal, true));
			hitThing.TryAttachFire(1f, launcher);
		}
	}
}
