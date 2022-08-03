namespace AloVoIP.OpenCRM.Dto
{
    public class TelephonySystemDto
    {
        public string BrevityName { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string OfficeId { get; set; }
        public string ServerAddress { get; set; }
        public TelephonySystemExtensionDto[] Extensions { get; set; }
    }
}
