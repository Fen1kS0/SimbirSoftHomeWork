using System;
using System.Collections.Generic;
using System.Linq;
using BookShop.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.WebApi.Controllers
{
    /// <summary>
    /// 1.2 - 3,
    /// 1.2 - 4
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly MockDb _mockDb;

        public BooksController(MockDb mockDb)
        {
            _mockDb = mockDb;
        }

        /// <summary>
        /// 1.2 - 4.a
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            return Ok(_mockDb.Books);
        }
        
        /// <summary>
        /// 1.2 - 4.b
        /// </summary>
        [HttpGet("author/{authorId}")]
        public ActionResult<IEnumerable<Book>> GetBooksByAuthor(Guid authorId)
        {
            return Ok(_mockDb.Books.Where(b => b.Author.Id == authorId));
        }
    }
}