using RimWorld;
using Verse;

namespace AncientChineseBeast;

public class SeXieTunnelSpawner : TunnelHiveSpawner
{
	protected override void Spawn(Map map, IntVec3 loc)
	{
		PawnKindDef pawn = Singleton.instance.beast.pawn;
		Pawn newThing = PawnGenerator.GeneratePawn(pawn, (Faction)null);
		GenSpawn.Spawn(newThing, loc, map, Rot4.Random);
	}
}
