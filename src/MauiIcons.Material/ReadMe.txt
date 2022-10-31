.NET MAUI Icons

## Initializing

In order to use the .NET MAUI Icons - Material you need to call the extension method in your `MauiProgram.cs` file as follows:

using MauiIcons.Material;

public static MauiApp CreateMauiApp()
{
    var builder = MauiApp.CreateBuilder();

    // Initialise the .Net Maui Icons - Material
	builder.UseMauiApp<App>().UseMaterialMauiIcons();
}

## XAML usage

In order to make use of the .Net Maui Icons - Material within XAML you can use this namespace:

xmlns:material="clr-namespace:MauiIcons.Material;assembly=MauiIcons.Material"

## Further information

For more information please visit:

- Our GitHub repository: https://github.com/AathifMahir/MauiIcons