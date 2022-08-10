using AloVoIP.OpenCRM.Enums;
using System;

namespace AloVoIP.OpenCRM.Requests
{
    public class CallChannelUpdateRequest
    {
        public string ChannelId { get; set; }
        public bool IsLive { get; set; }
        public ChannelState ChannelState { get; set; }
        public ChannelResponse ChannelResponse { get; set; }
        public DateTime? ConnectDate { get; set; }
        public DateTime? HangupDate { get; set; }
        public string RecordedFileName { get; set; }
        public string ToChangePeerName { get; set; } = "";
        public PeerType? ToChangePeerType { get; set; } = null;
    }
}
