using MauiIcons.Core;

namespace MauiIcons.SegoeFluent;
public sealed class MauiIcon : BaseMauiIcon
{
    public new SegoeFluentIcons? Icon 
    {
        get => (SegoeFluentIcons?)GetValue(IconProperty); 
        set => SetValue(IconProperty, value);
    }
    public override string IconFontFamily { get; set; } = Constants.FontFamily;
}
