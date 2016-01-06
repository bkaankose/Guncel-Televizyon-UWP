using GuncelTelevizyonUWP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuncelTelevizyonUWP.Models;
using Windows.Storage;

namespace GuncelTelevizyonUWP.Services
{
    public class SettingsService : ISettingsService
    {
        public async Task<Settings> GetSettingsAsync()
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile settingsJson = await storageFolder.GetFileAsync("settings.json");

            return null;
        }

        public Task<bool> SaveSettingsAsync(Settings _settingsModel)
        {
            throw new NotImplementedException();
        }
    }
}
