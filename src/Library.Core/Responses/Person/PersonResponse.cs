using System;
using System.Collections.Generic;
using Library.Core.Responses.Book;

namespace Library.Core.Responses.Person
{
    public class PersonResponse
    {
        public Guid Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string MiddleName { get; set; }
        
        public DateTime BirthDate { get; set; }

        public IEnumerable<BookResponse> Books { get; set; }
    }
}