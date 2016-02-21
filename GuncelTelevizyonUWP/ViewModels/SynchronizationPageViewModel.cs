using GuncelTelevizyonUWP.Helpers;
using GuncelTelevizyonUWP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Windows.Navigation;
using System.Collections.ObjectModel;
using GuncelTelevizyonUWP.Models;
using GuncelTelevizyonUWP.Context;

namespace GuncelTelevizyonUWP.ViewModels
{
    public class SynchronizationPageViewModel : BaseViewModel
    {
        #region Services

        ISynchronizationService _synchronizationService;
        IChannelService _channelService;
        #endregion

        #region Properties

        private string _informationText;

        public string InformationText
        {
            get { return _informationText; }
            set { _informationText = value; OnPropertyChanged("InformationText"); }
        }

        private int _percentage;

        public int Percentage
        {
            get { return _percentage; }
            set { _percentage = value; OnPropertyChanged("Percentage"); }
        }

        #endregion

        public SynchronizationPageViewModel(ISynchronizationService synchronizationService,IChannelService channelService)
        {
            _synchronizationService = synchronizationService;
            _channelService = channelService;

            _synchronizationService.ProgressChanged += _synchronizationService_ProgressChanged;
        }

        private void _synchronizationService_ProgressChanged(object sender, int e)
        {
            Percentage = e;
        }

        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);
            var channels = await _channelService.GetChannels();

            foreach(var channel in channels)
            {
                InformationText = string.Format("{0} yükleniyor", channel.Name);
                await _synchronizationService.SynchronizeChannelImage(channel.Id);
            }

            navigationService.Navigate("Main", null);
        }
    }
}
