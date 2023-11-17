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

    [System.ComponentModel.TypeConverter(typeof(ListStringTypeConverter))]
    public IList<string> OnPlatforms { get; set; }

    [System.ComponentModel.TypeConverter(typeof(ListStringTypeConverter))]
    public IList<string> OnIdioms { get; set; }
    public Type TypeArgument { get; set; }

    const double DefaultIconSize = 30.0;
    public object ProvideValue(IServiceProvider serviceProvider)
    {
        IProvideValueTarget provideValueTarget = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
        Type returnType = (provideValueTarget.TargetProperty as BindableProperty)?.ReturnType;

        if (PlatformHelper.IsValidPlatformsAndIdioms(OnPlatforms, OnIdioms))
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

        if (returnType is null && (targetObject is On || targetObject is OnPlatform<ImageSource>
            || targetObject is OnPlatform<FontImageSource> || targetObject is OnPlatformExtension
            || targetObject is OnIdiom<ImageSource> || targetObject is OnIdiom<FontImageSource>
            || targetObject is OnIdiomExtension) &&
            (TypeArgument == typeof(ImageSource) || TypeArgument == typeof(FontImageSource)))
            return AssignFontImageSource();

        else if (returnType is null && targetObject is On && (TypeArgument is null || TypeArgument != typeof(ImageSource) || TypeArgument != typeof(FontImageSource)))
            throw new MauiIconsExpection("MauiIcons only supports ImageSource or FontImageSource in conjunction with OnPlatform and OnIdiom After Assigning TypeArgument." +
                "it is recommended to utilize MauiIcon's integrated OnPlatform or OnIdiom functionalities for optimal compatibility.");

        throw new MauiIconsExpection($"MauiIcons extension does not provide {returnType} support");
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
                throw new MauiIconsExpection($"MauiIcons extension doesn't support this control {targetObject}");
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
