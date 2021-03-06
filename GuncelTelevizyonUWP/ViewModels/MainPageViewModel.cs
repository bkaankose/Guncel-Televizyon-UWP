﻿using GuncelTelevizyonUWP.Interfaces;
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

        private string _currentPageTitle = "Kanallar";

        public string CurrentPageTitle
        {
            get { return _currentPageTitle; }
            set { _currentPageTitle = value; OnPropertyChanged("CurrentPageTitle"); }
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

            HamburgerMenuItems.Add(new HamburgerMenuItem() { Title = "Tüm Kanallar", Icon = "", Type = HamburgerMenuItemType.ChannelCategory , Object = ChannelCategory.Hepsi });
            HamburgerMenuItems.Add(new HamburgerMenuItem() { Title = "Ulusal", Icon = "", Type = HamburgerMenuItemType.ChannelCategory , Object = ChannelCategory.Ulusal });
            HamburgerMenuItems.Add(new HamburgerMenuItem() { Title = "Haber", Icon = "", Type = HamburgerMenuItemType.ChannelCategory, Object = ChannelCategory.Haber });
            HamburgerMenuItems.Add(new HamburgerMenuItem() { Title = "Spor", Icon = "", Type = HamburgerMenuItemType.ChannelCategory, Object = ChannelCategory.Spor });
            HamburgerMenuItems.Add(new HamburgerMenuItem() { Title = "Müzik", Icon = "", Type = HamburgerMenuItemType.ChannelCategory, Object = ChannelCategory.Muzik });
            HamburgerMenuItems.Add(new HamburgerMenuItem() { Title = "Belgesel", Icon = "", Type = HamburgerMenuItemType.ChannelCategory, Object = ChannelCategory.Belgesel });
            HamburgerMenuItems.Add(new HamburgerMenuItem() { Title = "Eğlence", Icon = "   ", Type = HamburgerMenuItemType.ChannelCategory, Object = ChannelCategory.Eglence });
            HamburgerMenuItems.Add(new HamburgerMenuItem() { Title = "Çocuk", Icon = "", Type = HamburgerMenuItemType.ChannelCategory, Object = ChannelCategory.Cocuk });
            HamburgerMenuItems.Add(new HamburgerMenuItem() { Title = "Moda", Icon = "", Type = HamburgerMenuItemType.ChannelCategory, Object = ChannelCategory.Moda });
            HamburgerMenuItems.Add(new HamburgerMenuItem() { Title = "Sinema", Icon = "", Type = HamburgerMenuItemType.ChannelCategory, Object = ChannelCategory.Sinema });

            BottomHamburgerMenuItems.Add(new HamburgerMenuItem() { Icon = "", Title = "Yayın Akışı", Type = HamburgerMenuItemType.CurrentStreams });
            BottomHamburgerMenuItems.Add(new HamburgerMenuItem() { Icon = "", Title = "Ayarlar", Type = HamburgerMenuItemType.Settings });
            BottomHamburgerMenuItems.Add(new HamburgerMenuItem() { Icon = "", Title = "Hakkında", Type = HamburgerMenuItemType.About });


            this.PropertyChanged += MainVMPropertyChanged;
        }



        private void MainVMPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedHamburgerMenuItem" && SelectedHamburgerMenuItem != null)
            {
                switch(SelectedHamburgerMenuItem.Type)
                {
                    case HamburgerMenuItemType.Settings:
                        ChangeSubPage("Settings", null,"Ayarlar");
                        break;
                    case HamburgerMenuItemType.ChannelCategory:
                        ChangeSubPage("ChannelBrowser", SelectedHamburgerMenuItem.Object , "Kanallar");
                        break;
                    case HamburgerMenuItemType.CurrentStreams:
                        ChangeSubPage("Streams", null,"Yayın Akışı");
                        break;
                    case HamburgerMenuItemType.About:
                        ChangeSubPage("About", null,"Hakkında");
                        break;
                }
            }
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
        private void ChangeSubPage(string pageName,object pageParameter,string pageTitle)
        {
            CurrentPageTitle = pageTitle;
            SubPageParameter = pageParameter;
            SubPageName = pageName;
            OnPropertyChanged("SubPageChanged");
            IsPaneOpen = false;
        }
    }
}
