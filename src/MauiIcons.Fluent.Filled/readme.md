# .Net Maui Icons

The **.NET MAUI Icons - Fluent Filled** library serves as a lightweight icon library, addressing icon and font icon management in .NET MAUI by offering controls that utilize the comprehensive open-source version of the Fluent Icon Collection, seamlessly integrated into the library.
**[Check out the Repository for Docs](https://github.com/AathifMahir/MauiIcons)**

# Get Started
In order to use the .NET MAUI Icons - Fluent Filled you need to call the extension method in your `MauiProgram.cs` file as follows:

```csharp
using MauiIcons.Fluent.Filled;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		
		// Initialise the .Net Maui Icons - Fluent Filled
		builder.UseMauiApp<App>().UseFluentFilledMauiIcons();
	}
}
```

# Usage


In order to make use of the **.Net Maui Icons - Fluent Filled** you can use the below namespace:

`Xaml`

```xml
xmlns:mi="http://www.aathifmahir.com/dotnet/2022/maui/icons"
```

`C#`
```csharp
using MauiIcons.Fluent.Filled;
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

## Breaking Changes from v2

`Old (v1)`

```xml
xmlns:fluentFilled="clr-namespace:MauiIcons.FluentFilled;assembly=MauiIcons.FluentFilled"

<fluentFilled:MauiIcon Icon="AppFolder48Filled"/>
```

`New (v2)`

```xml
xmlns:mi="http://www.aathifmahir.com/dotnet/2022/maui/icons"

<mi:MauiIcon Icon="{mi:FluentFilled AppFolder48Filled}"/>
```

### Nuget Package Changes

- **`AathifMahir.Maui.MauiIcons.FluentFilled`** is Depcrecated and Replaced by [`AathifMahir.Maui.MauiIcons.Fluent.Filled`](https://www.nuget.org/packages/AathifMahir.Maui.MauiIcons.Fluent.Filled/)

## Built in Control Usage

`Xaml`
```xml
<mi:MauiIcon Icon="{mi:FluentFilled AppFolder48Filled}"/>
```
`C#`
```csharp
new MauiIcon() {Icon = FluentFilledIcons.AppFolder48Filled, IconColor = Colors.Green};

new MauiIcon().Icon(FluentFilledIcons.Accessibility48Filled).IconColor(Colors.Purple);
```

All the Properties and Features of Built in Control, **[Check Here](https://github.com/AathifMahir/MauiIcons)**


## Xaml Extension Usage
```xml
<Image Aspect="Center" Source="{mi:FluentFilled Icon=Accessibility48Filled}"/>

<Label Text="{mi:FluentFilled Icon=AppFolder48Filled}"/>
```

## C# Markup Usage

```csharp
new ImageButton().Icon(FluentFilledIcons.AppFolder48Filled),

new Image().Icon(FluentFilledIcons.Accessibility48Filled),

new Label().Icon(FluentFilledIcons.AppFolder48Filled).IconSize(40.0).IconColor(Colors.Red),

new Entry().Icon(FluentFilledIcons.Accessibility48Filled).IconSize(20.0).IconColor(Colors.Aqua),
```

**Disclaimer:** It's important to note that not all controls are compatible with C# markup. We have conducted tests with the following controls in the current release: **Label**, **Image**, **ImageButton**, **SearchBar**, **Editor**, and **Entry**. Additionally, the native **MauiIcon** control, when combined with C# markup, can prove to be quite versatile and offer extra features for various scenarios.

## Applying Icon To Text or Placeholder
Controls that Supports Placeholder, Can Assign the Icon To PlaceHolder or Text, 
Defaults to Placeholder but can be set to Text by Setting isPlaceHolder Parameter to False

```csharp
new Entry().Icon(FluentFilledIcons.Accessibility48Filled, isPlaceHolder: false).IconSize(20.0).IconColor(Colors.Aqua);

new SearchBar().Icon(FluentFilledIcons.AppFolder48Filled, isPlaceHolder: false);
```

**Disclaimer:** It's important to note that not all controls are compatible with C# markup. We have conducted tests with the following controls in the current release: **Label**, **Image**, **ImageButton**, **SearchBar**, **Editor**, and **Entry**. Additionally, the native **MauiIcon** control, when combined with C# markup, can prove to be quite versatile and offer extra features for various scenarios.

## Custom OnPlatform and OnIdiom Usage
`Xaml`

```xml
<mi:MauiIcon Icon="{mi:FluentFilled AppFolder48Filled}" OnPlatforms="WinUI, Android, MacCatalyst"/>
<mi:MauiIcon Icon="{mi:FluentFilled Accessibility48Filled}" OnIdioms="Desktop, Phone, Tablet"/>
<mi:MauiIcon Icon="{mi:FluentFilled AppFolder48Filled}" OnPlatforms="Android" OnIdioms="Phone"/>
```

`C#`
```csharp
new MauiIcon().Icon(FluentFilledIcons.AppFolder48Filled).OnPlatforms(new List<string>{"WinUI", "Android"});
new MauiIcon().Icon(FluentFilledIcons.Accessibility48Filled).OnIdioms(new List<string>{"Desktop", "Phone"});
new MauiIcon().Icon(FluentFilledIcons.AppFolder48Filled).OnPlatforms(new List<string>{"WinUI", "Android"}).OnIdioms(new List<string>{"Desktop", "Phone"});
```

## Maui Built in OnPlatform and OnIdiom Usage

```xml
<Image>
    <Image.Source>
        <OnPlatform x:TypeArguments="ImageSource" Default="{mi:FluentFilled Icon=Accessibility48Filled, TypeArgument={x:Type ImageSource}}">
            <On Platform="MacCatalyst, WinUI" 
			Value="{mi:FluentFilled Icon=AppFolder48Filled, IconBackgroundColor=Cyan, TypeArgument={x:Type ImageSource}}"/>
        </OnPlatform>
    </Image.Source>
</Image>

<Image>
    <Image.Source>
        <OnIdiom Default="{mi:FluentFilled Icon=AppFolder48Filled, TypeArgument={x:Type ImageSource}}" 
		Desktop="{mi:FluentFilled Icon=Accessibility48Filled, TypeArgument={x:Type ImageSource}}">
        </OnIdiom>
    </Image.Source>
</Image>

```
**Disclaimer:**  Only **ImageSource** or **FontImageSource** Supports Maui's Built in OnPlatform or OnIdiom and **TypeArgument** Should be Assigned to Work Optimally, Therefore It's Recommended to use MauiIcons Custom OnPlatform and OnIdioms

# License

**MauiIcons.Fluent.Filled**  
MauiIcons.Fluent.Filled is Licensed Under [MIT License](https://github.com/AathifMahir/MauiIcons/blob/master/LICENSE).

**Fluent UI System Icons**  
Fluent UI System Icons is Licensed Under [MIT License](https://github.com/microsoft/fluentui-system-icons/blob/main/LICENSE).


