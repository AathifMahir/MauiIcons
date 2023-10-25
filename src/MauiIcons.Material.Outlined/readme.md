# .Net Maui Icons

.Net Maui Icons - Material Outlined is a Lightweight Library That Resolves Icons or Font Icon Management on .Net Maui by Providing Controls with Complete Material Icon Collection Built into Library.

# Get Started
In order to use the .NET MAUI Icons - Material Outlined you need to call the extension method in your `MauiProgram.cs` file as follows:

```csharp
using MauiIcons.Material.Outlined;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		
		// Initialise the .Net Maui Icons - Material Outlined
		builder.UseMauiApp<App>().UseMaterialOutlinedIcons();
	}
}
```

### XAML usage

In order to make use of the .Net Maui Icons - Material within XAML you can use this namespace:

```xml
xmlns:mi="http://www.aathifmahir.com/dotnet/2022/maui/icons"

Maui Icons Built in Custom Control Usage:
<mi:MauiIcon Icon="{mi:MaterialOutlined Icon=Accounts}"/>

Image Extension Usage
<Image Aspect="Center" Source="{mi:MaterialOutlined Icon=Accounts}"/>

```

# License

**MauiIcons.Material.Outlined**
MauiIcons.Material.Outlined is Licensed Under [MIT License](https://github.com/AathifMahir/MauiIcons/blob/master/LICENSE).

**Material Design Icons**
Material Design Icons is Licensed Under [Apache License 2.0](https://github.com/google/material-design-icons/blob/master/LICENSE).


