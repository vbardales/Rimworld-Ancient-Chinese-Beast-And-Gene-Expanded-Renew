using System.Collections.Generic;
using RimWorld;
using Verse;

namespace AncientChineseBeast;

public class IncidentWorker_TunnelBeastApproach : IncidentWorker
{
	private List<Room> rooms = new List<Room>();

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
		Thing thing = GenSpawn.Spawn(ThingDef.Named("SZ_SeXieTunnelSpawner"), cell, map);
		SendStandardLetter(Singleton.instance.beast.label, Singleton.instance.beast.text, def.letterDef, parms, thing);
		return true;
	}

	private bool TryFindEntryCell(Map map, out IntVec3 cell)
	{
		rooms.AddRange(map.regionGrid.AllRooms);
		if (rooms.Count > 0)
		{
			rooms.SortBy((Room x) => x.GetStat(RoomStatDefOf.Wealth));
			rooms[rooms.Count - 1].Cells.TryRandomElement(out cell);
			rooms.Clear();
			return true;
		}
		cell = IntVec3.Invalid;
		return false;
	}
}
