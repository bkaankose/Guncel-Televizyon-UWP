using Prism.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Microsoft.Practices.Unity;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;
using GuncelTelevizyonUWP.Views;
using Prism.Windows.Mvvm;
using GuncelTelevizyonUWP.Interfaces;
using GuncelTelevizyonUWP.Repositories;
using GuncelTelevizyonUWP.Services;
using System.Reflection;
using GuncelTelevizyonUWP.Helpers;
using Prism.Mvvm;

namespace GuncelTelevizyonUWP
{
    sealed partial class App : BaseApplication
    {
        public App()
        {
            this.InitializeComponent();
            
        }
    }
}
