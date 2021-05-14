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
        public Guid Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string MiddleName { get; set; }
        
        public DateTime BirthDate { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}