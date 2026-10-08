using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RimWorks.Pickle;
using RimWorld;
using Verse;
using Verse.AI;

namespace AncientChineseBeast.PickleSteps
{
    // Steps of the staged Workshop gallery (feature 24, played on the Sanctuary fixture). The place, the decor, the colonists'
    // look and the camera are Nelim's Sanctuary / Nelim's Pickle Tools steps; what is left here is what only this mod knows:
    // a beast placed and turned on a cell, a qiongqi caught in its flight, and the capture helpers that animal-photograph
    // suites share (written in Animal Ark's suite first, copied here and reported to Pickle Tools for Elsewhere/).
    [PickleSteps]
    public sealed class GallerySteps
    {
        private static readonly Dictionary<Window, bool> WindowFlags = new Dictionary<Window, bool>();
        private static bool screenshotWasActive;
        private static bool screenshotOn;
        private static TimeSpeed savedSpeed = TimeSpeed.Normal;
        private static bool paused;

        private static Pawn Nth(PickleContext ctx, int number)
        {
            var list = SpawnSteps.TryGet(ctx);
            ctx.Assert(list != null && number >= 1 && number <= list.Pawns.Count,
                $"no pawn number {number}: this scenario spawned {list?.Pawns.Count ?? 0}");
            return list.Pawns[number - 1];
        }

        private static Rot4 Facing(PickleContext ctx, string word)
        {
            switch (word.ToLowerInvariant())
            {
                case "north": return Rot4.North;
                case "east": return Rot4.East;
                case "south": return Rot4.South;
                case "west": return Rot4.West;
            }
            ctx.Assert(false, $"facing must be North, East, South or West, not {word}");
            return Rot4.South;
        }

        // A beast comes from PawnGenerator (see SpawnSteps), has no faction (it arrives hostile from the wild) and stands on the
        // cell asked or the nearest standable one, turned the way the picture wants. The game is paused afterwards by its own step.
        private static void SpawnFacing(PickleContext ctx, string kindDefName, int x, int z, string facing, Gender? gender)
        {
            var map = Stage.CurrentMap(ctx);
            var kind = DefDatabase<PawnKindDef>.GetNamedSilentFail(kindDefName);
            ctx.Assert(kind != null, $"no PawnKindDef named {kindDefName}");
            var cell = new IntVec3(x, 0, z);
            ctx.Assert(cell.InBounds(map), $"({x}, {z}) is outside the map");
            if (!cell.Standable(map))
            {
                var near = CellFinder.StandableCellNear(cell, map, 3f);
                ctx.Assert(near.IsValid, $"({x}, {z}) is not standable and nothing standable lies within 3 cells");
                cell = near;
            }
            var pawn = PawnGenerator.GeneratePawn(new PawnGenerationRequest(kind, null, forceGenerateNewPawn: true, fixedGender: gender));
            GenSpawn.Spawn(pawn, cell, map, Facing(ctx, facing));
            ctx.Assert(pawn.Spawned, $"{kindDefName} did not spawn at {cell}");
            SpawnSteps.Remember(ctx, pawn);
        }

        [When("Ancient Chinese Beast: I spawn the pawn {string} at \\({int}, {int}\\) facing {word}")]
        public void SpawnPawnFacing(PickleContext ctx, string kindDefName, int x, int z, string facing)
        {
            SpawnFacing(ctx, kindDefName, x, z, facing, null);
        }

        [When("Ancient Chinese Beast: I spawn the {word} pawn {string} at \\({int}, {int}\\) facing {word}")]
        public void SpawnSexPawnFacing(PickleContext ctx, string sex, string kindDefName, int x, int z, string facing)
        {
            Gender gender;
            switch (sex.ToLowerInvariant())
            {
                case "male": gender = Gender.Male; break;
                case "female": gender = Gender.Female; break;
                default: ctx.Assert(false, $"sex must be male or female, not {sex}"); return;
            }
            SpawnFacing(ctx, kindDefName, x, z, facing, gender);
        }

        // The sexie's counter starts at 3600 and sends the most sensitive colonist of the map berserk on the first tick; it is set
        // before the pawn is spawned, as in SpawnSteps.SpawnPawnClockZero, here at a cell and facing east.
        [When("Ancient Chinese Beast: I spawn the pawn {string} at \\({int}, {int}\\) with its aura clock at zero")]
        public void SpawnClockZero(PickleContext ctx, string kindDefName, int x, int z)
        {
            var map = Stage.CurrentMap(ctx);
            var kind = DefDatabase<PawnKindDef>.GetNamedSilentFail(kindDefName);
            ctx.Assert(kind != null, $"no PawnKindDef named {kindDefName}");
            var cell = new IntVec3(x, 0, z);
            if (!cell.Standable(map))
            {
                var near = CellFinder.StandableCellNear(cell, map, 3f);
                ctx.Assert(near.IsValid, $"({x}, {z}) is not standable and nothing standable lies within 3 cells");
                cell = near;
            }
            var pawn = PawnGenerator.GeneratePawn(new PawnGenerationRequest(kind, null, forceGenerateNewPawn: true));
            var comp = pawn.GetComp<CompSeXieExpansion>();
            ctx.Assert(comp != null, $"{kindDefName} has no CompSeXieExpansion");
            var field = typeof(CompSeXieExpansion).GetField("ticks", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            ctx.Assert(field != null, "CompSeXieExpansion.ticks was not found");
            field.SetValue(comp, 0);
            GenSpawn.Spawn(pawn, cell, map, Rot4.West);
            ctx.Assert(pawn.Spawned, $"{kindDefName} did not spawn at {cell}");
            SpawnSteps.Remember(ctx, pawn);
        }

        // A colonist made by Pickle (by its short name) joins the numbered pawns of the scenario, so that the steps that say
        // "pawn 2" can act on a keeper whom the scenario dressed by name.
        [When("Ancient Chinese Beast: the colonist {string} is added to the pawns")]
        public void AddColonist(PickleContext ctx, string name)
        {
            var map = Stage.CurrentMap(ctx);
            var pawn = map.mapPawns.FreeColonistsSpawned.FirstOrDefault(p => p.Name != null && p.Name.ToStringShort == name);
            ctx.Assert(pawn != null, $"no free colonist called {name} stands on the map");
            SpawnSteps.Remember(ctx, pawn);
        }

        [When("Ancient Chinese Beast: pawn {int} is armed with {string}")]
        public void Arm(PickleContext ctx, int number, string weaponDefName)
        {
            var pawn = Nth(ctx, number);
            var def = DefDatabase<ThingDef>.GetNamedSilentFail(weaponDefName);
            ctx.Assert(def != null, $"no ThingDef named {weaponDefName}");
            var weapon = ThingMaker.MakeThing(def, def.MadeFromStuff ? GenStuff.DefaultStuffFor(def) : null) as ThingWithComps;
            ctx.Assert(weapon != null, $"{weaponDefName} is not a weapon with comps");
            pawn.equipment.AddEquipment(weapon);
            ctx.Assert(pawn.equipment.Primary != null, $"{pawn.LabelShort} holds no weapon after being armed");
        }

        // What the qiongqi's own AI does: the ability job, ordered at a pawn. The step lets the game run until the flying
        // thing exists, a few ticks more so that it is between the two ends of its path, then pauses. The wait is the
        // game's own ticks (Pickle drives them even paused) with a real-time cap, like Stage.WaitGameSeconds.
        [When("Ancient Chinese Beast: the qiongqi pawn {int} is caught in flight at pawn {int} within {int} seconds", TimeoutSeconds = 330f)]
        public async Task CaughtInFlight(PickleContext ctx, int qiongqiNumber, int targetNumber, int seconds)
        {
            var qiongqi = Nth(ctx, qiongqiNumber);
            var target = Nth(ctx, targetNumber);
            var map = Stage.CurrentMap(ctx);
            var ability = qiongqi.abilities?.GetAbility(DefDatabase<AbilityDef>.GetNamedSilentFail("SZ_QiongQi_FlyingStrike"));
            ctx.Assert(ability != null, $"{qiongqi.def.defName} has no flying strike ability");
            qiongqi.jobs.ClearQueuedJobs();
            qiongqi.jobs.TryTakeOrderedJob(ability.GetJob(target, target.Position), JobTag.Misc);
            var flyer = ThingDef.Named("SZ_QQPawnFlyingStrike");
            await Stage.WaitGameSeconds(ctx, () => map.listerThings.ThingsOfDef(flyer).Any(), seconds, 300);
            ctx.Assert(map.listerThings.ThingsOfDef(flyer).Any(), $"the qiongqi never took off; {Stage.LastWaitReport}");
            await ctx.WaitTicks(8);
            if (!paused) { savedSpeed = Find.TickManager.CurTimeSpeed; paused = true; }
            Find.TickManager.CurTimeSpeed = TimeSpeed.Paused;
            await ctx.WaitFrames(3);
        }

        // Freezes the beasts once placed, so that one does not eat its neighbour before the picture.
        [When("Ancient Chinese Beast: time is paused", TimeoutSeconds = 30f)]
        public async Task Pause(PickleContext ctx)
        {
            if (!paused) { savedSpeed = Find.TickManager.CurTimeSpeed; paused = true; }
            Find.TickManager.CurTimeSpeed = TimeSpeed.Paused;
            await ctx.WaitFrames(3);
        }

        // A capture of the map and nothing else: the game's own screenshot mode, with every open window (the Pickle
        // launcher panel and the log viewer included) told not to draw in it.
        [When("Ancient Chinese Beast: the map is shown alone for a capture", TimeoutSeconds = 30f)]
        public async Task MapAlone(PickleContext ctx)
        {
            Restore();
            var root = Find.UIRoot;
            ctx.Require(root?.screenshotMode != null, "no UIRoot screenshot mode is available");
            foreach (var window in Find.WindowStack.Windows.ToList())
            {
                WindowFlags[window] = window.drawInScreenshotMode;
                window.drawInScreenshotMode = false;
            }
            screenshotWasActive = root.screenshotMode.Active;
            root.screenshotMode.Active = true;
            screenshotOn = true;
            await ctx.WaitFrames(3);
        }

        [When("Ancient Chinese Beast: the interface is shown again")]
        public void InterfaceBack(PickleContext ctx)
        {
            Restore();
        }

        [AfterScenario]
        public void RestoreAfterScenario()
        {
            Restore();
        }

        private static void Restore()
        {
            foreach (var pair in WindowFlags)
                if (pair.Key != null) pair.Key.drawInScreenshotMode = pair.Value;
            WindowFlags.Clear();
            if (screenshotOn && Find.UIRoot?.screenshotMode != null) Find.UIRoot.screenshotMode.Active = screenshotWasActive;
            screenshotOn = false;
            if (paused && Find.TickManager != null) Find.TickManager.CurTimeSpeed = savedSpeed;
            paused = false;
        }
    }
}
