.NET MAUI Icons

Initializing

In order to use the .NET MAUI Icons - Cupertino you need to call the extension method in your `MauiProgram.cs` file as follows:

using MauiIcons.Cupertino;

public static MauiApp CreateMauiApp()
{
    var builder = MauiApp.CreateBuilder();

    // Initialise the .Net Maui Icons - Fluent
	builder.UseMauiApp<App>().UseCupertinoMauiIcons();
}

XAML usage

In order to make use of the .Net Maui Icons - Material within XAML you can use this namespace:

xmlns:mi="http://www.aathifmahir.com/dotnet/2022/maui/icons"

----------------------------------------------------------------------------------------------

Built in Custom Control Usage:

Xaml:

<mi:MauiIcon Icon="{mi:Cupertino Airplane}"/>

C#:

new MauiIcon().Icon(CupertinoIcons.AntFill).IconColor(Colors.Purple);

----------------------------------------------------------------------------------------------

Xaml Extension Usage:

<Image Aspect="Center" Source="{mi:Cupertino Icon=ArchiveboxFill}"/>
<Label Text="{mi:Cupertino Icon=Airplane}"/>

----------------------------------------------------------------------------------------------

C# Markup Usage:

new ImageButton().Icon(CupertinoIcons.AntFill),

new Image().Icon(CupertinoIcons.AntFill),

new Label().Icon(CupertinoIcons.AntFill).IconSize(40.0).IconColor(Colors.Red),

new Entry().Icon(CupertinoIcons.AntFill).IconSize(20.0).IconColor(Colors.Aqua),

----------------------------------------------------------------------------------------------

## Further information

For more information please visit:

- Our GitHub repository: https://github.com/AathifMahir/MauiIcons