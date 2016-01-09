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

        private bool _isCurrentSubPageSettings;

        public bool IsCurrentSubPageSettings
        {
            get { return _isCurrentSubPageSettings; }
            set { _isCurrentSubPageSettings = value; OnPropertyChanged("IsCurrentSubPageSettings"); }
        }


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


        private ObservableCollection<HamburgerMenuItem> _hamburgerMenuItems;

        public ObservableCollection<HamburgerMenuItem> HamburgerMenuItems
        {
            get { return _hamburgerMenuItems; }
            set { _hamburgerMenuItems = value; OnPropertyChanged("HamburgerMenuItems"); }
        }

        private HamburgerMenuItem  _selectedHamburgerMenuItem;

        public HamburgerMenuItem SelectedHamburgerMenuItem
        {
            get { return _selectedHamburgerMenuItem; }
            set { _selectedHamburgerMenuItem = value; OnPropertyChanged("SelectedHamburgerMenuItem"); }
        }

        private ObservableCollection<HamburgerMenuItem> _bottomHamburgerMenuItems;

        public ObservableCollection<HamburgerMenuItem> BottomHamburgerMenuItems
        {
            get { return _bottomHamburgerMenuItems; }
            set { _bottomHamburgerMenuItems = value; OnPropertyChanged("BottomHamburgerMenuItems"); }
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

            HamburgerMenuItems = new ObservableCollection<HamburgerMenuItem>();
            BottomHamburgerMenuItems = new ObservableCollection<HamburgerMenuItem>();

            HamburgerMenuItems.Add(new HamburgerMenuItem() { Title = "Tüm Kanallar", Icon = "", Type = HamburgerMenuItemType.ChannelCategory , Object = ChannelCategory.All });
            HamburgerMenuItems.Add(new HamburgerMenuItem() { Title = "Tüm Kanallar", Icon = "", Type = HamburgerMenuItemType.ChannelCategory });
            HamburgerMenuItems.Add(new HamburgerMenuItem() { Title = "Tüm Kanallar", Icon = "", Type = HamburgerMenuItemType.ChannelCategory });
            HamburgerMenuItems.Add(new HamburgerMenuItem() { Title = "Tüm Kanallar", Icon = "", Type = HamburgerMenuItemType.ChannelCategory });
            HamburgerMenuItems.Add(new HamburgerMenuItem() { Title = "Tüm Kanallar", Icon = "", Type = HamburgerMenuItemType.ChannelCategory });
            HamburgerMenuItems.Add(new HamburgerMenuItem() { Title = "Tüm Kanallar", Icon = "", Type = HamburgerMenuItemType.ChannelCategory });
            HamburgerMenuItems.Add(new HamburgerMenuItem() { Title = "Tüm Kanallar", Icon = "", Type = HamburgerMenuItemType.ChannelCategory });

            BottomHamburgerMenuItems.Add(new HamburgerMenuItem() { Icon = "", Title = "Ayarlar", Type = HamburgerMenuItemType.Settings });

            this.PropertyChanged += MainVMPropertyChanged;
        }



        private void MainVMPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedHamburgerMenuItem" && SelectedHamburgerMenuItem != null)
            {
                switch(SelectedHamburgerMenuItem.Type)
                {
                    case HamburgerMenuItemType.Settings:
                        ChangeSubPage("Settings", null);
                        break;
                    case HamburgerMenuItemType.ChannelCategory:
                        ChangeSubPage("ChannelBrowser", SelectedHamburgerMenuItem.Object);
                        break;
                }
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
            //SelectedChannelCategoryItem = null;
            //if (o.ToString() == "Settings")
            //    IsCurrentSubPageSettings = true;

            //ChangeSubPage(o.ToString(), null);
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
