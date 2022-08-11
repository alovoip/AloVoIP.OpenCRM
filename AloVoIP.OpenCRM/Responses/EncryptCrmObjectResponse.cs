using System.Threading.Tasks;

namespace AloVoIP.OpenCRM
{
    public class EncryptCrmObjectResponse
    {
        public Task<string> EncryptedObject { get; set; }
    }
}