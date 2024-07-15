using Content.Shared.Administration;
using Robust.Client.Player;
using Robust.Shared.Console;
using Robust.Shared.IoC;
using Robust.Shared.Network.Messages;

namespace ArabicaCliento.Commands;

[AnyCommand]
public class ArabicaPlayerList: IConsoleCommand
{
    public string Command => "arabica.toggle_menu";
    public string Description => "This command toggle the cheat menu";
    public string Help => "Toggle the cheat menu";
    
    public void Execute(IConsoleShell shell, string argStr, string[] args)
    {
    }
}