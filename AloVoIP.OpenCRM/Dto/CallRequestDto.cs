using AloVoIP.OpenCRM.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AloVoIP.OpenCRM.Dto
{
    public class CallRequestDto
    {
        public CallRequestDto(CallStoreType callStoreType, object data)
        {
            CallStoreType = callStoreType;
            Data = data;
        }
        public CallStoreType CallStoreType { get; }
        public object Data { get; }
    }
}
