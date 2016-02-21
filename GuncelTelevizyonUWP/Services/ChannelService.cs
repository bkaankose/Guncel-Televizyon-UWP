using GuncelTelevizyonUWP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuncelTelevizyonUWP.Models;
using System.Collections.ObjectModel;
using Microsoft.WindowsAzure.MobileServices;
using GuncelTelevizyonUWP.Helpers;
using GuncelTelevizyonUWP.Context;

namespace GuncelTelevizyonUWP.Services
{
    public class ChannelService : IChannelService
    {
        private MobileServiceHelper _serviceHelper;
        private ISettingsService _settingsService;
        public ChannelService(MobileServiceHelper serviceHelper,ISettingsService settingsService)
        {
            _serviceHelper = serviceHelper;
            _settingsService = settingsService;
        }
        public async Task<List<Channel>> GetChannels()
        {
            if (ContextHelper.Channels == null)
                ContextHelper.Channels = await _serviceHelper.GetTableData<Channel>();

            return ContextHelper.Channels;
        }

        public async Task<List<ChannelStreamInformation>> GetStreamInformations()
        {
            if (ContextHelper.StreamInformations == null)
                ContextHelper.StreamInformations = await _serviceHelper.GetCustomApiData<List<ChannelStreamInformation>>("Stream");

            return ContextHelper.StreamInformations;
        }

        public void FavoriteChannel(Guid channelId)
        {
            if(!ConfigurationContext.MainSettings.FavoritedChannelIds.Contains(channelId))
            {
                ConfigurationContext.MainSettings.FavoritedChannelIds.Add(channelId);
                _settingsService.SaveSettingsAsync(ConfigurationContext.MainSettings);
            }
        }

        public void UnfavoriteChannel(Guid channelId)
        {
            if (ConfigurationContext.MainSettings.FavoritedChannelIds.Contains(channelId))
            {
                ConfigurationContext.MainSettings.FavoritedChannelIds.Remove(channelId);
                _settingsService.SaveSettingsAsync(ConfigurationContext.MainSettings);
            }
        }

        //public Task<bool> IsFavorited(Guid channelId)
        //{

        //}
    }
}
