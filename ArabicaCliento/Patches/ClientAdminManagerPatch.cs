using Content.Client.Administration.Managers;
using HarmonyLib;

namespace ArabicaCliento.Patches;

[HarmonyPatch(typeof(ClientAdminManager))]
[HarmonyPatch(nameof(ClientAdminManager.CanAdminMenu))]
[HarmonyPatch(nameof(ClientAdminManager.CanAdminPlace))]
[HarmonyPatch(nameof(ClientAdminManager.CanScript))]
[HarmonyPatch(nameof(ClientAdminManager.CanCommand))]
[HarmonyPatch(nameof(ClientAdminManager.IsActive))]
internal static class ClientAdminManagerPatch
{
    [HarmonyPostfix]
    private static void Postfix(ref bool __result) => __result = true;
}