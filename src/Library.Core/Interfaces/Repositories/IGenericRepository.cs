using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Library.Core.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace Library.Core.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IReadOnlyCollection<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true
        );

        Task<TEntity> GetEntityByIdAsync(
            Guid id,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true
        );
        
        Task AddEntityAsync(TEntity entity);
        
        Task UpdateEntityAsync(TEntity entity);
        
        Task DeleteEntityAsync(TEntity entity);
    }
}