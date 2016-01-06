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
    sealed partial class App : PrismApplication
    {
        public T Resolve<T>() => _container.Resolve<T>();
        private Assembly[] cachedAssemblies = null;
        private Dictionary<string, Type> cachedViewModels = null;
        private IUnityContainer _container { get; }
        public App()
        {
            this.InitializeComponent();
            _container = new UnityContainer();
        }

        protected override async Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            await RegisterRepositories();
            NavigationService.Navigate("Main", null);
        }

        private Type PinpointViewModel(Type viewType)
        {
            var viewModelProperty = viewType.GetRuntimeProperty("ViewModel");
            if (viewModelProperty != null)
                return viewModelProperty.PropertyType;

            var tn = viewType.Name + "ViewModel";

            if (cachedViewModels != null && cachedViewModels.ContainsKey(tn))
                return cachedViewModels[tn];

            if (cachedAssemblies == null)
            {
                cachedAssemblies = ReflectionHelper.GetAssemblies().ToArray();
            }

            foreach (var a in cachedAssemblies)
            {
                var vm =
                    a.GetType($"{a.GetName().Name}.ViewModels.{tn}")
                    ?? a.GetType($"Tcm.Sfa.ViewModels.{tn}"); // hack

                if (vm != null)
                {
                    if (cachedViewModels == null) cachedViewModels = new Dictionary<string, Type>();
                    if (!cachedViewModels.ContainsKey(tn))
                        cachedViewModels.Add(tn, vm);

                    return vm;
                }
            }

            return null;
        }
        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        /// 

        private object ViewModelFactoy(Type modelType)
        {
            return _container.Resolve(modelType);
        }
        private async Task RegisterRepositories()
        {
            ViewModelLocationProvider.SetDefaultViewModelFactory(ViewModelFactoy);
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(PinpointViewModel);

            _container.RegisterInstance<ISettingsService>(Resolve<SettingsService>());
            _container.RegisterInstance<ISettingsRepository>(Resolve<SettingsRepository>());
            //var a = Resolve<SettingsRepository>();

        }
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
