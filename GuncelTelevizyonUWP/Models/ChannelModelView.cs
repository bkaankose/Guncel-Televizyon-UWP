using GuncelTelevizyonUWP.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuncelTelevizyonUWP.Models
{
    public class ChannelModelView
    {
        public Channel Channel { get; set; }
        public bool IsFavorited { get; set; }
        public bool HasChannelImage { get; set; }
        public string CurrentStream { get; set; }
        public string ChannelImage
        {
            get
            {
                if (HasChannelImage)
                    return string.Format("{0}\\Images\\{1}.png", ConfigurationContext.LocalFolder.Path, this.Channel.Id);
                else
                    return string.Format("noimage");
            }
        }
        public ChannelModelView(Channel _channel)
        {
            Channel = _channel;
        }
    }
}
