using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Library.Core.Entities;
using Library.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Library.Infrastructure.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(DbSet<TEntity> dbSet)
        {
            _dbSet = dbSet;
        }
        
        public async Task<IReadOnlyCollection<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true
            )
        {
            IQueryable<TEntity> query = _dbSet.AsSingleQuery();
            
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetEntityByIdAsync(
            Guid id,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true
            )
        {
            IQueryable<TEntity> query = _dbSet.AsSingleQuery();
            
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }
            
            if (include != null)
            {
                query = include(query);
            }
            
            return await query.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddEntityAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task UpdateEntityAsync(TEntity entity)
        {
            await Task.Run(() =>
            {
                entity.LastUpdateRecordDate = DateTimeOffset.Now;
                entity.Version++;
                
                _dbSet.Update(entity);
            });
        }

        public async Task DeleteEntityAsync(TEntity entity)
        {
            await Task.Run(() =>
            {
                _dbSet.Remove(entity);
            });
        }
    }
}
