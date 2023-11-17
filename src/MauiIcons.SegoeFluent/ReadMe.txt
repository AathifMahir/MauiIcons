.NET MAUI Icons

Initializing

In order to use the .NET MAUI Icons - Segoe Fluent you need to call the extension method in your `MauiProgram.cs` file as follows:

using MauiIcons.SegoeFluent;

public static MauiApp CreateMauiApp()
{
    var builder = MauiApp.CreateBuilder();

    // Initialise the .Net Maui Icons - Segoe Fluent
	builder.UseMauiApp<App>().UseSegoeFluentMauiIcons();
}

Usage

In order to make use of the .Net Maui Icons - Segoe Fluent you can use the below namespace:

xmlns:mi="http://www.aathifmahir.com/dotnet/2022/maui/icons"

----------------------------------------------------------------------------------------------

Built in Control Usage:

Xaml:

<mi:MauiIcon Icon="{mi:SegoeFluent AdjustHologram}"/>

C#:

new MauiIcon() {Icon = SegoeFluentIcons.ActionCenterQuiet, IconColor = Colors.Green};

new MauiIcon().Icon(SegoeFluentIcons.AdjustHologram).IconColor(Colors.Purple);

----------------------------------------------------------------------------------------------

Xaml Extension Usage:

<Image Aspect="Center" Source="{mi:SegoeFluent Icon=AdjustHologram}"/>

<Label Text="{mi:SegoeFluent Icon=ActionCenterQuiet}"/>

----------------------------------------------------------------------------------------------

C# Markup Usage:

new ImageButton().Icon(SegoeFluentIcons.ActionCenterQuiet),

new Image().Icon(SegoeFluentIcons.AdjustHologram),

new Label().Icon(SegoeFluentIcons.ActionCenterQuiet).IconSize(40.0).IconColor(Colors.Red),

new Entry().Icon(SegoeFluentIcons.AdjustHologram).IconSize(20.0).IconColor(Colors.Aqua),


Disclaimer: It's important to note that not all controls are compatible with C# markup. We have conducted tests with the following controls in the current release: 
Label, Image, ImageButton, SearchBar, Editor, and Entry. Additionally, the native MauiIcon control, when combined with C# markup, 
can prove to be quite versatile and offer extra features for various scenarios.

----------------------------------------------------------------------------------------------

## Further information

For more information and Complete Docs please visit:

- Our GitHub repository: https://github.com/AathifMahir/MauiIcons