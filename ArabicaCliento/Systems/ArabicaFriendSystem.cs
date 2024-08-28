using ArabicaCliento.Components;
using Content.Shared.Verbs;

namespace ArabicaCliento.Systems;

public class ArabicaFriendSystem: EntitySystem
{
    public override void Initialize()
    {
        SubscribeLocalEvent<GetVerbsEvent<Verb>>(AddFriendVerb);
    }

    private void AddFriendVerb(GetVerbsEvent<Verb> ev)
    {
        Verb verb;
        if (HasComp<ArabicaFriendComponent>(ev.Target))
            verb = new Verb
            {
                Text = "Unfriend",
                Act = () => RemComp<ArabicaFriendComponent>(ev.Target),
                ClientExclusive = true
            };
        else
            verb = new Verb
            {
                Text = "Friend",
                Act = () => AddComp(ev.Target, new ArabicaFriendComponent {NetSyncEnabled = false}),
                ClientExclusive = true
            };
        ev.Verbs.Add(verb);
    }
}