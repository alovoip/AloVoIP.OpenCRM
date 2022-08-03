using System;

namespace AloVoIP.OpenCRM.Dto
{
    public class BaseCrmObjectDto
    {
        public string CrmId { get; set; }
        public int CrmObjectTypeIndex { get; set; }
        public string CrmObjectTypeCode { get; set; }
        public string CrmObjectTypeName { get; set; }
        public string ParentCrmObjectId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public BaseCrmObjectExtendedPropertyDto[] ExtendedProperties { get; set; }
    }
}
