using Content.Shared.Input;
using Robust.Shared.Input;

namespace ArabicaCliento.Input;

public static class ArabicaContexts
{
    public static void SetupContexts(IInputContextContainer contexts)
    {
        var common = contexts.GetContext("common");
        common.AddFunction(ArabicaKeyFunctions.ToggleCheatMenu);
    }
}