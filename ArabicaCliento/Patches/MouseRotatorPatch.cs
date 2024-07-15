using System.Reflection;
using Content.Client.MouseRotator;
using Content.Shared.MouseRotator;
using Content.Shared.Movement.Systems;
using HarmonyLib;
using Robust.Client.GameObjects;
using Robust.Client.Graphics;
using Robust.Client.Input;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.Input;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Maths;
using Robust.Shared.Player;
using Robust.Shared.Timing;

namespace ArabicaCliento.Patches;

[HarmonyPatch(typeof(MouseRotatorSystem), nameof(MouseRotatorSystem.Update))]
public class MouseRotatorPatch
{
    [HarmonyPrefix]
    private static bool Prefix() => false;
}