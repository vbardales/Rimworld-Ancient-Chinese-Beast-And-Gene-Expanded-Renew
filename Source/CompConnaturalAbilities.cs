using System.Collections.Generic;
using RimWorld;
using Verse;

namespace AncientChineseBeast;

public class CompConnaturalAbilities : ThingComp
{
	public CompProperties_ConnaturalAbilities Props => props as CompProperties_ConnaturalAbilities;

	public override void PostPostMake()
	{
		RestoreAbilities();
	}

	public override void PostSpawnSetup(bool respawningAfterLoad)
	{
		RestoreAbilities();
	}

	public override IEnumerable<Gizmo> CompGetGizmosExtra()
	{
		if (parent.Faction == null || !parent.Faction.IsPlayer)
		{
			yield break;
		}
		foreach (Ability x in (parent as Pawn).abilities.abilities)
		{
			foreach (Command gizmo in x.GetGizmos())
			{
				yield return gizmo;
			}
		}
	}

	public override void CompTick()
	{
		Pawn pawn = parent as Pawn;
		if (Props.forceHostile && parent.Faction != Faction.OfPlayer && pawn.IsHashIntervalTick(120) && pawn.mindState.mentalStateHandler.CurStateDef != MentalStateDefOf.ManhunterPermanent && pawn.Awake())
		{
			pawn.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.ManhunterPermanent, parent.def.LabelCap, forced: false, forceWake: false, causedByMood: false, null, transitionSilently: true);
		}
		if (parent.Faction == Faction.OfPlayer)
		{
			pawn.mindState.mentalStateHandler.Reset();
		}
	}

	private void RestoreAbilities()
	{
		if (!(parent is Pawn { abilities: null } pawn))
		{
			return;
		}
		pawn.abilities = new Pawn_AbilityTracker(pawn);
		foreach (AbilityDef ability in Props.abilities)
		{
			pawn.abilities.GainAbility(ability);
		}
	}
}
