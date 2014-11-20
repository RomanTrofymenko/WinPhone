using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PivotView.DataModel.InstagramModel
{
    [DataContract]
    class ProfileResponse
    {
        [DataMember(Name = "data")]
        public User Data { get; set; }

        [DataMember(Name = "meta")]
        public Meta Meta { get; set; }

        [DataMember(Name = "pagination")]
        public Pagination Pagination { get; set; }
    }
}
