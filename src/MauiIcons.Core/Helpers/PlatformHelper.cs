using System.Runtime.InteropServices;

namespace MauiIcons.Core.Helpers;
internal static class PlatformHelper
{
    private static readonly string _currentPlatform = DeviceInfo.Platform.ToString();
    private static readonly string _currentIdiom = DeviceInfo.Idiom.ToString();
    public static bool IsValidPlatform(IList<string> platforms)
    {
        if (platforms is null || platforms.Count is 0) return true;

        foreach (var value in CollectionsMarshal.AsSpan((List<string>)platforms))
        {
            if (value.Contains(_currentPlatform, StringComparison.OrdinalIgnoreCase))
                return true;
        }
        return false;
    }    
    public static bool IsValidIdiom(IList<string> idioms)
    {
        if (idioms is null || idioms.Count is 0) return true;

        foreach (var value in CollectionsMarshal.AsSpan((List<string>)idioms))
        {
            if (value.Contains(_currentIdiom, StringComparison.OrdinalIgnoreCase))
                return true;
        }
        return false;
    }

    public static bool IsValidPlatformsAndIdioms(IList<string> onPlatforms, IList<string> onIdioms)
    {
        bool isPlatformsPresent = onPlatforms is not null && onPlatforms.Count > 0;
        bool isIdiomsPresent = onIdioms is not null && onIdioms.Count > 0;

        if(!isPlatformsPresent && !isIdiomsPresent)
            return true;

        bool isPlatformsAndIdioms = isPlatformsPresent && isIdiomsPresent && IsValidPlatformAndIdiom(onPlatforms!, onIdioms!);
        bool isPlatformsOnly = isPlatformsPresent && !isIdiomsPresent && IsValidPlatform(onPlatforms!);
        bool isIdiomsOnly = isIdiomsPresent && !isPlatformsPresent && IsValidIdiom(onIdioms!);

        static bool IsValidPlatformAndIdiom(IList<string> platforms, IList<string> idioms)
        {
            var platformSpan = CollectionsMarshal.AsSpan((List<string>)platforms);
            var idiomSpan = CollectionsMarshal.AsSpan((List<string>)idioms);

            int indexMin = Math.Min(platformSpan.Length, idiomSpan.Length);
            int indexMax = Math.Max(platformSpan.Length, idiomSpan.Length);

            bool onPlatform = false;
            bool onIdiom = false;

            for (int i = 0; i < indexMax; i++)
            {
                if (i < indexMin && platformSpan[i].Contains(_currentPlatform, StringComparison.OrdinalIgnoreCase) && idiomSpan[i].Contains(_currentIdiom, StringComparison.OrdinalIgnoreCase))
                    return true;

                if (i < platforms.Count && platformSpan[i].Contains(_currentPlatform, StringComparison.OrdinalIgnoreCase))
                    onPlatform = true;

                if (i < idioms.Count && idiomSpan[i].Contains(_currentIdiom, StringComparison.OrdinalIgnoreCase))
                    onIdiom = true;

                if (onPlatform && onIdiom)
                    break;
            }
            return onPlatform && onIdiom;
        }

        return isPlatformsAndIdioms
            || isPlatformsOnly
            || isIdiomsOnly;
    }
}
