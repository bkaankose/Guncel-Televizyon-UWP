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
        public DelegateCommand<object> NavigateToPageCommand { get; set; }

        #endregion
        #region Properties

        private bool _isPaneOpen;

        public bool IsPaneOpen
        {
            get { return _isPaneOpen; }
            set { _isPaneOpen = value; OnPropertyChanged("IsPaneOpen"); }
        }

        private string _subPageName = "ChannelBrowser";

        public string SubPageName
        {
            get { return _subPageName; }
            set { _subPageName = value; OnPropertyChanged("SubPageName"); }
        }

        private object _subPageParameter;

        public object SubPageParameter
        {
            get { return _subPageParameter; }
            set { _subPageParameter = value; OnPropertyChanged("SubPageParameter"); }
        }


        private ObservableCollection<ChannelCategoryItem> _channelCategoryItems;

        public ObservableCollection<ChannelCategoryItem> ChannelCategoryItems
        {
            get { return _channelCategoryItems; }
            set { _channelCategoryItems = value; OnPropertyChanged("ChannelCategoryItems"); }
        }

        private ChannelCategoryItem _selectedChannelCategoryItem;

        public ChannelCategoryItem SelectedChannelCategoryItem
        {
            get { return _selectedChannelCategoryItem; }
            set { _selectedChannelCategoryItem = value; OnPropertyChanged("SelectedChannelCategoryItem"); }
        }


        #endregion

        public MainPageViewModel(ISettingsRepository settingsRepository)
        {
            _settingsRepository = settingsRepository;
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);
            InitializeCommands();

            ChannelCategoryItems = new ObservableCollection<ChannelCategoryItem>();
            ChannelCategoryItems.Add(new ChannelCategoryItem() { Icon = "", Title = "Tüm Kanallar", Category = ChannelCategory.All });
            ChannelCategoryItems.Add(new ChannelCategoryItem() { Icon = "", Title = "Tüm Kanallar", Category = ChannelCategory.All });
            ChannelCategoryItems.Add(new ChannelCategoryItem() { Icon = "", Title = "Tüm Kanallar", Category = ChannelCategory.All });
            ChannelCategoryItems.Add(new ChannelCategoryItem() { Icon = "", Title = "Tüm Kanallar", Category = ChannelCategory.All });
            ChannelCategoryItems.Add(new ChannelCategoryItem() { Icon = "", Title = "Tüm Kanallar", Category = ChannelCategory.All });
            ChannelCategoryItems.Add(new ChannelCategoryItem() { Icon = "", Title = "Tüm Kanallar", Category = ChannelCategory.All });
            ChannelCategoryItems.Add(new ChannelCategoryItem() { Icon = "", Title = "Tüm Kanallar", Category = ChannelCategory.All });
            ChannelCategoryItems.Add(new ChannelCategoryItem() { Icon = "", Title = "Tüm Kanallar", Category = ChannelCategory.All });
            ChannelCategoryItems.Add(new ChannelCategoryItem() { Icon = "", Title = "Tüm Kanallar", Category = ChannelCategory.All });
            ChannelCategoryItems.Add(new ChannelCategoryItem() { Icon = "", Title = "Tüm Kanallar", Category = ChannelCategory.All });
            ChannelCategoryItems.Add(new ChannelCategoryItem() { Icon = "", Title = "Tüm Kanallar", Category = ChannelCategory.All });
            ChannelCategoryItems.Add(new ChannelCategoryItem() { Icon = "", Title = "Tüm Kanallar", Category = ChannelCategory.All });
            ChannelCategoryItems.Add(new ChannelCategoryItem() { Icon = "", Title = "Tüm Kanallar", Category = ChannelCategory.All });

            this.PropertyChanged += MainVMPropertyChanged;
        }

        private void MainVMPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "SelectedChannelCategoryItem")
            {
                ChangeSubPage("ChannelBrowser", SelectedChannelCategoryItem);
            }
        }

        private void InitializeCommands()
        {
            AnimatePaneCommand = new DelegateCommand(AnimatePane);
            PaneClosingCommand = new DelegateCommand(PaneClosing);
            NavigateToPageCommand = new DelegateCommand<object>(NavigateToPage);
        }

        private void PaneClosing()
        {
            IsPaneOpen = false;
        }
        private void AnimatePane()
        {
            IsPaneOpen = !IsPaneOpen;
        }
        private void NavigateToPage(object o)
        {
            ChangeSubPage(o.ToString(), null);
        }
        private void ChangeSubPage(string pageName,object pageParameter)
        {
            SubPageParameter = pageParameter;
            SubPageName = pageName;
            OnPropertyChanged("SubPageChanged");
            IsPaneOpen = false;
        }
    }
}
