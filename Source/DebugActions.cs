using System;
using System.Collections.Generic;
using LudeonTK;
using RimWorld;
using Verse;

namespace AncientChineseBeast;

// The development-mode entries for this mod, replacing the three buttons the original hung on the
// firecracker's own ThingComp.
//
// Those buttons had two problems and the smaller one was that you had to spawn a firecracker and
// select it to see them. The larger: two of the three did nothing at all. They added 120 and
// 1 200 000 to Singleton.nextBeastTimeHours, a field that is incremented every hour, reset to zero
// when a beast arrives, and READ BY NOTHING. Whatever gate it once opened had gone by the version
// that shipped, so the buttons had been inert for as long as anyone could have pressed them.
//
// What actually decides when a beast comes is in Singleton.HourTick: under an ordinary storyteller
// a 1% roll once a game day, refused unless 3 600 000 ticks - sixty days - have passed since the
// last one. So "sooner" is not one lever but two, and they are separated here: force one now, or
// open the gate and let the roll do its work. The third entry reads the clock back, because a
// scheduling bug is invisible otherwise.
public static class DebugActions
{
    [DebugActionYielder]
    private static IEnumerable<DebugActionNode> LocalizedActions()
    {
        yield return LocalizedAction("SZ_DebugBeastNow", ForceBeastApproach);
        yield return LocalizedAction("SZ_DebugNianNextHour", ForceYearBeast);
        yield return LocalizedAction("SZ_DebugClearCooldown", ClearBeastCooldown);
        yield return LocalizedAction("SZ_DebugReportClock", ReportBeastClock);
    }

    private static DebugActionNode LocalizedAction(string key, Action action)
    {
        // Attribute arguments must be constants and the game does not translate them.
        // Yield nodes directly so both the category and the visible labels are localized.
        return new DebugActionNode(key, action: action)
        {
            category = "SZ_DebugCategory".Translate(),
            labelGetter = () => key.Translate(),
            sourceAttribute = new DebugActionAttribute { allowedGameStates = AllowedGameStates.PlayingOnMap }
        };
    }

    // Sixty days, the interval HourTick requires between two beasts under any storyteller but Sexie.
    private const int BeastCooldownTicks = 3600000;

    private static void ForceBeastApproach()
    {
        Singleton.instance.BeastApproach(forced: true);
    }

    private static void ForceYearBeast()
    {
        Singleton.instance.YearBeastForced = true;
        Messages.Message("SZ_DebugNianScheduled".Translate(), MessageTypeDefOf.TaskCompletion, historical: false);
    }

    // The roll still has to come up, so this is not "a beast now" - it is the difference between a
    // colony that cannot be raided for another fifty days and one that can be raided tomorrow.
    private static void ClearBeastCooldown()
    {
        Singleton.instance.lastBeastTime = Find.TickManager.TicksGame - BeastCooldownTicks - 1;
        Messages.Message("SZ_DebugCooldownCleared".Translate(), MessageTypeDefOf.TaskCompletion, historical: false);
    }

    private static void ReportBeastClock()
    {
        int now = Find.TickManager.TicksGame;
        int since = now - Singleton.instance.lastBeastTime;
        string storyteller = Find.Storyteller.def.defName;
        string schedule = storyteller == "SZ_Storyteller_Sexie"
            ? "Sexie: one beast every 900000 ticks, no roll"
            : $"ordinary storyteller: 1% once a day, refused until {BeastCooldownTicks} ticks have passed";
        Log.Message(
            $"[Ancient Chinese Beast] tick {now}, {since} ticks since the last beast, storyteller {storyteller} ({schedule}). "
            + $"Chosen beast: {Singleton.instance.beast?.pawn?.defName ?? "none yet"}. "
            + $"Corpses held: {Singleton.instance.beastCorpses.Count} kind(s).");
        Messages.Message("SZ_DebugClockLogged".Translate(), MessageTypeDefOf.TaskCompletion, historical: false);
    }
}
