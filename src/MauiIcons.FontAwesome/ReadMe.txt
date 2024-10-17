.NET MAUI Icons

Initializing

In order to use the .NET MAUI Icons - FontAwesome you need to call the extension method in your `MauiProgram.cs` file as follows:

using MauiIcons.FontAwesome;

public static MauiApp CreateMauiApp()
{
    var builder = MauiApp.CreateBuilder();

    // Initialise the .Net Maui Icons - FontAwesome
	builder.UseMauiApp<App>().UseFontAwesomeMauiIcons();
}

Usage

In order to make use of the .Net Maui Icons - FontAwesome you can use the below namespace:

xmlns:mi="http://www.aathifmahir.com/dotnet/2022/maui/icons"

----------------------------------------------------------------------------------------------

Built in Control Usage:

Xaml:

<mi:MauiIcon Icon="{mi:FontAwesome Hashtag}"/>

C#:

new MauiIcon() {Icon = FontAwesomeIcons.Asterisk, IconColor = Colors.Green};

new MauiIcon().Icon(FontAwesomeIcons.GreaterThan).IconColor(Colors.Purple);

----------------------------------------------------------------------------------------------

Xaml Extension Usage:

<Image Aspect="Center" mi:MauiIcon.Value="{mi:FontAwesome Icon=Asterisk}"/>

<Button mi:MauiIcon.Value="{mi:FontAwesome Icon=Hashtag}"/>

----------------------------------------------------------------------------------------------

C# Markup Usage:

new ImageButton().Icon(FontAwesomeIcons.Hashtag),

new Image().Icon(FontAwesomeIcons.GreaterThan),

new Button().Icon(FontAwesomeIcons.Asterisk).IconSize(40.0).IconColor(Colors.Red),


Disclaimer: It's important to note that not all controls are compatible with C# markup. We have conducted tests with the following controls in the current release: 
Label, Image, ImageButton, SearchBar, Editor, and Entry. Additionally, the native MauiIcon control, when combined with C# markup, 
can prove to be quite versatile and offer extra features for various scenarios.

----------------------------------------------------------------------------------------------

## Further information

For more information and Complete Docs please visit:

- Our GitHub repository: https://github.com/AathifMahir/MauiIcons