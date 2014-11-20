using System.Collections.ObjectModel;
using System.Windows.Input;
using PivotView.Common;
using PivotView.DataModel.InstagramModel;

namespace PivotView.ViewModels
{
    public class ProfileViewModel
    {
        internal ProfileViewModel(ProfileResponse profile, FeedResponse feed)
        {
            _nextPostsUrl = feed.Pagination.NextUrl;
            User = profile.Data;
            GetMorePostsCommand = new RelayCommand(GetMorePosts);
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
