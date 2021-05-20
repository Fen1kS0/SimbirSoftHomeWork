using System;

namespace Library.Core.Entities
{
    /// <summary>
    /// 1.2.1 - 1
    /// </summary>
    public class LibraryCard
    {
        public Guid Id { get; set; }

        public Guid BookId { get; set; }
        
        public Book Book { get; set; }

        public Guid PersonId { get; set; }
        
        public Person Person { get; set; }
        
        public DateTimeOffset TimeGetBook { get; set; }
    }
}