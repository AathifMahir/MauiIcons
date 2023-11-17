namespace MauiIcons.Core.Helpers;
internal static class ThemeHelper
{
    internal static Color SetDefaultOrAssignedColor(this Color value, Color originalColor)
    {
        if (value is null)
        {
            return originalColor;
        }
        return value;
    }

    internal static Color SetDefaultOrAssignedColor(this Color value)
    {
        if (value is null)
        {
            return Application.Current is null ? Colors.Black : Application.Current.RequestedTheme == AppTheme.Dark
               ? Colors.White
               : Colors.Black;
        }
        return value;
    }
}
