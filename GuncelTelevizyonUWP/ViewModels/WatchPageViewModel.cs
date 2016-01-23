using GuncelTelevizyonUWP.Helpers;
using GuncelTelevizyonUWP.Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuncelTelevizyonUWP.ViewModels
{
    public class WatchPageViewModel : BaseViewModel
    {

        #region Properties

        private bool _isChannelsMenuOpen;

        public bool IsChannelsMenuOpen
        {
            get { return _isChannelsMenuOpen; }
            set { _isChannelsMenuOpen = value; OnPropertyChanged("IsChannelsMenuOpen"); }
        }


        private Uri _currentSource;

        public Uri CurrentSource
        {
            get { return _currentSource; }
            set { _currentSource = value; OnPropertyChanged("CurrentSource"); }
        }

        private Channel _currentChannel;

        public Channel CurrentChannel
        {
            get { return _currentChannel; }
            set { _currentChannel = value; OnPropertyChanged("CurrentChannel"); }
        }



        #endregion

        #region Commands

        public DelegateCommand PaneClosingCommand { get; set; }
        public DelegateCommand OpenPaneCommand { get; set; }

        #endregion
        public WatchPageViewModel()
        {
            CurrentSource = new Uri("http://mn-l.mncdn.com/showtv/showtv2/playlist.m3u8", UriKind.Absolute);
            PaneClosingCommand = new DelegateCommand(new Action(() => IsChannelsMenuOpen = false));
            OpenPaneCommand = new DelegateCommand(new Action(() =>
            {
                IsChannelsMenuOpen = true;
            }));
        }
    }
}
