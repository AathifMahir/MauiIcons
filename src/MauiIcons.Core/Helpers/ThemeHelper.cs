namespace MauiIcons.Core.Helpers;
internal static class ThemeHelper
{
    internal static Color SetDefaultOrAssignedColor(this Color value)
    {
        if (value == default)
        {
            return Application.Current.RequestedTheme == AppTheme.Dark 
                ? Colors.White 
                : Colors.Black;
        }
        return value;
    }

    internal static Color SetThemeAwareIconColor()
    {
        return Application.Current.RequestedTheme == AppTheme.Dark
                ? Colors.White
                : Colors.Black;
    }
}
