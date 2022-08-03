using AloVoIP.OpenCRM.Enums;
using AloVoIP.OpenCRM.General.Enums;
using System;

namespace AloVoIP.OpenCRM.General.Models
{
    public class CallChannelUpdateModel
    {
        public long CallChannelId { get; set; }
        public ChannelStatus ChannelStatusIndex { get; set; }
        public ChannelResponse ChannelResponseIndex { get; set; }
        public string RecordedFileName { get; set; }
        public DateTime? ConnectDate { get; set; }
        public DateTime? HangupDate { get; set; }
        public string ToChangePeerName { get; set; }
        public TelephonySystemPeerType? ToChangePeerTypeIndex { get; set; }
        public bool IsLive { get; set; }
    }
}
