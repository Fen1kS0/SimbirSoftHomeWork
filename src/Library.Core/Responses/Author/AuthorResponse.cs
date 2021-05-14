using System;
using System.Collections.Generic;
using Library.Core.Responses.Book;

namespace Library.Core.Responses.Author
{
    public class AuthorResponse
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public ICollection<BookResponse> Books { get; set; }
    }
}