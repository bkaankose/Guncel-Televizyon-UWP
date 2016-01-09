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

namespace GuncelTelevizyonUWP.Services
{
    public class SettingsService : ISettingsService
    {
        private StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
        public async Task<Settings> GetSettingsAsync()
        {
            if (ConfigurationContext.MainSettings != null)
                return ConfigurationContext.MainSettings;

            if (File.Exists(string.Format("{0}\\{1}", storageFolder.Path, "settings.json")))
            {
                StorageFile settingsJson = await storageFolder.GetFileAsync("settings.json");
               ConfigurationContext.MainSettings = JsonConvert.DeserializeObject<Settings>((JObject.Parse(await FileIO.ReadTextAsync(settingsJson)).ToString()));
            }else
               ConfigurationContext.MainSettings = new Settings() { Theme = AppTheme.Dark, FavoritedChannelIds = new List<int>() };


            return ConfigurationContext.MainSettings;
        }

        public async Task<bool> SaveSettingsAsync(Settings _settingsModel)
        {
            StorageFile storageFile = null;
            try
            {
                try
                {
                    storageFile = await storageFolder.GetFileAsync("settings.json");
                }
                catch (Exception)
                {
                    await storageFolder.CreateFileAsync("settings.json");
                    storageFile = await storageFolder.GetFileAsync("settings.json");
                }
                var settingsJson = JsonConvert.SerializeObject(_settingsModel);
                var inputStream = await storageFile.OpenAsync(FileAccessMode.ReadWrite);
                var writeStream = inputStream.GetOutputStreamAt(0);
                DataWriter writer = new DataWriter(writeStream);
                writer.WriteString(settingsJson);
                await writer.StoreAsync();
                await writeStream.FlushAsync();
                inputStream.Dispose();
                writer.Dispose();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
