using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PivotView.DataModel.InstagramModel
{
    [DataContract]
    public class PostSet<T>
    {
        [DataMember(Name = "count")]
        public int Count { get; set; }
        [DataMember(Name = "data")]
        public List<T> Data { get; set; }

    }
}