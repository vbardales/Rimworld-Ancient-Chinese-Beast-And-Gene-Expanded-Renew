using System.Linq;
using System.Threading.Tasks;
using RimWorks.Pickle;
using RimWorld;
using Verse;

namespace AncientChineseBeast.PickleSteps
{
    // M6 of Tests/Pickle/README.md's manual exceptions: 08 and 12 make a recipe's products through
    // GenRecipe.MakeRecipeProducts, which skips the job chain. Here a colonist does it the way a player's colony
    // would: the research is finished, the bench stands powered, a bill is on it, a beast corpse lies on the
    // ground, and the colonist's own work giver finds the bill, hauls the corpse to the bench and works it to the
    // end. Nothing is forced past the placing of the pieces.
    [PickleSteps]
    public sealed class BenchSteps
    {
        [Given("Ancient Chinese Beast: the research {string} is finished")]
        public void ResearchFinished(PickleContext ctx, string projectDefName)
        {
            var project = DefDatabase<ResearchProjectDef>.GetNamedSilentFail(projectDefName);
            ctx.Assert(project != null, $"no ResearchProjectDef named {projectDefName}");
            Find.ResearchManager.FinishProject(project, doCompletionDialog: false, researcher: null, doCompletionLetter: false);
            ctx.Assert(project.IsFinished, $"{projectDefName} is not finished");
        }

        // A bench that needs power gets it by switching its trader on after it spawns: the scenario is about the work,
        // not about wiring a generator, and an unconnected trader keeps the state it was given.
        [When("Ancient Chinese Beast: I place a powered {string} of the player's centred at x={int} z={int}")]
        public void PlacePowered(PickleContext ctx, string defName, int x, int z)
        {
            var map = Stage.CurrentMap(ctx);
            var def = DefDatabase<ThingDef>.GetNamedSilentFail(defName);
            ctx.Assert(def != null, $"no ThingDef named {defName}");
            var thing = ThingMaker.MakeThing(def);
            thing.SetFactionDirect(Faction.OfPlayer);
            GenSpawn.Spawn(thing, new IntVec3(x, 0, z), map, Rot4.South);
            ctx.Assert(thing.Spawned, $"{defName} did not spawn at x={x} z={z}");
            var power = thing.TryGetComp<CompPowerTrader>();
            if (power != null) power.PowerOn = true;
        }

        [When("Ancient Chinese Beast: I put the bill {string} on the {string}")]
        public void PutBill(PickleContext ctx, string recipeDefName, string benchDefName)
        {
            var map = Stage.CurrentMap(ctx);
            var recipe = DefDatabase<RecipeDef>.GetNamedSilentFail(recipeDefName);
            ctx.Assert(recipe != null, $"no RecipeDef named {recipeDefName}");
            var bench = Stage.ThingsOfDef(map, benchDefName).OfType<Building_WorkTable>().FirstOrDefault();
            ctx.Assert(bench != null, $"no {benchDefName} bench on the map");
            var bill = (Bill_Production)recipe.MakeNewBill();
            bill.repeatMode = BillRepeatModeDefOf.RepeatCount;
            bill.repeatCount = 1;
            bench.BillStack.AddBill(bill);
            ctx.Assert(bench.BillStack.Count == 1, "the bill was not added to the bench");
        }

        [Then("Ancient Chinese Beast: at least {int} {string} lie on the map within {int} seconds", TimeoutSeconds = 170f)]
        public async Task AtLeastOnMap(PickleContext ctx, int count, string defName, int seconds)
        {
            var map = Stage.CurrentMap(ctx);
            int Held() => Stage.ThingsOfDef(map, defName).Sum(t => t.stackCount);
            await Stage.WaitGameSeconds(ctx, () => Held() >= count, seconds);
            ctx.Assert(Held() >= count, $"{Held()} {defName} on the map, expected at least {count}; {Stage.LastWaitReport}");
        }
    }
}
