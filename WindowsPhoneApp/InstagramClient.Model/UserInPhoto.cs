using System.Runtime.Serialization;

namespace InstagramClient.Model
{
    [DataContract]
    public class UserInPhoto
    {
        [DataMember(Name = "position")]
        public Position Position { get; set; }
        [DataMember(Name = "user")]
        public User User { get; set; }
    }
}