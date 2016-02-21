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


        public async Task<ObservableCollection<ChannelModelView>> GetChannels(ChannelCategory category = ChannelCategory.Hepsi)
        {
            var _ret = new ObservableCollection<ChannelModelView>();
            var mainChannels = await _channelService.GetChannels();
            if (category != ChannelCategory.Hepsi)
                mainChannels = mainChannels.Where(a => a.Category == category).ToList();

            var streamInformations = await _channelService.GetStreamInformations();
            foreach (var channel in mainChannels)
            {
                var model = new ChannelModelView(channel);
                try
                {
                    var channelImageFile = await ConfigurationContext.LocalFolder.GetItemAsync(string.Format("Images\\{0}.png", model.Channel.Id));
                    if (channelImageFile != null)
                        model.HasChannelImage = true;
                    else
                        model.HasChannelImage = false;
                }
                catch (Exception)
                {
                    model.HasChannelImage = false;
                }

                model.CurrentStream = await GetExactCurrentStreamByChannel(model.Channel.Id);
                if (ConfigurationContext.MainSettings.FavoritedChannelIds.Contains(model.Channel.Id))
                    model.IsFavorited = true;
                else
                    model.IsFavorited = false;

                _ret.Add(model);
            }

            return _ret;
        }

        private async Task<StreamInformation> GetExactCurrentStreamByChannel(Guid channelId)
        {
            var streamInformations = (await _channelService.GetStreamInformations()).FirstOrDefault(a => a.ChannelId == channelId);

            if (streamInformations == null)
                return null;

            return streamInformations.DailyStreams.LastOrDefault(a => DateTime.Now > a.StartTime);
        }

        public async Task<ObservableCollection<ChannelStreamInformation>> GetStreamInformations()
        {
            return new ObservableCollection<ChannelStreamInformation>(await _channelService.GetStreamInformations());
        }

        public void FavoriteChannel(Guid channelId)
        {
            _channelService.FavoriteChannel(channelId);
        }

        public void UnfavoriteChannel(Guid channelId)
        {
            _channelService.UnfavoriteChannel(channelId);
        }
    }
}

