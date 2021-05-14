using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Core.Models;

namespace Library.Core.Interfaces.Repositories
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAuthors();

        Task<Author> GetAuthorById(Guid id);

        Task AddAuthor(Author author);

        Task UpdateAuthor(Author author);

        Task DeleteAuthor(Author author);
    }
}