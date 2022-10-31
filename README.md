# .Net Maui Icons

.Net Maui Icons - Fluent & Material is a Library to Resoves Icons or Font Icon Management on .Net Maui by Providing Controls with Complete Material Icon Collection Built into Library.

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
