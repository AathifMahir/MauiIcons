# .Net Maui Icons

.Net Maui Icons - Segoe Fluent is a Lightweight Windows Default Icon Library That Resolves Icons or Font Icon Management on .Net Maui by Providing Controls with Complete Segoe Fluent Icon Collection Built into Library.

# Get Started
In order to use the .Net Maui Icons - Fluent you need to call the extension method in your `MauiProgram.cs` file as follows:

```csharp
using MauiIcons.SegoeFluent;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		
		// Initialise the .Net Maui Icons - Fluent
		builder.UseMauiApp<App>().UseSegoeFluentMauiIcons();
	}
}
```

### XAML usage

In order to make use of the .Net Maui Icons - Fluent within XAML you can use this namespace:

```xml
xmlns:segoeFluent="clr-namespace:MauiIcons.SegoeFluent;assembly=MauiIcons.SegoeFluent"

Maui Icons Built in Custom Control Usage:
<segoeFluent:MauiIcon Icon="Accounts"/>

Image Extension Usage:
<Image Aspect="Center" Source="{segoeFluent:Icon Icon=Accounts}"/>

```

# License

**MauiIcons.SegoeFluent**
MauiIcons.SegoeFluent is Licensed Under [MIT License](https://github.com/AathifMahir/MauiIcons/blob/master/LICENSE).

**Segoe Fluent Icons**
Segoe FLuent Icons is Licensed by Microsoft Under Couple of [License](https://learn.microsoft.com/en-us/typography/font-list/segoe-mdl2-assets).


