namespace AloVoIP.OpenCRM.Requests
{
    public class MergeCallRequest
    {
        public string TsKey { get; set; }
        public long SourceCallId { get; set; }
        public long DestCallId { get; set; }
    }
}
