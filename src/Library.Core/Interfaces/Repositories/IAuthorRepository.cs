using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Library.Core.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace Library.Core.Interfaces.Repositories
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAuthors(
            Expression<Func<Author, bool>> predicate = null,
            Func<IQueryable<Author>, IOrderedQueryable<Author>> orderBy = null,
            Func<IQueryable<Author>, IIncludableQueryable<Author, object>> include = null,
            bool disableTracking = true
            );

        Task<Author> GetAuthorById(
            Guid id,
            Func<IQueryable<Author>, IIncludableQueryable<Author, object>> include = null,
            bool disableTracking = true
            );

        Task AddAuthor(Author author);

        Task UpdateAuthor(Author author);

        Task DeleteAuthor(Author author);
    }
}