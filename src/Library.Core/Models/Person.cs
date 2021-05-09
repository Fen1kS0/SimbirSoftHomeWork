using System;
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
        public string Name { get; set; }

        /// <summary>
        /// 1.2 - 2
        /// 1.2.2 - 1
        /// </summary>
        [Required]
        public string Surname { get; set; }

        /// <summary>
        /// 1.2 - 2
        /// 1.2.2 - 1
        /// </summary>
        [Required]
        public string Patronymic { get; set; }

        /// <summary>
        /// 1.2 - 2
        /// </summary>
        public DateTime BirthDate { get; set; }
    }
}