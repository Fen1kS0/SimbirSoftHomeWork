using System;
using System.Collections.Generic;
using Library.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Controllers
{
    /// <summary>
    /// 1.2 - 3,
    /// 1.2 - 4
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        /// <summary>
        /// 1.2 - 4.a
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            return Ok();
        }
        
        /// <summary>
        /// 1.2 - 4.b
        /// </summary>
        [HttpGet("author/{authorId}")]
        public ActionResult<IEnumerable<Book>> GetBooksByAuthor(Guid authorId)
        {
            return Ok();
        }

        /// <summary>
        /// 1.2 - 5
        /// 1.2.2 - 2
        /// </summary>
        [HttpPost]
        public ActionResult<IEnumerable<Book>> CreateBook(Book book)
        {
            return Ok();
        }
        
        /// <summary>
        /// 1.2 - 6
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult<Book> DeleteBook(Guid id)
        {
            return Ok();
        }
    }
}