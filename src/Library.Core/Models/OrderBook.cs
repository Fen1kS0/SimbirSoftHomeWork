using System;

namespace Library.Core.Models
{
    /// <summary>
    /// 1.2.1 - 1
    /// </summary>
    public class OrderBook
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid BookId { get; set; }

        /// <summary>
        /// 1.2.1 - 1
        /// </summary>
        public Book Book { get; set; }

        public Guid BuyerId { get; set; }

        /// <summary>
        /// 1.2.1 - 1
        /// </summary>
        public Person Person { get; set; }

        /// <summary>
        /// 1.2.1 - 1
        /// </summary>
        public DateTimeOffset TimeGetBook { get; set; }
    }
}