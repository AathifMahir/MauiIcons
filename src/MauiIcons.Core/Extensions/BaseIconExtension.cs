using MauiIcons.Core.Base;
using MauiIcons.Core.Converters;
using MauiIcons.Core.Helpers;

namespace MauiIcons.Core;

[ContentProperty(nameof(Icon))]
public abstract class BaseIconExtension<TEnum> : BaseIcon, IMarkupExtension<BindingBase> where TEnum : Enum
{
    public static new readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(TEnum?), typeof(BaseIconExtension<TEnum>), null);

    public new TEnum? Icon
    {
        get => (TEnum?)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public BindingBase ProvideValue(IServiceProvider serviceProvider)
    {
        var valueProvider = serviceProvider.GetService<IProvideValueTarget>() ?? throw new ArgumentException();
        Type? returnType = (valueProvider.TargetProperty as BindableProperty)?.ReturnType;

        if (PlatformHelper.IsValidPlatformsAndIdioms(OnPlatforms, OnIdioms) && valueProvider.TargetObject is not null)
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
            return SetImageSourceProperties(targetObject);

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
        if (!IsSet(BindableObject.BindingContextProperty))
            SetBinding(BindableObject.BindingContextProperty, new Binding(nameof(BindingContext), source: targetObject));

        switch (targetObject)
        {
            case Button button:
                button.SetValue(Button.FontFamilyProperty, Icon.GetFontFamily());
                button.SetBinding(Button.TextColorProperty, new Binding(nameof(IconColor), source: this,
                    converter: new DefaultColorConverter(), converterParameter: button.TextColor));
                button.SetBinding(Button.BackgroundColorProperty, new Binding(nameof(IconBackgroundColor), source: this,
                    converter: new DefaultColorConverter(), converterParameter: button.BackgroundColor));
                button.SetBinding(Button.FontSizeProperty, new Binding(nameof(IconSize), source: this));
                button.SetBinding(Button.FontAutoScalingEnabledProperty, new Binding(nameof(IconAutoScaling), source: this));
                break;
            case Label label:
                label.SetValue(Label.FontFamilyProperty, Icon.GetFontFamily());
                label.SetBinding(Label.TextColorProperty, new Binding(nameof(IconColor), source: this, 
                    converter: new DefaultColorConverter(), converterParameter: label.TextColor));
                label.SetBinding(Label.BackgroundColorProperty, new Binding(nameof(IconBackgroundColor), source: this, 
                    converter: new DefaultColorConverter(), converterParameter: label.BackgroundColor));
                label.SetBinding(Label.FontSizeProperty, new Binding(nameof(IconSize), source: this));
                label.SetBinding(Label.FontAutoScalingEnabledProperty, new Binding(nameof(IconAutoScaling), source: this));
                break;
            case Span span:
                span.SetValue(Span.FontFamilyProperty, Icon.GetFontFamily());
                span.SetBinding(Span.TextColorProperty, new Binding(nameof(IconColor), source: this, 
                    converter: new DefaultColorConverter(), converterParameter: span.TextColor));
                span.SetBinding(Span.BackgroundColorProperty, new Binding(nameof(IconBackgroundColor), source: this, 
                    converter: new DefaultColorConverter(), converterParameter: span.BackgroundColor));
                span.SetBinding(Span.FontSizeProperty, new Binding(nameof(IconSize), source: this));
                span.SetBinding(Span.FontAutoScalingEnabledProperty, new Binding(nameof(IconAutoScaling), source: this));
                break;
            case Entry entry:
                entry.SetValue(Entry.FontFamilyProperty, Icon.GetFontFamily());
                entry.SetBinding(Entry.TextColorProperty, new Binding(nameof(IconColor), source: this, 
                    converter: new DefaultColorConverter(), converterParameter: entry.TextColor));
                entry.SetBinding(Entry.BackgroundColorProperty, new Binding(nameof(IconBackgroundColor), source: this, 
                    converter: new DefaultColorConverter(), converterParameter: entry.BackgroundColor));
                entry.SetBinding(Entry.FontSizeProperty, new Binding(nameof(IconSize), source: this));
                entry.SetBinding(Entry.FontAutoScalingEnabledProperty, new Binding(nameof(IconAutoScaling), source: this));
                break;
            case Editor editor:
                editor.SetValue(Editor.FontFamilyProperty, Icon.GetFontFamily());
                editor.SetBinding(Editor.TextColorProperty, new Binding(nameof(IconColor), source: this, 
                    converter: new DefaultColorConverter(), converterParameter: editor.TextColor));
                editor.SetBinding(Editor.BackgroundColorProperty, new Binding(nameof(IconBackgroundColor), source: this, 
                    converter: new DefaultColorConverter(), converterParameter: editor.BackgroundColor));
                editor.SetBinding(Editor.FontSizeProperty, new Binding(nameof(IconSize), source: this));
                editor.SetBinding(Editor.FontAutoScalingEnabledProperty, new Binding(nameof(IconAutoScaling), source: this));
                break;
            case SearchBar searchBar:
                searchBar.SetValue(SearchBar.FontFamilyProperty, Icon.GetFontFamily());
                searchBar.SetBinding(SearchBar.TextColorProperty, new Binding(nameof(IconColor), source: this, 
                    converter: new DefaultColorConverter(), converterParameter: searchBar.TextColor));
                searchBar.SetBinding(SearchBar.BackgroundColorProperty, new Binding(nameof(IconBackgroundColor), source: this, 
                    converter: new DefaultColorConverter(), converterParameter: searchBar.BackgroundColor));
                searchBar.SetBinding(SearchBar.FontSizeProperty, new Binding(nameof(IconSize), source: this));
                searchBar.SetBinding(SearchBar.FontAutoScalingEnabledProperty, new Binding(nameof(IconAutoScaling), source: this));
                break;
            case MauiIcon mauiIcon:
                mauiIcon.SetBinding(MauiIcon.IconColorProperty, new Binding(nameof(IconColor), source: this, 
                    converter: new DefaultColorConverter(), converterParameter: mauiIcon.IconColor));
                mauiIcon.SetBinding(MauiIcon.IconBackgroundColorProperty, new Binding(nameof(IconBackgroundColor), source: this, 
                    converter: new DefaultColorConverter(), converterParameter: mauiIcon.IconBackgroundColor));
                mauiIcon.SetBinding(MauiIcon.IconSizeProperty, new Binding(nameof(IconSize), source: this));
                mauiIcon.SetBinding(MauiIcon.IconAutoScalingProperty, new Binding(nameof(IconAutoScaling), source: this));
                mauiIcon.SetBinding(MauiIcon.OnPlatformsProperty, new Binding(nameof(OnPlatforms), source: this));
                mauiIcon.SetBinding(MauiIcon.OnIdiomsProperty, new Binding(nameof(OnIdioms), source: this));
                break;
            case FontImageSource fontImageSource:
                fontImageSource.SetValue(FontImageSource.FontFamilyProperty, Icon.GetFontFamily());
                fontImageSource.SetBinding(FontImageSource.SizeProperty, new Binding(nameof(IconSize), source: this));
                fontImageSource.SetBinding(FontImageSource.ColorProperty, new Binding(nameof(IconColor), source: this, 
                    converter: new DefaultColorConverter(), converterParameter: fontImageSource.Color));
                fontImageSource.SetBinding(FontImageSource.FontAutoScalingEnabledProperty, new Binding(nameof(IconAutoScaling), source: this));
                break;
            default:
                throw new MauiIconsExpection($"MauiIcons extension doesn't support this control {targetObject}");
        }
        return new Binding(nameof(Icon), converter: !disableConverter ? new IconToGlyphConverter() : null, source: this);
    }

    Binding SetImageSourceProperties(object targetObject)
    {
        if (!IsSet(BindableObject.BindingContextProperty))
            SetBinding(BindableObject.BindingContextProperty, new Binding(nameof(BindingContext), source: targetObject));

        InternalSource = new FontImageSource();
        ((FontImageSource)InternalSource).SetBinding(FontImageSource.GlyphProperty, new Binding(nameof(Icon),
            converter: new IconToGlyphConverter(), source: this));
        ((FontImageSource)InternalSource).SetValue(FontImageSource.FontFamilyProperty, Icon.GetFontFamily());
        ((FontImageSource)InternalSource).SetBinding(FontImageSource.SizeProperty, new Binding(nameof(IconSize), source: this));
        ((FontImageSource)InternalSource).SetBinding(FontImageSource.ColorProperty, new Binding(nameof(IconColor), source: this,
                           converter: new DefaultColorConverter(), converterParameter: ((FontImageSource)InternalSource).Color));
        ((FontImageSource)InternalSource).SetBinding(FontImageSource.FontAutoScalingEnabledProperty, new Binding(nameof(IconAutoScaling), source: this));
        return new Binding(nameof(InternalSource),  source: this);
    }

    Binding SetBaseIconProperties()
    {
        base.SetValue(BaseIcon.IconProperty, Icon);
        return new Binding(".",  source: this);
    }

    public static readonly BindableProperty InternalSourceProperty = BindableProperty.Create(nameof(InternalSource), typeof(ImageSource), typeof(BaseIconExtension<TEnum>), null);

    /// <summary>
    /// This is Used Internally, Don't Use it in XAML or CodeBehind
    /// </summary>
    public ImageSource InternalSource
    {
        get => (ImageSource)GetValue(InternalSourceProperty);
        set => SetValue(InternalSourceProperty, value);
    }
}
