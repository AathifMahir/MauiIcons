using MauiIcons.Core;

namespace MauiIcons.Cupertino;
public sealed class IconExtension : BaseIconExtension
{
    public new CupertinoIcons? Icon
    {
        get => (CupertinoIcons?)base.Icon;
        set => base.Icon = value;
    }
    protected override string IconFontFamily { get; set; } = Constants.FontFamily;
}
