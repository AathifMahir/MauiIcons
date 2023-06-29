using MauiIcons.Core;
using MauiIcons.FluentFilled.Common;

namespace MauiIcons.FluentFilled;
public sealed class MauiIcon : BaseMauiIcon
{
    public new FluentFilledIcons? Icon
    {
        get => (FluentFilledIcons?)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }
}
