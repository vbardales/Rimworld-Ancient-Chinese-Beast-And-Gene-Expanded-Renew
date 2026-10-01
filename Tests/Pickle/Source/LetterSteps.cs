using System.Linq;
using RimWorks.Pickle;
using RimWorld;
using Verse;

namespace AncientChineseBeast.PickleSteps
{
    // M8 of Tests/Pickle/README.md's manual exceptions. Changing the language of a saved game is the game's own
    // restart and cannot be played inside a scenario, so what is asserted is the part the mod answers for:
    // Singleton.BeastFor refreshes a beast chosen earlier (and saved with its letter in the language of that
    // day) from the Def in the language of the run, so the next letter is not the stale one. The pass is run
    // once per language, so the same scenario proves it in English and in French.
    [PickleSteps]
    public sealed class LetterSteps
    {
        private const string StaleText = "STALE LETTER TEXT FROM ANOTHER LANGUAGE";

        [Given("Ancient Chinese Beast: the beast chosen in the saved game carries the letter of another language for incident {string}")]
        public void StaleBeast(PickleContext ctx, string incidentDefName)
        {
            var list = BeastsOf(ctx, incidentDefName);
            var first = list[0];
            Singleton.instance.beast = new BeastClass { pawn = first.pawn, label = StaleText, text = StaleText };
        }

        [Then("Ancient Chinese Beast: the newest letter has the text and the label of the beast list of incident {string}, not the stale ones")]
        public void NewestLetterIsCurrent(PickleContext ctx, string incidentDefName)
        {
            var letters = Find.LetterStack.LettersListForReading;
            ctx.Assert(letters.Count > 0, "no letter was sent");
            var letter = letters.Last() as ChoiceLetter;
            ctx.Assert(letter != null, $"the newest letter is a {letters.Last().GetType().Name}, not a ChoiceLetter");
            string text = ReadText(letter);
            string label = letter.Label.ToString();
            var list = BeastsOf(ctx, incidentDefName);
            var match = list.FirstOrDefault(b => b.text == text);
            ctx.Attach("letter", $"label: {label} | text: {text}");
            ctx.Assert(!text.Contains(StaleText) && !label.Contains(StaleText), "the letter still carries the stale text of the saved beast");
            ctx.Assert(match != null, $"the letter text is not the current text of any beast of {incidentDefName}");
            ctx.Assert(match.label == label, $"the letter label '{label}' is not the current label '{match.label}' of its beast");
            Singleton.instance.beast = null;
        }

        // ChoiceLetter keeps its body text in a member whose visibility differs between game builds: read it by name.
        private static string ReadText(ChoiceLetter letter)
        {
            const System.Reflection.BindingFlags all = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic;
            var type = typeof(ChoiceLetter);
            var prop = type.GetProperty("Text", all);
            if (prop != null) return prop.GetValue(letter)?.ToString();
            var field = type.GetField("text", all);
            return field?.GetValue(letter)?.ToString();
        }

        private static System.Collections.Generic.List<BeastClass> BeastsOf(PickleContext ctx, string incidentDefName)
        {
            var incident = DefDatabase<IncidentDef>.GetNamedSilentFail(incidentDefName);
            ctx.Assert(incident != null, $"no IncidentDef named {incidentDefName}");
            var ext = incident.GetModExtension<DefModExtension_Beasts>();
            ctx.Assert(ext != null && ext.beasts.Count > 0, $"{incidentDefName} carries no beast list");
            return ext.beasts;
        }
    }
}
