using MauiIcons.Core;

namespace MauiIcons.Material;
public sealed class IconExtension : BaseIconVariantExtension
{
    public new MaterialIcons? Icon
    {
        get => (MaterialIcons?)base.Icon;
        set => base.Icon = value;
    }
    public new MaterialVariant Variant 
    { 
        get => (MaterialVariant)base.Variant;
        set => base.Variant = value;
    }
    protected override Dictionary<Enum, string> VariantType { get; set; } = new Dictionary<Enum, string>()
    {
        { MaterialVariant.Regular, Constants.RegularFontFamily },
        { MaterialVariant.Outlined, Constants.OutlinedFontFamily },
        { MaterialVariant.Rounded, Constants.RoundedFontFamily },
        { MaterialVariant.Sharp, Constants.SharpFontFamily }
    };
}
