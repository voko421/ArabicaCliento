using HarmonyLib;

// ReSharper disable once CheckNamespace
// ReSharper disable once UnusedType.Global
public static class SubverterPatch
{
    public static string Name = "ArabicaCliento";
    public static string Description = "JUST DRINK ARABICA";
    public static Harmony Harm = new("com.noverd.arabica");
}