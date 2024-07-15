using ArabicaCliento.Systems;
using Content.Shared.Administration;
using Robust.Shared.Console;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;

namespace ArabicaCliento.Commands;

[AnyCommand]
public class ArabicaToggleMenuCommand : IConsoleCommand
{
    [Dependency] private readonly IEntitySystemManager _systemManager = default!;


    public string Command => "arabica.toggle_menu";
    public string Description => "This command toggle the cheat menu";
    public string Help => "Toggle the cheat menu";

    public void Execute(IConsoleShell shell, string argStr, string[] args)
    {
        _systemManager.GetEntitySystem<OpenCheatMenuSystem>().ToggleMenu();
    }
}