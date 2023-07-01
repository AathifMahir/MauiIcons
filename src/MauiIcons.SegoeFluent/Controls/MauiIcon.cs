using MauiIcons.Core;

namespace MauiIcons.SegoeFluent;
public sealed class MauiIcon : BaseMauiIcon
{
    public new SegoeFluentIcons? Icon 
    {
        get => (SegoeFluentIcons?)base.Icon; 
        set => base.Icon = value;
    }
}
