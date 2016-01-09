using GuncelTelevizyonUWP.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Windows.Navigation;

namespace GuncelTelevizyonUWP.ViewModels
{
    public class SettingsPageViewModel : BaseViewModel
    {
        private bool _isThemeDark;

        public bool IsThemeDark
        {
            get { return _isThemeDark; }
            set { _isThemeDark = value; OnPropertyChanged("IsThemeDark"); }
        }

        public SettingsPageViewModel()
        {
            
        }

        private async void VMPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "IsThemeDark")
            {
                CurrentSettings.Theme = IsThemeDark ? Models.AppTheme.Dark : Models.AppTheme.Light;
                await base.settingsService.SaveSettingsAsync(CurrentSettings);
                OnPropertyChanged("ApplySettings");
            }
        }

        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);
            await InitializeCurrentSettings();

            this.PropertyChanged += VMPropertyChanged;
        }
        private async Task InitializeCurrentSettings()
        {
            IsThemeDark = CurrentSettings.Theme == Models.AppTheme.Dark ? true : false;

        }
    }
}
