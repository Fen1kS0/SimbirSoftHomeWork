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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IGenericRepository<Author> _genericRepository;

        public AuthorRepository(LibraryDbContext context)
        {
            _genericRepository = new GenericRepository<Author>(context.Authors);
        }

        public async Task<IEnumerable<Author>> GetAllAuthors(
            Expression<Func<Author, bool>> predicate = null, 
            Func<IQueryable<Author>, IOrderedQueryable<Author>> orderBy = null, 
            Func<IQueryable<Author>, IIncludableQueryable<Author, object>> include = null, 
            bool disableTracking = true
            )
        {
            return await _genericRepository.GetAllAsync(predicate, orderBy, include, disableTracking);
        }

        public async Task<Author> GetAuthorById(
            Guid id, 
            Func<IQueryable<Author>, IIncludableQueryable<Author, object>> include = null, 
            bool disableTracking = true
            )
        {
            return await _genericRepository.GetEntityByIdAsync(id, include, disableTracking);
        }

        public async Task AddAuthor(Author author)
        {
            await _genericRepository.AddEntityAsync(author);
        }

        public async Task UpdateAuthor(Author author)
        {
            await _genericRepository.UpdateEntityAsync(author);
        }

        public async Task DeleteAuthor(Author author)
        {
            await _genericRepository.DeleteEntityAsync(author);
        }
    }
}