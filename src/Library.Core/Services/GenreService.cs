using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Core.Interfaces.Services;
using Library.Core.Requests.Genre;
using Library.Core.Responses.Book;
using Library.Core.Responses.Genre;

namespace Library.Core.Services
{
    public class GenreService : IGenreService
    {
        public async Task<IEnumerable<GenreWithoutBooksResponse>> GetAllGenres()
        {
            throw new NotImplementedException();
        }

        public async Task<GenreResponse> AddGenre(GenreAddRequest genreAddRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<BookCountResponse> GetCountBooks(Guid genreId)
        {
            throw new NotImplementedException();
        }
    }
}