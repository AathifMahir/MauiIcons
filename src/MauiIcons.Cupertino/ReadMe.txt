.NET MAUI Icons

Initializing

In order to use the .NET MAUI Icons - Cupertino you need to call the extension method in your `MauiProgram.cs` file as follows:

using MauiIcons.Cupertino;

public static MauiApp CreateMauiApp()
{
    var builder = MauiApp.CreateBuilder();

    // Initialise the .Net Maui Icons - Fluent
	builder.UseMauiApp<App>().UseCupertinoMauiIcons();
}

XAML usage

In order to make use of the .Net Maui Icons - Material within XAML you can use this namespace:

xmlns:cupertino="clr-namespace:MauiIcons.Cupertino;assembly=MauiIcons.Cupertino"

----------------------------------------------------------------------------------------------

Built in Custom Control Usage:

<cupertino:MauiIcon Icon="Accessibility48"/>

----------------------------------------------------------------------------------------------

Image Extension Usage:

<Image Aspect="Center" Source="{cupertino:Icon Icon=AddSquare20}"/>

----------------------------------------------------------------------------------------------

## Further information

For more information please visit:

- Our GitHub repository: https://github.com/AathifMahir/MauiIcons