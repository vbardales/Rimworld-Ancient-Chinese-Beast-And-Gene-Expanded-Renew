using RimWorld;
using Verse;
using Verse.AI;

namespace AncientChineseBeast;

public class JobGiver_QiongQiKillHuman : JobGiver_KillHuman
{
	protected override Job TryGiveJob(Pawn pawn)
	{
		if (pawn.mindState.enemyTarget == null || !pawn.mindState.enemyTarget.Spawned || pawn.mindState.enemyTarget is Pawn { Downed: not false })
		{
			pawn.mindState.enemyTarget = FindPawnTarget(pawn);
			if (pawn.mindState.enemyTarget == null)
			{
				return null;
			}
		}
		if (pawn.mindState.enemyTarget != null && pawn.CanReach(pawn.mindState.enemyTarget, PathEndMode.Touch, Danger.Deadly))
		{
			Job job = JobMaker.MakeJob(JobDefOf.AttackMelee, pawn.mindState.enemyTarget);
			job.expiryInterval = Rand.Range(420, 900);
			job.attackDoorIfTargetLost = true;
			job.canBashFences = true;
			return job;
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

	protected bool TryFindShootingPosition(Pawn pawn, Pawn target, out IntVec3 dest, Verb verbToUse = null)
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
