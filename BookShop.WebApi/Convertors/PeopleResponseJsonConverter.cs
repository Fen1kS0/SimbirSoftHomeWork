using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using BookShop.WebApi.Models;

namespace BookShop.WebApi.Convertors
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
            
            writer.WriteString(nameof(Person.Name).ToLowerInvariant(), value.Name);
            writer.WriteString(nameof(Person.Surname).ToLowerInvariant(), value.Surname);
            writer.WriteString(nameof(Person.Patronymic).ToLowerInvariant(), value.Patronymic);
            
            writer.WriteEndObject();
        }
    }
}