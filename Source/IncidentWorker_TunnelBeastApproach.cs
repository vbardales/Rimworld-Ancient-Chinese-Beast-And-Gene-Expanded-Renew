using System.Collections.Generic;
using System.Linq;
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
		BeastClass beast = Singleton.instance.BeastFor(def);
		Thing thing = GenSpawn.Spawn(ThingDef.Named("SZ_SeXieTunnelSpawner"), cell, map);
		SendStandardLetter(beast.label, beast.text, def.letterDef, parms, thing);
		return true;
	}

	private bool TryFindEntryCell(Map map, out IntVec3 cell)
	{
		// AllRooms also carries the map's great outdoors as one giant, unenclosed "room": on a poor colony its
		// scattered rocks and chunks can out-value every built room, and a random cell of it can land anywhere on
		// the map, never seen by a colonist. ProperRoom (well enclosed) keeps this to a room of the colony.
		rooms.AddRange(map.regionGrid.AllRooms.Where((Room r) => r.ProperRoom));
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
