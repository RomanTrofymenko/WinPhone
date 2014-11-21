using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PivotView.DataModel.InstagramModel;

namespace PivotView.ViewModels
{
    public class MockProfileVm
    {
        private User _user;

        private User GetUser()
        {
            return _user ?? (_user = new User
            {
                FullName = "Roman Trofymenko",
                Id = "1415662153",
                ProfilePicture =
                    "https://igcdn-photos-b-a.akamaihd.net/hphotos-ak-xap1/10520149_678842982184137_310257702_a.jpg",
                UserName = "rtrofimenko",
                Bio = "С другой стороны консультация с широким активом играет важную роль в формировании систем массового участия. Равным образом постоянный количественный рост и сфера нашей активности позволяет выполнять важные задания по разработке новых предложений. Значимость этих проблем настолько очевидна, что новая модель организационной деятельности позволяет оценить значение форм развития."
            });
        }

        private Post _post;

        private Post GetPost()
        {

            return _post ?? (_post = new Post
            {
                User = _user,
                Images = new Images
                {

                    LowRes = new Image
                    {
                        
                        Height = 306,
                        Width = 306,
                        Url =
                            "http://scontent-a.cdninstagram.com/hphotos-xpa1/t51.2885-15/10727804_745639228840605_1941302651_a.jpg"
                    },
                    StandRes = new Image
                    {
                        Height = 640,
                        Width = 640,
                        Url =
                            "http://scontent-a.cdninstagram.com/hphotos-xpa1/t51.2885-15/10727804_745639228840605_1941302651_n.jpg"
                    },
                    Thumbnail = new Image
                    {
                        Height = 150,
                        Width = 150,
                        Url =
                            "http://scontent-a.cdninstagram.com/hphotos-xpa1/t51.2885-15/10727804_745639228840605_1941302651_s.jpg"
                    }
                }
            });
        }

        private ObservableCollection<Post> _posts;

        
        private ObservableCollection<Post> GetPosts()
        {
            return _posts ??
                   (_posts =
                       new ObservableCollection<Post>(new List<Post>
                       {
                           GetPost(), GetPost(), GetPost(), GetPost(), GetPost(), GetPost(), GetPost(), GetPost(), GetPost()
                       }));
        }

        

        public User User { get { return GetUser(); } }

        public ObservableCollection<Post> Posts
        {
            get { return GetPosts(); }
        }

        public ICommand GetMorePostsCommand { get; private set; }
    }
}