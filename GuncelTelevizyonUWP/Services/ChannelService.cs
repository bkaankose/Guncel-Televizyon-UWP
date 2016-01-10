using GuncelTelevizyonUWP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuncelTelevizyonUWP.Models;
using System.Collections.ObjectModel;

namespace GuncelTelevizyonUWP.Services
{
    public class ChannelService : IChannelService
    {
        public async Task<ObservableCollection<ChannelModelView>> GetChannels()
        {
            var nRet = new ObservableCollection<ChannelModelView>();

            nRet.Add(new ChannelModelView() { Id = 1, IsFavorited = true, IsPrivate = false, Name = "Kanal D", CurrentStream = "En Son Babalar Duyar" ,  StreamUrl = "" });
            nRet.Add(new ChannelModelView() { Id = 1, IsFavorited = false, IsPrivate = false, Name = "Kanal D", CurrentStream = "En Son Babalar Duyar", StreamUrl = "" });
            nRet.Add(new ChannelModelView() { Id = 1, IsFavorited = false, IsPrivate = false, Name = "Kanal D", CurrentStream = "En Son Babalar Duyar", StreamUrl = "" });
            nRet.Add(new ChannelModelView() { Id = 1, IsFavorited = false, IsPrivate = false, Name = "Kanal D", CurrentStream = "En Son Babalar Duyar", StreamUrl = "" });
            nRet.Add(new ChannelModelView() { Id = 1, IsFavorited = false, IsPrivate = false, Name = "Kanal D", CurrentStream = "En Son Babalar Duyar", StreamUrl = "" });
            nRet.Add(new ChannelModelView() { Id = 1, IsFavorited = false, IsPrivate = false, Name = "Kanal D", CurrentStream = "En Son Babalar Duyar", StreamUrl = "" });
            nRet.Add(new ChannelModelView() { Id = 1, IsFavorited = false, IsPrivate = false, Name = "Kanal D", CurrentStream = "En Son Babalar Duyar", StreamUrl = "" });
            nRet.Add(new ChannelModelView() { Id = 1, IsFavorited = false, IsPrivate = false, Name = "Kanal D", CurrentStream = "En Son Babalar Duyar", StreamUrl = "" });
            nRet.Add(new ChannelModelView() { Id = 1, IsFavorited = false, IsPrivate = false, Name = "Kanal D", CurrentStream = "En Son Babalar Duyar", StreamUrl = "" });

            return nRet;
        }

        public async Task<ObservableCollection<DummyChannelCurrentStreamInformation>> GetCurrentChannelInformation()
        {
            var nRet = new ObservableCollection<DummyChannelCurrentStreamInformation>();
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
