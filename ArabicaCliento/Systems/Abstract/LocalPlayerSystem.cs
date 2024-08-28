using Robust.Shared.Player;

namespace ArabicaCliento.Systems.Abstract;

public abstract class LocalPlayerSystem: EntitySystem
{
    public override void Initialize()
    {
        SubscribeLocalEvent<LocalPlayerAttachedEvent>(OnAttached);
        SubscribeLocalEvent<LocalPlayerDetachedEvent>(OnDetached);
    }
    
    protected abstract void OnAttached(LocalPlayerAttachedEvent ev);
    
    protected abstract void OnDetached(LocalPlayerDetachedEvent ev);

}