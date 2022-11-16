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
        [JsonConverter(typeof(JsonDateConverter))]
        public (string Year, string Month, string Day) Date { get; set; }

        [JsonPropertyName("explanation")]
        public string Text { get; set; }

        [JsonPropertyName("hdurl")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("media_type")]
        public string Type { get; set; }

        //DateTime start_date { get; set; }
        //DateTime end_date { get; set; }
        //int count { get; set; }
        //bool thumbs { get; set; }
        public override string ToString() => $"{Title}";
    }
}
