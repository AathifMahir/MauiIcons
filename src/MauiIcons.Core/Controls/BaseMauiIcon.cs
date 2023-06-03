using MauiIcons.Core.Converters;
using MauiIcons.Core.Helpers;

namespace MauiIcons.Core;

public abstract class BaseMauiIcon : ContentView
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
        Content = BuildControl();
    }

    private Image BuildControl()
    {
        Image image = new() { Aspect = Aspect.Center };
        FontImageSource fontImageSource = new();
        fontImageSource.SetBinding(FontImageSource.GlyphProperty, new Binding(nameof(Icon), source: this, converter: new EnumToStringConverter()));
        fontImageSource.SetBinding(FontImageSource.FontAutoScalingEnabledProperty, new Binding(nameof(IconAutoScaling), source: this));
        fontImageSource.SetBinding(FontImageSource.FontFamilyProperty, new Binding(nameof(IconFontFamily), source: this));
        fontImageSource.SetBinding(FontImageSource.SizeProperty, new Binding(nameof(IconSize), source: this));
        fontImageSource.SetBinding(FontImageSource.ColorProperty, new Binding(nameof(IconColor), source: this));
        image.Source = fontImageSource;
        return image;
    }

    public static explicit operator FontImageSource(BaseMauiIcon baseIcon)
    {
        return new FontImageSource()
        {
            Glyph = baseIcon.Icon is not null ? EnumHelper.GetEnumDescription(baseIcon.Icon) : string.Empty,
            Color = baseIcon.IconColor ?? ThemeHelper.SetDefaultIconColor(),
            FontFamily = baseIcon.IconFontFamily,
            Size = baseIcon.IconSize,
            FontAutoScalingEnabled = baseIcon.IconAutoScaling
        };
    }

}