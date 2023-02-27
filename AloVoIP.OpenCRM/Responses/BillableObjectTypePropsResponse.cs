using AloVoIP.OpenCRM.Responses;
using System.Collections.Generic;

namespace AloVoIP.OpenCRM
{
    public class BillableObjectTypePropsResponse
    {
        public BillableObjectTypePropsResponse()
        {
            CRMObjectTypes = new List<CrmObjectTypeResponse>();
        }
        public List<CrmObjectTypeResponse> CRMObjectTypes { get; set; }
    }
}