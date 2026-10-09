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
    // (JobGiver_KillHuman_RangedAbility, FirstBlockingBuilding), which is whichever wall or door FindPathNow's shortest
    // path meets first, not necessarily the door: a colonist aligned with the door still saw a side wall attacked first
    // (run e5b4, 2026-09-28), so the scenario checks that some piece of the enclosure gives, not that it is the door.
    // The qiongqi's flying strike goes to the farthest colonist it can hit (CompQiongQiAIExpansion). Neither is forced:
    // the pieces are placed, the AI plays.
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

        // JobGiver_KillHuman.FindPawnTarget looks at the colonists the beast can reach and only when there is none does it
        // fall back to the unreachable ones, so with the colony's own colonists on the map a walled-in colonist is never the
        // target and nothing is ever broken (run be5e, 2026-09-28: nothing touched in 3261 ticks). The scenario removes every
        // colonist but the ones it spawned, which is the situation the door-breaking branch exists for.
        [When("Ancient Chinese Beast: I remove every colonist I did not spawn")]
        public void RemoveOtherColonists(PickleContext ctx)
        {
            var map = Stage.CurrentMap(ctx);
            var mine = SpawnSteps.TryGet(ctx)?.Pawns ?? new List<Pawn>();
            foreach (var pawn in map.mapPawns.FreeColonistsSpawned.Where(p => !mine.Contains(p)).ToList())
                pawn.Destroy(DestroyMode.Vanish);
            ctx.Assert(map.mapPawns.FreeColonistsSpawned.All(p => mine.Contains(p)), "a colonist that the scenario did not spawn is still on the map");
        }

        [Then("Ancient Chinese Beast: the enclosure is breached within {int} seconds", TimeoutSeconds = 450f)]
        public async Task Breached(PickleContext ctx, int seconds)
        {
            var enclosure = ctx.Get<Enclosure>();
            bool Breached() => enclosure.All().Any(t => t.Destroyed || t.HitPoints < t.MaxHitPoints);
            await Stage.WaitGameSeconds(ctx, Breached, seconds, 400);
            var hit = enclosure.All().FirstOrDefault(t => t.Destroyed || t.HitPoints < t.MaxHitPoints);
            ctx.Attach("what was breached", hit == null ? "nothing" : $"{hit.def.defName} at {hit.Position}: {(hit.Destroyed ? "destroyed" : hit.HitPoints + "/" + hit.MaxHitPoints)}");
            if (hit == null)
            {
                var map = Stage.CurrentMap(ctx);
                var beast = map.mapPawns.AllPawnsSpawned.FirstOrDefault(p => p.def.defName == "SZ_YearBeast");
                var colonist = map.mapPawns.FreeColonistsSpawned.FirstOrDefault();
                string beastState = beast == null ? "no nian beast on the map"
                    : $"nian at {beast.Position}, job {beast.CurJob?.def.defName ?? "none"}, mind target {beast.mindState.enemyTarget}, " +
                      $"downed {beast.Downed}, dead {beast.Dead}, awake {beast.Awake()}";
                string colonistState = colonist == null ? "no colonist on the map"
                    : $"colonist at {colonist.Position}, spawned {colonist.Spawned}, reachable from beast {(beast != null && beast.CanReach(colonist.PositionHeld, PathEndMode.OnCell, Danger.Deadly, canBashDoors: false, canBashFences: false, TraverseMode.PassAllDestroyableThings))}";
                ctx.Attach("beast diagnostic", beastState + "; " + colonistState);
            }
            ctx.Assert(hit != null, $"nothing of the enclosure was touched; {Stage.LastWaitReport}");
        }

        // The flying strike is decided on a one-second tick and queued as an ability job whose first target is the
        // pawn chosen; the step reads that job rather than waiting for the landing, which a colonist can move under.
        [Then("Ancient Chinese Beast: the qiongqi pawn {int} sets its flying strike on pawn {int} within {int} seconds", TimeoutSeconds = 450f)]
        public async Task StrikesFarthest(PickleContext ctx, int qiongqiNumber, int targetNumber, int seconds)
        {
            // The qiongqi casts in one tick (warmup 0): the ability job exists for a single tick, so the wait looks at every tick, not every five (run 2026-10-08c: cooldown 825 left, the strike had happened, the step saw nothing). It used to be cut by the
            // runner at 90, before 40 game seconds had passed (run bd0f, 2026-10-02: "timed out after 90s").
            var qiongqi = Nth(ctx, qiongqiNumber);
            var expected = Nth(ctx, targetNumber);
            Thing Chosen()
            {
                var job = qiongqi.CurJob;
                return job != null && job.ability != null ? job.targetA.Thing : null;
            }
            await Stage.WaitGameSeconds(ctx, () => Chosen() != null, seconds, 400, 1);
            var chosen = Chosen();
            if (chosen == null)
            {
                // What the AI comp needs: CanCast, and a target the verb accepts (range 30.9 and a line of sight).
                var ability = qiongqi.abilities?.GetAbility(DefDatabase<AbilityDef>.GetNamedSilentFail("SZ_QiongQi_FlyingStrike"));
                var sight = string.Join("; ", Nth(ctx, 1).Map.mapPawns.AllPawns.Where(p => p != qiongqi && !p.Downed).Select(p =>
                    $"{p.LabelShort} at {p.Position} {qiongqi.Position.DistanceTo(p.Position):F1} tiles, can hit {(ability != null && ability.VerbTracker.PrimaryVerb.CanHitTarget(p))}"));
                ctx.Attach("flying strike diagnostic", $"ability {(ability == null ? "missing" : "found")}, can cast {ability?.CanCast}, " +
                    $"cooldown ticks left {ability?.CooldownTicksRemaining}, qiongqi at {qiongqi.Position}, faction {qiongqi.Faction?.Name ?? "none"}, " +
                    $"job {qiongqi.CurJob?.def.defName ?? "none"}; {sight}");
            }
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
        public IEnumerable<IntVec3> Cells() => All().Select(t => t.Position);
    }
}
