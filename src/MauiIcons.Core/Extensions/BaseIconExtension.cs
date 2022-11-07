using MauiIcons.Core.Helpers;

namespace MauiIcons.Core;
public abstract class BaseIconExtension : IMarkupExtension<ImageSource>
{
    public virtual Enum Icon { get; set; }
    public Color IconColor { get; set; }
    public double IconSize { get; set; } = 30.0;
    public bool IconAutoScaling { get; set; }
    protected abstract string IconFontFamily { get; set; }
    public ImageSource ProvideValue(IServiceProvider serviceProvider)
    {
        return new FontImageSource() { Glyph = Icon != null ? EnumHelper.GetEnumDescription(Icon) : string.Empty, 
            Color = IconColor ?? ThemeHelper.SetDefaultIconColor(), FontFamily = IconFontFamily, Size = IconSize, 
            FontAutoScalingEnabled = IconAutoScaling };
    }

    object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
    {
        return (this as IMarkupExtension<ImageSource>).ProvideValue(serviceProvider);
    }
}
