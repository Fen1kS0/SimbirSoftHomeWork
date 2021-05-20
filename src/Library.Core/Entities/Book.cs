using System;
using System.Collections.Generic;

namespace Library.Core.Entities
{
    /// <summary>
    /// 1.2 - 2
    /// 1.2.2 - 1
    /// </summary>
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        
        public Guid AuthorId { get; set; }
        
        public Author Author { get; set; }

        public DateTime RealiseDate { get; set; }

        public ICollection<Genre> Genres { get; set; } = new List<Genre>();

        public ICollection<Person> Readers { get; set; } = new List<Person>();
    }
}