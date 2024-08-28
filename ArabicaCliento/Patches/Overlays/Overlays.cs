using Content.Client.Drugs;
using Content.Client.Drunk;
using Content.Client.Eye.Blinding;
using Content.Client.Flash;
using Content.Client.UserInterface.Systems.DamageOverlays.Overlays;
using HarmonyLib;

namespace ArabicaCliento.Patches;

[HarmonyPatch]
public class FlashOverlayPatch : OverlayPatch<FlashOverlay>;

[HarmonyPatch]
public class DamageOverlayPatch : OverlayPatch<DamageOverlay>;

[HarmonyPatch]
public class BlindOverlayPatch : OverlayPatch<BlindOverlay>;

[HarmonyPatch]
public class DrunkOverlayPatch : OverlayPatch<DrunkOverlay>;

[HarmonyPatch]
public class RainbowOverlayPatch : OverlayPatch<RainbowOverlay>;