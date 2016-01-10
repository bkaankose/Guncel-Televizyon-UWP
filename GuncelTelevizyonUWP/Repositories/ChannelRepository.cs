using GuncelTelevizyonUWP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuncelTelevizyonUWP.Models;
using System.Collections.ObjectModel;

namespace GuncelTelevizyonUWP.Repositories
{
    public class ChannelRepository : IChannelRepository
    {
        IChannelService _channelService;
        public ChannelRepository(IChannelService channelService)
        {
            _channelService = channelService;
        }

        public async Task<ObservableCollection<ChannelModelView>> GetChannels()
        {
            return await _channelService.GetChannels();
        }

        public async Task<ObservableCollection<DummyChannelCurrentStreamInformation>> GetCurrentChannelInformation()
        {
            return await _channelService.GetCurrentChannelInformation();
        }
    }
}

