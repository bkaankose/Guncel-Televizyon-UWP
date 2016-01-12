using GuncelTelevizyonUWP.Context;
using GuncelTelevizyonUWP.Interfaces;
using GuncelTelevizyonUWP.Models;
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
using Windows.UI.Core;

namespace GuncelTelevizyonUWP.Helpers
{
    public class BaseApplication : PrismApplication
    {
        public T Resolve<T>() => ApplicationContext.Container.Resolve<T>();
        private Assembly[] cachedAssemblies = null;
        private Dictionary<string, Type> cachedViewModels = null;

        public BaseApplication()
        {
            
        }
        
        protected override async Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            await RegisterRepositories();
            await ApplicationContext.Resolve<ISettingsRepository>().GetSettingsAsync();
            NavigationService.Navigate("Synchronization", null);
        }
        private object ViewModelFactoy(Type modelType)
        {
            return ApplicationContext.Container.Resolve(modelType);
        }
        private async Task RegisterRepositories()
        {
            ViewModelLocationProvider.SetDefaultViewModelFactory(ViewModelFactoy);
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(PinpointViewModel);

            ApplicationContext.Container.RegisterInstance<ISettingsService>(Resolve<SettingsService>());
            ApplicationContext.Container.RegisterInstance<ISettingsRepository>(Resolve<SettingsRepository>());

            ApplicationContext.Container.RegisterInstance<IChannelService>(Resolve<ChannelService>());
            ApplicationContext.Container.RegisterInstance<IChannelRepository>(Resolve<ChannelRepository>());

            ApplicationContext.Container.RegisterInstance<ISynchronizationService>(Resolve<SynchronizationService>());

            ApplicationContext.Container.RegisterInstance<IFeedbackService>(Resolve<FeedbackService>());
            ApplicationContext.Container.RegisterInstance<IDialogService>(Resolve<DialogService>());

            ApplicationContext.Container.RegisterInstance(NavigationService);
            ApplicationContext.Container.RegisterInstance(SessionStateService);
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
