using GuncelTelevizyonUWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuncelTelevizyonUWP.Interfaces
{
    public interface IChannelRepository
    {
        Task<ObservableCollection<DummyChannelCurrentStreamInformation>> GetCurrentChannelInformation();
        Task<ObservableCollection<ChannelModelView>> GetChannels();
    }
}
