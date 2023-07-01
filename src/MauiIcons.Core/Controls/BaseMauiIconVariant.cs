namespace MauiIcons.Core;
public abstract class BaseMauiIconVariant : BaseMauiIcon
{
    public static readonly BindableProperty VariantProperty = BindableProperty.Create(nameof(Variant), typeof(Enum), typeof(BaseMauiIconVariant), null, propertyChanged: OnVariantPropertyChanged);
    public virtual Enum Variant
    {
        get => (Enum)GetValue(VariantProperty);
        set => SetValue(VariantProperty, value);
    }
    protected abstract Dictionary<Enum, string> VariantType { get; set; } 
    private static void OnVariantPropertyChanged(BindableObject bindable, object oldValue, object newValue) 
    {
        if (!((BaseMauiIconVariant)bindable).VariantType.ContainsKey((Enum)newValue)) return;
        ((BaseMauiIconVariant)bindable).VariantType.TryGetValue((Enum)newValue, out string fontFamily);
        ((BaseMauiIconVariant)bindable).NotifyFontFamilyChanged(fontFamily);
    }
}
