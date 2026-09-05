using System;
using System.Collections.Generic;
using RimWorld;
using UnityEngine;
using Verse;

namespace AncientChineseBeast;

public class CompAbilityEffect_SectorCells : CompAbilityEffect
{
	public static IntVec3 casterCache;

	public static float angleCache;

	public static float radiusCache;

	public static Vector3 targetCache;

	public static List<IntVec3> resultCache = new List<IntVec3>();

	public override void DrawEffectPreview(LocalTargetInfo target)
	{
		GenDraw.DrawFieldEdges(GetSectorCells(target.CenterVector3, parent.verb.verbProps.AdjustedRange(parent.verb, parent.pawn), 40f, (IntVec3 c) => GenSight.LineOfSight(parent.pawn.Position, c, parent.pawn.Map)));
	}

	public List<IntVec3> GetSectorCells(Vector3 target, float radius, float angle, Func<IntVec3, bool> predicate = null)
	{
		if (parent.pawn.Position == casterCache && target == targetCache && angleCache == angle && radiusCache == radius)
		{
			return resultCache;
		}
		List<IntVec3> list = new List<IntVec3>();
		List<IntVec3> list2 = new List<IntVec3>();
		int num = GenRadial.NumCellsInRadius(radius);
		for (int i = 0; i < num; i++)
		{
			IntVec3 item = parent.pawn.Position + GenRadial.RadialPattern[i];
			list.Add(item);
		}
		float angleB2 = (target - parent.pawn.TrueCenter()).AngleFlat();
		foreach (IntVec3 item2 in list)
		{
			if (AngleAlgorithm((item2.ToVector3Shifted() - parent.pawn.TrueCenter()).AngleFlat(), angleB2, angle) && (predicate == null || predicate(item2)))
			{
				list2.Add(item2);
			}
		}
		casterCache = parent.pawn.Position;
		targetCache = target;
		angleCache = angle;
		resultCache.Clear();
		resultCache.AddRange(resultCache);
		return list2;
		static bool AngleAlgorithm(float angleA, float angleB, float limit)
		{
			return (double)Math.Abs(angleA - angleB) <= (double)limit * 0.5 || (double)Math.Abs(angleA - 360f - angleB) <= (double)limit * 0.5 || (double)Math.Abs(angleA + 360f - angleB) <= (double)limit * 0.5;
		}
	}
}
