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
    // a beast placed and turned on a cell.
    [PickleSteps]
    public sealed class GallerySteps
    {
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
    }
}
