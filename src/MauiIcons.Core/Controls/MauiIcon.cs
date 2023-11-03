using MauiIcons.Core.Converters;
using MauiIcons.Core.Helpers;
using Microsoft.Maui.Graphics.Converters;

namespace MauiIcons.Core;
public sealed class MauiIcon : Label, IMauiIcon, ILabel
{
    public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(Enum), typeof(MauiIcon), null);
    public static readonly BindableProperty IconSizeProperty = BindableProperty.Create(nameof(IconSize), typeof(double), typeof(MauiIcon), 30.0);
    public static readonly BindableProperty IconColorProperty = BindableProperty.Create(nameof(IconColor), typeof(Color), typeof(MauiIcon), ThemeHelper.SetThemeAwareIconColor());
    public static readonly BindableProperty IconBackgroundColorProperty = BindableProperty.Create(nameof(IconBackgroundColor), typeof(Color), typeof(MauiIcon), Colors.Transparent);
    public static readonly BindableProperty IconAutoScalingProperty = BindableProperty.Create(nameof(IconAutoScaling), typeof(bool), typeof(MauiIcon), false);
    public static readonly BindableProperty IconSuffixProperty = BindableProperty.Create(nameof(IconSuffix), typeof(string), typeof(MauiIcon), null);
    public static readonly BindableProperty IconSuffixFontFamilyProperty = BindableProperty.Create(nameof(IconSuffixFontFamily), typeof(string), typeof(MauiIcon), null);
    public static readonly BindableProperty IconSuffixFontSizeProperty = BindableProperty.Create(nameof(IconSuffixFontSize), typeof(double), typeof(MauiIcon), 20.0);
    public static readonly BindableProperty IconSuffixTextColorProperty = BindableProperty.Create(nameof(IconSuffixTextColor), typeof(Color), typeof(MauiIcon), null);
    public static readonly BindableProperty IconSuffixAutoScalingProperty = BindableProperty.Create(nameof(IconSuffixAutoScaling), typeof(bool), typeof(MauiIcon), false);
    public static readonly BindableProperty EntranceAnimationTypeProperty = BindableProperty.Create(nameof(EntranceAnimationType), typeof(AnimationType), typeof(MauiIcon), AnimationType.None);
    public static readonly BindableProperty EntranceAnimationDurationProperty = BindableProperty.Create(nameof(EntranceAnimationDuration), typeof(uint), typeof(MauiIcon), (uint)1500);
    

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
    public string IconSuffix
    {
        get => (string)GetValue(IconSuffixProperty);
        set => SetValue(IconSuffixProperty, value);
    }

    public string IconSuffixFontFamily
    {
        get => (string)GetValue(IconSuffixFontFamilyProperty);
        set => SetValue(IconSuffixFontFamilyProperty, value);
    }

    [System.ComponentModel.TypeConverter(typeof(FontSizeConverter))]
    public double IconSuffixFontSize
    {
        get => (double)GetValue(IconSuffixFontSizeProperty);
        set => SetValue(IconSuffixFontSizeProperty, value);

    }

    [System.ComponentModel.TypeConverter(typeof(ColorTypeConverter))]
    public Color IconSuffixTextColor
    {
        get => (Color)GetValue(IconSuffixTextColorProperty);
        set => SetValue(IconSuffixTextColorProperty, value);
    }

    public bool IconSuffixAutoScaling
    {
        get => (bool)GetValue(IconSuffixAutoScalingProperty);
        set => SetValue(IconSuffixAutoScalingProperty, value);
    }

    public AnimationType EntranceAnimationType
    {
        get => (AnimationType)GetValue(EntranceAnimationTypeProperty);
        set => SetValue(EntranceAnimationTypeProperty, value);
    }

    public uint EntranceAnimationDuration
    {
        get => (uint)GetValue(EntranceAnimationDurationProperty);
        set => SetValue(EntranceAnimationDurationProperty, value);
    }

    public MauiIcon()
    {
        BuildIconControl();
        Loaded += async (s, r) =>
        {
            iconSpan.FontFamily = Icon.GetType().Name;
            await AnimateIcon();
        };
    }

    Span iconSpan;
    Span suffixSpan;
    private void BuildIconControl()
    {
        iconSpan = new Span();
        iconSpan.SetBinding(Span.TextProperty, new Binding(nameof(Icon), converter: new EnumToStringConverter(), source: this));
        iconSpan.SetBinding(Span.FontAutoScalingEnabledProperty, new Binding(nameof(IconAutoScaling), source: this));
        iconSpan.SetBinding(Span.FontSizeProperty, new Binding(nameof(IconSize), source: this));
        iconSpan.SetBinding(Span.TextColorProperty, new Binding(nameof(IconColor), source: this));
        iconSpan.SetBinding(Span.BackgroundColorProperty, new Binding(nameof(IconBackgroundColor), source: this));

        suffixSpan = new Span();
        suffixSpan.SetBinding(Span.TextProperty, new Binding(nameof(IconSuffix), source: this));
        suffixSpan.SetBinding(Span.FontAutoScalingEnabledProperty, new Binding(nameof(IconSuffixAutoScaling), source: this));
        suffixSpan.SetBinding(Span.FontSizeProperty, new Binding(nameof(IconSuffixFontSize), source: this));
        suffixSpan.SetBinding(Span.FontFamilyProperty, new Binding(nameof(IconSuffixFontFamily), source: this));
        suffixSpan.SetBinding(Span.TextColorProperty, new Binding(nameof(IconSuffixTextColor), source: this));

        FormattedText = new FormattedString();
        FormattedText.Spans.Add(iconSpan);
        FormattedText.Spans.Add(new Span { Text = " " });
        FormattedText.Spans.Add(suffixSpan);
    }

    async Task AnimateIcon()
    {
        switch (EntranceAnimationType)
        {
            case AnimationType.None:
                return;
            case AnimationType.Fade:
                Opacity = 0;
                await this.FadeTo(1, EntranceAnimationDuration);
                return;
            case AnimationType.Scale:
                await this.ScaleTo(1.5, EntranceAnimationDuration);
                await this.ScaleTo(1, EntranceAnimationDuration);
                return;
            case AnimationType.Rotate:
                await this.RotateTo(360, EntranceAnimationDuration);
                Rotation = 0;
                return;
        }
    }

    public static explicit operator Image(MauiIcon baseIcon) => new()
    {
        Source = new FontImageSource()
        {
            Glyph = baseIcon.Icon.GetDescription(),
            Color = baseIcon.IconColor.SetDefaultOrAssignedColor(),
            FontFamily = baseIcon.Icon.GetType().Name,
            Size = baseIcon.IconSize,
            FontAutoScalingEnabled = baseIcon.IconAutoScaling,
        },
        BackgroundColor = baseIcon.IconBackgroundColor,
    };

    public static explicit operator FontImageSource(MauiIcon mi) => new()
    {
        Glyph = mi.Icon.GetDescription(),
        Color = mi.IconColor.SetDefaultOrAssignedColor(),
        FontFamily = mi.Icon.GetType().Name,
        Size = mi.IconSize,
        FontAutoScalingEnabled = mi.IconAutoScaling,
    };

    public static explicit operator Button(MauiIcon mi) => new()
    {
        Text = mi.Icon.GetDescription(),
        TextColor = mi.IconColor.SetDefaultOrAssignedColor(),
        FontFamily = mi.Icon.GetType().Name,
        BackgroundColor = mi.IconBackgroundColor,
        FontSize = mi.IconSize,
        FontAutoScalingEnabled = mi.IconAutoScaling,
    };

}
