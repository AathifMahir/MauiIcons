[assembly: XmlnsDefinition(Constants.XamlNamespace, Constants.MauiIconsNamespacePrefix + nameof(MauiIcons.Cupertino))]

[assembly: Microsoft.Maui.Controls.XmlnsPrefix(Constants.XamlNamespace, "icons")]

static partial class Constants
{
    internal const string XamlNamespace = "http://www.aathifmahir.com/dotnet/2022/maui/icons";
    internal const string MauiIconsNamespacePrefix = $"{nameof(MauiIcons)}.";

    internal static readonly string FontFamily = "CupertinoIcons";
    internal static readonly string TtfFontFamily = "Cupertino_Icons.ttf";
}