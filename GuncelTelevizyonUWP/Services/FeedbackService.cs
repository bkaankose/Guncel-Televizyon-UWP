using GuncelTelevizyonUWP.Helpers;
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
        MobileServiceHelper _mobileServiceHelper;
        public FeedbackService(MobileServiceHelper mobileServiceHelper)
        {
            _mobileServiceHelper = mobileServiceHelper;
        }
        public async Task<bool> SendFeedbackAsync(Feedback model)
        {
            return await _mobileServiceHelper.PostTableData(model);
        }
    }
}
