namespace MauiIcons.Core.Base;
public abstract class BaseMauiIcon : ContentView
{
    public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(Enum), typeof(BaseMauiIcon), null);

    public Enum? Icon
    {
        get => (Enum?)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }
}
