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
    public class GenreRepository : IGenreRepository
    {
        private readonly IGenericRepository<Genre> _genericRepository;

        public GenreRepository(LibraryDbContext context)
        {
            _genericRepository = new GenericRepository<Genre>(context.Genres);
        }

        public async Task<IEnumerable<Genre>> GetAllGenres(
            Expression<Func<Genre, bool>> predicate = null, 
            Func<IQueryable<Genre>, IOrderedQueryable<Genre>> orderBy = null, 
            Func<IQueryable<Genre>, IIncludableQueryable<Genre, object>> include = null, 
            bool disableTracking = true
            )
        {
            return await _genericRepository.GetAllAsync(predicate, orderBy, include, disableTracking);
        }

        public async Task<Genre> GetGenreById(
            Guid id, 
            Func<IQueryable<Genre>, IIncludableQueryable<Genre, object>> include = null,
            bool disableTracking = true
            )
        {
            return await _genericRepository.GetEntityByIdAsync(id, include, disableTracking);
        }

        public async Task AddGenre(Genre genre)
        {
            await _genericRepository.AddEntityAsync(genre);
        }

        public async Task UpdateGenre(Genre genre)
        {
            await _genericRepository.UpdateEntityAsync(genre);
        }

        public async Task DeleteGenre(Genre genre)
        {
            await _genericRepository.DeleteEntityAsync(genre);
        }
    }
}