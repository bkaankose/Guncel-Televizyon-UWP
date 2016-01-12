using GuncelTelevizyonUWP.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;

namespace GuncelTelevizyonUWP.ViewModels
{
    public class AboutPageViewModel : BaseViewModel
    {
        #region Properties

        public string Version
        {
            get
            {
                return Windows.ApplicationModel.Package.Current.Id.Version.Major.ToString() + "." + Windows.ApplicationModel.Package.Current.Id.Version.Minor.ToString() + "." + Windows.ApplicationModel.Package.Current.Id.Version.Build.ToString() + "." + Windows.ApplicationModel.Package.Current.Id.Version.Revision.ToString();
            }
        }


        #endregion
        public AboutPageViewModel()
        {

        }
    }
}
