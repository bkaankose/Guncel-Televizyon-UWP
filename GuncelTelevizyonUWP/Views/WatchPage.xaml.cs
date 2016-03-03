using GuncelTelevizyonUWP.Helpers;
using GuncelTelevizyonUWP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace GuncelTelevizyonUWP.Views
{
    public sealed partial class WatchPage : BasePage
    {
        private WatchPageViewModel ViewModel;
        public WatchPage()
        {
            this.InitializeComponent();
            ViewModel = this.DataContext as WatchPageViewModel;
            ViewModel.PropertyChanged += PropChanged;
        }

        private void PropChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "CurrentSource" && ViewModel.CurrentSource != null)
                mediaElement.SetMediaStreamSource(ViewModel.CurrentSource);
        }

        private void SplitView_PaneClosed(SplitView sender, object args)
        {
            ViewModel.IsChannelsMenuOpen = false;
        }

        private void BitrateChangedEvent(object sender, SelectionChangedEventArgs e)
        {
            HideAppBarFlyout("BitrateAppBarButton");
        }

        private void DisposeFlyouts()
        {
            HideAppBarFlyout("BitrateAppBarButton");
            HideAppBarFlyout("ChannelsAppBarButton");
        }

        private void HideAppBarFlyout(string AppBarButtonName)
        {
            (ChildTemplateControlHelper.FindChildControl<AppBarButton>(mediaElement.TransportControls, AppBarButtonName) as AppBarButton).Flyout.Hide();
        }

        private void ChannelChangedEvent(object sender, SelectionChangedEventArgs e)
        {
            HideAppBarFlyout("ChannelsAppBarButton");
        }
    }
}
