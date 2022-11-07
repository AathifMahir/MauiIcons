namespace MauiIcons.Core.Helpers;
internal sealed class ThemeHelper
{
    internal static Color SetDefaultIconColor()
    {
        return Application.Current.RequestedTheme == AppTheme.Dark ? Colors.White 
            : Application.Current.RequestedTheme == AppTheme.Light ? Colors.Black 
            : Colors.White;
    }
}
