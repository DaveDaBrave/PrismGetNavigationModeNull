namespace MauiApp1;

public class SecondPageViewModel : INavigatedAware
{
    public void OnNavigatedFrom(INavigationParameters parameters)
    {
        
    }

    public void OnNavigatedTo(INavigationParameters parameters)
    {
        var nav = parameters.GetNavigationMode();
    }
}