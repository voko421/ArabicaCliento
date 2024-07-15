using Content.Shared.Weapons.Melee;
using HarmonyLib;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using System.Reflection;
using ArabicaCliento.Systems;
using Content.Client.Weapons.Melee;

namespace ArabicaCliento.Patches;

[HarmonyPatch(typeof(MeleeWeaponSystem), "ClientHeavyAttack")]
class ClientHeavyAttackPatch
{
    [HarmonyPrefix]
    private static void Prefix(ref EntityUid user,
        ref EntityCoordinates coordinates,
        ref EntityUid meleeUid,
        ref MeleeWeaponComponent component)
    {
        var entity = IoCManager.Resolve<EntityManager>();
        var xform = entity.System<SharedTransformSystem>();
        var aim = entity.System<AimSystem>();

        var mapCoords = aim.GetClosetAliveMob(user);
        if (mapCoords == null) return;

        coordinates = EntityCoordinates.FromMap(coordinates.EntityId, mapCoords.Value, xform, entity);
    }
}