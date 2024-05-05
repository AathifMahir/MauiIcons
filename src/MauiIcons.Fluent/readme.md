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

## Breaking Changes from v2

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

## Built in Control Usage

`Xaml`
```xml
<mi:MauiIcon Icon="{mi:Fluent AppFolder48}"/>
```
`C#`
```csharp
new MauiIcon() {Icon = Fluent.AppFolder48, IconColor = Colors.Green};

new MauiIcon().Icon(FluentIcons.Accessibility48).IconColor(Colors.Purple);
```

All the Properties and Features of Built in Control, **[Check Here](https://github.com/AathifMahir/MauiIcons)**


## Xaml Extension Usage
```xml
<Image Aspect="Center" Source="{mi:Fluent Icon=Accessibility48}"/>

<Label Text="{mi:Fluent Icon=AppFolder48}"/>
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
new ImageButton().Icon(FluentIcons.AppFolder48),

new Image().Icon(FluentIcons.Accessibility48),

new Label().Icon(FluentIcons.AppFolder48).IconSize(40.0).IconColor(Colors.Red),

new Entry().Icon(FluentIcons.Accessibility48).IconSize(20.0).IconColor(Colors.Aqua),
```

**Disclaimer:** It's important to note that not all controls are compatible with C# markup. We have conducted tests with the following controls in the current release: **Label**, **Image**, **ImageButton**, **SearchBar**, **Editor**, and **Entry**. Additionally, the native **MauiIcon** control, when combined with C# markup, can prove to be quite versatile and offer extra features for various scenarios.

## Applying Icon To Text or Placeholder
Controls that Supports Placeholder, Can Assign the Icon To PlaceHolder or Text, 
Defaults to Placeholder but can be set to Text by Setting isPlaceHolder Parameter to False

```csharp
new Entry().Icon(FluentIcons.Accessibility48, isPlaceHolder: false).IconSize(20.0).IconColor(Colors.Aqua);

new SearchBar().Icon(FluentIcons.AppFolder48, isPlaceHolder: false);
```

**Disclaimer:** It's important to note that not all controls are compatible with C# markup. We have conducted tests with the following controls in the current release: **Label**, **Image**, **ImageButton**, **SearchBar**, **Editor**, and **Entry**. Additionally, the native **MauiIcon** control, when combined with C# markup, can prove to be quite versatile and offer extra features for various scenarios.

## Custom OnPlatform and OnIdiom Usage
`Xaml`

```xml
<mi:MauiIcon Icon="{mi:Fluent AppFolder48}" OnPlatforms="WinUI, Android, MacCatalyst"/>
<mi:MauiIcon Icon="{mi:Fluent Accessibility48}" OnIdioms="Desktop, Phone, Tablet"/>
<mi:MauiIcon Icon="{mi:Fluent AppFolder48}" OnPlatforms="Android" OnIdioms="Phone"/>
```

`C#`
```csharp
new MauiIcon().Icon(FluentIcons.AppFolder48).OnPlatforms(new List<string>{"WinUI", "Android"});
new MauiIcon().Icon(FluentIcons.Accessibility48).OnIdioms(new List<string>{"Desktop", "Phone"});
new MauiIcon().Icon(FluentIcons.AppFolder48).OnPlatforms(new List<string>{"WinUI", "Android"}).OnIdioms(new List<string>{"Desktop", "Phone"});
```

## Maui Built in OnPlatform and OnIdiom Usage

```xml
<Image>
    <Image.Source>
        <OnPlatform x:TypeArguments="ImageSource" Default="{mi:Fluent Icon=Accessibility48, TypeArgument={x:Type ImageSource}}">
            <On Platform="MacCatalyst, WinUI" 
			Value="{mi:Fluent Icon=AppFolder48, IconBackgroundColor=Cyan, TypeArgument={x:Type ImageSource}}"/>
        </OnPlatform>
    </Image.Source>
</Image>

<Image>
    <Image.Source>
        <OnIdiom Default="{mi:Fluent Icon=AppFolder48, TypeArgument={x:Type ImageSource}}" 
		Desktop="{mi:Fluent Icon=Accessibility48, TypeArgument={x:Type ImageSource}}">
        </OnIdiom>
    </Image.Source>
</Image>

```
**Disclaimer:**  Only **ImageSource** or **FontImageSource** Supports Maui's Built in OnPlatform or OnIdiom and **TypeArgument** Should be Assigned to Work Optimally, Therefore It's Recommended to use MauiIcons Custom OnPlatform and OnIdioms

# License

**MauiIcons.Fluent**  
The MauiIcons.Fluent is library is distributed under the [MIT License](https://github.com/AathifMahir/MauiIcons/blob/master/LICENSE).

**Fluent UI System Icons**   
The Fluent UI System Icons library is distributed under the [MIT License](https://github.com/microsoft/fluentui-system-icons/blob/main/LICENSE).

