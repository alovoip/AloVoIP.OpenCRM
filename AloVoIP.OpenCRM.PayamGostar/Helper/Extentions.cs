using System;
using System.Collections.Generic;
using System.Text;

namespace AloVoIP.OpenCRM.PayamGostar.Helper
{
    public static class Extentions
    {
        public static string ToStringSafe(this object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }
            return obj.ToString();
        }
    }
}
