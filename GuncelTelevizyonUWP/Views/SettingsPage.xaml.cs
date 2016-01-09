﻿using GuncelTelevizyonUWP.Helpers;
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
    public sealed partial class SettingsPage : BasePage
    {
        private SettingsPageViewModel PageVM;
        public SettingsPage()
        {
            this.InitializeComponent();
            PageVM = this.DataContext as SettingsPageViewModel;
            PageVM.PropertyChanged += PageVMPropertyChanged;
        }

        private async void PageVMPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "ApplySettings")
            {
                await base.ApplySettings();
            }
        }
    }
}
