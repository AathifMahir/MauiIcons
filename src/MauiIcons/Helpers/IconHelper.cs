using MauiIcons.Common;

namespace MauiIcons.Helpers;
internal sealed class IconHelper
{
    internal static string AssignSelectedFontFamily()
    {
        return Globals.SelectedIconType switch
        {
            IconType.Fluent => Constants.FluentIcons,
            IconType.Material => Constants.MaterialIcons,
            // TODO Add Cuppertino and Default Icon Support
            //IconType.Cuppertino => Constants.CuppertinoIcons,
            //IconType.Default => GetPlatformBasedFontFamily(),
            _ => Constants.FluentIcons,
        };
    }

    //private static string GetPlatformBasedFontFamily()
    //{
    //    if (DeviceInfo.Current.Platform == DevicePlatform.Android)
    //        return Constants.MaterialIcons;
    //    if (DeviceInfo.Current.Platform == DevicePlatform.iOS ||
    //        DeviceInfo.Current.Platform == DevicePlatform.MacCatalyst ||
    //        DeviceInfo.Current.Platform == DevicePlatform.MacCatalyst)
    //        return Constants.CuppertinoIcons;
    //    return Constants.FluentIcons;
    //}
}
