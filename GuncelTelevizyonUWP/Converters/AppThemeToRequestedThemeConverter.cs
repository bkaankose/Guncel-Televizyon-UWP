using GuncelTelevizyonUWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace GuncelTelevizyonUWP.Converters
{
    public class AppThemeToRequestedThemeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var sent = (AppTheme)value;
            if (sent == AppTheme.Dark)
                return ElementTheme.Dark;
            else
                return ElementTheme.Light;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
