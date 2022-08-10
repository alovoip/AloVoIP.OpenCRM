namespace AloVoIP.OpenCRM.Requests
{
    public class PaymentInfoRequest
    {
        public CustomerRequest CustomerRequest { get; set; }
        public string BillableObjectTypeKey { get; set; }
        public string BillableObjectNumber { get; set; }
        public string LookupNumberFieldKey { get; set; }
        public string ValueFieldKey { get; set; }
    }
}
