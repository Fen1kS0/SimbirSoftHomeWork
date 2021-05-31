using System;
using System.Collections.Generic;

namespace Library.Core.Requests.Book
{
    public class BookUpdateGenresRequest
    {
        public IEnumerable<Guid> GenresId { get; set; }
    }
}