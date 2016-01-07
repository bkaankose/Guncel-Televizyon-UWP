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

namespace GuncelTelevizyonUWP.Services
{
    public class SettingsService : ISettingsService
    {
        public async Task<Settings> GetSettingsAsync()
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            if (File.Exists(string.Format("{0}\\{1}", storageFolder.Path, "settings.json")))
            {
                StorageFile settingsJson = await storageFolder.GetFileAsync("settings.json");
                return JsonConvert.DeserializeObject<Settings>((JObject.Parse(await FileIO.ReadTextAsync(settingsJson)).ToString()));
            }else
                return new Settings() { Theme = AppTheme.Dark, FavoritedChannelIds = new List<int>() };
        }

        public Task<bool> SaveSettingsAsync(Settings _settingsModel)
        {
            throw new NotImplementedException();
        }
    }
}
