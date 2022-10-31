.NET MAUI Icons

## Initializing

In order to use the .NET MAUI Icons - Fluent you need to call the extension method in your `MauiProgram.cs` file as follows:

using MauiIcons.Fluent;

public static MauiApp CreateMauiApp()
{
    var builder = MauiApp.CreateBuilder();

    // Initialise the .Net Maui Icons - Fluent
	builder.UseMauiApp<App>().UseFluentMauiIcons();
}

## XAML usage

In order to make use of the .Net Maui Icons - Material within XAML you can use this namespace:

xmlns:fluent="clr-namespace:MauiIcons.Fluent;assembly=MauiIcons.Fluent"

## Further information

For more information please visit:

- Our GitHub repository: https://github.com/AathifMahir/MauiIcons