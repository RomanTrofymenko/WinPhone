using System;
using Windows.Security.Authentication.Web;
using Windows.Storage;
using InstagramClient.Model;

namespace InstagramClient
{
    static class AuthenticationHelper
    {
        private const string _appId = "f6ecbb4b957442fcb700be5783e105cf";
        private const string _redirectUri = "http://dumburi.com";

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
            var localSettings = ApplicationData.Current.LocalSettings;
            localSettings.Values.Add("token", _token);
            RequestManager.TryGetToken();
        }

        public static bool IsAuthenticated()
        {
            var localSettings = ApplicationData.Current.LocalSettings;
            return localSettings.Values.ContainsKey("token") &&
                   localSettings.Values["token"] != null &&
                   RequestManager.TryGetToken();
        }
    }
}
