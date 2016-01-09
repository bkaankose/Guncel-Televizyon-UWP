using GuncelTelevizyonUWP.Interfaces;
using GuncelTelevizyonUWP.Models;
using GuncelTelevizyonUWP.Services;
using Prism.Windows.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Windows.Navigation;
using GuncelTelevizyonUWP.Context;
using Windows.UI.Core;

namespace GuncelTelevizyonUWP.Helpers
{
    public class BaseViewModel : ViewModelBase
    {
        private Settings _currentSettings;

        public Settings CurrentSettings
        {
            get { return _currentSettings; }
            set { _currentSettings = value; OnPropertyChanged("CurrentSettings"); }
        }

        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value; OnPropertyChanged("IsBusy"); }
        }

        public ISettingsService settingsService;
        public INavigationService navigationService;
        public BaseViewModel()
        {
            navigationService = ApplicationContext.Resolve<INavigationService>();
            settingsService = ApplicationContext.Resolve<ISettingsService>();
            if (navigationService.CanGoBack())
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            else
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }

        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);
            CurrentSettings = await settingsService.GetSettingsAsync();
        }

    }
}
