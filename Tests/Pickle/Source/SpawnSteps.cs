using RimWorks.Pickle;
using Verse;

namespace AncientChineseBeast.PickleSteps
{
    // Pickle's own "I spawn a <def> at (x, z)" makes its thing with ThingMaker from the ThingDef. For a race that
    // gives a Pawn that no PawnKindDef ever generated, and the first 1.6 code that reads its kind throws a
    // NullReferenceException. The first run of this suite failed fifteen scenarios on exactly that, the
    // vanilla muffalo included, so it was never the beasts. A pawn has to come from PawnGenerator, as the
    // game makes one; the other suites of this repository family write the same step for the same reason.
    [PickleSteps]
    public sealed class SpawnSteps
    {
        // No faction: the beasts arrive hostile from the wild, and a muffalo or a chicken is a wild animal too.
        // A scenario that needs an owned pawn says so in its own step (the friendly clones come from the recipes).
        [When("Ancient Chinese Beast: I spawn the pawn {string} at x={int} z={int}")]
        public void SpawnPawn(PickleContext ctx, string kindDefName, int x, int z)
        {
            var map = Stage.CurrentMap(ctx);
            var kind = DefDatabase<PawnKindDef>.GetNamedSilentFail(kindDefName);
            ctx.Assert(kind != null, $"no PawnKindDef named {kindDefName}");
            var cell = new IntVec3(x, 0, z);
            ctx.Assert(cell.InBounds(map), $"x={x} z={z} is outside the map");
            var pawn = PawnGenerator.GeneratePawn(new PawnGenerationRequest(kind, null, forceGenerateNewPawn: true));
            GenSpawn.Spawn(pawn, cell, map);
            ctx.Assert(pawn.Spawned, $"{kindDefName} did not spawn at x={x} z={z}");
        }
    }
}
