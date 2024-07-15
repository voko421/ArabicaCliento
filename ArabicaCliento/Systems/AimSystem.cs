using Content.Client.CombatMode;
using Content.Shared.Mobs;
using Content.Shared.Mobs.Components;
using Robust.Client.GameObjects;
using Robust.Client.Graphics;
using Robust.Client.Input;
using Robust.Shared.Configuration;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Map;

namespace ArabicaCliento.Systems;

public class AimSystem : EntitySystem
{
    [Dependency] private readonly IEyeManager _eyeManager = default!;
    [Dependency] private readonly IInputManager _input = default!;
    [Dependency] private readonly TransformSystem _transform = default!;
    [Dependency] private readonly IConfigurationManager _cfgManager = default!;
    [Dependency] private readonly IOverlayManager _overlayManager = default!;
    [Dependency] private readonly CombatModeSystem _combatSystem = default!;

    public override void Initialize()
    {
        base.Initialize();
    }

    public MapCoordinates? GetClosetAliveMob(EntityUid controlledEntity)
    {
        var mousePos = _input.MouseScreenPosition;

        var query = EntityQueryEnumerator<TransformComponent, MobStateComponent>();

        var distanceToMouse = float.MaxValue;
        MapCoordinates? closest = null;
        while (query.MoveNext(out var uid, out var transform, out var state))
        {
            if (transform.MapID != _eyeManager.CurrentMap) continue;
            if (uid == controlledEntity) continue;
            if (state.CurrentState != MobState.Alive) continue;
            var entityMapPos = _transform.GetMapCoordinates(transform);

            var entityScreenPos = _eyeManager.MapToScreen(entityMapPos);
            var vector = mousePos.Position - entityScreenPos.Position;
            var distance = vector.Length();

            if (!(distance <= distanceToMouse) || !(distance < 180)) continue;
            closest = entityMapPos;
            distanceToMouse = distance;
        }
        return closest;
    }
}