using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Library.Core.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace Library.Core.Interfaces.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooks(
            Expression<Func<Book, bool>> predicate = null,
            Func<IQueryable<Book>, IOrderedQueryable<Book>> orderBy = null,
            Func<IQueryable<Book>, IIncludableQueryable<Book, object>> include = null,
            bool disableTracking = true
            );

        Task<Book> GetBookById(
            Guid id,
            Func<IQueryable<Book>, IIncludableQueryable<Book, object>> include = null,
            bool disableTracking = true
            );

        Task AddBook(Book book);

        Task UpdateBook(Book book);

        Task DeleteBook(Book book);
    }
}