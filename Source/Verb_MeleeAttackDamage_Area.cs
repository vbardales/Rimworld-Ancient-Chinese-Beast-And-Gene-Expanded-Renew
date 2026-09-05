using System.Collections.Generic;
using RimWorld;
using Verse;

namespace AncientChineseBeast;

public class Verb_MeleeAttackDamage_Area : Verb_MeleeAttackDamage
{
	private static List<Thing> targets = new List<Thing>();

	private IEnumerable<Thing> GetTargets(IntVec3 pos)
	{
		int num = GenRadial.NumCellsInRadius(3f);
		for (int i = 0; i < num; i++)
		{
			IntVec3 intVec = pos + GenRadial.RadialPattern[i];
			if (!intVec.InBounds(caster.Map))
			{
				continue;
			}
			foreach (Thing y in intVec.GetThingList(Caster.Map))
			{
				if (CanHitTarget(y))
				{
					yield return y;
				}
			}
		}
	}

	public override bool CanHitTarget(LocalTargetInfo targ)
	{
		return caster != null && caster.Spawned && targ != caster;
	}

	protected override bool TryCastShot()
	{
		LocalTargetInfo localTargetInfo = currentTarget;
		bool result = false;
		targets.AddRange(GetTargets(localTargetInfo.Cell));
		while (targets.Count > 0)
		{
			Thing thing = targets[targets.Count - 1];
			if (CanHitTarget(thing))
			{
				currentTarget = thing;
				if (base.TryCastShot())
				{
					result = true;
				}
				targets.RemoveAt(targets.Count - 1);
			}
		}
		return result;
	}

	protected override DamageWorker.DamageResult ApplyMeleeDamageToTarget(LocalTargetInfo target)
	{
		DamageWorker.DamageResult damageResult = base.ApplyMeleeDamageToTarget(target);
		damageResult.deflected = false;
		return damageResult;
	}
}
