using System;
using System.Linq;
using System.Threading.Tasks;
using RimWorks.Pickle;
using RimWorld;
using Verse;

namespace AncientChineseBeast.PickleSteps
{
    // Questions about the state of the map that more than one feature asks: is the drought on, how many
    // of a beast are alive, does a thing of this def exist, what did a recipe produce, and did the
    // tunnel come up in the room the mod says it picks.
    [PickleSteps]
    public sealed class BeastStateSteps
    {
        private const string Drought = "SZ_MingSheDrought";

        [Then("Ancient Chinese Beast: drought is not active")]
        public void DroughtIsNotActive(PickleContext ctx)
        {
            ctx.Assert(!Stage.CurrentMap(ctx).gameConditionManager.ActiveConditions.Any(c => c.def.defName == Drought),
                "SZ_MingSheDrought is active, and the only mingshe on the map is a tame one");
        }

        [Then("Ancient Chinese Beast: exactly {int} living {string} pawns exist within {int} seconds", TimeoutSeconds = 45f)]
        public async Task LivingPawnCount(PickleContext ctx, int count, string defName, int seconds)
        {
            var map = Stage.CurrentMap(ctx);
            int Living() => map.mapPawns.AllPawnsSpawned.Count(p => p.def.defName == defName && !p.Dead);
            await Stage.WaitGameSeconds(ctx, () => Living() == count, seconds);
            ctx.Assert(Living() == count, $"{Living()} living {defName} pawn(s) on the map, expected exactly {count}");
        }

        [Then("Ancient Chinese Beast: a thing {string} exists within {int} seconds", TimeoutSeconds = 100f)]
        public async Task ThingExists(PickleContext ctx, string defName, int seconds)
        {
            var map = Stage.CurrentMap(ctx);
            await Stage.WaitGameSeconds(ctx, () => Stage.ThingsOfDef(map, defName).Any(), seconds);
            ctx.Assert(Stage.ThingsOfDef(map, defName).Any(), $"no thing of def {defName} on the map; {Stage.LastWaitReport}");
        }

        [When("Ancient Chinese Beast: I look at the first {string}")]
        public void LookAtFirst(PickleContext ctx, string defName)
        {
            var thing = Stage.ThingsOfDef(Stage.CurrentMap(ctx), defName).FirstOrDefault();
            ctx.Assert(thing != null, $"no thing of def {defName} to look at");
            Find.CameraDriver.JumpToCurrentMapLoc(thing.Position);
        }

        [Then("Ancient Chinese Beast: the recipe output holds {int} {string}")]
        public void OutputHolds(PickleContext ctx, int count, string defName)
        {
            var products = Stage.RecipeProducts(ctx);
            ctx.Assert(products != null && products.Count > 0, "make a recipe before asking what it produced");
            int held = products.Where(t => t.def.defName == defName).Sum(t => t.stackCount);
            ctx.Assert(held == count, $"the recipe produced {held} {defName}, expected {count} (products: {string.Join(", ", products.Select(t => t.def.defName + " x" + t.stackCount))})");
        }

        // The sexie's tunnel comes up in "the richest room". The worker sorts rooms by their Wealth stat
        // and takes the last, so this asks the same question of the room the spawner actually stands in:
        // is its wealth the highest on the map. Equal wealth is not a failure, whichever tied room won.
        [Then("Ancient Chinese Beast: the tunnel spawner stands in the richest room")]
        public void TunnelInRichestRoom(PickleContext ctx)
        {
            var map = Stage.CurrentMap(ctx);
            var spawner = Stage.ThingsOfDef(map, Stage.TunnelSpawner).FirstOrDefault();
            ctx.Assert(spawner != null, "no tunnel spawner on the map");
            var room = spawner.GetRoom();
            ctx.Assert(room != null, "the tunnel spawner stands in no room");
            float wealth = room.GetStat(RoomStatDefOf.Wealth);
            float richest = map.regionGrid.AllRooms.Max(r => r.GetStat(RoomStatDefOf.Wealth));
            ctx.Assert(wealth >= richest, $"the tunnel opened in a room worth {wealth}; the richest room on the map is worth {richest}");
        }

        // Evidence for a person, not an assertion: the errors the log holds when this scenario ends,
        // written into the report. The incompatibility pass uses it to record what two mods defining the
        // same defs actually make the game say.
        [Then("Ancient Chinese Beast: I attach the logged errors to the report")]
        public void AttachErrors(PickleContext ctx)
        {
            var errors = Log.Messages.Where(m => m.type == LogMessageType.Error).Select(m => m.text.Split('\n')[0]).Distinct().Take(60).ToList();
            ctx.Attach("errors logged so far", errors.Count == 0 ? "none" : string.Join("\n", errors));
        }
    }
}
