# .Net Maui Icons

The **.NET MAUI Icons - Phosphor** library serves as a lightweight icon library, addressing icon and font icon management in .NET MAUI by offering controls that utilize the comprehensive open-source version of the Phosphor Icon Collection, seamlessly integrated into the library.
**[Check out the Repository for Docs](https://github.com/AathifMahir/MauiIcons)**

# Get Started
In order to use the .NET MAUI Icons - Material you need to call the extension method in your `MauiProgram.cs` file as follows:

```csharp
using MauiIcons.Material.Sharp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		
		// Initialise the .Net Maui Icons - Phosphor
		builder.UseMauiApp<App>().UsePhosphorMauiIcons();
	}
}
```

# Table of Contents

- [Usage](#usage)
- [Advanced Settings](#advanced-settings)
- [New Changes in v4](#new-changes-in-v4)
- [Workaround (Must Read)](#workaround)
- [Built in Control Usage](#built-in-control-usage)
- [Xaml Extension Usage](#xaml-extension-usage)
- [C# Markup Usage](#c-markup-usage)
- [Applying Icon To Text or Placeholder](#applying-icon-to-text-or-placeholder)
- [OnPlatform and OnIdiom Usage](#onplatform-and-onidiom-usage)
- [Breaking Changes](#breaking-changes)
	- [Version 3 to 4](#version-3-to-4)
	- [Version 2 to 3](#version-2-to-3)
	- [Version 1 to 2](#version-1-to-2)
- [Advanced Usage](#advanced-usage)
- [License](#license)
- [Contribute](#contribute)


# Usage


In order to make use of the **.Net Maui Icons - Phosphor** you can use the below namespace:

`Xaml`

```xml
xmlns:pi="http://www.aathifmahir.com/dotnet/2022/maui/icons"
```

`C#`
```csharp
using MauiIcons.Phosphor;
```

# Advanced Settings

You can set the default icon size, font override, and default font auto-scaling using the `UseMauiIconsCore` builder extension as follows:

```csharp
builder.UseMauiIconsCore(x => 
{
	x.SetDefaultIconSize(30.0);
	x.SetDefaultFontOverride(true);
	x.SetDefaultFontAutoScaling(true);
})
```

## Workaround

if you came across this issue dotnet/maui#7503 when using new namespace, Make sure to create an discarded instance of MauiIcon in the codebehind like below

```csharp

    public MainPage()
    {
        InitializeComponent();
        // Temporary Workaround for url styled namespace in xaml
        _ = new MauiIcon();
    }

```


## Built in Control Usage

`Xaml`
```xml
<pi:MauiIcon Icon="{pi:Phosphor Airplane}"/>
```
`C#`
```csharp
new MauiIcon() {Icon = PhosphorIcons.Airplane, IconColor = Colors.Green};

new MauiIcon().Icon(PhosphorIcons.Alarm).IconColor(Colors.Purple);
```

All the Properties and Features of Built in Control, **[Check Here](https://github.com/AathifMahir/MauiIcons)**


## Xaml Extension Usage
```xml
<Image Aspect="Center" pi.MauiIcon.Value="{pi:Phosphor Icon=Airplane}"/>

<Button pi.MauiIcon.Value="{pi:Phosphor Icon=Alarm}"/>

<ImageButton pi.MauiIcon.Value="{pi:Phosphor Icon=Alarm}"/>
```

## C# Markup Usage

```csharp
new ImageButton().Icon(PhosphorIcons.Airplane),

new Image().Icon(PhosphorIcons.Alarm),

new Button().Icon(PhosphorIcons.AddRoad).IconSize(40.0).IconColor(Colors.Red)
```

**Disclaimer:** It's important to note that not all controls are compatible with C# markup. We have conducted tests with the following controls in the current release: **Label**, **Image**, **ImageButton**, **SearchBar**, **Editor**, and **Entry**. Additionally, the native **MauiIcon** control, when combined with C# markup, can prove to be quite versatile and offer extra features for various scenarios.

## Applying Icon To Text or Placeholder
Controls that Supports Placeholder, Can Assign the Icon To PlaceHolder or Text, 
Defaults to Placeholder but can be set to Text by Setting TargetName Parameter to `Text`

`xaml`
```xml
<Entry pi:MauiIcon.Value="{pi:Phosphor Icon=Airplane, TargetName='Text'}"/>

<SearchBar pi:MauiIcon.Value="{pi:Phosphor Icon=Alarm, TargetName='Placeholder'}"/>
```

`C#`
```csharp
new Entry().Icon(PhosphorIcons.Alarm, isPlaceHolder: false).IconSize(20.0).IconColor(Colors.Aqua);

new SearchBar().Icon(PhosphorIcons.Airplane, isPlaceHolder: false);
```

**Disclaimer:** It's important to note that not all controls are compatible with C# markup. We have conducted tests with the following controls in the current release: **Label**, **Image**, **ImageButton**, **SearchBar**, **Editor**, and **Entry**. Additionally, the native **MauiIcon** control, when combined with C# markup, can prove to be quite versatile and offer extra features for various scenarios.

## OnPlatform and OnIdiom Usage
`Xaml`

```xml
<mi:MauiIcon Icon="{pi:Phosphor Airplane}" OnPlatforms="WinUI, Android, MacCatalyst"/>
<mi:MauiIcon Icon="{pi:Phosphor Alarm}" OnIdioms="Desktop, Phone, Tablet"/>
<mi:MauiIcon Icon="{pi:Phosphor Airplane}" OnPlatforms="Android" OnIdioms="Phone"/>
```

`C#`
```csharp
new MauiIcon().Icon(PhosphorIcons.Airplane).OnPlatforms(new List<string>{"WinUI", "Android"});
new MauiIcon().Icon(PhosphorIcons.Alarm).OnIdioms(new List<string>{"Desktop", "Phone"});
new MauiIcon().Icon(PhosphorIcons.Airplane).OnPlatforms(new List<string>{"WinUI", "Android"}).OnIdioms(new List<string>{"Desktop", "Phone"});
```

## Advanced Usage

The **.Net Maui Icons** library offers a wide range of features and capabilities, including the ability to customize how icons applied and which property it is applied too and etc. For more information on advanced usage, please refer to the [**Advanced Usage**](https://github.com/AathifMahir/MauiIcons/#advanced-usage)

# License

**MauiIcons.Phosphor**  
MauiIcons.Phosphor is Licensed Under [MIT License](https://github.com/AathifMahir/MauiIcons/blob/master/LICENSE).

**Material Design Icons**
Phosphor Icons is Licensed Under [MIT License](https://github.com/phosphor-icons/homepage/blob/master/LICENSE).

# Contribute

If you wish to contribute to this project, please don't hesitate to create an [issue or request](https://github.com/AathifMahir/MauiIcons/issues). Your input and feedback are highly appreciated. Additionally, if you're interested in supporting the project by providing resources or [**becoming a sponsor**](https://github.com/sponsors/AathifMahir), your contributions would be welcomed and instrumental in its continued development and success. Thank you for your interest in contributing to this endeavor.


