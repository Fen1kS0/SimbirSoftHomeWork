using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Core.Entities;

namespace Library.Core.Interfaces.Repositories
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> GetAllGenres();

        Task<Genre> GetGenreById(Guid id);

        Task AddGenre(Genre genre);

        Task UpdateGenre(Genre genre);

        Task DeleteGenre(Genre genre);
        
        Task SaveChanges();
    }
}