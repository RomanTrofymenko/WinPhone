using System.Runtime.Serialization;

namespace InstagramClient.Model
{
    [DataContract]
    public class ProfileResponse
    {
        [DataMember(Name = "data")]
        public User Data { get; set; }

        [DataMember(Name = "meta")]
        public Meta Meta { get; set; }

        [DataMember(Name = "pagination")]
        public Pagination Pagination { get; set; }
    }
}
