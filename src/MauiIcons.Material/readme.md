# .Net Maui Icons

The **.NET MAUI Icons - Material** library serves as a lightweight icon library, addressing icon and font icon management in .NET MAUI by offering controls that utilize the comprehensive open-source version of the Material Icon Collection, seamlessly integrated into the library.
**[Check out the Repository for Docs](https://github.com/AathifMahir/MauiIcons)**

# Get Started
In order to use the .NET MAUI Icons - Material you need to call the extension method in your `MauiProgram.cs` file as follows:

```csharp
using MauiIcons.Material;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		
		// Initialise the .Net Maui Icons - Material
		builder.UseMauiApp<App>().UseMaterialMauiIcons();
	}
}
```

# Usage


In order to make use of the **.Net Maui Icons - Material** you can use the below namespace:

`Xaml`

```xml
xmlns:mi="http://www.aathifmahir.com/dotnet/2022/maui/icons"
```

`C#`
```csharp
using MauiIcons.Material;
```

## Breaking Changes from v2

`Old (v1)`

```xml
xmlns:material="clr-namespace:MauiIcons.Material;assembly=MauiIcons.Material"

<material:MauiIcon Icon="AddRoad"/>
```

`New (v2)`

```xml
xmlns:mi="http://www.aathifmahir.com/dotnet/2022/maui/icons"

<mi:MauiIcon Icon="{mi:Material AddRoad}"/>
```

### Nuget Package Changes

- **`AathifMahir.Maui.MauiIcons.Material`** doesn't contain all the Variants anymore, Now only contains **Regular version** of Material Icons. Other Variants Decoupled into Seperate Packages Like Below
	- [`AathifMahir.Maui.MauiIcons.Material.Outlined`](https://www.nuget.org/packages/AathifMahir.Maui.MauiIcons.Material.Outlined/)
	- [`AathifMahir.Maui.MauiIcons.Material.Rounded`](https://www.nuget.org/packages/AathifMahir.Maui.MauiIcons.Material.Rounded/)
	- [`AathifMahir.Maui.MauiIcons.Material.Sharp`](https://www.nuget.org/packages/AathifMahir.Maui.MauiIcons.Material.Sharp/)


## Built in Control Usage

`Xaml`
```xml
<mi:MauiIcon Icon="{mi:Material AddRoad}"/>
```
`C#`
```csharp
new MauiIcon() {Icon = MaterialIcons.AddRoad, IconColor = Colors.Green};

new MauiIcon().Icon(MaterialIcons.ABC).IconColor(Colors.Purple);
```

All the Properties and Features of Built in Control, **[Check Here](https://github.com/AathifMahir/MauiIcons)**


## Xaml Extension Usage
```xml
<Image Aspect="Center" Source="{mi:Material Icon=ABC}"/>

<Label Text="{mi:Material Icon=AddRoad}"/>
```

## C# Markup Usage

```csharp
new ImageButton().Icon(MaterialIcons.AddRoad),

new Image().Icon(MaterialIcons.ABC),

new Label().Icon(MaterialIcons.AddRoad).IconSize(40.0).IconColor(Colors.Red),

new Entry().Icon(MaterialIcons.ABC).IconSize(20.0).IconColor(Colors.Aqua),
```

**Disclaimer:** It's important to note that not all controls are compatible with C# markup. We have conducted tests with the following controls in the current release: **Label**, **Image**, **ImageButton**, **SearchBar**, **Editor**, and **Entry**. Additionally, the native **MauiIcon** control, when combined with C# markup, can prove to be quite versatile and offer extra features for various scenarios.

## Applying Icon To Text or Placeholder
Controls that Supports Placeholder, Can Assign the Icon To PlaceHolder or Text, 
Defaults to Placeholder but can be set to Text by Setting isPlaceHolder Parameter to False

```csharp
new Entry().Icon(MaterialIcons.ABC, isPlaceHolder: false).IconSize(20.0).IconColor(Colors.Aqua);

new SearchBar().Icon(MaterialIcons.AddRoad, isPlaceHolder: false);
```

**Disclaimer:** It's important to note that not all controls are compatible with C# markup. We have conducted tests with the following controls in the current release: **Label**, **Image**, **ImageButton**, **SearchBar**, **Editor**, and **Entry**. Additionally, the native **MauiIcon** control, when combined with C# markup, can prove to be quite versatile and offer extra features for various scenarios.

## Custom OnPlatform and OnIdiom Usage
`Xaml`

```xml
<mi:MauiIcon Icon="{mi:Material AddRoad}" OnPlatforms="WinUI, Android, MacCatalyst"/>
<mi:MauiIcon Icon="{mi:Material ABC}" OnIdioms="Desktop, Phone, Tablet"/>
<mi:MauiIcon Icon="{mi:Material AddRoad}" OnPlatforms="Android" OnIdioms="Phone"/>
```

`C#`
```csharp
new MauiIcon().Icon(MaterialIcons.AddRoad).OnPlatforms(new List<string>{"WinUI", "Android"});
new MauiIcon().Icon(MaterialIcons.ABC).OnIdioms(new List<string>{"Desktop", "Phone"});
new MauiIcon().Icon(MaterialIcons.AddRoad).OnPlatforms(new List<string>{"WinUI", "Android"}).OnIdioms(new List<string>{"Desktop", "Phone"});
```

## Maui Built in OnPlatform and OnIdiom Usage

```xml
<Image>
    <Image.Source>
        <OnPlatform x:TypeArguments="ImageSource" Default="{mi:Material Icon=ABC, TypeArgument={x:Type ImageSource}}">
            <On Platform="MacCatalyst, WinUI" 
			Value="{mi:Material Icon=AddRoad, IconBackgroundColor=Cyan, TypeArgument={x:Type ImageSource}}"/>
        </OnPlatform>
    </Image.Source>
</Image>

<Image>
    <Image.Source>
        <OnIdiom Default="{mi:Material Icon=AddRoad, TypeArgument={x:Type ImageSource}}" 
		Desktop="{mi:Material Icon=ABC, TypeArgument={x:Type ImageSource}}">
        </OnIdiom>
    </Image.Source>
</Image>

```
**Disclaimer:**  Only **ImageSource** or **FontImageSource** Supports Maui's Built in OnPlatform or OnIdiom and **TypeArgument** Should be Assigned to Work Optimally, Therefore It's Recommended to use MauiIcons Custom OnPlatform and OnIdioms

# License

**MauiIcons.Material**
MauiIcons.Material is Licensed Under [MIT License](https://github.com/AathifMahir/MauiIcons/blob/master/LICENSE).

**Material Design Icons**
Material Design Icons is Licensed Under [Apache License 2.0](https://github.com/google/material-design-icons/blob/master/LICENSE).


