using MauiIcons.Core;
using MauiIcons.FluentFilled.Common;

namespace MauiIcons.FluentFilled;
public sealed class IconExtension : BaseIconExtension
{
    public new FluentFilledIcons? Icon
    {
        get => (FluentFilledIcons?)base.Icon;
        set => base.Icon = value;
    }
    protected override string IconFontFamily { get; set; } = Constants.FontFamily;
}
