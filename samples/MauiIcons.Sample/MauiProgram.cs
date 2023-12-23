using CommunityToolkit.Maui.Markup;
using MauiIcons.Cupertino;
using MauiIcons.Fluent;
using MauiIcons.Fluent.Filled;
using MauiIcons.FontAwesome;
using MauiIcons.FontAwesome.Brand;
using MauiIcons.FontAwesome.Solid;
using MauiIcons.Material;
using MauiIcons.Material.Outlined;
using MauiIcons.Material.Rounded;
using MauiIcons.Material.Sharp;
using MauiIcons.SegoeFluent;

namespace MauiIcons.Sample;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMaterialMauiIcons()
            .UseMaterialOutlinedMauiIcons()
            .UseMaterialRoundedMauiIcons()
            .UseMaterialSharpMauiIcons()
            .UseSegoeFluentMauiIcons()
            .UseFluentMauiIcons()
            .UseFluentFilledMauiIcons()
            .UseCupertinoMauiIcons()
            .UseFontAwesomeMauiIcons()
            .UseFontAwesomeSolidMauiIcons()
            .UseFontAwesomeBrandMauiIcons()
            .UseMauiCommunityToolkitMarkup()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        return builder.Build();
    }
}
