# .Net Maui Icons

The **.NET MAUI Icons - Fluent** library serves as a lightweight icon library, addressing icon and font icon management in .NET MAUI by offering controls that utilize the comprehensive open-source version of the Fluent Icon Collection, seamlessly integrated into the library.
**[Check out the Repository for Docs](https://github.com/AathifMahir/MauiIcons)**

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

# Usage


In order to make use of the **.Net Maui Icons - Fluent** you can use the below namespace:

`Xaml`

```xml
xmlns:mi="http://www.aathifmahir.com/dotnet/2022/maui/icons"
```

`C#`
```csharp
using MauiIcons.Fluent;
```
--------

### Built in Control Usage

`Xaml`
```xml
<mi:MauiIcon Icon="{mi:Fluent Accounts}"/>
```
`C#`
```csharp
new MauiIcon() {Icon = FluentIcons.Airplane20, IconColor = Colors.Green};

new MauiIcon().Icon(FluentIcons.Accounts).IconColor(Colors.Purple);
```

All the Properties and Features of Built in Control, **[Check Here](https://github.com/AathifMahir/MauiIcons)**

--------

### Xaml Extension Usage
```xml
<Image Aspect="Center" Source="{mi:Fluent Icon=Accounts}"/>

<Label Text="{mi:Fluent Icon=Airplane20}"/>
```
--------

### C# Markup Usage

```csharp
new ImageButton().Icon(FluentIcons.Airplane20),

new Image().Icon(FluentIcons.Accounts),

new Label().Icon(FluentIcons.Airplane20).IconSize(40.0).IconColor(Colors.Red),

new Entry().Icon(FluentIcons.Accounts).IconSize(20.0).IconColor(Colors.Aqua),
```

**Disclaimer:** It's important to note that not all controls are compatible with C# markup. We have conducted tests with the following controls in the current release: **Label**, **Image**, **ImageButton**, **SearchBar**, **Editor**, and **Entry**. Additionally, the native **MauiIcon** control, when combined with C# markup, can prove to be quite versatile and offer extra features for various scenarios.


# License

**MauiIcons.Fluent**<br>
The MauiIcons.Fluent is library is distributed under the [MIT License](https://github.com/AathifMahir/MauiIcons/blob/master/LICENSE).

**Fluent UI System Icons**<br>
The Fluent UI System Icons library is distributed under the [MIT License](https://github.com/microsoft/fluentui-system-icons/blob/main/LICENSE).

