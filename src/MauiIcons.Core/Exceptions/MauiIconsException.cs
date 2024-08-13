namespace MauiIcons.Core;
public sealed class MauiIconsException : Exception
{
    public MauiIconsException(string message): base(message){}
    public MauiIconsException(string code, string message) : base(string.Format("{code}: {message}", code, message)){}
}
