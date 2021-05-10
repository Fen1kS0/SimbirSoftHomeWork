using System;
using System.Collections.Generic;

namespace Library.Core.Models
{
    public class Author
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        
        /// <summary>
        /// 1.2 - 2
        /// 1.2.2 - 1
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// 1.2 - 2
        /// 1.2.2 - 1
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// 1.2 - 2
        /// 1.2.2 - 1
        /// </summary>
        public string MiddleName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}