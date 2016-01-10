using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuncelTelevizyonUWP.Interfaces
{
    public interface ISynchronizationService
    {
        Task SynchronizeChannelImage(int channelId);
        event EventHandler<int> ProgressChanged;
    }
}
