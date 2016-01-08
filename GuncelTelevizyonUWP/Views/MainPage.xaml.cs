using GuncelTelevizyonUWP.Helpers;
using GuncelTelevizyonUWP.ViewModels;
using Prism.Windows.Mvvm;

namespace GuncelTelevizyonUWP.Views
{
    public sealed partial class MainPage : BasePage
    {
        private MainPageViewModel MainVM;
        public MainPage()
        {
            this.InitializeComponent();
            MainVM = this.DataContext as MainPageViewModel;
            MainVM.PropertyChanged += VMPropertyChanged;
        }

        private void VMPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "SubPageChanged")
                subView.SetContent();
        }
    }
}
