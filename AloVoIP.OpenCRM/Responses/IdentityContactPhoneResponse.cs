namespace AloVoIP.OpenCRM.Responses
{
    public class IdentityContactPhoneResponse : IdentityContactResponse
    {
        public string ContinuedNumber { get; set; }
        public string Extension { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneType { get; set; }
    }
}
