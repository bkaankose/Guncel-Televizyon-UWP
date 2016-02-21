using GuncelTelevizyonUWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace GuncelTelevizyonUWP.Helpers
{
    public static class ContextHelper
    {
        #region Properties

        private static List<ChannelStreamInformation> _streamInformations;

        public static List<ChannelStreamInformation> StreamInformations
        {
            get { return _streamInformations; }
            set { _streamInformations = value; }
        }

        private static List<Channel> _channels;

        public static List<Channel> Channels
        {
            get { return _channels; }
            set { _channels = value; }
        }

        //public static Task<bool> GetChannelFavoriteStatus(Guid channelId)
        //{

        //}

        #endregion
    }
}
