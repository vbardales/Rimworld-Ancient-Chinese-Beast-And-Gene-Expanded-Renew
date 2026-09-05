using System.Collections.Generic;
using Verse;

namespace AncientChineseBeast;

public class Firecracker : Thing
{
	private int timingTicks = -1;

	private DamageDef damageDef;

	private Thing instigator;

	private ThingDef weapon;

	private ThingDef projectile;

	private float SpreadRange
	{
		get
		{
			string defName = damageDef.defName;
			string text = defName;
			if (!(text == "SZ_Firecracker_Flame"))
			{
				if (text == "SZ_Firecracker_FlameB")
				{
					return 3.5f;
				}
				return 1.4f;
			}
			return 4.7f;
		}
	}

	private string NextLevel
	{
		get
		{
			string defName = damageDef.defName;
			string text = defName;
			if (!(text == "SZ_Firecracker_Flame"))
			{
				if (text == "SZ_Firecracker_FlameB")
				{
					return "SZ_Firecracker_FlameC";
				}
				return "";
			}
			return "SZ_Firecracker_FlameB";
		}
	}

	protected override void Tick()
	{
		if (timingTicks == -1)
		{
			if (damageDef.defName == "SZ_Firecracker_Flame")
			{
				timingTicks = Rand.Range(3, 10);
			}
			else
			{
				timingTicks = Rand.Range(15, 55);
			}
		}
		timingTicks--;
		if (timingTicks == 0)
		{
			DoExplosion();
		}
	}

	private void DoExplosion()
	{
		// Named arguments, for the reason given in CompAbilityEffect_SoundWave: 1.6 added two
		// parameters in the middle of DoExplosion's list. Everything omitted was already the
		// parameter's own default.
		GenExplosion.DoExplosion(base.Position, base.Map, SpreadRange, DefDatabase<DamageDef>.GetNamed(NextLevel), instigator, explosionSound: SoundDef.Named("SZ_Firecracker"), weapon: weapon, projectile: projectile, postExplosionSpawnThingCount: 0, preExplosionSpawnThingCount: 0, doVisualEffects: false);
		Destroy();
	}

	public override void ExposeData()
	{
		base.ExposeData();
		Scribe_Defs.Look(ref damageDef, "damageDef");
		Scribe_Values.Look(ref timingTicks, "timingTicks", -1);
		Scribe_References.Look(ref instigator, "instigator");
		Scribe_Defs.Look(ref weapon, "weapon");
		Scribe_Defs.Look(ref projectile, "projectile");
	}

	public static void SpawnFirecracker(IntVec3 pos, Map map, DamageDef damageDef, Thing instigator, ThingDef weapon, ThingDef projectile)
	{
		Firecracker firecracker = (Firecracker)GenSpawn.Spawn(ThingDef.Named("SZ_Firecracker_Explosion"), pos, map);
		firecracker.damageDef = damageDef;
		firecracker.instigator = instigator;
		firecracker.weapon = weapon;
		firecracker.projectile = projectile;
	}
}
