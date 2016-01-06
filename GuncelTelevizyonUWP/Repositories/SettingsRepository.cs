using GuncelTelevizyonUWP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuncelTelevizyonUWP.Models;
using GuncelTelevizyonUWP.Services;

namespace GuncelTelevizyonUWP.Repositories
{
    public class SettingsRepository : ISettingsRepository
    {
        private ISettingsService _settingsService;
        public SettingsRepository(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public async Task<Settings> GetSettingsAsync()
        {
            return await _settingsService.GetSettingsAsync();
        }

        public async Task<bool> SaveSettingsAsync(Settings _settingsModel)
        {
            return await _settingsService.SaveSettingsAsync(_settingsModel);
        }
    }
}
