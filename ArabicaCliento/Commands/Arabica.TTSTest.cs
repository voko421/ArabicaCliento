// TODO: Rework this shit with reflection
/*using Content.Shared.Administration;
using Content.Shared.Corvax.TTS;
using Robust.Shared.Console;
using Robust.Shared.Prototypes;

namespace ArabicaCliento.Commands;

[AnyCommand]
public class TTSTestCommand : IConsoleCommand
{
    public string Command => "arabica.tts.test_tts";
    public string Description => "Test a TTS preview";
    public string Help => "arabica.spin.set_enabled <test_count>";

    public void Execute(IConsoleShell shell, string argStr, string[] args)
    {
        if (!int.TryParse(args[0], out var count))
        {
            shell.WriteError($"Can't parse {args[0]} as int");
            return;
        }

        var entMan = IoCManager.Resolve<IEntityManager>();
        var protoMan = IoCManager.Resolve<IPrototypeManager>();
        var speakers = protoMan.EnumeratePrototypes<TTSVoicePrototype>().Select(prototype => prototype.ID);
        for (var i = 0; i < count; i++)
            Task.Factory.StartNew(() =>
            {
                foreach (var speaker in speakers)
                {
                    entMan.EntityNetManager?.SendSystemNetworkMessage(new RequestPreviewTTSEvent(speaker));
                }
            });
    }
}
*/