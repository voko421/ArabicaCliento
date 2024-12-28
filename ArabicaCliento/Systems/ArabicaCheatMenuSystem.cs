using ArabicaCliento.UI;
using Robust.Client.UserInterface;

namespace ArabicaCliento.Systems;


public class ArabicaCheatMenuSystem : EntitySystem
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
        _window.Close();
        _window.Dispose();
    }
}