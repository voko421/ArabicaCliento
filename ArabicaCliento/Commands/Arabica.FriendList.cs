using Content.Shared.Administration;
using Robust.Shared.Console;

namespace ArabicaCliento.Commands;

[AnyCommand]
public class ArabicaFriendList : IConsoleCommand
{
    public string Command => "arabica.friend_list";
    public string Description => "Output a friendlist";
    public string Help => "arabica.friend_list";

    public void Execute(IConsoleShell shell, string argStr, string[] args)
    {
        foreach (var friend in ArabicaConfig.FriendsSet)
        {
            shell.WriteLine(friend);
        }
    }
}