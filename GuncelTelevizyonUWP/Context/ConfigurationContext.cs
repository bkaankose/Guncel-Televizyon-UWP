using GuncelTelevizyonUWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;

namespace GuncelTelevizyonUWP.Context
{
    public static class ConfigurationContext
    {
        public static string ChannelImageStorageURL = "https://gunceltelevizyon.blob.core.windows.net/channels/";
        public static StorageFolder LocalFolder = ApplicationData.Current.LocalFolder;

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
