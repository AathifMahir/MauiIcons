namespace MauiIcons.Core.Helpers;
internal static class PlatformHelper
{
    public static bool IsValidPlatform(IList<string> platforms)
    {
        if (platforms is null) return true;

        string targetPlatform = DeviceInfo.Platform.ToString();

        foreach (var value in platforms)
        {
            if (value.Contains(targetPlatform))
                return true;
        }
        return false;
    }

    public static bool IsValidIdiom(IList<string> idioms)
    {
        if(idioms is null) return true;

        string targetIdiom = DeviceInfo.Idiom.ToString();

        foreach (var value in idioms)
        {
            if (value.Contains(targetIdiom))
                return true;
        }
        return false;
    }

    public static bool IsValidPlatformsAndIdioms(IList<string> onPlatforms, IList<string> onIdioms)
    {
        if(onPlatforms is null &&  onIdioms is null) return true;

        bool isPlatformsPresent = onPlatforms is not null && onPlatforms.Count > 0;
        bool isIdiomsPresent = onIdioms is not null && onIdioms.Count > 0;

        bool isPlatformAndIdiomDefault = !isPlatformsPresent && !isIdiomsPresent;
        bool isPlatformsAndIdioms = isPlatformsPresent && isIdiomsPresent && IsValidPlatformAndIdiom(onPlatforms!, onIdioms!);
        bool isPlatformsOnly = isPlatformsPresent && !isIdiomsPresent && IsValidPlatform(onPlatforms!);
        bool isIdiomsOnly = isIdiomsPresent && !isPlatformsPresent && IsValidIdiom(onIdioms!);
        
        return isPlatformAndIdiomDefault 
            || isPlatformsAndIdioms
            || isPlatformsOnly
            || isIdiomsOnly;
    }

    private static bool IsValidPlatformAndIdiom(IList<string> platforms, IList<string> idioms)
    {
        int indexMin = Math.Min(platforms.Count, idioms.Count);
        int indexMax = Math.Max(platforms.Count, idioms.Count);

        bool onPlatform = false;
        bool onIdiom = false;

        string targetPlatform = DeviceInfo.Platform.ToString();
        string targetIdiom = DeviceInfo.Idiom.ToString();

        for (int i = 0; i < indexMax; i++)
        {
            if (i < indexMin && platforms[i].Contains(targetPlatform) && idioms[i].Contains(targetIdiom))
                return true;

            if (i < platforms.Count && platforms[i].Contains(targetPlatform))
                onPlatform = true;

            if (i < idioms.Count && idioms[i].Contains(targetIdiom))
                onIdiom = true;

            if (onPlatform && onIdiom)
                break;
        }
        return onPlatform && onIdiom;
    }
}
