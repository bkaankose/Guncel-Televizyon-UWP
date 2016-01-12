using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuncelTelevizyonUWP.Interfaces
{
    public interface IDialogService
    {
        Task ShowMessageAsync(string message, string title = "");
        Task<bool> ShowConfirmationDialogAsync(string confirmation, string title, string approveButtonLabel = "Evet", string declineButtonLabel = "Hayır");
    }
}
