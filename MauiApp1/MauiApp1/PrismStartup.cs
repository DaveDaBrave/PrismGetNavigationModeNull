using Prism.Controls;

namespace MauiApp1;

internal static class PrismStartup
{
    public static void Configure(PrismAppBuilder builder)
    {
        builder.RegisterTypes(RegisterTypes)
            .AddGlobalNavigationObserver(context => context.Subscribe(x =>
            {
                if (x.Type == NavigationRequestType.Navigate)
                    Console.WriteLine($"Navigation: {x.Uri}");
                else
                    Console.WriteLine($"Navigation: {x.Type}");
                var status = x.Cancelled ? "Cancelled" : x.Result.Success ? "Success" : "Failed";
                Console.WriteLine($"Result: {status}");
                if (status == "Failed" && !string.IsNullOrEmpty(x.Result?.Exception?.Message))
                    Console.Error.WriteLine(x.Result.Exception.Message);

                if (!x.Result.Success)
                {
                    Console.WriteLine(x.Result.Exception);

                    if (x.Result.Exception.InnerException != null)
                    {
                        Console.WriteLine(x.Result.Exception.InnerException);
                    }
                }
            }))
            .OnInitialized(OnInitialized)
            .CreateWindow(OnCreateWindow);
    }

    private static void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<MenuPage>();
        containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
        containerRegistry.RegisterForNavigation<SecondPage, SecondPageViewModel>();
    }

    private static void OnInitialized(IContainerProvider containerProvider)
    {
        
    }

    private static async Task OnCreateWindow(INavigationService navigationService)
    {
        await navigationService.NavigateAsync("/NavigationPage/MenuPage");
    }
}