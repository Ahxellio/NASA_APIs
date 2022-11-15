using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace NASA_APIs
{
    public class NASA_APIsClient
    {
        private readonly HttpClient _Client;
        public NASA_APIsClient(HttpClient Client)=> _Client = Client;

        public async Task<APOD[]> GetAPOD(int count, CancellationToken Cancel = default)
        {
            return await _Client.GetFromJsonAsync<APOD[]>($"https://api.nasa.gov/planetary/apod?api_key=Q7ybo1n8FBtVagagquxxfZMX74TMiQcOTtxqIzSa&count={count}",
                Cancel).ConfigureAwait(false);
        }

    }
    public class APOD
    {
        [JsonPropertyName("date")]
        [JsonConverter(typeof(JsonDateConverter))]
        public (string Year, string Month, string Day) Date { get; set; }

        [JsonPropertyName("explanation")]
        public string Text { get; set; }

        [JsonPropertyName("hdurl")]
        public string Url { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("media_type")]
        public string Type { get; set; }

        //DateTime start_date { get; set; }
        //DateTime end_date { get; set; }
        int count { get; set; }
        //bool thumbs { get; set; }

    }

    internal class JsonDateConverter : JsonConverter<(string Year, string Month, string Day)>
    {
        public override (string Year, string Month, string Day) Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var str = reader.GetString();
            var components = str.Split('-');
            var year = components[0];
            var month = components[1];
            var day = components[2];
            return (year, month, day);
        }

        public override void Write(Utf8JsonWriter writer, (string Year, string Month, string Day) value, JsonSerializerOptions options)
        {
            writer.WriteStringValue($"{value.Year} - {value.Month} - {value.Day}");
        }
    }
}
