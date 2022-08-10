using System;
namespace AloVoIP.OpenCRM.Responses
{
    public class IdentityResponse : BaseCrmObjectResponse
    {
        public decimal? Balance { get; set; }
        public string Classification { get; set; }
        public string ColorName { get; set; }
        public string CustomerNumber { get; set; }
        public DateTime? CustomerDate { get; set; }
        public bool? DontEmail { get; set; }
        public bool? DontFax { get; set; }
        public bool? DontPhoneCall { get; set; }
        public bool? DontSms { get; set; }
        public bool? DontSocialSms { get; set; }
        public string[] Emails { get; set; }
        public string IdentityType { get; set; }
        public string NickName { get; set; }
        public string OtherUsername { get; set; }
        public string SaleUsername { get; set; }
        public string SourceType { get; set; }
        public string SupportUsername { get; set; }
        public string Website { get; set; }
        public CategoryInfoResponse[] Categories { get; set; }
        public IdentityContactPhoneResponse[] PhoneContacts { get; set; }
        public IdentityContactAddressResponse[] AddressContacts { get; set; }

    }
}
