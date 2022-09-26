using SeptaKit.TelephonyServer.Enums;

namespace AloVoIP.OpenCRM.Responses
{
    public class LineResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool CanReceive { get; set; }
        public bool CanSend { get; set; }
        public bool IsActive { get; set; }
        public bool IsOnline { get; set; }
        public MediaType MediaType { get; set; }
    }
}
