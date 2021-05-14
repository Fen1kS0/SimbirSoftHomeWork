using System;

namespace Library.Core.Requests.Book
{
    public class BookAddRequest
    {
        public string Name { get; set; }

        public Guid AuthorId { get; set; }
    }
}