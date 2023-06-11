using MauiIcons.Core.Helpers;

namespace MauiIcons.Core;
public abstract class BaseTextIconExtension : IMarkupExtension<string>
{
    public virtual Enum Icon { get; set; }
    protected abstract string IconFontFamily { get; set; }
    public string ProvideValue(IServiceProvider serviceProvider)
    {
        return Icon != null ? EnumHelper.GetEnumDescription(Icon) : string.Empty;
    }

    object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
    {
        return (this as IMarkupExtension<string>).ProvideValue(serviceProvider);
    }
}
