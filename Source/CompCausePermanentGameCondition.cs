using RimWorld;
using Verse;

namespace AncientChineseBeast;

public class CompCausePermanentGameCondition : ThingComp
{
	private GameCondition condition;

	public CompProperties_CausePermanentGameCondition Props => props as CompProperties_CausePermanentGameCondition;

	public override void PostSpawnSetup(bool respawningAfterLoad)
	{
		if (parent.Faction != Faction.OfPlayer)
		{
			GameCondition gameCondition = (condition = GameConditionMaker.MakeConditionPermanent(Props.conditionDef));
			gameCondition.conditionCauser = parent;
			parent.Map.gameConditionManager.RegisterCondition(gameCondition);
		}
	}

	// 1.6 added a DestroyMode to ThingComp.PostDeSpawn; see CompSeXieExpansion for what the
	// one-argument form costs. Here it would leave a permanent game condition running on the
	// map after its causer is gone, with nothing left to end it.
	public override void PostDeSpawn(Map map, DestroyMode mode)
	{
		condition?.End();
	}

	public override void PostExposeData()
	{
		Scribe_References.Look(ref condition, "causedCondition");
	}
}
