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
using Prism.Commands;

namespace GuncelTelevizyonUWP.ViewModels
{
    public class ChannelBrowserPageViewModel : BaseViewModel
    {
        #region Properties

        private ObservableCollection<ChannelModelView> _currentChannels;

        public ObservableCollection<ChannelModelView> CurrentChannels
        {
            get { return _currentChannels; }
            set { _currentChannels = value; OnPropertyChanged("CurrentChannels"); }
        }

        private ChannelModelView _selectedChannel;

        public ChannelModelView SelectedChannel
        {
            get { return _selectedChannel; }
            set { _selectedChannel = value; OnPropertyChanged("SelectedChannel"); }
        }



        #endregion

        #region Commands

        public DelegateCommand FavoriteChannelCommand { get; set; }
        public DelegateCommand UnFavoriteChannelCommand { get; set; }
        public DelegateCommand WatchCommand { get; set; }

        #endregion
        private IChannelRepository _channelRepository;
        private INavigationService _navigationService;
        public ChannelBrowserPageViewModel(IChannelRepository channelRepository,INavigationService navigationService)
        {
            _channelRepository = channelRepository;
            _navigationService = navigationService;

            InitializeCommands();
        }
        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);
            ChannelCategory param = ChannelCategory.Hepsi;

            if(e.Parameter != null) // Navigated with channel category
                param = (ChannelCategory)e.Parameter;

            CurrentChannels = await _channelRepository.GetChannels(param);

        }

        private void InitializeCommands()
        {
            FavoriteChannelCommand = new DelegateCommand(FavoriteChannel);
            UnFavoriteChannelCommand = new DelegateCommand(UnFavoriteChannel);
            WatchCommand = new DelegateCommand(Watch);
        }
        private void FavoriteChannel()
        {
            _channelRepository.FavoriteChannel(SelectedChannel.Channel.Id);
            SelectedChannel.IsFavorited = true;
        }

        private void UnFavoriteChannel()
        {
            _channelRepository.UnfavoriteChannel(SelectedChannel.Channel.Id);
            SelectedChannel.IsFavorited = false;
        }
        private void Watch()
        {
            _navigationService.Navigate("Watch", SelectedChannel);
        }

    }
}
