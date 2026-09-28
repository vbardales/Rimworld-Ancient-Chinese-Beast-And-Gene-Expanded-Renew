using System.Collections.Generic;
using RimWorks.Pickle;
using RimWorld;
using RimWorld.Planet;
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

        // A plain colonist of the player's faction, for what a gene does to a human: the genes of the beasts are
        // implanted in a colonist, and PawnKindDefOf.Colonist is the game's own default one.
        [When("Ancient Chinese Beast: I spawn a colonist at x={int} z={int}")]
        public void SpawnColonist(PickleContext ctx, int x, int z)
        {
            var map = Stage.CurrentMap(ctx);
            var cell = new IntVec3(x, 0, z);
            ctx.Assert(cell.InBounds(map), $"x={x} z={z} is outside the map");
            var pawn = PawnGenerator.GeneratePawn(new PawnGenerationRequest(PawnKindDefOf.Colonist, Faction.OfPlayer, forceGenerateNewPawn: true));
            GenSpawn.Spawn(pawn, cell, map);
            ctx.Assert(pawn.Spawned, $"the colonist did not spawn at x={x} z={z}");
            Remember(ctx, pawn);
        }

        // A colonist who can do the work of a bench, for the scenarios that let a person work a bill: a generated
        // colonist may have a backstory that disables a work type, so the step draws again until the type is open,
        // then turns it on at the top priority. The cell is moved to the nearest standable one.
        [When("Ancient Chinese Beast: I spawn a colonist who can do {string} work at x={int} z={int}")]
        public void SpawnWorker(PickleContext ctx, string workTypeDefName, int x, int z)
        {
            var map = Stage.CurrentMap(ctx);
            var workType = DefDatabase<WorkTypeDef>.GetNamedSilentFail(workTypeDefName);
            ctx.Assert(workType != null, $"no WorkTypeDef named {workTypeDefName}");
            var cell = CellFinder.StandableCellNear(new IntVec3(x, 0, z), map, 8f);
            ctx.Assert(cell.IsValid, $"no standable cell near x={x} z={z}");
            Pawn pawn = null;
            for (int attempt = 0; attempt < 30 && pawn == null; attempt++)
            {
                var candidate = PawnGenerator.GeneratePawn(new PawnGenerationRequest(PawnKindDefOf.Colonist, Faction.OfPlayer, forceGenerateNewPawn: true));
                if (!candidate.WorkTypeIsDisabled(workType)) pawn = candidate;
                else Find.WorldPawns.PassToWorld(candidate, PawnDiscardDecideMode.Discard);
            }
            ctx.Assert(pawn != null, $"30 generated colonists all had {workTypeDefName} disabled");
            GenSpawn.Spawn(pawn, cell, map);
            pawn.workSettings.EnableAndInitialize();
            pawn.workSettings.SetPriority(workType, 1);
            ctx.Assert(pawn.Spawned, $"the colonist did not spawn near x={x} z={z}");
            Remember(ctx, pawn);
        }

        // A colonist at the nearest standable cell to the one asked, for a spot the scenario cannot vouch for.
        [When("Ancient Chinese Beast: I spawn a colonist near x={int} z={int}")]
        public void SpawnColonistNear(PickleContext ctx, int x, int z)
        {
            var map = Stage.CurrentMap(ctx);
            var cell = CellFinder.StandableCellNear(new IntVec3(x, 0, z), map, 8f);
            ctx.Assert(cell.IsValid, $"no standable cell near x={x} z={z}");
            var pawn = PawnGenerator.GeneratePawn(new PawnGenerationRequest(PawnKindDefOf.Colonist, Faction.OfPlayer, forceGenerateNewPawn: true));
            GenSpawn.Spawn(pawn, cell, map);
            ctx.Assert(pawn.Spawned, $"the colonist did not spawn near x={x} z={z}");
            Remember(ctx, pawn);
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
