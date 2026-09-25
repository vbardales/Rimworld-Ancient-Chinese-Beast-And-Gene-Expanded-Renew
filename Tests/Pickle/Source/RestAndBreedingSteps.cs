using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using RimWorks.Pickle;
using RimWorld;
using Verse;
using Verse.AI;

namespace AncientChineseBeast.PickleSteps
{
    // The beasts rest and breed. Everything here goes through the game's own paths: the need, the LayDown job the
    // vanilla think tree gives a tired animal, the Mate job, the pregnancy hediff and its birth, the egg layer and the
    // hatcher. Where a scenario could not wait a real gestation or a real egg (days of game time) it brings the
    // last value of the counter to just below completion and lets the game finish it, which is what the DEV
    // gizmos of the vanilla spawners do too. Waits are in game time (Stage.WaitGameSeconds).
    [PickleSteps]
    public sealed class RestAndBreedingSteps
    {
        private static Pawn Nth(PickleContext ctx, int number)
        {
            var list = SpawnSteps.TryGet(ctx);
            ctx.Assert(list != null && number >= 1 && number <= list.Pawns.Count,
                $"no pawn number {number}: this scenario spawned {list?.Pawns.Count ?? 0}");
            return list.Pawns[number - 1];
        }

        private static bool Asleep(Pawn pawn) => pawn.CurJob?.def == JobDefOf.LayDown || !pawn.Awake();

        [Then("Ancient Chinese Beast: pawn {int} has a rest need")]
        public void HasRestNeed(PickleContext ctx, int number)
        {
            var pawn = Nth(ctx, number);
            ctx.Assert(pawn.needs?.rest != null, $"{pawn.def.defName} has no rest need");
        }

        [When("Ancient Chinese Beast: the rest of pawn {int} is set to {float}")]
        public void SetRest(PickleContext ctx, int number, float level)
        {
            var pawn = Nth(ctx, number);
            ctx.Assert(pawn.needs?.rest != null, $"{pawn.def.defName} has no rest need to set");
            pawn.needs.rest.CurLevel = level;
        }

        [Then("Ancient Chinese Beast: pawn {int} is asleep within {int} seconds", TimeoutSeconds = 100f)]
        public async Task IsAsleep(PickleContext ctx, int number, int seconds)
        {
            var pawn = Nth(ctx, number);
            await Stage.WaitGameSeconds(ctx, () => Asleep(pawn), seconds);
            ctx.Assert(Asleep(pawn), $"{pawn.def.defName} is not asleep (job {pawn.CurJob?.def?.defName ?? "none"}, rest {pawn.needs?.rest?.CurLevel})");
        }

        // The male walks to the female and mates, through the real job. The think tree does this by chance every so
        // many hours (mateMtbHours); the scenario asks for it so that it does not depend on the roll.
        [When("Ancient Chinese Beast: pawn {int} mates with pawn {int}")]
        public void Mate(PickleContext ctx, int maleNumber, int femaleNumber)
        {
            var male = Nth(ctx, maleNumber);
            var female = Nth(ctx, femaleNumber);
            ctx.Assert(male.gender == Gender.Male && female.gender == Gender.Female, $"pawn {maleNumber} is {male.gender} and pawn {femaleNumber} is {female.gender}");
            ctx.Assert(male.ageTracker.CurLifeStage.reproductive && female.ageTracker.CurLifeStage.reproductive, "both must be adults");
            ctx.Assert(PawnUtility.FertileMateTarget(male, female), "the game says the two cannot mate: " + WhyNot(male, female));
            var job = JobMaker.MakeJob(JobDefOf.Mate, female);
            male.jobs.StartJob(job, JobCondition.InterruptForced);
        }

        // Where a pawn is and what it is doing, for the message of a wait that ran out.
        private static string Describe(Pawn pawn)
            => $"{pawn.def.defName} at {pawn.Position}, job {pawn.CurJob?.def?.defName ?? "none"}, spawned {pawn.Spawned}, downed {pawn.Downed}, rest {pawn.needs?.rest?.CurLevelPercentage.ToString("F2") ?? "none"}";

        private static string WhyNot(Pawn male, Pawn female)
            => $"male {male.def.defName} {male.gender} stage {male.ageTracker.CurLifeStage.defName}, female {female.def.defName} {female.gender} stage {female.ageTracker.CurLifeStage.defName}";

        [Then("Ancient Chinese Beast: pawn {int} is pregnant within {int} seconds", TimeoutSeconds = 100f)]
        public async Task IsPregnant(PickleContext ctx, int number, int seconds)
        {
            var pawn = Nth(ctx, number);
            await Stage.WaitGameSeconds(ctx, () => pawn.health.hediffSet.HasHediff(HediffDefOf.Pregnant), seconds);
            ctx.Assert(pawn.health.hediffSet.HasHediff(HediffDefOf.Pregnant), $"{pawn.def.defName} is not pregnant; {Stage.LastWaitReport}; the male: {Describe(Nth(ctx, 1))}, the female: {Describe(pawn)}");
        }

        [When("Ancient Chinese Beast: the pregnancy of pawn {int} is due now")]
        public void PregnancyDue(PickleContext ctx, int number)
        {
            var pawn = Nth(ctx, number);
            var pregnancy = pawn.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.Pregnant);
            ctx.Assert(pregnancy != null, $"{pawn.def.defName} is not pregnant");
            // Just below 1: the next tick of the hediff carries it over and the game gives birth by its own code.
            pregnancy.Severity = 0.9999f;
        }

        [Then("Ancient Chinese Beast: a young {string} of the player's faction is born within {int} seconds", TimeoutSeconds = 100f)]
        public async Task YoungBorn(PickleContext ctx, string raceDefName, int seconds)
        {
            var map = Stage.CurrentMap(ctx);
            Func<Pawn> young = () => map.mapPawns.AllPawnsSpawned.FirstOrDefault(p =>
                p.def.defName == raceDefName && p.Faction == Faction.OfPlayer && p.ageTracker.CurLifeStage.defName == "AnimalBaby");
            await Stage.WaitGameSeconds(ctx, () => young() != null, seconds);
            var born = young();
            ctx.Assert(born != null, $"no baby {raceDefName} of the player's faction appeared; the {raceDefName} pawns on the map: "
                + string.Join(", ", map.mapPawns.AllPawnsSpawned.Where(p => p.def.defName == raceDefName).Select(p => $"{p.ageTracker.CurLifeStage.defName}/{p.Faction?.Name ?? "none"}")));
            ctx.Attach("the young", $"{born.def.defName}, stage {born.ageTracker.CurLifeStage.defName}, kind {born.kindDef.defName}, gender {born.gender}");
        }

        private static ThingComp EggLayer(Pawn pawn) => pawn.AllComps.FirstOrDefault(c => c.GetType().Name == "CompEggLayer");

        [Then("Ancient Chinese Beast: pawn {int} is fertilised within {int} seconds", TimeoutSeconds = 100f)]
        public async Task IsFertilised(PickleContext ctx, int number, int seconds)
        {
            var pawn = Nth(ctx, number);
            var comp = EggLayer(pawn) as CompEggLayer;
            ctx.Assert(comp != null, $"{pawn.def.defName} has no egg layer");
            await Stage.WaitGameSeconds(ctx, () => comp.FullyFertilized, seconds);
            ctx.Assert(comp.FullyFertilized, $"{pawn.def.defName} was not fertilised; {Stage.LastWaitReport}; the male: {Describe(Nth(ctx, 1))}, the female: {Describe(pawn)}");
        }

        [When("Ancient Chinese Beast: the egg of pawn {int} is due now")]
        public void EggDue(PickleContext ctx, int number)
        {
            var pawn = Nth(ctx, number);
            var comp = EggLayer(pawn);
            ctx.Assert(comp != null, $"{pawn.def.defName} has no egg layer");
            var field = typeof(CompEggLayer).GetField("eggProgress", BindingFlags.NonPublic | BindingFlags.Instance);
            ctx.Assert(field != null, "CompEggLayer has no eggProgress field in this version");
            field.SetValue(comp, 1f);
        }

        [When("Ancient Chinese Beast: every {string} is due to hatch now")]
        public void HatchDue(PickleContext ctx, string eggDefName)
        {
            var eggs = Stage.ThingsOfDef(Stage.CurrentMap(ctx), eggDefName).ToList();
            ctx.Assert(eggs.Count > 0, $"no {eggDefName} on the map");
            var field = typeof(CompHatcher).GetField("gestateProgress", BindingFlags.NonPublic | BindingFlags.Instance);
            ctx.Assert(field != null, "CompHatcher has no gestateProgress field in this version");
            foreach (var egg in eggs)
            {
                var hatcher = egg.TryGetComp<CompHatcher>();
                ctx.Assert(hatcher != null, $"{eggDefName} has no hatcher");
                field.SetValue(hatcher, 0.9999f);
            }
        }

        [Then("Ancient Chinese Beast: the body clock of {string} is {word}")]
        public void BodyClock(PickleContext ctx, string raceDefName, string expected)
        {
            var race = DefDatabase<ThingDef>.GetNamedSilentFail(raceDefName);
            ctx.Assert(race != null, $"no ThingDef named {raceDefName}");
            var extension = race.modExtensions?.FirstOrDefault(e => e.GetType().FullName == "NocturnalAnimals.ExtendedRaceProperties");
            ctx.Assert(extension != null, $"{raceDefName} carries no NocturnalAnimals.ExtendedRaceProperties: the patch did not apply");
            var field = extension.GetType().GetField("bodyClock", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            ctx.Assert(field != null, "the extension has no bodyClock field in this version of the other mod");
            ctx.Assert(string.Equals(field.GetValue(extension)?.ToString(), expected, StringComparison.OrdinalIgnoreCase),
                $"{raceDefName} has body clock {field.GetValue(extension)}, not {expected}");
        }
    }
}
