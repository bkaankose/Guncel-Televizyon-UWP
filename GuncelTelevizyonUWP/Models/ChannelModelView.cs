using GuncelTelevizyonUWP.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuncelTelevizyonUWP.Models
{
    public class ChannelModelView : Channel
    {
        public bool IsFavorited { get; set; }
        public string ChannelImage
        {
            get
            {
                return string.Format("{0}\\Images\\{1}.png", ConfigurationContext.LocalFolder.Path, this.Id);
            }
        }
    }
}
