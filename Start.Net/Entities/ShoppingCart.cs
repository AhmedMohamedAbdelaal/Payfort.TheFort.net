using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Start.Net.Entities
{
    public class ShoppingCart
    {
        [JsonProperty("user_name")]
        public string UserName { get; set; }

        [JsonProperty("registered_at")]
        public DateTime RegisteredAt { get; set;}

        [JsonProperty("items")]
        public List<Item> Items { get; set; }

        [JsonProperty("billing_address")]
        public Address BillingAddress { get; set; }

        [JsonProperty("shipping_address")]
        public Address ShippingAddress { get; set; }
    }
}
