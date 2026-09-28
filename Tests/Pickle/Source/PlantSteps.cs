using System.Linq;
using System.Threading.Tasks;
using RimWorks.Pickle;
using RimWorld;
using Verse;

namespace AncientChineseBeast.PickleSteps
{
    // M1 of Tests/Pickle/README.md's manual exceptions: the mingshe's drought rots every plant on the map
    // but the four exempt kinds, once an hour of game time (GameCondition_MingSheDrought.GameConditionTick,
    // every 2500 ticks). A plant is spawned mature (Growth = 1) so the wait tests the drought, not growth.
    [PickleSteps]
    public sealed class PlantSteps
    {
        [When("Ancient Chinese Beast: I plant {string} at x={int} z={int}")]
        public void PlantAt(PickleContext ctx, string defName, int x, int z)
        {
            var map = Stage.CurrentMap(ctx);
            var def = DefDatabase<ThingDef>.GetNamedSilentFail(defName);
            ctx.Assert(def != null, $"no ThingDef named {defName}");
            var cell = new IntVec3(x, 0, z);
            ctx.Assert(cell.InBounds(map), $"x={x} z={z} is outside the map");
            var thing = ThingMaker.MakeThing(def);
            if (thing is Plant plant) plant.Growth = 1f;
            GenSpawn.Spawn(thing, cell, map);
            ctx.Assert(thing.Spawned, $"{defName} did not spawn at x={x} z={z}");
        }

        private static Thing PlantAt(PickleContext ctx, int x, int z)
        {
            var map = Stage.CurrentMap(ctx);
            var cell = new IntVec3(x, 0, z);
            var plant = cell.GetThingList(map).OfType<Plant>().FirstOrDefault();
            ctx.Assert(plant != null, $"no plant at x={x} z={z}");
            return plant;
        }

        [When("Ancient Chinese Beast: the plant at x={int} z={int} takes drought damage within {int} seconds", TimeoutSeconds = 170f)]
        public async Task TakesDroughtDamage(PickleContext ctx, int x, int z, int seconds)
        {
            var thing = PlantAt(ctx, x, z);
            await Stage.WaitGameSeconds(ctx, () => thing.HitPoints < thing.MaxHitPoints, seconds);
            ctx.Assert(thing.HitPoints < thing.MaxHitPoints, $"the plant at x={x} z={z} took no damage; {Stage.LastWaitReport}");
        }

        [Then("Ancient Chinese Beast: the plant at x={int} z={int} is untouched by the drought")]
        public void UntouchedByDrought(PickleContext ctx, int x, int z)
        {
            var thing = PlantAt(ctx, x, z);
            ctx.Assert(thing.HitPoints == thing.MaxHitPoints, $"the plant at x={x} z={z} ({thing.def.defName}) took damage ({thing.HitPoints}/{thing.MaxHitPoints}) despite being on the drought's exception list");
        }
    }
}
