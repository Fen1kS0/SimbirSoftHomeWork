using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Core.Interfaces.Services;
using Library.Core.Models;
using Library.Core.Requests.Author;
using Library.Core.Requests.Book;
using Library.Core.Responses.Book;
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
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        
        /// <summary>
        /// 1.2 - 4.a
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks()
        {
            var response = await _bookService.GetAllBooks();

            return Ok(response);
        }

        /// <summary>
        /// 1.2 - 5
        /// 1.2.2 - 2
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<BookResponse>> AddBook(BookAddRequest bookAddRequest)
        {
            var response = await _bookService.AddBook(bookAddRequest);

            return Ok(response);
        }

        /// <summary>
        /// 1.2 - 6
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookResponse>> DeleteBook(Guid id)
        {
            var response = await _bookService.DeleteBook(id);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BookResponse>> UpdateGenres(Guid id, BookUpdateGenresRequest bookUpdateGenresRequest)
        {
            var response = await _bookService.UpdateGenres(id, bookUpdateGenresRequest);

            return Ok(response);
        }

        /// <summary>
        /// 1.2 - 4.b
        /// </summary>
        [HttpGet("author/{authorId}")]
        public async Task<ActionResult<IEnumerable<BookResponse>>> GetBooksByAuthor(AuthorFioRequest authorFioRequest)
        {
            var response = await _bookService.GetBooksByAuthor(authorFioRequest);

            return Ok(response);
        }

        [HttpGet("genre/{genreId}")]
        public async Task<ActionResult<IEnumerable<BookResponse>>> GetBooksByGenre(Guid genreId)
        {
            var response = await _bookService.GetBooksByGenre(genreId);

            return Ok(response);
        }
    }
}