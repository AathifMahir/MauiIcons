using MauiIcons.Cupertino;
using MauiIcons.Fluent;
using MauiIcons.FluentFilled;
using MauiIcons.Material;
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
            .UseSegoeFluentMauiIcons()
            .UseFluentMauiIcons()
            .UseFluentFilledMauiIcons()
            .UseCupertinoMauiIcons()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        return builder.Build();
    }
}
