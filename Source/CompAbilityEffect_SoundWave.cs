using System.Collections.Generic;
using RimWorld;
using UnityEngine;
using Verse;

namespace AncientChineseBeast;

public class CompAbilityEffect_SoundWave : CompAbilityEffect_SectorCells
{
	public override bool AICanTargetNow(LocalTargetInfo target)
	{
		return target != null && target.Pawn != null;
	}

	public override bool CanApplyOn(LocalTargetInfo target, LocalTargetInfo dest)
	{
		return true;
	}

	public override bool Valid(LocalTargetInfo target, bool throwMessages = false)
	{
		return true;
	}

	public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
	{
		if (parent.pawn.def.defName == "SZ_MingShe")
		{
			parent.StartCooldown(0);
		}
		float rotation = (target.CenterVector3 - parent.pawn.TrueCenter()).AngleFlat();
		FleckCreationData dataStatic = FleckMaker.GetDataStatic(parent.pawn.DrawPos, parent.pawn.Map, DefDatabase<FleckDef>.GetNamed("SZ_MingSheWave"));
		dataStatic.rotation = rotation;
		float num = Mathf.Atan2(0f - (target.CenterVector3.z - (float)parent.pawn.Position.z), target.CenterVector3.x - (float)parent.pawn.Position.x) * 57.29578f;
		// 1.6 inserted postExplosionGasRadiusOverride and postExplosionGasAmount in the middle of
		// DoExplosion's parameter list, so the original all-positional call now lands two slots
		// off from the fifteenth argument on. Named arguments say what is meant and cannot slip
		// again; every argument left out here was already passing the parameter's own default.
		GenExplosion.DoExplosion(parent.pawn.Position, parent.pawn.Map, 29.9f, DefDatabase<DamageDef>.GetNamed("SZ_SoundWaveDamage"), parent.pawn, 15, 100f, postExplosionSpawnThingCount: 0, preExplosionSpawnThingCount: 0, ignoredThings: new List<Thing> { parent.pawn }, affectedAngle: new FloatRange(num - 22.5f, num + 22.5f), doVisualEffects: false, doSoundEffects: false, screenShakeFactor: 0f);
		parent.pawn.Map.flecks.CreateFleck(dataStatic);
	}
}
