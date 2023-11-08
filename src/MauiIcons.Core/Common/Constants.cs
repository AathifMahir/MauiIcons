namespace MauiIcons.Core;
internal class Constants
{
    public static Dictionary<DevicePlatform, PlatformType> PlatformMapping = new()
    {
            { DevicePlatform.WinUI, PlatformType.WinUI },
            { DevicePlatform.MacCatalyst, PlatformType.MacCatalyst },
            { DevicePlatform.Android, PlatformType.Android },
            { DevicePlatform.iOS, PlatformType.IOS },
            { DevicePlatform.Unknown, PlatformType.Unknown }
    };

    public static Dictionary<DeviceIdiom, IdiomType> IdiomMapping = new()
    {
            { DeviceIdiom.Desktop, IdiomType.Desktop },
            { DeviceIdiom.Tablet, IdiomType.Tablet },
            { DeviceIdiom.Phone, IdiomType.Phone },
            { DeviceIdiom.Watch, IdiomType.Watch },
            { DeviceIdiom.TV, IdiomType.TV },
            { DeviceIdiom.Unknown, IdiomType.Unknown }
    };
}
