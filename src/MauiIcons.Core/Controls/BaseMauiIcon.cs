using MauiIcons.Core.Converters;
using MauiIcons.Core.Helpers;
using Microsoft.Maui.Graphics.Converters;

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

    [System.ComponentModel.TypeConverter(typeof(ColorTypeConverter))]
    public Color IconColor
    {
        get => (Color)GetValue(IconColorProperty);
        set => SetValue(IconColorProperty, value);
    }

    [System.ComponentModel.TypeConverter(typeof(ColorTypeConverter))]
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
        Loaded += (s, r) => { label.FontFamily = SetDefaultFontFamily(); };
    }

    Label label;
    private Label BuildControl()
    {
        label = new();
        label.SetBinding(Label.TextProperty, new Binding(nameof(Icon), converter: new EnumToStringConverter(), source: this));
        label.SetBinding(Label.FontAutoScalingEnabledProperty, new Binding(nameof(IconAutoScaling), source: this));
        label.SetBinding(Label.FontSizeProperty, new Binding(nameof(IconSize), source: this));
        label.SetBinding(Label.TextColorProperty, new Binding(nameof(IconColor), source: this));
        label.SetBinding(Label.BackgroundColorProperty, new Binding(nameof(IconBackgroundColor), source: this));
        return label;
    }

    public static explicit operator FontImageSource(BaseMauiIcon baseIcon)
    {
        return new FontImageSource()
        {
            Glyph = baseIcon.Icon is not null ? EnumHelper.GetEnumDescription(baseIcon.Icon) : string.Empty,
            Color = baseIcon.IconColor ?? ThemeHelper.SetDefaultIconColor(),
            FontFamily = baseIcon.SetDefaultFontFamily(),
            Size = baseIcon.IconSize,
            FontAutoScalingEnabled = baseIcon.IconAutoScaling
        };
    }

    string SetDefaultFontFamily()
    {
        if (label is null) return string.Empty;
        if (label.FontFamily is not null && label.FontFamily.Contains(Icon?.GetType().Name)) return label.FontFamily;
        return Icon?.GetType().Name;
    }
    public void NotifyFontFamilyChanged(string fontFamily)
    {
        if (label is null) return;
        if (label.FontFamily == fontFamily) return;
        label.FontFamily = fontFamily;
    }
}