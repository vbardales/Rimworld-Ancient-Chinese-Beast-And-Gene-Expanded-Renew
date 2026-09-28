using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using RimWorks.Pickle;
using RimWorld;
using UnityEngine;
using Verse;

namespace AncientChineseBeast.PickleSteps
{
    // M2 and M3 of Tests/Pickle/README.md's manual exceptions, and the dodge half of M7: what a person would have
    // watched over dozens of shots and blows, played instead as a sample large enough that a fair coin cannot
    // fail the bounds (400 flips of a fair coin leave the 0.4 to 0.6 band with a chance below one in a hundred
    // thousand). The dodge is asked of the mod's own Harmony prefix through reflection, the blow of the beast's own
    // melee verb, the wind barrier of the ability the beast carries; nothing is simulated in place of them.
    [PickleSteps]
    public sealed class CombatSteps
    {
        private static Pawn Nth(PickleContext ctx, int number)
        {
            var list = SpawnSteps.TryGet(ctx);
            ctx.Assert(list != null && number >= 1 && number <= list.Pawns.Count,
                $"no pawn number {number}: this scenario spawned {list?.Pawns.Count ?? 0}");
            return list.Pawns[number - 1];
        }

        // ProjectileImpact_Patch's prefix answers false when the bearer dodges the projectile, true otherwise. Each
        // projectile is its own key in the patch's memory, so every shot here is a fresh, unspawned bullet.
        [Then("Ancient Chinese Beast: pawn {int} dodges between {float} and {float} of {int} shots")]
        public void DodgeRate(PickleContext ctx, int number, float low, float high, int shots)
        {
            var pawn = Nth(ctx, number);
            var nested = typeof(ProjectileImpact_Patch).GetNestedType("ProjectileImpact_PreFix", BindingFlags.NonPublic);
            var method = nested?.GetMethod("PreFix", BindingFlags.NonPublic | BindingFlags.Static);
            ctx.Assert(method != null, "the dodge prefix of ProjectileImpact_Patch was not found");
            var bullet = DefDatabase<ThingDef>.GetNamed("Bullet_BoltActionRifle");
            int dodged = 0;
            for (int i = 0; i < shots; i++)
            {
                var projectile = (Projectile)ThingMaker.MakeThing(bullet);
                if (!(bool)method.Invoke(null, new object[] { pawn, projectile })) dodged++;
            }
            float rate = dodged / (float)shots;
            ctx.Attach("dodge rate", $"{pawn.def.defName}: {dodged} of {shots} shots dodged ({rate:P0})");
            ctx.Assert(rate >= low && rate <= high, $"{pawn.def.defName} dodged {rate:P0} of {shots} shots, outside {low:P0} to {high:P0}");
        }

        private static bool InHead(BodyPartRecord part)
        {
            for (var p = part; p != null; p = p.parent) if (p.def == BodyPartDefOf.Head) return true;
            return false;
        }

        // The qiongqi's bite and claws aim at the head half of the time (Verb_MeleeAttackDamage_HitHead), on top of
        // whatever the vanilla roll gives, which is about a tenth for a human. The victim is healed between blows so
        // that one colonist can take every sample.
        [Then("Ancient Chinese Beast: pawn {int} lands at least {float} of {int} blows on the head of pawn {int}")]
        public void HeadBias(PickleContext ctx, int attackerNumber, float minimum, int blows, int victimNumber)
        {
            var attacker = Nth(ctx, attackerNumber);
            var victim = Nth(ctx, victimNumber);
            var verb = attacker.meleeVerbs.GetUpdatedAvailableVerbsList(false).Select(entry => entry.verb).OfType<Verb_MeleeAttackDamage_HitHead>().FirstOrDefault();
            ctx.Assert(verb != null, $"{attacker.def.defName} has no head-biased melee verb");
            var apply = typeof(Verb_MeleeAttackDamage).GetMethod("ApplyMeleeDamageToTarget", BindingFlags.Instance | BindingFlags.NonPublic);
            ctx.Assert(apply != null, "Verb_MeleeAttackDamage.ApplyMeleeDamageToTarget was not found");
            int landed = 0, head = 0;
            for (int i = 0; i < blows; i++)
            {
                apply.Invoke(verb, new object[] { new LocalTargetInfo(victim) });
                var injuries = victim.health.hediffSet.hediffs.OfType<Hediff_Injury>().ToList();
                if (injuries.Count > 0)
                {
                    landed++;
                    if (injuries.Any(injury => InHead(injury.Part))) head++;
                }
                foreach (var hediff in victim.health.hediffSet.hediffs.ToList())
                    if (hediff is Hediff_Injury || hediff is Hediff_MissingPart) victim.health.RemoveHediff(hediff);
                ctx.Assert(!victim.Dead, "the victim died between two samples");
            }
            ctx.Assert(landed >= blows / 2, $"only {landed} of {blows} blows left an injury");
            float share = head / (float)landed;
            ctx.Attach("head share", $"{head} of {landed} injuring blows landed on the head ({share:P0})");
            ctx.Assert(share >= minimum, $"{share:P0} of {landed} blows landed on the head, under {minimum:P0}");
        }

        // The wind barrier: raise it the way the ability's own Apply does (ticksTime = 900).
        [When("Ancient Chinese Beast: the wind barrier of pawn {int} is raised")]
        public void RaiseBarrier(PickleContext ctx, int number)
        {
            var pawn = Nth(ctx, number);
            var barrier = pawn.abilities?.abilities.OfType<Ability_WindBarrier>().FirstOrDefault();
            ctx.Assert(barrier != null, $"{pawn.def.defName} has no wind barrier ability");
            barrier.ticksTime = 900;
        }

        // An item lying on the ground, at the standable cell nearest the one asked, remembered by number.
        [When("Ancient Chinese Beast: I lay {string} near x={int} z={int}")]
        public void LayItem(PickleContext ctx, string defName, int x, int z)
        {
            var map = Stage.CurrentMap(ctx);
            var def = DefDatabase<ThingDef>.GetNamedSilentFail(defName);
            ctx.Assert(def != null, $"no ThingDef named {defName}");
            var cell = CellFinder.StandableCellNear(new IntVec3(x, 0, z), map, 8f);
            ctx.Assert(cell.IsValid, $"no standable cell near x={x} z={z}");
            var thing = ThingMaker.MakeThing(def);
            GenSpawn.Spawn(thing, cell, map);
            ctx.Assert(thing.Spawned, $"{defName} did not spawn near x={x} z={z}");
            Placed(ctx).Add(thing);
        }

        private static List<Thing> Placed(PickleContext ctx)
        {
            try { return ctx.Get<PlacedThings>().Things; }
            catch (System.Exception) { var placed = new PlacedThings(); ctx.Set(placed); return placed.Things; }
        }

        private static Thing NthThing(PickleContext ctx, int number)
        {
            var things = Placed(ctx);
            ctx.Assert(number >= 1 && number <= things.Count, $"no thing number {number}: this scenario laid {things.Count}");
            return things[number - 1];
        }

        [Then("Ancient Chinese Beast: thing {int} is cut within {int} seconds", TimeoutSeconds = 90f)]
        public async Task ThingIsCut(PickleContext ctx, int number, int seconds)
        {
            var thing = NthThing(ctx, number);
            await Stage.WaitGameSeconds(ctx, () => thing.Destroyed || thing.HitPoints < thing.MaxHitPoints, seconds);
            ctx.Assert(thing.Destroyed || thing.HitPoints < thing.MaxHitPoints, $"thing {number} ({thing.def.defName}) took no damage; {Stage.LastWaitReport}");
        }

        [Then("Ancient Chinese Beast: thing {int} is more than {int} tiles from pawn {int}")]
        public void ThingFarFromPawn(PickleContext ctx, int number, int tiles, int pawnNumber)
        {
            float distance = NthThing(ctx, number).Position.DistanceTo(Nth(ctx, pawnNumber).Position);
            ctx.Assert(distance > tiles, $"thing {number} is {distance} tiles from pawn {pawnNumber}, not more than {tiles}: the scenario's far piece is not far");
        }

        [Then("Ancient Chinese Beast: thing {int} is intact")]
        public void ThingIsIntact(PickleContext ctx, int number)
        {
            var thing = NthThing(ctx, number);
            ctx.Assert(!thing.Destroyed && thing.HitPoints == thing.MaxHitPoints, $"thing {number} ({thing.def.defName}) is damaged ({thing.HitPoints}/{thing.MaxHitPoints}) outside the barrier");
        }

        // A colonist standing far off, holding a rifle it does not use: the launcher of a shot the scenario throws.
        // The rifle must be given (Launch keeps it as the equipment the barrier re-makes when it throws the shot back).
        [When("Ancient Chinese Beast: I stand a rifle-bearing colonist near x={int} z={int}")]
        public void StandShooter(PickleContext ctx, int x, int z)
        {
            var map = Stage.CurrentMap(ctx);
            var cell = CellFinder.StandableCellNear(new IntVec3(x, 0, z), map, 8f);
            ctx.Assert(cell.IsValid, $"no standable cell near x={x} z={z}");
            var pawn = PawnGenerator.GeneratePawn(new PawnGenerationRequest(PawnKindDefOf.Colonist, Faction.OfPlayer, forceGenerateNewPawn: true));
            GenSpawn.Spawn(pawn, cell, map);
            var rifle = ThingMaker.MakeThing(DefDatabase<ThingDef>.GetNamed("Gun_BoltActionRifle")) as ThingWithComps;
            pawn.equipment.AddEquipment(rifle);
            ctx.Assert(pawn.Spawned && pawn.equipment.Primary != null, "the shooter did not spawn armed");
            SpawnSteps.Remember(ctx, pawn);
        }

        [When("Ancient Chinese Beast: pawn {int} shoots at pawn {int}")]
        public void ShootAt(PickleContext ctx, int shooterNumber, int targetNumber)
        {
            var shooter = Nth(ctx, shooterNumber);
            var target = Nth(ctx, targetNumber);
            var map = Stage.CurrentMap(ctx);
            var rifle = shooter.equipment.Primary;
            var projectile = (Projectile)GenSpawn.Spawn(DefDatabase<ThingDef>.GetNamed("Bullet_BoltActionRifle"), shooter.Position, map);
            projectile.Launch(shooter, shooter.DrawPos, new LocalTargetInfo(target), new LocalTargetInfo(target), ProjectileHitFlags.IntendedTarget, false, rifle);
        }

        [Then("Ancient Chinese Beast: a projectile launched by pawn {int} is in flight within {int} seconds", TimeoutSeconds = 60f)]
        public async Task ProjectileInFlight(PickleContext ctx, int number, int seconds)
        {
            var pawn = Nth(ctx, number);
            var map = Stage.CurrentMap(ctx);
            bool InFlight() => map.listerThings.ThingsInGroup(ThingRequestGroup.Projectile).OfType<Projectile>().Any(p => p.Launcher == pawn);
            await Stage.WaitGameSeconds(ctx, InFlight, seconds);
            ctx.Assert(InFlight(), $"no projectile launched by {pawn.def.defName} was seen in flight: the barrier threw nothing back; {Stage.LastWaitReport}");
        }
    }

    internal sealed class PlacedThings { public List<Thing> Things = new List<Thing>(); }
}
