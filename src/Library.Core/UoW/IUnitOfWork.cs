using System.Threading.Tasks;

namespace Library.Core.UoW
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();

        TRepository GetRepository<TRepository>();
    }
}