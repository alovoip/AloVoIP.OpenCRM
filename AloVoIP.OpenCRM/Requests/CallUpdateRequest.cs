using AloVoIP.OpenCRM.Enums;
using SeptaKit.TelephonyServer.Enums;
using System;

namespace AloVoIP.OpenCRM.Requests
{
    public class CallUpdateRequest
    {
        public string CallId { get; set; }
        public bool IsLive { get; set; }
        public string Number { get; set; }
        public DateTime? Date { get; set; }
        public CallType CallType { get; set; }
        public CallResult CallResult { get; set; }
        public string IdentityId { get; set; }
    }
}
