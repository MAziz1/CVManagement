using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVManagement.Infrastucture
{
    public static class Constants
    {
        public static readonly string NVARCHAR_250 = "nvarchar(250)";
        public static readonly string NVARCHAR_MAX = "nvarchar(MAX)";

        public static class Length
        {
            public static readonly int Normal = 250;
            public static readonly int CompanyName = 20;
            public static readonly int Phone = 11;
        }
    }
}
