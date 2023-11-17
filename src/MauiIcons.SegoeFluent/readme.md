# .Net Maui Icons

The **.NET MAUI Icons - Segoe Fluent** library serves as a lightweight icon library, addressing icon and font icon management in .NET MAUI by offering controls that utilize the Windows version of the Segoe Fluent Icon Collection, seamlessly integrated into the library.
**[Check out the Repository for Docs](https://github.com/AathifMahir/MauiIcons)**

# Get Started
In order to use the .Net Maui Icons - Segoe Fluent you need to call the extension method in your `MauiProgram.cs` file as follows:

```csharp
using MauiIcons.SegoeFluent;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		
		// Initialise the .Net Maui Icons - Fluent
		builder.UseMauiApp<App>().UseSegoeFluentMauiIcons();
	}
}
```

# Usage


In order to make use of the **.Net Maui Icons - Segoe Fluent** you can use the below namespace:

`Xaml`

```xml
xmlns:mi="http://www.aathifmahir.com/dotnet/2022/maui/icons"
```

`C#`
```csharp
using MauiIcons.SegoeFluent;
```

## Breaking Changes from v2

`Old (v1)`

```xml
xmlns:segoeFluent="clr-namespace:MauiIcons.SegoeFluent;assembly=MauiIcons.SegoeFluent"

<segoeFluent:MauiIcon Icon="ActionCenterQuiet"/>
```

`New (v2)`

```xml
xmlns:mi="http://www.aathifmahir.com/dotnet/2022/maui/icons"

<mi:MauiIcon Icon="{mi:SegoeFluent ActionCenterQuiet}"/>
```

## Built in Control Usage

`Xaml`
```xml
<mi:MauiIcon Icon="{mi:SegoeFluent ActionCenterQuiet}"/>
```
`C#`
```csharp
new MauiIcon() {Icon = SegoeFluent.ActionCenterQuiet, IconColor = Colors.Green};

new MauiIcon().Icon(SegoeFluentIcons.AdjustHologram).IconColor(Colors.Purple);
```

All the Properties and Features of Built in Control, **[Check Here](https://github.com/AathifMahir/MauiIcons)**


## Xaml Extension Usage
```xml
<Image Aspect="Center" Source="{mi:SegoeFluent Icon=AdjustHologram}"/>

<Label Text="{mi:SegoeFluent Icon=ActionCenterQuiet}"/>
```

## C# Markup Usage

```csharp
new ImageButton().Icon(SegoeFluentIcons.ActionCenterQuiet),

new Image().Icon(SegoeFluentIcons.AdjustHologram),

new Label().Icon(SegoeFluentIcons.ActionCenterQuiet).IconSize(40.0).IconColor(Colors.Red),

new Entry().Icon(SegoeFluentIcons.AdjustHologram).IconSize(20.0).IconColor(Colors.Aqua),
```

**Disclaimer:** It's important to note that not all controls are compatible with C# markup. We have conducted tests with the following controls in the current release: **Label**, **Image**, **ImageButton**, **SearchBar**, **Editor**, and **Entry**. Additionally, the native **MauiIcon** control, when combined with C# markup, can prove to be quite versatile and offer extra features for various scenarios.

## Applying Icon To Text or Placeholder
Controls that Supports Placeholder, Can Assign the Icon To PlaceHolder or Text, 
Defaults to Placeholder but can be set to Text by Setting isPlaceHolder Parameter to False

```csharp
new Entry().Icon(SegoeFluentIcons.AdjustHologram, isPlaceHolder: false).IconSize(20.0).IconColor(Colors.Aqua);

new SearchBar().Icon(SegoeFluentIcons.ActionCenterQuiet, isPlaceHolder: false);
```

**Disclaimer:** It's important to note that not all controls are compatible with C# markup. We have conducted tests with the following controls in the current release: **Label**, **Image**, **ImageButton**, **SearchBar**, **Editor**, and **Entry**. Additionally, the native **MauiIcon** control, when combined with C# markup, can prove to be quite versatile and offer extra features for various scenarios.

## Custom OnPlatform and OnIdiom Usage
`Xaml`

```xml
<mi:MauiIcon Icon="{mi:SegoeFluent ActionCenterQuiet}" OnPlatforms="WinUI, Android, MacCatalyst"/>
<mi:MauiIcon Icon="{mi:SegoeFluent AdjustHologram}" OnIdioms="Desktop, Phone, Tablet"/>
<mi:MauiIcon Icon="{mi:SegoeFluent ActionCenterQuiet}" OnPlatforms="Android" OnIdioms="Phone"/>
```

`C#`
```csharp
new MauiIcon().Icon(SegoeFluentIcons.ActionCenterQuiet).OnPlatforms(new List<string>{"WinUI", "Android"});
new MauiIcon().Icon(SegoeFluentIcons.AdjustHologram).OnIdioms(new List<string>{"Desktop", "Phone"});
new MauiIcon().Icon(SegoeFluentIcons.ActionCenterQuiet).OnPlatforms(new List<string>{"WinUI", "Android"}).OnIdioms(new List<string>{"Desktop", "Phone"});
```

## Maui Built in OnPlatform and OnIdiom Usage

```xml
<Image>
    <Image.Source>
        <OnPlatform x:TypeArguments="ImageSource" Default="{mi:SegoeFluent Icon=AdjustHologram, TypeArgument={x:Type ImageSource}}">
            <On Platform="MacCatalyst, WinUI" 
			Value="{mi:SegoeFluent Icon=ActionCenterQuiet, IconBackgroundColor=Cyan, TypeArgument={x:Type ImageSource}}"/>
        </OnPlatform>
    </Image.Source>
</Image>

<Image>
    <Image.Source>
        <OnIdiom Default="{mi:SegoeFluent Icon=ActionCenterQuiet, TypeArgument={x:Type ImageSource}}" 
		Desktop="{mi:SegoeFluent Icon=AdjustHologram, TypeArgument={x:Type ImageSource}}">
        </OnIdiom>
    </Image.Source>
</Image>

```
**Disclaimer:**  Only **ImageSource** or **FontImageSource** Supports Maui's Built in OnPlatform or OnIdiom and **TypeArgument** Should be Assigned to Work Optimally, Therefore It's Recommended to use MauiIcons Custom OnPlatform and OnIdioms

# License

**MauiIcons.SegoeFluent**  
MauiIcons.SegoeFluent is Licensed Under [MIT License](https://github.com/AathifMahir/MauiIcons/blob/master/LICENSE).

**Segoe Fluent Icons**  
Segoe FLuent Icons is Licensed by Microsoft Under Couple of [License](https://learn.microsoft.com/en-us/typography/font-list/segoe-mdl2-assets).


