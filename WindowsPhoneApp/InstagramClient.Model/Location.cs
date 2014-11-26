using System.Runtime.Serialization;

namespace InstagramClient.Model
{
    [DataContract]
    public class Location
    {
        [DataMember(Name = "latitude")]
        public float Latitude { get; set; }
        [DataMember(Name = "longitude")]
        public float Longitude { get; set; }
    }
}