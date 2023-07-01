using MauiIcons.Core;

namespace MauiIcons.Fluent;
public sealed class MauiIcon : BaseMauiIcon
{
    public new FluentIcons? Icon 
    {
        get => (FluentIcons?)base.Icon; 
        set => base.Icon = value;
    }
}
