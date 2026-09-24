using System;
using System.Linq;
using RimWorks.Pickle;
using Verse;

namespace AncientChineseBeast.PickleSteps
{
    // The declared incompatibility with the original mod (andery233xj.AncientChineseBeast, Workshop
    // 3292446841) says the two "define the same defs". RimWorld does not refuse two mods that do: the
    // later one silently replaces the earlier one's copy of a def, so what the game does about the
    // incompatibility is nothing at all, and what the player sees is one mod's beast under the other's
    // name. These steps assert that symptom rather than expecting a red run: both mods carry the def,
    // and the game keeps exactly one copy, from one of the two.
    [PickleSteps]
    public sealed class IncompatibilitySteps
    {
        private static ModContentPack Pack(PickleContext ctx, string packageId)
        {
            var pack = LoadedModManager.RunningMods.FirstOrDefault(m => string.Equals(m.PackageIdPlayerFacing, packageId, StringComparison.OrdinalIgnoreCase));
            ctx.Assert(pack != null, $"mod {packageId} is not running: this pass did not stage it");
            return pack;
        }

        [Then("Ancient Chinese Beast: the {string} {string} is defined by both mods {string} and {string}")]
        public void DefinedByBoth(PickleContext ctx, string typeName, string defName, string firstId, string secondId)
        {
            foreach (var id in new[] { firstId, secondId })
            {
                var pack = Pack(ctx, id);
                ctx.Assert(pack.AllDefs.Any(d => d.defName == defName && d.GetType().Name == typeName),
                    $"mod {id} does not define the {typeName} {defName}: the two mods no longer share it");
            }
        }

        [Then("Ancient Chinese Beast: the game keeps one copy of the {string} {string}, from mod {string} or {string}")]
        public void OneCopyKept(PickleContext ctx, string typeName, string defName, string firstId, string secondId)
        {
            var type = GenTypes.GetTypeInAnyAssembly(typeName);
            ctx.Assert(type != null, $"no def type named {typeName}");
            var kept = GenDefDatabase.GetDef(type, defName, false);
            ctx.Assert(kept != null, $"the game holds no {typeName} named {defName} at all");
            var owner = kept.modContentPack?.PackageIdPlayerFacing;
            ctx.Assert(string.Equals(owner, firstId, StringComparison.OrdinalIgnoreCase) || string.Equals(owner, secondId, StringComparison.OrdinalIgnoreCase),
                $"the copy of {defName} the game kept comes from {owner}, neither {firstId} nor {secondId}");
            ctx.Attach($"which mod's {defName} the game kept", owner ?? "unknown");
        }
    }
}
