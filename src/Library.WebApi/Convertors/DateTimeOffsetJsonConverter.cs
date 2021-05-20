using System;
using System.Globalization;
using Newtonsoft.Json;

namespace Library.WebApi.Convertors
{
    /// <summary>
    /// 1.2.1 - 4
    /// </summary>
    public class DateTimeOffsetJsonConverter : JsonConverter<DateTimeOffset>
    {
        public override void WriteJson(
            JsonWriter writer, 
            DateTimeOffset value, 
            JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString(
                "yyyy-MM-ddTHH:mm:ss.fffzzz", CultureInfo.InvariantCulture));
        }

        public override DateTimeOffset ReadJson(
            JsonReader reader,
            Type objectType, 
            DateTimeOffset existingValue, 
            bool hasExistingValue,
            JsonSerializer serializer
        )
        {
            return DateTime.ParseExact((string) reader.Value,
                "yyyy-MM-ddTHH:mm:ss.fffzzz", CultureInfo.InvariantCulture);
        }
    }
}