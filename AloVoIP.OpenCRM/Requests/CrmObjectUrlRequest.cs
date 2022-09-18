using System;
using System.Collections.Generic;
using System.Text;

namespace AloVoIP.OpenCRM.Requests
{
    public class CrmObjectUrlRequest
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string IdentityId { get; set; }
    }  
}
