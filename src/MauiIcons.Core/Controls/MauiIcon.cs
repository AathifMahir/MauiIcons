using MauiIcons.Core.Converters;
using MauiIcons.Core.Helpers;
using Microsoft.Maui.Graphics.Converters;

namespace MauiIcons.Core;

public sealed partial class MauiIcon : ContentView, IMauiIcon
{
    public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(Enum), typeof(MauiIcon), null);
    public static readonly BindableProperty IconSizeProperty = BindableProperty.Create(nameof(IconSize), typeof(double), typeof(MauiIcon), 30.0);
    public static readonly BindableProperty IconColorProperty = BindableProperty.Create(nameof(IconColor), typeof(Color), typeof(MauiIcon), null);
    public static readonly BindableProperty IconBackgroundColorProperty = BindableProperty.Create(nameof(IconBackgroundColor), typeof(Color), typeof(MauiIcon), null);
    public static readonly BindableProperty IconAutoScalingProperty = BindableProperty.Create(nameof(IconAutoScaling), typeof(bool), typeof(MauiIcon), false);
    
    public static readonly BindableProperty IconSuffixProperty = BindableProperty.Create(nameof(IconSuffix), typeof(string), typeof(MauiIcon), null, 
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((MauiIcon)bindable)._iconSuffixSpacer.Text = !string.IsNullOrEmpty((string)newValue) ? "  " : null;
        });

    public static readonly BindableProperty IconSuffixFontFamilyProperty = BindableProperty.Create(nameof(IconSuffixFontFamily), typeof(string), typeof(MauiIcon), null);
    public static readonly BindableProperty IconSuffixFontSizeProperty = BindableProperty.Create(nameof(IconSuffixFontSize), typeof(double), typeof(MauiIcon), 20.0);
    public static readonly BindableProperty IconSuffixTextColorProperty = BindableProperty.Create(nameof(IconSuffixTextColor), typeof(Color), typeof(MauiIcon), null);
    public static readonly BindableProperty IconSuffixBackgroundColorProperty = BindableProperty.Create(nameof(IconSuffixBackgroundColor), typeof(Color), typeof(MauiIcon), null);
    public static readonly BindableProperty IconSuffixAutoScalingProperty = BindableProperty.Create(nameof(IconSuffixAutoScaling), typeof(bool), typeof(MauiIcon), false);
    public static readonly BindableProperty IconAndSuffixBackgroundColorProperty = BackgroundColorProperty;
    public static readonly BindableProperty EntranceAnimationTypeProperty = BindableProperty.Create(nameof(EntranceAnimationType), typeof(AnimationType), typeof(MauiIcon), AnimationType.None);
    public static readonly BindableProperty EntranceAnimationDurationProperty = BindableProperty.Create(nameof(EntranceAnimationDuration), typeof(uint), typeof(MauiIcon), (uint)1500);

    public static readonly BindableProperty OnPlatformsProperty = BindableProperty.Create(nameof(OnPlatforms), typeof(IList<string>), typeof(MauiIcon), null, 
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            if (newValue is not null && newValue is IList<string> platforms && bindable is MauiIcon icon)
                icon.Content = PlatformHelper.IsValidPlatformsAndIdioms(platforms, icon.OnIdioms) ? 
                icon.Content ?? icon._root ?? icon.BuildIconControl() : null;

        });

    public static readonly BindableProperty OnIdiomsProperty = BindableProperty.Create(nameof(OnIdioms), typeof(IList<string>), typeof(MauiIcon), null, 
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            if (newValue is not null && newValue is IList<string> idioms && bindable is MauiIcon icon)
                icon.Content = PlatformHelper.IsValidPlatformsAndIdioms(icon.OnPlatforms, idioms) ? 
                icon.Content ?? icon._root ?? icon.BuildIconControl() : null;
        });

    public static readonly BindableProperty OnClickAnimationTypeProperty = BindableProperty.Create(nameof(OnClickAnimationType), typeof(AnimationType), typeof(MauiIcon), AnimationType.None,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            if(newValue is AnimationType type && type is not AnimationType.None && bindable is MauiIcon icon)
            {
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += icon.OnIconTapped;
                icon._iconLabel.GestureRecognizers.Add(tapGestureRecognizer);
            }
            else if (bindable is MauiIcon mi)
            {
                mi.DisposeGestureRecognizer();
            }
        });

    public static readonly BindableProperty OnClickAnimationDurationProperty = BindableProperty.Create(nameof(OnClickAnimationDuration), typeof(uint), typeof(MauiIcon), (uint)600);

    public Enum? Icon
    {
        get => (Enum?)GetValue(IconProperty);
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

    [System.ComponentModel.TypeConverter(typeof(ColorTypeConverter))]
    public Color IconSuffixBackgroundColor
    {
        get => (Color)GetValue(IconSuffixBackgroundColorProperty);
        set => SetValue(IconSuffixBackgroundColorProperty, value);
    }

    public bool IconSuffixAutoScaling
    {
        get => (bool)GetValue(IconSuffixAutoScalingProperty);
        set => SetValue(IconSuffixAutoScalingProperty, value);
    }

    [System.ComponentModel.TypeConverter(typeof(ColorTypeConverter))]
    public Color IconAndSuffixBackgroundColor
    {
        get => (Color)GetValue(IconAndSuffixBackgroundColorProperty);
        set => SetValue(IconAndSuffixBackgroundColorProperty, value);
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

    [System.ComponentModel.TypeConverter(typeof(ListStringTypeConverter))]
    public IList<string> OnPlatforms
    {
        get => (IList<string>)GetValue(OnPlatformsProperty);
        set => SetValue(OnPlatformsProperty, value);
    }

    [System.ComponentModel.TypeConverter(typeof(ListStringTypeConverter))]
    public IList<string> OnIdioms
    {
        get => (IList<string>)GetValue(OnIdiomsProperty);
        set => SetValue(OnIdiomsProperty, value);
    }
    public AnimationType OnClickAnimationType
    {
        get => (AnimationType)GetValue(OnClickAnimationTypeProperty);
        set => SetValue(OnClickAnimationTypeProperty, value);
    }
    public uint OnClickAnimationDuration
    {
        get => (uint)GetValue(OnClickAnimationDurationProperty);
        set => SetValue(OnClickAnimationDurationProperty, value);
    }

    public MauiIcon()
    {
        Content = BuildIconControl();
        Loaded += async (s, r) =>
        {
            _iconLabel.SetValue(Label.FontFamilyProperty, Icon.GetFontFamily());
            await AnimationHelper.AnimateIconAsync(EntranceAnimationType, _iconLabel, EntranceAnimationDuration);
        };
    }

    private readonly HorizontalStackLayout _root = new();
    private readonly Label _iconLabel = new();
    private readonly Label _suffixLabel = new();
    private readonly Span _iconSuffixSpacer = new();
    private readonly Span _suffixSpan = new();

    private HorizontalStackLayout BuildIconControl()
    {
        _iconLabel.SetBinding(Label.TextProperty, new Binding(nameof(Icon), converter: new IconToGlyphConverter(), source: this));
        _iconLabel.SetBinding(Label.FontAutoScalingEnabledProperty, new Binding(nameof(IconAutoScaling), source: this));
        _iconLabel.SetBinding(Label.FontSizeProperty, new Binding(nameof(IconSize), source: this));
        _iconLabel.SetBinding(Label.TextColorProperty, new Binding(nameof(IconColor), source: this));
        _iconLabel.SetBinding(Label.BackgroundColorProperty, new Binding(nameof(IconBackgroundColor), source: this));
        _iconLabel.SetValue(Label.VerticalOptionsProperty, LayoutOptions.Center);

        _suffixSpan.SetBinding(Span.TextProperty, new Binding(nameof(IconSuffix), source: this));
        _suffixSpan.SetBinding(Span.FontAutoScalingEnabledProperty, new Binding(nameof(IconSuffixAutoScaling), source: this));
        _suffixSpan.SetBinding(Span.FontSizeProperty, new Binding(nameof(IconSuffixFontSize), source: this));
        _suffixSpan.SetBinding(Span.FontFamilyProperty, new Binding(nameof(IconSuffixFontFamily), source: this));
        _suffixSpan.SetBinding(Span.TextColorProperty, new Binding(nameof(IconSuffixTextColor), source: this));
        _suffixSpan.SetBinding(Span.BackgroundColorProperty, new Binding(nameof(IconSuffixBackgroundColor), source: this));

        _suffixLabel.SetValue(Label.FormattedTextProperty, new FormattedString());
        _suffixLabel.SetValue(Label.VerticalOptionsProperty, LayoutOptions.Center);
        _suffixLabel.FormattedText.Spans.Add(_iconSuffixSpacer);
        _suffixLabel.FormattedText.Spans.Add(_suffixSpan);

        _root.Children.Add(_iconLabel);
        _root.Children.Add(_suffixLabel);
        return _root;
    }

    private async void OnIconTapped(object? sender, TappedEventArgs e)
    {
        await AnimationHelper.AnimateIconAsync(OnClickAnimationType, _iconLabel, OnClickAnimationDuration);
    }

    public void DisposeGestureRecognizer()
    {
        if (_iconLabel.GestureRecognizers.Count > 0 && _iconLabel.GestureRecognizers[0] is TapGestureRecognizer tapGestureRecognizer)
        {
            tapGestureRecognizer.Tapped -= OnIconTapped;
            _iconLabel.GestureRecognizers.Clear();
        }
    }

    public static explicit operator Image(MauiIcon baseIcon) => new()
    {
        Source = new FontImageSource()
        {
            Glyph = baseIcon.Icon.GetDescription(),
            Color = baseIcon.IconColor.SetDefaultOrAssignedColor(),
            FontFamily = baseIcon.Icon.GetFontFamily(),
            Size = baseIcon.IconSize,
            FontAutoScalingEnabled = baseIcon.IconAutoScaling,
        },
        BackgroundColor = baseIcon.IconBackgroundColor,
    };

    public static explicit operator FontImageSource(MauiIcon mi) => new()
    {
        Glyph = mi.Icon.GetDescription(),
        Color = mi.IconColor.SetDefaultOrAssignedColor(),
        FontFamily = mi.Icon.GetFontFamily(),
        Size = mi.IconSize,
        FontAutoScalingEnabled = mi.IconAutoScaling,
    };

    public static explicit operator Label(MauiIcon mi)
    {
        var label = new Label
        {
            FormattedText = new FormattedString()
        };
        label.FormattedText.Spans.Add(new Span
        {
            Text = mi._iconLabel.Text,
            FontSize = mi._iconLabel.FontSize,
            FontAutoScalingEnabled = mi._iconLabel.FontAutoScalingEnabled,
            FontFamily = mi.Icon.GetFontFamily(),
            TextColor = mi._iconLabel.TextColor,
            BackgroundColor = mi._iconLabel.BackgroundColor
        });
        label.FormattedText.Spans.Add(mi._iconSuffixSpacer);
        label.FormattedText.Spans.Add(mi._suffixSpan);
        label.VerticalOptions = LayoutOptions.Center;
        label.BackgroundColor = mi.IconAndSuffixBackgroundColor.SetDefaultOrAssignedColor(label.BackgroundColor);
        label.Loaded += async (s, r) =>
        {
            await AnimationHelper.AnimateIconAsync(mi.EntranceAnimationType, label, mi.EntranceAnimationDuration);
        };
        return label;
    }

    public static explicit operator Button(MauiIcon mi)
    {
        var button = new Button
        {
            Text = mi.Icon.GetDescription(),
            FontFamily = mi.Icon.GetFontFamily(),
            FontSize = mi.IconSize,
            FontAutoScalingEnabled = mi.IconAutoScaling
        };
        button.TextColor = mi.IconColor.SetDefaultOrAssignedColor(button.TextColor);
        button.BackgroundColor = mi.IconBackgroundColor.SetDefaultOrAssignedColor(button.BackgroundColor);
        return button;
    }

}
