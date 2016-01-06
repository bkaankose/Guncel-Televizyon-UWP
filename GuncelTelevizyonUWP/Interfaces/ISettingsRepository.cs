using GuncelTelevizyonUWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuncelTelevizyonUWP.Interfaces
{
    public interface ISettingsRepository
    {
        Task<Settings> GetSettingsAsync();
        Task<bool> SaveSettingsAsync(Settings _settingsModel);
    }
}
