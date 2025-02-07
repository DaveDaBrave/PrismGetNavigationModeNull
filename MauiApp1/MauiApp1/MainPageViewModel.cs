using System.Windows.Input;
using Prism.Navigation;

namespace MauiApp1;

public class MainPageViewModel : INavigatedAware
{
    private readonly INavigationService _navigationService;

    public ICommand ButtonClickedCommand { get; private set; }

    public MainPageViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        ButtonClickedCommand = new Command(async () => await ButtonClicked());
    }

    private async Task ButtonClicked()
    {
        var navResult = await _navigationService.SelectTabAsync("SecondPage");
    }

    public void OnNavigatedFrom(INavigationParameters parameters)
    {
        
    }

    public void OnNavigatedTo(INavigationParameters parameters)
    {
    }
}