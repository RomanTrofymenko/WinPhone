using System.Collections.ObjectModel;
using System.Windows.Input;
using PivotView.Common;
using PivotView.DataModel.InstagramModel;

namespace PivotView.ViewModels
{
    public class FeedViewModel
    {
        private string _nextPostsUrl;
        internal FeedViewModel(FeedResponse feed)
        {
            _nextPostsUrl = feed.Pagination.NextUrl;
            Posts = new ObservableCollection<Post>(feed.Data);
            GetMorePostsCommand = new RelayCommand(GetMorePosts);
        }

        private async void GetMorePosts()
        {
            var newPosts = await RequestManager.GetFeed(_nextPostsUrl);
            foreach (var post in newPosts.Data)
            {
                Posts.Add(post);
            }
            _nextPostsUrl = newPosts.Pagination.NextUrl;
        }

        public ObservableCollection<Post> Posts { get; set; }

        public ICommand GetMorePostsCommand { get; set; }
    }
}
