using AloVoIP.OpenCRM.Responses;
using System.Collections.Generic;

namespace AloVoIP.OpenCRM
{
    public class MoneyAccountsResponse
    {
        public MoneyAccountsResponse()
        {
            MoneyAccounts = new List<MoneyAccountResponse>();
        }
        public List<MoneyAccountResponse> MoneyAccounts { get; set; }
    }
}