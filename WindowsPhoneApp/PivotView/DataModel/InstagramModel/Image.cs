using System.Runtime.Serialization;

namespace PivotView.DataModel.InstagramModel
{
    [DataContract]
    public class Image
    {
        [DataMember(Name = "height")]
        public int Height { get; set; }
        [DataMember(Name = "width")]
        public int Width { get; set; }
        [DataMember(Name = "url")]
        public string Url { get; set; }
    }
}