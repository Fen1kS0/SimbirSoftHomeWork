using System;
using System.Collections.Generic;

namespace Library.Core.Models
{
    /// <summary>
    /// 1.2 - 2
    /// 1.2.2 - 1
    /// </summary>
    public class Book
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public Guid AuthorId { get; set; }
        
        public Person Author { get; set; }

        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
    }
}