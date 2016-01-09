using GuncelTelevizyonUWP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuncelTelevizyonUWP.Repositories
{
    public class ChannelRepository : IChannelRepository
    {
        IChannelRepository _channelRepository;
        public ChannelRepository(IChannelRepository channelRepository)
        {
            _channelRepository = channelRepository;
        }
    }
}

