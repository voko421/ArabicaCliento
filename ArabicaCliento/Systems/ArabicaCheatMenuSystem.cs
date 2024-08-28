using ArabicaCliento.Input;
using ArabicaCliento.UI;
using Robust.Client.Input;
using Robust.Client.UserInterface;
using Robust.Shared.Input.Binding;

namespace ArabicaCliento.Systems;


public class ArabicaCheatMenuSystem : EntitySystem
{
    [Dependency] private readonly IInputManager _input = default!;
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
        var handler = InputCmdHandler.FromDelegate(enabled: _ => ToggleMenu(), handle: false);
        _input.SetInputCommand(ArabicaKeyFunctions.ToggleCheatMenu, handler);
    }

    public override void Shutdown()
    {
        _window.Close();
        _window.Dispose();
    }
}