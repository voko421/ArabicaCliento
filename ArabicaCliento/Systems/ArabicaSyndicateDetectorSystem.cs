using Content.Shared.Mobs.Components;
using Content.Shared.StatusIcon;
using Content.Shared.StatusIcon.Components;
using Content.Shared.Store.Components;
using Content.Shared.StoreDiscount.Components;
using Content.Shared.UserInterface;
using Robust.Shared.Prototypes;

namespace ArabicaCliento.Systems;

public sealed class ArabicaSyndicateDetectorSystem : EntitySystem
{
    [Dependency] private readonly IPrototypeManager _prototype = default!;

    private FactionIconPrototype? _syndicateIcon;
    
    public override void Initialize()
    {
        if (_prototype.TryIndex<FactionIconPrototype>("SyndicateFaction", out var iconPrototype))
        {
            _syndicateIcon = iconPrototype;
            SubscribeLocalEvent<MobStateComponent, GetStatusIconsEvent>(OnGetStatusIconsEvent);
        }
        else
            MarseyLogger.Warn("Can't find syndi icon. ArabicaIconsSystem is down");
    }

    private bool CheckUplink(EntityUid target)
    {
        if (HasComp<StoreDiscountComponent>(target)) return true; // Detect PDA uplink
        if (!TryComp<StoreComponent>(target, out var storeComponent)) return false; // Detect nukeops uplink
        return storeComponent.Balance.Sum(item => (float)item.Value) != 0;
    }

    private void OnGetStatusIconsEvent(EntityUid uid, MobStateComponent _, ref GetStatusIconsEvent ev)
    {
        if (!ArabicaConfig.SyndicateDetector) return;
        if (!TryComp<TransformComponent>(uid, out var transform)) return;
        var children = transform.ChildEnumerator;
        while (children.MoveNext(out var child))
        {
            if (!CheckUplink(child)) continue;

            ev.StatusIcons.Add(_syndicateIcon!);
            return;
        }
    }
}