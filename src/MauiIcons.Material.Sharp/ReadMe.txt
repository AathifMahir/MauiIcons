.NET MAUI Icons

Initializing

In order to use the .NET MAUI Icons - Material Sharp you need to call the extension method in your `MauiProgram.cs` file as follows:

using MauiIcons.Material.Sharp;

public static MauiApp CreateMauiApp()
{
    var builder = MauiApp.CreateBuilder();

    // Initialise the .Net Maui Icons - Material
	builder.UseMauiApp<App>().UseMaterialSharpMauiIcons();
}

Usage

In order to make use of the .Net Maui Icons - Material Sharp you can use the below namespace:

xmlns:mi="http://www.aathifmahir.com/dotnet/2022/maui/icons"

----------------------------------------------------------------------------------------------

Built in Control Usage:

Xaml:

<mi:MauiIcon Icon="{mi:MaterialSharp AddRoad}"/>

C#:

new MauiIcon() {Icon = MaterialSharpIcons.ABC, IconColor = Colors.Green};

new MauiIcon().Icon(MaterialSharpIcons.AddRoad).IconColor(Colors.Purple);

----------------------------------------------------------------------------------------------

Xaml Extension Usage:

<Image Aspect="Center" mi:MauiIcon.Value="{mi:MaterialSharp Icon=AddRoad}"/>

<Button mi:MauiIcon.Value="{mi:MaterialSharp Icon=ABC}"/>

----------------------------------------------------------------------------------------------

C# Markup Usage:

new ImageButton().Icon(MaterialSharpIcons.ABC),

new Image().Icon(MaterialSharpIcons.AddRoad),

new Button().Icon(MaterialSharpIcons.ABC).IconSize(40.0).IconColor(Colors.Red),


Disclaimer: It's important to note that not all controls are compatible with C# markup. We have conducted tests with the following controls in the current release: 
Label, Image, ImageButton, SearchBar, Editor, and Entry. Additionally, the native MauiIcon control, when combined with C# markup, 
can prove to be quite versatile and offer extra features for various scenarios.

----------------------------------------------------------------------------------------------

## Further information

For more information and Complete Docs please visit:

- Our GitHub repository: https://github.com/AathifMahir/MauiIcons