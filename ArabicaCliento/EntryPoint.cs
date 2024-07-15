using ArabicaCliento.Input;
using Robust.Client.Input;
using Robust.Shared.ContentPack;
using Robust.Shared.IoC;
using Robust.Shared.Reflection;

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
            Function = ArabicaKeyFunctions.ToggleCheatMenu,
            BaseKey = Keyboard.Key.F4,
            Type = KeyBindingType.State
        };
        //_inputManager.RegisterBinding(registration, false);
        MarseyLogger.Debug("Setup context.");
        //ArabicaContexts.SetupContexts(_inputManager.Contexts);
        /*
        var dictionary =
            AccessTools.Field(typeof(BoundKeyMap), "KeyFunctionsMap")!.GetValue(_inputManager.NetworkBindMap) as
                Dictionary<BoundKeyFunction, KeyFunctionId>;
        MarseyLogger.Debug(
            $"MAP {"{" + string.Join(",", (dictionary ?? throw new InvalidOperationException()).Select(kv => kv.Key + "=" + kv.Value).ToArray()) + "}"}");
        var list =
            AccessTools.Field(typeof(BoundKeyMap), "KeyFunctionsList")!.GetValue(_inputManager.NetworkBindMap) as
                List<BoundKeyFunction>;
        MarseyLogger.Debug(
            $"LIST {string.Join(",", list ?? throw new InvalidOperationException())}");

        var listKeyBindo =
            AccessTools.Field(AccessTools.TypeByName("InputManager"), "_bindings").GetValue(_inputManager) as List<IKeyBinding>;
        MarseyLogger.Debug(
            $"listKeyBindo {string.Join(",", listKeyBindo ?? throw new InvalidOperationException())}");
        MarseyLogger.Debug("Setup is done.");
        */
    }
}