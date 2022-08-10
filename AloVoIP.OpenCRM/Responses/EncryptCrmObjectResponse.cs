using System.Threading.Tasks;

namespace AloVoIP.OpenCRM
{
    public class EncryptCrmObjectResponse
    {
        Task<string> EncryptedObject { get; set; }
    }
}