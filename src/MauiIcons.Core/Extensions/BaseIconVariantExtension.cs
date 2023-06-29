namespace MauiIcons.Core;
public abstract class BaseIconVariantExtension : BaseIconExtension
{
    Enum _variant;
    public virtual Enum Variant 
    {
        get => _variant;
        set
        {
            if (value != _variant)
            {
                _variant = value;
                IconFontFamily = GetVariantFontFamily(value);
            }
        }
    }
    protected abstract Dictionary<Enum, string> VariantType { get; set; }

    string GetVariantFontFamily(Enum variant)
    {
        if (variant is null || VariantType is null) return string.Empty;
        if (VariantType.ContainsKey(variant) && VariantType.TryGetValue(variant, out string fontFamily)) return fontFamily;
        return Icon.GetType().Name;
    }
}
