# .Net Maui Icons

The **.NET MAUI Icons - Font Awesome** library serves as a lightweight icon library, addressing icon and font icon management in .NET MAUI by offering controls that utilize the Free and Open Source Version of FontAwesome 6 Icons, seamlessly integrated into the library.
**[Check out the Repository for Docs](https://github.com/AathifMahir/MauiIcons)**

# Get Started
In order to use the .Net Maui Icons - Font Awesome you need to call the extension method in your `MauiProgram.cs` file as follows:

```csharp
using MauiIcons.FontAwesome;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		
		// Initialise the .Net Maui Icons - FontAwesome
		builder.UseMauiApp<App>().UseFontAwesomeMauiIcons();
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


In order to make use of the **.Net Maui Icons - Font Awesome** you can use the below namespace:

`Xaml`

```xml
xmlns:mi="http://www.aathifmahir.com/dotnet/2022/maui/icons"
```

`C#`
```csharp
using MauiIcons.FontAwesome;
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
<mi:MauiIcon Icon="{mi:FontAwesome Hashtag}"/>
```
`C#`
```csharp
new MauiIcon() {Icon = FontAwesomeIcons.Hashtag, IconColor = Colors.Green};

new MauiIcon().Icon(FontAwesomeIcons.Asterisk).IconColor(Colors.Purple);
```

All the Properties and Features of Built in Control, **[Check Here](https://github.com/AathifMahir/MauiIcons)**


## Xaml Extension Usage
```xml
<Image Aspect="Center" mi.MauiIcon.Value="{mi:FontAwesome Icon=Asterisk}"/>

<Button mi.MauiIcon.Value="{mi:FontAwesome Icon=Hashtag}"/>

<ImageButton mi.MauiIcon.Value="{mi:FontAwesome Icon=Hashtag}"/>
```

## C# Markup Usage

```csharp
new ImageButton().Icon(FontAwesomeIcons.Asterisk),

new Image().Icon(FontAwesomeIcons.Hashtag),

new Button().Icon(FontAwesomeIcons.GreaterThan).IconSize(40.0).IconColor(Colors.Red)
```

**Disclaimer:** It's important to note that not all controls are compatible with C# markup. We have conducted tests with the following controls in the current release: **Label**, **Image**, **ImageButton**, **SearchBar**, **Editor**, and **Entry**. Additionally, the native **MauiIcon** control, when combined with C# markup, can prove to be quite versatile and offer extra features for various scenarios.

## Applying Icon To Text or Placeholder
Controls that Supports Placeholder, Can Assign the Icon To PlaceHolder or Text, 
Defaults to Placeholder but can be set to Text by Setting TargetName Parameter to `Text`

`xaml`
```xml
<Entry mi:MauiIcon.Value="{mi:FontAwesome Icon=Hashtag, TargetName='Text'}"/>

<SearchBar mi:MauiIcon.Value="{mi:FontAwesome Icon=PenToSquare, TargetName='Placeholder'}"/>
```

```csharp
new Entry().Icon(FontAwesomeIcons.Star, isPlaceHolder: false).IconSize(20.0).IconColor(Colors.Aqua);

new SearchBar().Icon(FontAwesomeIcons.PenToSquare, isPlaceHolder: false);
```

**Disclaimer:** It's important to note that not all controls are compatible with C# markup. We have conducted tests with the following controls in the current release: **Label**, **Image**, **ImageButton**, **SearchBar**, **Editor**, and **Entry**. Additionally, the native **MauiIcon** control, when combined with C# markup, can prove to be quite versatile and offer extra features for various scenarios.

## OnPlatform and OnIdiom Usage
`Xaml`

```xml
<mi:MauiIcon Icon="{mi:FontAwesome Star}" OnPlatforms="WinUI, Android, MacCatalyst"/>
<mi:MauiIcon Icon="{mi:FontAwesome PenToSquare}" OnIdioms="Desktop, Phone, Tablet"/>
<mi:MauiIcon Icon="{mi:FontAwesome Asterisk}" OnPlatforms="Android" OnIdioms="Phone"/>
```

`C#`
```csharp
new MauiIcon().Icon(FontAwesomeIcons.GreaterThan).OnPlatforms(new List<string>{"WinUI", "Android"});
new MauiIcon().Icon(FontAwesomeIcons.Asterisk).OnIdioms(new List<string>{"Desktop", "Phone"});
new MauiIcon().Icon(FontAwesomeIcons.PenToSquare).OnPlatforms(new List<string>{"WinUI", "Android"}).OnIdioms(new List<string>{"Desktop", "Phone"});
```

## Breaking Changes

### Version 3 to 4

  - Icon won't be applied to the Controls like Entry, SearchBar and etc.. by default Instead v4 would throw an Exception, Need to set **FontOverride** to true to apply the Icon to these Controls on Builder Extension Level or Control Level
	- This Behavior can be reverted to Behavior of v3 by Using new `UseMauiIconsCore` Builder Extension and using `SetDefaultFontOverride` Method like Below

```csharp
	builder.UseMauiIconsCore(x => 
	{
		x.SetDefaultFontOverride(true);
	})
```

  - Icon Size is Now Set to Control's FontSize by Default, Previously it was set to **30.0** by Default
	- This Behavior can be reverted to Behavior of v3 by Using new `UseMauiIconsCore` Builder Extension and using `SetDefaultIconSize` Method like Below
```csharp
	builder.UseMauiIconsCore(x => 
	{
		x.SetDefaultIconSize(30.0);
	})
```
---

### Version 2 to 3

  - Removal of **TypeArgument** and Built in OnPlatform and OnIdiom Support, Use MauiIcons Integrated [Custom OnPlatform and OnIdioms Feature](#custom-onplatform-and-onidiom-usage)
  - Removal of **Dotnet 7** Support

## New Changes in v4

  1. We have a new way of Assigning/Setting Icons, Introducing New Attached Property for Icons,
	 The new **AttachedProperty** Brings in Support for **Triggers**, **Behaviors**, **Styles**, etc.. which is lacking on Classic Xaml Markup Extension, and also it's more cleaner and readable
```xml
/// Old
<Image Aspect="Center" Source="{mi:FontAwesome Icon=PenToSquare}"/>

// New
<Image Aspect="Center" mi.MauiIcon.Value="{mi:FontAwesome Icon=PenToSquare}"/>
```

**Disclaimer**: The Old Xaml Markup Extension is still Supported and can be used, but it's recommended to use the new Attached Property for better support and readability and we have plans to deprecate the old Xaml Markup Extension in the future in favor of Attached Property

### Example of Using Styles
```xml
<Style x:Key="ButtonStyle" TargetType="Button">
       <Setter Property="mi:MauiIcon.Value" Value="{mi:FontAwesome Icon=PenToSquare}" />
</Style>

<Button Style="{StaticResource ButtonStyle}"/>
```

  2. Introducing New `UseMauiIconsCore` Builder Extension for Setting Default Icon Size, Font Override, Default Font Auto Scaling and etc..
  3. Improved Built in OnPlatforms and OnIdioms with Binding Improvements and Enhanced Performance
  4. New [`OnClickAnimation`](https://github.com/AathifMahir/MauiIcons/#animation-usage) Support for MauiIcon Control


## Advanced Usage

The **.Net Maui Icons** library offers a wide range of features and capabilities, including the ability to customize how icons applied and which property it is applied too and etc. For more information on advanced usage, please refer to the [**Advanced Usage**](https://github.com/AathifMahir/MauiIcons/#advanced-usage)


# License

**MauiIcons.FontAwesome**  
MauiIcons.FontAwesome is Licensed Under [MIT License](https://github.com/AathifMahir/MauiIcons/blob/master/LICENSE).

**Font Awesome Free Icons**  
Font Awesome Free Icons is Licensed by FontAwesome Under Couple of [License](https://fontawesome.com/license/free).

# Contribute

If you wish to contribute to this project, please don't hesitate to create an [issue or request](https://github.com/AathifMahir/MauiIcons/issues). Your input and feedback are highly appreciated. Additionally, if you're interested in supporting the project by providing resources or [**becoming a sponsor**](https://github.com/sponsors/AathifMahir), your contributions would be welcomed and instrumental in its continued development and success. Thank you for your interest in contributing to this endeavor.



