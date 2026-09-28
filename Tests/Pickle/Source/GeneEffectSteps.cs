using System.Linq;
using System.Threading.Tasks;
using RimWorks.Pickle;
using RimWorld;
using Verse;

namespace AncientChineseBeast.PickleSteps
{
    // M7 of Tests/Pickle/README.md's manual exceptions: what the extracted genes do to a colonist. Recipes and
    // clones are played by 08 and 12; this is the other half, the gene implanted in a living human through the
    // game's own genes tracker, and the stat or hediff it is supposed to leave behind. The qiongqi eye's dodge is
    // a coin flip per projectile (ProjectileImpact_Patch) and is left to a statistical scenario of its own.
    [PickleSteps]
    public sealed class GeneEffectSteps
    {
        private static Pawn Nth(PickleContext ctx, int number)
        {
            var list = SpawnSteps.TryGet(ctx);
            ctx.Assert(list != null && number >= 1 && number <= list.Pawns.Count,
                $"no pawn number {number}: this scenario spawned {list?.Pawns.Count ?? 0}");
            return list.Pawns[number - 1];
        }

        [When("Ancient Chinese Beast: pawn {int} receives the gene {string}")]
        public void ReceivesGene(PickleContext ctx, int number, string geneDefName)
        {
            var pawn = Nth(ctx, number);
            var def = DefDatabase<GeneDef>.GetNamedSilentFail(geneDefName);
            ctx.Assert(def != null, $"no GeneDef named {geneDefName}");
            ctx.Assert(pawn.genes != null, "the colonist has no genes tracker (is Biotech active?)");
            pawn.genes.AddGene(def, xenogene: true);
            ctx.Assert(pawn.genes.GetGene(def) != null, $"the colonist did not receive {geneDefName}");
        }

        // Gene_Strength adds its hediff from Tick() while the bearer holds no weapon, so a tick has to pass.
        [Then("Ancient Chinese Beast: pawn {int} deals doubled melee damage unarmed within {int} seconds", TimeoutSeconds = 60f)]
        public async Task DoublesUnarmedDamage(PickleContext ctx, int number, int seconds)
        {
            var pawn = Nth(ctx, number);
            ctx.Assert(pawn.equipment?.Primary == null, "the colonist holds a weapon, so the gene would rightly not act");
            float baseline = 1f;
            await Stage.WaitGameSeconds(ctx, () => pawn.health.hediffSet.HasHediff(HediffDef.Named("SZ_Strength")), seconds);
            float factor = pawn.GetStatValue(StatDefOf.MeleeDamageFactor);
            ctx.Assert(pawn.health.hediffSet.HasHediff(HediffDef.Named("SZ_Strength")), $"SZ_Strength never came; {Stage.LastWaitReport}");
            ctx.Assert(System.Math.Abs(factor - 2f * baseline) < 0.01f, $"MeleeDamageFactor is {factor}, expected 2");
        }

        // Where the horn hediff lands is decided by Gene_Hediffs from a body part group; the step reads it off the
        // hediff instead of assuming a part, then compares that part's maximum hit points to its def's base value.
        [Then("Ancient Chinese Beast: pawn {int} has a nian horn whose part holds more hit points than its base")]
        public void HornRaisesHitPoints(PickleContext ctx, int number)
        {
            var pawn = Nth(ctx, number);
            var horn = pawn.health.hediffSet.hediffs.FirstOrDefault(h => h.def.defName == "SZ_Year_Horn");
            ctx.Assert(horn != null, "no SZ_Year_Horn hediff on the colonist");
            ctx.Assert(horn.Part != null, "the horn hediff is not on any body part");
            float max = horn.Part.def.GetMaxHealth(pawn);
            float baseHp = horn.Part.def.hitPoints;
            ctx.Attach("horn part hit points", $"{horn.Part.def.defName}: {max} now, {baseHp} base");
            ctx.Assert(max > baseHp, $"{horn.Part.def.defName} holds {max} hit points, not more than its base {baseHp}");
        }
    }
}
