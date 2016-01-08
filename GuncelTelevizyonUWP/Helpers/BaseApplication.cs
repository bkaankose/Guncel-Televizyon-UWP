using GuncelTelevizyonUWP.Interfaces;
using GuncelTelevizyonUWP.Repositories;
using GuncelTelevizyonUWP.Services;
using Microsoft.Practices.Unity;
using Prism.Mvvm;
using Prism.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;

namespace GuncelTelevizyonUWP.Helpers
{
    public class BaseApplication : PrismApplication
    {
        public T Resolve<T>() => _container.Resolve<T>();
        private Assembly[] cachedAssemblies = null;
        private Dictionary<string, Type> cachedViewModels = null;
        private IUnityContainer _container { get; }
        public BaseApplication()
        {
            _container = new UnityContainer();
            var settingsService = Resolve<SettingsService>();
            var mainSettings = settingsService.GetSettingsAsync();
            if (mainSettings.Result.Theme == Models.AppTheme.Dark)
                base.RequestedTheme = Windows.UI.Xaml.ApplicationTheme.Dark;
            else
                base.RequestedTheme = Windows.UI.Xaml.ApplicationTheme.Light;
        }

        protected override async Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            // Override requested theme
            

            await RegisterRepositories();
            NavigationService.Navigate("Main", null);
        }
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
                    ?? a.GetType($"GuncelTelevizyonUWP.ViewModels.{tn}");

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
    }
}
