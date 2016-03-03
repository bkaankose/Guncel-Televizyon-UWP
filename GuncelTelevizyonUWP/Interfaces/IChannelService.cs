using GuncelTelevizyonUWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuncelTelevizyonUWP.Interfaces
{
    public interface IChannelService
    {

        Task<List<ChannelStreamInformation>> GetStreamInformations();
        Task<List<Channel>> GetChannels();
        Task<string> GetSpecialChannelUrl(Guid channelId);
        void FavoriteChannel(Guid channelId);
        void UnfavoriteChannel(Guid channelId);
        
    }
}
