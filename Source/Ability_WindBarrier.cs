using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using RimWorld;
using UnityEngine;
using Verse;

namespace AncientChineseBeast;

[StaticConstructorOnStartup]
public class Ability_WindBarrier : Ability_Draw
{
	public int ticksTime;

	private static List<Projectile> projectiles = new List<Projectile>();

	private static List<Thing> targets = new List<Thing>();

	private static readonly Material WindA = MaterialPool.MatFrom("AncientChineseBeast/MingShe/WindA", ShaderDatabase.Transparent);

	private static readonly Material WindB = MaterialPool.MatFrom("AncientChineseBeast/MingShe/WindB", ShaderDatabase.Transparent);

	private static readonly Material WindC = MaterialPool.MatFrom("AncientChineseBeast/MingShe/WindC", ShaderDatabase.Transparent);

	public static readonly Material Shield = MaterialPool.MatFrom("Other/ForceField", ShaderDatabase.MoteGlow);

	public float Range => (pawn.def.defName == "SZ_MingShe" || pawn.def.defName == "SZ_MingShe_Friendly") ? 10f : 5f;

	public Ability_WindBarrier(Pawn pawn)
		: base(pawn)
	{
	}

	public Ability_WindBarrier(Pawn pawn, AbilityDef def)
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
		if (ticksTime % 30 == 0)
		{
			int num = GenRadial.NumCellsInRadius(Range - 0.5f);
			for (int i = 0; i < num; i++)
			{
				IntVec3 c = base.pawn.Position + GenRadial.RadialPattern[i];
				if (!c.InBounds(base.pawn.Map))
				{
					continue;
				}
				foreach (Thing thing2 in c.GetThingList(base.pawn.Map))
				{
					if ((base.pawn.HostileTo(thing2) || base.pawn.def.defName == "SZ_MingShe") && base.pawn != thing2)
					{
						targets.Add(thing2);
					}
				}
			}
			while (targets.Count > 0)
			{
				Thing thing = targets[targets.Count - 1];
				thing.TakeDamage(new DamageInfo(DamageDefOf.Cut, 10f, 100f, -1f, (Thing)base.pawn, (BodyPartRecord)null, (ThingDef)null, DamageInfo.SourceCategory.ThingOrUnknown, (Thing)null, true, true, QualityCategory.Normal, true));
				targets.RemoveAt(targets.Count - 1);
			}
		}
		foreach (Projectile item in StoreProjectiles.projectiles.Where((Projectile projectile) => projectile.Spawned && !projectile.Destroyed))
		{
			if (item.Map == base.pawn.Map && item.Launcher != base.pawn && CollisionDetermination(item.ExactPosition, base.pawn.TrueCenter(), Math.Max(Range, Range * item.def.projectile.SpeedTilesPerTick)))
			{
				projectiles.Add(item);
			}
		}
		while (projectiles.Count > 0)
		{
			if (projectiles[0].Launcher != null && (!(projectiles[0].Launcher is Pawn) || !base.pawn.Downed) && projectiles[0].Launcher.Spawned)
			{
				Vector3 a2 = (Vector3)typeof(Projectile).GetField("origin", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(projectiles[0]);
				if (!CollisionDetermination(a2, base.pawn.TrueCenter(), Range))
				{
					LocalTargetInfo usedTarget = new LocalTargetInfo(projectiles[0].Launcher);
					if (Rand.Chance(0.5f))
					{
						usedTarget = new LocalTargetInfo(usedTarget.Cell + Cells.EightCells.RandomElement());
					}
					ThingDef thingDef = projectiles[0].def;
					Projectile projectile2 = (Projectile)GenSpawn.Spawn(thingDef, projectiles[0].DrawPos.ToIntVec3(), base.pawn.Map);
					projectile2.Launch(base.pawn, projectiles[0].DrawPos, usedTarget, projectiles[0].Launcher, ProjectileHitFlags.All, preventFriendlyFire: false, ThingMaker.MakeThing(projectiles[0].EquipmentDef));
				}
			}
			projectiles[0].Destroy();
			projectiles.Remove(projectiles[0]);
		}
		static bool CollisionDetermination(Vector3 a, Vector3 b, float range)
		{
			float num2 = a.x - b.x;
			float num3 = a.z - b.z;
			return num2 * num2 + num3 * num3 <= range * range;
		}
	}

	public override void Draw(Vector3 drawLoc)
	{
		if (ticksTime >= 1)
		{
			if (ticksTime <= 60)
			{
				float a = (float)ticksTime / 60f;
				Color color = new Color(1f, 1f, 1f, a);
				WindA.color = color;
				WindB.color = color;
				WindC.color = color;
				Shield.color = color;
			}
			else
			{
				WindA.color = Color.white;
				WindB.color = Color.white;
				WindC.color = Color.white;
				Shield.color = Color.white;
			}
			Vector3 s = new Vector3(Range * 2f, 1f, Range * 2f);
			int num = Find.TickManager.TicksGame % 360;
			Matrix4x4 matrix = default(Matrix4x4);
			matrix.SetTRS(drawLoc, Quaternion.AngleAxis((float)num * 7f, Vector3.up), s);
			Graphics.DrawMesh(MeshPool.plane10, matrix, WindA, 0);
			Matrix4x4 matrix2 = default(Matrix4x4);
			matrix2.SetTRS(drawLoc, Quaternion.AngleAxis((float)num * 11f, Vector3.up), s);
			Graphics.DrawMesh(MeshPool.plane10, matrix2, WindB, 0);
			Matrix4x4 matrix3 = default(Matrix4x4);
			matrix3.SetTRS(drawLoc, Quaternion.AngleAxis((float)num * 13f, Vector3.up), s);
			Graphics.DrawMesh(MeshPool.plane10, matrix3, WindC, 0);
			Matrix4x4 matrix4 = default(Matrix4x4);
			matrix4.SetTRS(drawLoc, Quaternion.AngleAxis(0f, Vector3.up), new Vector3(Range * 2.1f, 1f, Range * 2.1f));
			Graphics.DrawMesh(MeshPool.plane10, matrix4, Shield, 0);
		}
	}

	public override void ExposeData()
	{
		base.ExposeData();
		Scribe_Values.Look(ref ticksTime, "ticksTime", 0);
	}
}
