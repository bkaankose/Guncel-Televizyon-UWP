using GuncelTelevizyonUWP.Context;
using GuncelTelevizyonUWP.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;

namespace GuncelTelevizyonUWP.Services
{
    public class SynchronizationService : ISynchronizationService
    {
        private BackgroundDownloader _downloader = new BackgroundDownloader();
        public SynchronizationService()
        {
            
        }

        public event EventHandler<int> ProgressChanged;

        public async Task SynchronizeChannelImage(Guid channelId)
        {
            var imageExists = await ConfigurationContext.LocalFolder.TryGetItemAsync(string.Format("Images\\{0}.png", channelId));
            if (imageExists == null)
            { // Channel image is not stored yet , download and save.
                try
                {
                    IStorageFile downloadedImage = await ConfigurationContext.LocalFolder.CreateFileAsync(string.Format("Images\\{0}.png", channelId));
                    var operation = _downloader.CreateDownload(new Uri(string.Format("{0}{1}.png", ConfigurationContext.ChannelImageStorageURL, channelId.ToString().ToUpper()), UriKind.Absolute), downloadedImage);
                    Progress<DownloadOperation> progress = new Progress<DownloadOperation>(progressChanged);
                    await operation.StartAsync().AsTask(new CancellationToken(), progress);
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void progressChanged(DownloadOperation downloadOperation)
        {
            int progress = (int)(100 * ((double)downloadOperation.Progress.BytesReceived / (double)downloadOperation.Progress.TotalBytesToReceive));
            ProgressChanged.Invoke(this, progress);
        }
    }
}
