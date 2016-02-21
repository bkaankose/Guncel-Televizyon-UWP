using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuncelTelevizyonUWP.Models
{
    public class Settings
    {
        public List<Guid> FavoritedChannelIds { get; set; }
        public AppTheme Theme { get; set; }
    }
}
