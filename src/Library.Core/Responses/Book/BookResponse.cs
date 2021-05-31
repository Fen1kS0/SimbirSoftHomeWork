using System;
using System.Collections.Generic;
using Library.Core.Responses.Author;
using Library.Core.Responses.Genre;

namespace Library.Core.Responses.Book
{
    public class BookResponse
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public Guid AuthorId { get; set; }
        
        public AuthorResponse Author { get; set; }
        
        public DateTime RealiseDate { get; set; }
        
        public ICollection<GenreResponse> Genres { get; set; }
    }
}