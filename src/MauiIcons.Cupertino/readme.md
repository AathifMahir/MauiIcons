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

## Breaking Changes from v2

`Old`

```xml
xmlns:cupertino="clr-namespace:MauiIcons.Cupertino;assembly=MauiIcons.Cupertino"

<cupertino:MauiIcon Icon="Airplane"/>
```

`New`

```xml
xmlns:mi="http://www.aathifmahir.com/dotnet/2022/maui/icons"

<mi:MauiIcon Icon="{mi:Cupertino Airplane}"/>
```

## Built in Control Usage

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


## Xaml Extension Usage
```xml
<Image Aspect="Center" Source="{mi:Cupertino Icon=ArchiveboxFill}"/>

<Label Text="{mi:Cupertino Icon=Airplane}"/>
```

## C# Markup Usage

```csharp
new ImageButton().Icon(CupertinoIcons.AntFill),

new Image().Icon(CupertinoIcons.AntFill),

new Label().Icon(CupertinoIcons.AntFill).IconSize(40.0).IconColor(Colors.Red),

new Entry().Icon(CupertinoIcons.AntFill).IconSize(20.0).IconColor(Colors.Aqua),
```

**Disclaimer:** It's important to note that not all controls are compatible with C# markup. We have conducted tests with the following controls in the current release: **Label**, **Image**, **ImageButton**, **SearchBar**, **Editor**, and **Entry**. Additionally, the native **MauiIcon** control, when combined with C# markup, can prove to be quite versatile and offer extra features for various scenarios.

## Applying Icon To Text or Placeholder
Controls that Supports Placeholder, Can Assign the Icon To PlaceHolder or Text, 
Defaults to Placeholder but can be set to Text by Setting isPlaceHolder Parameter to False

```csharp
new Entry().Icon(CupertinoIcons.AntFill, isPlaceHolder: false).IconSize(20.0).IconColor(Colors.Aqua);

new SearchBar().Icon(MaterialIcons.ABC, isPlaceHolder: false);
```

**Disclaimer:** It's important to note that not all controls are compatible with C# markup. We have conducted tests with the following controls in the current release: **Label**, **Image**, **ImageButton**, **SearchBar**, **Editor**, and **Entry**. Additionally, the native **MauiIcon** control, when combined with C# markup, can prove to be quite versatile and offer extra features for various scenarios.

## Custom OnPlatform and OnIdiom Usage
`Xaml`

```xml
<mi:MauiIcon Icon="{mi:Cupertino Airplane}" OnPlatforms="WinUI, Android, MacCatalyst"/>
<mi:MauiIcon Icon="{mi:Cupertino AntFill}" OnIdioms="Desktop, Phone, Tablet"/>
<mi:MauiIcon Icon="{mi:Cupertino Airplane}" OnPlatforms="Android" OnIdioms="Phone"/>
```

`C#`
```csharp
new MauiIcon().Icon(CupertinoIcons.AntFill).OnPlatforms(new List<string>{"WinUI", "Android"});
new MauiIcon().Icon(CupertinoIcons.Airplane).OnIdioms(new List<string>{"Desktop", "Phone"});
new MauiIcon().Icon(CupertinoIcons.AntFill).OnPlatforms(new List<string>{"WinUI", "Android"}).OnIdioms(new List<string>{"Desktop", "Phone"});
```

## Maui Built in OnPlatform and OnIdiom Usage

```xml
<Image>
    <Image.Source>
        <OnPlatform x:TypeArguments="ImageSource" Default="{mi:Cupertino Icon=Airplane, TypeArgument={x:Type ImageSource}}">
            <On Platform="MacCatalyst, WinUI" 
			Value="{mi:Cupertino Icon=AntFill, IconBackgroundColor=Cyan, TypeArgument={x:Type ImageSource}}"/>
        </OnPlatform>
    </Image.Source>
</Image>

<Image>
    <Image.Source>
        <OnIdiom Default="{mi:Cupertino Icon=AntFill, TypeArgument={x:Type ImageSource}}" 
		Desktop="{mi:Cupertino Icon=Airplane, TypeArgument={x:Type ImageSource}}">
        </OnIdiom>
    </Image.Source>
</Image>

```
**Disclaimer:**  Only **ImageSource** or **FontImageSource** Supports Maui's Built in OnPlatform or OnIdiom and **TypeArgument** Should be Assigned to Work Optimally, Therefore It's Recommended to use MauiIcons Custom OnPlatform and OnIdioms

# License

**MauiIcons.Cupertino**</br>
The MauiIcons.Cupertino library is distributed under the [MIT License](https://github.com/AathifMahir/MauiIcons/blob/master/LICENSE).

**Cupertino Icons**</br>
The Cupertino Icons library is distributed under the [MIT License](https://github.com/framework7io/framework7-icons/blob/master/LICENSE).

