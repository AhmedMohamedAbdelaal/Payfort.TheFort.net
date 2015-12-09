using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Start.Net.Entities
{
    public class Customer
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("cards")]
        public List<CardSummary> Cards { get; set; }

        [JsonProperty("default_card_id")]
        public string DefaultCardId { get; set; }
    }
}
