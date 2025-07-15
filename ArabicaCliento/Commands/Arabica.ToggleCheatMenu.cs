using ArabicaCliento.Systems;
using ArabicaCliento.UI;
using Content.Shared.Administration;
using Robust.Client.UserInterface;
using Robust.Shared.Console;

namespace ArabicaCliento.Commands;

[AnyCommand]
public class ToggleCheatMenuCommand: IConsoleCommand
{
    public string Command => "arabica.toggle_menu";
    public string Description => "This command toggle the cheat menu";
    
    public string Help => "arabica.toggle_menu";
    
    public void Execute(IConsoleShell shell, string argStr, string[] args)
    {
        IoCManager.Resolve<IUserInterfaceManager>().GetUIController<ArabicaCheatMenuUiController>().ToggleMenu();
    }
}