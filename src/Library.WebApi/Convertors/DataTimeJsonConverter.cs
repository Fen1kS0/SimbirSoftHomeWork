using System;
using System.Globalization;
using Newtonsoft.Json;

namespace Library.WebApi.Convertors
{
    /// <summary>
    /// 1.2.1 - 4
    /// </summary>
    public class DateTimeJsonConverter : JsonConverter<DateTime>
    {
        public override void WriteJson(
            JsonWriter writer, 
            DateTime value, 
            JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString(
                "yyyy-MM-dd", CultureInfo.InvariantCulture));
        }

        public override DateTime ReadJson(
            JsonReader reader,
            Type objectType, 
            DateTime existingValue, 
            bool hasExistingValue,
            JsonSerializer serializer
            )
        {
            return DateTime.ParseExact((string) reader.Value,
                "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }
    }
}