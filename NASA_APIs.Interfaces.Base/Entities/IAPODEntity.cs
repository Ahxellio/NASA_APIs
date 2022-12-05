using NASA_APIs.Interfaces.Base.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NASA_APIs.Interfaces.Base.Entities
{
    public interface IAPODEntity
    {
        [JsonPropertyName("date")]
        [JsonConverter(typeof(JsonDateConverter))]
        public DateTime Date { get; set; }

        [JsonPropertyName("explanation")]
        public string Text { get; set; }

        [JsonPropertyName("hdurl")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("media_type")]
        public string Type { get; set; }
    }
}
