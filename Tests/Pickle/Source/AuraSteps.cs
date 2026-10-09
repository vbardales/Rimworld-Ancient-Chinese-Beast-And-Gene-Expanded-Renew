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

        [Then("Ancient Chinese Beast: pawn {int} goes berserk within {int} seconds", TimeoutSeconds = 450f)]
        public async Task GoesBerserk(PickleContext ctx, int number, int seconds)
        {
            var pawn = Nth(ctx, number);
            await Stage.WaitGameSeconds(ctx, () => Berserk(pawn), seconds, 400);
            ctx.Assert(Berserk(pawn), $"pawn {number} is not berserk (state {pawn.MentalStateDef?.defName ?? "none"}, {pawn.Position}); {Stage.LastWaitReport}");
        }

        // Staging for a photograph: the aura itself is played by feature 04 (green). The gallery's scene cannot spend the
        // 2400 ticks the ring needs, the launcher's watchdog stops a scenario after 300 real seconds (gallery 6, 2026-10-09,
        // twice), so the colonist is sent berserk the way the ring does it and the picture shows the result.
        [When("Ancient Chinese Beast: pawn {int} is sent berserk as the aura does")]
        public void SentBerserk(PickleContext ctx, int number)
        {
            var pawn = Nth(ctx, number);
            ctx.Assert(pawn.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.Berserk, null, forced: true), $"pawn {number} refused the berserk state");
        }
        // The aura clock is set by the spawn step, before the first tick: "I spawn the pawn ... with its aura clock at zero" (SpawnSteps).
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
