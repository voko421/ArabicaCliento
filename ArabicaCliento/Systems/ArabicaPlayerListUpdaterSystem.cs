using Content.Client.Chat.Managers;
using Robust.Client.Player;
using Robust.Shared.Network;
using Robust.Shared.Network.Messages;
using Robust.Shared.Timing;

namespace ArabicaCliento.Systems;

/*public sealed class ArabicaPlayerListUpdaterSystem: EntitySystem
{
    private static readonly TimeSpan UpdateTime = TimeSpan.FromSeconds(4);
    [Dependency] private readonly IGameTiming _timing = default!;
    [Dependency] private readonly IPlayerManager _player = default!;
    [Dependency] private readonly INetManager _net = default!;

    private TimeSpan? _nextUpdate = null;

    public override void Initialize()
    {
        _nextUpdate = _timing.CurTime + UpdateTime;
        _player.PlayerListUpdated += OnPlayerListUpdated;
    }

    public override void Update(float frameTime)
    {
        if (_timing.CurTime > _nextUpdate)
            return;
        _net.ClientSendMessage(new MsgPlayerListReq());
        _nextUpdate = _timing.CurTime + UpdateTime;
    }

    public override void Shutdown()
    {
        _nextUpdate = null;
        _player.PlayerListUpdated -= OnPlayerListUpdated;
    }

    private void OnPlayerListUpdated()
    {
        
    }
}
*/