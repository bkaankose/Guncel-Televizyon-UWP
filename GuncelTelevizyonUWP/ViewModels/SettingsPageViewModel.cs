using GuncelTelevizyonUWP.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Windows.Navigation;
using GuncelTelevizyonUWP.Context;
using Prism.Commands;
using System.Collections.ObjectModel;
using GuncelTelevizyonUWP.Models;
using GuncelTelevizyonUWP.Interfaces;

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



        private ObservableCollection<QualityEnumModel> _allQualities;

        public ObservableCollection<QualityEnumModel> AllQualities
        {
            get { return _allQualities; }
            set { _allQualities = value; OnPropertyChanged("AllQualities"); }
        }

        private QualityEnumModel _selectedQuality;

        public QualityEnumModel SelectedQuality
        {
            get { return _selectedQuality; }
            set { _selectedQuality = value; OnPropertyChanged("SelectedQuality"); }
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
            AllQualities = settingsService.GetQualities();
            SelectedQuality = AllQualities.FirstOrDefault(a => a == CurrentSettings.PreferedQuality);
            this.PropertyChanged += SettingsPageViewModel_PropertyChanged;
        }

        private void SettingsPageViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IsDarkTheme))
                CurrentSettings.Theme = IsDarkTheme ? Models.AppTheme.Dark : Models.AppTheme.Light;
            else if (e.PropertyName == nameof(SelectedQuality))
                CurrentSettings.PreferedQuality = SelectedQuality;

            SaveSettings();
        }
    }
}
