using GuncelTelevizyonUWP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuncelTelevizyonUWP.Models;
using System.Collections.ObjectModel;
using GuncelTelevizyonUWP.Context;

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
            var _ret = new ObservableCollection<ChannelModelView>();
            var mainChannels = await _channelService.GetChannels();
            foreach (var channel in mainChannels)
            {
                var model = new ChannelModelView(channel);
                try
                {
                    var channelImageFile = await ConfigurationContext.LocalFolder.GetItemAsync(string.Format("Images\\{0}.png", model.Channel.Id.Trim()));
                    if (channelImageFile != null)
                        model.HasChannelImage = true;
                    else
                        model.HasChannelImage = false;
                }
                catch (Exception)
                {
                    model.HasChannelImage = false;
                }


                // TODO : Set favorite
                _ret.Add(model);
            }

            return _ret;
        }

        public async Task<ObservableCollection<DummyChannelCurrentStreamInformation>> GetCurrentChannelInformation()
        {
            return new ObservableCollection<DummyChannelCurrentStreamInformation>(await _channelService.GetCurrentChannelInformation());
        }
    }
}

