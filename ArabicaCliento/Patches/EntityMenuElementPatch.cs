using Content.Client.ContextMenu.UI;
using HarmonyLib;

namespace ArabicaCliento.Patches;

[HarmonyPatch(typeof(EntityMenuElement))]
[HarmonyPatch("GetEntityDescription")]
internal class EntityMenuElementPatch
{
    [HarmonyPrefix]
    private static bool Prefix(EntityUid entity, EntityMenuElement __instance, ref string __result)
    {
        __result = AccessTools.Method(typeof(EntityMenuElement), "GetEntityDescriptionAdmin")
            .Invoke(__instance, [entity]) as string ?? throw new InvalidOperationException();
        return false;
    }
}