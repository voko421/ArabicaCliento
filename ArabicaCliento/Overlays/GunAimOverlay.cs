using Content.Client.CombatMode;
using Content.Client.Weapons.Ranged.Systems;
using Robust.Client.Graphics;
using Robust.Client.Input;
using Robust.Client.Player;
using Robust.Shared.Enums;
using Robust.Shared.Map;
using Robust.Shared.Timing;

namespace ArabicaCliento.Overlays;

public class GunAimOverlay(
    IEntityManager entManager,
    IEyeManager eye,
    IInputManager input,
    IPlayerManager player,
    GunSystem guns,
    SharedTransformSystem transform,
    CombatModeSystem combatModeSystem)
    : Overlay
{
    public override OverlaySpace Space => OverlaySpace.WorldSpace;


    protected override void Draw(in OverlayDrawArgs args)
    {
        var worldHandle = args.WorldHandle;

        var player1 = player.LocalEntity;

        if (player1 == null ||
            !entManager.TryGetComponent<TransformComponent>(player1, out var xform))
        {
            return;
        }

        var mapPos = transform.GetMapCoordinates(player1.Value, xform: xform);

        if (mapPos.MapId == MapId.Nullspace)
            return;

        if (!combatModeSystem.IsInCombatMode(player1))
            return;

        if (!guns.TryGetGun(player1.Value, out _, out _))
            return;

        var mouseScreenPos = input.MouseScreenPosition;
        var mousePos = eye.PixelToMap(mouseScreenPos);

        if (mapPos.MapId != mousePos.MapId)
            return;

        worldHandle.DrawCircle(mousePos.Position, ArabicaConfig.RangedAimbotRadius, Color.White, false);
    }
}