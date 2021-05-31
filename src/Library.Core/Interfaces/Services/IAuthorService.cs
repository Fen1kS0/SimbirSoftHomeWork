using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Core.Requests.Author;
using Library.Core.Responses.Author;
using Library.Core.Responses.Book;

namespace Library.Core.Interfaces.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorWithoutBooksResponse>> GetAllAuthors();
        
        Task<IEnumerable<BookResponse>> GetBooksByAuthor(Guid authorId);

        Task<AuthorResponse> AddAuthor(AuthorAddRequest authorAddRequest);

        Task<AuthorResponse> DeleteAuthor(Guid id);
    }
}