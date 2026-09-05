using System.Collections.Generic;
using System.Linq;
using RimWorld;
using UnityEngine;
using Verse;

namespace AncientChineseBeast;

public class PawnFlyingStrike : PawnFlyer
{
	private int positionLastComputedTick = -1;

	private Vector3 groundPos;

	private float angle = -1f;

	public HashSet<Thing> hurtedTargets = new HashSet<Thing>();

	private static List<Thing> targets = new List<Thing>();

	// 1.6 moved the flyer's own flight logic out of Tick() and into TickInterval(int delta):
	// PawnFlyer no longer overrides Tick() at all, so a base.Tick() here would land on
	// Entity.Tick(), which is empty, and the flyer would hang in the air until the map unloaded.
	// PawnFlyer pins UpdateRateTicks to 1, so delta is always 1 and running the body twice still
	// advances the flight by two ticks per game tick, exactly as it did in 1.5.
	protected override void TickInterval(int delta)
	{
		DoubleTick(delta);
		if (base.Spawned)
		{
			DoubleTick(delta);
		}
	}

	private void DoubleTick(int delta)
	{
		int num = GenRadial.NumCellsInRadius(3.9f);
		for (int i = 0; i < num; i++)
		{
			IntVec3 c = groundPos.ToIntVec3() + GenRadial.RadialPattern[i];
			if (!c.InBounds(base.Map))
			{
				continue;
			}
			foreach (Thing thing2 in c.GetThingList(base.Map))
			{
				if ((base.FlyingPawn.HostileTo(thing2) || base.FlyingPawn.def.defName == "SZ_QiongQi") && !hurtedTargets.Contains(thing2))
				{
					hurtedTargets.Add(thing2);
					targets.Add(thing2);
				}
			}
		}
		while (targets.Count > 0)
		{
			Thing thing = targets[targets.Count - 1];
			BodyPartRecord bodyPartRecord = null;
			if (thing is Pawn && Rand.Chance(0.5f))
			{
				bodyPartRecord = thing.def.race.body.GetPartsWithTag(BodyPartTagDefOf.ConsciousnessSource)?.First();
			}
			thing.TakeDamage(new DamageInfo(DamageDefOf.Cut, 25f, 1f, -1f, (Thing)base.FlyingPawn, bodyPartRecord, (ThingDef)null, DamageInfo.SourceCategory.ThingOrUnknown, (Thing)null, true, true, QualityCategory.Normal, true));
			targets.RemoveAt(targets.Count - 1);
		}
		RecomputePosition();
		base.TickInterval(delta);
	}

	private void RecomputePosition()
	{
		if (positionLastComputedTick != ticksFlying)
		{
			if (angle == -1f)
			{
				angle = (base.DestinationPos - startVec).AngleFlat();
			}
			positionLastComputedTick = ticksFlying;
			float t = (float)ticksFlying / (float)ticksFlightTime;
			groundPos = Vector3.Lerp(startVec, base.DestinationPos, t);
		}
	}

	public override void DynamicDrawPhaseAt(DrawPhase phase, Vector3 drawLoc, bool flip = false)
	{
		RecomputePosition();
		base.FlyingPawn.DynamicDrawPhaseAt(phase, groundPos, flip);
	}

	public static PawnFlyingStrike Make(ThingDef flyingDef, Ability ability, Pawn pawn, IntVec3 destCell, EffecterDef flightEffecterDef, SoundDef landingSound, bool flyWithCarriedThing = false)
	{
		pawn.rotationTracker.FaceCell(destCell);
		return PawnFlyer.MakeFlyer(flyingDef, pawn, destCell, flightEffecterDef, landingSound, flyWithCarriedThing) as PawnFlyingStrike;
	}
}
