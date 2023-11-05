# .Net Maui Icons

The **.NET MAUI Icons - Cupertino** library serves as a lightweight icon library, addressing icon and font icon management in .NET MAUI by offering controls that utilize the comprehensive open-source version of the Framework 7 iOS Icon Collection, seamlessly integrated into the library.
**[Check out the Repository for Docs](https://github.com/AathifMahir/MauiIcons)**

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

# Usage


In order to make use of the **.Net Maui Icons - Cupertino** you can use the below namespace:

`Xaml`

```xml
xmlns:mi="http://www.aathifmahir.com/dotnet/2022/maui/icons"
```

`C#`
```csharp
using MauiIcons.Cupertino;
```
--------

### Built in Control Usage

`Xaml`
```xml
<mi:MauiIcon Icon="{mi:Cupertino Airplane}"/>
```
`C#`
```csharp
new MauiIcon() {Icon = CupertinoIcons.AppBadge, IconColor = Colors.Green};

new MauiIcon().Icon(CupertinoIcons.AntFill).IconColor(Colors.Purple);
```

All the Properties and Features of Built in Control, **[Check Here](https://github.com/AathifMahir/MauiIcons)**

--------

### Xaml Extension Usage
```xml
<Image Aspect="Center" Source="{mi:Cupertino Icon=ArchiveboxFill}"/>

<Label Text="{mi:Cupertino Icon=Airplane}"/>
```
--------

### C# Markup Usage

```csharp
new ImageButton().Icon(CupertinoIcons.AntFill),

new Image().Icon(CupertinoIcons.AntFill),

new Label().Icon(CupertinoIcons.AntFill).IconSize(40.0).IconColor(Colors.Red),

new Entry().Icon(CupertinoIcons.AntFill).IconSize(20.0).IconColor(Colors.Aqua),
```

**Disclaimer:** It's important to note that not all controls are compatible with C# markup. We have conducted tests with the following controls in the current release: **Label**, **Image**, **ImageButton**, **SearchBar**, **Editor**, and **Entry**. Additionally, the native **MauiIcon** control, when combined with C# markup, can prove to be quite versatile and offer extra features for various scenarios.


# License

**MauiIcons.Cupertino**</br>
The MauiIcons.Cupertino library is distributed under the [MIT License](https://github.com/AathifMahir/MauiIcons/blob/master/LICENSE).

**Cupertino Icons**</br>
The Cupertino Icons library is distributed under the [MIT License](https://github.com/framework7io/framework7-icons/blob/master/LICENSE).

