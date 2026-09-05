using RimWorld;
using UnityEngine;
using Verse;

namespace AncientChineseBeast;

public class CompAbilityEffect_JetFlame : CompAbilityEffect_SectorCells
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
		YearFlame yearFlame = (YearFlame)GenSpawn.Spawn(ThingDef.Named("SZ_YearBeastFlame"), parent.pawn.Position, parent.pawn.Map);
		yearFlame.launcher = parent.pawn;
		Vector3 origin = parent.pawn.TrueCenter();
		if (parent.pawn.def.defName == "SZ_YearBeast" || parent.pawn.def.defName == "SZ_YearBeast_Friendly")
		{
			parent.StartCooldown(0);
			switch (parent.pawn.Rotation.AsInt)
			{
			case 0:
				origin.z += 3.75f;
				break;
			case 1:
				origin.x += 4.2f;
				break;
			case 2:
				origin.z -= 3f;
				break;
			default:
				origin.x -= 4.2f;
				break;
			}
		}
		yearFlame.origin = origin;
		yearFlame.angle = (target.CenterVector3 - yearFlame.origin).AngleFlat();
	}
}
