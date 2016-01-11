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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace GuncelTelevizyonUWP.Helpers
{
    public class BasePage : SessionStateAwarePage
    {
        public BasePage()
        {
            ConfigurationContext.SettingsChanged += (c, r) => { InitializeSettings(c as Settings); };
            this.Transitions = new TransitionCollection() { new EntranceThemeTransition() };
        }
        private void InitializeSettings(Settings model)
        {
            // Theme
            base.RequestedTheme = model.Theme == AppTheme.Dark ? Windows.UI.Xaml.ElementTheme.Dark : Windows.UI.Xaml.ElementTheme.Light;
        }
    }
}
