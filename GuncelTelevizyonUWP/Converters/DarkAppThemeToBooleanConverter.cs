using GuncelTelevizyonUWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace GuncelTelevizyonUWP.Converters
{
    public class DarkAppThemeToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null) // Unexpected
                return false;

            var sentValue = (AppTheme)value;
            return sentValue == AppTheme.Dark ? true : false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value == null) // Unexpected
                return false;

            var sentValue = (bool)value;
            return sentValue == true ? AppTheme.Dark : AppTheme.Light;
        }
    }
}
