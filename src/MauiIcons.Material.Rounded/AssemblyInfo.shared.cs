[assembly: XmlnsDefinition(Constants.XamlNamespace, Constants.MauiIconsNamespacePrefix + nameof(MauiIcons.Material.Rounded))]
[assembly: XmlnsDefinition(Constants.XamlNamespace, Constants.MauiIconsNamespace)]

[assembly: Microsoft.Maui.Controls.XmlnsPrefix(Constants.XamlNamespace, "icons")]

static class Constants
{
    internal const string XamlNamespace = "http://www.aathifmahir.com/dotnet/2022/maui/icons";
    internal const string MauiIconsNamespace = $"{nameof(MauiIcons)}.{nameof(MauiIcons.Material)}";
    internal const string MauiIconsNamespacePrefix = $"{MauiIconsNamespace}.";

    internal static readonly string FontFamily = "MaterialRoundedIcons";
    internal static readonly string TtfFontFamily = "MaterialIconsRound-Regular.otf";
}