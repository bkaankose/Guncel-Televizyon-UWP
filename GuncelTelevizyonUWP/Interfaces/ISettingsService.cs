using GuncelTelevizyonUWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuncelTelevizyonUWP.Interfaces
{
    public interface ISettingsService
    {
        ObservableCollection<QualityEnumModel> GetQualities();
        Task<Settings> GetSettingsAsync();
        Task<bool> SaveSettingsAsync(Settings _settingsModel);
    }
}
