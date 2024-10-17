namespace MauiIcons.Core;

#pragma warning disable CA1822 // Mark members as static
public class Options
{
    internal static bool DefaultFontOverride { get; private set; }
    internal static double DefaultIconSize { get; private set; } = 0;

    internal static bool? DefaultIconAutoScaling { get; private set; }

    /// <summary>
    /// This property determines whether exceptions are suppressed when the overriding font is not set on a specific control that uses MauiIcons.
    /// </summary>
    /// <remarks>
    /// The default value is false.
    /// </remarks>
    public void SetDefaultFontOverride(bool value) => DefaultFontOverride = value;


    /// <summary>
    /// This property determines the default size of the icon.
    /// </summary>
    /// <param name="value"></param>

    public void SetDefaultIconSize(double value) => DefaultIconSize = value;


    /// <summary>
    /// This property determines whether the icon auto-scaling is enabled by default.
    /// </summary>
    /// <param name="value"></param>
    public void SetDefaultIconAutoScaling(bool value) => DefaultIconAutoScaling = value;



}
#pragma warning restore CA1822 // Mark members as static
