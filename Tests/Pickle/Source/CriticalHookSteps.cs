using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using RimWorks.Pickle;
using RimWorld;
using Verse;

namespace AncientChineseBeast.PickleSteps
{
    [PickleSteps]
    public sealed class CriticalHookSteps
    {
        private static Map Map(PickleContext ctx)
        {
            ctx.Require(Find.CurrentMap != null, "load a map before invoking an Ancient Chinese Beast step");
            return Find.CurrentMap;
        }

        private static Pawn PawnAt(PickleContext ctx, string defName, int x, int z)
        {
            var cell = new IntVec3(x, 0, z);
            var pawn = cell.GetThingList(Map(ctx)).OfType<Pawn>().FirstOrDefault(p => p.def.defName == defName);
            ctx.Assert(pawn != null, $"no {defName} pawn at x={x} z={z}");
            return pawn;
        }

        [Then("Ancient Chinese Beast: drought is active")]
        public void DroughtActive(PickleContext ctx)
        {
            ctx.Assert(Map(ctx).gameConditionManager.ActiveConditions.Any(c => c.def.defName == "SZ_MingSheDrought"),
                "SZ_MingSheDrought is not active after the mingshe spawned");
        }

        [When("Ancient Chinese Beast: I kill {string} at x={int} z={int}")]
        public void Kill(PickleContext ctx, string defName, int x, int z)
        {
            var pawn = PawnAt(ctx, defName, x, z);
            pawn.Kill(new DamageInfo(DamageDefOf.Crush, 9999f, 999f));
            ctx.Assert(pawn.Dead, $"{defName} at x={x} z={z} survived the test damage");
        }

        [Then("Ancient Chinese Beast: drought ends within {int} seconds", TimeoutSeconds = 35f)]
        public async Task DroughtEnds(PickleContext ctx, int seconds)
        {
            var map = Map(ctx);
            try { await ctx.WaitUntil(() => !map.gameConditionManager.ActiveConditions.Any(c => c.def.defName == "SZ_MingSheDrought"), seconds); }
            catch (Exception) { }
            ctx.Assert(!map.gameConditionManager.ActiveConditions.Any(c => c.def.defName == "SZ_MingSheDrought"), "SZ_MingSheDrought remained after its mingshe died");
        }

        [Then("Ancient Chinese Beast: {string} appears at x={int} z={int} within {int} seconds", TimeoutSeconds = 35f)]
        public async Task Appears(PickleContext ctx, string defName, int x, int z, int seconds)
        {
            var cell = new IntVec3(x, 0, z); var map = Map(ctx);
            try { await ctx.WaitUntil(() => cell.GetThingList(map).OfType<Pawn>().Any(p => p.def.defName == defName), seconds); }
            catch (Exception) { }
            ctx.Assert(cell.GetThingList(map).OfType<Pawn>().Any(p => p.def.defName == defName), $"{defName} did not appear at x={x} z={z}");
        }

        [When("Ancient Chinese Beast: I launch the qiongqi at x={int} z={int} to x={int} z={int}")]
        public void LaunchQiongQi(PickleContext ctx, int x, int z, int targetX, int targetZ)
        {
            var pawn = PawnAt(ctx, "SZ_QiongQi", x, z);
            var type = GenTypes.GetTypeInAnyAssembly("AncientChineseBeast.PawnFlyingStrike");
            var method = type?.GetMethod("Make", BindingFlags.Public | BindingFlags.Static);
            ctx.Assert(method != null, "PawnFlyingStrike.Make was not loaded");
            var flyer = method.Invoke(null, new object[] { ThingDef.Named("SZ_QQPawnFlyingStrike"), null, pawn, new IntVec3(targetX, 0, targetZ), null, null, false }) as Thing;
            ctx.Assert(flyer != null, "PawnFlyingStrike.Make returned no flyer");
            GenSpawn.Spawn(flyer, pawn.Position, Map(ctx));
        }

        [When("Ancient Chinese Beast: I execute incident {string}")]
        public void ExecuteIncident(PickleContext ctx, string defName)
        {
            var incident = DefDatabase<IncidentDef>.GetNamedSilentFail(defName);
            ctx.Assert(incident != null, $"no IncidentDef named {defName}");
            var parms = new IncidentParms { target = Map(ctx), forced = true };
            bool executed = incident.Worker.TryExecute(parms);
            ctx.Assert(executed, $"incident {defName} returned false");
        }

        [When("Ancient Chinese Beast: the chicken at x={int} z={int} crows")]
        public void ChickenCrows(PickleContext ctx, int x, int z)
        {
            var chicken = PawnAt(ctx, "SZ_Chicken", x, z);
            var ability = chicken.abilities.GetAbility(DefDatabase<AbilityDef>.GetNamed("SZ_Chicken_Crow"));
            ctx.Assert(ability != null, "the chicken has no SZ_Chicken_Crow ability");
            ctx.Assert(ability.CanCast, "the chicken crow ability cannot cast in the staged scene");
            ability.Activate(chicken, chicken);
        }

        [When("Ancient Chinese Beast: I invoke debug action {string}")]
        public void InvokeDebugAction(PickleContext ctx, string methodName)
        {
            Map(ctx);
            var type = GenTypes.GetTypeInAnyAssembly("AncientChineseBeast.DebugActions");
            var method = type?.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Static);
            ctx.Assert(method != null, $"no private debug action method named {methodName}");
            method.Invoke(null, null);
        }

        [When("Ancient Chinese Beast: I make recipe {string}")]
        public void MakeRecipe(PickleContext ctx, string recipeDefName)
        {
            var recipe = DefDatabase<RecipeDef>.GetNamedSilentFail(recipeDefName);
            ctx.Assert(recipe != null, $"no RecipeDef named {recipeDefName}");
            var method = typeof(GenRecipe).GetMethods(BindingFlags.Public | BindingFlags.Static)
                .SingleOrDefault(candidate => candidate.Name == "MakeRecipeProducts" && candidate.GetParameters().Length == 8);
            ctx.Assert(method != null, "GenRecipe.MakeRecipeProducts with its 1.6 signature was not loaded");
            // A worker, when the map has one. The mod's postfix replaces the result of the gene and clone recipes
            // before the game's own iterator ever runs, so they never needed one. The plain product recipe
            // (the archite capsules) does run it, and GenRecipe.PostProcessProduct reads worker.Ideo with no
            // null check: with no worker it throws a NullReferenceException that says nothing about the mod.
            var worker = Map(ctx).mapPawns.FreeColonists.FirstOrDefault();
            var result = method.Invoke(null, new object[] { recipe, worker, new List<Thing>(), null, null, null, null, null }) as IEnumerable<Thing>;
            var products = result?.ToList();
            ctx.Assert(products != null && products.Count > 0, $"{recipeDefName} produced no recipe products");
            ctx.Set(new RecipeOutput { Products = products });
        }

        [Then("Ancient Chinese Beast: the recipe output is a genepack containing {string}")]
        public void OutputIsGenepack(PickleContext ctx, string geneDefName)
        {
            var pack = Stage.RecipeProducts(ctx)?.OfType<Genepack>().SingleOrDefault();
            ctx.Assert(pack != null, "the recipe output was not exactly one Genepack");
            ctx.Assert(pack.GeneSet.GenesListForReading.Any(gene => gene.defName == geneDefName),
                $"the Genepack does not contain {geneDefName}");
        }

        [Then("Ancient Chinese Beast: the recipe output is a player {string} pawn")]
        public void OutputIsPlayerPawn(PickleContext ctx, string pawnKindDefName)
        {
            var pawn = Stage.RecipeProducts(ctx)?.OfType<Pawn>().SingleOrDefault();
            ctx.Assert(pawn != null, "the recipe output was not exactly one Pawn");
            ctx.Assert(pawn.kindDef.defName == pawnKindDefName, $"expected {pawnKindDefName}, got {pawn.kindDef.defName}");
            ctx.Assert(pawn.Faction == Faction.OfPlayer, "the cloned pawn did not join the player faction");
        }

        [When("Ancient Chinese Beast: I display the recipe output at x={int} z={int}")]
        public void DisplayRecipeOutput(PickleContext ctx, int x, int z)
        {
            var products = Stage.RecipeProducts(ctx);
            ctx.Assert(products != null && products.Count > 0, "make a recipe before displaying its output");
            var map = Map(ctx);
            foreach (var product in products)
            {
                ctx.Assert(!product.Spawned, "a recipe product was already spawned before review placement");
                GenSpawn.Spawn(product, new IntVec3(x, 0, z), map);
            }
        }

        [Then("Ancient Chinese Beast: the year-beast debug flag is set")]
        public void YearBeastFlagIsSet(PickleContext ctx)
        {
            var type = GenTypes.GetTypeInAnyAssembly("AncientChineseBeast.Singleton");
            var singleton = type?.GetField("instance", BindingFlags.Public | BindingFlags.Static)?.GetValue(null);
            var field = type?.GetField("YearBeastForced", BindingFlags.Public | BindingFlags.Instance);
            ctx.Assert(field != null, "YearBeastForced field was not loaded");
            var flag = field.GetValue(singleton) as bool?;
            ctx.Assert(flag == true, "ForceYearBeast did not set Singleton.YearBeastForced");
        }

        // The tunnel scenario waits up to 90 seconds for the sexie to come out; the step's own deadline has to be
        // longer than the longest wait a scenario asks for, or the engine cuts it off at 35 s (it did, first run).
        [Then("Ancient Chinese Beast: a {string} pawn exists within {int} seconds", TimeoutSeconds = 100f)]
        public async Task PawnExists(PickleContext ctx, string defName, int seconds)
        {
            var map = Map(ctx);
            try { await ctx.WaitUntil(() => map.mapPawns.AllPawnsSpawned.Any(p => p.def.defName == defName), seconds); }
            catch (Exception) { }
            ctx.Assert(map.mapPawns.AllPawnsSpawned.Any(p => p.def.defName == defName),
                $"no spawned pawn has defName {defName}");
        }

        [Then("Ancient Chinese Beast: a {string} or {string} pawn exists within {int} seconds", TimeoutSeconds = 35f)]
        public async Task OneOfPawnExists(PickleContext ctx, string firstDefName, string secondDefName, int seconds)
        {
            var map = Map(ctx);
            bool Exists() => map.mapPawns.AllPawnsSpawned.Any(p => p.def.defName == firstDefName || p.def.defName == secondDefName);
            try { await ctx.WaitUntil(Exists, seconds); }
            catch (Exception) { }
            ctx.Assert(Exists(), $"no spawned pawn has defName {firstDefName} or {secondDefName}");
        }

        [Then("Ancient Chinese Beast: no living {string} pawn exists within {int} seconds", TimeoutSeconds = 35f)]
        public async Task NoLivingPawnExists(PickleContext ctx, string defName, int seconds)
        {
            var map = Map(ctx);
            bool Absent() => !map.mapPawns.AllPawnsSpawned.Any(p => p.def.defName == defName && !p.Dead);
            try { await ctx.WaitUntil(Absent, seconds); }
            catch (Exception) { }
            ctx.Assert(Absent(), $"a living {defName} pawn remained after the staged behavior");
        }

        [Then("Ancient Chinese Beast: the qiongqi lands at x={int} z={int} within {int} seconds", TimeoutSeconds = 35f)]
        public async Task QiongQiLands(PickleContext ctx, int x, int z, int seconds)
        {
            var cell = new IntVec3(x, 0, z); var map = Map(ctx);
            try { await ctx.WaitUntil(() => cell.GetThingList(map).OfType<Pawn>().Any(p => p.def.defName == "SZ_QiongQi"), seconds); }
            catch (Exception) { }
            ctx.Assert(cell.GetThingList(map).OfType<Pawn>().Any(p => p.def.defName == "SZ_QiongQi"), "qiongqi never landed at the flight destination");
        }
    }
}
