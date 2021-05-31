using System;
using System.Collections.Generic;
using Library.Core.Responses.Book;

namespace Library.Core.Responses.Genre
{
    public class GenreResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<BookResponse> Books { get; set; }
    }
}