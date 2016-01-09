using GuncelTelevizyonUWP.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Windows.Navigation;
using GuncelTelevizyonUWP.Context;

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
            }
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);
            InitializeCurrentSettings();
            this.PropertyChanged += VMPropertyChanged;
        }
        private void InitializeCurrentSettings()
        {
            IsThemeDark = CurrentSettings.Theme == Models.AppTheme.Dark ? true : false;
        }
    }
}
