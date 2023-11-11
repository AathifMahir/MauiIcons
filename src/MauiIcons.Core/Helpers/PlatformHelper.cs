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

    public static bool IsValidPlatform(IList<string> platforms)
    {
        foreach(var value in platforms)
        {
            if (value.Contains(DeviceInfo.Platform.ToString()))
                return true;
        }
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

    public static bool IsValidIdiom(IList<string> idioms)
    {
        foreach (var value in idioms)
        {
            if (value.Contains(DeviceInfo.Idiom.ToString()))
                return true;
        }
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

    public static bool IsValidPlatformAndIdiom(IList<string> platforms, IList<string> idioms)
    {
        int indexMin = Math.Min(platforms.Count, idioms.Count);
        int indexMax = Math.Max(platforms.Count, idioms.Count);

        for (int i = 0; i < indexMax; i++)
        {
            if (i <= indexMin && platforms[i].Contains(DeviceInfo.Platform.ToString()) && idioms[i].Contains(DeviceInfo.Idiom.ToString()))
                return true;

            if (i <= platforms.Count && platforms[i].Contains(DeviceInfo.Platform.ToString()))
                return true;

            if (i <= idioms.Count && idioms[i].Contains(DeviceInfo.Idiom.ToString()))
                return true;
        }
        return false;
    }
}
