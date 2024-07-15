using System.Reflection;
using Content.Client.Administration.Managers;
using HarmonyLib;
using Robust.Client.Console;

namespace ArabicaCliento.Patches;

[HarmonyPatch]
static class ConsoleHostPatch
{
    [HarmonyTargetMethod]
    private static MethodBase TargetMethod()
    {
        return AccessTools.Method(AccessTools.TypeByName("Robust.Client.Console.ClientConsoleHost"),
            "CanExecute");
        
    }
    
    [HarmonyPostfix]
    private static void Postfix(ref bool __result) => __result = true;
}