.NET MAUI Icons

## Initializing

In order to use the .NET MAUI Icons you need to call the extension method in your `MauiProgram.cs` file as follows:

```csharp
using MauiIcons;

public static MauiApp CreateMauiApp()
{
    var builder = MauiApp.CreateBuilder();

    // Initialise the dotnet maui icons
	builder.UseMauiApp<App>().UseMauiIcons();
}
```

## XAML usage

In order to make use of the toolkit within XAML you can use this namespace:

xmlns:icon="clr-namespace:MauiIcons"

## Further information

For more information please visit:

- Our GitHub repository: https://github.com/AathifMahir/MauiIcons