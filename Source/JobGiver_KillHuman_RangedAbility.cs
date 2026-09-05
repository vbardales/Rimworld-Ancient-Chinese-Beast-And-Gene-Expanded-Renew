using RimWorld;
using Verse;
using Verse.AI;

namespace AncientChineseBeast;

public abstract class JobGiver_KillHuman_RangedAbility : JobGiver_KillHuman
{
	public abstract string RangedAbilityDefName(Pawn pawn);

	protected override Job TryGiveJob(Pawn pawn)
	{
		if (pawn.TryGetAttackVerb(null) == null)
		{
			return null;
		}
		if (pawn.mindState.enemyTarget == null || !pawn.mindState.enemyTarget.Spawned || pawn.mindState.enemyTarget is Pawn { Downed: not false })
		{
			pawn.mindState.enemyTarget = FindPawnTarget(pawn);
			if (pawn.mindState.enemyTarget == null)
			{
				return null;
			}
		}
		Ability ability = pawn.abilities.GetAbility(DefDatabase<AbilityDef>.GetNamed(RangedAbilityDefName(pawn)));
		if (ability != null && pawn.Position.Standable(pawn.Map))
		{
			if (ability.verb.CanHitTarget(pawn.mindState.enemyTarget))
			{
				return ability.GetJob(pawn.mindState.enemyTarget, pawn.mindState.enemyTarget);
			}
			if (TryFindShootingPosition(pawn, pawn.mindState.enemyTarget, out var dest, ability.verb))
			{
				Job job = JobMaker.MakeJob(JobDefOf.Goto, dest);
				job.expiryInterval = JobGiver_AIFightEnemy.ExpiryInterval_ShooterSucceeded.RandomInRange;
				job.checkOverrideOnExpire = true;
				return job;
			}
		}
		IntVec3 positionHeld = pawn.mindState.enemyTarget.PositionHeld;
		if (pawn.CanReach(positionHeld, PathEndMode.OnCell, Danger.Deadly, canBashDoors: false, canBashFences: false, TraverseMode.PassAllDestroyableThings))
		{
			// 1.6 renamed PathFinder.FindPath to FindPathNow, moved the type from Verse.AI to Verse,
			// turned PathFinderCostTuning into a struct and put the tuning before the end mode.
			using PawnPath path = pawn.Map.pathFinder.FindPathNow(pawn.Position, positionHeld, TraverseParms.For(pawn, Danger.Deadly, TraverseMode.PassAllDestroyableThings, canBashDoors: false, canBashFences: false, alwaysUseAvoidGrid: false), null, PathEndMode.OnCell);
			IntVec3 cellBefore;
			Thing thing = path.FirstBlockingBuilding(out cellBefore, pawn);
			if (thing != null)
			{
				Job job2 = JobMaker.MakeJob(JobDefOf.AttackMelee, thing);
				job2.ignoreDesignations = true;
				job2.expiryInterval = JobGiver_AIFightEnemy.ExpiryInterval_ShooterSucceeded.RandomInRange;
				job2.checkOverrideOnExpire = true;
				return job2;
			}
		}
		return null;
	}

	protected bool TryFindShootingPosition(Pawn pawn, Thing target, out IntVec3 dest, Verb verbToUse = null)
	{
		CastPositionRequest newReq = default(CastPositionRequest);
		newReq.caster = pawn;
		newReq.target = target;
		newReq.verb = verbToUse;
		newReq.maxRangeFromTarget = verbToUse.verbProps.range;
		newReq.wantCoverFromTarget = verbToUse.verbProps.range > 5f;
		return CastPositionFinder.TryFindCastPosition(newReq, out dest);
	}
}
