using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BookShop.WebApi.Convertors
{
    /// <summary>
    /// 1.2.1 - 4
    /// </summary>
    public class DateTimeOffsetJsonConverter : JsonConverter<DateTimeOffset>
    {
        public override DateTimeOffset Read(
            ref Utf8JsonReader reader, 
            Type typeToConvert, 
            JsonSerializerOptions options
            )
        {
            return DateTimeOffset.ParseExact(reader.GetString(),
                "yyyy-MM-ddTHH:mm:ss.fffzzz", CultureInfo.InvariantCulture);
        }

        public override void Write(
            Utf8JsonWriter writer, 
            DateTimeOffset value, 
            JsonSerializerOptions options
            )
        {
            writer.WriteStringValue(value.ToString(
                "yyyy-MM-ddTHH:mm:ss.fffzzz", CultureInfo.InvariantCulture));
        }
    }
}