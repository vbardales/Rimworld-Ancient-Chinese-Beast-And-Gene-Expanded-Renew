using System.Collections.Generic;
using System.Linq;
using RimWorld;
using UnityEngine;
using Verse;

namespace AncientChineseBeast;

[StaticConstructorOnStartup]
public class CompSeXieExpansion : ThingComp
{
	private int ticks = 3600;

	private static List<Pawn> pawns = new List<Pawn>();

	private List<Pawn> pawnsLocal = new List<Pawn>();

	private Pawn human;

	public static readonly Material Ring = MaterialPool.MatFrom("AncientChineseBeast/SeXie/Ring", ShaderDatabase.MoteGlow);

	public override void CompTick()
	{
		if (!parent.Spawned || parent.Faction == Faction.OfPlayer)
		{
			return;
		}
		if ((parent as Pawn).Downed)
		{
			if (parent.def.defName == "SZ_SeXie")
			{
				parent.Kill();
			}
		}
		else
		{
			BerserkRing();
			BerserkPerMintutes();
		}
	}

	private void BerserkRing()
	{
		if (parent.def.defName == "SZ_SeXie")
		{
			return;
		}
		if (human != null)
		{
			if (human.Spawned)
			{
				human.Destroy();
			}
			if (human.Corpse != null && human.Corpse.Spawned)
			{
				human.Corpse.Destroy();
			}
		}
		if (ticks % 1800 == 0)
		{
			pawnsLocal.Clear();
			pawnsLocal.AddRange(parent.Map.mapPawns.AllPawnsSpawned.Where((Pawn x) => x.RaceProps.Humanlike));
		}
		foreach (Pawn item in pawnsLocal)
		{
			if (item.Spawned && !item.Downed && item.Position.InHorDistOf(parent.Position, 10.9f))
			{
				float statValue = item.GetStatValue(StatDefOf.PsychicSensitivity);
				if (statValue > 0f && item.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.Berserk, null, forced: true))
				{
					item.mindState.mentalStateHandler.CurState.forceRecoverAfterTicks = (int)(3600f * statValue);
				}
			}
		}
	}

	public override void PostDraw()
	{
		if (!(parent.def.defName == "SZ_SeXie") && parent.Spawned)
		{
			Matrix4x4 matrix = default(Matrix4x4);
			matrix.SetTRS(parent.DrawPos, Quaternion.AngleAxis(0f, Vector3.up), new Vector3(22.889997f, 1f, 22.889997f));
			Graphics.DrawMesh(MeshPool.plane10, matrix, Ring, 0);
		}
	}

	private void BerserkPerMintutes()
	{
		ticks++;
		if (ticks <= 3600)
		{
			return;
		}
		float num = 0f;
		ticks = 0;
		foreach (Pawn item in parent.Map.mapPawns.FreeColonistsAndPrisonersSpawned)
		{
			if (!item.mindState.Active || !item.mindState.mentalStateHandler.InMentalState)
			{
				float statValue = item.GetStatValue(StatDefOf.PsychicSensitivity);
				if (statValue > num)
				{
					pawns.Clear();
					num = statValue;
				}
				if (statValue == num)
				{
					pawns.Add(item);
				}
			}
		}
		if (num > 0f && pawns.Any())
		{
			Pawn pawn = pawns.RandomElement();
			if (pawn.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.Berserk, null, forced: true))
			{
				pawn.mindState.mentalStateHandler.CurState.forceRecoverAfterTicks = (int)(3600f * pawn.GetStatValue(StatDefOf.PsychicSensitivity));
			}
		}
		pawns.Clear();
	}

	// 1.6 added a DestroyMode to ThingComp.PostDeSpawn. Kept as the one-argument form this
	// compiles clean and overrides nothing: the hook is never called, and the human form dies
	// without ever turning into the scorpion.
	public override void PostDeSpawn(Map map, DestroyMode mode)
	{
		if (parent.def.defName == "SZ_SeXie" && parent.Faction != Faction.OfPlayer)
		{
			Pawn pawn = PawnGenerator.GeneratePawn(PawnKindDef.Named("SZ_SeXieInsect"), (Faction)null);
			pawn.TryGetComp<CompSeXieExpansion>().human = parent as Pawn;
			pawn.ageTracker.BirthAbsTicks = (parent as Pawn).ageTracker.BirthAbsTicks;
			GenSpawn.Spawn(pawn, parent.Position, map, Rot4.Random);
		}
	}
}
