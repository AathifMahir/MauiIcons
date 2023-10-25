using MauiIcons.Core.Converters;
using MauiIcons.Core.Helpers;
using Microsoft.Maui.Graphics.Converters;

namespace MauiIcons.Core;
public sealed class MauiIcon : ContentView
{
    public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(Enum), typeof(MauiIcon), null);
    public static readonly BindableProperty IconSizeProperty = BindableProperty.Create(nameof(IconSize), typeof(double), typeof(MauiIcon), 30.0);
    public static readonly BindableProperty IconColorProperty = BindableProperty.Create(nameof(IconColor), typeof(Color), typeof(MauiIcon), ThemeHelper.SetThemeAwareIconColor());
    public static readonly BindableProperty IconBackgroundColorProperty = BindableProperty.Create(nameof(IconBackgroundColor), typeof(Color), typeof(MauiIcon), Colors.Transparent);
    public static readonly BindableProperty IconAutoScalingProperty = BindableProperty.Create(nameof(IconAutoScaling), typeof(bool), typeof(MauiIcon), false);

#nullable enable
    public Enum? Icon
    {
        get => (Enum?)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

#nullable disable

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
    public MauiIcon()
    {
        Content = BuildControl();
        Loaded += (s, r) => { label.FontFamily = Icon.GetType().Name; };
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

    public static explicit operator FontImageSource(MauiIcon baseIcon) => new()
    {
        Glyph = baseIcon.Icon.GetDescription(),
        Color = baseIcon.IconColor.SetDefaultOrAssignedColor(),
        FontFamily = baseIcon.Icon.GetType().Name,
        Size = baseIcon.IconSize,
        FontAutoScalingEnabled = baseIcon.IconAutoScaling
    };

    public static explicit operator string(MauiIcon baseIcon) => baseIcon.Icon.GetDescription();
}
