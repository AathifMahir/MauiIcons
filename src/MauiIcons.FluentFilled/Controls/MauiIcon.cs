using MauiIcons.Core;

namespace MauiIcons.FluentFilled;
public sealed class MauiIcon : BaseMauiIcon
{
    public new FluentFilledIcons? Icon
    {
        get => (FluentFilledIcons?)base.Icon;
        set => base.Icon = value;
    }
}
