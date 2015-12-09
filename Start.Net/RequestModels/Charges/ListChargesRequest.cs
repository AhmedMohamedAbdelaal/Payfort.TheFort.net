using System;

namespace Start.Net.RequestModels.Charges
{
    public class ListChargesRequest : RequestBase
    {
        public ListChargesRequest()
        {
            base.UriTemplate = "/charges?pagination[after]={0}&pagination[before]={1}";
            base.Uri = string.Format(base.UriTemplate, "", ""); //default with no pagination
            base.HttpMethod = System.Net.WebRequestMethods.Http.Get;
        }

        private DateTime? before;

        public DateTime? Before
        {
            get
            {
                return before;
            }
            set
            {
                before = value;
                base.Uri = string.Format(base.UriTemplate, After.HasValue ? After.Value.ToString("o") : "", before.HasValue ? before.Value.ToString("o") : "");
            }
        }

        private DateTime? after;

        public DateTime? After
        {
            get
            {
                return after;
            }
            set
            {
                after = value;
                base.Uri = string.Format(base.UriTemplate, after.HasValue ? after.Value.ToString("o") : "", Before.HasValue ? Before.Value.ToString("o") : "");
            }
        }
    }
}
