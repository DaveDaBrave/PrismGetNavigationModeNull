# PrismGetNavigationModeNull

When SelectTabAsync calls OnNavigatedTo on the target page parameters.GetNavigationMode() will result in:
System.ArgumentNullException: Value cannot be null. (Parameter 'NavigationMode is not available') at Prism.Navigation.NavigationParametersExtensions.GetNavigationMode(INavigationParameters parameters)
