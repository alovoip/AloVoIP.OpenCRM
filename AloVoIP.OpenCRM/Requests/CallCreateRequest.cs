using AloVoIP.OpenCRM.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AloVoIP.OpenCRM.Requests
{
    public class CallCreateRequest
    {
        public string TsKey { get; set; }
        public bool IsLive { get; set; }
        public string SourceCallId { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public CallType CallType { get; set; }
        public CallResult CallResult { get; set; }
        public string SourceInitCallChannelId { get; set; }
        public string SourceInitCallChannelPeerName { get; set; }
        public PeerType SourceInitCallChannelPeerType { get; set; }
    }
}