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

        private ISettingsService _settingsService;
        public BaseViewModel()
        {
            _settingsService = new SettingsService();
        }
        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            CurrentSettings = await _settingsService.GetSettingsAsync();
            base.OnNavigatedTo(e, viewModelState);
        }

    }
}
