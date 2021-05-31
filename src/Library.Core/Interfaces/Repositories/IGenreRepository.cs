using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Library.Core.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace Library.Core.Interfaces.Repositories
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> GetAllGenres(
            Expression<Func<Genre, bool>> predicate = null,
            Func<IQueryable<Genre>, IOrderedQueryable<Genre>> orderBy = null,
            Func<IQueryable<Genre>, IIncludableQueryable<Genre, object>> include = null,
            bool disableTracking = true
            );

        Task<Genre> GetGenreById(
            Guid id,
            Func<IQueryable<Genre>, IIncludableQueryable<Genre, object>> include = null,
            bool disableTracking = true
            );

        Task AddGenre(Genre genre);

        Task UpdateGenre(Genre genre);

        Task DeleteGenre(Genre genre);
    }
}