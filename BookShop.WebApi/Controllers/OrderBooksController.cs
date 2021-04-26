using System;
using System.Collections.Generic;
using System.Linq;
using BookShop.WebApi.Data;
using BookShop.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.WebApi.Controllers
{
    /// <summary>
    /// 1.2.1 - 2
    /// 1.2.1 - 4
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class OrderBooksController : ControllerBase
    {
        private readonly MockDb _mockDb;

        public OrderBooksController(MockDb mockDb)
        {
            _mockDb = mockDb;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderBook>> GetAllOrder()
        {
            return Ok(_mockDb.OrderBooks);
        }

        /// <summary>
        /// 1.2.1 - 4
        /// </summary>
        [HttpPost]
        public ActionResult<IEnumerable<OrderBook>> CreateOrderBook(OrderBook orderBook)
        {
            var book = _mockDb.Books.FirstOrDefault(b => b.Id == orderBook.BookId);
            var buyer = _mockDb.People.FirstOrDefault(p => p.Id == orderBook.BuyerId);

            if (book == null || buyer == null)
            {
                return BadRequest();
            }

            orderBook.Book = book;
            orderBook.Buyer = buyer;
            orderBook.TimeGetBook = DateTimeOffset.Now;

            _mockDb.OrderBooks.Add(orderBook);

            return Ok(_mockDb.OrderBooks);
        }
    }
}