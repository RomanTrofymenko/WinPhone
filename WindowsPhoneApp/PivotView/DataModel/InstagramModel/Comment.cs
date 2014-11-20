using System;
using System.Runtime.Serialization;

namespace PivotView.DataModel.InstagramModel
{
    [DataContract]
    public class Comment
    {
        [IgnoreDataMember]
        public DateTime CreatedTime { get; set; }
        
        [DataMember(Name = "created_time")]
        private string CreatedTimeJson
        {
            get { return this.CreatedTime.Ticks.ToString(); }
            set { this.CreatedTime = Constants.GetDateTimeFromSeconds(value); }
        }

        [DataMember(Name = "from")]
        public User From { get; set; }
        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "text")]
        public string Text { get; set; }

    }
}