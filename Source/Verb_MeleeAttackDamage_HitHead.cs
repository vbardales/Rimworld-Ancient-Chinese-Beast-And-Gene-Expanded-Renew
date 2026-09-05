using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using RimWorld;
using Verse;

namespace AncientChineseBeast;

public class Verb_MeleeAttackDamage_HitHead : Verb_MeleeAttackDamage
{
	protected override DamageWorker.DamageResult ApplyMeleeDamageToTarget(LocalTargetInfo target)
	{
		if (Rand.Chance(0.5f))
		{
			return base.ApplyMeleeDamageToTarget(target);
		}
		using (IEnumerator<DamageInfo> enumerator = (typeof(Verb_MeleeAttackDamage).GetMethod("DamageInfosToApply", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(this, new object[1] { target }) as IEnumerable<DamageInfo>).GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				DamageInfo current = enumerator.Current;
				if (!target.ThingDestroyed)
				{
					if (target.Pawn != null)
					{
						BodyPartRecord bodyPartRecord = target.Pawn.def.race.body.GetPartsWithTag(BodyPartTagDefOf.ConsciousnessSource)?.First();
						if (bodyPartRecord != null)
						{
							while (bodyPartRecord.depth != BodyPartDepth.Outside)
							{
								bodyPartRecord = bodyPartRecord.parent;
							}
							foreach (Hediff hediff in target.Pawn.health.hediffSet.hediffs)
							{
								if (hediff is Hediff_MissingPart && hediff.Part == bodyPartRecord)
								{
									return target.Thing.TakeDamage(current);
								}
							}
							current.SetHitPart(bodyPartRecord);
						}
					}
					return target.Thing.TakeDamage(current);
				}
			}
		}
		return new DamageWorker.DamageResult();
	}
}
