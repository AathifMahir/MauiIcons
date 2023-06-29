using MauiIcons.Core;

namespace MauiIcons.Material;
public sealed class MauiIcon : BaseMauiIconVariant
{
    public new MaterialIcons? Icon
    {
        get => (MaterialIcons?)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }
    public new MaterialVariant Variant
    {
        get => (MaterialVariant)GetValue(VariantProperty);
        set => SetValue(VariantProperty, value);
    }
    protected override Dictionary<Enum, string> VariantType { get; set; } = new Dictionary<Enum, string>()
    {
        { MaterialVariant.Regular, Constants.RegularFontFamily },
        { MaterialVariant.Outlined, Constants.OutlinedFontFamily },
        { MaterialVariant.Rounded, Constants.RoundedFontFamily },
        { MaterialVariant.Sharp, Constants.SharpFontFamily },
        { MaterialVariant.TwoTone, Constants.TwoToneFontFamily },
    };
}
