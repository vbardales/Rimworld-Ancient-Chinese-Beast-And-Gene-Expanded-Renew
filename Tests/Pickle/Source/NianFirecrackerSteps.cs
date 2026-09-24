using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using RimWorks.Pickle;
using RimWorld;
using Verse;

namespace AncientChineseBeast.PickleSteps
{
    // The nian beast and the firecracker are one design: an armoured animal that a tenth of everything
    // bounces off, and the one weapon that does a hundred times its damage. Both halves live in defs
    // (IncomingDamageFactor and damageMultipliers), which an offline test can read and cannot use. What
    // only the game can say is whether a real blow through Thing.TakeDamage still comes out that way on
    // 1.6, and whether the chain of small explosions the firecracker throws still starts and still stops.
    [PickleSteps]
    public sealed class NianFirecrackerSteps
    {
        private const string FirecrackerPiece = "SZ_Firecracker_Explosion";

        // Armour penetration 999 takes armour out of the sum, so what is measured is the factor the mod
        // put on the beast and nothing else. The blow lands on the core part: a random part would make
        // "did it die" a question about which limb was hit.
        [When("Ancient Chinese Beast: the {string} at x={int} z={int} is struck for {int} damage of {string}")]
        public void Struck(PickleContext ctx, string defName, int x, int z, int amount, string damageDefName)
        {
            var pawn = Stage.PawnAt(ctx, defName, x, z);
            var damage = DefDatabase<DamageDef>.GetNamedSilentFail(damageDefName);
            ctx.Assert(damage != null, $"no DamageDef named {damageDefName}");
            var core = pawn.RaceProps.body.corePart;
            ctx.Assert(core != null, $"{defName} has no core body part to strike");
            var result = pawn.TakeDamage(new DamageInfo(damage, amount, 999f, -1f, null, core));
            ctx.Set(new Blow { Dealt = result.totalDamageDealt });
        }

        // Not a blow: the nian beast takes a tenth of every damage but a firecracker's, so "kill it with a
        // big enough hit" is a question about its health and not about what the scenario is checking.
        [When("Ancient Chinese Beast: the {string} at x={int} z={int} is killed outright")]
        public void KilledOutright(PickleContext ctx, string defName, int x, int z)
        {
            var pawn = Stage.PawnAt(ctx, defName, x, z);
            pawn.Kill(null);
            ctx.Assert(pawn.Dead, $"{defName} at x={x} z={z} survived Pawn.Kill");
        }

        [Then("Ancient Chinese Beast: the last blow dealt at most {float} damage")]
        public void BlowAtMost(PickleContext ctx, float ceiling)
        {
            var blow = ctx.Get<Blow>();
            ctx.Assert(blow != null, "no blow was struck in this scenario");
            ctx.Assert(blow.Dealt <= ceiling, $"the blow dealt {blow.Dealt} damage, more than the {ceiling} it should stay under");
        }

        [Then("Ancient Chinese Beast: the last blow dealt more than {float} damage")]
        public void BlowMoreThan(PickleContext ctx, float floor)
        {
            var blow = ctx.Get<Blow>();
            ctx.Assert(blow != null, "no blow was struck in this scenario");
            ctx.Assert(blow.Dealt > floor, $"the blow dealt only {blow.Dealt} damage, not more than {floor}");
        }

        [Then("Ancient Chinese Beast: the {string} at x={int} z={int} is alive")]
        public void IsAlive(PickleContext ctx, string defName, int x, int z)
        {
            var pawn = Stage.PawnAt(ctx, defName, x, z);
            ctx.Assert(!pawn.Dead, $"{defName} at x={x} z={z} is dead");
        }

        // The fire breath is the ability the nian beast is known for. Activated on the target directly:
        // an AI that has to decide to use it is a separate question from whether it works when it does.
        [When("Ancient Chinese Beast: the {string} at x={int} z={int} breathes fire at the {string} at x={int} z={int}")]
        public void BreatheFire(PickleContext ctx, string beastDefName, int x, int z, string targetDefName, int targetX, int targetZ)
        {
            var beast = Stage.PawnAt(ctx, beastDefName, x, z);
            var target = Stage.PawnAt(ctx, targetDefName, targetX, targetZ);
            var ability = beast.abilities?.GetAbility(DefDatabase<AbilityDef>.GetNamed("SZ_YearBeast_Flamethrower"));
            ctx.Assert(ability != null, $"{beastDefName} has no SZ_YearBeast_Flamethrower ability");
            ctx.Set(new BurntTarget { Pawn = target });
            ability.Activate(new LocalTargetInfo(target), new LocalTargetInfo(target));
        }

        // A wound, a fire on the body or death: any of the three says the flame reached the target. The
        // projectile lives for a few ticks only, so the outcome is what is checked, not the projectile.
        [Then("Ancient Chinese Beast: the flame target is hurt or burning within {int} seconds", TimeoutSeconds = 45f)]
        public async Task TargetIsHurt(PickleContext ctx, int seconds)
        {
            var target = ctx.Get<BurntTarget>()?.Pawn;
            ctx.Assert(target != null, "no fire was breathed in this scenario");
            bool Reached() => target.Dead || target.health.hediffSet.hediffs.Count > 0 || target.HasAttachment(ThingDefOf.Fire);
            try { await ctx.WaitUntil(Reached, seconds); }
            catch (Exception) { }
            ctx.Assert(Reached(), $"the {target.def.defName} took no wound and caught no fire after the nian beast breathed on it");
        }

        // The butchery yields whatever the game decides for this race. What it yields is written into the
        // report, whether or not it is what a description promises: the description of the nian beast
        // says "nian beast fangs", and no ThingDef of that name ships with the mod.
        [When("Ancient Chinese Beast: the corpse of a {string} at x={int} z={int} is butchered by a colonist")]
        public void Butcher(PickleContext ctx, string defName, int x, int z)
        {
            var map = Stage.CurrentMap(ctx);
            var corpse = new IntVec3(x, 0, z).GetThingList(map).OfType<Corpse>().FirstOrDefault(c => c.InnerPawn != null && c.InnerPawn.def.defName == defName);
            ctx.Assert(corpse != null, $"no corpse of a {defName} at x={x} z={z}");
            var butcher = map.mapPawns.FreeColonists.FirstOrDefault();
            ctx.Assert(butcher != null, "the map has no free colonist to butcher with");
            var products = corpse.ButcherProducts(butcher, 1f).ToList();
            ctx.Set(new Butchery { Products = products });
            ctx.Attach($"butchery of a {defName}", products.Count == 0 ? "no product" : string.Join("\n", products.Select(t => $"{t.def.defName} x{t.stackCount}")));
        }

        [Then("Ancient Chinese Beast: the butchery yielded meat")]
        public void ButcheryYieldedMeat(PickleContext ctx)
        {
            var products = ctx.Get<Butchery>()?.Products;
            ctx.Assert(products != null, "nothing was butchered in this scenario");
            ctx.Assert(products.Any(t => t.def.IsMeat), "the butchery yielded no meat: " + (products.Count == 0 ? "no product at all" : string.Join(", ", products.Select(t => t.def.defName))));
        }

        // The projectile's own explosion, taken from its def, so that a change to the radius or the damage
        // def in XML is what this exercises. Damage amount is left to the def's default, as the def says.
        [When("Ancient Chinese Beast: a firecracker goes off at x={int} z={int}")]
        public void FirecrackerGoesOff(PickleContext ctx, int x, int z)
        {
            var projectile = ThingDef.Named("SZ_FirecrackerProjectile").projectile;
            ctx.Assert(projectile != null && projectile.damageDef != null && projectile.explosionRadius > 0f, "SZ_FirecrackerProjectile has no explosion to stage");
            GenExplosion.DoExplosion(new IntVec3(x, 0, z), Stage.CurrentMap(ctx), projectile.explosionRadius, projectile.damageDef, null, doVisualEffects: false);
        }

        // The pieces are short-lived on purpose: a first-generation piece explodes three to ten ticks after
        // it lands. Polling for one between steps would miss it about as often as not, so this watches
        // tick by tick and records what it saw, and the assertions read the record.
        [When("Ancient Chinese Beast: I watch the firecracker pieces for {int} ticks", TimeoutSeconds = 90f)]
        public async Task WatchPieces(PickleContext ctx, int ticks)
        {
            var map = Stage.CurrentMap(ctx);
            var field = typeof(Firecracker).GetField("damageDef", BindingFlags.NonPublic | BindingFlags.Instance);
            ctx.Assert(field != null, "Firecracker no longer has a damageDef field to read the level from");
            var seen = new PiecesSeen();
            for (int i = 0; i < ticks; i++)
            {
                int present = 0;
                foreach (var piece in Stage.ThingsOfDef(map, FirecrackerPiece))
                {
                    present++;
                    var level = (field.GetValue(piece) as DamageDef)?.defName ?? "unset";
                    seen.Levels.Add(level);
                }
                if (present > seen.MostAtOnce) seen.MostAtOnce = present;
                await ctx.WaitTicks(1);
            }
            ctx.Set(seen);
            ctx.Attach("firecracker pieces watched", $"levels seen: {(seen.Levels.Count == 0 ? "none" : string.Join(", ", seen.Levels.OrderBy(l => l)))}; most at once: {seen.MostAtOnce}");
        }

        [Then("Ancient Chinese Beast: the watched pieces included level {string}")]
        public void WatchedLevel(PickleContext ctx, string damageDefName)
        {
            var seen = ctx.Get<PiecesSeen>();
            ctx.Assert(seen != null, "no firecracker pieces were watched in this scenario");
            ctx.Assert(seen.Levels.Contains(damageDefName), $"no piece of level {damageDefName} was seen; levels seen: {(seen.Levels.Count == 0 ? "none" : string.Join(", ", seen.Levels))}");
        }

        [Then("Ancient Chinese Beast: the watched pieces never included level {string}")]
        public void WatchedNeverLevel(PickleContext ctx, string damageDefName)
        {
            var seen = ctx.Get<PiecesSeen>();
            ctx.Assert(seen != null, "no firecracker pieces were watched in this scenario");
            ctx.Assert(!seen.Levels.Contains(damageDefName), $"a piece of level {damageDefName} was seen: the chain went past its third level");
        }

        [Then("Ancient Chinese Beast: no firecracker piece remains")]
        public void NoPieceRemains(PickleContext ctx)
        {
            var left = Stage.ThingsOfDef(Stage.CurrentMap(ctx), FirecrackerPiece).Count();
            ctx.Assert(left == 0, $"{left} firecracker piece(s) remain: the chain did not stop");
        }

        [Then("Ancient Chinese Beast: the {string} at x={int} z={int} is wounded within {int} seconds", TimeoutSeconds = 45f)]
        public async Task IsWounded(PickleContext ctx, string defName, int x, int z, int seconds)
        {
            var pawn = Stage.PawnAt(ctx, defName, x, z);
            bool Wounded() => pawn.Dead || pawn.health.hediffSet.hediffs.Any(h => h is Hediff_Injury);
            try { await ctx.WaitUntil(Wounded, seconds); }
            catch (Exception) { }
            ctx.Assert(Wounded(), $"the {defName} took no injury within {seconds} seconds");
        }
    }

    internal sealed class PiecesSeen
    {
        public readonly System.Collections.Generic.HashSet<string> Levels = new System.Collections.Generic.HashSet<string>();
        public int MostAtOnce;
    }
}