using System.Diagnostics;
using System.Threading.Tasks;
using RimWorks.Pickle;
using Verse;

namespace AncientChineseBeast.PickleSteps
{
    // Pickle's own "the main menu is open" gives the game five seconds to be there. With a second beast mod in the load
    // order (the pass of feature 13 stages the original) the defs take longer to load, and the first full pass ran
    // out of those five seconds (2026-10-02). This waits for the same state, in real time and frame by frame (no tick
    // passes in the menu), for as long as the scenario asks.
    [PickleSteps]
    public sealed class MenuSteps
    {
        [Given("Ancient Chinese Beast: the main menu is open within {int} seconds", TimeoutSeconds = 150f)]
        public async Task MenuOpen(PickleContext ctx, int seconds)
        {
            var clock = Stopwatch.StartNew();
            while (clock.Elapsed.TotalSeconds < seconds && !(Current.ProgramState == ProgramState.Entry && !LongEventHandler.AnyEventNowOrWaiting))
                await ctx.WaitFrames(5);
            ctx.Assert(Current.ProgramState == ProgramState.Entry && !LongEventHandler.AnyEventNowOrWaiting,
                $"the main menu is not open after {clock.Elapsed.TotalSeconds:F0} real seconds (program state {Current.ProgramState})");
        }
    }
}
