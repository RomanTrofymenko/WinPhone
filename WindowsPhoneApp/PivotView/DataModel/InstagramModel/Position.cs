using System.Runtime.Serialization;

namespace PivotView.DataModel.InstagramModel
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