# .Net Maui Icons

.Net Maui Icons - Fluent & Material is a Library to Resoves Icons or Font Icon Management on .Net Maui by Providing Controls with Complete Material Icon Collection Built into Library.

# Packages

Package | Latest stable | Latest Preview | Description
---------|---------------|---------------|------------
`AathifMahir.Maui.MauiIcons.Core` | [![AathifMahir.Maui.MauiIcons.Core](https://img.shields.io/nuget/v/AathifMahir.Maui.MauiIcons.Core)](https://nuget.org/packages/AathifMahir.Maui.MauiIcons.Core/) | [![AathifMahir.Maui.MauiIcons.Core](https://img.shields.io/nuget/vpre/AathifMahir.Maui.MauiIcons.Core)](https://nuget.org/packages/AathifMahir.Maui.MauiIcons.Core/absoluteLatest) | Core Library for Maui Icons
`AathifMahir.Maui.MauiIcons.Fluent` | [![AathifMahir.Maui.MauiIcons.Fluent](https://img.shields.io/nuget/v/AathifMahir.Maui.MauiIcons.Fluent)](https://nuget.org/packages/AathifMahir.Maui.MauiIcons.Fluent/) | [![AathifMahir.Maui.MauiIcons.Fluent](https://img.shields.io/nuget/vpre/AathifMahir.Maui.MauiIcons.Fluent)](https://nuget.org/packages/AathifMahir.Maui.MauiIcons.Fluent/absoluteLatest) | Maui Icons - Fluent Package Contains Complete Collection of Segoe UI FLuent Icons.
`AathifMahir.Maui.MauiIcons.Material` | [![AathifMahir.Maui.MauiIcons.Material](https://img.shields.io/nuget/v/AathifMahir.Maui.MauiIcons.Material)](https://nuget.org/packages/AathifMahir.Maui.MauiIcons.Material/) | [![AathifMahir.Maui.MauiIcons.Material](https://img.shields.io/nuget/vpre/AathifMahir.Maui.MauiIcons.Material)](https://nuget.org/packages/AathifMahir.Maui.MauiIcons.Material/absoluteLatest) | Maui Icons - Material Package Contains Complete Collection of Material Icons.


# Get Started
In order to use the .NET MAUI Icons you need to call the extension method in your `MauiProgram.cs` file as follows:

```csharp
public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		
		// Initialise the .Net Maui Icons - Fluent
		builder.UseMauiApp<App>().UseFluentMauiIcons();
		
		// Initialise the .Net Maui Icons - Material
		builder.UseMauiApp<App>().UseMaterialMauiIcons();
	}
}
```

### XAML usage

In order to make use of the toolkit within XAML you can use this namespace:

```xml
xmlns:fluent="clr-namespace:MauiIcons.Fluent;assembly=MauiIcons.Fluent"
xmlns:material="clr-namespace:MauiIcons.Material;assembly=MauiIcons.Material"
```
