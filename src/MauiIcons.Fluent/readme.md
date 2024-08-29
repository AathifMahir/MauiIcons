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
<mi:MauiIcon Value="{mi:Fluent AppFolder48}"/>
```
`C#`
```csharp
new MauiIcon() {Value = Fluent.AppFolder48, IconColor = Colors.Green};

new MauiIcon().Icon(FluentIcons.Accessibility48).IconColor(Colors.Purple);
```

All the Properties and Features of Built in Control, **[Check Here](https://github.com/AathifMahir/MauiIcons)**


## Xaml Extension Usage
```xml
<Image Aspect="Center" mi.MauiIcon.Icon="{mi:Fluent Icon=Accessibility48}"/>

<Label mi.MauiIcon.Icon="{mi:Fluent Icon=AppFolder48}"/>
```


## C# Markup Usage

```csharp
new ImageButton().Icon(FluentIcons.AppFolder48),

new Image().Icon(FluentIcons.Accessibility48),

new Label().Icon(FluentIcons.AppFolder48).IconSize(40.0).IconColor(Colors.Red),

new Entry().Icon(FluentIcons.Accessibility48).IconSize(20.0).IconColor(Colors.Aqua),
```

**Disclaimer:** It's important to note that not all controls are compatible with C# markup. We have conducted tests with the following controls in the current release: **Label**, **Image**, **ImageButton**, **SearchBar**, **Editor**, and **Entry**. Additionally, the native **MauiIcon** control, when combined with C# markup, can prove to be quite versatile and offer extra features for various scenarios.

## Applying Icon To Text or Placeholder
Controls that Supports Placeholder, Can Assign the Icon To PlaceHolder or Text, 
Defaults to Placeholder but can be set to Text by Setting TargetName Parameter to `Text`

```csharp
new Entry().Icon(FluentIcons.Accessibility48, targetName: "Text").IconSize(20.0).IconColor(Colors.Aqua);

new SearchBar().Icon(FluentIcons.AppFolder48, targetName: "Placeholder");
```

**Disclaimer:** It's important to note that we are Overriding Font on Input Control to Set the Icon that Could Cause Unexpected Behaviors and Rendering Issues as well.

## Custom OnPlatform and OnIdiom Usage
`Xaml`

```xml
<mi:MauiIcon Value="{mi:Fluent AppFolder48}" OnPlatforms="WinUI, Android, MacCatalyst"/>
<mi:MauiIcon Value="{mi:Fluent Accessibility48}" OnIdioms="Desktop, Phone, Tablet"/>
<mi:MauiIcon Value="{mi:Fluent AppFolder48}" OnPlatforms="Android" OnIdioms="Phone"/>
```

`C#`
```csharp
new MauiIcon().Icon(FluentIcons.AppFolder48).OnPlatforms(new List<string>{"WinUI", "Android"});
new MauiIcon().Icon(FluentIcons.Accessibility48).OnIdioms(new List<string>{"Desktop", "Phone"});
new MauiIcon().Icon(FluentIcons.AppFolder48).OnPlatforms(new List<string>{"WinUI", "Android"}).OnIdioms(new List<string>{"Desktop", "Phone"});
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

 - Setting Icons into `IconProperty` Using Vanilla C# is no longer Supported, Instead Need to Set the Icon to `ValueProperty`, Like Below Example
	
`C#`
```csharp
        // old (v3)
        new MauiIcon() { Icon = FluentIcons.AppFolder48 };

        // new (v4)
        new MauiIcon() { Value = FluentIcons.AppFolder48 };
```
`Xaml`
```xml
	<!-- old (v3) -->
	<mi:MauiIcon Icon="{mi:Fluent AppFolder48}"/>
	
	<!-- new (v4) -->
	<mi:MauiIcon Value="{mi:Fluent AppFolder48}"/>
```

**Disclaimer**: The Old `IconProperty` is still Supported and can be used in Xaml not C#, but it's recommended to use the new `ValueProperty` Since it could be cause of a Performance Penanlty


### Version 2 to 3

  - Removal of **TypeArgument** and Built in OnPlatform and OnIdiom Support, Use MauiIcons Integrated [Custom OnPlatform and OnIdioms Feature](#custom-onplatform-and-onidiom-usage)
  - Removal of **Dotnet 7** Support

### Version 1 to 2

`Old (v1)`

```xml
xmlns:fluent="clr-namespace:MauiIcons.Fluent;assembly=MauiIcons.Fluent"

<fluent:MauiIcon Icon="AppFolder48"/>
```

`New (v2)`

```xml
xmlns:mi="http://www.aathifmahir.com/dotnet/2022/maui/icons"

<mi:MauiIcon Icon="{mi:Fluent AppFolder48}"/>
```

## New Changes in v4

  1. We have a new way of Assigning/Setting Icons, Introducing New Attached Property for Icons,
	 The new **AttachedProperty** Brings in Support for **Triggers**, **Behaviors**, **Styles**, etc.. which is lacking on Classic Xaml Markup Extension, and also it's more cleaner and readable
```xml
/// Old
<Image Aspect="Center" Source="{mi:Fluent Icon=Accessibility48}"/>

// New
<Image Aspect="Center" mi.MauiIcon.Icon="{mi:Fluent Icon=Accessibility48}"/>
```

**Disclaimer**: The Old Xaml Markup Extension is still Supported and can be used, but it's recommended to use the new Attached Property for better support and readability and we have plans to depreciate the old Xaml Markup Extension in the future in favor of Attached Property

### Example of Using Styles
```xml
<Style x:Key="ButtonStyle" TargetType="Button">
       <Setter Property="mi:MauiIcon.Icon" Value="{mi:Fluent Icon=AppFolder48}" />
</Style>

<Button Style="{StaticResource ButtonStyle}"/>
```

  2. Introducing New `UseMauiIconsCore` Builder Extension for Setting Default Icon Size, Font Override, Default Font Auto Scaling and etc..
  3. Improved Built in OnPlatforms and OnIdioms with Binding Improvements and Enhanced Performance
  4. New `OnClickAnimation` Support for MauiIcon Control


## Advanced Usage

- If you came across Situation where the Controls Does Have Multiple Source to Apply Icons, You want the Icon you Set on Attached Property to Apply to All the Sources, You can do that as well, Set the TargetName to `.`, This will Apply the Icon to All the Sources
```xml
<Tab mi:MauiIcon.Icon="{mi:Fluent Icon=Home32, TargetName='.'}">
            <ShellContent
                Title="Xaml"
                ContentTemplate="{DataTemplate local:MainPage}"
                Route="MainPage" />
</Tab>
```
- If you came across Situation Where you want to Apply the Icon to Different Source over Default Source that Set by MauiIcons, You can do that as well, Set the TargetName to Source Property Name, This will Apply the Icon to that Specific Source
```xml
<Tab mi:MauiIcon.Icon="{mi:Fluent Icon=Home32, TargetName='FlyoutIcon'}">
            <ShellContent
                Title="Xaml"
                ContentTemplate="{DataTemplate local:MainPage}"
                Route="MainPage" />
</Tab>
```
- If you came across Situation where the Controls Does Have Multiple Source to Apply Icons, You want different icon for those Additional Sources, You can do that by Applying the Icon Directly to Source Using Xaml Markup like Below Example
```xml
<Tab mi:MauiIcon.Icon="{mi:Fluent Icon=Home32}" FlyoutIcon="{mi:Fluent Icon=Accessibility48}">
            <ShellContent
                Title="Xaml"
                ContentTemplate="{DataTemplate local:MainPage}"
                Route="MainPage" />
</Tab>
```

Overall TargetName Behaves like a Source Property Name, If you want to Apply the Icon to Specific Source, Set the TargetName to Source Property Name, If you want to Apply the Icon to All the Sources, Set the TargetName to `.`
# License

**MauiIcons.Fluent**  
The MauiIcons.Fluent is library is distributed under the [MIT License](https://github.com/AathifMahir/MauiIcons/blob/master/LICENSE).

**Fluent UI System Icons**   
The Fluent UI System Icons library is distributed under the [MIT License](https://github.com/microsoft/fluentui-system-icons/blob/main/LICENSE).

