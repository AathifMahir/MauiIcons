using MauiIcons.Core;

namespace MauiIcons.SegoeFluent;
public sealed class IconExtension : BaseIconExtension
{
    public new SegoeFluentIcons? Icon 
    { 
        get => (SegoeFluentIcons?)base.Icon;
        set => base.Icon = value;
    }
}
