using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using InstagramClient.Model;

namespace InstagramClient.ViewModels
{
    public class MockFeedVm
    {
        public ObservableCollection<Post> Posts
        {
            get
            {
                return new ObservableCollection<Post>(new List<Post>
                {
                    GetPost2(),
                    //GetPost2()
                });
            }
        }

        public ICommand GetMorePostsCommand { get; set; }

        private Post GetPost1()
        {
            return new Post
            {
                User = new User
                {
                    FullName = "Dmitry Shapar",
                    Id = "362507260",
                    ProfilePicture =
                        "https://instagramimages-a.akamaihd.net/profiles/profile_362507260_75sq_1367196039.jpg",
                    UserName = "atomohod3"
                },

                Caption = new Comment()
                {
                    CreatedTime = new DateTime(2014, 11, 20),
                    From = new User()
                    {
                        FullName = "Dmitry Shapar",
                        Id = "362507260",
                        ProfilePicture =
                            "https://instagramimages-a.akamaihd.net/profiles/profile_362507260_75sq_1367196039.jpg",
                        UserName = "atomohod3"
                    },
                    Id = "855610442991752785",
                    Text = "#французскийбульдог #мэрри"
                },
                Comments = new PostSet<Comment>
                {
                    Count = 1,
                    Data = new List<Comment>
                    {
                        new Comment
                        {
                            CreatedTime = new DateTime(2014, 11, 20),
                            From = new User()
                            {
                                FullName = "Dmitry Shapar",
                                Id = "362507260",
                                ProfilePicture =
                                    "https://instagramimages-a.akamaihd.net/profiles/profile_362507260_75sq_1367196039.jpg",
                                UserName = "atomohod3"
                            },
                            Id = "855610442991752785",
                            Text = "#французскийбульдог #мэрри"
                        }
                    }
                },
                Id = "855610442538767952_362507260",
                Images = new Images
                {
                    LowRes =
                        new Image
                        {
                            Height = 306,
                            Width = 306,
                            Url =
                                "http://scontent-a.cdninstagram.com/hphotos-xap1/t51.2885-15/923835_914567331894355_456668660_a.jpg"
                        },
                    StandRes =
                        new Image
                        {
                            Height = 640,
                            Width = 640,
                            Url =
                                "http://scontent-a.cdninstagram.com/hphotos-xap1/t51.2885-15/923835_914567331894355_456668660_n.jpg"
                        },
                    Thumbnail =
                        new Image
                        {
                            Height = 150,
                            Width = 150,
                            Url =
                                "http://scontent-a.cdninstagram.com/hphotos-xap1/t51.2885-15/923835_914567331894355_456668660_s.jpg"
                        }
                },
                Likes = new PostSet<User>()
                {
                    Count = 2,
                    Data = new List<User>
                    {
                        new User
                        {
                            FullName = "Anna",
                            Id = "306147292",
                            ProfilePicture =
                                "https://instagramimages-a.akamaihd.net/profiles/profile_362507260_75sq_1367196039.jpg",
                            UserName = "nyura_nyura"
                        },
                        new User
                        {
                            FullName = "Anna",
                            Id = "248031302",
                            ProfilePicture =
                                "https://igcdn-photos-e-a.akamaihd.net/hphotos-ak-xap1/10632501_418872994927164_1096946724_a.jpg",
                            UserName = "blek_rabbit_n"
                        },
                    }
                }
            };
        }
        private Post GetPost2()
        {
            return new Post
            {
                User = new User
                {
                    FullName = "Dmitry Shapar",
                    Id = "362507260",
                    ProfilePicture =
                        "https://instagramimages-a.akamaihd.net/profiles/profile_362507260_75sq_1367196039.jpg",
                    UserName = "atomohod3"
                },

                Caption = new Comment()
                {
                    CreatedTime = new DateTime(2014, 11, 20),
                    From = new User()
                    {
                        FullName = "Dmitry Shapar",
                        Id = "362507260",
                        ProfilePicture =
                            "https://instagramimages-a.akamaihd.net/profiles/profile_362507260_75sq_1367196039.jpg",
                        UserName = "atomohod3"
                    },
                    Id = "855610442991752785",
                    Text = "#французскийбульдог #мэрри"
                },
                Comments = new PostSet<Comment>
                {
                    Count = 1,
                    Data = new List<Comment>
                    {
                        new Comment
                        {
                            CreatedTime = new DateTime(2014, 11, 20),
                            From = new User()
                            {
                                FullName = "Dmitry Shapar",
                                Id = "362507260",
                                ProfilePicture =
                                    "https://instagramimages-a.akamaihd.net/profiles/profile_362507260_75sq_1367196039.jpg",
                                UserName = "atomohod3"
                            },
                            Id = "855610442991752785",
                            Text = "#французскийбульдог #мэрри"
                        }
                    }
                },
                Id = "855610442538767952_362507260",
                Images = new Images
                {
                    LowRes =
                        new Image
                        {
                            Height = 306,
                            Width = 306,
                            Url =
                                "http://scontent-a.cdninstagram.com/hphotos-xap1/t51.2885-15/923835_914567331894355_456668660_a.jpg"
                        },
                    StandRes =
                        new Image
                        {
                            Height = 640,
                            Width = 640,
                            Url =
                                "http://scontent-a.cdninstagram.com/hphotos-xap1/t51.2885-15/923835_914567331894355_456668660_n.jpg"
                        },
                    Thumbnail =
                        new Image
                        {
                            Height = 150,
                            Width = 150,
                            Url =
                                "http://scontent-a.cdninstagram.com/hphotos-xap1/t51.2885-15/923835_914567331894355_456668660_s.jpg"
                        }
                },
                Likes = new PostSet<User>()
                {
                    Count = 2,
                    Data = new List<User>
                    {
                        new User
                        {
                            FullName = "Anna",
                            Id = "306147292",
                            ProfilePicture =
                                "https://instagramimages-a.akamaihd.net/profiles/profile_362507260_75sq_1367196039.jpg",
                            UserName = "nyura_nyura"
                        },
                        new User
                        {
                            FullName = "Anna",
                            Id = "248031302",
                            ProfilePicture =
                                "https://igcdn-photos-e-a.akamaihd.net/hphotos-ak-xap1/10632501_418872994927164_1096946724_a.jpg",
                            UserName = "blek_rabbit_n"
                        },
                    }
                },
                UserHasLiked = true
            };
        }

    }
}
