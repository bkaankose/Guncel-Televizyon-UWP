using GuncelTelevizyonUWP.Interfaces;
using Prism.Windows.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Windows.Navigation;
using GuncelTelevizyonUWP.Helpers;
using System.Collections.ObjectModel;
using GuncelTelevizyonUWP.Models;
using Prism.Commands;

namespace GuncelTelevizyonUWP.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        #region Repositories
        private ISettingsRepository _settingsRepository;
        #endregion

        #region Commands
        public DelegateCommand AnimatePaneCommand { get; set; }
        public DelegateCommand PaneClosingCommand { get; set; }

        #endregion
        #region Properties

        private bool _isPaneOpen;

        public bool IsPaneOpen
        {
            get { return _isPaneOpen; }
            set { _isPaneOpen = value; OnPropertyChanged("IsPaneOpen"); }
        }


        private ObservableCollection<ChannelCategoryItem> _channelCategoryItems;

        public ObservableCollection<ChannelCategoryItem> ChannelCategoryItems
        {
            get { return _channelCategoryItems; }
            set { _channelCategoryItems = value; OnPropertyChanged("ChannelCategoryItems"); }
        }

        #endregion

        public MainPageViewModel(ISettingsRepository settingsRepository)
        {
            _settingsRepository = settingsRepository;
        }

        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);
            InitializeCommands();

            ChannelCategoryItems = new ObservableCollection<ChannelCategoryItem>();
            ChannelCategoryItems.Add(new ChannelCategoryItem() { Icon = "", Title = "Tüm Kanallar" });
            ChannelCategoryItems.Add(new ChannelCategoryItem() { Icon = "", Title = "Tüm Kanallar" });
            ChannelCategoryItems.Add(new ChannelCategoryItem() { Icon = "", Title = "Tüm Kanallar" });
            ChannelCategoryItems.Add(new ChannelCategoryItem() { Icon = "", Title = "Tüm Kanallar" });
            ChannelCategoryItems.Add(new ChannelCategoryItem() { Icon = "", Title = "Tüm Kanallar" });
            ChannelCategoryItems.Add(new ChannelCategoryItem() { Icon = "", Title = "Tüm Kanallar" });
            ChannelCategoryItems.Add(new ChannelCategoryItem() { Icon = "", Title = "Tüm Kanallar" });
            ChannelCategoryItems.Add(new ChannelCategoryItem() { Icon = "", Title = "Tüm Kanallar" });
            ChannelCategoryItems.Add(new ChannelCategoryItem() { Icon = "", Title = "Tüm Kanallar" });
            ChannelCategoryItems.Add(new ChannelCategoryItem() { Icon = "", Title = "Tüm Kanallar" });
            ChannelCategoryItems.Add(new ChannelCategoryItem() { Icon = "", Title = "Tüm Kanallar" });
            ChannelCategoryItems.Add(new ChannelCategoryItem() { Icon = "", Title = "Tüm Kanallar" });
            ChannelCategoryItems.Add(new ChannelCategoryItem() { Icon = "", Title = "Tüm Kanallar" });
        }
        private void InitializeCommands()
        {
            AnimatePaneCommand = new DelegateCommand(AnimatePane);
            PaneClosingCommand = new DelegateCommand(PaneClosing);
        }

        private void PaneClosing()
        {
            IsPaneOpen = false;
        }
        private void AnimatePane()
        {
            IsPaneOpen = !IsPaneOpen;
        }
    }
}
