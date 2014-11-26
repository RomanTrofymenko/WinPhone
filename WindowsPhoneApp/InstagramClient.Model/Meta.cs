using System.Runtime.Serialization;

namespace InstagramClient.Model
{
    [DataContract]
    public class Meta
    {
        [DataMember(Name = "code")]
        public int Code { get; set; }
    }
}