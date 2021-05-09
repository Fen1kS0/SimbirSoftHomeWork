using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Core.Models
{
    /// <summary>
    /// 1.2 - 2
    /// 1.2.2 - 1
    /// </summary>
    public class Book
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        
        /// <summary>
        /// 1.2 - 2
        /// 1.2.2 - 1
        /// </summary>
        [Required]
        public string Title { get; set; }
        
        public Guid AuthorId { get; set; }
        
        /// <summary>
        /// 1.2 - 2
        /// </summary>
        public Person Author { get; set; }

        /// <summary>
        /// 1.2 - 2
        /// 1.2.2 - 1
        /// </summary>
        [Required]
        public string Genre { get; set; }
    }
}