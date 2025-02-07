using NavigationMode = Prism.Navigation.NavigationMode;

namespace MauiApp1;

public class BasePageViewModel : BindableBase, INavigatedAware
{
    protected BasePageViewModel() { }
    
    public void OnNavigatedTo(INavigationParameters parameters)
    {
        var mode = parameters.GetNavigationMode();
        if (parameters == null)
        {
            var internalParameters = (INavigationParametersInternal) new NavigationParameters();
            internalParameters.Add("__NavigationMode", NavigationMode.New);
            parameters = (NavigationParameters)internalParameters;
        }
    }
    
    public void OnNavigatedFrom(INavigationParameters parameters)
    {
        var mode = parameters.GetNavigationMode();
        if (parameters == null)
        {
            var internalParameters = (INavigationParametersInternal) new NavigationParameters();
            internalParameters.Add("__NavigationMode", NavigationMode.New);
            parameters = (NavigationParameters)internalParameters;
        }
    }
}



// public class MainPageViewModel : INavigatedAware
// {
//     private readonly INavigationService _navigationService;
//
//     public ICommand ButtonClickedCommand { get; private set; }
//
//     public MainPageViewModel(INavigationService navigationService)
//     {
//         _navigationService = navigationService;
//         ButtonClickedCommand = new Command(async () => await ButtonClicked());
//     }
//
//     private async Task ButtonClicked()
//     {
//         var navResult = await _navigationService.SelectTabAsync("SecondPage");
//     }
//
//     public void OnNavigatedFrom(INavigationParameters parameters)
//     {
//         
//     }
//
//     public void OnNavigatedTo(INavigationParameters parameters)
//     {
//     }
// }