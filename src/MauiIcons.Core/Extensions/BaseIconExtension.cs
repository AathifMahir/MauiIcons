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
                    converter: new DefaultFontColorConverter(), converterParameter: button.TextColor));
                button.SetBinding(Button.BackgroundColorProperty, new Binding(nameof(IconBackgroundColor), source: this,
                    converter: new DefaultFontColorConverter(), converterParameter: button.BackgroundColor));
                button.SetBinding(Button.FontSizeProperty, new Binding(nameof(IconSize), source: this,
                    converter: new DefaultFontSizeConverter(), converterParameter: button.FontSize));
                button.SetBinding(Button.FontAutoScalingEnabledProperty, new Binding(nameof(IconAutoScaling), source: this,
                    converter: new DefaultFontAutoScalingConverter(), converterParameter: button.FontAutoScalingEnabled));
                break;
            case Label label:
                label.SetValue(Label.FontFamilyProperty, Icon.GetFontFamily());
                label.SetBinding(Label.TextColorProperty, new Binding(nameof(IconColor), source: this, 
                    converter: new DefaultFontColorConverter(), converterParameter: label.TextColor));
                label.SetBinding(Label.BackgroundColorProperty, new Binding(nameof(IconBackgroundColor), source: this, 
                    converter: new DefaultFontColorConverter(), converterParameter: label.BackgroundColor));
                label.SetBinding(Label.FontSizeProperty, new Binding(nameof(IconSize), source: this,
                    converter: new DefaultFontSizeConverter(), converterParameter: label.FontSize));
                label.SetBinding(Label.FontAutoScalingEnabledProperty, new Binding(nameof(IconAutoScaling), source: this,
                    converter: new DefaultFontAutoScalingConverter(), converterParameter: label.FontAutoScalingEnabled));
                break;
            case Span span:
                span.SetValue(Span.FontFamilyProperty, Icon.GetFontFamily());
                span.SetBinding(Span.TextColorProperty, new Binding(nameof(IconColor), source: this, 
                    converter: new DefaultFontColorConverter(), converterParameter: span.TextColor));
                span.SetBinding(Span.BackgroundColorProperty, new Binding(nameof(IconBackgroundColor), source: this, 
                    converter: new DefaultFontColorConverter(), converterParameter: span.BackgroundColor));
                span.SetBinding(Span.FontSizeProperty, new Binding(nameof(IconSize), source: this,
                    converter: new DefaultFontSizeConverter(), converterParameter: span.FontSize));
                span.SetBinding(Span.FontAutoScalingEnabledProperty, new Binding(nameof(IconAutoScaling), source: this,
                    converter: new DefaultFontAutoScalingConverter(), converterParameter: span.FontAutoScalingEnabled));
                break;
            case InputView input:
                if(!FontOverride && !Options.SuppressExceptionsInFontOverride)
                    throw new MauiIconsExpection("This input control does not natively support icons or image sources. To apply an icon, " +
                        "set OverrideFont to true. This will replace any custom fonts with the default fonts. Please be aware that explicitly setting the FontFamily on the control itself will not render the icon. " +
                        "Additionally, using OverrideFont may cause unexpected behavior, such as issues with text rendering.");

                input.SetValue(InputView.FontFamilyProperty, Icon.GetFontFamily());
                input.SetBinding(InputView.TextColorProperty, new Binding(nameof(IconColor), source: this, 
                    converter: new DefaultFontColorConverter(), converterParameter: input.TextColor));
                input.SetBinding(InputView.BackgroundColorProperty, new Binding(nameof(IconBackgroundColor), source: this, 
                    converter: new DefaultFontColorConverter(), converterParameter: input.BackgroundColor));
                input.SetBinding(InputView.FontSizeProperty, new Binding(nameof(IconSize), source: this,
                    converter: new DefaultFontSizeConverter(), converterParameter: input.FontSize));
                input.SetBinding(InputView.FontAutoScalingEnabledProperty, new Binding(nameof(IconAutoScaling), source: this,
                    converter: new DefaultFontAutoScalingConverter(), converterParameter: input.FontAutoScalingEnabled));
                break;
            case MauiIcon mauiIcon:
                mauiIcon.SetBinding(MauiIcon.IconColorProperty, new Binding(nameof(IconColor), source: this, 
                    converter: new DefaultFontColorConverter(), converterParameter: mauiIcon.IconColor));
                mauiIcon.SetBinding(MauiIcon.IconBackgroundColorProperty, new Binding(nameof(IconBackgroundColor), source: this, 
                    converter: new DefaultFontColorConverter(), converterParameter: mauiIcon.IconBackgroundColor));
                mauiIcon.SetBinding(MauiIcon.IconSizeProperty, new Binding(nameof(IconSize), source: this,
                    converter: new DefaultFontSizeConverter(), converterParameter: mauiIcon.IconSize));
                mauiIcon.SetBinding(MauiIcon.IconAutoScalingProperty, new Binding(nameof(IconAutoScaling), source: this,
                    converter: new DefaultFontAutoScalingConverter(), converterParameter: mauiIcon.IconAutoScaling));
                mauiIcon.SetBinding(MauiIcon.OnPlatformsProperty, new Binding(nameof(OnPlatforms), source: this));
                mauiIcon.SetBinding(MauiIcon.OnIdiomsProperty, new Binding(nameof(OnIdioms), source: this));
                break;
            case FontImageSource fontImageSource:
                fontImageSource.SetValue(FontImageSource.FontFamilyProperty, Icon.GetFontFamily());
                fontImageSource.SetBinding(FontImageSource.SizeProperty, new Binding(nameof(IconSize), source: this,
                    converter: new DefaultFontSizeConverter(), converterParameter: fontImageSource.Size));
                fontImageSource.SetBinding(FontImageSource.ColorProperty, new Binding(nameof(IconColor), source: this, 
                    converter: new DefaultFontColorConverter(), converterParameter: fontImageSource.Color));
                fontImageSource.SetBinding(FontImageSource.FontAutoScalingEnabledProperty, new Binding(nameof(IconAutoScaling), source: this,
                    converter: new DefaultFontAutoScalingConverter(), converterParameter: fontImageSource.FontAutoScalingEnabled));
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
        IText? element = targetObject as IText;
        InternalSource = new FontImageSource();
        ((FontImageSource)InternalSource).SetBinding(FontImageSource.GlyphProperty, new Binding(nameof(Icon),
            converter: new IconToGlyphConverter(), source: this));
        ((FontImageSource)InternalSource).SetValue(FontImageSource.FontFamilyProperty, Icon.GetFontFamily());
        ((FontImageSource)InternalSource).SetBinding(FontImageSource.SizeProperty, new Binding(nameof(IconSize), source: this,
            converter: new DefaultFontSizeConverter(), converterParameter: ((FontImageSource)InternalSource).Size));
        ((FontImageSource)InternalSource).SetBinding(FontImageSource.ColorProperty, new Binding(nameof(IconColor), source: this,
                           converter: new DefaultFontColorConverter(), converterParameter: element is not null ? element.TextColor : ((FontImageSource)InternalSource).Color));
        ((FontImageSource)InternalSource).SetBinding(FontImageSource.FontAutoScalingEnabledProperty, new Binding(nameof(IconAutoScaling), source: this,
            converter: new DefaultFontAutoScalingConverter(), converterParameter: ((FontImageSource)InternalSource).FontAutoScalingEnabled));
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
