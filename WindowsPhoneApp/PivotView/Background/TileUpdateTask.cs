using System;
using System.IO;
using System.Linq;
using System.Net;
using Windows.ApplicationModel.Background;
using Windows.Data.Xml.Dom;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using PivotView.Common;
using PivotView.DataModel.InstagramModel;

namespace PivotView.Background
{
    public sealed class TileUpdateTask : IBackgroundTask
    {
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            var deferral = taskInstance.GetDeferral();

            var feed = await RequestManager.GetFeed();

            UpdateTile(feed);
            
            deferral.Complete();
        }

        private async void UpdateTile(FeedResponse feed)
        {
            var updater = TileUpdateManager.CreateTileUpdaterForApplication();
            updater.EnableNotificationQueue(true);
            updater.Clear();

            // Keep track of the number feed items that get tile notifications. 
            int itemCount = 0;

            // Create a tile notification for each feed item.
            foreach (var item in feed.Data.Take(5))
            {
                var file = await ApplicationData.Current.TemporaryFolder.CreateFileAsync(String.Format("temp{0}.jpg", itemCount));
                
                
                var download = new BackgroundDownloader().CreateDownload(new Uri(item.Images.StandRes.Url), file);
                await download.StartAsync();

                var tileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWide310x150ImageAndText02);

                tileXml.GetElementsByTagName(_imageElementName)[0].Attributes.GetNamedItem("src").InnerText = file.Name;
                tileXml.GetElementsByTagName(_textElementName)[0].InnerText = item.User.FullName;
                tileXml.GetElementsByTagName(_textElementName)[1].InnerText = item.Caption.Text ?? String.Empty;

                // Create a new tile notification. 
                updater.Update(new TileNotification(tileXml));

                // Don't create more than 5 notifications.
                if (itemCount++ > 5) break;
            }
        }

        private const string _imageElementName = "image";
        private const string _textElementName = "text";
        private const string _tileTemplate =
@"<tile>
  <visual version=""2"">
    <binding template=""TileWide310x150ImageAndText02"" fallback=""TileWideImageAndText02"">
      <image id=""1"" src=""image1.png"" alt=""alt text""/>
      <text id=""1"">Text Field 1</text>
      <text id=""2"">Text Field 2</text>
    </binding>  
  </visual>
</tile>";
    }
}
