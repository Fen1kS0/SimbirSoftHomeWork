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

        /// <summary>
        /// 1.2 - 5
        /// </summary>
        [HttpPost]
        public ActionResult<IEnumerable<Book>> CreateBook(Book book)
        {
            var author = _mockDb.People.FirstOrDefault(p => p.Id == book.AuthorId);

            if (author == null)
            {
                return BadRequest();
            }

            book.Author = author;
            _mockDb.Books.Add(book);

            return Ok(_mockDb.Books);
        }

        [HttpDelete("{id}")]
        public ActionResult<Book> DeleteBook(Guid id)
        {
            var book = _mockDb.Books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            _mockDb.Books.Remove(book);

            return Ok(book);
        }
    }
}