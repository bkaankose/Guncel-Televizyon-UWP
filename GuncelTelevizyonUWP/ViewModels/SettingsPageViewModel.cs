using GuncelTelevizyonUWP.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Windows.Navigation;
using GuncelTelevizyonUWP.Context;
using Prism.Commands;

namespace GuncelTelevizyonUWP.ViewModels
{
    public class SettingsPageViewModel : BaseViewModel
    {
        #region Properties

        private bool _isDarkTheme;

        public bool IsDarkTheme
        {
            get { return _isDarkTheme; }
            set { _isDarkTheme = value; OnPropertyChanged("IsDarkTheme"); }
        }

        #endregion

        #region Commands

        public DelegateCommand SaveSettingsCommand { get; set; }

        #endregion

        public SettingsPageViewModel()
        {
            InitializeCommands();
        }

        private async void SaveSettings()
        {
            await settingsService.SaveSettingsAsync(CurrentSettings);
        }

        private void InitializeCommands()
        {
            SaveSettingsCommand = new DelegateCommand(SaveSettings);
        }
        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);
            IsDarkTheme = CurrentSettings.Theme == Models.AppTheme.Dark ? true : false;

            this.PropertyChanged += SettingsPageViewModel_PropertyChanged;
        }

        private void SettingsPageViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(IsDarkTheme))
            {
                CurrentSettings.Theme = IsDarkTheme ? Models.AppTheme.Dark : Models.AppTheme.Light;
                SaveSettings();
            }
        }
    }
}
