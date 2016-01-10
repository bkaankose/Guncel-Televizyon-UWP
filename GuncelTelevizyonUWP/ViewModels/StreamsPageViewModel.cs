﻿using GuncelTelevizyonUWP.Helpers;
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

        private ObservableCollection<DummyChannelCurrentStreamInformation> _currentStreams;

        public ObservableCollection<DummyChannelCurrentStreamInformation> CurrentStreams
        {
            get { return _currentStreams; }
            set { _currentStreams = value; OnPropertyChanged("CurrentStreams"); }
        }

        private ObservableCollection<DummyChannelCurrentStreamInformation> _selectedCurrentStreams;

        public ObservableCollection<DummyChannelCurrentStreamInformation> SelectedCurrentStreams
        {
            get { return _selectedCurrentStreams; }
            set { _selectedCurrentStreams = value; OnPropertyChanged("SelectedCurrentStreams"); }
        }


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
            SelectedCurrentStreams = new ObservableCollection<DummyChannelCurrentStreamInformation>();
        }

        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);

            var parameter = e.Parameter;
            if (parameter == null) // List current streams
                CurrentStreams = await _channelRepository.GetCurrentChannelInformation();
            else if (parameter.GetType() == typeof(int)) // Navigated with the channelId , list streams of that channel.
            {

            }
        }

        private void InitializeCommands()
        {
            SetAlarmCommand = new DelegateCommand(SetAlarm);
        }
        private void SetAlarm()
        {
            if(SelectedCurrentStreams != null && SelectedCurrentStreams.Count > 0)
            {
                // TODO : Set an alarm for selected streams
            }
        }
    }
}