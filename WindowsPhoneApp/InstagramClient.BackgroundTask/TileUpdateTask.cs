using System;
using System.Linq;
using Windows.ApplicationModel.Background;
using Windows.Data.Xml.Dom;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.Storage.Search;
using Windows.UI.Notifications;
using InstagramClient.Model;

namespace InstagramClient.BackgroundTask
{
    public sealed class TileUpdateTask : IBackgroundTask
    {
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            if (!RequestManager.TryGetToken())
                return;

            var deferral = taskInstance.GetDeferral();
            try
            {
                var feed = await RequestManager.GetFeed();

                UpdateTile(feed);
            }
            catch (Exception)
            { }
            var xmlContent = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText01);
            xmlContent.GetElementsByTagName(_textElementName)[0].InnerText = "Hello from Instagram Client!";
            var toastNode = xmlContent.GetElementsByTagName("toast")[0];
            ((XmlElement)toastNode).SetAttribute("launch", "{\"type\":\"toast\",\"postId\":\"1\",\"param2\":\"2\"}");
            var notification = new ToastNotification(xmlContent);
            var toastManager = ToastNotificationManager.CreateToastNotifier();
            toastManager.Show(notification);

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
            foreach (var item in feed.Data)
            {
                var tileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWide310x150ImageAndText02);

                tileXml.GetElementsByTagName(_imageElementName)[0].Attributes.GetNamedItem("src").InnerText = item.Images.LowRes.Url;
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
