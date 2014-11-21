using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web;
using PivotView.DataModel.InstagramModel;

namespace PivotView.Common
{
    static class RequestManager
    {
        private const string _appId = "f6ecbb4b957442fcb700be5783e105cf";
        private const string _redirectUri = "http://dumburi.com";
        private const string _apiBase = "https://api.instagram.com/v1/";
        private const string _httpsWwwInstagramComOauthAuthorizeClientId = "https://www.instagram.com/oauth/authorize/?client_id={0}&redirect_uri={1}&response_type=token";
        private static string _token;// = "1415662153.f6ecbb4.dedb6f9f24be4ed7b1dc888a61948fec";

        public static void BeginAuthenticate()
        {
            var tokenRequestUrl = String.Format(_httpsWwwInstagramComOauthAuthorizeClientId, Uri.EscapeDataString(_appId), Uri.EscapeDataString(_redirectUri));
            var startUri = new Uri(tokenRequestUrl);
            var endUri = new Uri(_redirectUri);
            if (String.IsNullOrEmpty(_token))
            {
                WebAuthenticationBroker.AuthenticateAndContinue(startUri, endUri, null, WebAuthenticationOptions.None);
            }
        }

        public static void EndAuthenticate(WebAuthenticationResult response)
        {
            var url = response.ResponseData;
            _token = url.Replace(_redirectUri + "/#access_token=", "");
        }

        public static async Task<FeedResponse> GetFeed(string nextPageUrl = null)
        {
            FeedResponse feed = null;

            var requestUrl = string.IsNullOrEmpty(nextPageUrl) ? _apiBase + "users/self/feed?access_token=" + _token : nextPageUrl;
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

            var requestUrl = String.Format("{0}users/{1}?access_token={2}",_apiBase, String.IsNullOrEmpty(userId) ? "self" : userId, _token);
            var req = WebRequest.Create(requestUrl);
            using (var response = await req.GetResponseAsync())
            {
                var serializer = new DataContractJsonSerializer(typeof(ProfileResponse));
                profile = (ProfileResponse)serializer.ReadObject(response.GetResponseStream());
            }
            
            return profile;
        }

        public static bool IsAuthenticated()
        {
            return !(String.IsNullOrEmpty(_token));
        }
    }
}
