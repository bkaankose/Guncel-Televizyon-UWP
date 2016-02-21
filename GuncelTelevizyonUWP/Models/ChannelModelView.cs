using GuncelTelevizyonUWP.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuncelTelevizyonUWP.Models
{
    public class ChannelModelView : INotifyPropertyChanged
    {
        public ChannelModelView(Channel _channel)
        {
            Channel = _channel;
        }

        public Channel Channel { get; set; }
        private bool _isFavorited;

        public bool IsFavorited
        {
            get { return _isFavorited; }
            set { _isFavorited = value; PropChanged("IsFavorited"); }
        }

        public bool HasChannelImage { get; set; }
        public StreamInformation CurrentStream { get; set; }
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

        public event PropertyChangedEventHandler PropertyChanged;
        private void PropChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(null, new PropertyChangedEventArgs(propName));
        }
    }
}
