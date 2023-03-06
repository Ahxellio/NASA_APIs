using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NASA_APIs.DAL.Entities
{
    public class TechTransferValue
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
