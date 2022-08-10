using System;

namespace AloVoIP.OpenCRM.Responses
{
    public class BaseCrmObjectResponse
    {
        public string Id { get; set; }
        public int CrmObjectTypeIndex { get; set; }
        public string CrmObjectTypeCode { get; set; }
        public string CrmObjectTypeName { get; set; }
        public string ParentCrmObjectId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public CrmObjectExtendedPropertyResponse[] ExtendedProperties { get; set; }
    }
}
