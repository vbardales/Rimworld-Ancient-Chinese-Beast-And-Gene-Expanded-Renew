using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RimWorks.Pickle;
using RimWorld;
using Verse;
using Verse.AI;

namespace AncientChineseBeast.PickleSteps
{
    // M5 and the "furthest shooter" half of M3 of Tests/Pickle/README.md's manual exceptions: what the beasts' own AI
    // decides. The nian beast that cannot reach a colonist indoors attacks the building in its way
    // (JobGiver_KillHuman_RangedAbility, FirstBlockingBuilding); the qiongqi's flying strike goes to the farthest
    // colonist it can hit (CompQiongQiAIExpansion). Neither is forced: the pieces are placed, the AI plays.
    [PickleSteps]
    public sealed class SiegeSteps
    {
        private static Pawn Nth(PickleContext ctx, int number)
        {
            var list = SpawnSteps.TryGet(ctx);
            ctx.Assert(list != null && number >= 1 && number <= list.Pawns.Count,
                $"no pawn number {number}: this scenario spawned {list?.Pawns.Count ?? 0}");
            return list.Pawns[number - 1];
        }

        // A 5 x 5 ring of steel walls with a wooden door on its south side and a colonist in the middle. The ring's
        // pieces are remembered so that a later step can say whether any of them was breached.
        [When("Ancient Chinese Beast: I wall in a colonist behind a wooden door, centred at x={int} z={int}")]
        public void WallIn(PickleContext ctx, int cx, int cz)
        {
            var map = Stage.CurrentMap(ctx);
            var enclosure = new Enclosure();
            for (int dx = -2; dx <= 2; dx++)
                for (int dz = -2; dz <= 2; dz++)
                {
                    if (System.Math.Abs(dx) != 2 && System.Math.Abs(dz) != 2) continue;
                    var cell = new IntVec3(cx + dx, 0, cz + dz);
                    ctx.Assert(cell.InBounds(map), $"the enclosure leaves the map at {cell}");
                    bool door = dx == 0 && dz == -2;
                    var thing = door
                        ? ThingMaker.MakeThing(ThingDefOf.Door, ThingDefOf.WoodLog)
                        : ThingMaker.MakeThing(ThingDefOf.Wall, ThingDefOf.Steel);
                    thing.SetFaction(Faction.OfPlayer);
                    GenSpawn.Spawn(thing, cell, map);
                    ctx.Assert(thing.Spawned, $"{thing.def.defName} did not spawn at {cell}");
                    (door ? enclosure.Doors : enclosure.Walls).Add(thing);
                }
            ctx.Set(enclosure);
            var pawn = PawnGenerator.GeneratePawn(new PawnGenerationRequest(PawnKindDefOf.Colonist, Faction.OfPlayer, forceGenerateNewPawn: true));
            GenSpawn.Spawn(pawn, new IntVec3(cx, 0, cz), map);
            ctx.Assert(pawn.Spawned, "the walled-in colonist did not spawn");
            SpawnSteps.Remember(ctx, pawn);
        }

        [Then("Ancient Chinese Beast: the enclosure is breached within {int} seconds", TimeoutSeconds = 170f)]
        public async Task Breached(PickleContext ctx, int seconds)
        {
            var enclosure = ctx.Get<Enclosure>();
            bool Breached() => enclosure.All().Any(t => t.Destroyed || t.HitPoints < t.MaxHitPoints);
            await Stage.WaitGameSeconds(ctx, Breached, seconds);
            var hit = enclosure.All().FirstOrDefault(t => t.Destroyed || t.HitPoints < t.MaxHitPoints);
            ctx.Attach("what was breached", hit == null ? "nothing" : $"{hit.def.defName} at {hit.Position}: {(hit.Destroyed ? "destroyed" : hit.HitPoints + "/" + hit.MaxHitPoints)}");
            ctx.Assert(hit != null, $"nothing of the enclosure was touched; {Stage.LastWaitReport}");
            ctx.Assert(enclosure.Doors.Any(t => t.Destroyed || t.HitPoints < t.MaxHitPoints), $"the beast went for {hit?.def.defName} and not for the door: the wall was the way it found");
        }

        // The flying strike is decided on a one-second tick and queued as an ability job whose first target is the
        // pawn chosen; the step reads that job rather than waiting for the landing, which a colonist can move under.
        [Then("Ancient Chinese Beast: the qiongqi pawn {int} sets its flying strike on pawn {int} within {int} seconds", TimeoutSeconds = 90f)]
        public async Task StrikesFarthest(PickleContext ctx, int qiongqiNumber, int targetNumber, int seconds)
        {
            var qiongqi = Nth(ctx, qiongqiNumber);
            var expected = Nth(ctx, targetNumber);
            Thing Chosen()
            {
                var job = qiongqi.CurJob;
                return job != null && job.ability != null ? job.targetA.Thing : null;
            }
            await Stage.WaitGameSeconds(ctx, () => Chosen() != null, seconds);
            var chosen = Chosen();
            ctx.Assert(chosen != null, $"the qiongqi never started a flying strike; {Stage.LastWaitReport}");
            ctx.Attach("flying strike target", $"{chosen} at {chosen.Position}, {qiongqi.Position.DistanceTo(chosen.Position):F1} tiles from the qiongqi");
            ctx.Assert(chosen == expected, $"the qiongqi flew at {chosen}, not at the farthest colonist {expected}");
        }
    }

    internal sealed class Enclosure
    {
        public List<Thing> Walls = new List<Thing>();
        public List<Thing> Doors = new List<Thing>();
        public IEnumerable<Thing> All() => Walls.Concat(Doors);
    }
}
