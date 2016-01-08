using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace GuncelTelevizyonUWP.Helpers
{
    public class SubPage : Frame
    {

        #region DependencyProperties
        public string PageName
        {
            get { return (string)GetValue(PageNameProperty); }
            set { SetValue(PageNameProperty, value); }
        }

        public static readonly DependencyProperty PageNameProperty =
            DependencyProperty.Register("PageName", typeof(string), typeof(Frame), null);





        public object PageParameter
        {
            get { return (object)GetValue(PageParameterProperty); }
            set { SetValue(PageParameterProperty, value); }
        }

        public static readonly DependencyProperty PageParameterProperty =
            DependencyProperty.Register("PageParameter", typeof(object), typeof(Frame), null);

        #endregion
        public SubPage()
        {
            this.Loaded += SubPage_Loaded;
            
        }

        private void SubPage_Loaded(object sender, RoutedEventArgs e)
        {
            Type type = GetPageTypeByName(PageName);
            if (type == null)
                Debugger.Break(); // debug

            var control = Activator.CreateInstance(type) as SessionStateAwarePage;

            (control.DataContext as BaseViewModel).OnNavigatedTo(new NavigatedToEventArgs() { NavigationMode = NavigationMode.New, Parameter = PageParameter }, null);
            this.Content = new Grid();
            (this.Content as Grid).Children.Clear();
            (this.Content as Grid).Children.Add(control);
        }

        public virtual Type GetPageTypeByName(string pageToken)
        {
            var viewType = ReflectionHelper.GetType(string.Format("GuncelTelevizyonUWP.Views.{0}Page", pageToken));
            return viewType;
        }
    }
}
