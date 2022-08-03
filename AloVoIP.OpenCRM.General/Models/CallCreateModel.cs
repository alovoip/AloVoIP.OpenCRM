using AloVoIP.OpenCRM.General.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AloVoIP.OpenCRM.General.Models
{
    public class CallCreateModel
    {
        public string TsKey { get; set; }
        public string SourceId { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime StartDate { get; set; }
        public PhoneCallType CallTypeIndex { get; set; }
        public string InitChannelPeerName { get; set; }
        public TelephonySystemPeerType InitChannelPeerTypeIndex { get; set; }
        public string InitChannelSourceId { get; set; }
        public bool IsLive { get; set; }
    }
}
