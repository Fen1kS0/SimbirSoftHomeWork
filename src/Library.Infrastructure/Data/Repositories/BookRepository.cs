using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Library.Core.Entities;
using Library.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Query;

namespace Library.Infrastructure.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IGenericRepository<Book> _genericRepository;

        public BookRepository(LibraryDbContext context)
        {
            _genericRepository = new GenericRepository<Book>(context.Books);
        }
        
        public async Task<IEnumerable<Book>> GetAllBooks(
            Expression<Func<Book, bool>> predicate = null, 
            Func<IQueryable<Book>, IOrderedQueryable<Book>> orderBy = null, 
            Func<IQueryable<Book>, IIncludableQueryable<Book, object>> include = null, 
            bool disableTracking = true
            )
        {
            return await _genericRepository.GetAllAsync(predicate, orderBy, include, disableTracking);
        }

        public async Task<Book> GetBookById(
            Guid id, 
            Func<IQueryable<Book>, IIncludableQueryable<Book, object>> include = null, 
            bool disableTracking = true
            )
        {
            return await _genericRepository.GetEntityByIdAsync(id, include, disableTracking);
        }

        public async Task AddBook(Book book)
        {
            await _genericRepository.AddEntityAsync(book);
        }

        public async Task UpdateBook(Book book)
        {
            await _genericRepository.UpdateEntityAsync(book);
        }

        public async Task DeleteBook(Book book)
        {
            await _genericRepository.DeleteEntityAsync(book);
        }
    }
}