using ArabicaCliento.Input;
using ArabicaCliento.UI;
using Content.Shared.Input;
using Content.Shared.Movement.Systems;
using Robust.Client.Input;
using Robust.Client.UserInterface;
using Robust.Shared.GameObjects;
using Robust.Shared.Input;
using Robust.Shared.Input.Binding;
using Robust.Shared.IoC;
using Robust.Shared.Maths;
using Robust.Shared.Player;

namespace ArabicaCliento.Systems;


public class OpenCheatMenuSystem : EntitySystem
{
    [Dependency] private readonly IUserInterfaceManager _ui = default!;
    private CheatMenuWindow _window = null!;

    public void ToggleMenu()
    {
        if (!_window.IsOpen)
            _window.OpenCentered();
        else
            _window.Close();
    }


    public override void Initialize()
    {
        _window = _ui.CreateWindow<CheatMenuWindow>();
        MarseyLogger.Info("CheatMenu init done.");
    }

    public override void Shutdown()
    {
        base.Shutdown();
        _window.Close();
        _window.Dispose();
    }
}