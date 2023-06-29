using MauiIcons.Core;

namespace MauiIcons.Fluent;
public sealed class MauiIcon : BaseMauiIcon
{
    public new FluentIcons? Icon 
    {
        get => (FluentIcons?)GetValue(IconProperty); 
        set => SetValue(IconProperty, value);
    }
}
