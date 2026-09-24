using System;
using System.Linq;
using RimWorks.Pickle;
using Verse;

namespace AncientChineseBeast.PickleSteps
{
    // A Dog Said... Animal Prosthetics 2 (SamBucher.ADogSaidAnimalProsthetics2) puts a surgery recipe on a race
    // by listing the race in one of its category defs, and copies those lists onto the recipes once, when its
    // own patch runs. What this mod's patch achieved is therefore visible in one place only: the recipe list the
    // game holds on the race. A recipe that is not defined at all would make "does not offer" pass for the wrong
    // reason, so every step first insists that the recipe exists.
    [PickleSteps]
    public sealed class AnimalProstheticsSteps
    {
        private static ThingDef Race(PickleContext ctx, string defName)
        {
            var race = DefDatabase<ThingDef>.GetNamedSilentFail(defName);
            ctx.Assert(race != null, $"no ThingDef named {defName}");
            return race;
        }

        private static bool Offers(PickleContext ctx, ThingDef race, string recipeDefName)
        {
            ctx.Assert(DefDatabase<RecipeDef>.GetNamedSilentFail(recipeDefName) != null,
                $"no RecipeDef named {recipeDefName}: the other mod does not define it in this version");
            return race.AllRecipes.Any(recipe => recipe.defName == recipeDefName);
        }

        private static void AssertOffers(PickleContext ctx, string raceDefName, params string[] recipes)
        {
            var race = Race(ctx, raceDefName);
            foreach (var recipe in recipes)
                ctx.Assert(Offers(ctx, race, recipe), $"{raceDefName} does not offer {recipe}");
        }

        [Then("Ancient Chinese Beast: the race {string} offers the recipes {string}, {string} and {string}")]
        public void OffersThree(PickleContext ctx, string race, string first, string second, string third)
            => AssertOffers(ctx, race, first, second, third);

        [Then("Ancient Chinese Beast: the race {string} offers the recipes {string} and {string}")]
        public void OffersTwo(PickleContext ctx, string race, string first, string second)
            => AssertOffers(ctx, race, first, second);

        [Then("Ancient Chinese Beast: the race {string} does not offer the recipe {string}")]
        public void DoesNotOffer(PickleContext ctx, string raceDefName, string recipe)
            => ctx.Assert(!Offers(ctx, Race(ctx, raceDefName), recipe), $"{raceDefName} offers {recipe}, and should not");

        [Then("Ancient Chinese Beast: the mod {string} loads before {string}")]
        public void LoadsBefore(PickleContext ctx, string earlierId, string laterId)
        {
            var running = LoadedModManager.RunningModsListForReading;
            int Index(string id) => running.FindIndex(m => string.Equals(m.PackageIdPlayerFacing, id, StringComparison.OrdinalIgnoreCase));
            int earlier = Index(earlierId), later = Index(laterId);
            ctx.Assert(earlier >= 0 && later >= 0, $"both {earlierId} and {laterId} must be running (positions {earlier} and {later})");
            ctx.Assert(earlier < later, $"{earlierId} loads at {earlier}, after {laterId} at {later}: the category lists were copied before it added its races");
        }
    }
}
