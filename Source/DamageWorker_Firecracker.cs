using System.Collections.Generic;
using RimWorld;
using Verse;

namespace AncientChineseBeast;

public class DamageWorker_Firecracker : DamageWorker_AddInjury
{
	private float DamageRange => def.defName switch
	{
		"SZ_Firecracker_Flame" => 3.7f, 
		"SZ_Firecracker_FlameB" => 2.5f, 
		"SZ_Firecracker_FlameC" => 1.3f, 
		_ => 1.3f, 
	};

	protected override void ExplosionVisualEffectCenter(Explosion explosion)
	{
		FleckMaker.ThrowSmoke(explosion.Position.ToVector3Shifted() + Gen.RandomHorizontalVector(0.7f), explosion.Map, 0.6f);
	}

	public override void ExplosionAffectCell(Explosion explosion, IntVec3 c, List<Thing> damagedThings, List<Thing> ignoredThings, bool canThrowMotes)
	{
		if (explosion.Position.InHorDistOf(c, DamageRange))
		{
			base.ExplosionAffectCell(explosion, c, damagedThings, ignoredThings, canThrowMotes);
		}
		if (def.defName != "SZ_Firecracker_FlameC" && Rand.Chance(0.1f))
		{
			Firecracker.SpawnFirecracker(c, explosion.Map, def, explosion.instigator, explosion.weapon, explosion.projectile);
		}
	}
}
