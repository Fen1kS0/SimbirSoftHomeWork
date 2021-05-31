using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Library.Core.Entities;

namespace Library.WebApi.Convertors
{
    /// <summary>
    /// 1.2.2 - 2
    /// </summary>
    public class PeopleResponseJsonConverter : JsonConverter<Person>
    {
        public override Person Read(
            ref Utf8JsonReader reader, 
            Type typeToConvert, 
            JsonSerializerOptions options
            )
        {
            throw new InvalidOperationException();
        }

        public override void Write(
            Utf8JsonWriter writer, 
            Person value, 
            JsonSerializerOptions options
            )
        {
            writer.WriteStartObject();
            
            writer.WriteString(nameof(Person.FirstName).ToLowerInvariant(), value.FirstName);
            writer.WriteString(nameof(Person.LastName).ToLowerInvariant(), value.LastName);
            writer.WriteString(nameof(Person.MiddleName).ToLowerInvariant(), value.MiddleName);
            
            writer.WriteEndObject();
        }
    }
}