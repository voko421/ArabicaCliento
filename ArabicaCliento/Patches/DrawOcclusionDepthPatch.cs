using HarmonyLib;

namespace ArabicaCliento.Patches;

[HarmonyPatch("Robust.Client.Graphics.Clyde.Clyde", "DrawOcclusionDepth")]
internal static class DrawOcclusionDepthPatch
{
    [HarmonyPrefix]
    static bool Prefix()
    {
        return !ArabicaConfig.FOVDisable;
    }
}