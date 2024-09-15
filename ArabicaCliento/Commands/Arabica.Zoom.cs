using ArabicaCliento.Systems;
using Content.Shared.Administration;
using Robust.Client.Player;
using Robust.Shared.Console;

namespace ArabicaCliento.Commands;

[AnyCommand]
public class ForceZoomCommand : IConsoleCommand
{
    public string Command => "arabica.auto_zoom.set";
    public string Description => "Set forced zoom";
    public string Help => "arabica.auto_zoom.set <zoom>";

    public void Execute(IConsoleShell shell, string argStr, string[] args)
    {
        if (args.Length != 1)
        {
            shell.WriteError("Invalid args count");
            return;
        }

        if (!float.TryParse(args[0], out var zoom))
        {
            shell.WriteError($"Unable to parse {args[0]} as float");
            return;
        }

        var sys = IoCManager.Resolve<IEntityManager>().System<ArabicaAutoZoomSystem>();
        sys.UpdateZoom(zoom);
    }
}