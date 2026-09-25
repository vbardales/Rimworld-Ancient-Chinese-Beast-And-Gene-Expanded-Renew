using System.Collections.Generic;
using RimWorks.Pickle;
using RimWorld;
using Verse;

namespace AncientChineseBeast.PickleSteps
{
    // Pickle's own "I spawn a <def> at (x, y)" makes its thing with ThingMaker from the ThingDef. For a race that
    // gives a Pawn that no PawnKindDef ever generated, and the first 1.6 code that reads its kind throws a
    // NullReferenceException. The first run of this suite failed fifteen scenarios on exactly that, the
    // vanilla muffalo included, so it was never the beasts. A pawn has to come from PawnGenerator, as the
    // game makes one; the other suites of this repository family write the same step for the same reason.
    [PickleSteps]
    public sealed class SpawnSteps
    {
        // No faction: the beasts arrive hostile from the wild, and a muffalo or a chicken is a wild animal too.
        // A scenario that needs an owned pawn uses the tame step below.
        [When("Ancient Chinese Beast: I spawn the pawn {string} at x={int} z={int}")]
        public void SpawnPawn(PickleContext ctx, string kindDefName, int x, int z)
        {
            Spawn(ctx, kindDefName, x, z, null, null);
        }

        // A tame pawn of a chosen sex: the breeding scenarios need a male and a female, which the game draws at random.
        [When("Ancient Chinese Beast: I spawn the tame {string} of gender {word} at x={int} z={int}")]
        public void SpawnTame(PickleContext ctx, string kindDefName, string gender, int x, int z)
        {
            Gender parsed;
            switch (gender.ToLowerInvariant())
            {
                case "male": parsed = Gender.Male; break;
                case "female": parsed = Gender.Female; break;
                default: ctx.Assert(false, $"gender must be male or female, not {gender}"); return;
            }
            Spawn(ctx, kindDefName, x, z, Faction.OfPlayer, parsed);
        }

        private static void Spawn(PickleContext ctx, string kindDefName, int x, int z, Faction faction, Gender? gender)
        {
            var map = Stage.CurrentMap(ctx);
            var kind = DefDatabase<PawnKindDef>.GetNamedSilentFail(kindDefName);
            ctx.Assert(kind != null, $"no PawnKindDef named {kindDefName}");
            var cell = new IntVec3(x, 0, z);
            ctx.Assert(cell.InBounds(map), $"x={x} z={z} is outside the map");
            var request = new PawnGenerationRequest(kind, faction, forceGenerateNewPawn: true, fixedGender: gender);
            var pawn = PawnGenerator.GeneratePawn(request);
            GenSpawn.Spawn(pawn, cell, map);
            ctx.Assert(pawn.Spawned, $"{kindDefName} did not spawn at x={x} z={z}");
            Remember(ctx, pawn);
        }

        // The pawns a scenario spawned, in order, so that a later step can say "pawn 2" instead of a cell the pawn
        // has left: a beast that walks off its cell has not gone anywhere the scenario cares about.
        internal static void Remember(PickleContext ctx, Pawn pawn)
        {
            var list = TryGet(ctx);
            if (list == null) { list = new SpawnedPawns(); ctx.Set(list); }
            list.Pawns.Add(pawn);
        }

        internal static SpawnedPawns TryGet(PickleContext ctx)
        {
            try { return ctx.Get<SpawnedPawns>(); }
            catch (System.Exception) { return null; }
        }
    }

    internal sealed class SpawnedPawns { public List<Pawn> Pawns = new List<Pawn>(); }
}
