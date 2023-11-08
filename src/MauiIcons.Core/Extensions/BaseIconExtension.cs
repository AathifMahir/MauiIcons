using MauiIcons.Core.Helpers;

namespace MauiIcons.Core;

[ContentProperty(nameof(Icon))]
public abstract class BaseIconExtension<TEnum> : IMarkupExtension<object> where TEnum : Enum
{
#nullable enable
    public TEnum? Icon { get; set; }
#nullable disable
    public Color IconColor { get; set; }
    public Color IconBackgroundColor { get; set; }

    [System.ComponentModel.TypeConverter(typeof(FontSizeConverter))]
    public double IconSize { get; set; } = DefaultIconSize;
    public bool IconAutoScaling { get; set; } = false;
    public PlatformType OnPlatform { get; set; } = PlatformType.All;
    public IdiomType OnIdiom { get; set; } = IdiomType.All;

    const double DefaultIconSize = 30.0;
    public object ProvideValue(IServiceProvider serviceProvider)
    {
        IProvideValueTarget provideValueTarget = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
        Type returnType = (provideValueTarget.TargetProperty as BindableProperty)?.ReturnType;

        if (PlatformHelper.IsValidPlatformAndIdiom(OnPlatform, OnIdiom))
            return AssignIconsBasedOnType(provideValueTarget.TargetObject, returnType);

        return null;
    }

    object AssignIconsBasedOnType(object targetObject, Type returnType)
    {
        if (returnType == typeof(Enum))
            return AssignMauiIconProperties(targetObject);

        if (returnType == typeof(string))
            return AssignFontProperties(targetObject);

        if (returnType == typeof(ImageSource) || returnType == typeof(FontImageSource))
            return AssignFontImageSource();

        if (returnType is null && targetObject is On)
            throw new MauiIconsExpection("OnPlatform and OnIdiom is Built into MauiIcons, Therefore Set OnPlatform or OnIdiom Using Built in Properties");

        throw new MauiIconsExpection($"Maui Icon Extension Does Not Provide {returnType} Support");
    }

    string AssignFontProperties(object targetObject)
    {
        switch (targetObject)
        {
            case Button button:
                button.FontFamily = Icon.GetFontFamily();
                button.TextColor = IconColor.SetDefaultOrAssignedColor(button.TextColor);
                button.BackgroundColor = IconBackgroundColor.SetDefaultOrAssignedColor(button.BackgroundColor);
                button.FontSize = IconSize;
                button.FontAutoScalingEnabled = IconAutoScaling;
                break;
            case Label label:
                label.FontFamily = Icon.GetFontFamily();
                label.TextColor = IconColor.SetDefaultOrAssignedColor(label.TextColor);
                label.BackgroundColor = IconBackgroundColor.SetDefaultOrAssignedColor(label.BackgroundColor);
                label.FontSize = IconSize;
                label.FontAutoScalingEnabled = IconAutoScaling;
                break;
            case Span span:
                span.FontFamily = Icon.GetFontFamily();
                span.TextColor = IconColor.SetDefaultOrAssignedColor(span.TextColor);
                span.BackgroundColor = IconBackgroundColor.SetDefaultOrAssignedColor(span.BackgroundColor);
                span.FontSize = IconSize;
                span.FontAutoScalingEnabled = IconAutoScaling;
                break;
            case Entry entry:
                entry.FontFamily = Icon.GetFontFamily();
                entry.TextColor = IconColor.SetDefaultOrAssignedColor(entry.TextColor);
                entry.BackgroundColor = IconBackgroundColor.SetDefaultOrAssignedColor(entry.BackgroundColor);
                entry.FontSize = IconSize;
                entry.FontAutoScalingEnabled = IconAutoScaling;
                break;
            case Editor editor:
                editor.FontFamily = Icon.GetFontFamily();
                editor.TextColor = IconColor.SetDefaultOrAssignedColor(editor.TextColor);
                editor.BackgroundColor = IconBackgroundColor.SetDefaultOrAssignedColor(editor.BackgroundColor);
                editor.FontSize = IconSize;
                editor.FontAutoScalingEnabled = IconAutoScaling;
                break;
            case SearchBar searchBar:
                searchBar.FontFamily = Icon.GetFontFamily();
                searchBar.TextColor = IconColor.SetDefaultOrAssignedColor(searchBar.TextColor);
                searchBar.BackgroundColor = IconBackgroundColor.SetDefaultOrAssignedColor(searchBar.BackgroundColor);
                searchBar.FontSize = IconSize;
                searchBar.FontAutoScalingEnabled = IconAutoScaling;
                break;
            case MauiIcon mauiIcon:
                mauiIcon.Icon = Icon;
                mauiIcon.IconColor = IconColor.SetDefaultOrAssignedColor(mauiIcon.IconColor);
                mauiIcon.IconBackgroundColor = IconBackgroundColor.SetDefaultOrAssignedColor(mauiIcon.IconBackgroundColor);
                mauiIcon.IconSize = IconSize;
                mauiIcon.IconAutoScaling = IconAutoScaling;
                break;
            default:
                throw new MauiIconsExpection($"Maui Icon Extension Doesn't Support this Control {targetObject}");
        }
        return Icon.GetDescription();
    }

    FontImageSource AssignFontImageSource() => new()
    {
        Glyph = Icon.GetDescription(),
        Color = IconColor.SetDefaultOrAssignedColor(),
        FontFamily = Icon.GetFontFamily(),
        Size = IconSize,
        FontAutoScalingEnabled = IconAutoScaling
    };

#nullable enable
    TEnum? AssignMauiIconProperties(object targetObject)
    {
        bool isIconPropertyChanged = IconColor is not null
            || IconBackgroundColor is not null
            || IconSize is not DefaultIconSize
            || IconAutoScaling;

        if (Icon is not null && isIconPropertyChanged)
        {
            AssignFontProperties(targetObject);
        }
        return Icon;
    }

#nullable disable

}
