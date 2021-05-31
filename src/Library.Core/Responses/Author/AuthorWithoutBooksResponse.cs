using System;

namespace Library.Core.Responses.Author
{
    public class AuthorWithoutBooksResponse
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }
    }
}