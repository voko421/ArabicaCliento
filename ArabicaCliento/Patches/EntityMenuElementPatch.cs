using Content.Client.ContextMenu.UI;
using HarmonyLib;
using Robust.Shared.GameObjects;

namespace ArabicaCliento.Patches;

[HarmonyPatch(typeof(EntityMenuElement))]
[HarmonyPatch("GetEntityDescription")]
class EntityMenuElementPatch
{
    [HarmonyPrefix]
    static bool Prefix(EntityUid entity, EntityMenuElement __instance, ref string __result)
    {
        __result = AccessTools.Method(typeof(EntityMenuElement), "GetEntityDescriptionAdmin")
            .Invoke(__instance, [entity]) as string ?? throw new InvalidOperationException();
        return false;
    }
}