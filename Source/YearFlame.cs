using System;
using RimWorld;
using UnityEngine;
using Verse;

namespace AncientChineseBeast;

public class YearFlame : Thing, IAnimationThing
{
	private int fireTime;

	public float angle = 0f;

	public Vector3 origin = default(Vector3);

	public Thing launcher;

	private const float distance = 17f;

	private const float angleSet = 40f;

	public int Index
	{
		get
		{
			int num = (fireTime - 3) / 4;
			if (num < 0)
			{
				return 0;
			}
			if (num <= 8)
			{
				return num;
			}
			if (num >= 9 && num <= 38)
			{
				return (num - 3) % 6 + 3;
			}
			return Math.Min(13, num - 31);
		}
	}

	protected override void DrawAt(Vector3 drawLoc, bool flip = false)
	{
		Vector3 loc = origin;
		loc.y = AltitudeLayer.Projectile.AltitudeFor();
		Graphic.Draw(loc, Rot4.North, this, angle);
	}

	public override void SpawnSetup(Map map, bool respawningAfterLoad)
	{
		base.SpawnSetup(map, respawningAfterLoad);
		if (origin == default(Vector3))
		{
			origin = base.Position.ToVector3Shifted();
		}
	}

	protected override void Tick()
	{
		fireTime++;
		if (fireTime % 12 == 0)
		{
			Attack();
		}
		if (fireTime >= 183)
		{
			Destroy();
		}
	}

	private void Attack()
	{
		foreach (Pawn item in base.Map.mapPawns.AllPawnsSpawned)
		{
			if (item != launcher)
			{
				Vector3 vector = item.Position.ToVector3Shifted();
				if ((vector - origin).sqrMagnitude < 289f && AngleAlgorithm((vector - origin).AngleFlat(), angle, 40f))
				{
					((Projectile)GenSpawn.Spawn(ThingDef.Named((launcher.Faction == Faction.OfPlayer) ? "SZ_YearBeastFlameProjectile_Small" : "SZ_YearBeastFlameProjectile"), origin.ToIntVec3(), base.Map)).Launch(launcher ?? this, origin, item, item, ProjectileHitFlags.All);
				}
			}
		}
		static bool AngleAlgorithm(float angleA, float angleB, float limit)
		{
			return (double)Math.Abs(angleA - angleB) <= (double)limit * 0.5 || (double)Math.Abs(angleA - 360f - angleB) <= (double)limit * 0.5 || (double)Math.Abs(angleA + 360f - angleB) <= (double)limit * 0.5;
		}
	}

	public override void ExposeData()
	{
		base.ExposeData();
		Scribe_Values.Look(ref fireTime, "fireTime", 0);
		Scribe_Values.Look(ref origin, "origin");
		Scribe_Values.Look(ref angle, "angle", 0f);
		Scribe_References.Look(ref launcher, "launcher");
	}
}
