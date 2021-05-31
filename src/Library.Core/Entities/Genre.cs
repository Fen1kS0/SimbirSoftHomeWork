using System;
using System.Collections.Generic;

namespace Library.Core.Entities
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}