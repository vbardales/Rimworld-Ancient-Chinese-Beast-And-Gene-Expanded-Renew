using RimWorld;
using Verse;

namespace AncientChineseBeast;

public class IncidentWorker_YearBeastApproach : IncidentWorker
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
		PawnKindDef pawnKindDef = PawnKindDef.Named("SZ_YearBeast");
		IntVec3 loc = CellFinder.RandomClosewalkCellNear(cell, map, 10);
		Pawn pawn = PawnGenerator.GeneratePawn(pawnKindDef, (Faction)null);
		GenSpawn.Spawn(pawn, loc, map, Rot4.Random);
		SendStandardLetter(parms, pawn);
		return true;
	}

	private bool TryFindEntryCell(Map map, out IntVec3 cell)
	{
		return RCellFinder.TryFindRandomPawnEntryCell(out cell, map, CellFinder.EdgeRoadChance_Animal + 0.2f);
	}
}
