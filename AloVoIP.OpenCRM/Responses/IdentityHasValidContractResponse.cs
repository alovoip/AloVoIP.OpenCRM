namespace AloVoIP.OpenCRM
{
    public class IdentityHasValidContractResponse
    {
        bool IsValid { get; set; }
    }

    public class CrmObjectUrlResponse
    {
        string Id { get; set; }
        string Url { get; set; }
    }
}