using MauiIcons.Core.Helpers;

namespace MauiIcons.Core;
public static class CommonExtension
{
    /// <summary>
    /// this is used for seamlessly transforming the MauiIcons Enum Constructs to an ImageSource
    /// </summary>
    /// <param name="iconColor">sets the color of the icon. Defaults to black or white based on App Theme</param>
    /// <param name="iconSize">sets the size of the icon. Defaults to 30.0</param>
    /// <param name="iconAutoScaling">sets a value indicating whether the icon should automatically scale. Defaults to false</param>
    /// <returns>Icon as ImageSource</returns>
    /// <exception cref="MauiIconsException">
    /// Thrown when the Enum is not a MauiIcons Construct
    /// </exception>
    public static ImageSource ToImageSource(this Enum icon, Color? iconColor = null, double iconSize = 30.0, bool iconAutoScaling = false)
    {
        if (icon.GetDescription() is null)
            throw new MauiIconsException("MauiIcons ToImageSourceExtension Only Works on MauiIcons Constructs Not on All the Enum Types");

        return new FontImageSource()
        {
            Glyph = icon.GetDescription(),
            Color = iconColor.SetDefaultOrAssignedColor(),
            FontFamily = icon.GetFontFamily(),
            Size = iconSize,
            FontAutoScalingEnabled = iconAutoScaling
        };
    }
}
