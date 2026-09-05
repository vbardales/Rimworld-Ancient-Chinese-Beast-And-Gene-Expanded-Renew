using RimWorld;
using Verse;

namespace AncientChineseBeast;

public class CompAIExpansionFriendly : ThingComp
{
	public CompProperties_AIExpansionFriendly Props => props as CompProperties_AIExpansionFriendly;

	public override void CompTick()
	{
		Pawn pawn = parent as Pawn;
		if (pawn.CurJobDef != JobDefOf.AttackMelee)
		{
			return;
		}
		Pawn pawn2 = pawn.CurJob.targetA.Pawn;
		if (pawn2 != null)
		{
			Ability ability = pawn.abilities.GetAbility(Props.rangeAbility);
			if (ability != null && pawn.Position.Standable(pawn.Map) && ability.CanCast && ability.verb.CanHitTarget(pawn.mindState.enemyTarget))
			{
				pawn.jobs.StartJob(ability.GetJob(pawn.mindState.enemyTarget, pawn.mindState.enemyTarget));
			}
		}
	}
}
