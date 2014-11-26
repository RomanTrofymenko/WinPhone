using System.Runtime.Serialization;

namespace InstagramClient.Model
{
    [DataContract]
    public class Images
    {
        [DataMember(Name = "low_resolution")]
        public Image LowRes { get; set; }
        [DataMember(Name = "standard_resolution")]
        public Image StandRes { get; set; }
        [DataMember(Name = "thumbnail")]
        public Image Thumbnail { get; set; }
    }
}