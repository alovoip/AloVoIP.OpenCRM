using System;
using System.Collections.Generic;
using System.Text;

namespace AloVoIP.OpenCRM.General.Models
{
    public class CallMergeModel
    {
        public string TsKey { get; set; }
        public long SourceCallId { get; set; }
        public long DestinationCallId { get; set; }
    }
}
