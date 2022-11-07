using MauiIcons.Core;

namespace MauiIcons.Fluent;
public sealed class IconExtension : BaseIconExtension
{
    public new FluentIcons? Icon 
    { 
        get => (FluentIcons?)base.Icon;
        set => base.Icon = value;
    }
    protected override string IconFontFamily { get; set; } = Constants.FontFamily;
}
