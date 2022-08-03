using AloVoIP.OpenCRM.General.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AloVoIP.OpenCRM.General.Models
{
    public class CallChannelCreateModel
    {
        public long CallId { get; set; }
        public string ChannelPeerName { get; set; }
        public TelephonySystemPeerType ChannelPeerTypeIndex { get; set; }
        public string ChannelSourceId { get; set; }
        public ChannelStatus ChannelStatusIndex { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsLive { get; set; }
    }
}
