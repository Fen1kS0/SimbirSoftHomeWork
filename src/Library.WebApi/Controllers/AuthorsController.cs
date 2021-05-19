using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Core.Interfaces.Services;
using Library.Core.Requests.Author;
using Library.Core.Responses.Author;
using Library.Core.Responses.Book;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        
        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorWithoutBooksResponse>>> GetAllAuthors()
        {
            var response = await _authorService.GetAllAuthors();

            return Ok(response);
        }

        [HttpGet("{authorId}/books")]
        public async Task<ActionResult<IEnumerable<BookResponse>>> GetBooksByAuthor(Guid authorId)
        {
            var response = await _authorService.GetBooksByAuthor(authorId);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<AuthorResponse>> AddAuthor(AuthorAddRequest authorAddRequest)
        {
            var response = await _authorService.AddAuthor(authorAddRequest);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AuthorResponse>> DeleteAuthor(Guid id)
        {
            var response = await _authorService.DeleteAuthor(id);

            return Ok(response);
        }
    }
}