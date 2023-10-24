.NET MAUI Icons

Initializing

In order to use the .NET MAUI Icons - Fluent Filled you need to call the extension method in your `MauiProgram.cs` file as follows:

using MauiIcons.Fluent.Filled;

public static MauiApp CreateMauiApp()
{
    var builder = MauiApp.CreateBuilder();

    // Initialise the .Net Maui Icons - Fluent Filled
	builder.UseMauiApp<App>().UseFluentFilledMauiIcons();
}

XAML usage

In order to make use of the .Net Maui Icons - Fluent Filled within XAML you can use this namespace:

xmlns:fluentFilled="clr-namespace:MauiIcons.Fluent.Filled;assembly=MauiIcons.Fluent.Filled"

----------------------------------------------------------------------------------------------

Built in Custom Control Usage:

<fluentFilled:MauiIcon Icon="Accounts"/>

----------------------------------------------------------------------------------------------

Image Extension Usage:

<Image Aspect="Center" Source="{fluentFilled:Icon Icon=Accounts}"/>

----------------------------------------------------------------------------------------------

## Further information

For more information please visit:

- Our GitHub repository: https://github.com/AathifMahir/MauiIcons