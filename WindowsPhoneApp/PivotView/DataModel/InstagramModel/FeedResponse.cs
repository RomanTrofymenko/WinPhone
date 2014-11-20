using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PivotView.DataModel.InstagramModel
{
    [DataContract]
    class FeedResponse
    {
        [DataMember(Name = "data")]
        public List<Post> Data { get; set; }

        [DataMember(Name = "meta")]
        public Meta Meta { get; set; }

        [DataMember(Name = "pagination")]
        public Pagination Pagination { get; set; }
    }
    [DataContract]
    internal class Pagination
    {
        [DataMember(Name = "next_max_like_id")]
        public string NextMaxLikeId { get; set; }
        [DataMember(Name = "next_url")]
        public string NextUrl { get; set; }
    }
    [DataContract]
    internal class Meta
    {
        [DataMember(Name = "code")]
        public int Code { get; set; }
    }
}
