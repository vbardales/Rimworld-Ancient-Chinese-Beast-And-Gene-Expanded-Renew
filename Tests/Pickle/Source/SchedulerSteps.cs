using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using LudeonTK;
using RimWorks.Pickle;
using RimWorld;
using Verse;

namespace AncientChineseBeast.PickleSteps
{
    // The mod's scheduler is Singleton.HourTick, called by a Harmony patch on TickManager.DoSingleTick
    // once every 2500 ticks. It decides three things: a beast every 900000 ticks under the mod's own
    // storyteller, a 1% roll once a day behind a sixty-day gate under any other, and the nian beast on
    // the first hour of the first day of the year under every storyteller. None of it can be waited out
    // in a test, so these steps move the game clock and let the real tick loop, or a direct call of
    // HourTick under a known random seed, do the rest. The game's own date functions are asked to
    // confirm every clock position the arithmetic here picks, so a wrong sum fails loudly rather than
    // testing a different hour than the scenario says.
    [PickleSteps]
    public sealed class SchedulerSteps
    {
        private const int HourTicks = GenDate.TicksPerHour;     // 2500
        private const int DayTicks = GenDate.TicksPerDay;       // 60000
        private const int YearTicks = GenDate.TicksPerYear;     // 3600000
        private const int SixtyDays = 3600000;                  // the interval Singleton.HourTick requires

        private static void SetClock(PickleContext ctx, long tick)
        {
            ctx.Require(tick > 0 && tick < int.MaxValue, $"a game clock of {tick} ticks is out of range");
            Find.TickManager.DebugSetTicksGame((int)tick);
        }

        // A tick multiple of `step` a little after now, minus `before`. "Before" is what lets the real
        // tick loop cross the boundary, and the mod's own check (TicksGame % 2500 == 0) run on it.
        [When("Ancient Chinese Beast: the clock is moved to {int} ticks before the next multiple of {int}")]
        public void ClockBeforeMultiple(PickleContext ctx, int before, int step)
        {
            ctx.Require(step > 0 && before >= 0 && before < step, "the offset must be smaller than the step");
            long now = Find.TickManager.TicksGame;
            long next = (now / step + 1) * step;
            if (next - before <= now + 10) next += step;
            SetClock(ctx, next - before);
        }

        // The first game tick that is a multiple of 2500 and falls inside a given local hour. The mod
        // checks the local hour and the day of the year only at those ticks, and local time is offset
        // from game ticks by the map's longitude, so the window is found by arithmetic and then checked
        // against GenDate at the tick it picked.
        [When("Ancient Chinese Beast: the clock is moved to {int} ticks before local hour {int} of day {int} of a new year")]
        public void ClockBeforeLocalTime(PickleContext ctx, int before, int hour, int day)
        {
            var map = Stage.CurrentMap(ctx);
            ctx.Require(before >= 0 && before < HourTicks, "the offset must be smaller than an hour");
            float longitude = Find.WorldGrid.LongLatOf(map.Tile).x;
            long localToGame = Find.TickManager.gameStartAbsTick + GenDate.LocalTicksOffsetFromLongitude(longitude);
            long now = Find.TickManager.TicksGame;
            long inYear = (long)day * DayTicks + (long)hour * HourTicks;
            long yearStart = ((now + 20000 + localToGame) / YearTicks + 1) * YearTicks;    // a year start, well ahead
            long windowStart = yearStart + inYear - localToGame;                            // in game ticks
            long tick = (windowStart + HourTicks - 1) / HourTicks * HourTicks;              // first multiple of 2500 in it
            long abs = Find.TickManager.gameStartAbsTick + tick;
            ctx.Assert(GenDate.HourOfDay(abs, longitude) == hour && GenDate.DayOfYear(abs, longitude) == day,
                $"tick {tick} is local hour {GenDate.HourOfDay(abs, longitude)} of day {GenDate.DayOfYear(abs, longitude)}, not hour {hour} of day {day}: the clock arithmetic is wrong");
            SetClock(ctx, tick - before);
        }

        // Direct call, no tick loop: what is under test is the roll and the gate, and the tick loop would
        // spend random numbers on other systems first and make the seed useless. The tick is a multiple
        // of 60000 (the roll's own condition), moved a day at a time off the first hour of the year so
        // the nian beast's branch, which shares the method, stays out of it.
        [When("Ancient Chinese Beast: the ordinary hour tick runs at a day boundary with a winning roll and the gate {word}")]
        public void HourTickWithWinningRoll(PickleContext ctx, string gate)
        {
            var map = Stage.CurrentMap(ctx);
            ctx.Assert(Find.Storyteller.def.defName != "SZ_Storyteller_Sexie", "the storyteller is already Sexie, which has no daily roll");
            float longitude = Find.WorldGrid.LongLatOf(map.Tile).x;
            long tick = 7200000;
            for (int i = 0; i < 200; i++, tick += DayTicks)
            {
                long abs = Find.TickManager.gameStartAbsTick + tick;
                if (!(GenDate.HourOfDay(abs, longitude) == 0 && GenDate.DayOfYear(abs, longitude) == 0)) break;
            }
            ctx.Assert(gate == "open" || gate == "closed", $"the gate is either open or closed, not {gate}");
            SetClock(ctx, tick);
            // The gate is measured against the clock, so it is set after the clock has moved, never before.
            Singleton.instance.lastBeastTime = gate == "open" ? Find.TickManager.TicksGame - SixtyDays - 1000 : Find.TickManager.TicksGame - 1000;
            int seed = WinningSeed(ctx);
            Rand.PushState(seed);
            try { Singleton.instance.HourTick(); }
            finally { Rand.PopState(); }
        }

        // The first seed whose first draw passes the 1% chance. Found by trying, so the scenario does not
        // hard-code a number that a change to Rand would silently turn into a losing one.
        private static int WinningSeed(PickleContext ctx)
        {
            for (int seed = 1; seed < 100000; seed++)
            {
                Rand.PushState(seed);
                bool wins = Rand.Chance(0.01f);
                Rand.PopState();
                if (wins) return seed;
            }
            ctx.Assert(false, "no random seed under 100000 wins a 1% chance");
            return 0;
        }

        [When("Ancient Chinese Beast: the sixty-day gate is forced closed")]
        public void GateClosed(PickleContext ctx)
        {
            Singleton.instance.lastBeastTime = Find.TickManager.TicksGame - 1000;
        }

        [Then("Ancient Chinese Beast: the sixty-day gate is open")]
        public void GateIsOpen(PickleContext ctx)
        {
            int since = Find.TickManager.TicksGame - Singleton.instance.lastBeastTime;
            ctx.Assert(since > SixtyDays, $"only {since} ticks have passed since the last beast; the gate needs more than {SixtyDays}");
        }

        [When("Ancient Chinese Beast: the storyteller is switched to {string}")]
        public void SwitchStoryteller(PickleContext ctx, string defName)
        {
            var def = DefDatabase<StorytellerDef>.GetNamedSilentFail(defName);
            ctx.Assert(def != null, $"no StorytellerDef named {defName}");
            Find.Storyteller.def = def;
            Find.Storyteller.Notify_DefChanged();
            ctx.Assert(Find.Storyteller.def.defName == defName, $"the storyteller is {Find.Storyteller.def.defName}, not {defName}");
        }

        [Then("Ancient Chinese Beast: an ordinary beast arrives within {int} seconds", TimeoutSeconds = 45f)]
        public async Task OrdinaryBeastArrives(PickleContext ctx, int seconds)
        {
            var map = Stage.CurrentMap(ctx);
            try { await ctx.WaitUntil(() => Stage.OrdinaryBeastPresent(map), seconds); }
            catch (Exception) { }
            ctx.Assert(Stage.OrdinaryBeastPresent(map), "no mingshe, qiongqi, sexie or tunnel arrived; " + WhyNoBeast(map));
        }

        // The first run failed this step for the "beast attack now" debug action with nothing else to go on. The
        // action builds ordinary incident parameters (not forced), so an incident that refuses to fire on a day-zero
        // colony would explain it; this puts the answer in the failure message instead of leaving a guess.
        private static string WhyNoBeast(Map map)
        {
            var reasons = new List<string>();
            foreach (var name in new[] { "SZ_BeastApproach", "SZ_BeastApproachTunnel" })
            {
                var def = DefDatabase<IncidentDef>.GetNamedSilentFail(name);
                if (def == null) { reasons.Add($"{name}: no such incident"); continue; }
                var parms = RimWorld.StorytellerUtility.DefaultParmsNow(RimWorld.IncidentCategoryDefOf.ThreatBig, map);
                reasons.Add($"{name}.CanFireNow={def.Worker.CanFireNow(parms)} (forced={parms.forced}, days passed {GenDate.DaysPassed}, earliestDay {def.earliestDay}, minPopulation {def.minPopulation})");
            }
            return string.Join("; ", reasons);
        }

        // Waited in game ticks, not seconds: "nothing happened" needs the same amount of game time to
        // pass whatever speed the run is at.
        [Then("Ancient Chinese Beast: no ordinary beast is present after {int} ticks", TimeoutSeconds = 30f)]
        public async Task NoOrdinaryBeast(PickleContext ctx, int ticks)
        {
            await ctx.WaitTicks(ticks);
            var map = Stage.CurrentMap(ctx);
            ctx.Assert(!Stage.OrdinaryBeastPresent(map), "an ordinary beast is present that the scenario says should not have come");
        }

        [Then("Ancient Chinese Beast: no nian beast is present after {int} ticks", TimeoutSeconds = 30f)]
        public async Task NoNianBeast(PickleContext ctx, int ticks)
        {
            await ctx.WaitTicks(ticks);
            var map = Stage.CurrentMap(ctx);
            ctx.Assert(!map.mapPawns.AllPawnsSpawned.Any(p => p.def.defName == "SZ_YearBeast"), "a nian beast is present that the scenario says should not have come");
        }

        [Then("Ancient Chinese Beast: the year-beast debug flag is clear")]
        public void YearBeastFlagIsClear(PickleContext ctx)
        {
            ctx.Assert(!Singleton.instance.YearBeastForced, "Singleton.YearBeastForced is still set after the hour tick that should have used it");
        }

        // The mod's development actions are built by a DebugActionYielder, so that their labels go
        // through the language files: an attribute takes a constant string and the game does not translate
        // it. Whether a label really comes out translated in the pass's language is what this checks, and
        // it does it by the Keyed key so the same line serves the English pass and the French one.
        [When("Ancient Chinese Beast: I trigger the localized debug action {string}")]
        public void TriggerLocalizedAction(PickleContext ctx, string key)
        {
            var yielder = typeof(DebugActions).GetMethod("LocalizedActions", BindingFlags.NonPublic | BindingFlags.Static);
            ctx.Assert(yielder != null, "DebugActions.LocalizedActions is not there any more");
            var nodes = ((IEnumerable<DebugActionNode>)yielder.Invoke(null, null)).ToList();
            var label = key.Translate().RawText;
            ctx.Assert(label != key, $"the Keyed entry {key} is not translated in this language: the debug menu would show the raw key");
            var node = nodes.FirstOrDefault(n => n.LabelNow == label);
            ctx.Assert(node != null, $"no debug action is labelled \"{label}\" (found: {string.Join(", ", nodes.Select(n => n.LabelNow))})");
            var category = "SZ_DebugCategory".Translate().RawText;
            ctx.Assert(category != "SZ_DebugCategory" && node.category == category, $"the debug category reads \"{node.category}\", not \"{category}\"");
            node.action();
        }
    }

}
