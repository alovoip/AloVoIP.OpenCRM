namespace AloVoIP.OpenCRM.Responses
{
    public class TelephonySystemResponse
    {
        public string BrevityName { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string OfficeId { get; set; }
        public string ServerAddress { get; set; }
        public TelephonySystemExtensionResponse[] Extensions { get; set; }
    }
}
