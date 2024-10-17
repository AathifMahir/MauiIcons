.NET MAUI Icons

Initializing

In order to use the .NET MAUI Icons - Material Rounded you need to call the extension method in your `MauiProgram.cs` file as follows:

using MauiIcons.Material.Rounded;

public static MauiApp CreateMauiApp()
{
    var builder = MauiApp.CreateBuilder();

    // Initialise the .Net Maui Icons - Material
	builder.UseMauiApp<App>().UseMaterialRoundedMauiIcons();
}

Usage

In order to make use of the .Net Maui Icons - Material Rounded you can use the below namespace:

xmlns:mi="http://www.aathifmahir.com/dotnet/2022/maui/icons"

----------------------------------------------------------------------------------------------

Built in Control Usage:

Xaml:

<mi:MauiIcon Icon="{mi:MaterialRounded AddRoad}"/>

C#:

new MauiIcon() {Icon = MaterialRoundedIcons.ABC, IconColor = Colors.Green};

new MauiIcon().Icon(MaterialRoundedIcons.AddRoad).IconColor(Colors.Purple);

----------------------------------------------------------------------------------------------

Xaml Extension Usage:

<Image Aspect="Center" mi:MauiIcon.Value="{mi:MaterialRounded Icon=AddRoad}"/>

<Button mi:MauiIcon.Value="{mi:MaterialRounded Icon=ABC}"/>

----------------------------------------------------------------------------------------------

C# Markup Usage:

new ImageButton().Icon(MaterialRoundedIcons.ABC),

new Image().Icon(MaterialRoundedIcons.AddRoad),

new Button().Icon(MaterialRoundedIcons.ABC).IconSize(40.0).IconColor(Colors.Red),


Disclaimer: It's important to note that not all controls are compatible with C# markup. We have conducted tests with the following controls in the current release: 
Label, Image, ImageButton, SearchBar, Editor, and Entry. Additionally, the native MauiIcon control, when combined with C# markup, 
can prove to be quite versatile and offer extra features for various scenarios.

----------------------------------------------------------------------------------------------

## Further information

For more information and Complete Docs please visit:

- Our GitHub repository: https://github.com/AathifMahir/MauiIcons