using System.Collections.Generic;
using System.Runtime.Serialization;

namespace InstagramClient.Model
{
    [DataContract]
    public class FeedResponse
    {
        [DataMember(Name = "data")]
        public List<Post> Data { get; set; }

        [DataMember(Name = "meta")]
        public Meta Meta { get; set; }

        [DataMember(Name = "pagination")]
        public Pagination Pagination { get; set; }
    }
}
