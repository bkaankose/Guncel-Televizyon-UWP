using GuncelTelevizyonUWP.Interfaces;
using GuncelTelevizyonUWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuncelTelevizyonUWP.Services
{
    public class FeedbackService : IFeedbackService
    {
        public async Task<bool> SendFeedbackAsync(Feedback model)
        {
            // TODO : Send feedback
            await Task.Delay(3000);
            return true;
        }
    }
}
