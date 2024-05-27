using Robust.Shared.ContentPack;
using Robust.Shared.IoC;

namespace ArabicaCliento;

public sealed class EntryPoint : GameShared
{
    public override void PostInit()
    {
        MarseyLogger.Info("Building graph...");
        IoCManager.BuildGraph();
        MarseyLogger.Info("Graph success built!");
    }
}