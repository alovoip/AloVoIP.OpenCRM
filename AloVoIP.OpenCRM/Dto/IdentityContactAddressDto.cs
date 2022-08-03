namespace AloVoIP.OpenCRM.Dto
{
    public class IdentityContactAddressDto : IdentityContactDto
    {
        public string Address { get; set; }
        public string AddressType { get; set; }
        public string AreaCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string ZipBox { get; set; }
        public string ZipCode { get; set; }
    }
}
