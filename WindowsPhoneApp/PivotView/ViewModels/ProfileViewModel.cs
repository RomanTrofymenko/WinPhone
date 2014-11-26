using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using InstagramClient.Common;
using InstagramClient.Model;
using PivotView.Common;

namespace InstagramClient.ViewModels
{
    public class ProfileViewModel
    {
        internal ProfileViewModel(ProfileResponse profile, FeedResponse feed)
        {
            _nextPostsUrl = feed.Pagination.NextUrl;
            User = profile.Data;
            Posts = new ObservableCollection<Post>(feed.Data);
            GetMorePostsCommand = new RelayCommand(GetMorePosts, CanGetMorePosts);
        }

        private bool CanGetMorePosts()
        {
            return !String.IsNullOrEmpty(_nextPostsUrl);
        }

        private string _nextPostsUrl;

        private async void GetMorePosts()
        {
            var newPosts = await RequestManager.GetFeed(_nextPostsUrl);
            foreach (var post in newPosts.Data)
            {
                Posts.Add(post);
            }
            _nextPostsUrl = newPosts.Pagination.NextUrl;
        }

        public User User { get; set; }

        public ObservableCollection<Post> Posts { get; set; }

        public ICommand GetMorePostsCommand { get; private set; }
    }
}
