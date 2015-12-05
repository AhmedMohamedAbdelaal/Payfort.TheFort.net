using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.Net.Constants
{
    public static class ChargeState
    {
        public static string Authorized = "authorized";
        public static string Captured = "captured";
        public static string Refunded = "refunded";
        public static string PartiallyRefunded = "partially_refunded";
        public static string Failed = "failed";
    }
}
