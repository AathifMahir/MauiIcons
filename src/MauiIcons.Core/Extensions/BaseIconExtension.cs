using MauiIcons.Core.Converters;
using MauiIcons.Core.Helpers;
using Microsoft.Maui.Graphics.Converters;

namespace MauiIcons.Core;

[ContentProperty(nameof(Icon))]
public abstract class BaseIconExtension<TEnum> : BindableObject, IMarkupExtension<BindingBase> where TEnum : Enum
{
    public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(TEnum?), typeof(BaseIconExtension<TEnum>), null);
    public static readonly BindableProperty IconSizeProperty = BindableProperty.Create(nameof(IconSize), typeof(double), typeof(BaseIconExtension<TEnum>), 30.0);
    public static readonly BindableProperty IconColorProperty = BindableProperty.Create(nameof(IconColor), typeof(Color), typeof(BaseIconExtension<TEnum>), null);
    public static readonly BindableProperty IconBackgroundColorProperty = BindableProperty.Create(nameof(IconBackgroundColor), typeof(Color), typeof(BaseIconExtension<TEnum>), null);
    public static readonly BindableProperty IconAutoScalingProperty = BindableProperty.Create(nameof(IconAutoScaling), typeof(bool), typeof(BaseIconExtension<TEnum>), false);

    public TEnum? Icon
    {
        get => (TEnum?)GetValue(IconProperty);
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

    [System.ComponentModel.TypeConverter(typeof(ListStringTypeConverter))]
    public IList<string> OnPlatforms { get; set; } = [];

    [System.ComponentModel.TypeConverter(typeof(ListStringTypeConverter))]
    public IList<string> OnIdioms { get; set; } = [];

    public BindingBase ProvideValue(IServiceProvider serviceProvider)
    {
        var valueProvider = serviceProvider.GetService<IProvideValueTarget>() ?? throw new ArgumentException();
        Type? returnType = (valueProvider.TargetProperty as BindableProperty)?.ReturnType;

        if (PlatformHelper.IsValidPlatformsAndIdioms(OnPlatforms, OnIdioms))
            return SetMauiIconBasedOnType(valueProvider.TargetObject, returnType);

        return new Binding();
    }

    object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) =>
        (this as IMarkupExtension<BindingBase>).ProvideValue(serviceProvider);

    Binding SetMauiIconBasedOnType(object targetObject, Type? returnType)
    {
        if (returnType == typeof(Enum))
            return SetFontProperties(targetObject, disableConverter: true);

        if (returnType == typeof(string))
            return SetFontProperties(targetObject);

        if (returnType == typeof(ImageSource) || returnType == typeof(FontImageSource))
            return SetImageSourceProperties();

        if(returnType == typeof(BaseIcon))
            return SetBaseIconProperties();

        if (returnType is null && targetObject is Setter setter)
            return setter.Property.DeclaringType != typeof(MauiIcon)
                    ? throw new MauiIconsExpection("MauiIcons doesn't support Style Setter to be used in conjunction with Xaml Extension.")
                    : SetBaseIconProperties();

        if (returnType is null && (targetObject is On or OnPlatform<ImageSource>
            or OnPlatform<FontImageSource> or OnPlatformExtension
            or OnIdiom<ImageSource> or OnIdiom<FontImageSource>
            or OnIdiomExtension))
            throw new MauiIconsExpection("MauiIcons doesn't support Maui OnPlatform or OnIdiom," +
                "Therefore it is recommended to utilize MauiIcon's integrated Custom OnPlatform or OnIdiom functionalities.");

        throw new MauiIconsExpection($"MauiIcons Extension does not provide {returnType} support");
    }

    Binding SetFontProperties(object targetObject, bool disableConverter = false)
    {
        switch (targetObject)
        {
            case Button button:
                button.FontFamily = Icon.GetFontFamily();
                button.SetBinding(Button.TextColorProperty, new Binding(nameof(IconColor), source: this, mode: BindingMode.OneWay,
                    converter: new DefaultColorConverter(), converterParameter: button.TextColor));
                button.SetBinding(Button.BackgroundColorProperty, new Binding(nameof(IconBackgroundColor), source: this, mode: BindingMode.OneWay,
                    converter: new DefaultColorConverter(), converterParameter: button.BackgroundColor));
                button.SetBinding(Button.FontSizeProperty, new Binding(nameof(IconSize), source: this, mode: BindingMode.OneWay));
                button.SetBinding(Button.FontAutoScalingEnabledProperty, new Binding(nameof(IconAutoScaling), source: this, mode: BindingMode.OneWay));
                break;
            case Label label:
                label.FontFamily = Icon.GetFontFamily();
                label.SetBinding(Label.TextColorProperty, new Binding(nameof(IconColor), source: this, mode: BindingMode.OneWay,
                    converter: new DefaultColorConverter(), converterParameter: label.TextColor));
                label.SetBinding(Label.BackgroundColorProperty, new Binding(nameof(IconBackgroundColor), source: this, mode: BindingMode.OneWay,
                    converter: new DefaultColorConverter(), converterParameter: label.BackgroundColor));
                label.SetBinding(Label.FontSizeProperty, new Binding(nameof(IconSize), source: this, mode: BindingMode.OneWay));
                label.SetBinding(Label.FontAutoScalingEnabledProperty, new Binding(nameof(IconAutoScaling), source: this, mode: BindingMode.OneWay));
                break;
            case Span span:
                span.FontFamily = Icon.GetFontFamily();
                span.SetBinding(Span.TextColorProperty, new Binding(nameof(IconColor), source: this, mode: BindingMode.OneWay,
                    converter: new DefaultColorConverter(), converterParameter: span.TextColor));
                span.SetBinding(Span.BackgroundColorProperty, new Binding(nameof(IconBackgroundColor), source: this, mode: BindingMode.OneWay,
                    converter: new DefaultColorConverter(), converterParameter: span.BackgroundColor));
                span.SetBinding(Span.FontSizeProperty, new Binding(nameof(IconSize), source: this, mode: BindingMode.OneWay));
                span.SetBinding(Span.FontAutoScalingEnabledProperty, new Binding(nameof(IconAutoScaling), source: this, mode: BindingMode.OneWay));
                break;
            case Entry entry:
                entry.FontFamily = Icon.GetFontFamily();
                entry.SetBinding(Entry.TextColorProperty, new Binding(nameof(IconColor), source: this, mode: BindingMode.OneWay,
                    converter: new DefaultColorConverter(), converterParameter: entry.TextColor));
                entry.SetBinding(Entry.BackgroundColorProperty, new Binding(nameof(IconBackgroundColor), source: this, mode: BindingMode.OneWay,
                    converter: new DefaultColorConverter(), converterParameter: entry.BackgroundColor));
                entry.SetBinding(Entry.FontSizeProperty, new Binding(nameof(IconSize), source: this, mode: BindingMode.OneWay));
                entry.SetBinding(Entry.FontAutoScalingEnabledProperty, new Binding(nameof(IconAutoScaling), source: this, mode: BindingMode.OneWay));
                break;
            case Editor editor:
                editor.FontFamily = Icon.GetFontFamily();
                editor.SetBinding(Editor.TextColorProperty, new Binding(nameof(IconColor), source: this, mode: BindingMode.OneWay,
                    converter: new DefaultColorConverter(), converterParameter: editor.TextColor));
                editor.SetBinding(Editor.BackgroundColorProperty, new Binding(nameof(IconBackgroundColor), source: this, mode: BindingMode.OneWay,
                    converter: new DefaultColorConverter(), converterParameter: editor.BackgroundColor));
                editor.SetBinding(Editor.FontSizeProperty, new Binding(nameof(IconSize), source: this, mode: BindingMode.OneWay));
                editor.SetBinding(Editor.FontAutoScalingEnabledProperty, new Binding(nameof(IconAutoScaling), source: this, mode: BindingMode.OneWay));
                break;
            case SearchBar searchBar:
                searchBar.FontFamily = Icon.GetFontFamily();
                searchBar.SetBinding(SearchBar.TextColorProperty, new Binding(nameof(IconColor), source: this, mode: BindingMode.OneWay,
                    converter: new DefaultColorConverter(), converterParameter: searchBar.TextColor));
                searchBar.SetBinding(SearchBar.BackgroundColorProperty, new Binding(nameof(IconBackgroundColor), source: this, mode: BindingMode.OneWay,
                    converter: new DefaultColorConverter(), converterParameter: searchBar.BackgroundColor));
                searchBar.SetBinding(SearchBar.FontSizeProperty, new Binding(nameof(IconSize), source: this, mode: BindingMode.OneWay));
                searchBar.SetBinding(SearchBar.FontAutoScalingEnabledProperty, new Binding(nameof(IconAutoScaling), source: this, mode: BindingMode.OneWay));
                break;
            case MauiIcon mauiIcon:
                mauiIcon.SetBinding(MauiIcon.IconColorProperty, new Binding(nameof(IconColor), source: this, mode: BindingMode.OneWay,
                    converter: new DefaultColorConverter(), converterParameter: mauiIcon.IconColor));
                mauiIcon.SetBinding(MauiIcon.IconBackgroundColorProperty, new Binding(nameof(IconBackgroundColor), source: this, mode: BindingMode.OneWay,
                    converter: new DefaultColorConverter(), converterParameter: mauiIcon.IconBackgroundColor));
                mauiIcon.SetBinding(MauiIcon.IconSizeProperty, new Binding(nameof(IconSize), source: this, mode: BindingMode.OneWay));
                mauiIcon.SetBinding(MauiIcon.IconAutoScalingProperty, new Binding(nameof(IconAutoScaling), source: this, mode: BindingMode.OneWay));
                break;
            case FontImageSource fontImageSource:
                fontImageSource.FontFamily = Icon.GetFontFamily();
                fontImageSource.SetBinding(FontImageSource.SizeProperty, new Binding(nameof(IconSize), source: this, mode: BindingMode.OneWay));
                fontImageSource.SetBinding(FontImageSource.ColorProperty, new Binding(nameof(IconColor), source: this, mode: BindingMode.OneWay,
                    converter: new DefaultColorConverter(), converterParameter: fontImageSource.Color));
                fontImageSource.SetBinding(FontImageSource.FontAutoScalingEnabledProperty, new Binding(nameof(IconAutoScaling), source: this, mode: BindingMode.OneWay));
                break;
            default:
                throw new MauiIconsExpection($"MauiIcons extension doesn't support this control {targetObject}");
        }
        return new Binding(nameof(Icon), mode: BindingMode.OneWay, converter: !disableConverter ? new IconToGlyphConverter() : null, source: this);
    }

    Binding SetImageSourceProperties()
    {
        InternalSource = new FontImageSource();
        ((FontImageSource)InternalSource).SetBinding(FontImageSource.GlyphProperty, new Binding(nameof(Icon), mode: BindingMode.OneWay, converter: new IconToGlyphConverter(), source: this));
        ((FontImageSource)InternalSource).FontFamily = Icon.GetFontFamily();
        ((FontImageSource)InternalSource).SetBinding(FontImageSource.SizeProperty, new Binding(nameof(IconSize), source: this));
        ((FontImageSource)InternalSource).SetBinding(FontImageSource.ColorProperty, new Binding(nameof(IconColor), source: this,
                           converter: new DefaultColorConverter(), converterParameter: ((FontImageSource)InternalSource).Color));
        ((FontImageSource)InternalSource).SetBinding(FontImageSource.FontAutoScalingEnabledProperty, new Binding(nameof(IconAutoScaling), source: this));
        return new Binding(nameof(InternalSource), mode: BindingMode.OneWay, source: this);
    }

    Binding SetBaseIconProperties()
    {
        InternalBaseSource = new BaseIcon();
        InternalBaseSource.SetBinding(BaseIcon.IconProperty, new Binding(nameof(Icon), mode: BindingMode.OneWay, source: this));
        InternalBaseSource.SetBinding(BaseIcon.IconSizeProperty, new Binding(nameof(IconSize), source: this));
        InternalBaseSource.SetBinding(BaseIcon.IconColorProperty, new Binding(nameof(IconColor), source: this));
        InternalBaseSource.SetBinding(BaseIcon.IconBackgroundColorProperty, new Binding(nameof(IconBackgroundColor), source: this));
        InternalBaseSource.SetBinding(BaseIcon.IconAutoScalingProperty, new Binding(nameof(IconAutoScaling), source: this));
        return new Binding(nameof(InternalBaseSource), mode: BindingMode.OneWay, source: this);
    }

    public static readonly BindableProperty InternalSourceProperty = BindableProperty.Create(nameof(InternalSource), typeof(ImageSource), typeof(BaseIconExtension<TEnum>), null);
    public static readonly BindableProperty InternalBaseSourceProperty = BindableProperty.Create(nameof(InternalBaseSource), typeof(BaseIcon), typeof(BaseIconExtension<TEnum>), null);

    /// <summary>
    /// This is Used Internally, Don't Use it in XAML or CodeBehind
    /// </summary>
    public ImageSource InternalSource
    {
        get => (ImageSource)GetValue(InternalSourceProperty);
        set => SetValue(InternalSourceProperty, value);
    }

    /// <summary>
    /// This is Used Internally, Don't Use it in XAML or CodeBehind
    /// </summary>
    public BaseIcon InternalBaseSource
    {
        get => (BaseIcon)GetValue(InternalBaseSourceProperty);
        set => SetValue(InternalBaseSourceProperty, value);
    }

    

}
