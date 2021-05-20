using System;
using System.Collections.Generic;

namespace Library.Core.Entities
{
    /// <summary>
    /// 1.2 - 2
    /// 1.2.2 - 1
    /// </summary>
    public class Author : BaseEntity
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string MiddleName { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}