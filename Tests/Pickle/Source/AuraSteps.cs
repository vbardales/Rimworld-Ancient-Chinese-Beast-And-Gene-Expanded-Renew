using System.Threading.Tasks;
using RimWorks.Pickle;
using RimWorld;
using Verse;

namespace AncientChineseBeast.PickleSteps
{
    // M4 of Tests/Pickle/README.md's manual exceptions: the scorpion sexie's aura (CompSeXieExpansion.BerserkRing)
    // sends every humanlike within 10.9 tiles that has any psychic sensitivity berserk. The ring's cadence is
    // internal; what a person would watch is who is berserk and who is not, so that is what is asserted.
    [PickleSteps]
    public sealed class AuraSteps
    {
        private static Pawn Nth(PickleContext ctx, int number)
        {
            var list = SpawnSteps.TryGet(ctx);
            ctx.Assert(list != null && number >= 1 && number <= list.Pawns.Count,
                $"no pawn number {number}: this scenario spawned {list?.Pawns.Count ?? 0}");
            return list.Pawns[number - 1];
        }

        private static bool Berserk(Pawn pawn) => pawn.InMentalState && pawn.MentalStateDef == MentalStateDefOf.Berserk;

        [Then("Ancient Chinese Beast: pawn {int} goes berserk within {int} seconds", TimeoutSeconds = 170f)]
        public async Task GoesBerserk(PickleContext ctx, int number, int seconds)
        {
            var pawn = Nth(ctx, number);
            await Stage.WaitGameSeconds(ctx, () => Berserk(pawn), seconds);
            ctx.Assert(Berserk(pawn), $"pawn {number} is not berserk (state {pawn.MentalStateDef?.defName ?? "none"}, {pawn.Position}); {Stage.LastWaitReport}");
        }

        // CompSeXieExpansion does two things: every tick it sends the humanlikes within 10.9 tiles berserk (a list it takes
        // when its private counter is a multiple of 1800), and each time the counter passes 3600 it sends the most
        // psychically sensitive colonist of the whole map berserk, wherever they stand. The counter starts at 3600, so
        // both act on the first tick, and the second cannot tell a far colonist from the ring. Setting the counter to
        // 0 takes the ring's list on the first tick and puts the map-wide pick 3600 ticks off (it was 1800 until 2026-10-01, which a slow wait of 30 game seconds could reach: the far colonist went berserk by the map-wide pick in the first full pass), which is what lets a scenario see the ring alone.
        [When("Ancient Chinese Beast: the aura clock of pawn {int} is set to leave only the ring")]
        public void ClockForRingOnly(PickleContext ctx, int number)
        {
            var beast = Nth(ctx, number);
            var comp = beast.GetComp<CompSeXieExpansion>();
            ctx.Assert(comp != null, $"{beast.def.defName} has no CompSeXieExpansion");
            var field = typeof(CompSeXieExpansion).GetField("ticks", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            ctx.Assert(field != null, "CompSeXieExpansion.ticks was not found");
            field.SetValue(comp, 0);
        }

        [Then("Ancient Chinese Beast: pawn {int} is not berserk")]
        public void IsNotBerserk(PickleContext ctx, int number)
        {
            var pawn = Nth(ctx, number);
            ctx.Assert(!Berserk(pawn), $"pawn {number} is berserk at {pawn.Position}, outside the ring");
        }

        [Then("Ancient Chinese Beast: pawn {int} is more than {int} tiles from pawn {int}")]
        public void FartherThan(PickleContext ctx, int a, int tiles, int b)
        {
            float distance = Nth(ctx, a).Position.DistanceTo(Nth(ctx, b).Position);
            ctx.Assert(distance > tiles, $"pawns {a} and {b} are {distance} tiles apart, not more than {tiles}: the scenario's far colonist is not far");
        }
    }
}
