using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuncelTelevizyonUWP.Context
{
    public static class ApplicationContext
    {
        public static T Resolve<T>() => Container.Resolve<T>();
        public static IUnityContainer Container = new UnityContainer();

    }
}
