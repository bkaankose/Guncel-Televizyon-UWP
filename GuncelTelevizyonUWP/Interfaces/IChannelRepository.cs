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
        void FavoriteChannel(Guid channelId);
        void UnfavoriteChannel(Guid channelId);
        Task<ObservableCollection<ChannelStreamInformation>> GetStreamInformations();
        Task<ObservableCollection<ChannelModelView>> GetChannels(ChannelCategory category = ChannelCategory.Hepsi);
    }
}
