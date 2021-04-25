using System;

namespace BookShop.WebApi.Models
{
    /// <summary>
    /// 1.2.1 - 1
    /// </summary>
    public class OrderBook
    {
        public OrderBook()
        {
            Id = new Guid();
        }
        
        public Guid Id { get; set; }

        /// <summary>
        /// 1.2.1 - 1
        /// </summary>
        public Book Book { get; set; }

        /// <summary>
        /// 1.2.1 - 1
        /// </summary>
        public Person Buyer { get; set; }

        /// <summary>
        /// 1.2.1 - 1
        /// </summary>
        public DateTime DateTimeOffset { get; set; }
    }
}