# .Net Maui Icons

.Net Maui Icons - Fluent Filled is a Lightweight Icon Library That Resolves Icons or Font Icon Management on .Net Maui by Providing Controls with Complete Microsoft OpenSource Fluent Icon Collection Built into Library.

# Get Started
In order to use the .NET MAUI Icons - Fluent Filled you need to call the extension method in your `MauiProgram.cs` file as follows:

```csharp
using MauiIcons.Fluent.Filled;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		
		// Initialise the .Net Maui Icons - Fluent Filled
		builder.UseMauiApp<App>().UseFluentFilledMauiIcons();
	}
}
```

### XAML usage

In order to make use of the .Net Maui Icons - Fluent Filled within XAML you can use this namespace:

```xml
xmlns:fluentFilled="clr-namespace:MauiIcons.Fluent.Filled;assembly=MauiIcons.Fluent.Filled"

Maui Icons Built in Custom Control Usage:
<fluentFilled:MauiIcon Icon="Accounts"/>

Image Extension Usage
<Image Aspect="Center" Source="{fluentFilled:Icon Icon=Accounts}"/>

```

# License

**MauiIcons.Fluent.Filled**
MauiIcons.Fluent.Filled is Licensed Under [MIT License](https://github.com/AathifMahir/MauiIcons/blob/master/LICENSE).

**Fluent UI System Icons**
Fluent UI System Icons is Licensed Under [MIT License](https://github.com/microsoft/fluentui-system-icons/blob/main/LICENSE).


