using MauiIcons.Core.Helpers;
namespace MauiIcons.Core;

public abstract partial class BaseMauiIcon : ContentView
{
    public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(Enum), typeof(BaseMauiIcon), null);
    public static readonly BindableProperty IconSizeProperty = BindableProperty.Create(nameof(IconSize), typeof(double), typeof(BaseMauiIcon), 30.0);
    public static readonly BindableProperty IconColorProperty = BindableProperty.Create(nameof(IconColor), typeof(Color), typeof(BaseMauiIcon), ThemeHelper.SetDefaultIconColor());
    public static readonly BindableProperty IconBackgroundColorProperty = BindableProperty.Create(nameof(IconBackgroundColor), typeof(Color), typeof(BaseMauiIcon), Colors.Transparent);
    public static readonly BindableProperty IconAutoScalingProperty = BindableProperty.Create(nameof(IconAutoScaling), typeof(bool), typeof(BaseMauiIcon), false);
    
    public virtual Enum Icon 
    {
        get => (Enum)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }
    public double IconSize
    {
        get => (double)GetValue(IconSizeProperty);
        set => SetValue(IconSizeProperty, value);
    }
    public Color IconColor
    {
        get => (Color)GetValue(IconColorProperty);
        set => SetValue(IconColorProperty, value);
    }

    public Color IconBackgroundColor
    {
        get => (Color)GetValue(IconBackgroundColorProperty);
        set => SetValue(IconBackgroundColorProperty, value);
    }
    public bool IconAutoScaling
    {
        get => (bool)GetValue(IconAutoScalingProperty);
        set => SetValue(IconAutoScalingProperty, value);
    }
    public abstract string IconFontFamily { get; set; }



    public BaseMauiIcon()
	{
		InitializeComponent();
        BindingContext = this;
    }

    public static explicit operator FontImageSource(BaseMauiIcon baseIcon)
    {
        return new FontImageSource()
        {
            Glyph = baseIcon.Icon != null ? EnumHelper.GetEnumDescription(baseIcon.Icon) : string.Empty,
            Color = baseIcon.IconColor ?? ThemeHelper.SetDefaultIconColor(),
            FontFamily = baseIcon.IconFontFamily,
            Size = baseIcon.IconSize,
            FontAutoScalingEnabled = baseIcon.IconAutoScaling
        };
    }

}