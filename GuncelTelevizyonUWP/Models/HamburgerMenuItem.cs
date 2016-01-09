using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuncelTelevizyonUWP.Models
{
    public class HamburgerMenuItem
    {
        public string Icon { get; set; }
        public string Title { get; set; }
        public HamburgerMenuItemType Type { get; set; }
        public object Object { get; set; }
    }
}
