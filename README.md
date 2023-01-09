<img src="https://github.com/AathifMahir/MauiIcons/blob/89f13e4a26bb9b486048b07f9d67cad12df677c1/images/icon_with_text.png" alt="MauiIcons_logo" height=175 width=815>



# .Net Maui Icons

>.Net Maui Icons - Fluent & Material is a Library to Resolves Icons or Font Icon Management on .Net Maui by Providing Controls with Complete Material Icon Collection Built into Library.

# Packages

Package | Latest stable | Latest Preview | Description
---------|---------------|---------------|------------
`AathifMahir.Maui.MauiIcons.Core` | [![AathifMahir.Maui.MauiIcons.Core](https://img.shields.io/nuget/v/AathifMahir.Maui.MauiIcons.Core)](https://nuget.org/packages/AathifMahir.Maui.MauiIcons.Core/) | [![AathifMahir.Maui.MauiIcons.Core](https://img.shields.io/nuget/vpre/AathifMahir.Maui.MauiIcons.Core)](https://nuget.org/packages/AathifMahir.Maui.MauiIcons.Core/absoluteLatest) | Core Library for Maui Icons
`AathifMahir.Maui.MauiIcons.SegoeFluent` | [![AathifMahir.Maui.MauiIcons.SegoeFluent](https://img.shields.io/nuget/v/AathifMahir.Maui.MauiIcons.SegoeFluent)](https://nuget.org/packages/AathifMahir.Maui.MauiIcons.SegoeFluent/) | [![AathifMahir.Maui.MauiIcons.SegoeFluent](https://img.shields.io/nuget/vpre/AathifMahir.Maui.MauiIcons.SegoeFluent)](https://nuget.org/packages/AathifMahir.Maui.MauiIcons.SegoeFluent/absoluteLatest) | Maui Icons - Segoe Fluent Package Contains Complete Collection of Built in Windows Segoe Fluent Icons.
`AathifMahir.Maui.MauiIcons.Fluent` | [![AathifMahir.Maui.MauiIcons.Fluent](https://img.shields.io/nuget/v/AathifMahir.Maui.MauiIcons.Fluent)](https://nuget.org/packages/AathifMahir.Maui.MauiIcons.Fluent/) | [![AathifMahir.Maui.MauiIcons.Fluent](https://img.shields.io/nuget/vpre/AathifMahir.Maui.MauiIcons.Fluent)](https://nuget.org/packages/AathifMahir.Maui.MauiIcons.Fluent/absoluteLatest) | Maui Icons - Fluent Package Contains Complete Collection of Open Source Version Fluent Icons from Microsoft.
`AathifMahir.Maui.MauiIcons.FluentFilled` | [![AathifMahir.Maui.MauiIcons.FluentFilled](https://img.shields.io/nuget/v/AathifMahir.Maui.MauiIcons.FluentFilled)](https://nuget.org/packages/AathifMahir.Maui.MauiIcons.FluentFilled/) | [![AathifMahir.Maui.MauiIcons.FluentFilled](https://img.shields.io/nuget/vpre/AathifMahir.Maui.MauiIcons.FluentFilled)](https://nuget.org/packages/AathifMahir.Maui.MauiIcons.FluentFilled/absoluteLatest) | Maui Icons - Fluent Filled Package Contains Complete Collection of Open Source Version Fluent Icons from Microsoft.
`AathifMahir.Maui.MauiIcons.Material` | [![AathifMahir.Maui.MauiIcons.Material](https://img.shields.io/nuget/v/AathifMahir.Maui.MauiIcons.Material)](https://nuget.org/packages/AathifMahir.Maui.MauiIcons.Material/) | [![AathifMahir.Maui.MauiIcons.Material](https://img.shields.io/nuget/vpre/AathifMahir.Maui.MauiIcons.Material)](https://nuget.org/packages/AathifMahir.Maui.MauiIcons.Material/absoluteLatest) | Maui Icons - Material Package Contains Complete Collection of Material Icons.


# Get Started
>In order to use the .NET MAUI Icons you need to call the extension method in your `MauiProgram.cs` file as follows:

```csharp
public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		
		// Initialise the .Net Maui Icons - Fluent
		builder.UseMauiApp<App>().UseFluentMauiIcons();
		
		// Initialise the .Net Maui Icons - Material
		builder.UseMauiApp<App>().UseMaterialMauiIcons();
	}
}
```

### XAML usage

>In order to make use of the toolkit within XAML you can use this namespace:

```xml
xmlns:fluent="clr-namespace:MauiIcons.Fluent;assembly=MauiIcons.Fluent"
xmlns:material="clr-namespace:MauiIcons.Material;assembly=MauiIcons.Material"

<!-- Fluent Icon Control -->
<fluent:MauiIcon Icon="Accounts"/>

<!-- Fluent Icon Image Extension -->
<Image Aspect="Center" Source="{fluent:Icon Icon=ActionCenterQuiet}"/>

<!-- Material Icon Control -->
<material:MauiIcon Icon="ABC"/>

<!-- Material Icon Image Extension -->
<Image Aspect="Center" Source="{material:Icon Icon=AddRoad}"/>
```

# License

>**MauiIcons** is Licensed Under [MIT License](https://github.com/AathifMahir/MauiIcons/blob/master/LICENSE).

>**Fluent UI System Icons** is Licensed Under [MIT License](https://github.com/microsoft/fluentui-system-icons/blob/main/LICENSE).

>**Material Design Icons** is Licensed Under [Apache License 2.0](https://github.com/google/material-design-icons/blob/master/LICENSE).

>**Segoe Fluent Icons** is Licensed by Microsoft Under Couple of [License](https://learn.microsoft.com/en-us/typography/font-list/segoe-mdl2-assets).
