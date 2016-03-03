using GuncelTelevizyonUWP.Helpers;
using GuncelTelevizyonUWP.Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Streaming.Adaptive;
using Prism.Windows.Navigation;
using GuncelTelevizyonUWP.Interfaces;
using System.Collections.ObjectModel;
using ByteSizeLib;
using System.Diagnostics;
using Newtonsoft.Json;

namespace GuncelTelevizyonUWP.ViewModels
{
    public class WatchPageViewModel : BaseViewModel
    {

        #region Properties
        private IEnumerable<IGrouping<ChannelCategory, ChannelModelView>> _groupedChannels;

        public IEnumerable<IGrouping<ChannelCategory, ChannelModelView>> GroupedChannels
        {
            get { return _groupedChannels; }
            set { _groupedChannels = value; OnPropertyChanged("GroupedChannels"); }
        }



        private bool _isChannelsMenuOpen;

        public bool IsChannelsMenuOpen
        {
            get { return _isChannelsMenuOpen; }
            set { _isChannelsMenuOpen = value; OnPropertyChanged("IsChannelsMenuOpen"); }
        }


        private AdaptiveMediaSource _currentSource;

        public AdaptiveMediaSource CurrentSource
        {
            get { return _currentSource; }
            set { _currentSource = value; OnPropertyChanged("CurrentSource"); }
        }

        private ChannelModelView _currentChannel;

        public ChannelModelView CurrentChannel
        {
            get { return _currentChannel; }
            set { _currentChannel = value; OnPropertyChanged("CurrentChannel"); }
        }

        private ObservableCollection<ChannelModelView> _allChannels;

        public ObservableCollection<ChannelModelView> AllChannels
        {
            get { return _allChannels; }
            set { _allChannels = value; OnPropertyChanged("AllChannels"); }
        }

        private ObservableCollection<BitrateModelView> _availableBitrates;

        public ObservableCollection<BitrateModelView> AvailableBitrates
        {
            get { return _availableBitrates; }
            set { _availableBitrates = value;  }
        }

        private BitrateModelView _selectedBitrate;

        public BitrateModelView SelectedBitrate
        {
            get { return _selectedBitrate; }
            set { _selectedBitrate = value; OnPropertyChanged("SelectedBitrate"); }
        }

        #endregion

        #region Commands
        

        #endregion

        #region Services & Repositories

        private readonly INavigationService _navigationService;
        private readonly IDialogService _dialogService;
        private readonly IChannelRepository _channelRepository;
        #endregion
        public WatchPageViewModel(INavigationService navigationService,IDialogService dialogService,IChannelRepository channelRepository)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            _channelRepository = channelRepository;
        }

        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);

            this.PropertyChanged += PropChanged;
            AllChannels = await OperateAsyncOperation(_channelRepository.GetChannels(ChannelCategory.Hepsi));

            CurrentChannel = AllChannels.FirstOrDefault(a => a.Channel.Id == (JsonConvert.DeserializeObject<ChannelModelView>(e.Parameter.ToString())).Channel.Id);
        }

        private async void PropChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CurrentChannel))
            {
                if(!CurrentChannel.Channel.IsSpecial) // Normal channel
                    OperateMediaStreamResult(await AdaptiveMediaSource.CreateFromUriAsync(new Uri(CurrentChannel.Channel.URL, UriKind.RelativeOrAbsolute)));
                else // Special channel, request for a valid stream url.
                {

                }
            }
            else if (e.PropertyName == nameof(CurrentSource) && CurrentSource != null)
            {
                AvailableBitrates = new ObservableCollection<BitrateModelView>();
                foreach (var bitrate in CurrentSource.AvailableBitrates.Where(a => a != 0))
                    AvailableBitrates.Add(new BitrateModelView() { Bitrate = bitrate });

                OnPropertyChanged("AvailableBitrates");
                if(CurrentSettings.PreferedQuality == QualityEnumModel.Düşük)
                    SelectedBitrate = AvailableBitrates.OrderBy(b => b.Bitrate).FirstOrDefault(a => a.Bitrate == CurrentSource.CurrentPlaybackBitrate);
                else if(CurrentSettings.PreferedQuality == QualityEnumModel.Yüksek)
                    SelectedBitrate = AvailableBitrates.OrderByDescending(b => b.Bitrate).FirstOrDefault(a => a.Bitrate == CurrentSource.CurrentPlaybackBitrate);
                else if(CurrentSettings.PreferedQuality == QualityEnumModel.Orta)
                    SelectedBitrate = AvailableBitrates.OrderBy(b => b.Bitrate).FirstOrDefault(a => a.Bitrate == AvailableBitrates[AvailableBitrates.Count / 2].Bitrate);
            }
            else if (e.PropertyName == nameof(SelectedBitrate) && SelectedBitrate != null && CurrentSource != null && SelectedBitrate.Bitrate != CurrentSource.CurrentPlaybackBitrate)
                CurrentSource.DesiredMinBitrate = SelectedBitrate.Bitrate;
            else if (e.PropertyName == nameof(AllChannels))
                GroupedChannels = AllChannels.OrderBy(b => b.Channel.Name).GroupBy(a => a.Channel.Category);
        }

        private async void OperateMediaStreamResult(AdaptiveMediaSourceCreationResult result)
        {
            switch(result.Status)
            {
                case AdaptiveMediaSourceCreationStatus.Success:
                    CurrentSource = result.MediaSource;
                    CurrentSource.DownloadBitrateChanged += (c, r) => { Debug.WriteLine("Download : {0}", CurrentSource.CurrentDownloadBitrate); };
                    CurrentSource.PlaybackBitrateChanged += (c, r) => { Debug.WriteLine("Playback : {0}", CurrentSource.CurrentPlaybackBitrate); };
                    break;
                default:
                    var reportResult = await _dialogService.ShowConfirmationDialogAsync(string.Format("Show TV yüklenemedi."), ":(");
                    if(reportResult)
                    {
                        // TODO : Report channel
                    }
                    break;
            }
        }
    }
}
