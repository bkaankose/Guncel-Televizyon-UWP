using GuncelTelevizyonUWP.Helpers;
using GuncelTelevizyonUWP.Interfaces;
using GuncelTelevizyonUWP.Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;
using Windows.System;
using Windows.UI.Popups;

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

        private Feedback _currentFeedback;

        public Feedback CurrentFeedback
        {
            get { return _currentFeedback; }
            set { _currentFeedback = value; OnPropertyChanged("CurrentFeedback"); }
        }

        #endregion

        #region Services

        IFeedbackService _feedbackService;
        #endregion

        #region Commands
        public DelegateCommand SendFeedbackCommand { get; set; }
        public DelegateCommand<object> NavigateToUrlCommand { get; set; }
        
        #endregion

        public AboutPageViewModel(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            SendFeedbackCommand = new DelegateCommand(SendFeedback);
            NavigateToUrlCommand = new DelegateCommand<object>(NavigateToUrl);
        }
        private async void SendFeedback()
        {
            if(string.IsNullOrEmpty(CurrentFeedback.FirstName) ||string.IsNullOrEmpty(CurrentFeedback.LastName) || string.IsNullOrEmpty(CurrentFeedback.EMail) || string.IsNullOrEmpty(CurrentFeedback.Message))
            {
                await new MessageDialog("Geribildirim gönderebilmek için formdaki bilgilerin hepsini doldurmak zorundasınız.").ShowAsync();
                return;
            }

            IsBusy = true;

            var feedbackResult = await _feedbackService.SendFeedbackAsync(CurrentFeedback);
            //if(feedbackResult) // Success
            IsBusy = false;
        }
        private async void NavigateToUrl(object o)
        {
            await Launcher.LaunchUriAsync(new Uri(o.ToString(), UriKind.Absolute));
        }
    }
}
