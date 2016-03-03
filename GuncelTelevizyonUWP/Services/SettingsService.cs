using GuncelTelevizyonUWP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuncelTelevizyonUWP.Models;
using Windows.Storage;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Windows.Storage.Streams;
using GuncelTelevizyonUWP.Context;
using System.Collections.ObjectModel;

namespace GuncelTelevizyonUWP.Services
{
    public class SettingsService : ISettingsService
    {
        private StorageFolder storageFolder = ConfigurationContext.LocalFolder;

        public ObservableCollection<QualityEnumModel> GetQualities()
        {
            var nret = new ObservableCollection<QualityEnumModel>();
            var qualities = Enum.GetValues(typeof(QualityEnumModel));
            foreach (var q in qualities)
                nret.Add((QualityEnumModel)q);

            return nret;
            
        }

        public async Task<Settings> GetSettingsAsync()
        {
            if (ConfigurationContext.MainSettings != null)
                return ConfigurationContext.MainSettings;

            if (File.Exists(string.Format("{0}\\{1}", storageFolder.Path, "settings.json")))
            {
                StorageFile settingsJson = await storageFolder.GetFileAsync("settings.json");
                ConfigurationContext.MainSettings = JsonConvert.DeserializeObject<Settings>((JObject.Parse(await FileIO.ReadTextAsync(settingsJson)).ToString()));
            }
            else
               ConfigurationContext.MainSettings = new Settings() { Theme = AppTheme.Dark, FavoritedChannelIds = new List<Guid>() , PreferedQuality = QualityEnumModel.Orta };


            return ConfigurationContext.MainSettings;
        }
        public async Task<bool> SaveSettingsAsync(Settings _settingsModel)
        {
            StorageFile storageFile = await storageFolder.CreateFileAsync("settings.json", CreationCollisionOption.OpenIfExists);
            try
            {
                var settingsJson = JsonConvert.SerializeObject(_settingsModel);
                await FileIO.WriteLinesAsync(storageFile, settingsJson.Split('\n'));
                ConfigurationContext.MainSettings = _settingsModel;
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
