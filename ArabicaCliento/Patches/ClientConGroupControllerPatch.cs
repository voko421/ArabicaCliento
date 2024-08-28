using HarmonyLib;
using Robust.Client.Console;

namespace ArabicaCliento.Patches;

[HarmonyPatch(typeof(ClientConGroupController))]
[HarmonyPatch(nameof(ClientConGroupController.CanCommand))]
[HarmonyPatch(nameof(ClientConGroupController.CanScript))]
[HarmonyPatch(nameof(ClientConGroupController.CanAdminMenu))]
[HarmonyPatch(nameof(ClientConGroupController.CanAdminPlace))]
[HarmonyPatch(nameof(ClientConGroupController.CanViewVar))]
internal static class ClientConGroupControllerPatch
{
    [HarmonyPostfix]
    private static void Postfix(ref bool __result) => __result = true;
}