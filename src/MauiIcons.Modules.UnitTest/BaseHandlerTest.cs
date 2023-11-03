using MauiIcons.Cupertino;
using MauiIcons.Fluent;
using MauiIcons.Fluent.Filled;
using MauiIcons.Material;
using MauiIcons.Material.Outlined;
using MauiIcons.Material.Rounded;
using MauiIcons.Material.Sharp;
using MauiIcons.Modules.UnitTest.Mocks;
using MauiIcons.SegoeFluent;

namespace MauiIcons.Modules.UnitTest;
public abstract class BaseHandlerTest : BaseTest
{

    protected BaseHandlerTest()
    {
        CreateAndSetMockApplication(out var serviceProvider);
        ServiceProvider = serviceProvider;
    }

    protected IServiceProvider ServiceProvider { get; }

    protected static TElementHandler CreateElementHandler<TElementHandler>(Microsoft.Maui.IElement view, bool hasMauiContext = true)
        where TElementHandler : IElementHandler, new()
    {
        var mockElementHandler = new TElementHandler();
        mockElementHandler.SetVirtualView(view);

        if (hasMauiContext)
        {
            mockElementHandler.SetMauiContext(Application.Current?.Handler?.MauiContext ?? throw new NullReferenceException());
        }

        return mockElementHandler;
    }

    protected static TViewHandler CreateViewHandler<TViewHandler>(IView view, bool hasMauiContext = true)
        where TViewHandler : IViewHandler, new()
    {
        var mockViewHandler = new TViewHandler();
        mockViewHandler.SetVirtualView(view);

        if (hasMauiContext)
        {
            mockViewHandler.SetMauiContext(Application.Current?.Handler?.MauiContext ?? throw new NullReferenceException());
        }

        return mockViewHandler;
    }

    static void CreateAndSetMockApplication(out IServiceProvider serviceProvider)
    {
        var appBuilder = MauiApp.CreateBuilder()
                                .UseMaterialMauiIcons()
                                .UseMaterialOutlinedMauiIcons()
                                .UseMaterialRoundedMauiIcons()
                                .UseMaterialSharpMauiIcons()
                                .UseSegoeFluentMauiIcons()
                                .UseFluentMauiIcons()
                                .UseFluentFilledMauiIcons()
                                .UseCupertinoMauiIcons()
                                .UseMauiApp<MockApplication>();

        var mauiApp = appBuilder.Build();

        var application = mauiApp.Services.GetRequiredService<IApplication>();
        serviceProvider = mauiApp.Services;

        application.Handler = new ApplicationHandlerStub();
        application.Handler.SetMauiContext(new HandlersContextStub(mauiApp.Services));
    }
}
