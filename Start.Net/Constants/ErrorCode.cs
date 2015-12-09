using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.Net.Constants
{
    public static class ErrorCode 
    {
        /// <summary>
        /// The card was declined by the acquiring bank
        /// </summary>
        public const string CardDeclined = "card_declined";

        public const string UnprocessableEntity = "unprocessable_entity";

        public const string NotFound = "not_found";
    }
}
