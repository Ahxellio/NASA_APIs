using NASA_APIs.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace NASA_APIs.Models
{
    public class APODModel
    {
        [JsonPropertyName("date")]
        //[JsonConverter(typeof(JsonDateConverter))]
        public string Date { get; set; }

        [JsonPropertyName("explanation")]
        public string Text { get; set; }

        [JsonPropertyName("hdurl")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("media_type")]
        public string Type { get; set; }

        public override string ToString() => $"{Title}";
    }
}
