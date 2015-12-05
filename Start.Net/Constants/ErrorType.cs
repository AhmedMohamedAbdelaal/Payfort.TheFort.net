using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.Net.Constants
{
    public static class ErrorType 
    {
        /// <summary>
        /// There’s a problem with the parameters that were passed in the original request.
        /// </summary>
        public static string Request = "request";

        /// <summary>
        /// There’s a problem on Start’s end, and we were unable to process the transaction. These should be rare.
        /// </summary>
        public static string Processing = "processing";

        /// <summary>
        /// The transaction was rejected by our banking provider. This could be due to insufficient funds for a charge, for example.
        /// </summary>
        public static string Banking = "banking";

        /// <summary>
        /// The API key used in the request is invalid or expired.
        /// </summary>
        public static string Authentication = "authentication";
    }
}
