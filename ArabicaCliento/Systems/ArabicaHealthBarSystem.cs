using ArabicaCliento.Systems.Abstract;
using Content.Shared.Overlays;

namespace ArabicaCliento.Systems;

public class ArabicaHealthBarSystem : LocalPlayerAddCompSystem<ShowHealthBarsComponent>
{
    protected override ShowHealthBarsComponent CompOverride =>
        new ShowHealthBarsComponent { DamageContainers = ["Biological", "Silicon"] };
}