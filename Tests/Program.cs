// Checks this mod against the RimWorld assemblies it will be loaded next to.
//
// Why these three checks and not others. The 1.6 port broke in exactly three ways, and all three
// are silent: nothing refuses to compile, and the game logs nothing useful until the moment the
// code is reached, which for a boss that arrives once a year can be a very long time.
//
//   1. A Harmony patch whose target no longer exists. Harmony throws while patching, at load.
//   2. A patch method whose parameter name no longer matches one of the target's. Harmony binds
//      those BY NAME - rename drawLoc upstream and the patch stops compiling arguments, not
//      quietly, but only once the game tries to patch.
//   3. A method that used to override a base one and, since a signature changed under it, is now
//      just a method nobody calls. This is the worst of the three: it compiles, it patches, it
//      loads, and the sexie simply never becomes the scorpion. Two of the mod's hooks were in
//      that state on 1.6.
//
// What this cannot do: run any of it. The reference assemblies have method bodies, but Unity is
// not initialised and RimWorld's static state does not exist outside the game, so nothing here
// constructs a Thing or calls into the game. These are metadata checks, and a clean run means
// the mod's attachment points are still where it thinks they are - not that it works.
//
//   dotnet run --project Tests
//   dotnet run --project Tests -- "D:\Steam\...\RimWorld\RimWorldWin64_Data\Managed"

using System.Reflection;

const string DefaultManaged = @"C:\Program Files (x86)\Steam\steamapps\common\RimWorld\RimWorldWin64_Data\Managed";

string managed = args.Length > 0 ? args[0] : DefaultManaged;
string modDll = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", "Mod", "Assemblies", "AncientChineseBeast.dll"));
if (!File.Exists(modDll))
    modDll = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "Mod", "Assemblies", "AncientChineseBeast.dll"));

if (!Directory.Exists(managed))
{
    Console.Error.WriteLine($"RimWorld's Managed folder is not at {managed}.");
    Console.Error.WriteLine("Pass the path as the first argument. Nothing can be checked against a game that is not there.");
    return 2;
}
if (!File.Exists(modDll))
{
    Console.Error.WriteLine($"The mod assembly is not at {modDll}. Build Source/ first.");
    return 2;
}

// A mod assembly names Assembly-CSharp, UnityEngine and Harmony by their short names, and .NET
// only looks next to this program. Point it at the folders they came from, and remember what has
// already been asked for: an unresolvable name asked twice recurses to a stack overflow instead
// of to an error.
var probeDirs = new List<string> { managed, Path.GetDirectoryName(modDll) };
foreach (var harmonyDir in FindHarmony()) probeDirs.Add(harmonyDir);
var probed = new HashSet<string>();
AppDomain.CurrentDomain.AssemblyResolve += (_, e) =>
{
    var shortName = e.Name.Split(',')[0];
    if (!probed.Add(shortName)) return null;
    foreach (var dir in probeDirs)
    {
        var candidate = Path.Combine(dir, shortName + ".dll");
        if (File.Exists(candidate)) return Assembly.LoadFrom(candidate);
    }
    return null;
};

var mod = Assembly.LoadFrom(modDll);
var game = Assembly.LoadFrom(Path.Combine(managed, "Assembly-CSharp.dll"));
var modTypes = TypesOf(mod);
var gameTypes = TypesOf(game);

Console.WriteLine($"mod   {Path.GetFileName(modDll)}  {modTypes.Length} types");
Console.WriteLine($"game  Assembly-CSharp.dll  {gameTypes.Length} types  ({FileVersion(Path.Combine(managed, "Assembly-CSharp.dll"))})");
Console.WriteLine();

var failures = new List<string>();
int checks = 0;

CheckHarmonyTargets();
CheckPatchParameters();
CheckOverridesStillOverride();

Console.WriteLine();
if (failures.Count == 0)
{
    Console.WriteLine($"{checks} checks, nothing to report.");
    return 0;
}
Console.WriteLine($"{checks} checks, {failures.Count} problem(s):");
foreach (var f in failures) Console.WriteLine("  " + f);
return 1;

// ---------------------------------------------------------------------------------------------

// Every [HarmonyPatch] must name a method that exists. The attribute comes in two shapes here:
// with an explicit Type[] of argument types, and without, which is only unambiguous when the
// target has a single overload. Both are resolved the way Harmony resolves them.
void CheckHarmonyTargets()
{
    Console.WriteLine("Harmony targets");
    foreach (var (type, target, declared) in PatchedTypes())
    {
        checks++;
        if (target == null)
        {
            failures.Add($"{Pretty(type)}: {declared} does not resolve on the 1.6 assembly");
            Console.WriteLine($"  MISSING  {Pretty(type)}  ->  {declared}");
        }
        else
        {
            Console.WriteLine($"  ok       {Pretty(type)}  ->  {target.DeclaringType.Name}.{target.Name}({string.Join(", ", target.GetParameters().Select(p => p.ParameterType.Name))})");
        }
    }
}

// Harmony binds a patch method's parameters BY NAME. __instance, __result and friends are the
// special ones; ___field reaches a private field of the target's type; anything else has to be
// the name of one of the target method's own parameters. A name that no longer matches is not a
// compile error and not a warning - it is an exception thrown while the game patches, or, worse,
// an argument silently carrying something other than what the code believes.
void CheckPatchParameters()
{
    Console.WriteLine();
    Console.WriteLine("Patch method parameters");
    foreach (var (type, target, _) in PatchedTypes())
    {
        if (target == null) continue;   // already reported
        foreach (var patch in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly))
        {
            if (!IsPatchMethod(patch)) continue;
            foreach (var p in patch.GetParameters())
            {
                checks++;
                var name = ArgumentName(p);
                var problem = BindProblem(name, p, target);
                if (problem != null)
                {
                    failures.Add($"{Pretty(type)}.{patch.Name}({name}): {problem}");
                    Console.WriteLine($"  BAD      {Pretty(type)}.{patch.Name}  {name}  -  {problem}");
                }
                else
                {
                    Console.WriteLine($"  ok       {Pretty(type)}.{patch.Name}  {name}");
                }
            }
        }
    }
}

string BindProblem(string name, ParameterInfo p, MethodBase target)
{
    var paramType = p.ParameterType.IsByRef ? p.ParameterType.GetElementType() : p.ParameterType;

    switch (name)
    {
        case "__instance":
            if (target.IsStatic) return "the target is static, so there is no instance to receive";
            return paramType.IsAssignableFrom(target.DeclaringType) || target.DeclaringType.IsAssignableFrom(paramType)
                ? null : $"declared {paramType.Name}, but the target is on {target.DeclaringType.Name}";
        case "__result":
        case "__resultRef":
            var ret = (target as MethodInfo)?.ReturnType;
            if (ret == null || ret == typeof(void)) return "the target returns void, so there is no result to receive";
            return paramType.IsAssignableFrom(ret) || ret.IsAssignableFrom(paramType)
                ? null : $"declared {paramType.Name}, but the target returns {ret.Name}";
        case "__state":
        case "__args":
        case "__originalMethod":
        case "__runOriginal":
        case "__exception":
            return null;
    }

    if (name.StartsWith("___"))
    {
        var fieldName = name.Substring(3);
        var field = FindField(target.DeclaringType, fieldName);
        return field != null ? null : $"{target.DeclaringType.Name} has no field '{fieldName}'";
    }

    var match = target.GetParameters().FirstOrDefault(tp => tp.Name == name);
    if (match == null)
        return $"the target has no parameter called '{name}' (it has: {string.Join(", ", target.GetParameters().Select(tp => tp.Name))})";
    var matchType = match.ParameterType.IsByRef ? match.ParameterType.GetElementType() : match.ParameterType;
    return paramType.IsAssignableFrom(matchType) || matchType.IsAssignableFrom(paramType)
        ? null : $"declared {paramType.Name}, but the target's '{name}' is {matchType.Name}";
}

// The check the 1.6 port most needed and did not have. A method that overrides nothing is legal
// C#; it is only wrong because the author believed it would be called. So: for every instance
// method the mod declares, if some base type declares a virtual method of the same name and ours
// is not an override of it, say so. An overload deliberately added beside an inherited method
// trips this too, which is the right trade - there are few of them, and each is worth a look.
void CheckOverridesStillOverride()
{
    Console.WriteLine();
    Console.WriteLine("Methods that look like hooks");
    foreach (var type in modTypes.Where(t => t.BaseType != null && t.BaseType != typeof(object)))
    {
        foreach (var m in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly))
        {
            if (m.IsSpecialName) continue;
            if (m.GetBaseDefinition() != m) continue;            // it does override something
            var shadowed = VirtualInBase(type.BaseType, m.Name);
            if (shadowed == null) continue;                      // a method of its own, not a hook
            checks++;
            var sig = $"{shadowed.DeclaringType.Name}.{shadowed.Name}({string.Join(", ", shadowed.GetParameters().Select(p => p.ParameterType.Name))})";
            var ours = $"{m.Name}({string.Join(", ", m.GetParameters().Select(p => p.ParameterType.Name))})";
            failures.Add($"{Pretty(type)}.{ours} overrides nothing, yet {sig} is virtual - a changed signature leaves the method compiling and never called");
            Console.WriteLine($"  SHADOW   {Pretty(type)}.{ours}  beside virtual {sig}");
        }
    }
    if (!failures.Any(f => f.Contains("overrides nothing")))
        Console.WriteLine("  ok       every method that shares a name with a virtual one overrides it");
}

MethodInfo VirtualInBase(Type baseType, string name)
{
    for (var t = baseType; t != null && t != typeof(object); t = t.BaseType)
    {
        var m = t.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                 .FirstOrDefault(x => x.Name == name && (x.IsVirtual || x.IsAbstract) && !x.IsFinal);
        if (m != null) return m;
    }
    return null;
}

// Walks the mod's types looking for [HarmonyPatch], resolving each declared target once so both
// checks agree on what they are talking about.
IEnumerable<(Type type, MethodBase target, string declared)> PatchedTypes()
{
    foreach (var type in modTypes)
    {
        var attr = type.GetCustomAttributesData().FirstOrDefault(a => a.AttributeType.Name == "HarmonyPatch");
        if (attr == null) continue;
        var args = attr.ConstructorArguments;
        if (args.Count < 2) continue;                       // the bare [HarmonyPatch] marker
        var declaringType = args[0].Value as Type;
        var methodName = args[1].Value as string;
        if (declaringType == null || methodName == null) continue;

        Type[] argTypes = null;
        if (args.Count >= 3 && args[2].Value is IReadOnlyCollection<CustomAttributeTypedArgument> list)
            argTypes = list.Select(x => (Type)x.Value).ToArray();

        var declared = $"{declaringType.Name}.{methodName}({(argTypes == null ? "any overload" : string.Join(", ", argTypes.Select(t => t.Name)))})";
        yield return (type, Resolve(declaringType, methodName, argTypes), declared);
    }
}

MethodBase Resolve(Type type, string name, Type[] argTypes)
{
    const BindingFlags all = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;
    if (argTypes != null)
        return type.GetMethod(name, all, null, argTypes, null);
    var candidates = type.GetMethods(all).Where(m => m.Name == name).ToArray();
    return candidates.Length == 1 ? candidates[0] : null;
}

static bool IsPatchMethod(MethodInfo m) =>
    m.GetCustomAttributesData().Any(a => a.AttributeType.Name is "HarmonyPrefix" or "HarmonyPostfix" or "HarmonyTranspiler" or "HarmonyFinalizer")
    || m.Name is "Prefix" or "Postfix" or "Transpiler" or "Finalizer";

// [HarmonyArgument("realName")] renames a parameter for binding purposes, so read it first.
static string ArgumentName(ParameterInfo p)
{
    var attr = p.GetCustomAttributesData().FirstOrDefault(a => a.AttributeType.Name == "HarmonyArgument");
    if (attr != null && attr.ConstructorArguments.Count > 0 && attr.ConstructorArguments[0].Value is string s) return s;
    return p.Name;
}

static FieldInfo FindField(Type type, string name)
{
    for (var t = type; t != null; t = t.BaseType)
    {
        var f = t.GetField(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly);
        if (f != null) return f;
    }
    return null;
}

// GetTypes() throws on Assembly-CSharp outside the game: it references Unity assemblies that will
// not load. The exception still carries every type that did resolve, which is all of them but a
// handful.
static Type[] TypesOf(Assembly a)
{
    try { return a.GetTypes(); }
    catch (ReflectionTypeLoadException e) { return e.Types.Where(t => t != null).ToArray(); }
}

static string Pretty(Type t) => t.FullName?.Replace("AncientChineseBeast.", "") ?? t.Name;

static string FileVersion(string path) =>
    System.Diagnostics.FileVersionInfo.GetVersionInfo(path).FileVersion ?? "version unknown";

IEnumerable<string> FindHarmony()
{
    // Harmony ships as its own mod, and its assembly is needed here so that the [HarmonyPatch]
    // attributes on the mod's patch classes can be read at all.
    //
    // The version matters, and finding the wrong one is not hypothetical: the first 0Harmony.dll
    // under the Workshop folder on this machine is a 1.2 shipped inside some other mod, and
    // HarmonyLib.HarmonyPatch does not exist in Harmony 1 - the namespace was Harmony. Loading it
    // makes every attribute read throw TypeLoadException. So: only version 2 and above, newest
    // first, which puts brrainz.harmony's own copy in front of anything vendored.
    var roots = new[]
    {
        @"C:\Program Files (x86)\Steam\steamapps\workshop\content\294100",
        @"C:\Program Files (x86)\Steam\steamapps\common\RimWorld\Mods",
    };
    var found = new List<(Version version, string dir)>();
    foreach (var root in roots.Where(Directory.Exists))
        foreach (var dll in Directory.EnumerateFiles(root, "0Harmony.dll", SearchOption.AllDirectories))
        {
            try
            {
                var v = AssemblyName.GetAssemblyName(dll).Version;
                if (v.Major >= 2) found.Add((v, Path.GetDirectoryName(dll)));
            }
            catch { /* not a managed assembly, or unreadable: it is not the one we want either */ }
        }
    return found.OrderByDescending(f => f.version).Select(f => f.dir).Distinct();
}
