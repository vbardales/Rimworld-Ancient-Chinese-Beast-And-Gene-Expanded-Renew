using System.Collections.Generic;
using System.Linq;
using RimWorld;
using UnityEngine;
using Verse;

namespace AncientChineseBeast;

public class Ability_BerserkRing : Ability_Draw
{
	public int ticksTime;

	private List<Pawn> pawnsLocal = new List<Pawn>();

	public Ability_BerserkRing(Pawn pawn)
		: base(pawn)
	{
	}

	public Ability_BerserkRing(Pawn pawn, AbilityDef def)
		: base(pawn, def)
	{
	}

	public override void AbilityTick()
	{
		base.AbilityTick();
		if (ticksTime <= 0)
		{
			return;
		}
		ticksTime--;
		if (ticksTime % 180 == 0)
		{
			pawnsLocal.Clear();
			pawnsLocal.AddRange(pawn.Map.mapPawns.AllPawnsSpawned.Where((Pawn x) => x.RaceProps.Humanlike && pawn.HostileTo(x)));
		}
		foreach (Pawn item in pawnsLocal)
		{
			if (item.Spawned && !item.Downed && item.Position.InHorDistOf(pawn.Position, 10.9f))
			{
				float statValue = item.GetStatValue(StatDefOf.PsychicSensitivity);
				if (statValue > 0f && item.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.Berserk, null, forced: true))
				{
					item.mindState.mentalStateHandler.CurState.forceRecoverAfterTicks = (int)(3600f * statValue);
				}
			}
		}
	}

	public override void Draw(Vector3 drawLoc)
	{
		if (ticksTime >= 1)
		{
			Matrix4x4 matrix = default(Matrix4x4);
			matrix.SetTRS(pawn.DrawPos, Quaternion.AngleAxis(0f, Vector3.up), new Vector3(22.889997f, 1f, 22.889997f));
			Graphics.DrawMesh(MeshPool.plane10, matrix, CompSeXieExpansion.Ring, 0);
		}
	}

	public override void ExposeData()
	{
		base.ExposeData();
		Scribe_Values.Look(ref ticksTime, "ticksTime", 0);
	}
}
