using System.Globalization;
using System.Resources;

namespace MauiIcons.Modules.UnitTest.Mocks;

public class MockResourceManager : ResourceManager
{
    public override string GetString(string name, CultureInfo? culture) => culture?.EnglishName ?? string.Empty;
}