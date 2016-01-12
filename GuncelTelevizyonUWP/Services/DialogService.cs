using GuncelTelevizyonUWP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace GuncelTelevizyonUWP.Services
{
    public class DialogService : IDialogService
    {
        public async Task<bool> ShowConfirmationDialogAsync(string confirmation, string title,string approveButtonLabel = "Evet",string declineButtonLabel = "Hayır")
        {
            var msg = new MessageDialog(confirmation, title);
            msg.Commands.Add(new UICommand() { Label = approveButtonLabel });
            msg.Commands.Add(new UICommand() { Label = declineButtonLabel });

            var res = await msg.ShowAsync();

            return res.Label == approveButtonLabel ? true : false;

        }

        public async Task ShowMessageAsync(string message, string title = "")
        {
            await new MessageDialog(message, title).ShowAsync();
        }
    }
}
