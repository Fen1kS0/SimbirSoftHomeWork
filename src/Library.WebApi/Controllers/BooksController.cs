using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using BookShop.WebApi.Models;
using Library.WebApi.Convertors;
using Library.WebApi.Data;
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
            if (!_mockDb.People.Exists(a => a.Id == authorId))
                return NotFound();
            
            return Ok(_mockDb.Books.Where(b => b.Author.Id == authorId));
        }

        /// <summary>
        /// 1.2 - 5
        /// 1.2.2 - 2
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

            var options = new JsonSerializerOptions()
            {
                Converters =
                {
                    new BooksResponseJsonConverter()
                }
            };

            var response = JsonSerializer.Serialize(_mockDb.Books, options);

            return Ok(response);
        }
        
        /// <summary>
        /// 1.2 - 6
        /// </summary>
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