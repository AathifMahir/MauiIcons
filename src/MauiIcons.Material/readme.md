# .Net Maui Icons

.Net Maui Icons - Material is a Lightweight Library That Resolves Icons or Font Icon Management on .Net Maui by Providing Controls with Complete Material Icon Collection Built into Library.

# Get Started
In order to use the .NET MAUI Icons - Material you need to call the extension method in your `MauiProgram.cs` file as follows:

```csharp
using MauiIcons.Material;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		
		// Initialise the .Net Maui Icons - Material
		builder.UseMauiApp<App>().UseMaterialMauiIcons();
	}
}
```

### XAML usage

In order to make use of the .Net Maui Icons - Material within XAML you can use this namespace:

```xml
xmlns:material="clr-namespace:MauiIcons.Material;assembly=MauiIcons.Material"
```
