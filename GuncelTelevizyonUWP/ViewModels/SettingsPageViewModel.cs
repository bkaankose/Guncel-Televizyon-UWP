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
        }
    }
}
