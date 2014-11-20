using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PivotView.DataModel.InstagramModel
{
    [DataContract]
    public class User
    {
        [DataMember(Name = "full_name")]
        public string FullName { get; set; }
        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "profile_picture")]
        public string ProfilePicture { get; set; }
        [DataMember(Name = "username")]
        public string UserName { get; set; }
        
        [DataMember(Name = "website", IsRequired = false)]
        public string Website { get; set; }
        [DataMember(Name = "bio", IsRequired = false)]
        public string Bio { get; set; }
        [DataMember(Name = "counts", IsRequired = false)]
        public ProfileCounter Counter { get; set; }
    }

    [DataContract]
    public class ProfileCounter
    {
        [DataMember(Name = "followed_by")]
        public int FollowedBy { get; set; }
        [DataMember(Name = "follows")]
        public int Follows { get; set; }
        [DataMember(Name = "media")]
        public int Media { get; set; }
    }
}
