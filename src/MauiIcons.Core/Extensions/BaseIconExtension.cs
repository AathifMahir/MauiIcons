using MauiIcons.Core.Helpers;

namespace MauiIcons.Core;

[ContentProperty(nameof(Icon))]
public abstract class BaseIconExtension : IMarkupExtension<object>
{
    public virtual Enum Icon { get; set; }
    public Color IconColor { get; set; }
    public double IconSize { get; set; } = 30.0;
    public bool IconAutoScaling { get; set; }
    protected abstract string IconFontFamily { get; set; }
    public object ProvideValue(IServiceProvider serviceProvider)
    {
        IProvideValueTarget provideValueTarget = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
        Type returnType = (provideValueTarget.TargetProperty as BindableProperty)?.ReturnType;

        if (returnType == typeof(string))
        {
            AssignFontFamily(provideValueTarget.TargetObject);
            return Icon is not null ? EnumHelper.GetEnumDescription(Icon) : string.Empty;
        }
        if(returnType == typeof(ImageSource))
        {
            return new FontImageSource()
            {
                Glyph = Icon is not null ? EnumHelper.GetEnumDescription(Icon) : string.Empty,
                Color = IconColor ?? ThemeHelper.SetDefaultIconColor(),
                FontFamily = IconFontFamily,
                Size = IconSize,
                FontAutoScalingEnabled = IconAutoScaling
            };
        }
        throw new NotSupportedException($"Icon Extension Doesn't Support {returnType}");
    }

    public void AssignFontFamily(object targetObject)
    {
        switch (targetObject)
        {
            case Button button:
                button.FontFamily = IconFontFamily;
                break;
            case Label label:
                label.FontFamily = IconFontFamily;
                break;
            case Entry entry:
                entry.FontFamily = IconFontFamily;
                break;
            case Editor editor:
                editor.FontFamily = IconFontFamily;
                break;
            case SearchBar searchBar:
                searchBar.FontFamily = IconFontFamily;
                break;
            default:
                throw new NotSupportedException($"Icon Extension Doesn't Support this Control {targetObject}");
        }
    }
}
