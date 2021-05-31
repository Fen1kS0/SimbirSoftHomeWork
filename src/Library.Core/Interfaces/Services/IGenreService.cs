using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Core.Requests.Genre;
using Library.Core.Responses.Book;
using Library.Core.Responses.Genre;

namespace Library.Core.Interfaces.Services
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreWithoutBooksResponse>> GetAllGenres();

        Task<GenreResponse> AddGenre(GenreAddRequest genreAddRequest);
        
        Task<BookCountResponse> GetCountBooks(Guid genreId);
    }
}