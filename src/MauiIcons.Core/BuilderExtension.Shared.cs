namespace MauiIcons.Core;
public static class BuilderExtension
{
    public static MauiAppBuilder UseMauiIconsCore(this MauiAppBuilder builder, Action<Options>? options = default)
    {
        options?.Invoke(new Options());
        return builder;
    }
}
