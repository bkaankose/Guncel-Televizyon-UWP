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

namespace GuncelTelevizyonUWP.Services
{
    public class ChannelService : IChannelService
    {
        private MobileServiceHelper _serviceHelper;
        public ChannelService(MobileServiceHelper serviceHelper)
        {
            _serviceHelper = serviceHelper;
        }
        public async Task<List<Channel>> GetChannels()
        {
            return await _serviceHelper.GetTableData<Channel>();
        }

        public async Task<List<DummyChannelCurrentStreamInformation>> GetCurrentChannelInformation()
        {
            var nRet = new List<DummyChannelCurrentStreamInformation>();
            nRet.Add(new DummyChannelCurrentStreamInformation() { ChannelName = "Kanal D", StreamName = "Var Mısın Yok Musun ?", ChannelImage = "https://upload.wikimedia.org/wikipedia/tr/thumb/c/ca/Kanal_D_logo.svg/522px-Kanal_D_logo.svg.png" });
            nRet.Add(new DummyChannelCurrentStreamInformation() { ChannelName = "Kanal D", StreamName = "Var Mısın Yok Musun ?", ChannelImage = "https://upload.wikimedia.org/wikipedia/tr/thumb/c/ca/Kanal_D_logo.svg/522px-Kanal_D_logo.svg.png" });
            nRet.Add(new DummyChannelCurrentStreamInformation() { ChannelName = "Kanal D", StreamName = "Var Mısın Yok Musun ?", ChannelImage = "https://upload.wikimedia.org/wikipedia/tr/thumb/c/ca/Kanal_D_logo.svg/522px-Kanal_D_logo.svg.png" });
            nRet.Add(new DummyChannelCurrentStreamInformation() { ChannelName = "Kanal D", StreamName = "Var Mısın Yok Musun ?", ChannelImage = "https://upload.wikimedia.org/wikipedia/tr/thumb/c/ca/Kanal_D_logo.svg/522px-Kanal_D_logo.svg.png" });
            nRet.Add(new DummyChannelCurrentStreamInformation() { ChannelName = "Kanal D", StreamName = "Var Mısın Yok Musun ?", ChannelImage = "https://upload.wikimedia.org/wikipedia/tr/thumb/c/ca/Kanal_D_logo.svg/522px-Kanal_D_logo.svg.png" });
            nRet.Add(new DummyChannelCurrentStreamInformation() { ChannelName = "Kanal D", StreamName = "Var Mısın Yok Musun ?", ChannelImage = "https://upload.wikimedia.org/wikipedia/tr/thumb/c/ca/Kanal_D_logo.svg/522px-Kanal_D_logo.svg.png" });
            nRet.Add(new DummyChannelCurrentStreamInformation() { ChannelName = "Kanal D", StreamName = "Var Mısın Yok Musun ?", ChannelImage = "https://upload.wikimedia.org/wikipedia/tr/thumb/c/ca/Kanal_D_logo.svg/522px-Kanal_D_logo.svg.png" });


            return nRet;
        }
    }
}
