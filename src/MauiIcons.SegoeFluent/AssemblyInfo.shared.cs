[assembly: XmlnsDefinition(Constants.XamlNamespace, Constants.MauiIconsNamespacePrefix + nameof(MauiIcons.SegoeFluent))]

[assembly: Microsoft.Maui.Controls.XmlnsPrefix(Constants.XamlNamespace, "icons")]

static class Constants
{
    internal const string XamlNamespace = "http://www.aathifmahir.com/dotnet/2022/maui/icons";
    internal const string MauiIconsNamespacePrefix = $"{nameof(MauiIcons)}.";

    internal static readonly string FontFamily = "SegoeFluentIcons";
    internal static readonly string TtfFontFamily = "Segoe_Fluent_Icons.ttf";
}