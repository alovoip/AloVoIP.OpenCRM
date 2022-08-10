namespace AloVoIP.OpenCRM.Requests
{
    public class IdentityHasValidContractRequest
    {
        public CustomerRequest CustomerRequest { get; set; }
        public string ContractKey { get; set; }
    }
}
