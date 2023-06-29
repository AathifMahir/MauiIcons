using MauiIcons.Core.Converters;
using MauiIcons.Core.Helpers;

namespace MauiIcons.Core;

[ContentProperty(nameof(Icon))]
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

    [System.ComponentModel.TypeConverter(typeof(FontSizeConverter))]
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
    public BaseMauiIcon()
    {
        Content = BuildControl();
        Loaded += (s, r) => { fontImageSource.FontFamily = AssignDefaultFontFamily(); };
    }

    FontImageSource fontImageSource;
    private Image BuildControl()
    {
        Image image = new() { Aspect = Aspect.Center };
        fontImageSource = new();
        fontImageSource.SetBinding(FontImageSource.GlyphProperty, new Binding(nameof(Icon), source: this, converter: new EnumToStringConverter()));
        fontImageSource.SetBinding(FontImageSource.FontAutoScalingEnabledProperty, new Binding(nameof(IconAutoScaling), source: this));
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
            FontFamily = baseIcon.AssignDefaultFontFamily(),
            Size = baseIcon.IconSize,
            FontAutoScalingEnabled = baseIcon.IconAutoScaling
        };
    }

    public void NotifyFontFamilyChanged(string fontFamily)
    {
        if (fontImageSource is null) return;
        if (fontImageSource.FontFamily == fontFamily) return;
        fontImageSource.FontFamily = fontFamily;
    }

    string AssignDefaultFontFamily()
    {
        if(fontImageSource is null) return string.Empty;
        if (fontImageSource.FontFamily is not null) return fontImageSource.FontFamily;
        return Icon.GetType().Name;
    }

}