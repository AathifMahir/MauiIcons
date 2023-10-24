using MauiIcons.Core;

namespace MauiIcons.Fluent.Filled;
public sealed class IconExtension : BaseIconExtension
{
    public new FluentFilledIcons? Icon
    {
        get => (FluentFilledIcons?)base.Icon;
        set => base.Icon = value;
    }
}
