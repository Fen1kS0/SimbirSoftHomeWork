using System;
using System.Threading.Tasks;
using Library.Core.UoW;

namespace Library.Infrastructure.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryDbContext _libraryDbContext;
        private readonly IServiceProvider _serviceProvider;

        public UnitOfWork(LibraryDbContext libraryDbContext, IServiceProvider serviceProvider)
        {
            _libraryDbContext = libraryDbContext;
            _serviceProvider = serviceProvider;
        }
        
        public async Task SaveChangesAsync()
        {
            await _libraryDbContext.SaveChangesAsync();
        }

        public TRepository GetRepository<TRepository>()
        {
            return (TRepository) _serviceProvider.GetService(typeof(TRepository));
        }
    }
}