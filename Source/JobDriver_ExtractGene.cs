using System.Collections.Generic;
using RimWorld;
using Verse;
using Verse.AI;

namespace AncientChineseBeast;

public class JobDriver_ExtractGene : JobDriver
{
	protected Building_GeneExtractor Building => job.GetTarget(TargetIndex.A).Thing as Building_GeneExtractor;

	protected Corpse Corpse => job.GetTarget(TargetIndex.B).Thing as Corpse;

	public override bool TryMakePreToilReservations(bool errorOnFailed)
	{
		return pawn.Reserve(Building, job, 1, -1, null, errorOnFailed);
	}

	protected override IEnumerable<Toil> MakeNewToils()
	{
		this.FailOnDespawnedNullOrForbidden(TargetIndex.A);
		yield return Toils_Reserve.Reserve(TargetIndex.B);
		yield return Toils_Goto.GotoThing(TargetIndex.B, PathEndMode.ClosestTouch).FailOnDespawnedNullOrForbidden(TargetIndex.B).FailOnSomeonePhysicallyInteracting(TargetIndex.B);
		yield return Toils_General.DoAtomic(delegate
		{
			job.count = 1;
		});
		yield return Toils_Haul.StartCarryThing(TargetIndex.B).FailOnDestroyedNullOrForbidden(TargetIndex.B);
		yield return Toils_Goto.GotoThing(TargetIndex.A, PathEndMode.InteractionCell);
		yield return Toils_General.Wait(240).FailOnDestroyedNullOrForbidden(TargetIndex.B).FailOnDestroyedNullOrForbidden(TargetIndex.A)
			.FailOnCannotTouch(TargetIndex.A, PathEndMode.Touch)
			.WithProgressBarToilDelay(TargetIndex.A);
		Toil toil = ToilMaker.MakeToil("ExtractGene");
		toil.initAction = delegate
		{
			Corpse.InnerPawn.GetComp<CompGenesInCorpse>()?.ExtractAt(pawn.Position, pawn.Map);
		};
		toil.defaultCompleteMode = ToilCompleteMode.Instant;
		yield return toil;
	}
}
