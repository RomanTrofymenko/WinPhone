using System;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Windows.Storage;

namespace InstagramClient.Model
{
    public static class RequestManager
    {
        public static bool TryGetToken()
        {
            var localSettings = ApplicationData.Current.LocalSettings;
            if (!localSettings.Values.ContainsKey("token") || localSettings.Values["token"] == null) return false;
            _token = (string)localSettings.Values["token"];
            return true;
        }

        private static string _token;
        private const string _apiBase = "https://api.instagram.com/v1/";

        public static async Task<FeedResponse> GetFeed(string nextPageUrl = null)
        {
            FeedResponse feed = null;

            var requestUrl = string.IsNullOrEmpty(nextPageUrl) ? String.Format("{0}users/self/feed?access_token={1}", _apiBase, _token) : nextPageUrl;
            var req = WebRequest.Create(requestUrl);
            using (var response = await req.GetResponseAsync())
            {
                var serializer = new DataContractJsonSerializer(typeof(FeedResponse));
                feed = (FeedResponse)serializer.ReadObject(response.GetResponseStream());
            }

            return feed;
        }

        public static async Task<FeedResponse> GetUserMedia(string userId = null)
        {
            return await GetFeed(String.Format("{0}users/{1}/media/recent?access_token={2}", _apiBase, String.IsNullOrEmpty(userId) ? "self" : userId, _token));
        }

        public static async Task<ProfileResponse> GetUserProfile(string userId = null)
        {
            ProfileResponse profile = null;

            var requestUrl = String.Format("{0}users/{1}?access_token={2}", _apiBase, String.IsNullOrEmpty(userId) ? "self" : userId, _token);
            var req = WebRequest.Create(requestUrl);
            using (var response = await req.GetResponseAsync())
            {
                var serializer = new DataContractJsonSerializer(typeof(ProfileResponse));
                profile = (ProfileResponse)serializer.ReadObject(response.GetResponseStream());
            }

            return profile;
        }
    }
}