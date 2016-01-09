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
        private SettingsService settingsService = ApplicationContext.Resolve<SettingsService>();
        public BasePage()
        {
            
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await InitializeBasePage();
            //this.RequestedTheme = Windows.UI.Xaml.ElementTheme.Light;
        }

        public async Task ApplySettings()
        {
            await InitializeBasePage();
        }

        private async Task InitializeBasePage()
        {
            _mainSettings = await settingsService.GetSettingsAsync();
            this.RequestedTheme = _mainSettings.Theme == AppTheme.Light ? Windows.UI.Xaml.ElementTheme.Light : Windows.UI.Xaml.ElementTheme.Dark;
        }
    }
}
