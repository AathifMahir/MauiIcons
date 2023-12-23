[assembly: XmlnsDefinition(Constants.XamlNamespace, Constants.MauiIconsNamespacePrefix + nameof(MauiIcons.FontAwesome.Solid))]
[assembly: XmlnsDefinition(Constants.XamlNamespace, Constants.MauiIconsNamespace)]

[assembly: Microsoft.Maui.Controls.XmlnsPrefix(Constants.XamlNamespace, "icons")]

static class Constants
{
    internal const string XamlNamespace = "http://www.aathifmahir.com/dotnet/2022/maui/icons";
    internal const string MauiIconsNamespace = $"{nameof(MauiIcons)}.{nameof(MauiIcons.FontAwesome)}";
    internal const string MauiIconsNamespacePrefix = $"{MauiIconsNamespace}.";

    internal static readonly string FontFamily = "FontAwesomeSolidIcons";
    internal static readonly string TtfFontFamily = "FontAwesome6Free-Solid-900.otf";
}