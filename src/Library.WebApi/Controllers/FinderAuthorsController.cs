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
    public class FinderAuthorsController : ControllerBase
    {
        private readonly IFinderAuthorsService _finderAuthorsService;

        public FinderAuthorsController(IFinderAuthorsService finderAuthorsService)
        {
            _finderAuthorsService = finderAuthorsService;
        }

        [HttpGet("bookRealiseDate")]
        public async Task<ActionResult<IEnumerable<AuthorWithoutBooksResponse>>> GetAuthorsByRealiseDateBook(
            [FromQuery] int year,
            [FromQuery] SortMode sortMode
            )
        {
            var response = await _finderAuthorsService.GetAuthorsByRealiseDateBook(year, sortMode);

            return Ok(response);
        }
        
        [HttpGet("substringBookName")]
        public async Task<ActionResult<IEnumerable<AuthorWithoutBooksResponse>>> FindAuthorBySubstringBookName(
            [FromQuery] string substring
            )
        {
            var response = await _finderAuthorsService.FindAuthorBySubstringBookName(substring);

            return Ok(response);
        }
    }
}