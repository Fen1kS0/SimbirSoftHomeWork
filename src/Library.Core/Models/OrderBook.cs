using System;

namespace Library.Core.Models
{
    /// <summary>
    /// 1.2.1 - 1
    /// </summary>
    public class OrderBook
    {
        public Guid Id { get; set; }

        public Guid BookId { get; set; }
        
        public Book Book { get; set; }

        public Guid BuyerId { get; set; }
        
        public Person Person { get; set; }
        
        public DateTimeOffset TimeGetBook { get; set; }
    }
}