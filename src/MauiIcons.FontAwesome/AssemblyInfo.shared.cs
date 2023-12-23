[assembly: XmlnsDefinition(Constants.XamlNamespace, Constants.MauiIconsNamespacePrefix + nameof(MauiIcons.FontAwesome))]

[assembly: Microsoft.Maui.Controls.XmlnsPrefix(Constants.XamlNamespace, "icons")]

static class Constants
{
    internal const string XamlNamespace = "http://www.aathifmahir.com/dotnet/2022/maui/icons";
    internal const string MauiIconsNamespacePrefix = $"{nameof(MauiIcons)}.";

    internal static readonly string FontFamily = "FontAwesomeIcons";
    internal static readonly string TtfFontFamily = "FontAwesome6Free-Regular-400.otf";
}