using System;

namespace BookShop.WebApi.Models
{
    /// <summary>
    /// 1.2 - 2
    /// </summary>
    public class Book
    {
        public Book()
        {
            Id = Guid.NewGuid();
        }
        
        public Guid Id { get; set; }
        
        /// <summary>
        /// 1.2 - 2
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Для поиска автора
        /// </summary>
        public Guid AuthorId { get; set; }
        
        /// <summary>
        /// 1.2 - 2
        /// </summary>
        public Person Author { get; set; }

        /// <summary>
        /// 1.2 - 2
        /// </summary>
        public string Genre { get; set; }
    }
}