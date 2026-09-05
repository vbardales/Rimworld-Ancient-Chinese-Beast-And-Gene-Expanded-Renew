using RimWorld;
using Verse;

namespace AncientChineseBeast;

public class IncidentWorker_ChickenPasses : IncidentWorker
{
	protected override bool CanFireNowSub(IncidentParms parms)
	{
		Map map = (Map)parms.target;
		IntVec3 cell;
		return TryFindEntryCell(map, out cell);
	}

	protected override bool TryExecuteWorker(IncidentParms parms)
	{
		Map map = (Map)parms.target;
		if (!TryFindEntryCell(map, out var cell))
		{
			return false;
		}
		PawnKindDef pawnKindDef = PawnKindDef.Named("SZ_Chicken");
		int num = Rand.RangeInclusive(90000, 150000);
		IntVec3 result = IntVec3.Invalid;
		if (!RCellFinder.TryFindRandomCellOutsideColonyNearTheCenterOfTheMap(cell, map, 10f, out result))
		{
			result = IntVec3.Invalid;
		}
		Pawn pawn = null;
		IntVec3 loc = CellFinder.RandomClosewalkCellNear(cell, map, 10);
		pawn = PawnGenerator.GeneratePawn(pawnKindDef, (Faction)null);
		GenSpawn.Spawn(pawn, loc, map, Rot4.Random);
		pawn.mindState.exitMapAfterTick = Find.TickManager.TicksGame + num;
		if (result.IsValid)
		{
			pawn.mindState.forcedGotoPosition = CellFinder.RandomClosewalkCellNear(result, map, 10);
		}
		SendStandardLetter(parms, pawn);
		return true;
	}

	private bool TryFindEntryCell(Map map, out IntVec3 cell)
	{
		return RCellFinder.TryFindRandomPawnEntryCell(out cell, map, CellFinder.EdgeRoadChance_Animal + 0.2f);
	}
}
