# .Net Maui Icons

.Net Maui Icons is a Library that Resolves Icon Management on Maui Apps, Currently It Support Fluent Icons and Material Icons

# Get Started
In order to use the .NET MAUI Icons you need to call the extension method in your `MauiProgram.cs` file as follows:

```csharp
using MauiIcons;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		
		// Initialise the .Net Maui Icons
		builder.UseMauiApp<App>().UseMauiIcons();
	}
}
```

### XAML usage

In order to make use of the toolkit within XAML you can use this namespace:

```xml
xmlns:icon="clr-namespace:MauiIcons"
```
