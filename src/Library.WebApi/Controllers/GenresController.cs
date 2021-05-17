using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Core.Interfaces.Services;
using Library.Core.Requests.Genre;
using Library.Core.Responses.Book;
using Library.Core.Responses.Genre;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreWithoutBooksResponse>>> GetAllGenres()
        {
            var response = await _genreService.GetAllGenres();

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<GenreResponse>> AddGenre(GenreAddRequest genreAddRequest)
        {
            var response = await _genreService.AddGenre(genreAddRequest);

            return Ok(response);
        }

        [HttpGet("{genreId}/countBooks")]
        public async Task<ActionResult<BookCountResponse>> GetCountBooks(Guid genreId)
        {
            var response = await _genreService.GetCountBooks(genreId);

            return Ok(response);
        }
    }
}