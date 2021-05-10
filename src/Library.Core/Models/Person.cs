using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Core.Models
{
    /// <summary>
    /// 1.2 - 2
    /// 1.2.2 - 1
    /// </summary>
    public class Person
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        
        /// <summary>
        /// 1.2 - 2
        /// 1.2.2 - 1
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// 1.2 - 2
        /// 1.2.2 - 1
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// 1.2 - 2
        /// 1.2.2 - 1
        /// </summary>
        [Required]
        public string MiddleName { get; set; }

        /// <summary>
        /// 1.2 - 2
        /// </summary>
        public DateTime BirthDate { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}