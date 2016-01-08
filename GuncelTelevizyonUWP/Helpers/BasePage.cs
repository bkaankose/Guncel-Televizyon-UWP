using GuncelTelevizyonUWP.Context;
using GuncelTelevizyonUWP.Models;
using GuncelTelevizyonUWP.Services;
using Prism.Windows.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace GuncelTelevizyonUWP.Helpers
{
    public class BasePage : SessionStateAwarePage
    {
        private Settings _mainSettings;
        public BasePage()
        {
            
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await InitializeBasePage();
        }

        private async Task InitializeBasePage()
        {
            var settingsService = ApplicationContext.Resolve<SettingsService>();
            _mainSettings = await settingsService.GetSettingsAsync();
            this.RequestedTheme = _mainSettings.Theme == AppTheme.Light ? Windows.UI.Xaml.ElementTheme.Light : Windows.UI.Xaml.ElementTheme.Dark;
        }
    }
}
