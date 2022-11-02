using MauiIcons.Core.Helpers;

namespace MauiIcons.Core;
public abstract class BaseIconExtension : IMarkupExtension<ImageSource>
{
    public virtual Enum Icon { get; set; }
    public Color IconColor { get; set; }
    protected abstract string IconFontFamily { get; set; }
    public ImageSource ProvideValue(IServiceProvider serviceProvider)
    {
        return new FontImageSource() { Glyph = Icon != null ? EnumHelper.GetEnumDescription(Icon) : string.Empty, Color = IconColor ?? Colors.White, FontFamily = IconFontFamily };
    }

    object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
    {
        return (this as IMarkupExtension<ImageSource>).ProvideValue(serviceProvider);
    }
}
