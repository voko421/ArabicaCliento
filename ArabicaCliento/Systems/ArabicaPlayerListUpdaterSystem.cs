using Content.Client.Chat.Managers;
using Robust.Client.Player;

namespace ArabicaCliento.Systems;

public sealed class ArabicaPlayerListUpdaterSystem: EntitySystem
{
    [Dependency] private readonly IChatManager _chat = default!;
    [Dependency] private readonly IPlayerManager _player = default!;

    public override void Initialize()
    {
        _player.PlayerListUpdated += OnPlayerListUpdated;
    }

    public override void Shutdown()
    {
        _player.PlayerListUpdated -= OnPlayerListUpdated;
    }

    private void OnPlayerListUpdated()
    {
    }
}