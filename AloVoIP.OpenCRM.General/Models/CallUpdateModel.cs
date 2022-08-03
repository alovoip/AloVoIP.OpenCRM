using AloVoIP.OpenCRM.General.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AloVoIP.OpenCRM.General.Models
{
    public class CallUpdateModel
    {
        public long CallId { get; set; }
        public DateTime? EndDate { get; set; }
        public string PhoneNumber { get; set; }
        public Guid? IdentityId { get; set; }
        public PhoneCallType CallTypeIndex { get; set; }
        public bool IsLive { get; set; }
    }
}
