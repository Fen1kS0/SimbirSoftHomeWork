using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Core.Enums;
using Library.Core.Interfaces.Services;
using Library.Core.Responses.Author;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FindAuthorsController : ControllerBase
    {
        private readonly IFindAuthorsService _findAuthorsService;

        public FindAuthorsController(IFindAuthorsService findAuthorsService)
        {
            _findAuthorsService = findAuthorsService;
        }

        [HttpGet("bookRealiseDate")]
        public async Task<ActionResult<IEnumerable<AuthorWithoutBooksResponse>>> GetAuthorsByRealiseDateBook(
            [FromQuery] int year,
            [FromQuery] SortMode sortMode
            )
        {
            var response = await _findAuthorsService.GetAuthorsByRealiseDateBook(year, sortMode);

            return Ok(response);
        }
        
        [HttpGet("substringBookName")]
        public async Task<ActionResult<IEnumerable<AuthorWithoutBooksResponse>>> FindAuthorBySubstringBookName(
            [FromQuery] string substring
            )
        {
            var response = await _findAuthorsService.FindAuthorBySubstringBookName(substring);

            return Ok(response);
        }
    }
}