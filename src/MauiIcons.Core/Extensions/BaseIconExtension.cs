using MauiIcons.Core.Helpers;

namespace MauiIcons.Core;

[ContentProperty(nameof(Icon))]
public abstract class BaseIconExtension<TEnum> : IMarkupExtension<object> where TEnum : struct, Enum
{
    public TEnum? Icon { get; set; }
    public Color IconColor { get; set; }
    public Color IconBackgroundColor { get; set; }

    [System.ComponentModel.TypeConverter(typeof(FontSizeConverter))]
    public double IconSize { get; set; } = DefaultIconSize;
    public bool IconAutoScaling { get; set; }

    const double DefaultIconSize = 30.0;
    public object ProvideValue(IServiceProvider serviceProvider)
    {
        IProvideValueTarget provideValueTarget = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
        Type returnType = (provideValueTarget.TargetProperty as BindableProperty)?.ReturnType;

        if (returnType == typeof(Enum))
        {
            return AssignMauiIconProperties(provideValueTarget.TargetObject);
        }
        if (returnType == typeof(string))
        {
            return AssignFontProperties(provideValueTarget.TargetObject);
        }
        if (returnType == typeof(ImageSource))
        {
            return AssignFontImageSource();
        }
        throw new NotSupportedException($"Maui Icon Extension Doesn't Support {returnType}");
    }

    string AssignFontProperties(object targetObject)
    {
        switch (targetObject)
        {
            case Button button:
                button.FontFamily = Icon.GetFontFamily();
                button.TextColor = IconColor.SetDefaultOrAssignedColor();
                button.BackgroundColor = IconBackgroundColor;
                button.FontSize = IconSize;
                button.FontAutoScalingEnabled = IconAutoScaling;
                break;
            case Label label:
                label.FontFamily = Icon.GetFontFamily();
                label.TextColor = IconColor.SetDefaultOrAssignedColor();
                label.BackgroundColor = IconBackgroundColor;
                label.FontSize = IconSize;
                label.FontAutoScalingEnabled = IconAutoScaling;
                break;
            case Entry entry:
                entry.FontFamily = Icon.GetFontFamily();
                entry.TextColor = IconColor.SetDefaultOrAssignedColor();
                entry.BackgroundColor = IconBackgroundColor;
                entry.FontSize = IconSize;
                entry.FontAutoScalingEnabled = IconAutoScaling;
                break;
            case Editor editor:
                editor.FontFamily = Icon.GetFontFamily();
                editor.TextColor = IconColor.SetDefaultOrAssignedColor();
                editor.BackgroundColor = IconBackgroundColor;
                editor.FontSize = IconSize;
                editor.FontAutoScalingEnabled = IconAutoScaling;
                break;
            case SearchBar searchBar:
                searchBar.FontFamily = Icon.GetFontFamily();
                searchBar.TextColor = IconColor.SetDefaultOrAssignedColor();
                searchBar.BackgroundColor = IconBackgroundColor;
                searchBar.FontSize = IconSize;
                searchBar.FontAutoScalingEnabled = IconAutoScaling;
                break;
            case MauiIcon mauiIcon:
                mauiIcon.IconColor = IconColor.SetDefaultOrAssignedColor();
                mauiIcon.IconBackgroundColor = IconBackgroundColor;
                mauiIcon.IconSize = IconSize;
                mauiIcon.IconAutoScaling = IconAutoScaling;
                break;
            default:
                throw new NotSupportedException($"Maui Icon Extension using Text Doesn't Support this Control {targetObject}");
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

}
