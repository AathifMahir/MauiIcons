# .Net Maui Icons

.Net Maui Icons - Fluent Filled is a Lightweight Icon Library That Resolves Icons or Font Icon Management on .Net Maui by Providing Controls with Complete Microsoft OpenSource Fluent Icon Collection Built into Library.

# Get Started
In order to use the .NET MAUI Icons - Fluent Filled you need to call the extension method in your `MauiProgram.cs` file as follows:

```csharp
using MauiIcons.FluentFilled;

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
xmlns:fluentFilled="clr-namespace:MauiIcons.FluentFilled;assembly=MauiIcons.FluentFilled"

Maui Icons Built in Custom Control Usage:
<fluentFilled:MauiIcon Icon="Accounts"/>

Image Extension Usage
<Image Aspect="Center" Source="{fluentFilled:Icon Icon=Accounts}"/>

```

# License

**MauiIcons.FluentFilled**
MauiIcons.FluentFilled is Licensed Under [MIT License](https://github.com/AathifMahir/MauiIcons/blob/master/LICENSE).

**Fluent UI System Icons**
Fluent UI System Icons is Licensed Under [MIT License](https://github.com/microsoft/fluentui-system-icons/blob/main/LICENSE).


