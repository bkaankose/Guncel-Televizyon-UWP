using GuncelTelevizyonUWP.Interfaces;
using Prism.Windows.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Windows.Navigation;

namespace GuncelTelevizyonUWP.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region Repositories

        private ISettingsRepository _settingsRepository;

        #endregion

        public MainPageViewModel(ISettingsRepository settingsRepository)
        {
            _settingsRepository = settingsRepository;
        }

        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);
            var a = await _settingsRepository.GetSettingsAsync();
        }
    }
}
