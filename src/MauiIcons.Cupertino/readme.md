# .Net Maui Icons

The **.NET MAUI Icons - Cupertino** library serves as a lightweight icon library, addressing icon and font icon management in .NET MAUI by offering controls that utilize the comprehensive open-source version of the Framework 7 iOS Icon Collection, seamlessly integrated into the library.
**[Readmore](https://github.com/AathifMahir/MauiIcons)**

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

XAML usage

In order to make use of the .Net Maui Icons - Material within XAML you can use this namespace:

```xml
xmlns:mi="http://www.aathifmahir.com/dotnet/2022/maui/icons"
```
----------------------------------------------------------------------------------------------

Built in Control Usage:

Xaml
```xml
<mi:MauiIcon Icon="{mi:Cupertino Airplane}"/>
```
C#
```csharp
new MauiIcon().Icon(CupertinoIcons.AntFill).IconColor(Colors.Purple);
```

All the Properties and Features of Built in Control, **[Check Here](https://github.com/AathifMahir/MauiIcons)**

----------------------------------------------------------------------------------------------

Xaml Extension Usage:
```xml
<Image Aspect="Center" Source="{mi:Cupertino Icon=ArchiveboxFill}"/>
<Label Text="{mi:Cupertino Icon=Airplane}"/>
```
----------------------------------------------------------------------------------------------

C# Markup Usage:

```csharp
new ImageButton().Icon(CupertinoIcons.AntFill),

new Image().Icon(CupertinoIcons.AntFill),

new Label().Icon(CupertinoIcons.AntFill).IconSize(40.0).IconColor(Colors.Red),

new Entry().Icon(CupertinoIcons.AntFill).IconSize(20.0).IconColor(Colors.Aqua),
```

**Disclaimer:** Not all controls support C# markup. We have tested **Label**, **Image**, **ImageButton**, and **Entry** controls with the current release. Of course, the built-in **MauiIcon** control with C# markup can be used in various scenarios.

----------------------------------------------------------------------------------------------
# License

**MauiIcons.Cupertino**
MauiIcons.Cupertino is Licensed Under [MIT License](https://github.com/AathifMahir/MauiIcons/blob/master/LICENSE).

**Cupertino Icons**
Cupertino Icons is Licensed Under [MIT License](https://github.com/framework7io/framework7-icons/blob/master/LICENSE).

