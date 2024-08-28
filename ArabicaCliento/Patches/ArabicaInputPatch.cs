using ArabicaCliento.Input;
using HarmonyLib;
using Robust.Client.GameObjects;
using Robust.Client.GameStates;
using Robust.Client.Input;
using Robust.Shared.Input;

namespace ArabicaCliento.Patches;

//[HarmonyPatch(typeof(InputSystem), "DispatchInputCommand")]
public class ArabicaInputPatch
{
    [HarmonyPrefix]
    private static bool Prefix(ClientFullInputCmdMessage clientMsg, FullInputCmdMessage message)
    {
        var stateMan = IoCManager.Resolve<IClientGameStateManager>();
        var entMan = IoCManager.Resolve<IEntityManager>();
        var inputMan = IoCManager.Resolve<IInputManager>();
        stateMan.InputCommandDispatched(clientMsg, message);
        
        if (message.InputFunctionId != inputMan.NetworkBindMap.KeyFunctionID(ArabicaKeyFunctions.ToggleCheatMenu))
            entMan.EntityNetManager?.SendSystemNetworkMessage(message, message.InputSequence);
        return false;
    }
    
}