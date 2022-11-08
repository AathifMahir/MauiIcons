using MauiIcons.Core;

namespace MauiIcons.Material;
public sealed class MauiIcon : BaseMauiIcon
{
    public new MaterialIcons? Icon 
    {
        get => (MaterialIcons?)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }
    public override string IconFontFamily { get; set; } = Constants.FontFamily;
}
