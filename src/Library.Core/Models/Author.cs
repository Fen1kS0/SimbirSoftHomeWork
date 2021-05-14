using System;
using System.Collections.Generic;

namespace Library.Core.Models
{
    /// <summary>
    /// 1.2 - 2
    /// 1.2.2 - 1
    /// </summary>
    public class Author
    {
        public Guid Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string MiddleName { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}