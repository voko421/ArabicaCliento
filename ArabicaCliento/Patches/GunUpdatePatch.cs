using System.Reflection.Emit;
using ArabicaCliento.Systems;
using Content.Client.Weapons.Ranged.Systems;
using Content.Shared.Weapons.Ranged.Events;
using HarmonyLib;
using Robust.Client.Input;
using Robust.Client.Player;
using Robust.Shared.Map;

namespace ArabicaCliento.Patches;

[HarmonyPatch(typeof(GunSystem), nameof(GunSystem.Update))]
public class GunUpdatePatch
{
    NetCoordinates Patch(EntityCoordinates realCoordinates, MetaDataComponent metadata)
    {
        var entity = IoCManager.Resolve<EntityManager>();
        if (!ArabicaConfig.RangedAimbotEnabled)
            return entity.GetNetCoordinates(realCoordinates);
        var inputManager = IoCManager.Resolve<IInputManager>();
        var playerMan = IoCManager.Resolve<IPlayerManager>();
        var transform = entity.System<SharedTransformSystem>();
        var aimSystem = entity.System<ArabicaAimSystem>();
        HashSet<EntityUid>? exclude = null;
        if (playerMan.LocalEntity != null)
            exclude = [playerMan.LocalEntity.Value];
        var aimOutput =
            aimSystem.GetClosestInRange(inputManager.MouseScreenPosition, ArabicaConfig.RangedAimbotRadius, exclude);
        if (aimOutput == null)
        {
            return entity.GetNetCoordinates(realCoordinates);
        }

        var closest = EntityCoordinates.FromMap(realCoordinates.EntityId, aimOutput.Value.Position, transform, entity);
        return entity.GetNetCoordinates(closest);
    }

    [HarmonyTranspiler]
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var requestShootCoordinatesField =
            AccessTools.Field(typeof(RequestShootEvent), nameof(RequestShootEvent.Coordinates));
        var methodInfo = AccessTools.Method(typeof(GunUpdatePatch), nameof(Patch));

        var codes = new List<CodeInstruction>(instructions);
        var index = codes.FindIndex(c => c.StoresField(requestShootCoordinatesField));

        codes[index - 1] = new CodeInstruction(OpCodes.Call, methodInfo); // Before stfld goes call

        return codes.AsEnumerable();
    }
}