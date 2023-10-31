namespace MauiIcons.Core;
public sealed class MauiIconsExpection : Exception
{
    public MauiIconsExpection(string message): base(message){}
    public MauiIconsExpection(string code, string message) : base(string.Format("{code}: {message}", code, message)){}
}
