.NET MAUI Icons

Initializing

In order to use the .NET MAUI Icons - Fluent Filled you need to call the extension method in your `MauiProgram.cs` file as follows:

using MauiIcons.Fluent.Filled;

public static MauiApp CreateMauiApp()
{
    var builder = MauiApp.CreateBuilder();

    // Initialise the .Net Maui Icons - Fluent Filled
	builder.UseMauiApp<App>().UseFluentFilledIcons();
}

Usage

In order to make use of the .Net Maui Icons - Fluent you can use the below namespace:

xmlns:mi="http://www.aathifmahir.com/dotnet/2022/maui/icons"

----------------------------------------------------------------------------------------------

Built in Control Usage:

Xaml:

<mi:MauiIcon Icon="{mi:FluentFilled AppFolder48Filled}"/>

C#:

new MauiIcon() {Icon = FluentFilledIcons.Airplane20Filled, IconColor = Colors.Green};

new MauiIcon().Icon(FluentFilledIcons.AppFolder48Filled).IconColor(Colors.Purple);

----------------------------------------------------------------------------------------------

Xaml Extension Usage:

<Image Aspect="Center" Source="{mi:FluentFilled Icon=AppFolder48Filled}"/>

<Label Text="{mi:FluentFilled Icon=Airplane20Filled}"/>

----------------------------------------------------------------------------------------------

C# Markup Usage:

new ImageButton().Icon(FluentFilledIcons.Airplane20Filled),

new Image().Icon(FluentFilledIcons.AppFolder48Filled),

new Label().Icon(FluentFilledIcons.Airplane20Filled).IconSize(40.0).IconColor(Colors.Red),

new Entry().Icon(FluentFilledIcons.AppFolder48Filled).IconSize(20.0).IconColor(Colors.Aqua),


Disclaimer: It's important to note that not all controls are compatible with C# markup. We have conducted tests with the following controls in the current release: 
Label, Image, ImageButton, SearchBar, Editor, and Entry. Additionally, the native MauiIcon control, when combined with C# markup, 
can prove to be quite versatile and offer extra features for various scenarios.

----------------------------------------------------------------------------------------------

## Further information

For more information and Complete Docs please visit:

- Our GitHub repository: https://github.com/AathifMahir/MauiIcons