using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace InstagramClient.Model
{
    [DataContract]
    public class Post
    {
        [DataMember(Name = "attribution")]
        public object Attribution { get; set; }
        [DataMember(Name = "caption")]
        public Comment Caption { get; set; }
        [DataMember(Name = "comments")]
        public PostSet<Comment> Comments { get; set; }

        [IgnoreDataMember]
        public DateTime CreatedTime { get; set; }

        [DataMember(Name = "created_time")]
        private string CreatedTimeJson
        {
            get { return this.CreatedTime.Ticks.ToString(); }
            set { this.CreatedTime = Constants.GetDateTimeFromSeconds(value); }
        }

        [DataMember(Name = "filter")]
        public string Filter { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "images")]
        public Images Images { get; set; }

        [DataMember(Name = "likes")]
        public PostSet<User> Likes { get; set; }

        [DataMember(Name = "link")]
        public string Link { get; set; }

        [DataMember(Name = "location")]
        public Location Location { get; set; }

        [DataMember(Name = "tags")]
        public List<string> Tags { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "user")]
        public User User { get; set; }

        [DataMember(Name = "user_has_liked")]
        public bool UserHasLiked { get; set; }

        [DataMember(Name = "users_in_photo")]
        public List<UserInPhoto> UsersInPhoto { get; set; }


    }
}