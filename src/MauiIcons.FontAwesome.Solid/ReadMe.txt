.NET MAUI Icons

Initializing

In order to use the .NET MAUI Icons - FontAwesome Solid you need to call the extension method in your `MauiProgram.cs` file as follows:

using MauiIcons.FontAwesome.Solid;

public static MauiApp CreateMauiApp()
{
    var builder = MauiApp.CreateBuilder();

    // Initialise the .Net Maui Icons - FontAwesome Solid
	builder.UseMauiApp<App>().UseFontAwesomeSolidMauiIcons();
}

Usage

In order to make use of the .Net Maui Icons - FontAwesome Solid you can use the below namespace:

xmlns:mi="http://www.aathifmahir.com/dotnet/2022/maui/icons"

----------------------------------------------------------------------------------------------

Built in Control Usage:

Xaml:

<mi:MauiIcon Icon="{mi:FontAwesomeSolid Hashtag}"/>

C#:

new MauiIcon() {Icon = FontAwesomeSolidIcons.Asterisk, IconColor = Colors.Green};

new MauiIcon().Icon(FontAwesomeSolidIcons.GreaterThanEqual).IconColor(Colors.Purple);

----------------------------------------------------------------------------------------------

Xaml Extension Usage:

<Image Aspect="Center" Source="{mi:FontAwesomeSolid Icon=Asterisk}"/>

<Label Text="{mi:FontAwesomeSolid Icon=Hashtag}"/>

----------------------------------------------------------------------------------------------

C# Markup Usage:

new ImageButton().Icon(FontAwesomeSolidIcons.Hashtag),

new Image().Icon(FontAwesomeSolidIcons.GreaterThanEqual),

new Label().Icon(FontAwesomeSolidIcons.Asterisk).IconSize(40.0).IconColor(Colors.Red),

new Entry().Icon(FontAwesomeSolidIcons.Hashtag).IconSize(20.0).IconColor(Colors.Aqua),


Disclaimer: It's important to note that not all controls are compatible with C# markup. We have conducted tests with the following controls in the current release: 
Label, Image, ImageButton, SearchBar, Editor, and Entry. Additionally, the native MauiIcon control, when combined with C# markup, 
can prove to be quite versatile and offer extra features for various scenarios.

----------------------------------------------------------------------------------------------

## Further information

For more information and Complete Docs please visit:

- Our GitHub repository: https://github.com/AathifMahir/MauiIcons