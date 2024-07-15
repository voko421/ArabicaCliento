using Content.Client.Administration.Managers;
using HarmonyLib;
using Robust.Client.Console;

namespace ArabicaCliento.Patches;

[HarmonyPatch(typeof(ClientAdminManager))]
[HarmonyPatch(nameof(ClientAdminManager.CanAdminMenu))]
[HarmonyPatch(nameof(ClientAdminManager.CanAdminPlace))]
[HarmonyPatch(nameof(ClientAdminManager.CanScript))]
[HarmonyPatch(nameof(ClientAdminManager.CanCommand))]
[HarmonyPatch(nameof(ClientAdminManager.IsActive))]
static class ClientAdminManagerPatch
{
    [HarmonyPostfix]
    private static void Postfix(ref bool __result) => __result = true;
}