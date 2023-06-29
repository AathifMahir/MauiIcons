using MauiIcons.Core;

namespace MauiIcons.FluentFilled;
public sealed class IconExtension : BaseIconExtension
{
    public new FluentFilledIcons? Icon
    {
        get => (FluentFilledIcons?)base.Icon;
        set => base.Icon = value;
    }
}
