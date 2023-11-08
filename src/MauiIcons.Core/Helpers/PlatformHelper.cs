namespace MauiIcons.Core.Helpers;
internal static class PlatformHelper
{
    public static bool IsValidPlatform(PlatformType platform)
    {
        var devicePlatform = DeviceInfo.Platform;
        var currentPlatform = Constants.PlatformMapping.ContainsKey(devicePlatform) ? Constants.PlatformMapping[devicePlatform] : PlatformType.All;

        if (platform is PlatformType.All || currentPlatform == platform)
            return true;

        return false;
    }

    public static bool IsValidIdiom(IdiomType idiom)
    {
        var deviceIdiom = DeviceInfo.Idiom;
        var currentIdiom = Constants.IdiomMapping.ContainsKey(deviceIdiom) ? Constants.IdiomMapping[deviceIdiom] : IdiomType.All;

        if (idiom is IdiomType.All || currentIdiom == idiom)
            return true;

        return false;
    }

    public static bool IsValidPlatformAndIdiom(PlatformType platform, IdiomType idiom)
    {
        var devicePlatform = DeviceInfo.Platform;
        var deviceIdiom = DeviceInfo.Idiom;
        var currentPlatform = Constants.PlatformMapping.ContainsKey(devicePlatform) ? Constants.PlatformMapping[devicePlatform] : PlatformType.All;
        var currentIdiom = Constants.IdiomMapping.ContainsKey(deviceIdiom) ? Constants.IdiomMapping[deviceIdiom] : IdiomType.All;

        if ((platform is PlatformType.All || currentPlatform == platform) &&
        (idiom is IdiomType.All || currentIdiom == idiom))
            return true;

        return false;
    }
}
