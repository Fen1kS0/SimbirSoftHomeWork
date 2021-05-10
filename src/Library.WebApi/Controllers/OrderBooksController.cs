using System;
using System.Collections.Generic;
using Library.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Controllers
{
    /// <summary>
    /// 1.2.1 - 2
    /// 1.2.1 - 4
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class OrderBooksController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<OrderBook>> GetAllOrder()
        {
            return Ok();
        }

        /// <summary>
        /// 1.2.1 - 4
        /// </summary>
        [HttpPost]
        public ActionResult<IEnumerable<OrderBook>> CreateOrderBook(OrderBook orderBook)
        {
            return Ok();
        }
    }
}