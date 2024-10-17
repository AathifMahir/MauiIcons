.NET MAUI Icons

Initializing

In order to use the .NET MAUI Icons - Material you need to call the extension method in your `MauiProgram.cs` file as follows:

using MauiIcons.Material;

public static MauiApp CreateMauiApp()
{
    var builder = MauiApp.CreateBuilder();

    // Initialise the .Net Maui Icons - Material
	builder.UseMauiApp<App>().UseMaterialIcons();
}

Usage

In order to make use of the .Net Maui Icons - Material you can use the below namespace:

xmlns:mi="http://www.aathifmahir.com/dotnet/2022/maui/icons"

----------------------------------------------------------------------------------------------

Built in Control Usage:

Xaml:

<mi:MauiIcon Icon="{mi:Material AddRoad}"/>

C#:

new MauiIcon() {Icon = MaterialIcons.ABC, IconColor = Colors.Green};

new MauiIcon().Icon(MaterialIcons.AddRoad).IconColor(Colors.Purple);

----------------------------------------------------------------------------------------------

Xaml Extension Usage:

<Image Aspect="Center" mi:MauiIcon.Value="{mi:Material Icon=AddRoad}"/>

<Button mi:MauiIcon.Value="{mi:Material Icon=ABC}"/>

----------------------------------------------------------------------------------------------

C# Markup Usage:

new ImageButton().Icon(MaterialIcons.ABC),

new Image().Icon(MaterialIcons.AddRoad),

new Button().Icon(MaterialIcons.ABC).IconSize(40.0).IconColor(Colors.Red),


Disclaimer: It's important to note that not all controls are compatible with C# markup. We have conducted tests with the following controls in the current release: 
Label, Image, ImageButton, SearchBar, Editor, and Entry. Additionally, the native MauiIcon control, when combined with C# markup, 
can prove to be quite versatile and offer extra features for various scenarios.

----------------------------------------------------------------------------------------------

## Further information

For more information and Complete Docs please visit:

- Our GitHub repository: https://github.com/AathifMahir/MauiIcons