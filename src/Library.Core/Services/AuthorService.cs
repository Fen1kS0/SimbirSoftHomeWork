using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Core.Interfaces.Services;
using Library.Core.Requests.Author;
using Library.Core.Responses.Author;
using Library.Core.Responses.Book;

namespace Library.Core.Services
{
    public class AuthorService : IAuthorService
    {
        public async Task<IEnumerable<AuthorWithoutBooksResponse>> GetAllAuthors()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BookResponse>> GetBooksByAuthor(Guid authorId)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthorResponse> AddAuthor(AuthorAddRequest authorAddRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthorResponse> DeleteAuthor(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}