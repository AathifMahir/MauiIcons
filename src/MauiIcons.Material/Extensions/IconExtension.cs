using MauiIcons.Core;

namespace MauiIcons.Material;
public sealed class IconExtension : BaseIconExtension
{
    public new MaterialIcons? Icon
    {
        get => (MaterialIcons?)base.Icon;
        set => base.Icon = value;
    }
    protected override string IconFontFamily { get; set; } = Constants.FontFamily;
}
