using System.Reflection;
using HarmonyLib;
using JetBrains.Annotations;
using Robust.Client.Graphics;

namespace ArabicaCliento.Patches.Overlays;

[UsedImplicitly(ImplicitUseTargetFlags.WithInheritors)]
public abstract class OverlayPatch<T> where T: Overlay
{
    [HarmonyTargetMethod]
    private static MethodBase TargetMethod()
    {
        return AccessTools.Method(typeof(T), "Draw");
    }
    
    [HarmonyPrefix]
    private static bool Prefix() => false;
}