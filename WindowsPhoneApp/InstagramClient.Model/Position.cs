using System.Runtime.Serialization;

namespace InstagramClient.Model
{
    [DataContract]
    public class Position
    {
        [DataMember(Name = "x")]
        public float X { get; set; }
        [DataMember(Name = "y")]
        public float Y { get; set; }
    }
}