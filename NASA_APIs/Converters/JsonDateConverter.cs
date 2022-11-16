using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace NASA_APIs.Converters
{
    public class JsonDateConverter : JsonConverter<(string Year, string Month, string Day)>
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
            writer.WriteStringValue($"{value.Year}-{value.Month}-{value.Day}");
        }
    }
}
