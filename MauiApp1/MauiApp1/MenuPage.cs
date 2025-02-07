using Prism.Controls;
using NavigationMode = Prism.Navigation.NavigationMode;
using TabbedPage = Microsoft.Maui.Controls.TabbedPage;

namespace MauiApp1
{
    public class MenuPage : TabbedPage
    {
        private BasePageViewModel _prevViewModel;
        
        public MenuPage()
        {
            CreateTabBar();
        }

        private void CreateTabBar()
        {
            CurrentPageChanged -= OnCurrentPageChanged;

            Children.Clear();
            
            var overviewPage = new PrismNavigationPage(new MainPage()
            {
                Title = "Test",
            });
            
            ViewModelLocator.SetNavigationName(overviewPage, "OverviewPage");
            NavigationPage.SetHasNavigationBar(overviewPage, false);

            var turnoversPage = new PrismNavigationPage(new MainPage()
            {
                Title = "Test",
            });
            ViewModelLocator.SetNavigationName(turnoversPage, "TurnoversPage");
            NavigationPage.SetHasNavigationBar(turnoversPage, false);

            var ordersPage = new PrismNavigationPage(new MainPage()
            {
                Title = "Test",
            });
            ViewModelLocator.SetNavigationName(ordersPage, "OrdersPage");
            NavigationPage.SetHasNavigationBar(ordersPage, false);

            var menuMorePage = new PrismNavigationPage(new SecondPage()
            {
                Title = "Test",
            });
            ViewModelLocator.SetNavigationName(menuMorePage, "SecondPage");
            NavigationPage.SetHasNavigationBar(menuMorePage, false);

            Children.Add(overviewPage);
            Children.Add(ordersPage);
            Children.Add(turnoversPage);
            Children.Add(menuMorePage);
            
            CurrentPageChanged += OnCurrentPageChanged;
        }
        
        private void OnCurrentPageChanged(object sender, EventArgs e)
        {
            // we add the navigation mode to the internal parameters, otherwise GetNavigationMode() would throw an exception. 
            // We will default to NavigationMode.New because at this point its not clear if its a new or back navigation.

            var internalParameters = (INavigationParametersInternal)new NavigationParameters();
            internalParameters.Add("__NavigationMode", NavigationMode.New);

            _prevViewModel?.OnNavigatedFrom((NavigationParameters)internalParameters);

            _prevViewModel = (CurrentPage as NavigationPage)?.CurrentPage.BindingContext as BasePageViewModel;

            if (_prevViewModel != null)
            {
                // SetTabBarIcons();
            }

            _prevViewModel?.OnNavigatedTo((NavigationParameters)internalParameters);
        }
    }
}

