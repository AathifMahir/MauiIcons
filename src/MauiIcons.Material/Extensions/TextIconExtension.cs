using MauiIcons.Core;

namespace MauiIcons.Material;
public sealed class TextIconExtension : BaseTextIconExtension
{
    public new MaterialIcons? Icon
    {
        get => (MaterialIcons?)base.Icon;
        set => base.Icon = value;
    }
}
