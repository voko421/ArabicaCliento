using Robust.Client.Input;
using Robust.Shared.ContentPack;

namespace ArabicaCliento;

public sealed class EntryPoint : GameShared
{
    [Dependency] private readonly IInputManager _inputManager = default!;

    public override void PostInit()
    {
        MarseyLogger.Debug("Building graph...");
        IoCManager.BuildGraph();
        MarseyLogger.Debug("Graph success built!");
        IoCManager.InjectDependencies(this);
        var registration = new KeyBindingRegistration
        {
            Function = "arabica.toggle_menu",
            BaseKey = Keyboard.Key.F4,
            Type = KeyBindingType.Command
        };
        _inputManager.RegisterBinding(registration, false);
        MarseyLogger.Debug("Setup context.");
    }
}