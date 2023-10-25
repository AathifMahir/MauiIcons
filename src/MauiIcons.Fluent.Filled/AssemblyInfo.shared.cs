[assembly: XmlnsDefinition(Constants.XamlNamespace, Constants.MauiIconsNamespacePrefix + nameof(MauiIcons.Fluent.Filled))]
[assembly: XmlnsDefinition(Constants.XamlNamespace, Constants.MauiIconsNamespace)]

[assembly: Microsoft.Maui.Controls.XmlnsPrefix(Constants.XamlNamespace, "icons")]

static class Constants
{
    internal const string XamlNamespace = "http://www.aathifmahir.com/dotnet/2022/maui/icons";
    internal const string MauiIconsNamespace = $"{nameof(MauiIcons)}.{nameof(MauiIcons.Fluent)}";
    internal const string MauiIconsNamespacePrefix = $"{MauiIconsNamespace}.";

    internal static readonly string FontFamily = "FluentFilledIcons";
    internal static readonly string TtfFontFamily = "FluentSystemIcons-Filled.ttf";
}