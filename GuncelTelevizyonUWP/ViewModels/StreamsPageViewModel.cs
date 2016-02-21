using GuncelTelevizyonUWP.Helpers;
using GuncelTelevizyonUWP.Interfaces;
using GuncelTelevizyonUWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Windows.Navigation;
using Prism.Commands;

namespace GuncelTelevizyonUWP.ViewModels
{
    public class StreamsPageViewModel : BaseViewModel
    {
        #region Properties

        private ObservableCollection<ChannelStreamInformation> _currentStreams;

        public ObservableCollection<ChannelStreamInformation> CurrentStreams
        {
            get { return _currentStreams; }
            set { _currentStreams = value; OnPropertyChanged("CurrentStreams"); }
        }

        //private ObservableCollection<ChannelStreamInformation> _selectedCurrentStreams;

        //public ObservableCollection<ChannelStreamInformation> SelectedCurrentStreams
        //{
        //    get { return _selectedCurrentStreams; }
        //    set { _selectedCurrentStreams = value; OnPropertyChanged("SelectedCurrentStreams"); }
        //}


        #endregion
        #region Repositories
        private readonly IChannelRepository _channelRepository;

        #endregion
        #region Commands

        public DelegateCommand SetAlarmCommand { get; set; }

        #endregion
        public StreamsPageViewModel(IChannelRepository channelRepository)
        {
            _channelRepository = channelRepository;
            InitializeCommands();
            
            CurrentStreams = new ObservableCollection<ChannelStreamInformation>();
        }

        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);

            var parameter = e.Parameter;
            if (parameter == null) // List current streams
                CurrentStreams = await OperateAsyncOperation(_channelRepository.GetStreamInformations(), "Yayın akışları yükleniyor");
            else if (parameter.GetType() == typeof(int)) // Navigated with the channelId , list streams of that channel.
                CurrentStreams.Add((await OperateAsyncOperation(_channelRepository.GetStreamInformations(), "Yayın akışları yükleniyor")).FirstOrDefault(a => a.ChannelId == Guid.Parse(parameter.ToString())));
        }

        private void InitializeCommands()
        {
            //SetAlarmCommand = new DelegateCommand(SetAlarm);
        }
        //private void SetAlarm()
        //{
        //    if(SelectedCurrentStreams != null && SelectedCurrentStreams.Count > 0)
        //    {
        //        // TODO : Set an alarm for selected streams
        //    }
        //}
    }
}
