using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Core.Requests.Author;
using Library.Core.Requests.Book;
using Library.Core.Responses.Book;

namespace Library.Core.Interfaces.Services
{
    public interface IBookService
    {
        Task<BookResponse> AddBook(BookAddRequest bookAddRequest);

        Task<BookResponse> DeleteBook(Guid id);

        Task<BookResponse> UpdateGenres(BookUpdateGenresRequest bookUpdateGenresRequest);

        Task<IEnumerable<BookResponse>> GetBooksByAuthor(AuthorFioRequest authorFioRequest);
        
        Task<IEnumerable<BookResponse>> GetBooksByGenre(Guid genreId);
    }
}