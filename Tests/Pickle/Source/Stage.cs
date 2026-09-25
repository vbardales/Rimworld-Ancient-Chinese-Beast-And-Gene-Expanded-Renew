using System.Collections.Generic;
using System.Linq;
using RimWorks.Pickle;
using Verse;

namespace AncientChineseBeast.PickleSteps
{
    // What every step class of this suite needs and none of them should each write out again: the map
    // the scenario is playing on, a pawn found by def name at a cell, and the questions a scenario asks
    // about "a beast has arrived". Kept in one place so that the four defNames that mean "an ordinary
    // beast" cannot drift between the step that waits for one and the step that checks none came.
    internal static class Stage
    {
        // The three walking beasts, and the tunnel the sexie digs up through. The nian beast is not in
        // this list on purpose: it has its own incident and its own schedule.
        internal static readonly string[] OrdinaryBeastPawns = { "SZ_MingShe", "SZ_QiongQi", "SZ_SeXie" };
        internal const string TunnelSpawner = "SZ_SeXieTunnelSpawner";

        internal static Map CurrentMap(PickleContext ctx)
        {
            ctx.Require(Find.CurrentMap != null, "load a map before invoking an Ancient Chinese Beast step");
            return Find.CurrentMap;
        }

        internal static Pawn PawnAt(PickleContext ctx, string defName, int x, int z)
        {
            var cell = new IntVec3(x, 0, z);
            var pawn = cell.GetThingList(CurrentMap(ctx)).OfType<Pawn>().FirstOrDefault(p => p.def.defName == defName);
            ctx.Assert(pawn != null, $"no {defName} pawn at x={x} z={z}");
            return pawn;
        }

        // Waits for a condition in GAME time: "within N seconds" is 60 * N ticks at normal speed, and the ticks are driven
        // here, five at a time, with the same wait "I wait N ticks" uses. Pickle's autorun default is fast mode, where the
        // game's tick loop is driven only by that wait: a real-time WaitUntil there watches a simulation that is not moving,
        // and the first runs failed the tunnel scenario that way (the sexie never came out of a tunnel due at the next
        // tick). Nor does the wait depend on how fast the machine is, which is what the launcher's 120 s watchdog punished.
        // The caller asserts afterwards; a condition that never comes true just spends its budget.
        //
        // A wait also stops at 150 real seconds, before the 170 s step deadline of the long waits cuts the scenario off with no word on
        // why (the tunnel run of 2026-09-25 spent all 100 s on 20 game seconds): the caller then asserts with LastWaitReport,
        // which says how many of the ticks it asked for the game really ran.
        internal static string LastWaitReport = "no wait yet";

        internal static async System.Threading.Tasks.Task WaitGameSeconds(PickleContext ctx, System.Func<bool> condition, int seconds)
        {
            const int step = 5;
            var clock = System.Diagnostics.Stopwatch.StartNew();
            int startTick = Find.TickManager.TicksGame;
            for (int spent = 0; spent < seconds * 60 && !condition() && clock.Elapsed.TotalSeconds < 150; spent += step)
                await ctx.WaitTicks(step);
            LastWaitReport = $"the game advanced {Find.TickManager.TicksGame - startTick} ticks of the {seconds * 60} asked for in {clock.Elapsed.TotalSeconds:F1} real seconds";
        }

        internal static bool OrdinaryBeastPresent(Map map)
        {
            if (map.mapPawns.AllPawnsSpawned.Any(p => !p.Dead && OrdinaryBeastPawns.Contains(p.def.defName))) return true;
            return map.listerThings.AllThings.Any(t => t.def.defName == TunnelSpawner);
        }

        internal static IEnumerable<Thing> ThingsOfDef(Map map, string defName)
            => map.listerThings.AllThings.Where(t => t.def.defName == defName);

        // The products of the last recipe a scenario made, or null when none was made. Context state is
        // read by type; a scenario that never set it must not crash the step that asks, it must fail it.
        internal static List<Thing> RecipeProducts(PickleContext ctx)
        {
            try { return ctx.Get<RecipeOutput>()?.Products; }
            catch (System.Exception) { return null; }
        }
    }

    // Scenario state, keyed by type through PickleContext.Set/Get. A step class instance is not a place
    // to keep a value between two steps: the authoring guide says to use the context, and the earlier
    // recipe steps kept theirs in a field for want of one.
    internal sealed class RecipeOutput { public List<Thing> Products; }
    internal sealed class Blow { public float Dealt; }
    internal sealed class Butchery { public List<Thing> Products; }
    internal sealed class BurntTarget { public Pawn Pawn; }
}
