using System.Collections.Generic;
using RimWorld;
using UnityEngine;
using Verse;

namespace AncientChineseBeast;

public class Singleton : IExposable
{
	public static Singleton instance = new Singleton();

	public Dictionary<ThingDef, List<Corpse>> beastCorpses = new Dictionary<ThingDef, List<Corpse>>();

	public BeastClass beast;

	public int lastBeastTime;

	public int nextBeastTimeHours = -1440;

	public bool YearBeastForced;

	public void Tick()
	{
		if (Find.TickManager.TicksGame % 2500 == 0)
		{
			HourTick();
		}
	}

	public void HourTick()
	{
		nextBeastTimeHours++;
		if (Find.Storyteller.def.defName == "SZ_Storyteller_Sexie")
		{
			if (Find.TickManager.TicksGame > 60000 && Find.TickManager.TicksGame % 900000 == 0)
			{
				BeastApproach();
			}
		}
		else if (Find.TickManager.TicksGame % 60000 == 0 && Find.TickManager.TicksGame - lastBeastTime > 3600000 && Rand.Chance(0.01f))
		{
			lastBeastTime = Find.TickManager.TicksGame;
			BeastApproach();
		}
		foreach (Map item in Find.Maps.FindAll((Map x) => x.IsPlayerHome))
		{
			Vector2 vector = Find.WorldGrid.LongLatOf(item.Tile);
			if (YearBeastForced || (GenLocalDate.HourOfDay(item) == 0 && GenDate.DayOfYear(Find.TickManager.TicksAbs, vector.x) == 0))
			{
				IncidentDef incidentDef = IncidentDef.Named("SZ_YearBeastApproach");
				IncidentParms incidentParms = StorytellerUtility.DefaultParmsNow(incidentDef.category, item);
				incidentParms.forced = true;
				if (incidentDef.Worker.CanFireNow(incidentParms))
				{
					lastBeastTime = Find.TickManager.TicksGame;
					YearBeastForced = false;
					incidentDef.Worker.TryExecute(incidentParms);
				}
			}
		}
	}

	// Which beast the incident is about. BeastApproach picks one before firing either incident,
	// which is the only route that exists in play, so the workers used to read `beast` straight
	// out of this object. Fired any other way - from the development menu, which is the only way
	// to see these incidents without waiting out a 1% daily roll gated behind sixty days - `beast`
	// is null and the worker throws before it spawns anything.
	//
	// Each incident def carries its own list in a DefModExtension_Beasts, so there is always an
	// answer available; taking it here keeps the choice in one place, and leaves the field set so
	// the letter and the tunnel spawner that read it later agree with what was spawned.
	public BeastClass BeastFor(IncidentDef incident)
	{
		var extension = incident?.GetModExtension<DefModExtension_Beasts>();
		// Older saves contain a deep copy of the letter in the language used at save time.
		// Resolve the same pawn kind against the current Def so a language change takes effect.
		if (beast != null && extension != null)
		{
			BeastClass current = extension.beasts.Find(candidate => candidate.pawn == beast.pawn);
			if (current != null) beast = current;
		}
		if (beast == null)
		{
			if (extension != null && extension.beasts.Count > 0) beast = extension.beasts.RandomElement();
		}
		return beast;
	}

	// forced is for the development action: an incident that is not forced answers to the storyteller's difficulty
	// and to its own conditions, and on a run where CanFireNow said no the action did nothing at all, silently
	// (found by the first Pickle run, 2026-09-24). The scheduler keeps asking with forced false, as before.
	public void BeastApproach(bool forced = false)
	{
		Map target = Find.Maps.FindAll((Map x) => x.IsPlayerHome).RandomElement();
		IncidentDef incidentDef = IncidentDef.Named("SZ_BeastApproach");
		IncidentDef incidentDef2 = IncidentDef.Named("SZ_BeastApproachTunnel");
		List<BeastClass> beasts = incidentDef.GetModExtension<DefModExtension_Beasts>().beasts;
		List<BeastClass> beasts2 = incidentDef2.GetModExtension<DefModExtension_Beasts>().beasts;
		int num = Rand.Range(1, beasts.Count + beasts2.Count + 1);
		IncidentParms parms = StorytellerUtility.DefaultParmsNow(IncidentCategoryDefOf.ThreatBig, target);
		parms.forced = forced;
		if (num > beasts.Count)
		{
			beast = beasts2[num - beasts.Count - 1];
			if (incidentDef2.Worker.CanFireNow(parms))
			{
				nextBeastTimeHours = 0;
				incidentDef2.Worker.TryExecute(parms);
			}
		}
		else
		{
			beast = beasts[num - 1];
			if (incidentDef.Worker.CanFireNow(parms))
			{
				nextBeastTimeHours = 0;
				incidentDef.Worker.TryExecute(parms);
			}
		}
	}

	public void ExposeData()
	{
		Scribe_Deep.Look(ref beast, "beast");
		Scribe_Values.Look(ref nextBeastTimeHours, "nextBeastTimeHours", 0);
		Scribe_Values.Look(ref lastBeastTime, "lastYearBeast", 0);
	}
}
