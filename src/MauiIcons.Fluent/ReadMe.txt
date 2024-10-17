.NET MAUI Icons

Initializing

In order to use the .NET MAUI Icons - Fluent you need to call the extension method in your `MauiProgram.cs` file as follows:

using MauiIcons.Fluent;

public static MauiApp CreateMauiApp()
{
    var builder = MauiApp.CreateBuilder();

    // Initialise the .Net Maui Icons - Fluent
	builder.UseMauiApp<App>().UseFluentIcons();
}

Usage

In order to make use of the .Net Maui Icons - Fluent you can use the below namespace:

xmlns:mi="http://www.aathifmahir.com/dotnet/2022/maui/icons"

----------------------------------------------------------------------------------------------

Built in Control Usage:

Xaml:

<mi:MauiIcon Icon="{mi:Fluent AppFolder48}"/>

C#:

new MauiIcon() {Icon = FluentIcons.Airplane20, IconColor = Colors.Green};

new MauiIcon().Icon(FluentIcons.AppFolder48).IconColor(Colors.Purple);

----------------------------------------------------------------------------------------------

Xaml Extension Usage:

<Image Aspect="Center" mi:MauiIcon.Value="{mi:Fluent Icon=AppFolder48}"/>

<Button mi:MauiIcon.Value="{mi:Fluent Icon=Airplane20}"/>

<ImageButton mi:MauiIcon.Value="{mi:Fluent Icon=Airplane}"/>

----------------------------------------------------------------------------------------------

C# Markup Usage:

new ImageButton().Icon(FluentIcons.Airplane20),

new Image().Icon(FluentIcons.AppFolder48),

new Button().Icon(FluentIcons.Airplane20).IconSize(40.0).IconColor(Colors.Red),


Disclaimer: It's important to note that not all controls are compatible with C# markup. We have conducted tests with the following controls in the current release: 
Label, Image, ImageButton, SearchBar, Editor, and Entry. Additionally, the native MauiIcon control, when combined with C# markup, 
can prove to be quite versatile and offer extra features for various scenarios.

----------------------------------------------------------------------------------------------

## Further information

For more information and Complete Docs please visit:

- Our GitHub repository: https://github.com/AathifMahir/MauiIcons