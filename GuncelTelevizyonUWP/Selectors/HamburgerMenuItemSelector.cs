using GuncelTelevizyonUWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace GuncelTelevizyonUWP.Selectors
{
    public class HamburgerMenuItemSelector : DataTemplateSelector
    {
        public DataTemplate SeperatorTemplate { get; set; }
        public DataTemplate MenuItemTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var sentItem = item as HamburgerMenuItem;
            return sentItem.Type == HamburgerMenuItemType.Seperator ? SeperatorTemplate : MenuItemTemplate;

        }
    }
}
