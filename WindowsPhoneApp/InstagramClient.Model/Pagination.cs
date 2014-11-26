using System.Runtime.Serialization;

namespace InstagramClient.Model
{
    [DataContract]
    public class Pagination
    {
        [DataMember(Name = "next_max_like_id")]
        public string NextMaxLikeId { get; set; }
        [DataMember(Name = "next_url")]
        public string NextUrl { get; set; }
    }
}