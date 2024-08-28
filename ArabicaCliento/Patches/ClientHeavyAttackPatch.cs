using Content.Shared.Weapons.Melee;
using HarmonyLib;
using Robust.Shared.Map;
using ArabicaCliento.Systems;
using Content.Client.Weapons.Melee;

namespace ArabicaCliento.Patches;

[HarmonyPatch(typeof(MeleeWeaponSystem), "ClientHeavyAttack")]
public class ClientHeavyAttackPatch
{
    public static bool Enabled = true;
    [HarmonyPrefix]
    private static void Prefix(ref EntityUid user,
        ref EntityCoordinates coordinates,
        ref EntityUid meleeUid,
        ref MeleeWeaponComponent component)
    {
        var entity = IoCManager.Resolve<EntityManager>();
        var xform = entity.System<SharedTransformSystem>();
        var aim = entity.System<ArabicaAimSystem>();

        var output = aim.GetClosestToEntInRange(user, component.Range, [user]);
        if (output == null || !Enabled) return;

        coordinates = EntityCoordinates.FromMap(coordinates.EntityId, output.Value.Position, xform, entity);
    }
}