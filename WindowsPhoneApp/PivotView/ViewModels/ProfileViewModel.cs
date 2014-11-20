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

    public class MockProfileVm
    {
        private static User _user = new User
        {
            FullName = "Roman Trofymenko",
            Id = "1415662153",
            ProfilePicture =
                "https://igcdn-photos-b-a.akamaihd.net/hphotos-ak-xap1/10520149_678842982184137_310257702_a.jpg",
            UserName = "rtrofimenko"
        };

        private static Post _post = new Post
        {
            User = _user,
            Images = new Images
            {
                LowRes = { Height = 306, Width = 306, Url = "http://scontent-a.cdninstagram.com/hphotos-xpa1/t51.2885-15/10727804_745639228840605_1941302651_a.jpg" },
                StandRes = { Height = 640, Width = 640, Url = "http://scontent-a.cdninstagram.com/hphotos-xpa1/t51.2885-15/10727804_745639228840605_1941302651_n.jpg" },
                Thumbnail = { Height = 150, Width = 150, Url = "http://scontent-a.cdninstagram.com/hphotos-xpa1/t51.2885-15/10727804_745639228840605_1941302651_s.jpg" }
            }
        };

        public User User { get { return _user; } }

        public ObservableCollection<Post> Posts { get { return new ObservableCollection<Post>(new Post[] { _post, _post, _post, _post, _post, _post, _post, _post, _post }); } }

        public ICommand GetMorePostsCommand { get; private set; }
    }
}
