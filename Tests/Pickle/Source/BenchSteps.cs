using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RimWorks.Pickle;
using RimWorld;
using Verse;
using Verse.AI;

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
            var center = new IntVec3(x, 0, z);
            // The first M6 runs (2026-09-28) placed the extractor at (156, 146): its interaction cell, three cells south of the
            // centre, was not standable and the colonist could not reach it, so no job was ever offered. Take the nearest centre
            // whose whole footprint and interaction cell are standable, and say which one was taken.
            var found = false;
            // RadialCellsAround lists the cells from the nearest to the farthest.
            foreach (var c in GenRadial.RadialCellsAround(center, 30f, true))
            {
                if (!c.InBounds(map)) continue;
                var rect = GenAdj.OccupiedRect(c, Rot4.South, def.size);
                var interaction = ThingUtility.InteractionCellWhenAt(def, c, Rot4.South, map);
                if (rect.Cells.All(cell => cell.InBounds(map) && cell.Standable(map) && cell.GetEdifice(map) == null)
                    && interaction.InBounds(map) && interaction.Standable(map))
                {
                    center = c; found = true; break;
                }
            }
            ctx.Assert(found, $"no place within 30 cells of x={x} z={z} holds a {defName} with a standable interaction cell");
            ctx.Attach("bench placement", $"asked for ({x}, {z}), placed at {center}");
            GenSpawn.Spawn(thing, center, map, Rot4.South);
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

        // Let the game run a while with no condition, so that a scenario can look at a state part of the way through.
        [When("Ancient Chinese Beast: the game runs for {int} seconds", TimeoutSeconds = 170f)]
        public async Task GameRuns(PickleContext ctx, int seconds)
        {
            await Stage.WaitGameSeconds(ctx, () => false, seconds);
        }

        // Why a bill is not being worked, written into the report: every check the work giver makes, read off the
        // bench, the bill, the colonist and the corpse. Attached, not asserted: it is there for the day a run is red.
        [Then("Ancient Chinese Beast: I attach why pawn {int} is or is not working the bill on the {string}")]
        public void AttachBillState(PickleContext ctx, int number, string benchDefName)
        {
            var map = Stage.CurrentMap(ctx);
            var list = SpawnSteps.TryGet(ctx);
            ctx.Assert(list != null && number >= 1 && number <= list.Pawns.Count, $"no pawn number {number}");
            var pawn = list.Pawns[number - 1];
            var bench = Stage.ThingsOfDef(map, benchDefName).OfType<Building_WorkTable>().FirstOrDefault();
            ctx.Assert(bench != null, $"no {benchDefName} bench on the map");
            var lines = new List<string>();
            var power = bench.GetComp<CompPowerTrader>();
            lines.Add($"bench at {bench.Position}, interaction cell {bench.InteractionCell}, power on {power?.PowerOn}, usable for bills {bench.CurrentlyUsableForBills()}");
            var bill = bench.BillStack.Bills.FirstOrDefault();
            if (bill == null) lines.Add("no bill on the bench");
            else lines.Add($"bill {bill.recipe.defName}: should do now {bill.ShouldDoNow()}, recipe available now {bill.recipe.AvailableNow}, suspended {bill.suspended}");
            var workType = DefDatabase<WorkTypeDef>.GetNamed("Smithing");
            lines.Add($"pawn {pawn.LabelShort} at {pawn.Position}, job {pawn.CurJob?.def.defName ?? "none"}, awake {pawn.Awake()}, drafted {pawn.Drafted}, in mental state {pawn.InMentalState}");
            lines.Add($"Smithing disabled {pawn.WorkTypeIsDisabled(workType)}, priority {pawn.workSettings?.GetPriority(workType)}, schedule {pawn.timetable?.CurrentAssignment?.defName}");
            var giverDef = DefDatabase<WorkGiverDef>.GetNamedSilentFail("SZ_DoBeastGeneExtractor");
            var giver = giverDef?.Worker as WorkGiver_Scanner;
            lines.Add($"work giver {(giver == null ? "missing" : "found")}: has job {giver?.HasJobOnThing(pawn, bench, false)}, skips {giver?.ShouldSkip(pawn, false)}");
            lines.Add($"bench: reservable {pawn.CanReserve(bench)}, forbidden {bench.IsForbidden(pawn)}, interaction cell standable {bench.InteractionCell.Standable(map)}, reach interaction cell {pawn.CanReach(bench, PathEndMode.InteractionCell, Danger.Some)}");
            if (bill != null)
            {
                lines.Add($"bill: pawn allowed to start {bill.PawnAllowedToStartAnew(pawn)}, skill requirements met {bill.recipe.PawnSatisfiesSkillRequirements(pawn)}, radius {bill.ingredientSearchRadius}");
                foreach (var corpse in map.listerThings.ThingsInGroup(ThingRequestGroup.Corpse).OfType<Corpse>())
                    lines.Add($"corpse {corpse.def.defName}: fixed or allowed {bill.IsFixedOrAllowedIngredient(corpse)}, bill filter {bill.ingredientFilter.Allows(corpse)}, recipe fixed filter {bill.recipe.fixedIngredientFilter?.Allows(corpse)}, ingredient filter {bill.recipe.ingredients.Any(ig => ig.filter.Allows(corpse))}, distance to bench {(corpse.Position - bench.Position).LengthHorizontal:F1}");
            }
            foreach (var corpse in map.listerThings.ThingsInGroup(ThingRequestGroup.Corpse).OfType<Corpse>())
                lines.Add($"corpse {corpse.def.defName} at {corpse.Position}, forbidden {corpse.IsForbidden(pawn)}, reachable {pawn.CanReach(corpse, PathEndMode.Touch, Danger.Deadly)}, reservable {pawn.CanReserve(corpse)}");
            ctx.Attach("bill diagnostic", string.Join("\n", lines));
        }

        [Then("Ancient Chinese Beast: at least {int} {string} lie on the map within {int} seconds", TimeoutSeconds = 450f)]
        public async Task AtLeastOnMap(PickleContext ctx, int count, string defName, int seconds)
        {
            var map = Stage.CurrentMap(ctx);
            int Held() => Stage.ThingsOfDef(map, defName).Sum(t => t.stackCount);
            await Stage.WaitGameSeconds(ctx, () => Held() >= count, seconds, 400);
            ctx.Assert(Held() >= count, $"{Held()} {defName} on the map, expected at least {count}; {Stage.LastWaitReport}");
        }
    }
}
