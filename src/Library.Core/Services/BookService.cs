using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Core.Interfaces.Services;
using Library.Core.Requests.Author;
using Library.Core.Requests.Book;
using Library.Core.Responses.Book;

namespace Library.Core.Services
{
    public class BookService : IBookService
    {
        public async Task<BookResponse> AddBook(BookAddRequest bookAddRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<BookResponse> DeleteBook(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<BookResponse> UpdateGenres(BookUpdateGenresRequest bookUpdateGenresRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BookResponse>> GetBooksByAuthor(AuthorFioRequest authorFioRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BookResponse>> GetBooksByGenre(Guid genreId)
        {
            throw new NotImplementedException();
        }
    }
}