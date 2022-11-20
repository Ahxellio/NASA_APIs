using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace NASA_APIs.Models
{
    public class TechTransferModel
    {
        [JsonPropertyName("results")]
        public List<List<object>> Results { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("perpage")]
        public int Perpage { get; set; }

        [JsonPropertyName("page")]
        public int Page { get; set; }
    }

}
