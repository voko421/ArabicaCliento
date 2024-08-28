using System.Numerics;
using ArabicaCliento.Systems.Abstract;
using Content.Client.Commands;
using Robust.Client.GameObjects;
using Robust.Client.Player;
using Robust.Shared.Player;

namespace ArabicaCliento.Systems;

public class ArabicaAutoZoomSystem : LocalPlayerSystem
{
    [Dependency] private readonly IPlayerManager _player = default!;

    private float _zoom = 1.5f;

    public void UpdateZoom(float zoom)
    {
        _zoom = zoom;
        if (_player.LocalEntity == null)
            return;
        if (!TryComp<EyeComponent>(_player.LocalEntity.Value, out var eyeComponent))
            return;
        eyeComponent.Eye.Zoom = new Vector2(_zoom, _zoom);
    }

    protected override void OnAttached(LocalPlayerAttachedEvent ev)
    {
        if (!TryComp<EyeComponent>(ev.Entity, out var eyeComponent))
            return;
        eyeComponent.NetSyncEnabled = false;
        eyeComponent.Eye.Zoom = new Vector2(_zoom, _zoom);
    }

    protected override void OnDetached(LocalPlayerDetachedEvent ev)
    {
        if (!TryComp<EyeComponent>(ev.Entity, out var eyeComponent))
            return;
        eyeComponent.Eye.Zoom = eyeComponent.Zoom;
        eyeComponent.NetSyncEnabled = true;
    }
}