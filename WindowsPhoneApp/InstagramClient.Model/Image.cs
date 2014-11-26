using System.Runtime.Serialization;

namespace InstagramClient.Model
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