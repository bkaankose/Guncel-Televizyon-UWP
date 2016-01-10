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
        #endregion
        private IChannelRepository _channelRepository; 
        public ChannelBrowserPageViewModel(IChannelRepository channelRepository)
        {
            _channelRepository = channelRepository;
            InitializeCommands();
        }
        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);
            CurrentChannels = await _channelRepository.GetChannels();
        }

        private void InitializeCommands()
        {
            FavoriteChannelCommand = new DelegateCommand(FavoriteChannel);
            UnFavoriteChannelCommand = new DelegateCommand(UnFavoriteChannel);
        }
        private void FavoriteChannel()
        {

        }

        private void UnFavoriteChannel()
        {

        }


    }
}
