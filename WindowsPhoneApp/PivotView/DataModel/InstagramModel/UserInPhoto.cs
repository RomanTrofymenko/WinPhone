using System.Runtime.Serialization;

namespace PivotView.DataModel.InstagramModel
{
    [DataContract]
    public class UserInPhoto
    {
        [DataMember(Name = "position")]
        public Position Position { get; set; }
        [DataMember(Name = "user")]
        public User User { get; set; }
    }
}