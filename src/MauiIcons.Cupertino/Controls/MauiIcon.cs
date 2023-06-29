using MauiIcons.Core;

namespace MauiIcons.Cupertino;
public sealed class MauiIcon : BaseMauiIcon
{
    public new CupertinoIcons? Icon
    {
        get => (CupertinoIcons?)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }
}
