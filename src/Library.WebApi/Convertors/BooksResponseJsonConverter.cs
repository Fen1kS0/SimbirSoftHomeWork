using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Library.WebApi.Models;

namespace Library.WebApi.Convertors
{
    /// <summary>
    /// 1.2.2 - 2
    /// </summary>
    public class BooksResponseJsonConverter : JsonConverter<Book>
    {
        public override Book Read(
            ref Utf8JsonReader reader, 
            Type typeToConvert, 
            JsonSerializerOptions options
            )
        {
            throw new InvalidOperationException();
        }

        public override void Write(
            Utf8JsonWriter writer, 
            Book value, 
            JsonSerializerOptions options
            )
        {
            writer.WriteStartObject();
            
            writer.WriteString(nameof(Book.Title).ToLowerInvariant(), value.Title);
            writer.WriteString("authorName", value.Author.Name);
            
            writer.WriteEndObject();
        }
    }
}