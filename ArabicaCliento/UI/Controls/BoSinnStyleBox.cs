using Content.Shared.Mobs;
using Robust.Client.Graphics;
using Robust.Shared.Graphics;

namespace ArabicaCliento.UI.Controls;

public class BoSinnStyleBox: StyleBoxTexture
{
    private const string TexturePath = "Arabica/bosinn.png";
    private static Texture? _boSinnCache;

    private static Texture? GetTexture()
    {
        if (_boSinnCache is not null)
            return _boSinnCache;
        if (!File.Exists(TexturePath))
            return null;
        using var stream = File.OpenRead(TexturePath);
        _boSinnCache = Texture.LoadFromPNGStream(stream, loadParameters: new TextureLoadParameters());
        return _boSinnCache;
    }
    
    public BoSinnStyleBox()
    {
        Texture = GetTexture();
        Modulate = new Color(255, 255, 255, 0);
    }
}