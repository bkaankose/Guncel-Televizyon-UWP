using GuncelTelevizyonUWP.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuncelTelevizyonUWP.Models
{
    public class ChannelStreamInformation
    {
        public Guid ChannelId { get; set; }
        public string ChannelName { get; set; }
        public List<StreamInformation> DailyStreams { get; set; }
        public string ChannelImage
        {
            get
            {
                return string.Format("{0}\\Images\\{1}.png", ConfigurationContext.LocalFolder.Path, ChannelId);
            }
        }
        
        public StreamInformation CurrentStream
        {
            get
            {
                return DailyStreams.LastOrDefault(a => DateTime.Now > a.StartTime);
            }
        }
    }
}
