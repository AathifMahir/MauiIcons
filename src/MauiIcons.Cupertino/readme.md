# .Net Maui Icons

.Net Maui Icons - Cupertino is a Lightweight Icon Library That Resolves Icons or Font Icon Management on .Net Maui by Providing Controls with Complete Open Source Version of FrameWork 7 IOS Icon Collection Built into Library.

# Get Started
In order to use the .Net Maui Icons - Cupertino you need to call the extension method in your `MauiProgram.cs` file as follows:

```csharp
using MauiIcons.Cupertino;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		
		// Initialise the .Net Maui Icons - Cupertino
		builder.UseMauiApp<App>().UseCupertinoMauiIcons();
	}
}
```

### XAML usage

In order to make use of the .Net Maui Icons - Cupertino within XAML you can use this namespace:

```xml
xmlns:cupertino="clr-namespace:MauiIcons.Cupertino;assembly=MauiIcons.Cupertino"

Maui Icons Built in Custom Control Usage:
<cupertino:MauiIcon Icon="Accounts"/>

Image Extension Usage:
<Image Aspect="Center" Source="{cupertino:Icon Icon=Accounts}"/>

```

# License

**MauiIcons.Cupertino**
MauiIcons.Cupertino is Licensed Under [MIT License](https://github.com/AathifMahir/MauiIcons/blob/master/LICENSE).

**Cupertino Icons**
Cupertino Icons is Licensed Under [MIT License](https://github.com/framework7io/framework7-icons/blob/master/LICENSE).

