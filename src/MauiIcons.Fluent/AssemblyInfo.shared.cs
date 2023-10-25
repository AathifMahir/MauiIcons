[assembly: XmlnsDefinition(Constants.XamlNamespace, Constants.MauiIconsNamespacePrefix + nameof(MauiIcons.Fluent))]

[assembly: Microsoft.Maui.Controls.XmlnsPrefix(Constants.XamlNamespace, "icons")]

static class Constants
{
    internal const string XamlNamespace = "http://www.aathifmahir.com/dotnet/2022/maui/icons";
    internal const string MauiIconsNamespacePrefix = $"{nameof(MauiIcons)}.";

    internal static readonly string FontFamily = "FluentIcons";
    internal static readonly string TtfFontFamily = "Fluent_Icons_Regular.ttf";
}