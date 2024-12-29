using Content.Shared.Administration;
using Robust.Shared.Console;

namespace ArabicaCliento.Commands;

[AnyCommand]
public class ArabicaFriendCommand : IConsoleCommand
{
    public string Command => "arabica.friend";
    public string Description => "Add username to friend-list";
    public string Help => "arabica.friend <username>";

    public void Execute(IConsoleShell shell, string argStr, string[] args)
    {
        if (args.Length != 1)
        {
            shell.WriteError("Invalid args count");
            return;
        }
        
        if (ArabicaConfig.FriendsSet.Add(args[0]))
            shell.WriteLine("Username is successfully added");
        else
            shell.WriteError("Username is already presented");
    }
}