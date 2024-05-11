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

## Breaking Changes

### Version 1 to 2

`Old (v1)`

```xml
xmlns:cupertino="clr-namespace:MauiIcons.Cupertino;assembly=MauiIcons.Cupertino"

<cupertino:MauiIcon Icon="Airplane"/>
```

`New (v2)`

```xml
xmlns:mi="http://www.aathifmahir.com/dotnet/2022/maui/icons"

<mi:MauiIcon Icon="{mi:Cupertino Airplane}"/>
```

### Version 2 to 3

  - Removal of **TypeArgument** and Built in OnPlatform and OnIdiom Support, Use MauiIcons Integrated [Custom OnPlatform and OnIdioms Feature](#custom-onplatform-and-onidiom-usage)
  - Removal of **Dotnet 7** Support

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

## Xaml Extension Data Binding Usage

The below example, Make Sures that BindingContext Inside the Xaml Extension is Set to Root of this Page, Likewise make sure to set the BindingContext When using Binding Inside the MauiIcons Xaml Extension, Additionally This example Binds to MyIcon and MyColor Properties Which Present in Code Behind But Not Included in this Example.
```xml
<ContentPage
    x:Class="MauiIcons.Sample.BindingPage"
    xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    xmlns:local="clr-namespace:MauiIcons.Sample"
    xmlns:mi="http://www.aathifmahir.com/dotnet/2022/maui/icons"
    x:Name="thisRoot">
        <HorizontalStackLayout>
            <Label Text="{mi:Fluent BindingContext={x:Reference thisRoot}, Icon={Binding MyIcon}, IconColor={Binding MyColor}}" />
            <Image>
                <Image.Source>
                    <FontImageSource 
                    Glyph="{mi:Fluent BindingContext={x:Reference thisRoot}, 
                    Icon={Binding MyIcon}, IconColor={Binding MyColor}}" />
                </Image.Source>
            </Image>

            <ImageButton Source="{mi:Fluent BindingContext={x:Reference thisRoot}, Icon={Binding MyIcon}, IconColor={Binding MyColor}" />
        </HorizontalStackLayout>
</ContentPage>
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

# License

**MauiIcons.Fluent.Filled**  
MauiIcons.Fluent.Filled is Licensed Under [MIT License](https://github.com/AathifMahir/MauiIcons/blob/master/LICENSE).

**Fluent UI System Icons**  
Fluent UI System Icons is Licensed Under [MIT License](https://github.com/microsoft/fluentui-system-icons/blob/main/LICENSE).


