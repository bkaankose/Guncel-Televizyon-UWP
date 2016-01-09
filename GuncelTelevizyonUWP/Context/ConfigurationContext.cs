using GuncelTelevizyonUWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuncelTelevizyonUWP.Context
{
    public static class ConfigurationContext
    {
        private static Settings _mainSettings;
        public static Settings MainSettings
        {
            get
            {
                return _mainSettings;
            }
            set
            {
                _mainSettings = value;
                if(SettingsChanged != null)
                    SettingsChanged.Invoke(_mainSettings, null);
            }
        }
        public static event EventHandler SettingsChanged;
    }
}
