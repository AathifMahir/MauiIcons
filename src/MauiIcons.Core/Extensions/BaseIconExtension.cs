using MauiIcons.Core.Helpers;

namespace MauiIcons.Core;

[ContentProperty(nameof(Icon))]
public abstract class BaseIconExtension : IMarkupExtension<object>
{
    public virtual Enum Icon { get; set; }
    public Color IconColor { get; set; }

    [System.ComponentModel.TypeConverter(typeof(FontSizeConverter))]
    public double IconSize { get; set; } = 30.0;
    public bool IconAutoScaling { get; set; }
    protected virtual string IconFontFamily { get; set; }
    public object ProvideValue(IServiceProvider serviceProvider)
    {
        IProvideValueTarget provideValueTarget = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
        Type returnType = (provideValueTarget.TargetProperty as BindableProperty)?.ReturnType;

        if (returnType == typeof(string))
        {
            AssignFontProperties(provideValueTarget.TargetObject);
            return Icon is not null ? EnumHelper.GetEnumDescription(Icon) : string.Empty;
        }
        if(returnType == typeof(ImageSource))
        {
            return new FontImageSource()
            {
                Glyph = Icon is not null ? EnumHelper.GetEnumDescription(Icon) : string.Empty,
                Color = IconColor ?? ThemeHelper.SetDefaultIconColor(),
                FontFamily = AssignDefaultFontFamily(),
                Size = IconSize,
                FontAutoScalingEnabled = IconAutoScaling
            };
        }
        throw new NotSupportedException($"Icon Extension Doesn't Support {returnType}");
    }

    void AssignFontProperties(object targetObject)
    {
        switch (targetObject)
        {
            case Button button:
                button.FontFamily = AssignDefaultFontFamily();
                button.TextColor = IconColor ?? ThemeHelper.SetDefaultIconColor();
                button.FontSize = IconSize;
                break;
            case Label label:
                label.FontFamily = AssignDefaultFontFamily();
                label.TextColor = IconColor ?? ThemeHelper.SetDefaultIconColor();
                label.FontSize = IconSize;
                break;
            case Entry entry:
                entry.FontFamily = AssignDefaultFontFamily();
                entry.TextColor = IconColor ?? ThemeHelper.SetDefaultIconColor();
                entry.FontSize = IconSize;
                break;
            case Editor editor:
                editor.FontFamily = AssignDefaultFontFamily();
                editor.TextColor = IconColor ?? ThemeHelper.SetDefaultIconColor();
                editor.FontSize = IconSize;
                break;
            case SearchBar searchBar:
                searchBar.FontFamily = AssignDefaultFontFamily();
                searchBar.TextColor = IconColor ?? ThemeHelper.SetDefaultIconColor();
                searchBar.FontSize = IconSize;
                break;
            default:
                throw new NotSupportedException($"Icon Extension using Text Doesn't Support this Control {targetObject}");
        }
    }

    string AssignDefaultFontFamily()
    {
        if (IconFontFamily is not null) return IconFontFamily;
        if(Icon is not null) return Icon.GetType().Name;
        return string.Empty;
    }
}
