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
    [Dependency] private readonly IInputManager _inputManager = default!;
    
    private sealed class OpenCheatMenuInputHandler(OpenCheatMenuSystem cheatMenuSystem) : InputCmdHandler
    {
        public override bool HandleCmdMessage(IEntityManager entManager, ICommonSession? session, IFullInputCmdMessage message)
        {
            if (session?.AttachedEntity == null) return false;
            
            cheatMenuSystem.Open();
            return false;
        }
    }
    
    private void Open()
    {
        _ui.GetFirstWindow<CheatMenuWindow>().OpenCentered();
    }

    public override void Initialize()
    {
        base.Initialize();
        var registration = new KeyBindingRegistration
        {
            Function = "СheatMenu",
            BaseKey = Keyboard.Key.F4,
            Type = KeyBindingType.Toggle
        };

        _inputManager.RegisterBinding(registration);
        CommandBinds.Builder
            .Bind("СheatMenu", new OpenCheatMenuInputHandler(this))
            .Register<OpenCheatMenuSystem>();
        MarseyLogger.Info("CheatMenu init done.");
    }
}