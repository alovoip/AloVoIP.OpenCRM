namespace AloVoIP.OpenCRM.Dto
{
    public class IdentityContactPhoneDto : IdentityContactDto
    {
        public string ContinuedNumber { get; set; }
        public string Extension { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneType { get; set; }
    }
}
