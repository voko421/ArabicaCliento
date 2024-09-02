using Content.Client.Administration.Systems;
using Content.Shared.Administration;
using Robust.Client.Player;
using Robust.Shared.Console;

namespace ArabicaCliento.Commands;

[AnyCommand]
public class ArabicaPlayerList : IConsoleCommand
{
    public string Command => "arabica.player_list";
    public string Description => "Output a playerlist";
    public string Help => "arabica.player_list";

    public void Execute(IConsoleShell shell, string argStr, string[] args)
    {
        var man = IoCManager.Resolve<IPlayerManager>();
        foreach (var ses in man.Sessions)
        {
            shell.WriteLine(ses.Name);
        }
    }
}