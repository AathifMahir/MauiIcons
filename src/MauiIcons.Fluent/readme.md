# .Net Maui Icons

.Net Maui Icons - Fluent is a Lightweight Library That Resolves Icons or Font Icon Management on .Net Maui by Providing Controls with Complete Fluent Icon Collection Built into Library.

# Get Started
In order to use the .Net Maui Icons - Fluent you need to call the extension method in your `MauiProgram.cs` file as follows:

```csharp
using MauiIcons.Fluent;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		
		// Initialise the .Net Maui Icons - Fluent
		builder.UseMauiApp<App>().UseFluentMauiIcons();
	}
}
```

### XAML usage

In order to make use of the .Net Maui Icons - Fluent within XAML you can use this namespace:

```xml
xmlns:fluent="clr-namespace:MauiIcons.Fluent;assembly=MauiIcons.Fluent"
```
