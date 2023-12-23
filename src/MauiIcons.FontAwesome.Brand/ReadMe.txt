.NET MAUI Icons

Initializing

In order to use the .NET MAUI Icons - FontAwesome Brand you need to call the extension method in your `MauiProgram.cs` file as follows:

using MauiIcons.FontAwesome.Brand;

public static MauiApp CreateMauiApp()
{
    var builder = MauiApp.CreateBuilder();

    // Initialise the .Net Maui Icons - FontAwesome Brand
	builder.UseMauiApp<App>().UseFontAwesomeBrandMauiIcons();
}

Usage

In order to make use of the .Net Maui Icons - FontAwesome Brand you can use the below namespace:

xmlns:mi="http://www.aathifmahir.com/dotnet/2022/maui/icons"

----------------------------------------------------------------------------------------------

Built in Control Usage:

Xaml:

<mi:MauiIcon Icon="{mi:FontAwesomeBrand Hashtag}"/>

C#:

new MauiIcon() {Icon = FontAwesomeBrandIcons.GooglePay, IconColor = Colors.Green};

new MauiIcon().Icon(FontAwesomeBrandIcons.Shopify).IconColor(Colors.Purple);

----------------------------------------------------------------------------------------------

Xaml Extension Usage:

<Image Aspect="Center" Source="{mi:FontAwesomeBrand Icon=GooglePay}"/>

<Label Text="{mi:FontAwesomeBrand Icon=Hashtag}"/>

----------------------------------------------------------------------------------------------

C# Markup Usage:

new ImageButton().Icon(FontAwesomeBrandIcons.Hashtag),

new Image().Icon(FontAwesomeBrandIcons.Shopify),

new Label().Icon(FontAwesomeBrandIcons.GooglePay).IconSize(40.0).IconColor(Colors.Red),

new Entry().Icon(FontAwesomeBrandIcons.Hashtag).IconSize(20.0).IconColor(Colors.Aqua),


Disclaimer: It's important to note that not all controls are compatible with C# markup. We have conducted tests with the following controls in the current release: 
Label, Image, ImageButton, SearchBar, Editor, and Entry. Additionally, the native MauiIcon control, when combined with C# markup, 
can prove to be quite versatile and offer extra features for various scenarios.

----------------------------------------------------------------------------------------------

## Further information

For more information and Complete Docs please visit:

- Our GitHub repository: https://github.com/AathifMahir/MauiIcons