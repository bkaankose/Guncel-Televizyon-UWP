using GuncelTelevizyonUWP.Helpers;
using GuncelTelevizyonUWP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuncelTelevizyonUWP.ViewModels
{
    public class CurrentStreamsPageViewModel : BaseViewModel
    {
        #region Repositories
        private readonly IChannelRepository _channelRepository;

        #endregion
        public CurrentStreamsPageViewModel(IChannelRepository channelRepository)
        {
            _channelRepository = channelRepository;
        }
    }
}
