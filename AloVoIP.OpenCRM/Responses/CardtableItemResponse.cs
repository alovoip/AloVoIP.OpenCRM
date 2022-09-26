using SeptaKit.TelephonyServer.Enums;
using System;

namespace AloVoIP.OpenCRM.Responses
{
    public class CardtableItemResponse
    {
        public string CrmObjectId { get; set; }
        public string CrmObjectTypeId { get; set; }
        public string HolderId { get; set; }
        public string HolderName { get; set; }
        public string IdentityId { get; set; }
        public string IdentityNickName { get; set; }
        public string LifePathId { get; set; }
        public string ProcessInstanceId { get; set; }
        public string StateName { get; set; }
        public string StateUserKey { get; set; }
        public string Subject { get; set; }
        public string StateId { get; set; }
        public string EnterCardtableDatePersian { get; set; }
        public DateTime? EnterCardtableDate { get; set; }
        public ProcessInstanceType? ProcessInstanceType { get; set; }
        public StateActionType? StateActionTypeIndex { get; set; }
        public CardtableStatus CardtableStatus { get; set; }
        public CrmObjectTypes? CrmObjectType { get; set; }
    }
}
